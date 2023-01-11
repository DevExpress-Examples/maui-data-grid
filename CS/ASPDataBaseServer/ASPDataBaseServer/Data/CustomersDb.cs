using System;
using Microsoft.EntityFrameworkCore;
using ASPDataBaseServer.Model;

namespace ASPDataBaseServer.Data
{
	public class CustomersContext : DbContext
    {
        static readonly DbContextOptions<CustomersContext> options = new DbContextOptionsBuilder<CustomersContext>()
           .UseInMemoryDatabase(databaseName: "Test")
           .Options;

        public CustomersContext() : base(options) { }

        public DbSet<Customer> Customers => Set<Customer>();
    }
}

