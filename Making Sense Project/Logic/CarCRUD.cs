using Making_Sense_Project.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Making_Sense_Project.Logic
{
    public class CarCRUD : ICarCRUD
    {

        void ICarCRUD.CreateCar(Car car)
        {
            int id;
            Brand brand = new Brand();
            bool transmission = false;
            bool nextStep = false;
            ReadWriteJson json = new ReadWriteJson();
            string datos = json.ReadJsonFile();
            List<Car> listCar = json.DesrealizedJson(datos);
            //incremento de idCar segun la cantidad de objetos en la lista
            if (listCar.Count > 0)
            {
                id = listCar.Count + 1;
            }
            else
            {
                id = 1;
            }
            do
            {
                Console.WriteLine("Elija la Marca del auto que desea agregar");
                foreach (var value in Enum.GetValues(typeof(Brand)))
                {
                    Console.WriteLine("{0,3} {1}",
                        (int)value, (Brand)value);
                }
                List<Brand> listEnum = Enum.GetValues(typeof(Brand)).Cast<Brand>().ToList();
                int idMarca = int.Parse(Console.ReadLine());
                if (idMarca <= 6 || idMarca == 0)
                {
                    for (int i = 0; i < listEnum.Count; i++)
                    {
                        if (idMarca == listEnum.IndexOf((Brand)i))
                        {
                            brand = (Brand)Enum.Parse(typeof(Brand), idMarca.ToString());
                            nextStep = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Valor no aceptado");
                }
            } while (!nextStep);

            Console.WriteLine("Ingrese Modelo del Auto");
            string model = Console.ReadLine();
            Console.WriteLine("Ingrese Color del Auto ");
            string color = Console.ReadLine();
            Console.WriteLine("Ingrese año del auto");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese cantidad de puerdas del auto");
            byte doors = byte.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese transmision M = Manual, A = Automatico");
            string transmissionValue = Console.ReadLine();
            if (transmissionValue == "M")
            {
                transmission = false;
            }
            else if (transmissionValue == "A")
            {
                transmission = true;
            }
            listCar.Add(new Car
            {
                IdCar = id,
                Brand = brand,
                Model = model,
                Color = color,
                Year = year,
                NumbersDoor = doors,
                Transmission = transmission
            });
            var serialize = json.SerializeJson(listCar);
            json.WriteJsonFile(serialize);
            Console.WriteLine("Auto Creado con éxito");
            StartUp startUp = new StartUp();
            startUp.StartApp();
        }
        public Car GetCarByID(int idCar)
        {
            ReadWriteJson json = new ReadWriteJson();
            string datos = json.ReadJsonFile();
            List<Car> listCar = json.DesrealizedJson(datos);
            Car car = listCar.SingleOrDefault(x => x.IdCar == idCar);
            if (car != null)
            {
                var jsonObject = JObject.FromObject(car);
                foreach (var item in jsonObject)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
            else
            {
                StartUp startUp = new StartUp();
                startUp.StartApp();
            }
            return car;
        }
        void ICarCRUD.UpdateCar(Car car)
        {
            int id;
            Brand brand = new Brand();
            bool transmission = false;
            bool nextStep = false;
            ReadWriteJson json = new ReadWriteJson();
            string datos = json.ReadJsonFile();
            List<Car> listCar = json.DesrealizedJson(datos);
            listCar.Remove(listCar.SingleOrDefault(x => x.IdCar == car.IdCar));
            //incremento de idCar segun la cantidad de objetos en la lista
            if (listCar.Count > 0)
            {
                id = listCar.Count + 3;
            }
            else
            {
                id = 1;
            }
            do
            {
                Console.WriteLine("Elija la Marca del auto que desea agregar");
                foreach (var value in Enum.GetValues(typeof(Brand)))
                {
                    Console.WriteLine("{0,3} {1}",
                        (int)value, (Brand)value);
                }
                List<Brand> listEnum = Enum.GetValues(typeof(Brand)).Cast<Brand>().ToList();
                int idMarca = int.Parse(Console.ReadLine());
                if (idMarca <= 6 || idMarca == 0)
                {
                    for (int i = 0; i < listEnum.Count; i++)
                    {
                        if (idMarca == listEnum.IndexOf((Brand)i))
                        {
                            brand = (Brand)Enum.Parse(typeof(Brand), idMarca.ToString());
                            nextStep = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Valor no aceptado");
                }
            } while (!nextStep);
            

            Console.WriteLine("Ingrese Modelo del Auto");
            string model = Console.ReadLine();
            Console.WriteLine("Ingrese Color del Auto ");
            string color = Console.ReadLine();
            Console.WriteLine("Ingrese año del auto");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese cantidad de puerdas del auto");
            byte doors = byte.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese transmision M = Manual, A = Automatico");
            string transmissionValue = Console.ReadLine();
            if (transmissionValue == "M")
            {
                transmission = false;
            }
            else if (transmissionValue == "A")
            {
                transmission = true;
            }
            car = (new Car
            {
                IdCar = id,
                Brand = brand,
                Model = model,
                Color = color,
                Year = year,
                NumbersDoor = doors,
                Transmission = transmission
            });
            listCar.Add(car);
            var serialize = json.SerializeJson(listCar);
            json.WriteJsonFile(serialize);
            var jsonObject = JObject.FromObject(listCar.Last());
            foreach (var item in jsonObject)
            {
               
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            Console.WriteLine("Auto actualizado");
            StartUp startUp = new StartUp();
            startUp.StartApp();
        }
        public void DeleteCarById(int idCar)
        {
            ReadWriteJson json = new ReadWriteJson();
            string datos = json.ReadJsonFile();
            List<Car> listCar = json.DesrealizedJson(datos);
            listCar.Remove(listCar.SingleOrDefault(x => x.IdCar == idCar));
            var serialize = json.SerializeJson(listCar);
            json.WriteJsonFile(serialize);
            Console.WriteLine("Auto eliminado");
            StartUp startUp = new StartUp();
            startUp.StartApp();
        }
    }
}
