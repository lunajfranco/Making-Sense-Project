using Making_Sense_Project.Logic;
using Making_Sense_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Making_Sense_Project_API.Model.Repostory
{
    public interface ICarCRUD<T> : ICRUD<T> 
    {

    }
    public class CarCRUD<T> : ICarCRUD<Car>
    {
        private readonly ReadWriteJsonCar _readWriteJson;

        public CarCRUD(ReadWriteJsonCar readWriteJson)
        {
            _readWriteJson = readWriteJson;
        }

        public void Create(Car car)
        {
            string dataJson = _readWriteJson.ReadJsonFile();
            //se asigna los datos del json a una lista
            List<Car> listCar = _readWriteJson.DesrealizedJson(dataJson);
            listCar.Add(car);
            string serializedJson = _readWriteJson.SerializeJson(listCar);
            _readWriteJson.WriteJsonFile(serializedJson);
        }

        public void DeleteById(int idCar)
        {
            string dataJson = _readWriteJson.ReadJsonFile();
            List<Car> listCar = _readWriteJson.DesrealizedJson(dataJson);
            listCar.Remove(listCar.SingleOrDefault(x => x.IdCar == idCar));
            string serializedJson = _readWriteJson.SerializeJson(listCar);
            _readWriteJson.WriteJsonFile(serializedJson);
        }

        public IList<Car> GetAll()
        {
            string dataJson = _readWriteJson.ReadJsonFile();
            List<Car> listCar = _readWriteJson.DesrealizedJson(dataJson);
            return listCar;
        }

        public Car GetById(int idCar)
        {
            string dataJson = _readWriteJson.ReadJsonFile();
            List<Car> listCar = _readWriteJson.DesrealizedJson(dataJson);
            Car car = listCar.SingleOrDefault(x => x.IdCar == idCar);
            return car;
        }
        public void Update(Car car)
        {
            string dataJson = _readWriteJson.ReadJsonFile();
            List<Car> listCar = _readWriteJson.DesrealizedJson(dataJson);
            listCar.Remove(listCar.SingleOrDefault(x => x.IdCar == car.IdCar));
            listCar.Add(car);
            string serializedJson = _readWriteJson.SerializeJson(listCar);
            _readWriteJson.WriteJsonFile(serializedJson);
        }
    }
}
