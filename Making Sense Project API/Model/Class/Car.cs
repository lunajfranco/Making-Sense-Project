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
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public byte NumbersDoor { get; set; }
        public bool Automatic { get; set; }
    }
}
