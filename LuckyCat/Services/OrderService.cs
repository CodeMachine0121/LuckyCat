using LuckyCat.Interface;
using LuckyCat.Models;
using LuckyCat.Repositories;

namespace LuckyCat.Services;

public class OrderService(IOrderRepository orderRepository, IPriceRepository prizeRepository) : IOrderService
{

    public async Task StoreOrder(OrderDto dto)
    {
        var orderedProductItems = dto.OrderedProducts.Keys.ToList();
        var prizeBy = prizeRepository.GetPrizeBy(orderedProductItems);

        var orderDomain = new OrderDomain()
        {
            TotalAmount = dto.ExtraAmount,
            OrderedProducts = dto.OrderedProducts
        };
        
        orderedProductItems.ForEach(x=> orderDomain.TotalAmount += prizeBy[x] * dto.OrderedProducts[x]);

        await orderRepository.SaveOrder(orderDomain);
    }
}