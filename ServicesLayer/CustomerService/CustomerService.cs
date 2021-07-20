using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.CustomerService
{
    public class CustomerService : ICustomerService
    {
        #region Property
        private IRepository<Customer> _repository;
        #endregion

        #region Constructor
        public CustomerService(IRepository<Customer> repository)
        {
            _repository = repository;
        }
        #endregion

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _repository.GetAll();
        }

        public async Task<Customer> GetCustomer(Guid id)
        {
            return await _repository.Get(id);
        }

        public async Task InsertCustomer(Customer customer)
        {
            customer.Id = Guid.NewGuid();
            await _repository.Insert(customer);
        }
        public async Task UpdateCustomer(Customer customer)
        {
            await _repository.Update(customer);
        }

        public async Task DeleteCustomer(Guid id)
        {
            Customer customer = await GetCustomer(id);
            await _repository.Delete(customer);
        }

    }
}
