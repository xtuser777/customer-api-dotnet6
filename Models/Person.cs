using System.ComponentModel.DataAnnotations;

namespace CustomerApi.Models;

public class Person
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [Range(1, 2)]
    public int Type { get; set; }
    
    public int IndividualPersonId { get; set; }
    public IndividualPerson? IndividualPerson { get; set; }
    
    public int EnterprisePersonId { get; set; }
    public EnterprisePerson? EnterprisePerson { get; set; }
    
    public int AddressId { get; set; }
    public Address? Address { get; set; }
    
    public int ContactId { get; set; }
    public Contact? Contact { get; set; }

}