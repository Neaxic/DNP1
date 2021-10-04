using System.IO;
using System.Text.Json;
using SDJ_JSON;

namespace DefaultNamespace
{
    public class JSONConverter
    {
        private Person p;
        private string jsonfile = "\\Users\\andreas\\Documents\\Github\\json-converter\\Test.json"; 
        
        public JSONConverter()
        {

        }


        public Person jsonConverter()
        {
            if (File.Exists(jsonfile))
            {
                string content = File.ReadAllText(jsonfile);
                p = JsonSerializer.Deserialize<Person>(content, new JsonSerializerOptions{ PropertyNameCaseInsensitive = true});
                //System.Console.WriteLine(content);
            }
            else
            {
                System.Console.WriteLine("Cant find file");
            }

            return p;
        }
    }
}