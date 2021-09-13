using Making_Sense_Project_API.Model.Class;
using Making_Sense_Project_API.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Making_Sense_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICRUD<Customer> _customerCRUD;

        public CustomerController(ICRUD<Customer> customerCRUD)
        {
            _customerCRUD = customerCRUD;
        }

        [HttpPost("Create")]
        public IActionResult Create(Customer customer)
        {
            try
            {
                _customerCRUD.Create(customer);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Update(Customer customer)
        {
            try
            {
                _customerCRUD.Update(customer);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpGet("GetByDNI")]
        public IActionResult GetByDni(int dni)
        {
            Customer customer;
            try
            {
                customer = _customerCRUD.GetById(dni);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(customer);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            IList<Customer> listCustomers = _customerCRUD.GetAll();
            return Ok(listCustomers.OrderBy(x => x.DNI));
        }
        
        [HttpDelete("DeleteByDni")]
        public IActionResult Delete(int dni)
        {
            try
            {
                _customerCRUD.DeleteById(dni);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
