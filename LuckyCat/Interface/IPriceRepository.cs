using LuckyCat.Enums;
using LuckyCat.Models;
using LuckyCat.Repositories;

namespace LuckyCat.Interface;

public interface IPriceRepository
{
    List<PriceDomain> GetPrizeBy(List<Product> orderedProduct);
}