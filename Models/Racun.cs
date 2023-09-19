namespace InvoiceApiProject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("racuni_table")]
public class Racun  {
    [Key]
    [Column("id")]
    public int Id {get; set;}
    [Required(ErrorMessage = "DatumUstvarjanja polje je obvezno.")]
    [Column("date_of_creation")]
    public required DateTime DateOfCreation { get; set; }
    [Required(ErrorMessage = "znesek je obvezen.")]
    [Column("znesek")]
    public required float Znesek { get; set; }
    [ForeignKey("org_id")]
    public int OrgId {get; set;}
    [ForeignKey("stranka_id")]
    public int StrankaId { get; set; }
    [ForeignKey("artikel_id")]
    public int ArtikelId { get; set; }
    public required Artikel Artikel {get; set;}

    public required Stranka Stranka { get; set; }
    public required Organizacija Organizacija {get; set;}
}