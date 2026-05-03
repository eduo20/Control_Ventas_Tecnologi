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
        private string _datosEmpleados = "Emplados.json";

        public List<Empleados> LeerEmpleados()
        {
            if (!File.Exists(_datosEmpleados))

                return new List<Empleados>();
            try
            {
                var jsonEmpleados = File.ReadAllText(_datosEmpleados);
                return JsonSerializer.Deserialize<List<Empleados>>(jsonEmpleados) ?? new List<Empleados>();
            } catch 
            {
                return new List<Empleados>();
            }


        }
    }            
}
