using Making_Sense_Project.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Making_Sense_Project.Logic
{
    public class ReadWriteJson
    {
        private string _path = ConfigurationManager.AppSettings["_pathJson"];

        public string SerializeJson(List<Car> cars)
        {
            return JsonConvert.SerializeObject(cars.ToArray(), Formatting.Indented);
        }
        public void WriteJsonFile(string CarJson)
        {
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
        public List<Car> DesrealizedJson(string datosJson)
        {
            List<Car> listCar = JsonConvert.DeserializeObject<List<Car>>(datosJson);

            return listCar;
        }
    }
}
