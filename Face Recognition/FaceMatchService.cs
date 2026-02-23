using Azure;
using Azure.AI.Vision.Face;
using Gym_Manager_System.Face_Recognition;

namespace Gym_Manager_System.Face_Recognition
{
    public class FaceMatchService
    {
        private readonly FaceClient _faceClient;
        private readonly LargePersonGroupClient _groupClient;
        private const string GroupId = "gym-members";

        public FaceMatchService()
        {
            var config = new ConfigLoader();
            var endpoint = new Uri(config.FaceEndpoint);
            var credential = new AzureKeyCredential(config.FaceKey);

            _faceClient = new FaceClient(endpoint, credential);
            _groupClient = new FaceAdministrationClient(endpoint, credential)
                               .GetLargePersonGroupClient(GroupId);
        }

        // Create group once on first launch
        public async Task InitializeAsync()
        {
            try
            {
                await _groupClient.CreateAsync(GroupId, recognitionModel: FaceRecognitionModel.Recognition04);
            }
            catch (RequestFailedException ex) when (ex.Status == 409)
            {               

            }
        }

        // Register new member - returns Azure Person ID
        public async Task<Guid> RegisterPersonAsync(string memberName)
        {
            var result = await _groupClient.CreatePersonAsync(memberName);
            return result.Value.PersonId;
        }

        // Add face photo to that person
        public async Task AddFaceAsync(Guid personId, Stream imageStream)
        {
            await _groupClient.AddFaceAsync(personId, BinaryData.FromStream(imageStream));
        }

        // Train after every registration
        public async Task TrainAsync()
        {
            var operation = await _groupClient.TrainAsync(WaitUntil.Completed);
            await operation.WaitForCompletionResponseAsync();
        }

        // Identify face - returns Person ID or null if no match
        public async Task<Guid?> IdentifyAsync(Stream imageStream)
        {
            var detected = await _faceClient.DetectAsync(
                BinaryData.FromStream(imageStream),
                FaceDetectionModel.Detection03,
                FaceRecognitionModel.Recognition04,
                returnFaceId: true);

            if (!detected.Value.Any()) return null;

            var faceIds = detected.Value
                .Where(f => f.FaceId.HasValue)
                .Select(f => f.FaceId!.Value)
                .ToList();

            var identified = await _faceClient.IdentifyFromLargePersonGroupAsync(faceIds, GroupId);

            return identified.Value
                .FirstOrDefault()
                ?.Candidates
                .FirstOrDefault(c => c.Confidence >= 0.7)
                ?.PersonId;
        }

        // Remove member face
        public async Task DeletePersonAsync(Guid personId)
        {
            await _groupClient.DeletePersonAsync(personId);
            await TrainAsync();
        }
    }
}