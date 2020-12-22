using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using NEGOCIO;
using Famydoc.Utils;

namespace web_cl_famydoc
{
    public partial class login : System.Web.UI.Page
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        int TempoCookie = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["TempoCookie"]);
        protected void Page_Load(object sender, EventArgs e)
        {
            //log.Info($"()=> Primer Inicio");
            //log.Error($"()=> Primer Inicio");

            bool validacion = new PersonaBC().validacionConexion();

            if (validacion)
            {
                lblmensaje.Text = " Conexion correcta";
            }

            if (Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect("index.aspx");
            }
        }

        protected void btn_ingresar_Click(object sender, EventArgs e)
        {
            try
            {
                FormsAuthentication.Initialize();
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(int.Parse(Utils.ValorWebConfig("autentications:version")), "cuentaUsuario", DateTime.Now, DateTime.Now.AddHours(int.Parse(Utils.ValorWebConfig("autentucations:expiration-hrs"))), false, "UserData");
                string encTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName , encTicket );
                Response.Cookies.Add(faCookie);

                log.Info($"()=> Inicio de Session --> Usuario : Cuenta , nombre = nombre");

                Response.Redirect("index.aspx");
                return;
            }
            catch (Exception ex)
            {
                log.Error($"()=>Mensaje : {ex.Message} - Modulo : Login");
                throw;
            }
        }
    }
}