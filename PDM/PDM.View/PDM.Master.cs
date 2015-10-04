using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PDM.View
{
    public partial class PDM : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public void AlteraTexto()
        {
            
        }

        protected void OnClick(object sender, ImageClickEventArgs e)
        {
            string exit = "sim";
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx?end_session=" + exit);
        }
    }
}