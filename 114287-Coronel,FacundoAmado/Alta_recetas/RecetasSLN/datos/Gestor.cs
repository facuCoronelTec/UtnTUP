using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using RecetasSLN.dominio;
using RecetasSLN.datos;


namespace RecetasSLN.datos
{
    class Gestor
    {
        private IRecetasDAO dao;
        public DataTable ListarIngredientes()
        {
            dao = new RecetasDAO();
            return dao.ListarIngredientes();
        }
        
        public int ProximaReceta()
        {
            dao = new RecetasDAO();
            return dao.ProximaReceta();
        }

        public bool EjecutarInsert(Receta oReceta)
        {
            
            return dao.EjecutarInsert(oReceta);
        }

        public DataTable ListarTipoReceta()
        {
            dao = new RecetasDAO();
            return dao.ListarTipoReceta();
        }
    }
}
