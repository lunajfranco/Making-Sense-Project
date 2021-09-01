using Making_Sense_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Making_Sense_Project.Logic
{
    public class CarCRUD : ICarCRUD
    {
        List<Car> ICarCRUD.CreateCar(Car car)
        {
            List<Car> cars = new List<Car> {
            new Car
                {
                IdCar = 2,
                Brand = Brand.Volkswagen,
                Model = "Gol",
                Color = "negro",
                Year = 2015,
                NumbersDoor = 3,
                Transmission = false
                }
            };
            return cars;
        }
        public Car GetCarByID(int idCar)
        {
            ReadWriteJson json = new ReadWriteJson();
            string datos = json.ReadJsonFile();
            List<Car> listCar = json.DesrealizedJson(datos);

            return listCar.SingleOrDefault(x => x.IdCar == idCar);
        }
        void ICarCRUD.UpdateCar(Car car)
        {
            ReadWriteJson json = new ReadWriteJson();
            string datos = json.ReadJsonFile();
            List<Car> listCar = json.DesrealizedJson(datos);
            listCar.Remove(listCar.SingleOrDefault(x => x.IdCar == car.IdCar));
            listCar.Add(car);
            var serialize = json.SerializeJson(listCar);
            json.WriteJsonFile(serialize);
        }
        public void DeleteCarById(int idCar)
        {
            throw new NotImplementedException();
        }
    }
}
