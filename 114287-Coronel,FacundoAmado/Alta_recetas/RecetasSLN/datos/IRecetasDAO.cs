using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecetasSLN.dominio;
using RecetasSLN.datos;


namespace RecetasSLN.datos
{
    interface IRecetasDAO
    {
        DataTable ListarIngredientes();
        int ProximaReceta();
        bool EjecutarInsert(Receta oReceta);

        DataTable ListarTipoReceta();

    }
}
