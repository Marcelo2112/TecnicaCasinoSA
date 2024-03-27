#nullable disable

using Microsoft.EntityFrameworkCore;
using BackFacturas.Models;

namespace BackFacturas.Data
{
    public class FacturasContext : DbContext
    {
        public FacturasContext(DbContextOptions<FacturasContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<DetalleFactura> DetallesFactura { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
}
