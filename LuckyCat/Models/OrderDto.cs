using LuckyCat.Enums;

namespace LuckyCat.Models;

public class OrderDto
{
    public Dictionary<Product, int> OrderedProductsAndAmount { get; set; }
    public decimal ExtraAmount { get; set; }
}