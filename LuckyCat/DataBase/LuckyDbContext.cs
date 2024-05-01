using LuckyCat.DataBase.Entity;
using Microsoft.EntityFrameworkCore;

namespace LuckyCat.DataBase;

public class LuckyDbContext : DbContext
{
    public LuckyDbContext(DbContextOptions<LuckyDbContext> options) : base(options)
    {
    }

    public DbSet<Order> Order { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Order>()
            .HasKey(x=> x.Id);
    }

}