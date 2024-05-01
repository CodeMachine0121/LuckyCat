using LuckyCat.Enums;

namespace LuckyCat.Models;

public class OrderDomain
{
    public decimal TotalAmount { get; set; }
    public Dictionary<Product, int> OrderedProducts { get; set; }
}