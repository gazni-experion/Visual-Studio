using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Repository;
using DatingApp.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace DatingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepo _cust;

        public CustomersController(ICustomerRepo cust)
        {
            _cust = cust;
        }

        //Method for showing all customers
        [HttpGet("allcustomers")]       //----/api/customers/allcustomers
        [Authorize]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                var customers = await _cust.GetAllCustomers();
                if (customers == null)
                {
                    return NotFound();
                }
                return Ok(customers);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //Method for getting a customer by id
        [HttpGet("id")]      //----/api/customers/id
        [Authorize]
        public async Task<IActionResult> GetCustomer(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                var customers = await _cust.GetCustomer(id);
                if (customers == null)
                {
                    return NotFound();
                }
                return Ok(customers);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
