using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace PDM.View
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            string email;
            string senha;
            string empresa;
            string nome;
            string idTarefa;
            //string strConexao = @"Server=COLUSSI\SQLExpress; Database=pdm; User Id=sa;password=d@217799";
            //string strConexao = @"Server=TI\SQLExpress; Database=pdm; User Id=sa;password=d@217799";
            string strConexao = @"Server=VIRTUAL01\SQLExpress; Database=pdm; User Id=sa;password=*Cris159";
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}