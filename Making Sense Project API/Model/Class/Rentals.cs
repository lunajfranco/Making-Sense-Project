using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Making_Sense_Project_API.Model.Class
{
    public class Rentals
    {
        public int IdRentals { get; set; }
        public int IdCar { get; set; }
        public int DniCustomer { get; set; }
        public string DurationRental { get; set; }
        public DateTime StartRentals { get; set; }
        public DateTime EndRentals { get; set; }
    }
}
