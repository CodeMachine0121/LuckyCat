using LuckyCat.DataBase;
using LuckyCat.DataBase.Entity;
using LuckyCat.Enums;
using LuckyCat.Models;
using Microsoft.EntityFrameworkCore;

namespace LuckyCat.Repositories;

public class OrderRepository(LuckyDbContext context) : BaseRepository(context), IOrderRepository
{
    private readonly DbSet<Order> _repo = context.Order;

    public void SaveOrder(OrderDomain domain)
    {
        var orderedProducts = new Dictionary<string, int>();
        domain.OrderedProducts.Keys.ToList().ForEach(x=> orderedProducts.Add(x.ToString(), domain.OrderedProducts[x]));

        _repo.Add(new Order
        {
            CreatedOn = DateTime.Now,
            CreatedBy = "System",
            TotalAmount = domain.TotalAmount,
            OrderedProduct = orderedProducts
        });
    }

    public Dictionary<Product, decimal> GetPrizeBy(List<Product> any)
    {
        return new Dictionary<Product, decimal>()
        {
            {Product.SauceDuckRice, 40m},
        };
    }
}