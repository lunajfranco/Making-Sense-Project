using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Making_Sense_Project.Model
{
    interface ICarCRUD
    {
        void CreateCar(Car car);
        Car GetCarByID(int idCar);
        void UpdateCar(Car car);
        void DeleteCarById(int idCar);
    }
}
