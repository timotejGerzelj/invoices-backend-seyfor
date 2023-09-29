namespace InvoiceApiProject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("articles_table")]
public class Article  {
[Key]
[Column("id")]
public int Id {get; set;}
[Required(ErrorMessage = "Polje ime je obvezno.")]
[Column("name")]
public string Name { get; set; }

[Required(ErrorMessage = "Polje cena je obvezno.")]
[Column("price")]
public float Price { get; set; }

}