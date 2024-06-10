using CustomerAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerAPI.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> AddCustomerAsync(Customer customer);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
    }
}
