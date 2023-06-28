using Newtonsoft.Json;

namespace Core.Helpers
{
    public class ObjectToDictionaryConverter
    {
        public static Dictionary<string, string> Convert(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            return dictionary;
        }
    }
}
