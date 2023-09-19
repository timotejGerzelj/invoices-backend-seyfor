using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InvoiceApiProject.Models;

[Table("stranka_table")]
public class Stranka {
    [Key]
    [Column("id")]
    public int Id {get; set;}
    [Required(ErrorMessage = "Polje ime je obvezno.")]
    [Column("ime")]
    public required string Ime { get; set; }
    [Required(ErrorMessage = "polje naslov je obvezen.")]
    [Column("naslov")]
    public required string Naslov { get; set; }
}