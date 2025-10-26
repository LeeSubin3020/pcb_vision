using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PCBVison.Models
{
    public class PcbModel
    {
        private readonly InferenceSession session;

        public PcbModel(string modelPath)
        {
            session = new InferenceSession(modelPath);
        }

        public List<DetectionResult> Predict(Mat frame)
        {
            List<DetectionResult> results = new List<DetectionResult>();

            // 1️⃣ 이미지 전처리
            Mat resized = new Mat();
            Cv2.Resize(frame, resized, new OpenCvSharp.Size(640, 640));
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
                // YOLOv8 ONNX 출력 텐서 가져오기
                var outputTensor = output.First().AsTensor<float>();
                var outputArray = outputTensor.ToArray();

                int numDetections = outputArray.Length / 85; // YOLOv8 기준: 85 = 4(xywh)+1(conf)+80(class)
                for (int i = 0; i < numDetections; i++)
                {
                    float x = outputArray[i * 85 + 0];
                    float y = outputArray[i * 85 + 1];
                    float w = outputArray[i * 85 + 2];
                    float h = outputArray[i * 85 + 3];
                    float conf = outputArray[i * 85 + 4];
                    int classId = (int)outputArray[i * 85 + 5]; // 클래스 ID

                    if (conf > 0.5f) // confidence threshold
                    {
                        results.Add(new DetectionResult
                        {
                            Rect = new Rect((int)(x - w / 2), (int)(y - h / 2), (int)w, (int)h),
                            Label = $"PCB_{classId}",
                            Confidence = conf
                        });
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
    }
}

