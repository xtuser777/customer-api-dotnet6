using CustomerApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Context;

public class CustomerApiContext : IdentityDbContext
{
    public CustomerApiContext(DbContextOptions<CustomerApiContext> options) : base(options)
    { }

    public DbSet<Customer> Customers { get; set; }
}