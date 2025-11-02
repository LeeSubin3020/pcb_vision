using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using OpenCvSharp;
using OpenCvSharp.Dnn;
using OpenCvSharp.XImgProc;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Windows.Forms;

namespace PCBVison.Models
{
    public class PcbModel
    {
        private readonly InferenceSession session;

        private readonly string[] labels = new string[]
        {
            "A1", "AMS-1117", "CH340G", "S4"
        };

        private readonly Scalar[] colors = new Scalar[]
        {
            Scalar.Red, Scalar.Blue, Scalar.Green, Scalar.Yellow,
            Scalar.Cyan
        };

        public Scalar[] Colors => colors;

        private const float confidenceThreshold = 0.01f; // 신뢰도 임계값(지정값 이상일때만 객체로 인식)
        private const float nmsThreshold = 0.1f;  // NMS 임계값 (이 값 이상 겹치는 박스는 하나로 합침)

        public PcbModel(string modelPath)
        {
            // ✅ DirectML GPU 사용 옵션
            var options = new SessionOptions();
            // options.AppendExecutionProvider_DML();

            session = new InferenceSession(modelPath, options);
        }

        public List<DetectionResult> Predict(Mat frame)
        {
            List<DetectionResult> results = new List<DetectionResult>();

            int originalWidth = frame.Width;
            int originalHeight = frame.Height;

            // ==========================
            // 1️⃣ 이미지 전처리
            // ==========================
            Mat resized = new Mat();
            Cv2.Resize(frame, resized, new OpenCvSharp.Size(896, 896));

            if (resized.Channels() == 1)
                Cv2.CvtColor(resized, resized, ColorConversionCodes.GRAY2BGR);

            Cv2.CvtColor(resized, resized, ColorConversionCodes.BGR2RGB);

            float[] imgData = new float[3 * 896 * 896];
            int idx = 0;
            for (int c = 0; c < 3; c++)
                for (int y = 0; y < 896; y++)
                    for (int x = 0; x < 896; x++)
                        imgData[idx++] = resized.At<Vec3b>(y, x)[c] / 255.0f;

            var tensor = new DenseTensor<float>(imgData, new int[] { 1, 3, 896, 896 });
            var inputs = new List<NamedOnnxValue> { NamedOnnxValue.CreateFromTensor("images", tensor) };

            using (var output = session.Run(inputs))
            {
                var outputTensor = output.First().AsTensor<float>();
                var dims = outputTensor.Dimensions.ToArray(); // [1, 13, 8400] 예상

                int numChannels = dims[1];  // 13
                int numProposals = dims[2]; // 8400
                int numClasses = numChannels - 5; // 9개 클래스

                List<Rect> boxes = new List<Rect>();
                List<float> confidences = new List<float>();
                List<int> classIds = new List<int>();

                // ==========================
                // 2️⃣ 각 detection 후보 처리
                // ==========================
                for (int i = 0; i < numProposals; i++)
                {
                    // 올바른 축 접근 순서 [0, channel, proposal]
                    float x = outputTensor[0, 0, i];
                    float y = outputTensor[0, 1, i];
                    float w = outputTensor[0, 2, i];
                    float h = outputTensor[0, 3, i];
                    float objConf = outputTensor[0, 4, i];

                    // 클래스 확률 중 최대값 찾기
                    float maxProb = 0f;
                    int clsId = -1;
                    for (int c = 0; c < numClasses; c++)
                    {
                        float classProb = outputTensor[0, 5 + c, i];
                        if (classProb > maxProb)
                        {
                            maxProb = classProb;
                            clsId = c;
                        }
                    }

                    float confidence = objConf * maxProb;
                    if (confidence < confidenceThreshold || clsId < 0) continue;

                    float xScale = (float)originalWidth / 896f;
                    float yScale = (float)originalHeight / 896f;

                    int left = (int)((x - w / 2) * xScale);
                    int top = (int)((y - h / 2) * yScale);
                    int width = (int)(w * xScale);
                    int height = (int)(h * yScale);

                    // 좌표 클램핑
                    left = Math.Max(0, Math.Min(left, originalWidth - 1));
                    top = Math.Max(0, Math.Min(top, originalHeight - 1));
                    width = Math.Max(1, Math.Min(width, originalWidth - left));
                    height = Math.Max(1, Math.Min(height, originalHeight - top));

                    boxes.Add(new Rect(left, top, width, height));
                    confidences.Add(confidence);
                    classIds.Add(clsId);

                }

                // ==========================
                // 3️⃣ NMS (중복 박스 제거)
                // ==========================
                if (boxes.Count > 0)
                {
                    int[] indices;
                    CvDnn.NMSBoxes(boxes.ToArray(), confidences.ToArray(), confidenceThreshold, nmsThreshold, out indices);

                    foreach (int idxNms in indices)
                    {
                        int clsIndex = classIds[idxNms];
                        results.Add(new DetectionResult
                        {
                            Rect = boxes[idxNms],
                            Label = labels[clsIndex],
                            Confidence = confidences[idxNms],
                            LabelIndex = clsIndex
                        });

                    }
                }
            }

            return results;
        }



        public InspectionResult AnalyzeResults(List<DetectionResult> results)
        {
            var result = new InspectionResult();

            result.Total = results.Count;
            result.Pass = results.Count(r => r.Confidence > 0.02f);
            result.Fail = result.Total - result.Pass;

            return result;
        }

        public class DetectionResult
        {
            public Rect Rect { get; set; }
            public string Label { get; set; }
            public float Confidence { get; set; }
            public int LabelIndex { get; set; }
        }

        // 검사율
        public class InspectionResult
        {
            public int Total { get; set; }
            public int Pass { get; set; }
            public int Fail { get; set; }
        }
    }
}

