using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PDM.BusinessLayer;
using PDM.DataObjects;
using System.Data;

namespace PDM.View
{
    public partial class ConsultaTarefas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView grid = new GridView();
            DataTable dt = new DataTable();
            List<Tarefa> lista = new List<Tarefa>();
            TarefaBL tbl = new TarefaBL();
            lista = tbl.buscaTarefasUsuario(Session["email"].ToString());

            DataColumn c1 = new DataColumn("etapa", Type.GetType("System.String"));
            DataColumn c2 = new DataColumn("responsavel", Type.GetType("System.String"));
            DataColumn c3 = new DataColumn("dataInicio", Type.GetType("System.String"));
            DataColumn c4 = new DataColumn("prazo", Type.GetType("System.String"));
            DataColumn c5 = new DataColumn("titulo", Type.GetType("System.String"));
            DataColumn c6 = new DataColumn("editar", Type.GetType("System.String"));
            dt.Columns.Add(c1);
            dt.Columns.Add(c2);
            dt.Columns.Add(c3);
            dt.Columns.Add(c4);
            dt.Columns.Add(c5);
            dt.Columns.Add(c6);

            foreach (Tarefa t in lista)
            {
                EtapaBL ebl = new EtapaBL();
                DataRow dr = dt.NewRow();
                dr["etapa"] = ebl.buscaDescricaoEtapa(t.idEtapa);
                dr["responsavel"] = t.emailResponsavel.ToString();
                dr["dataInicio"] = t.dataInicio.ToString();
                dr["prazo"] = t.prazoEstimado.ToString();
                dr["titulo"] = t.titulo.ToString();
                dr["editar"] = "~/RealizaTarefa.aspx?id_tarefa=" + t.id.ToString();
                dt.Rows.Add(dr);
            }
            gridTerceiros.DataSource = dt.Copy();
            gridTerceiros.DataBind();
        }
    }
}