using LuckyCat.Enums;
using LuckyCat.Models;

namespace LuckyCat.Repositories;

public interface IOrderRepository
{
    Task SaveOrder(OrderDomain domain);
}