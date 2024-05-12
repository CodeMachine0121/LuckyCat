using LuckyCat.Interface;
using LuckyCat.Models;
using LuckyCat.Repositories;

namespace LuckyCat.Services;

public class OrderService(IOrderRepository orderRepository, IPriceRepository priceRepository) : IOrderService
{

    public async Task StoreOrder(OrderDto dto)
    {
        var orderedProductItems = dto.OrderedProductsAndAmount.Keys.ToList();
        var prizeBy = priceRepository.GetPrizeBy(orderedProductItems);

        var orderDomain = new OrderDomain()
        {
            TotalAmount = dto.ExtraAmount,
            OrderedProducts = dto.OrderedProductsAndAmount
        };

        orderedProductItems.ForEach(x =>
            orderDomain.TotalAmount +=
                prizeBy.First(p => p.Product == x).PriceAmount * dto.OrderedProductsAndAmount[x]);

        await orderRepository.SaveOrder(orderDomain);
    }
}