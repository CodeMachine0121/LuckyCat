using LuckyCat.Enums;

namespace LuckyCat.Models;

public class OrderRequest
{
    public List<int> ProductIds { get; set; }
    public decimal ExtraAmount { get; set; }

    public OrderDto ToDto()
    {
        return new OrderDto
        {
            Products = ProductIds.Select(x=> (Product)Enum.Parse(typeof(Product), x.ToString())).ToList(),
            ExtraAmount = ExtraAmount
        };
    }
}