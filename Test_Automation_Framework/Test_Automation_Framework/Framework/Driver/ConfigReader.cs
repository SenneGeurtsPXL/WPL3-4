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
            string jsonString = ReadJsonFromFile(@"..\..\..\Framework\Config.txt");
            var jsonSettings = new JsonSerializerSettings
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            };
            var jsonObject = JsonConvert.DeserializeObject<JObject>(jsonString, jsonSettings);
            string browser = jsonObject["browser"]?.ToString();
            int waitTime = jsonObject["waittime"]?.ToObject<int>() ?? 0;
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
