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
        private string _datosEmpleadosLocal =  "Empleados.json";

        // 2 Copia de seguridad que ira a git
        private string _datosEmpleadosGit = "C:\\Users\\eduar\\Desktop\\UMES 2025\\3 semestre ing\\Progra III\\Proyecto final\\Control_Ventas_Tecnologi\\Empleados.json";

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
            catch
            {
                return new List<Empleados>();
            }
        }

       
        }
    }
