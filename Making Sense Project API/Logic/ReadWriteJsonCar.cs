using Making_Sense_Project.Model;
using Microsoft.Extensions.Configuration;
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
    public class ReadWriteJsonCar
    {
        private string _pathJsonCar;
            public ReadWriteJsonCar(IConfiguration configuration)
        {
            _pathJsonCar = configuration.GetValue<string>("MySettings:_PathJsonCar");
        }
        public string SerializeJson(List<Car> cars)
        {
            return JsonConvert.SerializeObject(cars.ToArray(), Formatting.Indented);
        }
        public void WriteJsonFile(string CarJson)
        {
            File.WriteAllText(_pathJsonCar, CarJson);
        }
        public string ReadJsonFile()
        {
            string dataJson;
            using (var reader = new StreamReader(_pathJsonCar))
            {
                dataJson = reader.ReadToEnd();
            }
            return dataJson;
        }
        public List<Car> DesrealizedJson(string dataJson)
        {
            List<Car> listCar = JsonConvert.DeserializeObject<List<Car>>(dataJson);

            return listCar;
        }
    }
}
