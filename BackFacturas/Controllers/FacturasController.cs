using Microsoft.AspNetCore.Mvc;
using BackFacturas.Data;
using BackFacturas.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class FacturasController : ControllerBase
{
    private readonly FacturasContext _context;

    public FacturasController(FacturasContext context)
    {
        _context = context;
    }


    [HttpPost]
    public async Task<ActionResult<Factura>> PostFactura(Factura factura)
    {

        //factura.Fecha = DateTime.UtcNow; // o DateTime.UtcNow si prefieres la hora UTC


        foreach (var detalle in factura.Detalles)
        {
            detalle.SubTotal = detalle.Cantidad * detalle.Precio;
        }


        factura.total = factura.Detalles.Sum(d => d.SubTotal);

        _context.Facturas.Add(factura);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetFactura), new { id = factura.IdFactura }, factura);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Factura>> GetFactura(int id)
    {
        var factura = await _context.Facturas
                                    .Include(f => f.Detalles)
                                    .ThenInclude(d => d.Producto)
                                    .FirstOrDefaultAsync(f => f.IdFactura == id);

        if (factura == null)
        {
            return NotFound();
        }

        return factura;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Factura>>> GetAllFacturas()
    {
        return await _context.Facturas
                             .Include(f => f.Detalles)
                             .ThenInclude(d => d.Producto)
                             .ToListAsync();
    }



}
