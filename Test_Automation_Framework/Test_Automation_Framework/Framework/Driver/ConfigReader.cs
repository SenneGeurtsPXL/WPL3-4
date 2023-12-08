using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Automation_Framework.Framework.Driver
{
    public class ConfigReader
    {
        public string BrowserType { get; set; }
        public int WaitTime { get; set; }

        public ConfigReader() 
        {
            // Read the JSON string from a file or any other source
            string jsonString = ReadJsonFromFile(@"..\..\..\Framework\Config.txt");

            // Deserialize the JSON string
            var jsonSettings = new JsonSerializerSettings
            {
                // Use camelCase for property names
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            };

            var jsonObject = JsonConvert.DeserializeObject<JObject>(jsonString, jsonSettings);

            // Access values using property names
            string browser = jsonObject["browser"]?.ToString();
            int waitTime = jsonObject["waittime"]?.ToObject<int>() ?? 0;

            // Output the values
            BrowserType = browser;
            WaitTime = waitTime;
        }
        static string ReadJsonFromFile(string filePath)
        {
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                return streamReader.ReadToEnd();
            }
        }

    }
}
