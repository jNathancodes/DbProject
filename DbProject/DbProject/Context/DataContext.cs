using DbProject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject.Context
{
    internal class DataContext : DbContext 
    {
        private readonly string _connectionString = "Server=localhost;Database=CaseDb;Encrypt=False;Trusted_Connection=True;";

        public DbSet<CaseEntity> Cases { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<AddressEntity> Address { get; set; }
        public DbSet<CommentEntity> Comment { get; set; }

        public DataContext() 
        {

        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
