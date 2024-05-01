using Microsoft.EntityFrameworkCore;

namespace LuckyCat.DataBase;

public class LuckyDbContext: DbContext
{
    public LuckyDbContext(DbContextOptions<LuckyDbContext> options): base(options)
    {
        
    }
}