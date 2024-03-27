using Microsoft.AspNetCore.Mvc;
using BackFacturas.Data;
using BackFacturas.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private readonly FacturasContext _context;

    public ClientesController(FacturasContext context)
    {
        _context = context;
    }


    [HttpPost]
    public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
    {

        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();


        return CreatedAtAction(nameof(GetCliente), new { rutCliente = cliente.RutCliente }, cliente);
    }


    [HttpGet("{rutCliente}")]
    public async Task<ActionResult<Cliente>> GetCliente(int rutCliente)
    {
        var cliente = await _context.Clientes.FindAsync(rutCliente);

        if (cliente == null)
        {
            return NotFound();
        }

        return cliente;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> GetAllClientes()
    {
        return await _context.Clientes.ToListAsync();
    }


}
