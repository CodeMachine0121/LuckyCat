using LuckyCat.DataBase;

namespace LuckyCat.Repositories;

public class BaseRepository
{
    private readonly LuckyDbContext _context;

    protected BaseRepository(LuckyDbContext context)
    {
        _context = context;
    }
    
    protected async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}