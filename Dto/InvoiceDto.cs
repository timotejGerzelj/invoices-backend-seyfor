namespace InvoiceApiProject.DTOs;
using System.ComponentModel.DataAnnotations;

public class InvoiceDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "DatumUstvarjanja polje je obvezno.")]
    public DateTime DateOfCreation { get; set; }

    [Required(ErrorMessage = "Znesek je obvezen.")]
    public float Price { get; set; }
    public int OrgId { get; set; }
    public int ClientId { get; set; }
}
