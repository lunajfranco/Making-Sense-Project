using Making_Sense_Project_API.Model.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Making_Sense_Project_API.Model.Dtos
{
    public class RentalsDto
    {
        [Required(ErrorMessage = "Campo Obligatorio")]
        public int IdCar { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public int IdCustomer { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")] 
        public int DniCustomer { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string DurationRental { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public DateTime StartRentals { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public DateTime EndRentals { get; set; }
    }
}
