namespace InvoiceApiProject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("invoice_table")]
public class Invoice  {
    [Key]
    [Column("id")]
    public int Id {get; set;}
    [Required(ErrorMessage = "DatumUstvarjanja polje je obvezno.")]
    [Column("date_of_creation")]
    public required DateTime DateOfCreation { get; set; }
    [Required(ErrorMessage = "znesek je obvezen.")]
    [Column("price")]
    public required float Price { get; set; }
    [ForeignKey("OrgId")]
    [Column("org_id")]
    public int OrgId {get; set;}
    [ForeignKey("Client")]
    [Column("client_id")]
    public int ClientId { get; set; }
    public virtual ICollection<LineItem> LineItems { get; set; } // Add this navigation property

    public Client? Client { get; set; }
    public Organisation? Organisation {get; set;}
}