using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PDM.View
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["email"] == null)
            //{
            //    Response.Redirect("Login.aspx");
            //}
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastroUsuarioMasterNovo.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}