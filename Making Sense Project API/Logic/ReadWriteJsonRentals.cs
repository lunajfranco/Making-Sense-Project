using Making_Sense_Project_API.Model.Class;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Making_Sense_Project_API.Logic
{
    public class ReadWriteJsonRentals
    {
        private readonly string _PathJsonRental;
        public ReadWriteJsonRentals(IConfiguration configuration)
        {
            _PathJsonRental = configuration.GetValue<string>("MySettings:_PathJsonRentals");
        }
        public string SerializeJson(List<Rentals> rentals)
        {
            return JsonConvert.SerializeObject(rentals.ToArray(), Formatting.Indented);
        }
        public void WriteJsonFile(string rentalsJson)
        {
            File.WriteAllText(_PathJsonRental, rentalsJson);
        }
        public string ReadJsonFile()
        {
            string dataRentalsJson;
            using (var reader = new StreamReader(_PathJsonRental))
            {
                dataRentalsJson = reader.ReadToEnd();
            }
            return dataRentalsJson;
        }
        public List<Rentals> DesrealizedJson(string dataRentalsJson)
        {
            List<Rentals> listRentals = JsonConvert.DeserializeObject<List<Rentals>>(dataRentalsJson);

            return listRentals;
        }
    }
}
