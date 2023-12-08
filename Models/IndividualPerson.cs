using System.ComponentModel.DataAnnotations;

namespace CustomerApi.Models;

public class IndividualPerson
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(80, MinimumLength = 5)]
    public string? Name { get; set; }
    
    [Required]
    [StringLength(14, MinimumLength = 11)]
    public string? Document { get; set; }
    
    [Required]
    public DateTime Birth { get; set; }
}