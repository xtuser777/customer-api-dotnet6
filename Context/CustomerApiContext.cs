using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Context;

public class CustomerApiContext : DbContext
{
    public CustomerApiContext(DbContextOptions<CustomerApiContext> options) : base(options)
    { }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}