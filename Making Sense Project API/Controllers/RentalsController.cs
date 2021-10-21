using AutoMapper;
using Making_Sense_Project_API.Model.Class;
using Making_Sense_Project_API.Model.Dtos;
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
        private readonly IMapper _mapper;

        public RentalsController(IRentalsCRUD<Rentals> rentalsCRUD,
            ICarCRUD<Car> carCRUD, ICustomerCRUD<Customer> customerCRUD,
            IMapper mapper)
        {
            _rentalsCRUD = rentalsCRUD;
            _carCRUD = carCRUD;
            _customerCRUD = customerCRUD;
            _mapper = mapper;
        }

        [HttpPost("Create")]
        public IActionResult Create(RentalsDto rentalsDto)
        {
            if (rentalsDto == null)
            {
                return BadRequest(ModelState);
            }
            if (_carCRUD.GetById(rentalsDto.IdCar) == null)
            {
                return NotFound($"No se registro ningun auto con id {nameof(rentalsDto.IdCar)} registrado");
            }
            if (_customerCRUD.GetById(rentalsDto.DniCustomer) == null)
            {
                return NotFound($"No se registro ningun cliente con id {nameof(rentalsDto.DniCustomer)} registrado");
            }
            var rentals = _mapper.Map<Rentals>(rentalsDto);
            if (!_rentalsCRUD.Create(rentals))
            {
                ModelState.AddModelError("", "Algo salio mal");
                return StatusCode(505, ModelState);
            }
            return NoContent();
        }

        [HttpPut("Update")]
        public IActionResult Update(int idRentals, RentalsDto rentalsDto)
        {
            var rental = _rentalsCRUD.GetById(idRentals);
            if (rental == null)
            {
                return NotFound($"No se encontro renta con id {nameof(idRentals)} para actualizar");
            }
            rental = _mapper.Map(rentalsDto, rental);
            if (!_rentalsCRUD.Update(rental))
            {
                ModelState.AddModelError("", "Algo salio mal");
                return StatusCode(505, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("DeleteById")]
        public IActionResult Delete(int idRentals)
        {
            var rental = _rentalsCRUD.GetById(idRentals);
            if (rental == null)
            {
                return NotFound($"No se encontro renta con id {nameof(idRentals)} para eliminar");
            }
            if (!_rentalsCRUD.Delete(rental))
            {
                ModelState.AddModelError("", "Algo salio mal");
                return StatusCode(505, ModelState);
            }
            return NoContent();
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int idRentals)
        {
            var rental = _rentalsCRUD.GetById(idRentals);
            if (rental == null)
            {
                return NotFound($"No existe renta con id {nameof(idRentals)} registrado");
            }
            var rentalDto = _mapper.Map<RentalsDto>(rental);
            return Ok(rentalDto);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var lisRentals = _rentalsCRUD.GetAll();
            if (lisRentals.Count == 0)
            {
                return NotFound();
            }
            var listRentalsDto = new List<RentalsDto>();
            foreach (var item in lisRentals)
            {
                listRentalsDto.Add(_mapper.Map<RentalsDto>(item));
            }
            return Ok(listRentalsDto);
        }
    } 
}
