using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Making_Sense_Project.Model
{
    interface ICarCRUD
    {
        List<Car> CreateCar(Car car);
        Car GetCarByID(int idCar);
        void UpdateCar(Car car);
        void DeleteCarById(int idCar);
    }
}
