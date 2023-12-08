using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Context;

public class CustomerApiContext : DbContext
{
    public CustomerApiContext(DbContextOptions<CustomerApiContext> options) : base(options)
    { }

    public DbSet<Address> Addresses { get; set; }

    public DbSet<Contact> Contacts { get; set; }

    public DbSet<IndividualPerson> IndividualPersons { get; set; }

    public DbSet<EnterprisePerson> EnterprisePersons { get; set; }

    public DbSet<Person> Persons { get; set; }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().Navigation(c => c.Person).AutoInclude();
        modelBuilder.Entity<Person>().Navigation(p => p.IndividualPerson).AutoInclude();
        modelBuilder.Entity<Person>().Navigation(p => p.EnterprisePerson).AutoInclude();
        modelBuilder.Entity<Person>().Navigation(p => p.Address).AutoInclude();
        modelBuilder.Entity<Person>().Navigation(p => p.Contact).AutoInclude();
    }
}