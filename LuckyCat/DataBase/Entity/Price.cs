using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LuckyCat.Enums;

namespace LuckyCat.DataBase.Entity;

[Table("price")]
public class Price: BaseEntityIntId
{
    [Required] 
    public Product Product { get; set; }
    
    [Required]
    public decimal Amount { get; set; }
}