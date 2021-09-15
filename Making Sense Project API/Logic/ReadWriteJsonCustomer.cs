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
    public class ReadWriteJsonCustomer
    {
        private readonly string _PathJsonCustomer;
        public ReadWriteJsonCustomer(IConfiguration configuration)
        {
            _PathJsonCustomer = configuration.GetValue<string>("MySettings:_PathJsonCustomer");
        }
        public string SerializeJson(List<Customer> customers)
        {
            return JsonConvert.SerializeObject(customers.ToArray(), Formatting.Indented);
        }
        public void WriteJsonFile(string customerJson)
        {
            File.WriteAllText(_PathJsonCustomer, customerJson);
        }
        public string ReadJsonFile()
        {
            string dataCustomerJson;
            using (var reader = new StreamReader(_PathJsonCustomer))
            {
                dataCustomerJson = reader.ReadToEnd();
            }
            return dataCustomerJson;
        }
        public List<Customer> DesrealizedJson(string dataCustomerJson)
        {
            List<Customer> listCustomers = JsonConvert.DeserializeObject<List<Customer>>(dataCustomerJson);

            return listCustomers;
        }

    }
}
