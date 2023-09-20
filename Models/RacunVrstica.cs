using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InvoiceApiProject.Models;


[Table("line_items")]
public class RacunVrstica
{
        [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Quantity is required.")]
    [Column("quantity")]
    public int Kvantiteta { get; set; }

    [ForeignKey("invoice_id")]
    public int RacunId { get; set; }
    public Racun Racun { get; set; }

    [ForeignKey("article_id")]
    public int ArtikelId { get; set; }
    public Artikel Artikel { get; set; }
}

