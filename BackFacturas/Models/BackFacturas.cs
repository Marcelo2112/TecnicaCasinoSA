using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BackFacturas.Models
{
    public class Cliente
    {
        [Key]
        public int RutCliente { get; set; }
        public string? NombreCliente { get; set; }
        public string? Email { get; set; }
        public List<Factura> Facturas { get; set; } = new List<Factura>();
    }

    public class DetalleFactura
    {
        [Key]
        public int IdDetalleFactura { get; set; }
        public int IdFactura { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public int SubTotal { get; set; }
        [JsonIgnore]
        public Factura? Factura { get; set; }
        public Producto? Producto { get; set; }
    }

    public class Factura
    {
        [Key]
        public int IdFactura { get; set; }
        public string? NumeroFactura { get; set; }
        public int RutClienteFk { get; set; }
        public int total { get; set; }
        [JsonIgnore]
        public Cliente? Cliente { get; set; }
        public List<DetalleFactura> Detalles { get; set; } = new List<DetalleFactura>();
    }

    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public string? Nombre { get; set; }
        public int Precio { get; set; }
        [JsonIgnore]
        public List<DetalleFactura> DetallesFactura { get; set; } = new List<DetalleFactura>();
    }
}
