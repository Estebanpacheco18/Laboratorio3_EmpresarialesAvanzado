using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly CafeteriaContext _context;
    protected readonly DbSet<T> _set;

    public Repository(CafeteriaContext context)
    {
        _context = context;
        _set = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync() => await _set.ToListAsync();

    public async Task<T?> GetByIdAsync(int id) => await _set.FindAsync(id);

    public async Task AddAsync(T entity)
    {
        await _set.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _set.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _set.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id) => (await GetByIdAsync(id)) != null;

    public IQueryable<T> Query() => _set.AsQueryable();

    public Task SaveChangesAsync() => _context.SaveChangesAsync();
}