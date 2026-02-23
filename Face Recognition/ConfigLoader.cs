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
            Env.Load();
        }

    }
}
