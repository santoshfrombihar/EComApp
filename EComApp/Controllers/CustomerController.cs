using EComApp.DTOs;
using EComApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EComApp.Controllers
{
    [ApiController]
    [Route("customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        
        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse<CustomerResponseDTO>>> RegisterCustomer([FromBody] CustomerRegistrationDTO customerRegistration)
        {
            var response = await _customerService.RegisterCustomer(customerRegistration);
            if(response.StatusCode != 201)
            {
                return StatusCode(response.StatusCode, response);
            }
            return Ok(response);
        }
    }
}
