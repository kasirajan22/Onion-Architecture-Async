using System;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer.Context
{
    public interface IApplicationDbContext
    {
        DbSet<Customer> Customer { get; set; }
    }
}
