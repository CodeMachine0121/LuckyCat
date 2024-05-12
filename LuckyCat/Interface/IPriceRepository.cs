using LuckyCat.Enums;

namespace LuckyCat.Interface;

public interface IPriceRepository
{
    Dictionary<Product, decimal> GetPrizeBy(List<Product> any);
}