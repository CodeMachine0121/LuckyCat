using LuckyCat.DataBase;
using LuckyCat.DataBase.Entity;
using LuckyCat.Enums;
using LuckyCat.Interface;
using LuckyCat.Models;
using Microsoft.EntityFrameworkCore;

namespace LuckyCat.Repositories;

public class PriceRepository(LuckyDbContext context) : IPriceRepository
{
    private readonly DbSet<Price> _repo = context.Price;

    public List<PriceDomain> GetPrizeBy(List<Product> orderedProduct)
    {
        var priceDomains = _repo.Select(x => x.ToDomain()).ToList();
        return priceDomains.Where(x => orderedProduct.Contains(x.Product)).ToList();
    }

}