using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PERSISTENCIA
{
    public abstract class ConexionDAC
    {
        protected string strConexion;

        public ConexionDAC()
        {
            strConexion = System.Configuration.ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString;
        }

    }
}
