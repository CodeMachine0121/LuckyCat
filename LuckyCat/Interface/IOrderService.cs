using LuckyCat.Models;

namespace LuckyCat.Interface;

public interface IOrderService
{
    Task StoreOrder(OrderDto dto);
}