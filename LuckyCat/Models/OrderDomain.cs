using LuckyCat.Enums;

namespace LuckyCat.Models;

public class OrderDomain
{
    public string RefNo { get; set; }
    public decimal TotalAmount { get; set; }
    public Dictionary<Product, int> OrderedProducts { get; set; }
}