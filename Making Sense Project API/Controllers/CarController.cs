using Making_Sense_Project_API.Model.Class;
using Making_Sense_Project_API.Model.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Making_Sense_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICarCRUD<Car> _carCRUD;
        public CarController(ICarCRUD<Car> carCRUD)
        {
            _carCRUD = carCRUD;
        }

        [HttpPost("Create")]
        public IActionResult Create(Car car)
        {
            if (_carCRUD.GetById(car.IdCar) != null)
            {
                return BadRequest($"Ya existe un auto con id {car.IdCar} creado");
            }
            _carCRUD.Create(car);
            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Update(Car car)
        {
            if (_carCRUD.GetById(car.IdCar) == null)
            {
                return NotFound($"No se encontro auto con id {car.IdCar} para actualizar");
            }
            _carCRUD.Update(car);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int idCar)
        {
            if (_carCRUD.GetById(idCar) == null)
            {
                return NotFound($"No se encontro auto con id {idCar} para eliminar");
            }
            _carCRUD.DeleteById(idCar);
            return Ok();
        }

        [HttpGet("byId")]
        public IActionResult Get(int idCar)
        {

            if (_carCRUD.GetById(idCar) == null)
            {
                return NotFound($"No se encontro auto con id {idCar} registrado");
            }
            return Ok(_carCRUD.GetById(idCar));
        }

        [HttpGet("All")]
        public IActionResult GetAll()
        {
            IList<Car> list = _carCRUD.GetAll();
            return Ok(list.OrderBy(x => x.IdCar));
        }
    }
}
