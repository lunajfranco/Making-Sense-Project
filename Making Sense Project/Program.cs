using Making_Sense_Project.Logic;
using Making_Sense_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Making_Sense_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            CarCRUD carCRUD = new CarCRUD();
            ReadWriteJson json = new ReadWriteJson();
            //var cars = carCRUD.Create();
            //json.SerializeJson(cars);
            var datos = json.ReadJsonFile();
            json.DesrealizedJson(datos);
            Console.ReadKey();
        }
    }
}
