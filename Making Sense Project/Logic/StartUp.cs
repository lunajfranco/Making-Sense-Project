using Making_Sense_Project.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Making_Sense_Project.Logic
{
    public class StartUp
    {
        public void StartApp()
        {
            int idCar;
            Car resultado = new Car();
            ICarCRUD carCRUD = new CarCRUD();
            Car car = new Car();
            bool nextStep = false;
            do
            {
                string message = "ingrese C para Crear, B para Buscar, U para Actualizar, D para eliminar auto o E para salir";
                Console.WriteLine(message);
                string accion = Console.ReadLine().ToUpper();
                switch (accion)
                {
                    case "C":
                        carCRUD.CreateCar(car);
                            nextStep = true;
                            break;
                    case "B":
                        Console.WriteLine("Ingrese Id del auto que desea buscar");
                        idCar = int.Parse(Console.ReadLine());
                        resultado = carCRUD.GetCarByID(idCar);
                        Console.WriteLine(resultado);
                            nextStep = false;
                        break;
                    case "U":
                        Console.WriteLine("Ingrese Id del auto que desea Actualizar");
                        idCar = int.Parse(Console.ReadLine());
                        resultado = carCRUD.GetCarByID(idCar);
                        carCRUD.UpdateCar(resultado);
                            nextStep = true;
                            break;
                    case "D":
                        Console.WriteLine("Ingrese el Id del auto que desea eliminar");
                        idCar = int.Parse(Console.ReadLine());
                        carCRUD.DeleteCarById(idCar);
                        nextStep = true;
                        break;
                    case "E":
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Valor incorrecto");
                        break;
                }
            } while (!nextStep);
        }
    }
}
