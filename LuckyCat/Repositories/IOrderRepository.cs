using LuckyCat.Enums;
using LuckyCat.Models;

namespace LuckyCat.Repositories;

public interface IOrderRepository
{
    Task SaveOrder(OrderDomain domain);
    Dictionary<Product, decimal> GetPrizeBy(List<Product> any);
}