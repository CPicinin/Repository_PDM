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
    public partial class CadastraEtapa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Value;
            EtapaBL ebl = new EtapaBL();
            bool gravou = ebl.gravaEtapa(nome);
            if(gravou)
            {
                Response.Write("<script>alert('Registro efetuado com sucesso!')</script>");
            }
        }

        protected void btnCancela_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultaEtapa.aspx");
        }
    }
}