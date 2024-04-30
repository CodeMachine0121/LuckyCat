using LuckyCat.Enums;

namespace LuckyCat.Models;

public class OrderDto
{
    public List<Product> Products { get; set; }
    public decimal ExtraAmount { get; set; }
}