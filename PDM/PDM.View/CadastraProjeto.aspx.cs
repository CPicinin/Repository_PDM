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
            Dictionary<string, string> lista = new Dictionary<string, string>();
            lista = pbl.buscaTiposProjeto();
            listaTipo.DataSource = lista;
            listaTipo.DataBind();
            List<Usuario> listaU = new List<Usuario>();
            UsuarioBL ubl = new UsuarioBL();
            listaU = ubl.buscaUsuariosEmpresa(Convert.ToInt16(Session["empresa"].ToString()));
            foreach (Usuario u in listaU)
            {
                listaResponsaveis.Items.Add(u.email);
            }
            listaResponsaveis.DataBind();

            Dictionary<string, string> listaTer = new Dictionary<string, string>();
            TerceiroBL tbl = new TerceiroBL();
            List<Terceiro> listaT = new List<Terceiro>();
            listaT = tbl.buscaTerceiros(Convert.ToInt16(Session["empresa"]));
            foreach(Terceiro t in listaT)
            {
                string item = t.id.ToString();
                string item2 = t.nome.ToString();
                listaTer.Add(item, item2);
            }
            listaTerceiros.DataSource = listaTer;
            listaTerceiros.DataBind();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Projeto p = new Projeto();
            p.titulo = txtTitulo.Value;
            p.emailResponsavel = listaResponsaveis.SelectedItem.Value;
            p.tipo = Convert.ToInt16(listaTipo.SelectedItem.Value);
            p.status = 0;
            if(checkTerceiro.Checked == true)
            {
                p.vaiTerceiro = 1;
                p.idTerceiro = Convert.ToInt16(listaTerceiros.SelectedItem.Value);
            }
            else
            {
                p.vaiTerceiro = 0;
                p.idTerceiro = 1;
            }
            p.dataInicio = DateTime.Now;
            ProjetoBL pbl = new ProjetoBL();
            bool cadastrou = pbl.cadastraProjeto(p);
            if (cadastrou)
            {
                Response.Write("<script>alert('Registro efetuado com sucesso!')</script>");
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
            Response.Redirect("ConsultaProjeto.aspx");
        }

        protected void checkTerceiro_CheckedChanged(object sender, EventArgs e)
        {
            if(checkTerceiro.Checked == true)
            {
                listaTerceiros.Enabled = true;
            }
            else
            {
                listaTerceiros.Enabled = false;
            }
        }
    }
}