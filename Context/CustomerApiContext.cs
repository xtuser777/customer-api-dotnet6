using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Context;

public class CustomerApiContext : DbContext
{
    public CustomerApiContext(DbContextOptions<CustomerApiContext> options) : base(options)
    { }

    public DbSet<Address> Addresses { get; set; }

    public DbSet<Contact> Contacts { get; set; }
}