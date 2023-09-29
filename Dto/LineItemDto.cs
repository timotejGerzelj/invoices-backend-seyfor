namespace InvoiceApiProject.DTOs;
using System.ComponentModel.DataAnnotations;

public class LineItemDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Quantity is required.")]
    public int Quantity { get; set; }
    public int InvoiceId { get; set; }
    public int ArticleId { get; set; }
}
