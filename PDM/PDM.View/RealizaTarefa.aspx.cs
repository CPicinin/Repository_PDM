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
            }
            carregaTabela();
        }
        public void carregaTabela()
        {
            GridView grid = new GridView();
            DataTable dt = new DataTable();
            List<ItemTarefa> lista = new List<ItemTarefa>();
            TarefaBL tbl = new TarefaBL();
            //lista = tbl.buscaTarefasUsuario(Session["email"].ToString());
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
                dr["excluir"] = "";
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
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}