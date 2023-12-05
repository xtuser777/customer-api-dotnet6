using System.ComponentModel.DataAnnotations;

namespace CustomerApi.Models;

public class Customer
{
    [Key]
    public int Id { get; set; }
    
    public int PersonId { get; set; }
    public Person? Person { get; set; }
}