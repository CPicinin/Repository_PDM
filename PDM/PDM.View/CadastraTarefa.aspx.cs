using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PDM.DataObjects;
using PDM.BusinessLayer;
using PDM.PrintMailOther;

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

            EtapaBL ebl = new EtapaBL();
            Dictionary<string, string> listaE = new Dictionary<string, string>();
            listaE = ebl.buscaDescricaoEtapas();
            ListaEtapas.DataSource = listaE;
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
            if(foi)
            {
                MensagemBL mbl = new MensagemBL();
                Mensagem m = new Mensagem();
                m.data = DateTime.Now;
                m.remetente = "notificador.pdm@gmail.com";
                m.responsavel = t.emailResponsavel;
                m.mensagem = "Uma nova Tarefa foi criada para você no Projeto Nº " + t.idProjeto + ".";
                m.lida = 0;
                mbl.cadastraMensagem(m);
            }
            string etapa = ebl.buscaDescricaoEtapa(t.idEtapa);
            string urlRedirecionada = "http://localhost:61700/Login.aspx";
            string nome = Session["nome"].ToString();
            string dataIni = t.dataInicio.ToShortDateString();
            string nomeEtapa = ebl.buscaDescricaoEtapa(t.idEtapa);
            string strPrazo = t.prazoEstimado.ToString();
            string titulo = t.titulo;
            string mensagem = "<html><head><meta http-equiv='content-type' content='text/html; charset=utf-8' /></head> " +
                                            " <body><p style='font-family:Calibri;font-size:medium;'>Olá " + nome + ",</p>" +
                                            " <p style='font-family:Calibri;font-size:medium;'>Você acaba de receber uma tarefa no software PDM. Veja mais detalhes:</p> " +
                                            " <p style='font-family:Calibri;font-size:medium;'>Título da Tarefa: " + titulo + " <br> " +
                                            " Etapa: " + etapa + "<br> " +
                                            " Data de início: " + dataIni + "<br> " +
                                            " Prazo de conclusão em dias: " + strPrazo + " </p> " +
                                            " <p> Clique no link abaixo para acessar o sistema e conferir suas tarefas. <br> " +
                                            " <a href='" + urlRedirecionada + "'>Link para Login </a> </p>" +
                                            " <p style='font-family:Calibri;font-size:medium;'>Contamos com seu empenho para o sucesso do projeto!<br> " +
                                            " Administrador</p><body></html>";
            Email email = new Email();
            email.notificarNovaTarefa(t.emailResponsavel, mensagem);
            
            LogEventoBL lbl = new LogEventoBL();
            Log l = new Log();
            l.email = Session["email"].ToString();
            l.data = DateTime.Now;
            l.descricao = "Cadastro de Nova Tarefa para o projeto nº " + t.idProjeto + " ";
            lbl.adicionaLog(l);

            Response.Redirect("EditaProjeto.aspx?id_projeto=" + idProjeto.ToString());
        }

        protected void btnCancela_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditaProjeto.aspx?id_projeto=" + idProjeto.ToString());
        }
    }
}