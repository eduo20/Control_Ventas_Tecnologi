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
        private readonly string _datosProductosbin = "Productos.json";

        private readonly string _datosProductosGit = "C:\\Users\\eduar\\Desktop\\UMES 2025\\3 semestre ing\\Progra III\\Proyecto final\\Control_Ventas_Tecnologi\\Productos.json";

        public List<Productos> LeerProductos()
        {

            string rutaLeer2 = File.Exists(_datosProductosGit) ? _datosProductosGit : _datosProductosbin;
            if (!File.Exists(rutaLeer2))
                return new List<Productos>();
            try
            {
                var productosJson = File.ReadAllText(rutaLeer2);
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

            try
            {
                // 4. GUARDADO EN GIT (Ruta absoluta)
                // Verificamos si la ruta existe para no tronar el programa en otra PC
                if (Directory.Exists(Path.GetDirectoryName(_datosProductosGit)))
                {
                    File.WriteAllText(_datosProductosGit, nuevoJson);
                }

                // 5. GUARDADO EN BIN (Ruta relativa)
                // Esto asegura que el programa vea los cambios de inmediato
                File.WriteAllText(_datosProductosbin, nuevoJson);
            }
            catch (Exception ex)
            {
                // Por si hay algún error de permisos o de ruta
                Console.WriteLine("Error al guardar: " + ex.Message);
            }

        } //este codigo se encarga de guardar los productos en ambos lugares, asegurando que el programa funcione sin importar la PC donde se ejecute 
        //para ser sincero tube que investigar mucho y usar ia para encontrar un codigo asi.
    }
}
