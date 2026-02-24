using Azure;
using Azure.AI.Vision.Face;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Gym_Manager_System.Face_Recognition
{
    public class FaceDetectionService
    {
        private readonly FaceClient _faceClient;

        public FaceDetectionService()
        {
            var config = new ConfigLoader();
            var endpoint = new Uri(config.FaceEndpoint);
            var credential = new AzureKeyCredential(config.FaceKey);
            _faceClient = new FaceClient(endpoint, credential);
        }

       
        public async Task<(bool IsValid, string Message)> ValidateImageForRegistrationAsync(Stream imageStream)
        {
            if (imageStream == null || imageStream.Length == 0)
                return (false, "No image provided.");

            try
            {
                var detected = await _faceClient.DetectAsync(
                    BinaryData.FromStream(imageStream),
                    FaceDetectionModel.Detection03,
                    FaceRecognitionModel.Recognition04,
                    returnFaceId: false);

                var count = detected.Value?.Count ?? 0;
                if (count == 0)
                    return (false, "No face detected. Please ensure the face is clearly visible.");
                if (count > 1)
                    return (false, "More than one face detected. Please ensure only the member is in the frame.");
                return (true, "OK");
            }
            catch (RequestFailedException ex)
            {
                return (false, $"Face detection failed: {ex.Message}");
            }
        }
    }
}
