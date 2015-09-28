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

            DataColumn c1 = new DataColumn("Cnpj", Type.GetType("System.String"));
            DataColumn c2 = new DataColumn("Nome", Type.GetType("System.String"));
            DataColumn c3 = new DataColumn("Email", Type.GetType("System.String"));
            DataColumn c4 = new DataColumn("Telefone", Type.GetType("System.String"));
            DataColumn c5 = new DataColumn("editar", Type.GetType("System.String"));

            dt.Columns.Add(c1);
            dt.Columns.Add(c2);
            dt.Columns.Add(c3);
            dt.Columns.Add(c4);
            dt.Columns.Add(c5);

            foreach (Tarefa t in lista)
            {
                DataRow dr = dt.NewRow();
                dr["Cnpj"] = t.cpfCnpj.ToString();
                dr["Nome"] = t.nome.ToString();
                dr["Email"] = t.email.ToString();
                dr["Telefone"] = t.telefone.ToString();
                dr["editar"] = "~/EditaTerceiro.aspx?id_terceiro=" + t.id.ToString();
                dt.Rows.Add(dr);
            }
            gridTerceiros.DataSource = dt.Copy();
            gridTerceiros.DataBind();
        }
    }
}