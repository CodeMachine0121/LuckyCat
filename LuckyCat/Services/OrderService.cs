using LuckyCat.Interface;
using LuckyCat.Models;
using LuckyCat.Repositories;

namespace LuckyCat.Services;

public class OrderService(IOrderRepository orderRepository) : IOrderService
{

    public void StoreOrder(OrderDto dto)
    {
        var prizeBy = orderRepository.GetPrizeBy(dto.OrderedProducts.Keys.ToList());

        var orderDomain = new OrderDomain()
        {
            TotalAmount = dto.ExtraAmount
        };
        
        dto.OrderedProducts.Keys.ToList().ForEach(x=> 
            orderDomain.TotalAmount += prizeBy[x] * dto.OrderedProducts[x]);

        orderRepository.SaveOrder(orderDomain);
    }
}