using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Control_Ventas_Tecnologi
{
    internal class BaseDatosFactura
    {
        // Ruta 1: Carpeta donde se ejecuta el programa (bin/Debug)
        private readonly string _rutaFacturasbin = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "facturas.json");

        // Ruta 2: Tu carpeta de desarrollo (Desktop)
        private readonly string _rutaFacturasGit = @"C:\Users\eduar\Desktop\UMES 2025\3 semestre ing\Progra III\Proyecto final\Control_Ventas_Tecnologi\facturas.json";

        public List<Factura> LeerFacturas()
        {
            // Priorizamos leer de la ruta del Escritorio si existe, si no, de la carpeta bin
            string rutaArchivo = File.Exists(_rutaFacturasGit) ? _rutaFacturasGit : _rutaFacturasbin;

            if (!File.Exists(rutaArchivo))
                return new List<Factura>();

            try
            {
                string json = File.ReadAllText(rutaArchivo);
                // Si el archivo está vacío, devolver lista nueva para evitar errores de deserialización
                if (string.IsNullOrWhiteSpace(json)) return new List<Factura>();

                return JsonSerializer.Deserialize<List<Factura>>(json) ?? new List<Factura>();
            }
            catch (Exception ex)
            {
                // Es bueno saber si falló la lectura
                Console.WriteLine("Error al leer facturas: " + ex.Message);
                return new List<Factura>();
            }
        }

        public void GuardarFactura(Factura nuevaFactura)
        {
            try
            {
                // 1. Obtener lista actual
                List<Factura> listaExistente = LeerFacturas();

                // 2. Generar correlativo automático
                int correlativo = listaExistente.Count + 1;
                nuevaFactura.NoFactura = "FAC-" + correlativo.ToString("D5");

                // 3. Agregar a la lista
                listaExistente.Add(nuevaFactura);

                // 4. Serializar
                var opciones = new JsonSerializerOptions { WriteIndented = true };
                var nuevoJson = JsonSerializer.Serialize(listaExistente, opciones);

                // 5. Guardar en carpeta BIN (Ejecución)
                File.WriteAllText(_rutaFacturasbin, nuevoJson);

                // 6. Intentar guardar en carpeta de PROYECTO (Escritorio)
                string carpetaGit = Path.GetDirectoryName(_rutaFacturasGit);
                if (Directory.Exists(carpetaGit))
                {
                    File.WriteAllText(_rutaFacturasGit, nuevoJson);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico al guardar la factura: " + ex.Message);
            }
        }

        public void GuardarTodo(List<Factura> lista)
        {
            try
            {
                var opciones = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(lista, opciones);

                File.WriteAllText(_rutaFacturasbin, json);

                if (Directory.Exists(Path.GetDirectoryName(_rutaFacturasGit)))
                {
                    File.WriteAllText(_rutaFacturasGit, json);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar cambios en facturas: " + ex.Message);
            }
        }
    }
}