using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PDM.BusinessLayer;
using PDM.DataObjects;

namespace PDM.View
{
    public partial class ConsultaProjeto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView grid = new GridView();
            DataTable dt = new DataTable();
            List<Projeto> lista = new List<Projeto>();
            ProjetoBL tbl = new ProjetoBL();
            lista = tbl.buscaProjetos(Session["email"].ToString());

            DataColumn c1 = new DataColumn("numero", Type.GetType("System.String"));
            DataColumn c2 = new DataColumn("titulo", Type.GetType("System.String"));
            DataColumn c3 = new DataColumn("responsavel", Type.GetType("System.String"));
            DataColumn c4 = new DataColumn("dataAbertura", Type.GetType("System.String"));
            DataColumn c5 = new DataColumn("editar", Type.GetType("System.String"));

            dt.Columns.Add(c1);
            dt.Columns.Add(c2);
            dt.Columns.Add(c3);
            dt.Columns.Add(c4);
            dt.Columns.Add(c5);

            foreach (Projeto p in lista)
            {
                DataRow dr = dt.NewRow();
                dr["numero"] = p.id.ToString();
                dr["titulo"] = p.titulo.ToString();
                dr["responsavel"] = p.emailResponsavel.ToString();
                dr["dataAbertura"] = p.dataInicio.ToString();
                dr["editar"] = "~/EditaProjeto.aspx?id_projeto=" + p.id.ToString();
                dt.Rows.Add(dr);
            }
            gridProjetos.DataSource = dt.Copy();
            gridProjetos.DataBind();
        }

        protected void btnrelatorio_Click(object sender, EventArgs e)
        {

        }
    }
}