using LuckyCat.Enums;

namespace LuckyCat.Models;

public class OrderRequest
{
    public Dictionary<int, int> OrderedProductIds { get; set; }
    public decimal ExtraAmount { get; set; }

    public OrderDto ToDto()
    {
        
        return new OrderDto
        {
            
            OrderedProducts = OrderedProductIds.Select(x=> 
                new Dictionary<Product, int>
                {
                    {Enum.Parse<Product>(x.Key.ToString()), x.Value}
                }).First(),
            ExtraAmount = ExtraAmount
        };
    }
}