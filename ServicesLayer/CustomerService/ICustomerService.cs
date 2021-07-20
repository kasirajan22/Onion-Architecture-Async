
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesLayer.CustomerService
{
   public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomer(Guid id);
        Task InsertCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task DeleteCustomer(Guid id);
    }
}
