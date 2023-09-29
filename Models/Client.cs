using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("client_table")]
public class Client {
    [Key]
    [Column("id")]
    public int Id {get; set;}
    [Required(ErrorMessage = "Polje ime je obvezno.")]
    [Column("name")]
    public required string Name { get; set; }
    [Required(ErrorMessage = "polje naslov je obvezen.")]
    [Column("address")]
    public required string Address { get; set; }
}