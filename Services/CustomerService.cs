using CustomerAPI.Models;
using CustomerAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<string> SendOtpAsync(string phoneNumber)
        {
            // Mock sending OTP
            string otp = "1234"; 
            return otp;
        }

        public async Task<bool> ValidateOtpAsync(string phoneNumber, string otp)
        {
            // Validate OTP
            return otp == "1234";
        }

        public async Task<Customer> OnboardCustomerAsync(Customer customer)
        {
            // Validate LGA and State
            if (!ValidateLGAState(customer.State, customer.LGA))
            {
                throw new ArgumentException("LGA does not match the selected state.");
            }

            // Mock OTP validation
            var isOtpValid = await ValidateOtpAsync(customer.PhoneNumber, "1234");
            if (!isOtpValid)
            {
                throw new ArgumentException("Invalid OTP.");
            }

            customer.IsPhoneNumberVerified = true;
            return await _customerRepository.AddCustomerAsync(customer);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllCustomersAsync();
        }

        private bool ValidateLGAState(string state, string lga)
        {
            return true;
        }
    }
}
