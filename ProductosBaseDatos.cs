using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Control_Ventas_Tecnologi
{
    internal class ProductosBaseDatos
    {
        private readonly string _datosProductos = "Productos.json";

        public List<Productos> LeerProductos()
        {
            if (!File.Exists(_datosProductos))
                return new List<Productos>();
            try
            {
                var productosJson = File.ReadAllText(_datosProductos);
                return JsonSerializer.Deserialize<List<Productos>>(productosJson) ?? new List<Productos>();
            }
            catch
            {
                return new List<Productos>();
            }
        }

        public void GuardarProductos(Productos nuevoProducto)
        {
            List<Productos> productosExistentes = LeerProductos();

            productosExistentes.Add(nuevoProducto);

            var opciones = new JsonSerializerOptions { WriteIndented = true };
            var nuevoJson = JsonSerializer.Serialize(productosExistentes, opciones);
            File.WriteAllText(_datosProductos, nuevoJson);


        }
    }
}
