using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RespositoryPattern
{
   public interface IRepository<T> where T: Customer
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(Guid Id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
