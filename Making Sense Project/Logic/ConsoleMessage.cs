using Making_Sense_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Making_Sense_Project.Logic
{
    class ConsoleMessage
    {
        public List<Car> CreateCarsMessage(List<Car> listCar)
        {
            int id;
            Brand brand = new Brand();
            bool transmission = false;
            bool nextStep = false;
            //Se incrementa el id sumando +1 el ultimo id registrado en el json
            if (listCar.Count > 0)
            {
                Car getId = listCar.LastOrDefault();
                id = getId.IdCar + 1;
            }
            else
            {
                id = 1;
            }
            do
            {
                //imprime el Enum en forma descendente
                Console.WriteLine("Elija la Marca del auto que desea agregar");
                foreach (var value in Enum.GetValues(typeof(Brand)))
                {
                    Console.WriteLine("{0,3} {1}",
                        (int)value, (Brand)value);
                }
                //se convierte el enum en lista y se busca el enum que coincida con lo que busca el cliente
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
            do
            {
                nextStep = false;
                Console.WriteLine("Ingrese transmision M = Manual, A = Automatico");
                string transmissionValue = Console.ReadLine().ToUpper();
                if (transmissionValue == "M")
                {
                    transmission = false;
                    nextStep = true;
                }
                else if (transmissionValue == "A")
                {
                    transmission = true;
                    nextStep = true;
                }
                else
                {
                    Console.WriteLine("Valor no aceptado");
                }
            } while (!nextStep);
            
            listCar.Add(new Car
            {
                IdCar = id,
                Brand = brand,
                Model = model,
                Color = color,
                Year = year,
                NumbersDoor = doors,
                Automatic = transmission
            });
            return listCar;
        }
        public Car UpdateCarsMessage(List<Car> listCar)
        {
            Car car = new Car();
            int id;
            Brand brand = new Brand();
            bool transmission = false;
            bool nextStep = false;
            //Se incrementa el id sumando +1 el ultimo id registrado en el json
            if (listCar.Count > 0)
            {
                Car getId = listCar.LastOrDefault();
                id = getId.IdCar + 1;
            }
            else
            {
                id = 1;
            }
            do
            {
                //imprime el Enum en forma descendente
                Console.WriteLine("Elija la Marca del auto que desea agregar");
                foreach (var value in Enum.GetValues(typeof(Brand)))
                {
                    Console.WriteLine("{0,3} {1}",
                        (int)value, (Brand)value);
                }
                //se convierte el enum en lista y se busca el enum que coincida con lo que busca el cliente
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
            do
            {
                nextStep = false;
                Console.WriteLine("Ingrese transmision M = Manual, A = Automatico");
                string transmissionValue = Console.ReadLine().ToUpper();
                if (transmissionValue == "M")
                {
                    transmission = false;
                    nextStep = true;
                }
                else if (transmissionValue == "A")
                {
                    transmission = true;
                    nextStep = true;
                }
                else
                {
                    Console.WriteLine("Valor no aceptado");
                }
            } while (!nextStep);
            //agregamos los valores ingresados por consola y retornamos Car
            car = (new Car
            {
                IdCar = id,
                Brand = brand,
                Model = model,
                Color = color,
                Year = year,
                NumbersDoor = doors,
                Automatic = transmission
            });
            return car;
        }
    }
}
