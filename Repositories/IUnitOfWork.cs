namespace CustomerApi.Repositories
{
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
        Task Commit();
    }
}
