using LuckyCat.DataBase;

namespace LuckyCat.Repositories;

public class BaseRepository
{
    private readonly LuckyDbContext _context;

    protected BaseRepository(LuckyDbContext context)
    {
        _context = context;
    }
    
    protected Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}