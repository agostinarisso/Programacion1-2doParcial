using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2doparcial
{
    public class Promedio
    {
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public double PromedioGeneral { get; set; }
        public string GenerarRegistro()
    {
        return $"{Legajo},{Nombre},{Apellido},{PromedioGeneral}";
    }
    }
    
}
