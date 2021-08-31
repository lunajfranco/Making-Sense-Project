using Making_Sense_Project.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Making_Sense_Project.Logic
{
    public class ReadWriteJson
    {
        private string _path = @"C:\Users\lunaj\source\repos\Making Sense Project\Making Sense Project\Data\CarJson.json";

        public void SerializeJson(List<Car> cars)
        {
            string CarJson = JsonConvert.SerializeObject(cars.ToArray(), Formatting.Indented);
            File.WriteAllText(_path, CarJson);
        }
        public string ReadJsonFile()
        {
            string datosJson;
            using (var reader = new StreamReader(_path))
            {
                datosJson = reader.ReadToEnd();
            }
            return datosJson;
        }
        public void DesrealizedJson(string datosJson)
        {
            Console.WriteLine(datosJson);
        }
    }
}
