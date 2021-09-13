using Making_Sense_Project_API.Model.Class;
using Making_Sense_Project_API.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Making_Sense_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICRUD<Car> _carCRUD;
        public CarController(ICRUD<Car> carCRUD)
        {
            _carCRUD = carCRUD;
        }

        [HttpGet("byId")]
        public IActionResult Get(int idCar)
        {
            Car car = _carCRUD.GetById(idCar);
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
            _carCRUD.DeleteById(idCar);
            return Ok();
        }
        [HttpPost("Create")]
        public IActionResult Create(Car car)
        {
            _carCRUD.Create(car);
            return Ok();
        }
        [HttpPut("Update")]
        public IActionResult Update(Car car)
        {
            _carCRUD.Update(car);
            return Ok();
        }

    }
}
