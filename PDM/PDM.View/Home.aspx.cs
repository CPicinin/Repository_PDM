using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PDM.BusinessLayer;
using PDM.DataObjects;

namespace PDM.View
{
    public partial class Home : System.Web.UI.Page
    {
        public static bool userLogged = false;
        protected void page_Init(object sender, EventArgs e)
        {
            if (!userLogged)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                TarefaBL tbl = new TarefaBL();
                lblQntTarefas.Text = tbl.contaTarefasUsuario(Session["email"].ToString()).ToString();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!userLogged)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {

            }
        }
    }
}