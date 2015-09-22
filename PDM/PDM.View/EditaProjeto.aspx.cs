using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PDM.BusinessLayer;
using PDM.DataObjects;
using System.Data;

namespace PDM.View
{
    public partial class EditaProjeto : System.Web.UI.Page
    {
        Projeto p = new Projeto();

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
                    dr["DataInicio"] = t.dataInicio.ToString();
                    dr["Prazo"] = t.dataInicio.AddDays(t.prazoEstimado).ToString();
                    dr["Status"] = t.status.ToString();
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
            lstEtapa.DataSource = listaEtapas;
            lstEtapa.DataBind();
        }

        protected void btnCancela_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultaProjeto.aspx");
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {

        }

        protected void btnBuscaTarefas_Click(object sender, EventArgs e)
        {
            bool filtra = false;
            string etapa = "";
            TarefaBL tbl = new TarefaBL();
            List<Tarefa> listaTarefas = new List<Tarefa>();
            if(lstEtapa.SelectedIndex == 0)
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
            foreach (Tarefa t in listaTarefas)
            {
                DataRow dr = dt.NewRow();
                dr["Responsavel"] = t.emailResponsavel.ToString();
                dr["DataInicio"] = t.dataInicio.ToString();
                dr["Prazo"] = t.dataInicio.AddDays(t.prazoEstimado).ToString();
                dr["Status"] = t.status.ToString();
                dr["Titulo"] = t.titulo.ToString();
                dr["editar"] = "~/EditaTarefa.aspx?id_tarefa=" + t.id.ToString();
                dt.Rows.Add(dr);
            }
            gridTarefas.DataSource = dt.Copy();
            gridTarefas.DataBind();
        }
    }
}