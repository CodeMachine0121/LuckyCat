using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuckyCat.DataBase.Entity;

[Table("order")]
public class Order: BaseEntityIntId
{
    [Required] 
    public decimal TotalAmount { get; set; }
    
    [Required]
    public Dictionary<string, int> OrderedProduct { get; set; }
}