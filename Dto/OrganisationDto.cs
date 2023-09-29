namespace InvoiceApiProject.DTOs;
using System.ComponentModel.DataAnnotations;

public class OrganisationDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Polje ime je obvezno.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Polje opis je obvezno.")]
    public string Description { get; set; }
}
