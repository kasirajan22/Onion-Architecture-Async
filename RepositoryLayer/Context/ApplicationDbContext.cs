using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;


namespace RepositoryLayer.Context
{
    public partial class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Customer> Customer { get; set; }
    }
}
