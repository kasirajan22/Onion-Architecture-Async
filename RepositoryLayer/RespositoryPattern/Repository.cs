using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RespositoryPattern
{
   public class Repository<T> : IRepository<T> where T: Customer
    {
        #region property
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<T> entities;
        #endregion

        #region Constructor
        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            entities = _applicationDbContext.Set<T>();
        }
        #endregion

        public async Task Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<T> Get(Guid Id)
        {
            return await entities.SingleOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await entities.ToListAsync();
        }

        public async Task Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            await _applicationDbContext.SaveChangesAsync();
        }
        public async Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

    }
}
