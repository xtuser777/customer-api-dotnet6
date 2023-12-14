
using CustomerApi.Context;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private CustomerApiContext _context;

        private CustomerRepository _customerRepository;

        public UnitOfWork(CustomerApiContext context)
        {
            _context = context;
            _customerRepository = new CustomerRepository(_context);
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
