using System.Text.Json;
using LuckyCat.DataBase;
using LuckyCat.DataBase.Entity;
using LuckyCat.Models;
using Microsoft.EntityFrameworkCore;

namespace LuckyCat.Repositories;

public class OrderRepository(LuckyDbContext context) : BaseRepository(context), IOrderRepository
{
    private readonly DbSet<Order> _repo = context.Order;

    public async Task SaveOrder(OrderDomain domain)
    {
        var orderedProducts = new Dictionary<string, int>();
        domain.OrderedProducts.Keys.ToList().ForEach(x=> orderedProducts.Add(x.ToString(), domain.OrderedProducts[x]));

        _repo.Add(new Order
        {
            RefNo = domain.RefNo,
            CreatedOn = DateTime.Now,
            CreatedBy = "System",
            TotalAmount = domain.TotalAmount,
            OrderedProduct = JsonSerializer.Serialize(orderedProducts)
        });

        await SaveChangesAsync();
    }
}