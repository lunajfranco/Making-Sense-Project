using Making_Sense_Project_API.Model.Class;
using Making_Sense_Project_API.Model.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Making_Sense_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalsCRUD<Rentals> _rentalsCRUD;
        private readonly ICarCRUD<Car> _carCRUD;
        private readonly ICustomerCRUD<Customer> _customerCRUD;

        public RentalsController(IRentalsCRUD<Rentals> rentalsCRUD,
            ICarCRUD<Car> carCRUD, ICustomerCRUD<Customer> customerCRUD)
        {
            _rentalsCRUD = rentalsCRUD;
            _carCRUD = carCRUD;
            _customerCRUD = customerCRUD;
        }

        [HttpPost("Create")]
        public IActionResult Create(Rentals rentals)
        {
            if (_carCRUD.GetById(rentals.IdCar) == null)
            {
                return BadRequest($"No hay auto registrado con id {rentals.IdCar}");
            }
            if (_customerCRUD.GetById(rentals.DniCustomer) == null)
            {
                return BadRequest($"No hay cliente registrado con id {rentals.DniCustomer}");
            }
            if (_rentalsCRUD.GetById(rentals.IdRentals) != null)
            {
                return BadRequest($"Ya se encuentra registrada una renta con id {rentals.IdRentals}");
            }
            _rentalsCRUD.Create(rentals);
            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Update(Rentals rentals)
        {
            if (_rentalsCRUD.GetById(rentals.IdRentals) == null)
            {
                return NotFound($"No se encontro renta con id {rentals.IdRentals} para actualizar");
            }
            _rentalsCRUD.Update(rentals);
            return Ok();
        }

        [HttpDelete("DeleteById")]
        public IActionResult Delete(int idRentals)
        {
            if (_rentalsCRUD.GetById(idRentals) == null)
            {
                return NotFound($"No se encontro renta con id {idRentals} para eliminar");
            }
            _rentalsCRUD.DeleteById(idRentals);
            return Ok();
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int idRentals)
        {
            if (_rentalsCRUD.GetById(idRentals) == null)
            {
                return NotFound($"No existe renta con id {idRentals} registrado");
            }
            return Ok(_rentalsCRUD.GetById(idRentals));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            IList<Rentals> listRentals = _rentalsCRUD.GetAll();
            return Ok(listRentals.OrderBy(x => x.IdRentals));
        }
    } 
}
