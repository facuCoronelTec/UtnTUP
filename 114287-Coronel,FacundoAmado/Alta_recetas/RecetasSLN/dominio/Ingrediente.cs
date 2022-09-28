using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.dominio
{
    internal class Ingrediente
    {
        public int ingredienteId { get; set; }
        public string Nombre { get; set; }
        public int Unidad { get; set; }

        public Ingrediente()
        {
            ingredienteId = 0;
            Nombre = string.Empty;
            Unidad = 0;
        }
    }
}
