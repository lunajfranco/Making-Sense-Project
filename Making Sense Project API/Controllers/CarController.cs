using Making_Sense_Project.Model;
using Making_Sense_Project_API.Model.Repostory;
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
            Car car = _carCRUD.GetById(idCar);
            return Ok(car);
        }

        [HttpGet("All")]
        public IActionResult GetAll()
        {
            var list = _carCRUD.GetAll();
            return Ok(list);
        }

        [HttpDelete]
        public IActionResult Delete(int idCar)
        {
            _carCRUD.DeleteById(idCar);
            return Ok();
        }
        [HttpPut("Create")]
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
