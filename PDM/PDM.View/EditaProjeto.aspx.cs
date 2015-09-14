using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PDM.BusinessLayer;
using PDM.DataObjects;

namespace PDM.View
{
    public partial class EditaProjeto : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            ProjetoBL pbl = new ProjetoBL();
            List<string> lista = new List<string>();
            lista = pbl.buscaTiposProjeto();
            if(lista != null)
            {
                listaTipo.DataSource = lista;
                listaTipo.DataBind();
            }
            List<Usuario> listaU = new List<Usuario>();
            UsuarioBL ubl = new UsuarioBL();
            listaU = ubl.buscaUsuariosEmpresa(Convert.ToInt16(Session["empresa"].ToString()));
            foreach (Usuario u in listaU)
            {
                listaResponsaveis.Items.Add(u.email);
            }
            listaResponsaveis.DataBind();

            if (Request["id_projeto"] != null)
            {
                Projeto p = new Projeto();
                p = pbl.buscaProjeto("", Convert.ToInt16(Request["id_projeto"].ToString()));
                txtTitulo.Value = p.titulo;
                listaResponsaveis.Text = p.emailResponsavel;
                listaTipo.SelectedIndex = p.tipo;
            }
        }

        protected void btnCancela_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultaProjeto.aspx");
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {

        }
    }
}