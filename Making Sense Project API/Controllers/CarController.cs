using AutoMapper;
using Making_Sense_Project_API.Model.Class;
using Making_Sense_Project_API.Model.Dtos;
using Making_Sense_Project_API.Model.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Making_Sense_Project_API.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICarCRUD<Car> _carCRUD;
        private readonly IMapper _mapper;

        public CarController(ICarCRUD<Car> carCRUD, IMapper mapper)
        {
            _carCRUD = carCRUD;
            _mapper = mapper;
        }

        [HttpPost("Create")]
        public IActionResult Create(CarDto carDto)
        {
            if (carDto == null)
            {
                return BadRequest(ModelState);
            }
            var car = _mapper.Map<Car>(carDto);
            if (!_carCRUD.Create(car))
            {
                ModelState.AddModelError("", "Algo salio mal");
                return StatusCode(505, ModelState);
            }
            return NoContent();
        }

        [HttpPatch]
        public IActionResult Update(int carId, CarDto carDto)
        {
            var car = _carCRUD.GetById(carId);
            if ( car == null)
            {
                return NotFound($"No se encontro auto con id {nameof(carId)} para actualizar");
            }
            car = _mapper.Map(carDto, car);
            if (!_carCRUD.Update(car))
            {
                ModelState.AddModelError("", "Algo salio mal");
                return StatusCode(505, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int idCar)
        {
            var car = _carCRUD.GetById(idCar);
            if (car == null)
            {
                return NotFound($"No se encontro auto con id {nameof(idCar)} para eliminar");
            }
            if (!_carCRUD.Delete(car))
            {
                ModelState.AddModelError("", "Algo salio mal");
                return StatusCode(505, ModelState);
            }
            return NoContent();
        }

        [HttpGet("byId")]
        public IActionResult Get(int idCar)
        {
            var car = _carCRUD.GetById(idCar);
            if (car == null)
            {
                return NotFound($"No se encontro auto con id {nameof(idCar)} registrado");
            }
            var carDto = _mapper.Map<CarDto>(car);
            return Ok(carDto);
        }

        [HttpGet("All")]
        public IActionResult GetAll()
        {
            var listCars = _carCRUD.GetAll();
            if (listCars.Count == 0)
            {
                return NotFound();
            }
            var listCarsDto = new List<CarDto>();
            foreach (var item in listCars)
            {
                listCarsDto.Add(_mapper.Map<CarDto>(item));
            }
            return Ok(listCarsDto);
        }
    }
}
