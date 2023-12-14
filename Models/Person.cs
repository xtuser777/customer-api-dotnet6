using System.ComponentModel.DataAnnotations;

namespace CustomerApi.Models;

public class Person
{
    [Required]
    [StringLength(80, MinimumLength = 2)]
    public string? Street { get; set; }

    [Required]
    [StringLength(5, MinimumLength = 1)]
    public string? Number { get; set; }

    [Required]
    [StringLength(40, MinimumLength = 5)]
    public string? Neighborhood { get; set; }

    [StringLength(30)]
    public string? Complement { get; set; }

    [Required]
    [StringLength(10, MinimumLength = 8)]
    public string? Code { get; set; }

    [Required]
    [StringLength(80, MinimumLength = 5)]
    public string? City { get; set; }

    [Required]
    [StringLength(2, MinimumLength = 2)]
    public string? State { get; set; }

    [Required]
    [StringLength(14, MinimumLength = 10)]
    public string? Phone { get; set; }

    [Required]
    [StringLength(15, MinimumLength = 11)]
    public string? Cellphone { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(100, MinimumLength = 10)]
    public string? Email { get; set; }
}