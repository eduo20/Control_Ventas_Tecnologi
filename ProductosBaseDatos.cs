using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace Control_Ventas_Tecnologi
{
    internal class ProductosBaseDatos
    {
        private readonly string _datosProductosbin = "Productos.json";
        private readonly string _datosProductosGit = @"C:\Users\eduar\Desktop\UMES 2025\3 semestre ing\Progra III\Proyecto final\Control_Ventas_Tecnologi\Productos.json";

        public List<Productos> LeerProductos()
        {
            // Prioridad: Escritorio (Git) > bin/Debug
            string rutaLeer = File.Exists(_datosProductosGit) ? _datosProductosGit : _datosProductosbin;

            if (!File.Exists(rutaLeer)) return new List<Productos>();

            try
            {
                string json = File.ReadAllText(rutaLeer);
                if (string.IsNullOrWhiteSpace(json)) return new List<Productos>();
                return JsonSerializer.Deserialize<List<Productos>>(json) ?? new List<Productos>();
            }
            catch (Exception)
            {
                return new List<Productos>();
            }
        }

        // UNIFICADO: Este método servirá para Guardar uno nuevo, editar o actualizar stock
        public void GuardarTodo(List<Productos> listaCompleta)
        {
            if (listaCompleta == null) return;

            try
            {
                var opciones = new JsonSerializerOptions { WriteIndented = true };
                string nuevoJson = JsonSerializer.Serialize(listaCompleta, opciones);

                // 1. Guardar en el BIN (Carpeta del programa)
                File.WriteAllText(_datosProductosbin, nuevoJson);

                // 2. Guardar en el ESCRITORIO (Carpeta del proyecto)
                string carpetaGit = Path.GetDirectoryName(_datosProductosGit);
                if (Directory.Exists(carpetaGit))
                {
                    File.WriteAllText(_datosProductosGit, nuevoJson);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar productos: " + ex.Message);
            }
        }

        // Ahora GuardarProductos simplemente usa el método GuardarTodo
        public void GuardarProductos(Productos nuevoProducto)
        {
            List<Productos> lista = LeerProductos();
            lista.Add(nuevoProducto);
            GuardarTodo(lista);
        }

        public void EliminarProducto(string codigo)
        {
            List<Productos> lista = LeerProductos();
            lista.RemoveAll(p => p.Codigo == codigo);
            GuardarTodo(lista);
        }
    }
}