using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Famydoc.Utils
{
    public static class Utils
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string ValorWebConfig(string parametroWebConfig)
        {
            try
            {
                string confiValue = ConfigurationManager.AppSettings[parametroWebConfig.Trim().ToString()];
                return confiValue;
            }
            catch (Exception ex)
            {
                log.Error($"()=>Mensaje : {ex.Message} - Modulo : UTIL");
                return null;
            }
        }

    }
}
