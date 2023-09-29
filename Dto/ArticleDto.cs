using AutoMapper;

namespace InvoiceApiProject.DTOs;

using System.ComponentModel.DataAnnotations;

public class ArticleDto
{
    public int Id { get; set; }

[Required(ErrorMessage = "Polje ime je obvezno.")]
public string Name { get; set; }

[Required(ErrorMessage = "Polje cena je obvezno.")]
public float Price { get; set; }}
