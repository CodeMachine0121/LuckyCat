using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LuckyCat.Enums;
using LuckyCat.Models;
using LuckyCat.Repositories;

namespace LuckyCat.DataBase.Entity;

[Table("price")]
public class Price: BaseEntityIntId
{
    [Required] 
    public Product Product { get; set; }
    
    [Required]
    public decimal Amount { get; set; }

    public PriceDomain ToDomain()
    {
        return new PriceDomain()
        {
            Product = Product ,
            PriceAmount = Amount
        };
    }
}