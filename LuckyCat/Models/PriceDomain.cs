using LuckyCat.Enums;

namespace LuckyCat.Models;

public class PriceDomain
{
    public Product Product { get; set; }
    public decimal PriceAmount { get; set; }
}