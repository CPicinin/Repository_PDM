using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PDM.DataObjects;
using PDM.BusinessLayer;

namespace PDM.View
{
    public partial class CadastraProjeto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Projeto p = new Projeto();
            p.titulo = txtTitulo.Value;
            p.emailResponsavel = listaResponsaveis.SelectedItem.Value;
            p.tipo = listaTipo.SelectedIndex;
            p.status = 0;
            p.dataInicio = DateTime.Now;
            ProjetoBL pbl = new ProjetoBL();
            bool cadastrou = pbl.cadastraProjeto(p);
            if(cadastrou)
            {
                Response.Write("");
            }
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            txtTitulo.Value = "";
            listaResponsaveis.SelectedIndex = 0;
            listaTipo.SelectedIndex = 0;
        }
    }
}