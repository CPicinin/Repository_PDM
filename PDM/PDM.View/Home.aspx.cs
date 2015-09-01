using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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