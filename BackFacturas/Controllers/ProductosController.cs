using Microsoft.AspNetCore.Mvc;
using BackFacturas.Data;
using BackFacturas.Models;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ProductosController : ControllerBase
{
    private readonly FacturasContext _context;

    public ProductosController(FacturasContext context)
    {
        _context = context;
    }


    [HttpPost]
    public async Task<ActionResult<Producto>> PostProducto(Producto producto)
    {

        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();


        return CreatedAtAction(nameof(GetProducto), new { idProducto = producto.IdProducto }, producto);
    }


    [HttpGet("{idProducto}")]
    public async Task<ActionResult<Producto>> GetProducto(int idProducto)
    {
        var producto = await _context.Productos.FindAsync(idProducto);

        if (producto == null)
        {
            return NotFound();
        }

        return producto;
    }
}
