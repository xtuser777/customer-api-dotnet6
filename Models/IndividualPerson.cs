using System.ComponentModel.DataAnnotations;

namespace CustomerApi.Models;

public class IndividualPerson
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(80, MinimumLength = 5)]
    public string Nome { get; set; }
    
    [Required]
    [StringLength(14, MinimumLength = 11)]
    public string Document { get; set; }
    
    [Required]
    public DateTime Birth { get; set; }

    public IndividualPerson(int id, string nome, string document, DateTime birth)
    {
        Id = id;
        Nome = nome;
        Document = document;
        Birth = birth;
    }
}