using Making_Sense_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Making_Sense_Project.Logic
{
    public class CarCRUD
    {
        public List<Car> Create()
        {
            List<Car> car = new List<Car> {
            new Car
                {
                IdCar = 2,
                Marca = new Marca { IdMarca = 1, NombreMarca = "volskwagen" },
                Color = "negro",
                Year = 2015,
                CantidadPuertas = 3,
                Transimision = "Manual"
                }
            };
            return car;
        }
    }
}
