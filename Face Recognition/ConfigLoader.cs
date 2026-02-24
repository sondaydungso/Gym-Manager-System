using System;

namespace Gym_Manager_System.Face_Recognition
{
    public class ConfigLoader
    {
        private readonly string _FaceKey;
        private readonly string _FaceEndpoint;

        public ConfigLoader()
        {
            // Load .env first so env vars are set before we read them
            EnvParser.Load(".env");

            _FaceKey = (Environment.GetEnvironmentVariable("key1") ?? Environment.GetEnvironmentVariable("key") ?? "").Trim();
            _FaceEndpoint = (Environment.GetEnvironmentVariable("endpoint1") ?? Environment.GetEnvironmentVariable("endpoint") ?? "").Trim();

            if (string.IsNullOrEmpty(_FaceKey) || string.IsNullOrEmpty(_FaceEndpoint))
                throw new InvalidOperationException(
                    "Azure Face API is not configured. Add a .env file in the application folder with:\r\n" +
                    "key1=your_azure_face_key\r\nendpoint=https://your-resource.cognitiveservices.azure.com/");
        }

        public string FaceKey => _FaceKey;
        public string FaceEndpoint => _FaceEndpoint;
    }
}
