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
    [ForeignKey("OrgId")]
    [Column("org_id")]
    public int OrgId {get; set;}
    [ForeignKey("Stranka")]
    [Column("stranka_id")]
    public int StrankaId { get; set; }
    public virtual ICollection<RacunVrstica> LineItems { get; set; } // Add this navigation property

    public Stranka? Stranka { get; set; }
    public Organizacija? Organizacija {get; set;}
}