using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager_System.Face_Recognition
{
    public class EnvParser
    {
        /// <summary>Finds .env by trying: exe directory, then current directory.</summary>
        public static string? ResolveEnvPath(string fileName = ".env")
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var path1 = Path.Combine(baseDir, fileName);
            if (File.Exists(path1)) return path1;
            var path2 = Path.Combine(Environment.CurrentDirectory, fileName);
            if (File.Exists(path2)) return path2;
            if (File.Exists(fileName)) return Path.GetFullPath(fileName);
            return null;
        }

        public static void Load(string filePath)
        {
            var path = Path.IsPathRooted(filePath) ? filePath : ResolveEnvPath(filePath);
            if (path == null || !File.Exists(path))
                return;

            var lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                if (string.IsNullOrWhiteSpace(line) || line.TrimStart().StartsWith("#"))
                    continue;

                var parts = line.Split('=', 2);
                if (parts.Length != 2)
                    continue;

                var key = parts[0].Trim().TrimStart('\uFEFF'); // trim BOM on first key
                var value = parts[1].Trim();
                if (string.IsNullOrEmpty(key)) continue;
                Environment.SetEnvironmentVariable(key, value);
            }
        }
    }
}