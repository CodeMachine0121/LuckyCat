using LuckyCat.Enums;
using LuckyCat.Interface;

namespace LuckyCat.Repositories;

public class PriceRepository : IPriceRepository
{
    public Dictionary<Product, decimal> GetPrizeBy(List<Product> any)
    {
        return new Dictionary<Product, decimal>()
        {
            {
                Product.SauceDuckRice, 20
            }
        };
    }
}