using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Ventas_Tecnologi
{
    internal class Factura
    {
        public int NoFactura { get; set; }
        public string nit2 { get; set; } = string.Empty;
        public DateTime fechaVenta { get; set; }
        public string estadoVenta { get; set; } = string.Empty;

    }
}
