using LuckyCat.Interface;
using LuckyCat.Models;
using LuckyCat.Repositories;

namespace LuckyCat.Services;

public class OrderService: IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public void StoreOrder(OrderDto dto)
    {
        var prizeBy = _orderRepository.GetPrizeBy(dto.OrderedProducts.Keys.ToList());

        var orderDomain = new OrderDomain()
        {
            TotalAmount = dto.ExtraAmount
        };
        
        dto.OrderedProducts.Keys.ToList().ForEach(x=> 
            orderDomain.TotalAmount += prizeBy[x] * dto.OrderedProducts[x]);

        _orderRepository.SaveOrder(orderDomain);
    }
}