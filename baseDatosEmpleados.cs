using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_Ventas_Tecnologi
{
    internal class baseDatosEmpleados
    {
        // 1. Ruta relativa para que el programa funcione (bin/Debug)
        private readonly string _datosEmpleadosLocal = "Emplados.json";

        // 2 Copia de seguridad que ira a git
        private readonly string _datosEmpleadosGit = "C:\\Users\\eduar\\Desktop\\UMES 2025\\3 semestre ing\\Progra III\\Proyecto final\\Control_Ventas_Tecnologi\\Emplados.json";

        public List<Empleados> LeerEmpleados()
        {
            string rutaALeer = File.Exists(_datosEmpleadosGit) ? _datosEmpleadosGit : _datosEmpleadosLocal;

            
            if (!File.Exists(rutaALeer))
                return new List<Empleados>();
            try
            {
                var jsonEmpleados = File.ReadAllText(rutaALeer);
                return JsonSerializer.Deserialize<List<Empleados>>(jsonEmpleados) ?? new List<Empleados>();
            }
            catch (Exception ex)
            {
                
                return new List<Empleados>();
            }
        }


    }
}
