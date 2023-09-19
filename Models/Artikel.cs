namespace InvoiceApiProject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("artikli_table")]
public class Artikel  {
    [Key]
    [Column("id")]
    public int Id {get; set;}
    [Required(ErrorMessage = "polje ime je obvezno.")]
    [Column("ime")]
    public required string Ime { get; set; }
    [Required(ErrorMessage = "polje cena je obvezna.")]
    [Column("cena")]
    public required float Cena {get; set;}

}