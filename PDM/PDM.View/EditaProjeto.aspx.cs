using PdfSharp;
using PdfSharp.Charting;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PDM.BusinessLayer;
using PDM.DataObjects;
using PDM.PrintMailOther;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PDM.View
{
    public partial class EditaProjeto : System.Web.UI.Page
    {
        Projeto p = new Projeto();
        internal static PdfDocument s_document;
        XFont font = new XFont("Calibri", 9, XFontStyle.Regular);
        XFont headersFont = new XFont("Calibri", 10, XFontStyle.Bold);
        ProjetoBL pda = new ProjetoBL();
        RectangleF rect;

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProjetoBL pbl = new ProjetoBL();
                List<string> lista = new List<string>();
                lista = pbl.buscaTiposProjeto();
                foreach (string s in lista)
                {
                    listaTipo.Items.Add(s);
                }
                listaTipo.DataBind();
                List<Usuario> listaU = new List<Usuario>();
                string teste = Session["empresa"].ToString();
                UsuarioBL ubl = new UsuarioBL();
                listaU = ubl.buscaUsuariosEmpresa(Convert.ToInt16(teste));
                foreach (Usuario u in listaU)
                {
                    listaResponsaveis.Items.Add(u.email);
                }
                listaResponsaveis.DataBind();

                if (Request["id_projeto"] != null)
                {
                    p = pbl.buscaProjeto("", Convert.ToInt16(Request["id_projeto"].ToString()));
                    txtTitulo.Value = p.titulo;
                    listaResponsaveis.Text = p.emailResponsavel;
                    listaTipo.SelectedIndex = p.tipo;
                    GridView grid = new GridView();
                    DataTable dt = new DataTable();
                    List<Tarefa> listaTarefas = new List<Tarefa>();
                    TarefaBL tbl = new TarefaBL();
                    listaTarefas = tbl.buscaTarefasProjeto(p.id, false, "");

                    DataColumn c1 = new DataColumn("Responsavel", Type.GetType("System.String"));
                    DataColumn c2 = new DataColumn("DataInicio", Type.GetType("System.String"));
                    DataColumn c3 = new DataColumn("Prazo", Type.GetType("System.String"));
                    DataColumn c4 = new DataColumn("Status", Type.GetType("System.String"));
                    DataColumn c5 = new DataColumn("Titulo", Type.GetType("System.String"));
                    DataColumn c6 = new DataColumn("editar", Type.GetType("System.String"));


                    dt.Columns.Add(c1);
                    dt.Columns.Add(c2);
                    dt.Columns.Add(c3);
                    dt.Columns.Add(c4);
                    dt.Columns.Add(c5);
                    dt.Columns.Add(c6);

                    foreach (Tarefa t in listaTarefas)
                    {
                        DataRow dr = dt.NewRow();
                        dr["Responsavel"] = t.emailResponsavel.ToString();
                        dr["DataInicio"] = t.dataInicio.ToShortDateString();
                        dr["Prazo"] = t.dataInicio.AddDays(t.prazoEstimado).ToShortDateString();
                        switch (t.status)
                        {
                            case 0:
                                dr["Status"] = "Pendente";
                                break;
                            case 1:
                                dr["Status"] = "Em Andamento";
                                break;
                            case 2:
                                dr["Status"] = "Concluída";
                                break;
                            case 3:
                                dr["Status"] = "Cancelada";
                                break;
                        }
                        dr["Titulo"] = t.titulo.ToString();
                        dr["editar"] = "~/EditaTarefa.aspx?id_tarefa=" + t.id.ToString();
                        dt.Rows.Add(dr);
                    }
                    gridTarefas.DataSource = dt.Copy();
                    gridTarefas.DataBind();
                }
                EtapaBL ebl = new EtapaBL();
                List<string> listaEtapas = new List<string>();
                listaEtapas = ebl.buscaDescricaoEtapas();
                lstEtapa.Items.Add("--selecione--");
                foreach (string s in listaEtapas)
                {
                    lstEtapa.Items.Add(s);
                }
                lstEtapa.DataBind();
            }
        }

        protected void btnCancela_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultaProjeto.aspx");
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            ProjetoBL pbl = new ProjetoBL();
            p.tipo = listaTipo.SelectedIndex;
            p.titulo = txtTitulo.Value;
            bool foi = pbl.editaProjeto(p);
            if (foi)
            {
                Response.Write("<script>alert('Projeto editado com sucesso!')</script>");
            }
            LogEventoBL lbl = new LogEventoBL();
            Log l = new Log();
            l.email = Session["email"].ToString();
            l.data = DateTime.Now;
            l.descricao = "Editado projeto " + p.id + "-" + p.titulo + " ";
            lbl.adicionaLog(l);
            Response.Redirect("ConsultaEtapa.aspx");
        }

        protected void btnBuscaTarefas_Click(object sender, EventArgs e)
        {
            bool filtra = false;
            string etapa = "";
            TarefaBL tbl = new TarefaBL();
            List<Tarefa> listaTarefas = new List<Tarefa>();
            if (lstEtapa.SelectedIndex == 0)
            {
                filtra = false;
                etapa = "";
            }
            else
            {
                filtra = true;
                etapa = lstEtapa.SelectedItem.Value.ToString();
            }
            listaTarefas = tbl.buscaTarefasProjeto(p.id, filtra, etapa);
            DataTable dt = new DataTable();

            DataColumn c1 = new DataColumn("Responsavel", Type.GetType("System.String"));
            DataColumn c2 = new DataColumn("DataInicio", Type.GetType("System.String"));
            DataColumn c3 = new DataColumn("Prazo", Type.GetType("System.String"));
            DataColumn c4 = new DataColumn("Status", Type.GetType("System.String"));
            DataColumn c5 = new DataColumn("Titulo", Type.GetType("System.String"));
            DataColumn c6 = new DataColumn("editar", Type.GetType("System.String"));

            dt.Columns.Add(c1);
            dt.Columns.Add(c2);
            dt.Columns.Add(c3);
            dt.Columns.Add(c4);
            dt.Columns.Add(c5);
            dt.Columns.Add(c6);
            foreach (Tarefa t in listaTarefas)
            {
                DataRow dr = dt.NewRow();
                dr["Responsavel"] = t.emailResponsavel.ToString();
                dr["DataInicio"] = t.dataInicio.ToShortDateString();
                dr["Prazo"] = t.dataInicio.AddDays(t.prazoEstimado).ToShortDateString();
                switch (t.status)
                {
                    case 0:
                        dr["Status"] = "Pendente";
                        break;
                    case 1:
                        dr["Status"] = "Em Andamento";
                        break;
                    case 2:
                        dr["Status"] = "Concluída";
                        break;
                    case 3:
                        dr["Status"] = "Cancelada";
                        break;
                }
                //dr["Status"] = t.status.ToString();
                dr["Titulo"] = t.titulo.ToString();
                dr["editar"] = "~/EditaTarefa.aspx?id_tarefa=" + t.id.ToString();
                dt.Rows.Add(dr);
            }
            gridTarefas.DataSource = dt.Copy();
            gridTarefas.DataBind();
        }

        protected void btnNotifica_Click(object sender, EventArgs e)
        {
            bool filtra = false;
            string etapa = "";
            TarefaBL tbl = new TarefaBL();
            List<Tarefa> listaTarefas = new List<Tarefa>();

            listaTarefas = tbl.buscaTarefasProjeto(p.id, filtra, etapa);

            foreach (Tarefa t in listaTarefas)
            {
                UsuarioBL ubl = new UsuarioBL();
                EtapaBL ebl = new EtapaBL();
                string urlRedirecionada = "http://localhost:61700/Login.aspx";
                string nome = ubl.buscaNome(t.emailResponsavel);
                string dataIni = t.dataInicio.ToShortDateString();
                string nomeEtapa = ebl.buscaDescricaoEtapa(t.idEtapa);
                string prazo = t.prazoEstimado.ToString();
                string titulo = t.titulo;
                string mensagem = "<html><head><meta http-equiv='content-type' content='text/html; charset=utf-8' /></head> " +
                                                " <body><p style='font-family:Calibri;font-size:medium;'>Olá " + nome + ",</p>" +
                                                " <p style='font-family:Calibri;font-size:medium;'>Você acaba de receber uma tarefa no software PDM. Veja mais detalhes:</p> " +
                                                " <p style='font-family:Calibri;font-size:medium;'>Título da Tarefa: " + titulo + " <br> " +
                                                " Etapa: " + etapa + "<br> " +
                                                " Data de início: " + dataIni + "<br> " +
                                                " Prazo de conclusão em dias: " + prazo + " </p> " +
                                                " <p> Clique no link abaixo para acessar o sistema e conferir suas tarefas. <br> " +
                                                " <a href='" + urlRedirecionada + "'>Link para Login </a> </p>" +
                                                " <p style='font-family:Calibri;font-size:medium;'>Contamos com seu empenho para o sucesso do projeto!<br> " +
                                                " Administrador</p><body></html>";
                Email email = new Email();
                email.notificarNovaTarefa(t.emailResponsavel, mensagem);
            }
        }
        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastraTarefa.aspx?id_projeto=" + Request["id_projeto"].ToString());
        }

        protected void btnGeraRelatorio_Click(object sender, EventArgs e)
        {
            s_document = new PdfDocument();
            s_document.Info.Title = "`PDM - Projeto";
            s_document.Info.Author = "PDM Product Development Manager";
            s_document.Info.Subject = "Documento de Acompanhamento de Projeto";
            s_document.Info.Keywords = "Projeto, PDM";

            int idprojeto = Convert.ToInt16(Request["id_projeto"].ToString());
            p = new Projeto();
            ProjetoBL pbl = new ProjetoBL();
            p = pbl.buscaProjeto("", idprojeto);

            string filename = String.Format(@"{0}_projeto_{1}.pdf", Guid.NewGuid().ToString("D").ToUpper(), p.id);
            string filepath= @"C:\Users\Gestao_02\Source\Repos\Repository_PDM\PDM\PDM.View\pdf\";

            criaPDFPage(s_document.AddPage(), p);
            s_document.Save(filepath + filename);
            Process.Start(filepath + filename);
        }
        public void criaPDFPage(PdfPage page, Projeto pro)
        {
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XTextFormatter tf = new XTextFormatter(gfx);
            XRect retangulo;
            int iLeftMargin = 15;
            int iTopMargin = 25;
            int conta = 0, iTempTopMargin;
            System.Drawing.Point point;
            point = new System.Drawing.Point(260, 15);
            System.Drawing.Image newImage = System.Drawing.Image.FromFile(@"C:\Users\Gestao_02\Source\Repos\Repository_PDM\PDM\PDM.View\template\img\pdm.png");
            gfx.DrawImage(newImage, point);

            //MOntar header
            iLeftMargin = iLeftMargin + 15;
            iTopMargin = iTopMargin + 50;

            point = new System.Drawing.Point(iLeftMargin + 3, iTopMargin + 10);
            gfx.DrawString("Número do Projeto: " + pro.id.ToString(), font, Brushes.Black, point);
            gfx.DrawRectangle(new Pen(Brushes.Black), iLeftMargin, iTopMargin, 270, 15);
            point = new System.Drawing.Point(iLeftMargin + 3 + 270, iTopMargin + 10);
            string tipo = pda.buscaNomeTipoProjeto(pro.tipo);
            gfx.DrawString("Tipo de projeto: " + tipo, font, Brushes.Black, point);
            gfx.DrawRectangle(new Pen(Brushes.Black), iLeftMargin + 270, iTopMargin, 270, 15);

            iTopMargin = iTopMargin + 15;

            point = new System.Drawing.Point(iLeftMargin + 3, iTopMargin + 10);
            UsuarioBL uda = new UsuarioBL();
            string nome = uda.buscaNome(pro.emailResponsavel);
            gfx.DrawString("Responsável pelo Projeto: " + nome, font, Brushes.Black, point);
            gfx.DrawRectangle(new Pen(Brushes.Black), iLeftMargin, iTopMargin, 270, 15);
            point = new System.Drawing.Point(iLeftMargin + 3 + 270, iTopMargin + 10);
            gfx.DrawString("E-mail do responsável: " + pro.emailResponsavel, font, Brushes.Black, point);
            gfx.DrawRectangle(new Pen(Brushes.Black), iLeftMargin + 270, iTopMargin, 270, 15);

            iTopMargin = iTopMargin + 15;

            point = new System.Drawing.Point(iLeftMargin + 3, iTopMargin + 10);
            gfx.DrawString("Data de Início: " + pro.dataInicio.ToShortDateString(), font, Brushes.Black, point);
            gfx.DrawRectangle(new Pen(Brushes.Black), iLeftMargin, iTopMargin, 270, 15);
            point = new System.Drawing.Point(iLeftMargin + 3 + 270, iTopMargin + 10);
            gfx.DrawString("Duração em dias até agora: " + DateTime.Now.Subtract(pro.dataInicio).Days, font, Brushes.Black, point);
            gfx.DrawRectangle(new Pen(Brushes.Black), iLeftMargin + 270, iTopMargin, 270, 15);

            iTopMargin = iTopMargin + 15;

            TarefaBL tda = new TarefaBL();
            int qntTotal = tda.contaTarefasProjeto(pro.id);
            int qntFinalizada = tda.contaTarefaFinalizadasProjeto(pro.id);
            point = new System.Drawing.Point(iLeftMargin + 3, iTopMargin + 10);
            gfx.DrawString("Quantidade Total de Tarefas: " + qntTotal, font, Brushes.Black, point);
            gfx.DrawRectangle(new Pen(Brushes.Black), iLeftMargin, iTopMargin, 270, 15);
            point = new System.Drawing.Point(iLeftMargin + 3 + 270, iTopMargin + 10);
            gfx.DrawString("Percentual de Tarefas Concluídas): " + ((qntFinalizada * 100)/qntTotal) + "%", font, Brushes.Black, point);
            gfx.DrawRectangle(new Pen(Brushes.Black), iLeftMargin + 270, iTopMargin, 270, 15);

            iTopMargin = iTopMargin + 15;

            point = new System.Drawing.Point(iLeftMargin + 3, iTopMargin + 10);
            gfx.DrawString("Título: " + pro.titulo, font, Brushes.Black, point);
            gfx.DrawRectangle(new Pen(Brushes.Black), iLeftMargin, iTopMargin, 540, 15);

            iTopMargin = iTopMargin + 37;

            point = new System.Drawing.Point(iLeftMargin + 3, iTopMargin + 10);
            gfx.DrawString("TAREFAS", headersFont, Brushes.Black, point);
            gfx.DrawRectangle(new Pen(Brushes.Black), iLeftMargin, iTopMargin, 540, 15);

            iTopMargin = iTopMargin + 15;

            rect = new RectangleF(iLeftMargin + 3, iTopMargin + 10, 540, 300);
            conta = 0;
            iTempTopMargin = iTopMargin;
            List<Tarefa> lista = new List<Tarefa>();
            lista = tda.buscaTarefasProjeto(pro.id, false, "");
            foreach (Tarefa t in lista)
            {
                StringBuilder frase = new StringBuilder();
                frase.Append(t.titulo);
                frase.Append(" (");
                string status;
                switch (t.status)
                {
                    case 0:
                        status = "Pendente";
                        break;
                    case 1:
                        status = "Em Andamento";
                        break;
                    case 2:
                        status = "Concluída";
                        break;
                    case 3:
                        status = "Cancelada";
                        break;
                    default:
                        status = "Não Iformado";
                        break;
                }
                frase.Append(status);
                frase.Append(")");
                point = new System.Drawing.Point(iLeftMargin + 3, iTempTopMargin + 10);
                gfx.DrawString(frase.ToString(), font, Brushes.Black, point);
                conta++;
                iTempTopMargin = iTempTopMargin + 15;
            }
            rect = new RectangleF(iLeftMargin, iTopMargin, 540, iTempTopMargin - iTopMargin);
            gfx.DrawRectangle(Pens.Black, Rectangle.Round(rect));
            iTopMargin = iTempTopMargin + 15;
        }
    }
}