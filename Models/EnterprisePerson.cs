using System.ComponentModel.DataAnnotations;

namespace CustomerApi.Models;

public class EnterprisePerson : Person
{    
    [Required]
    [StringLength(100, MinimumLength = 5)]
    public string? CorporateName { get; set; }
    
    [Required]
    [StringLength(80, MinimumLength = 2)]
    public string? FantasyName { get; set; }
    
    [Required]
    [StringLength(19, MinimumLength = 14)]
    public string? Document { get; set; }

}