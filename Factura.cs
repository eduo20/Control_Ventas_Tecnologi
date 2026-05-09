using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Ventas_Tecnologi
{
    public class Factura
    {
        public string NoFactura { get; set; } = string.Empty;
        public string Nit2 { get; set; } = string.Empty;
        public string NombreCliente { get; set; } = string.Empty; 
        public DateTime FechaVenta { get; set; }
        public bool Entregado { get; set; } = false; // Propiedad nueva
        public decimal TotalPagado { get; set; }

        // Una lista de los productos que se lleva el cliente
        public List<DetalleVenta> Items { get; set; } = new List<DetalleVenta>();
    }

    // Esta clase guarda cada renglón del carrito de compras
    public class DetalleVenta
    {
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}
