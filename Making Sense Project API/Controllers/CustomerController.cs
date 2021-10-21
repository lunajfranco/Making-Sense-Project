using Making_Sense_Project_API.Model.Class;
using Making_Sense_Project_API.Model.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Making_Sense_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerCRUD<Customer> _customerCRUD;

        public CustomerController(ICustomerCRUD<Customer> customerCRUD)
        {
            _customerCRUD = customerCRUD;
        }

        [HttpPost("Create")]
        public IActionResult Create(Customer customer)
        {
            if (_customerCRUD.GetById(customer.DNI) != null)
            {
                return BadRequest($"Ya existe cliente con dni {customer.DNI}");
            }
            _customerCRUD.Create(customer);
            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Update(Customer customer)
        {
            if (_customerCRUD.GetById(customer.DNI) == null)
            {
                return NotFound($"No se encontro cliente con dni {customer.DNI} para actualizar");
            }
            _customerCRUD.Update(customer);
            return Ok();
        }

        [HttpDelete("DeleteByDni")]
        public IActionResult Delete(int dni)
        {
            if (_customerCRUD.GetById(dni) == null)
            {
                return NotFound($"No se encontro cliente con dni {dni} para eliminar");
            }
            _customerCRUD.DeleteById(dni);
            return Ok();
        }

        [HttpGet("GetByDNI")]
        public IActionResult GetByDni(int dni)
        {
            if (_customerCRUD.GetById(dni) == null)
            {
                return NotFound($"No se encontro cliente con dni {dni}");
            }
            return Ok(_customerCRUD.GetById(dni));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            IList<Customer> listCustomers = _customerCRUD.GetAll();
            return Ok(listCustomers.OrderBy(x => x.DNI));
        }
    }
}
