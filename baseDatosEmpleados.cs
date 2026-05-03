using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Control_Ventas_Tecnologi
{
    internal class baseDatosEmpleados
    {
        // 1. Ruta relativa para que el programa funcione (bin/Debug)
        private string _datosEmpleadosLocal = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Empleados.json");

        // 2. Ruta absoluta para que Git vea los cambios (TU RUTA DE ESCRITORIO)
        private string _datosEmpleadosGit = "C:\\Users\\eduar\\Desktop\\UMES 2025\\3 semestre ing\\Progra III\\Proyecto final\\Control_Ventas_Tecnologi\\Empleados.json";

        public List<Empleados> LeerEmpleados()
        {
            // Intentamos leer de la ruta de Git para que siempre tengas lo más actualizado
            string rutaALeer = File.Exists(_datosEmpleadosGit) ? _datosEmpleadosGit : _datosEmpleadosLocal;

            if (!File.Exists(rutaALeer))
                return new List<Empleados>();
            try
            {
                var jsonEmpleados = File.ReadAllText(rutaALeer);
                return JsonSerializer.Deserialize<List<Empleados>>(jsonEmpleados) ?? new List<Empleados>();
            }
            catch
            {
                return new List<Empleados>();
            }
        }

        public void GuardarEmpleados(Empleados nuevoEmpleado)
        {
            // 1. Obtener la lista actual
            List<Empleados> lista = LeerEmpleados();

            // 2. Agregar el nuevo
            lista.Add(nuevoEmpleado);

            // 3. Serializar con formato bonito para que el JSON se vea ordenado en Git
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(lista, opciones);

            try
            {
                // 4. Guardar en la carpeta del Proyecto (Para Git)
                File.WriteAllText(_datosEmpleadosGit, jsonString);

                // 5. Guardar en la carpeta Debug (Para que el programa lo use de inmediato)
                File.WriteAllText(_datosEmpleadosLocal, jsonString);
            }
            catch (Exception ex)
            {
                // Si algo falla con las rutas, al menos lo intentamos
                System.Windows.Forms.MessageBox.Show("Error al sincronizar con Git: " + ex.Message);
            }
        }
    }
}