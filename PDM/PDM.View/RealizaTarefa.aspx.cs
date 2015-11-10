using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PDM.BusinessLayer;
using PDM.DataObjects;

namespace PDM.View
{
    public partial class RealizaTarefa : System.Web.UI.Page
    {
        int idTarefa;

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Request["id_tarefa"] != null)
            {
                idTarefa = Convert.ToInt16(Request["id_tarefa"].ToString());
                Session["idTarefa"] = idTarefa;
            }
            TarefaBL tbl = new TarefaBL();
            Tarefa t = new Tarefa();
            t = tbl.buscaTarefa(idTarefa);

            EtapaBL ebl = new EtapaBL();
            lblEtapa.Text = ebl.buscaDescricaoEtapa(t.idEtapa);
            lblTitulo.Text = t.titulo;
            lblDtIni.Text = t.dataInicio.ToShortDateString();
            lblPrazo.Text = t.prazoEstimado.ToString();
            
            switch (t.status)
            {
                case 0:
                    lblStatus.Text = "Pendente";
                    break;
                case 1:
                    lblStatus.Text = "Em Andamento";
                    break;
                case 2:
                    lblStatus.Text = "Concluída";
                    break;
                case 3:
                    lblStatus.Text = "Cancelada";
                    break;
            }
            carregaTabela();
        }
        public void carregaTabela()
        {
            GridView grid = new GridView();
            DataTable dt = new DataTable();
            List<ItemTarefa> lista = new List<ItemTarefa>();
            TarefaBL tbl = new TarefaBL();
            lista = tbl.buscaItensTarefa(idTarefa);
            DataColumn c1 = new DataColumn("data", Type.GetType("System.String"));
            DataColumn c2 = new DataColumn("descricao", Type.GetType("System.String"));
            DataColumn c3 = new DataColumn("excluir", Type.GetType("System.String"));
            dt.Columns.Add(c1);
            dt.Columns.Add(c2);
            dt.Columns.Add(c3);

            foreach (ItemTarefa t in lista)
            {
                EtapaBL ebl = new EtapaBL();
                DataRow dr = dt.NewRow();
                dr["data"] = t.data.ToString();
                dr["descricao"] = t.descricao.ToString();
                dr["excluir"] = "ExcluirItemTarefa.aspx?id_item=" + t.id.ToString();
                dt.Rows.Add(dr);
            }
            gridItens.DataSource = dt.Copy();
            gridItens.DataBind();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ItemTarefa i = new ItemTarefa();
            i.idTarefa = idTarefa;
            i.data = DateTime.Now;
            i.descricao = txtItem.Text;
            TarefaBL tbl = new TarefaBL();
            bool foi = tbl.adicionarItem(i);
            carregaTabela();
            LogEventoBL lbl = new LogEventoBL();
            Log l = new Log();
            l.email = Session["email"].ToString();
            l.data = DateTime.Now;
            l.descricao = "Adicionou um item <" + i.descricao + "> na Tarefa nº " + i.idTarefa + " ";
            lbl.adicionaLog(l);
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            TarefaBL tbl = new TarefaBL();
            bool foi = tbl.mudaStatusTarefa(2, idTarefa);
            if (foi)
            {
                Response.Write("<script>alert('Tarefa Finalizada com Sucesso!')</script>");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            TarefaBL tbl = new TarefaBL();
            bool foi = tbl.mudaStatusTarefa(3, idTarefa);
            if (foi)
            {
                Response.Write("<script>alert('Tarefa Cancelada com Sucesso!')</script>");
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultaTarefas.aspx");
        }
    }
}