using LuckyCat.Enums;
using LuckyCat.Models;

namespace LuckyCat.Repositories;

public class OrderRepository: IOrderRepository
{
    public void SaveOrder(OrderDomain domain)
    {
        
    }

    public Dictionary<Product, decimal> GetPrizeBy(List<Product> any)
    {
        return new Dictionary<Product, decimal>()
        {
            {Product.SauceDuckRice, 40m},
        };
    }
}