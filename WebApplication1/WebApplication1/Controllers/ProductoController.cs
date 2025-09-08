namespace WebApplication1.Controllers;

using Microsoft.AspNetCore.Mvc;
using Data;
using Models;

[Route("api/[controller]")]
[ApiController]
public class ProductosController : ControllerBase
{
    private readonly IProductoRepository _repo;

    public ProductosController(IProductoRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var productos = await _repo.GetAllAsync();
        return Ok(productos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var producto = await _repo.GetByIdAsync(id);
        return producto == null ? NotFound() : Ok(producto);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] producto producto)
    {
        await _repo.AddAsync(producto);
        return CreatedAtAction(nameof(Get), new { id = producto.ID }, producto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] producto producto)
    {
        if (id != producto.ID) return BadRequest();
        await _repo.UpdateAsync(producto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var exists = await _repo.ExistsAsync(id);
        if (!exists) return NotFound();
        await _repo.DeleteAsync(id);
        return NoContent();
    }
}