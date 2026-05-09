using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Control_Ventas_Tecnologi
{
    internal class BaseDatosClienteas
    {
        private readonly string _datosClientesLocalbin = "Clientes.json";

        private readonly string _datosClientesGit = "C:\\Users\\eduar\\Desktop\\UMES 2025\\3 semestre ing\\Progra III\\Proyecto final\\Control_Ventas_Tecnologi\\Clientes.json";

        // Devuelve una lista de Clientes leídos desde el archivo
        public List<DatosCliente> Leer()
        {
            string ruta = File.Exists(_datosClientesGit) ? _datosClientesGit : _datosClientesLocalbin;

            if (!File.Exists(ruta))
                return new List<DatosCliente>();

            try
            {
                var json = File.ReadAllText(ruta);
                return JsonSerializer.Deserialize<List<DatosCliente>>(json) ?? new List<DatosCliente>();
            }
            catch
            {
                
                return new List<DatosCliente>();
            }
        }

        public void Guardar(DatosCliente nuevoCliente)
        {
            
            List<DatosCliente> lista = Leer();


            // 2. VALIDACIÓN 
            if (lista.Any(c => c.nit == nuevoCliente.nit)) return;

            lista.Add(nuevoCliente);

            
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            var nuevoJson = JsonSerializer.Serialize(lista, opciones);

            try
            {
                
                File.WriteAllText(_datosClientesLocalbin, nuevoJson);

                if (Directory.Exists(Path.GetDirectoryName(_datosClientesGit)))
                {
                    File.WriteAllText(_datosClientesGit, nuevoJson);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    } 
}







