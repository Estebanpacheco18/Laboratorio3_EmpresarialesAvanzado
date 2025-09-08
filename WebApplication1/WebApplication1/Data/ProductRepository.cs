using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class ProductoRepository : Repository<producto>, IProductoRepository
{
    public ProductoRepository(CafeteriaContext context) : base(context)
    {
    }

    public async Task<IEnumerable<producto>> GetByCategoriaAsync(string categoria)
    {
        return await _set
            .Where(p => p.Categoria != null && p.Categoria.ToLower() == categoria.ToLower())
            .ToListAsync();
    }

    public async Task<IEnumerable<producto>> GetInStockAsync()
    {
        return await _set
            .Where(p => p.Stock.HasValue && p.Stock.Value > 0)
            .ToListAsync();
    }
}