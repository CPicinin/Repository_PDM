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
            foreach(Usuario u in listaU)
            {
                listaResponsaveis.Items.Add(u.email);
            }
            listaResponsaveis.DataBind();
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
                Response.Write("Projeto cadastrado com sucesso!");
            }
            LogEventoBL lbl = new LogEventoBL();
            Log l = new Log();
            l.email = Session["email"].ToString();
            l.data = DateTime.Now;
            l.descricao = "Cadastradao Projeto Titulo: " + p.titulo + ", Responsável: " + p.emailResponsavel + " ";
            lbl.adicionaLog(l);
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            txtTitulo.Value = "";
            listaResponsaveis.SelectedIndex = 0;
            listaTipo.SelectedIndex = 0;
        }

        protected void btnCancela_Click(object sender, EventArgs e)
        {

        }
    }
}