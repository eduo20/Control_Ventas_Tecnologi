using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Ventas_Tecnologi
{
    internal class DatosCliente
    {
        public int noFactura { get; set; }
        public string nit { get; set; } = string.Empty;
        public string nombre { get; set; } = string.Empty;
        public string apellido { get; set; } = string.Empty;
        public string direcion { get; set; } = string.Empty;
        public string telefono { get; set; } = string.Empty;
    }
}
