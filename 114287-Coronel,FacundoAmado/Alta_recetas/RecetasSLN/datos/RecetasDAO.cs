using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RecetasSLN.dominio;

namespace RecetasSLN.datos
{
    class RecetasDAO : IRecetasDAO
    {
        SqlConnection conexion = new SqlConnection(Properties.Resources.ConnexionString);
        SqlCommand cmd = new SqlCommand();

        public DataTable ListarIngredientes()
        {
            DataTable dt = new DataTable();
            conexion.Open();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_CONSULTAR_INGREDIENTES";
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        public DataTable ListarTipoReceta()
        {
            DataTable dt = new DataTable();
            conexion.Open();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_LISTAR_TIPORECETA";
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        public int ProximaReceta()
        {
            SqlParameter param = new SqlParameter("@Proximo", SqlDbType.Int);
            SqlCommand command = new SqlCommand();

            try
            {
                command.Parameters.Clear();
                conexion.Open();
                command.Connection = conexion;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_PROXIMA_RECETA";
                param.Direction = ParameterDirection.Output;
                command.Parameters.Add(param);
                return (int)param.Value;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if(conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        public bool EjecutarInsert(Receta oReceta)
        {
            SqlTransaction transaction = null;
            conexion.Open();
            bool ok = true;

            try
            {
                SqlCommand cmdMaestro = new SqlCommand("SP_INSERTAR_RECETA", conexion, transaction);
                cmdMaestro.CommandType = CommandType.StoredProcedure;

                cmdMaestro.Parameters.AddWithValue("@id_receta", oReceta.recetaNro);
                cmdMaestro.Parameters.AddWithValue("@tipo_receta", oReceta.tipoReceta);
                cmdMaestro.Parameters.AddWithValue("@nombre", oReceta.Nombre);

                if(oReceta.Cheff != null)
                {
                    cmdMaestro.Parameters.AddWithValue("@cheff", oReceta.Cheff);

                }
                else
                {
                    cmdMaestro.Parameters.AddWithValue("@cheff", DBNull.Value);
                }

                cmdMaestro.ExecuteNonQuery();
                int cuenta = 1;

                //insertar en detalle
                foreach (DetalleReceta detalle in oReceta.detalleRecetas)
                {
                    SqlCommand cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLE", conexion, transaction);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@id_receta", oReceta.recetaNro);
                    cmdDetalle.Parameters.AddWithValue("@id_ingrediente", detalle.ingrediente.ingredienteId);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", detalle.cantidad);
                    cuenta++;
                    cmdDetalle.ExecuteNonQuery();

                }

                transaction.Commit();

            }catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if(conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }

            }

            return ok;


        }


    }
}
