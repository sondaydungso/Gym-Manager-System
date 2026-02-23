using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager_System.Face_Recognition
{
    public class EnvParser
    {
        public static void Load(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Warning: The file '{filePath}' does not exist.");
                Console.WriteLine("Please create a .env file with your database connection details.");
                Console.WriteLine("See .env.example for a template.");
                throw new FileNotFoundException($"The file '{filePath}' does not exist. Please create it with your database credentials.");
            }

            foreach (var line in File.ReadAllLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                    continue;

                var parts = line.Split('=', 2);
                if (parts.Length != 2)
                    continue;

                var key = parts[0].Trim();
                var value = parts[1].Trim();
                Environment.SetEnvironmentVariable(key, value);
            }
        }
    }
}