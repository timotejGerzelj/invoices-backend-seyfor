using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using InvoiceApiProject.Models;


[Table("line_items")]
public class RacunVrstica
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Quantity is required.")]
    [Column("quantity")]
    public int Kolicina { get; set; }
    [ForeignKey("Racun")]
    [Column("invoice_id")]
    public int RacunId { get; set; }
    [JsonIgnore]
    public Racun? Racun { get; set; }   
    [ForeignKey("Artikel")]
    [Column("article_id")]
    public int ArtikelId { get; set; }
    public Artikel? Artikel { get; set; }
}

