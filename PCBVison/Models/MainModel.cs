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
            "Audio Port", "Camera Port", "Display", "GPIO", "Hdmi Port",
            "LAN Port", "MCU Chip", "USB Port", "charging Port"
        };

        private readonly Scalar[] colors = new Scalar[]
        {
            Scalar.Red, Scalar.Blue, Scalar.Green, Scalar.Yellow,
            Scalar.Cyan, Scalar.Magenta, Scalar.Orange, Scalar.Pink,
            Scalar.Brown, Scalar.Lime
        };

        private const float confidenceThreshold = 0.05f; // 신뢰도 임계값(지정값 이상일때만 객체로 인식)
        private const float nmsThreshold = 0.4f;  // NMS 임계값 (이 값 이상 겹치는 박스는 하나로 합침)

        public PcbModel(string modelPath)
        {
            session = new InferenceSession(modelPath);
        }

        public List<DetectionResult> Predict(Mat frame)
        {
            List<DetectionResult> results = new List<DetectionResult>();

            int originalWidth = frame.Width;
            int originalHeight = frame.Height;

            float xFactor = originalWidth / 640f;
            float yFactor = originalHeight / 640f;

            // 이미지 전처리
            Mat resized = new Mat();
            Cv2.Resize(frame, resized, new OpenCvSharp.Size(640, 640));

            // Ensure the image is 3 channels (BGR) before further processing
            if (resized.Channels() == 1)
            {
                Cv2.CvtColor(resized, resized, ColorConversionCodes.GRAY2BGR);
            }

            Cv2.CvtColor(resized, resized, ColorConversionCodes.BGR2RGB);

            float[] imgData = new float[3 * 640 * 640];
            int idx = 0;
            for (int c = 0; c < 3; c++)
                for (int y = 0; y < 640; y++)
                    for (int x = 0; x < 640; x++)
                        imgData[idx++] = resized.At<Vec3b>(y, x)[c] / 255.0f;

            var tensor = new DenseTensor<float>(imgData, new int[] { 1, 3, 640, 640 });
            var inputs = new List<NamedOnnxValue> { NamedOnnxValue.CreateFromTensor("images", tensor) };

            using (var output = session.Run(inputs))
            {
                var outputTensor = output.First().AsTensor<float>();

                // The output of YOLOv8 is often [1, 8400, 84]
                // where 8400 is the number of detections, and 84 is [x, y, w, h, class_0, ..., class_79]
                const int numProposals = 8400;

                List<Rect> boxes = new List<Rect>();
                List<float> confidences = new List<float>();
                List<int> classIds = new List<int>();

                for (int i = 0; i < numProposals; i++)
                {
                    float x = outputTensor[0, 0, i];
                    float y = outputTensor[0, 1, i];
                    float w = outputTensor[0, 2, i];
                    float h = outputTensor[0, 3, i];
                    float objectConfidence = outputTensor[0, 4, i];

                    // 클래스 확률 중 최대값 찾기
                    float maxProb = 0f;
                    int clsId = -1;


                    int numClasses = outputTensor.Dimensions[1] - 5;
                    for (int c = 0; c < numClasses; c++)
                    {
                        float classProb = outputTensor[0, 5 + c, i];
                        if (classProb > maxProb)
                        {
                            maxProb = classProb;
                            clsId = c;
                        }
                    }

                    float confidence = objectConfidence * maxProb;

                    if (confidence > confidenceThreshold)
                    {
                        int left = (int)((x - w / 2) * 640);  // 640 = resized width
                        int top = (int)((y - h / 2) * 640);
                        int width = (int)(w * 640);
                        int height = (int)(h * 640);

                        Console.WriteLine($"Box {i}: left={left}, top={top}, w={width}, h={height}, conf={confidence:F3}");

                        boxes.Add(new Rect(left, top, width, height));
                        confidences.Add(confidence);
                        classIds.Add(clsId);
                    }

                }


                if (boxes.Count > 0)
                {
                    int[] indices;
                    CvDnn.NMSBoxes(boxes.ToArray(), confidences.ToArray(), confidenceThreshold, nmsThreshold, out indices);

                    foreach (int idxNms in indices)
                    {
                        int clsIndex = classIds[idxNms];
                        if (clsIndex >= 0 && clsIndex < labels.Length)
                        {
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
            }


            return results;
        }
    }

    public class DetectionResult
    {
        public Rect Rect { get; set; }
        public string Label { get; set; }
        public float Confidence { get; set; }

        public int LabelIndex { get; set; }
    }
}

