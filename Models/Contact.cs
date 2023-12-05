using System.ComponentModel.DataAnnotations;

namespace CustomerApi.Models;

public class Contact
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(14, MinimumLength = 10)]
    public string Phone { get; set; }
    
    [Required]
    [StringLength(15, MinimumLength = 11)]
    public string Cellphone { get; set; }
    
    [Required]
    [EmailAddress]
    [StringLength(14, MinimumLength = 10)]
    public string Email { get; set; }

    public Contact(int id, string phone, string cellphone, string email)
    {
        Id = id;
        Phone = phone;
        Cellphone = cellphone;
        Email = email;
    }
}