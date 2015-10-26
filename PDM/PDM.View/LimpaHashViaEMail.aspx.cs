using PDM.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PDM.View
{
    public partial class LimpaHashViaEMail : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            bool foi;

            if (Request["recover"] != null)
            {
                string teste = Request["recover"].ToString();
                UsuarioBL ubl = new UsuarioBL();
                foi = ubl.limpaHash(teste);
                if(foi)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }
        }
    }
}