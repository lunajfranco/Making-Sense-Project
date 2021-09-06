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
            ReadWriteJson json = new ReadWriteJson();
            StartUp startUp = new StartUp();
            ConsoleMessage consoleMessage = new ConsoleMessage();
            //Se lee json para ver si tiene algo
            string dataJson = json.ReadJsonFile();
            //se asigna los datos del json a una lista
            List<Car> listCar = json.DesrealizedJson(dataJson);
            //llamamos a los mensajes que apareceran en consola para la entrada de datos
            listCar = consoleMessage.CreateCarsMessage(listCar);
            //Serializamos el json con los datos obtenidos
            string serializedJson = json.SerializeJson(listCar);
            //Se Escribe el json con los datos serializados
            json.WriteJsonFile(serializedJson);
            Console.WriteLine("Auto Creado con éxito");
            //Se vuelve al menu principal
            startUp.StartApp();
        }
        public Car GetCarByID(int idCar)
        {
            ReadWriteJson json = new ReadWriteJson();
            // Se lee json para ver si tiene algo
            string dataJson = json.ReadJsonFile();
            //se asigna los datos del json a una lista
            List<Car> listCar = json.DesrealizedJson(dataJson);
            //Se busca un auto en la lista con el id ingresado 
            Car car = listCar.SingleOrDefault(x => x.IdCar == idCar);
            if (car != null)
            {
                //Se recibe el auto con el id y lo transformamos a un jsonObject
                //para poder imprimir linea por linea con los valores encontrados
                var jsonObject = JObject.FromObject(car);
                foreach (var item in jsonObject)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
            else
            {
                Console.WriteLine("No se encontró ningún Auto con ese Id");
                StartUp startUp = new StartUp();
                startUp.StartApp();
            }
            return car;
        }
        void ICarCRUD.UpdateCar(Car car)
        {
            StartUp startUp = new StartUp();
            ConsoleMessage consoleMessage = new ConsoleMessage();
            ReadWriteJson json = new ReadWriteJson();
            // Se lee json para ver si tiene algo
            string dataJson = json.ReadJsonFile();
            //se asigna los datos del json a una lista
            List<Car> listCar = json.DesrealizedJson(dataJson);
            //borramos el auto que deseamos actualizar buscado por id
            listCar.Remove(listCar.SingleOrDefault(x => x.IdCar == car.IdCar));
            //llamamos a los mensajes de consola para que el cliente ingrese los valores actualizados
            car = consoleMessage.UpdateCarsMessage(listCar);
            //Se agregan los datos recibidos a la lista
            listCar.Add(car);
            //Serializamos el json con los datos obtenidos
            string serialize = json.SerializeJson(listCar);
            //Escribimos el json con los datos serializados
            json.WriteJsonFile(serialize);
            //Se recibe el auto actualizado y lo transformamos a un jsonObject
            //para poder imprimir linea por linea con los valores encontrados
            var jsonObject = JObject.FromObject(listCar.Last());
            foreach (var item in jsonObject)
            {
               
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            Console.WriteLine("Auto actualizado");
            //Se vuelve al menu principal
            startUp.StartApp();
        }
        public void DeleteCarById(int idCar)
        {
            StartUp startUp = new StartUp();
            ReadWriteJson json = new ReadWriteJson();
            // Se lee json para ver si tiene algo
            string dataJson = json.ReadJsonFile();
            //se asigna los datos del json a una lista
            List<Car> listCar = json.DesrealizedJson(dataJson);
            //borramos el auto que coincida con el id recibido
            listCar.Remove(listCar.SingleOrDefault(x => x.IdCar == idCar));
            //Serializamos el json con los datos obtenidos
            string serialize = json.SerializeJson(listCar);
            //Escribimos el json con los datos serializados
            json.WriteJsonFile(serialize);
            Console.WriteLine("Auto eliminado");
            //Se vuelve al menu principal
            startUp.StartApp();
        }
    }
}
