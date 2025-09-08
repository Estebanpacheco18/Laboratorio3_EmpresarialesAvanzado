using WebApplication1.Models;

namespace WebApplication1.Data;

public interface IProductoRepository : IRepository<producto>
{
    Task<IEnumerable<producto>> GetByCategoriaAsync(string categoria);
    Task<IEnumerable<producto>> GetInStockAsync();
}
