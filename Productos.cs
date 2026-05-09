using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace Control_Ventas_Tecnologi
{
    internal class Productos
    {
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string PrecioCompra { get; set; } = string.Empty;
        public string PrecioVenta { get; set; } = string.Empty;
        public int Existencia { get; set; } = 0;

       
    }
}
