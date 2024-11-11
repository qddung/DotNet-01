
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Payment.Helper
{
    public static class JsonHelper
    {

        public static string DocJsonString(string filePath)
        {
            string currentDir = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(currentDir);
            string pathCombine = Path.Combine(currentDir, filePath);
            StreamReader r = new StreamReader(pathCombine);
            string json = r.ReadToEnd();
            return json;

        }

        public static List<T> LoadDataFromFile<T>(string filePath)
        {

            string currentDir = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(currentDir);
            string pathCombine = Path.Combine(currentDir, filePath);
            List<T> items = new List<T>();
            if (File.Exists(pathCombine) == false) return items;

            using (StreamReader r = new StreamReader(pathCombine))
            {
                string json = r.ReadToEnd();
                if (string.IsNullOrEmpty(json))
                {
                    return items;
                }
                items = JsonSerializer.Deserialize<List<T>>(json);
            }
            return items;

        }

        public static bool WriteFileJson<T>(string filePath, List<T> data)
        {
            string currentDir = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(currentDir);
            string pathCombine = Path.Combine(currentDir, filePath);

            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(pathCombine, json);
            return true;

        }
    }
}
