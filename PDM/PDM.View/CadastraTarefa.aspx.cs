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
    public partial class CadastraTarefa : System.Web.UI.Page
    {
        int idProjeto = 0;

        protected void Page_Init(object sender, EventArgs e)
        {
            List<Usuario> listaU = new List<Usuario>();
            UsuarioBL ubl = new UsuarioBL();
            listaU = ubl.buscaUsuariosEmpresa(Convert.ToInt16(Session["empresa"].ToString()));
            foreach (Usuario u in listaU)
            {
                listaResponsaveis.Items.Add(u.email);
            }
            listaResponsaveis.DataBind();

            List<string> listaE = new List<string>();
            EtapaBL ebl = new EtapaBL();
            listaE = ebl.buscaDescricaoEtapas();
            foreach(string desc in listaE)
            {
                ListaEtapas.Items.Add(desc);
            }
            ListaEtapas.DataBind();

            if (Request["id_projeto"] != null)
            {
                idProjeto = Convert.ToInt16(Request["id_projeto"].ToString());
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            TarefaBL tbl = new TarefaBL();
            EtapaBL ebl = new EtapaBL();
            Tarefa t = new Tarefa();
            
            t.idProjeto = idProjeto;
            t.idEtapa = ebl.buscaIdEtapa(ListaEtapas.SelectedItem.Value);
            t.emailResponsavel = listaResponsaveis.SelectedItem.Value;
            t.titulo = txtTitulo.Value;
            DateTime dt = Convert.ToDateTime(txtDataIni.Value);
            t.dataInicio = dt;
            int prazo = Convert.ToInt16(txtPrazo.Value);
            t.prazoEstimado = prazo;
            t.dataFim = dt.AddDays(prazo);
            t.observacao = txtObservacao.Value;

            if (pendente.Checked == true) { t.status = 0; }
            else if (emAndamento.Checked == true) { t.status = 1; }
            else if (concluido.Checked == true) { t.status = 2; }
            else if (cancelado.Checked == true) { t.status = 3; }
            else { t.status = 0; }

            bool foi = tbl.cadastraTarefa(t);
            {
                Response.Write("<script>alert('Tarefa gravada com sucesso!')</script>");
            }
            Response.Redirect("EditaProjeto.aspx?id_projeto=" + idProjeto.ToString());
        }

        protected void btnCancela_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditaProjeto.aspx?id_projeto=" + idProjeto.ToString());
        }
    }
}