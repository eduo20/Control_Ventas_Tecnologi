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
        private string _datosEmpleados = "C:\\Users\\eduar\\Desktop\\UMES 2025\\3 semestre ing\\Progra III\\Proyecto final\\Control_Ventas_Tecnologi\\Emplados.json";

        public List<Empleados> LeerEmpleados()
        {
            if (!File.Exists(_datosEmpleados))
            {
                return new List<Empleados>();
            }
            string json = File.ReadAllText(_datosEmpleados);
            return JsonSerializer.Deserialize<List<Empleados>>(json) ?? new List<Empleados>();
        }
    }
}
