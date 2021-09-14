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

        [HttpGet("byId")]
        public IActionResult Get(int idCar)
        {
            Car car;
            try
            {
                car = _carCRUD.GetById(idCar);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(car);
        }

        [HttpGet("All")]
        public IActionResult GetAll()
        {
            IList<Car> list = _carCRUD.GetAll();
            return Ok(list.OrderBy(x => x.IdCar));
        }

        [HttpDelete]
        public IActionResult Delete(int idCar)
        {
            try
            {
                _carCRUD.DeleteById(idCar);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpPost("Create")]
        public IActionResult Create(Car car)
        {
            try
            {
                _carCRUD.Create(car);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpPut("Update")]
        public IActionResult Update(Car car)
        {
            try
            {
                _carCRUD.Update(car);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

    }
}
