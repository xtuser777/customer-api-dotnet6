namespace CustomerApi.Repositories
{
    public interface IUnitOfWork
    {
        IAddressRepository AddressRepository { get; }
        IContactRepository ContactRepository { get; }
        IIndividualPersonRepository IndividualPersonRepository { get; }
        IEnterprisePersonRepository EnterprisePersonRepository { get; }
        IPersonRepository PersonRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        Task Commit();
    }
}
