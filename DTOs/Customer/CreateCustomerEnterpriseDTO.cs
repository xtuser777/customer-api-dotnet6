namespace CustomerApi.DTOs.Customer;

public class CreateCustomerEnterpriseDTO
{
    public string CorporateName { get; set; }
    public string FantasyName { get; set; }
    public string Document { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string Neighborhood { get; set; }
    public string Complement { get; set; }
    public string Code { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Phone { get; set; }
    public string Cellphone { get; set; }
    public string Email { get; set; }

    public CreateCustomerEnterpriseDTO(string corporateName, string fantasyName, string document, string street, string number, string neighborhood, string complement, string code, string city, string state, string phone, string cellphone, string email)
    {
        CorporateName = corporateName;
        FantasyName = fantasyName;
        Document = document;
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        Complement = complement;
        Code = code;
        City = city;
        State = state;
        Phone = phone;
        Cellphone = cellphone;
        Email = email;
    }
}