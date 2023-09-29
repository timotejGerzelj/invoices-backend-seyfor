namespace InvoiceApiProject.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("organisation_table")]
public class Organisation  {
    [Key]
    [Column("id")]
    public int Id {get; set;}
    [Required(ErrorMessage = "polje ime je obvezno.")]
    [Column("name")]
    public required string Name { get; set; }
    [Required(ErrorMessage = "polje opis je obvezno.")]
    [Column("description")]
    public required string Description { get; set; }
}