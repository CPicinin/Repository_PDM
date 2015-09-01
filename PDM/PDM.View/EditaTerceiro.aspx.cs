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
    public partial class EditaTerceiro : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Request["id_terceiro"] != null)
            {
                int codigo = Convert.ToInt16(Request["id_terceiro"].ToString());
                Terceiro t = new Terceiro();
                TerceiroBL tbl = new TerceiroBL();
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {

        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}