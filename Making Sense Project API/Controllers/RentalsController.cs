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
                return NotFound();
            }
            if (_customerCRUD.GetById(rentals.DniCustomer) == null)
            {
                return NotFound();
            }
            _rentalsCRUD.Create(rentals);
            return Ok();
        }
        [HttpPut("Update")]
        public IActionResult Update(Rentals rentals)
        {
            if (_rentalsCRUD.GetById(rentals.IdRentals) == null)
            {
                return NotFound();
            }
            _rentalsCRUD.Update(rentals);
            return Ok();
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int idRentals)
        {
            Rentals rentals = _rentalsCRUD.GetById(idRentals);
            if ( rentals == null)
            {
                return NotFound();
            }
            return Ok(rentals);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            IList<Rentals> listRentals = _rentalsCRUD.GetAll();
            return Ok(listRentals.OrderBy(x => x.IdRentals));
        }
        [HttpDelete("DeleteById")]
        public IActionResult Delete(int idRentals)
        {
            if (_rentalsCRUD.GetById(idRentals) == null)
            {
                return NotFound();
            }
            _rentalsCRUD.DeleteById(idRentals);
            return Ok();
        }
    } 
}
