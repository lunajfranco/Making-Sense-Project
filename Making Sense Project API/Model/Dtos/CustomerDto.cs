using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Making_Sense_Project_API.Model.Dtos
{
    public class CustomerDto
    {
        [Required(ErrorMessage = "Campo Obligatorio")]
        public int DNI { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public int PhoneNumber { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string City { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Province { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public int PostalCode { get; set; }
        public DateTime HistoryLastModification { get; set; }
    }
}
