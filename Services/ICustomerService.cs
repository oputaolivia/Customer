using CustomerAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerAPI.Services
{
    public interface ICustomerService
    {
        Task<string> SendOtpAsync(string phoneNumber);
        Task<bool> ValidateOtpAsync(string phoneNumber, string otp);
        Task<Customer> OnboardCustomerAsync(Customer customer);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
    }
}
