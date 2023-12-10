using Newtonsoft.Json;
using System.IO;

namespace FeedSurf.Misc
{
    public static class JsonManager
    {
        public static void SerializeToFile<T>(T obj, String path)
        {
            String directoryPath = Path.GetDirectoryName(path);
            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
            File.WriteAllText(path, JsonConvert.SerializeObject(obj));
        }

        public static T? DeserializeFromFile<T>(String path)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
            }
            catch
            {
                return default(T);
            }
        }
    }
}
