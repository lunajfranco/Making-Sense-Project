using Making_Sense_Project_API.Model.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Making_Sense_Project_API.Model.Dtos
{
    public class CarDto
    {
        [Required(ErrorMessage = "Campo Obligatorio")]
        public Brand Brand { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Color { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public byte NumbersDoor { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public bool Automatic { get; set; }
    }
}
