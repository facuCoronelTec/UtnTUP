using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.dominio
{
    internal class Receta
    {
        public int recetaNro { get; set; }
        public string Nombre { get; set; }
        public int tipoReceta { get; set; }
        public string Cheff { get; set; }
        public List<DetalleReceta> detalleRecetas { get; set; }
        public Receta()
        {
            recetaNro = 0;
            tipoReceta = 0;
            Cheff = string.Empty;
            Nombre = string.Empty;
            detalleRecetas = new List<DetalleReceta>();
        }

        public void AgregarReceta(DetalleReceta detalle)
        {
            detalleRecetas.Add(detalle);
        }
        public void Eliminar(int indice)
        {
            detalleRecetas.RemoveAt(indice);
        }
    }
}
