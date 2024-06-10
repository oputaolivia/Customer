using CustomerAPI.Models;
using CustomerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net.Http;

namespace CustomerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly HttpClient _httpClient;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("onboard")]
        public async Task<IActionResult> OnboardCustomer([FromBody] Customer customer)
        {
            try
            {
                var onboardedCustomer = await _customerService.OnboardCustomerAsync(customer);
                return Ok(onboardedCustomer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("banks")]
        public async Task<IActionResult> GetBanks()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync("https://wema-alatdev-apimgt.azure-api.net/alat-test/api/Shared/GetAllBanks");
                    return Ok(response);
                }
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error fetching banks: " + ex.Message);
            }
        }

    }
}
