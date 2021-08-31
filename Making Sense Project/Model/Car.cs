using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Making_Sense_Project.Model
{
    public class Car
    {
        public int IdCar { get; set; }
        public Marca Marca { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public byte CantidadPuertas { get; set; }
        public string Transimision { get; set; }
    }
}
