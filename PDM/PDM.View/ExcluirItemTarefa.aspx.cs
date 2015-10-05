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
    public partial class ExcluirItemTarefa : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if(Request["id_item"] != null)
            {
                int id = Convert.ToInt16(Request["id_item"].ToString());
                TarefaBL tbl = new TarefaBL();
                tbl.removerItem(id);
                Response.Redirect("~/RealizaTarefa.aspx?id_tarefa=" + Session["idTarefa"].ToString());
            }
        }
    }
}