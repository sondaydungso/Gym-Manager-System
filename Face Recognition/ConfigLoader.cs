using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager_System.Face_Recognition
{
    public class ConfigLoader
    {
        private string _FaceKey;
        private string _FaceEndpoint;

        public ConfigLoader() 
        {
           LoadEnvironmentVariables();
        }
        private void LoadEnvironmentVariables()
        {
            EnvParser.Load(".env");
            _FaceKey = Environment.GetEnvironmentVariable("key1");
            _FaceEndpoint = Environment.GetEnvironmentVariable("endpoint");
            if (string.IsNullOrEmpty(_FaceKey) || string.IsNullOrEmpty(_FaceEndpoint))
                throw new Exception("Azure credentials not found in .env file");
        }

        public string FaceKey { get { return _FaceKey; } }
        public string FaceEndpoint { get { return _FaceEndpoint; } }

    }
}
