using AutoMapper;
using Making_Sense_Project_API.Model.Class;
using Making_Sense_Project_API.Model.Dtos;
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
        private readonly IMapper _mapper;

        public CustomerController(ICustomerCRUD<Customer> customerCRUD, IMapper mapper)
        {
            _customerCRUD = customerCRUD;
            _mapper = mapper;
        }

        [HttpPost("Create")]
        public IActionResult Create(CustomerDto customerDto)
        {
            if (_customerCRUD.GetById(customerDto.DNI) != null)
            {
                return BadRequest($"Ya existe cliente con dni {nameof(customerDto.DNI)}");
            }
            var customer = _mapper.Map<Customer>(customerDto);
            if (!_customerCRUD.Create(customer))
            {
                ModelState.AddModelError("", "Algo salio mal");
                return StatusCode(505, ModelState);
            }
            return NoContent();
        }

        [HttpPut("Update")]
        public IActionResult Update(int dni, CustomerDto customerDto)
        {
            var customer = _customerCRUD.GetById(dni);
            if (customer == null)
            {
                return NotFound($"No se encontro cliente con dni {nameof(dni)} para actualizar");
            }
            customer = _mapper.Map(customerDto, customer);
            if (!_customerCRUD.Update(customer))
            {
                ModelState.AddModelError("", "Algo salio mal");
                return StatusCode(505, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("DeleteByDni")]
        public IActionResult Delete(int dni)
        {
            if (_customerCRUD.GetById(dni) == null)
            {
                return NotFound($"No se encontro cliente con dni {nameof(dni)} para eliminar");
            }
            if (!_customerCRUD.Delete(_customerCRUD.GetById(dni)))
            {
                ModelState.AddModelError("", "Algo salio mal");
                return StatusCode(505, ModelState);
            }
            return NoContent();
        }

        [HttpGet("GetByDNI")]
        public IActionResult GetByDni(int dni)
        {
            var customer = _customerCRUD.GetById(dni);
            if (customer == null)
            {
                return NotFound($"No se encontro cliente con dni {nameof(dni)}");
            }
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return Ok(customerDto);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var listCustomer = _customerCRUD.GetAll();
            if (listCustomer.Count == 0)
            {
                return NotFound();
            }
            var listCustomerDtos = new List<CustomerDto>();

            foreach (var item in listCustomer)
            {
                listCustomerDtos.Add(_mapper.Map<CustomerDto>(item));
            }

            return Ok(listCustomerDtos);
        }
    }
}
