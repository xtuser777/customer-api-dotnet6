using System.ComponentModel.DataAnnotations;

namespace CustomerApi.Models;

public class Customer : IndividualPerson 
{
    [Key]
    public int Id { get; set; }
}