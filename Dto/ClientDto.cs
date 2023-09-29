namespace InvoiceApiProject.DTOs;

using System.ComponentModel.DataAnnotations;

public class ClientDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Polje ime je obvezno.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Polje naslov je obvezen.")]
    public string Address { get; set; }
}