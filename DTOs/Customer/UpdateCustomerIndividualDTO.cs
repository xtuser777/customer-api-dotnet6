namespace CustomerApi.DTOs.Customer;

public class UpdateCustomerIndividualDTO : CreateCustomerIndividualDTO
{
    public int Id { get; set; }

    public UpdateCustomerIndividualDTO(
        int id, 
        string name, 
        string document, 
        string birth, 
        string street, 
        string number, 
        string neighborhood, 
        string complement, 
        string code, 
        string city, 
        string state, 
        string phone, 
        string cellphone, 
        string email
    ) : base(name, document, birth, street, number, neighborhood, complement, code, city, state, phone, cellphone, email)
    {
        Id = id;
    }
}