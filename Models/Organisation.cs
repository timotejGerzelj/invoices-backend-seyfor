namespace InvoiceApiProject.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("organisation_table")]
public class Organizacija  {
    [Key]
    [Column("id")]
    public int Id {get; set;}
    [Required(ErrorMessage = "polje ime je obvezno.")]
    [Column("ime")]
    public required string Ime { get; set; }
    [Required(ErrorMessage = "polje opis je obvezno.")]
    [Column("opis")]
    public required string Opis { get; set; }
}