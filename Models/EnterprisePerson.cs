using System.ComponentModel.DataAnnotations;

namespace CustomerApi.Models;

public class EnterprisePerson
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(100, MinimumLength = 5)]
    public string CorporateName { get; set; }
    
    [Required]
    [StringLength(80, MinimumLength = 2)]
    public string FantasyName { get; set; }
    
    [Required]
    [StringLength(19, MinimumLength = 14)]
    public string Document { get; set; }

    public EnterprisePerson(int id, string corporateName, string fantasyName, string document)
    {
        Id = id;
        CorporateName = corporateName;
        FantasyName = fantasyName;
        Document = document;
    }

    public EnterprisePerson()
    {
    }
}