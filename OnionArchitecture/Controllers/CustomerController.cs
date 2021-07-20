using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer;
using ServicesLayer.CustomerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnionArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        #region Property
        private readonly ICustomerService _customerService;
        #endregion

        #region Constructor
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        #endregion

        [HttpPost(nameof(GetCustomer))]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            var result = await _customerService.GetCustomer(id);
            if(result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
            
        }
        [HttpPost(nameof(GetAllCustomer))]
        public async Task<IActionResult> GetAllCustomer()
        {
            var result = await _customerService.GetAllCustomers();
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");

        }
        [HttpPost(nameof(InsertCustomer))]
        public async Task<IActionResult> InsertCustomer(Customer customer)
        {
           await _customerService.InsertCustomer(customer);
            return Ok("Data inserted");

        }
        [HttpPost(nameof(UpdateCustomer))]
        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            await _customerService.UpdateCustomer(customer);
            return Ok("Updation done");

        }
        [HttpPost(nameof(DeleteCustomer))]
        public async Task<IActionResult> DeleteCustomer(Guid Id)
        {
            await _customerService.DeleteCustomer(Id);
            return Ok("Data Deleted");

        }
    }
}
