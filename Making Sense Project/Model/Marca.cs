using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Making_Sense_Project.Model
{
    public class Marca
    {
        public int IdMarca { get; set; }
        public string NombreMarca { get; set; }
        public List<Car> Cars { get; set; }
    }
}
