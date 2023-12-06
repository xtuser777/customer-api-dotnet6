namespace CustomerApi.DTOs.Customer;

public class UpdateCustomerEnterpriseDTO : CreateCustomerEnterpriseDTO
{
    public UpdateCustomerEnterpriseDTO(
        int id, 
        string corporateName, 
        string fantasyName, 
        string document, 
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
    ) : base(corporateName, fantasyName, document, street, number, neighborhood, complement, code, city, state, phone, cellphone, email)
    {
        Id = id;
    }

    public int Id { get; set; }

    
}