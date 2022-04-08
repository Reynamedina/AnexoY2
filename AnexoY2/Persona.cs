using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnexoY2
{
    internal class Persona
    {
        public string ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo  { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public decimal Salario { get; set; }
    }
}
