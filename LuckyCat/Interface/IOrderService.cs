using LuckyCat.Models;

namespace LuckyCat.Interface;

public interface IOrderService
{
    void StoreOrder(OrderDto dto);
}