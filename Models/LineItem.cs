using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using InvoiceApiProject.Models;


[Table("line_items_table")]
public class LineItem
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Quantity is required.")]
    [Column("quantity")]
    public int Quantity { get; set; }
    [ForeignKey("Invoice")]
    [Column("invoice_id")]
    public int InvoiceId { get; set; }
    [JsonIgnore]
    public Invoice? Invoice { get; set; }   
    [ForeignKey("Article")]
    [Column("article_id")]
    public int ArticleId { get; set; }
}

