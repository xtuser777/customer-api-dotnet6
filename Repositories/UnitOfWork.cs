
using CustomerApi.Context;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private CustomerApiContext _context;

        private AddressRepository _addressRepository;
        private ContactRepository _contactRepository;
        private IndividualPersonRepository _individualPersonRepository;
        private EnterprisePersonRepository _enterprisePersonRepository;
        private PersonRepository _personRepository;
        private CustomerRepository _customerRepository;

        public UnitOfWork(CustomerApiContext context)
        {
            _context = context;
        }

        public IAddressRepository AddressRepository
        {
            get { return _addressRepository ?? new AddressRepository(_context); }
        }

        public IContactRepository ContactRepository
        {
            get { return _contactRepository ?? new ContactRepository(_context); }
        }

        public IIndividualPersonRepository IndividualPersonRepository
        {
            get { return _individualPersonRepository ?? new IndividualPersonRepository(_context); }
        }

        public IEnterprisePersonRepository EnterprisePersonRepository
        {
            get { return _enterprisePersonRepository ?? new EnterprisePersonRepository(_context); }
        }

        public IPersonRepository PersonRepository
        {
            get { return _personRepository ?? new PersonRepository(_context); }
        }

        public ICustomerRepository CustomerRepository
        {
            get { return _customerRepository ?? new CustomerRepository(_context); }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
