using LuckyCat.Enums;

namespace LuckyCat.Models;

public class OrderDto
{
    public Dictionary<Product, int> OrderedProducts { get; set; }
    public decimal ExtraAmount { get; set; }
}