using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace PERSISTENCIA
{

    public class PersonaDAC :PERSISTENCIA.ConexionDAC
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //log.Info($"()=> Primer Inicio");
        //log.Error($"()=> Primer Inicio");


        public bool ValidacionConexion()
        {
            bool validacion = false;
            using (SqlConnection sqlConn = new SqlConnection(this.strConexion))
            {

                try
                {
                 sqlConn.Open();
                    using (SqlCommand cmd = new SqlCommand(strConexion ,sqlConn ))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_ValidacionConexion";
                        cmd.CommandTimeout = 0;

                        //cmd.Parameters.AddWithValue("Parametro", 0);

                        using (SqlDataReader lectura = cmd.ExecuteReader())
                        {
                            if (lectura.Read())
                            {
                                if (lectura["Resultado"].ToString().Equals("1"))
                                {
                                    validacion = true;
                                }
                            }

                        }
                    }

               
                    log.Info($"()=> Primer conexion");
            }
            catch (Exception ex)
            {
                log.Error($"()=> Primer conexion{ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                {
                        sqlConn.Close();
                }
            }
        }
            return validacion;
        }

    }
}
