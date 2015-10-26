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
    public partial class EditaTarefa : System.Web.UI.Page
    {
        int idProjeto = 0, idTarefa = 0, idEtapa = 0;
        DateTime dataFim = DateTime.Now;
        string obs="";
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
                listaEtapas.Items.Add(desc);
            }
            listaEtapas.DataBind();

            if (Request["id_tarefa"] != null)
            {
                int id = Convert.ToInt16(Request["id_tarefa"].ToString());
                TarefaBL tbl = new TarefaBL();
                EtapaBL etapaBL = new EtapaBL();
                Tarefa t = new Tarefa();

                t = tbl.buscaTarefa(id);

                idProjeto = t.idProjeto;
                idTarefa = t.id;
                idEtapa = t.idEtapa;
                
                string descEtapa = etapaBL.buscaDescricaoEtapa(t.idEtapa);
                listaEtapas.SelectedItem.Value = descEtapa;

                obs = t.observacao;
                listaResponsaveis.SelectedItem.Value = t.emailResponsavel;
                txtTitulo.Value = t.titulo;
                txtDataIni.Value = t.dataInicio.ToShortDateString();
                txtPrazo.Value = t.prazoEstimado.ToString();
                switch(t.status)
                {
                    case 0:
                        pendente.Checked = true;
                        break;
                    case 1:
                        emAndamento.Checked = true;
                        break;
                    case 2:
                        concluido.Checked = true;
                        break;
                    case 3:
                        cancelado.Checked = true;
                        break;
                }
            }
            else
            {
                Response.Redirect("ConsultaProjeto.aspx");
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            TarefaBL tbl = new TarefaBL();
            EtapaBL eBL = new EtapaBL();
            Tarefa t = new Tarefa();
            t.id = idTarefa;
            t.idProjeto = idProjeto;
            t.idEtapa = eBL.buscaIdEtapa(listaEtapas.SelectedItem.Value);
            t.emailResponsavel = listaResponsaveis.SelectedItem.Value;
            t.titulo = txtTitulo.Value;
            DateTime dataI = Convert.ToDateTime(txtDataIni.Value);
            t.dataInicio = dataI;
            t.dataFim = dataI.AddDays(Convert.ToInt16(txtPrazo.Value));
            t.prazoEstimado = Convert.ToInt16(txtPrazo.Value);
            t.observacao = obs;

            if(pendente.Checked == true){t.status = 0;}
            else if (emAndamento.Checked == true){t.status = 1;}
            else if(concluido.Checked == true){t.status = 2;}
            else if (cancelado.Checked == true){t.status = 3;}
            else{t.status = 0;}
            
            bool foi = tbl.editaTarefa(t);
            if (foi)
            {
                Response.Write("<script>alert('Tarefa editada com sucesso!')</script>");
            }
            LogEventoBL lbl = new LogEventoBL();
            Log l = new Log();
            l.email = Session["email"].ToString();
            l.data = DateTime.Now;
            l.descricao = "Editou tarefa nº" + t.id + " ";
            lbl.adicionaLog(l);
            Response.Redirect("EditaProjeto.aspx?id_projeto=" + idProjeto.ToString());
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            TarefaBL tbl = new TarefaBL();
            bool foi = tbl.excluiTarefa(idTarefa);
            if(foi)
            {
                Response.Write("<script>alert('Tarefa excluída com sucesso!')</script>");
            }
            LogEventoBL lbl = new LogEventoBL();
            Log l = new Log();
            l.email = Session["email"].ToString();
            l.data = DateTime.Now;
            l.descricao = "Removeu a Tarefa nº " + idTarefa + " ";
            lbl.adicionaLog(l);
            Response.Redirect("EditaProjeto.aspx?id_projeto=" + idProjeto.ToString());
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditaProjeto.aspx?id_projeto=" + idProjeto.ToString());
        }
    }
}