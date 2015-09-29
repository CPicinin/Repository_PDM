using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PDM.DataObjects;
using PDM.BusinessLayer;

namespace PDM.View
{
    public partial class ConsultaEtapa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            alimentagrid();
        }
        public void alimentagrid()
        {
            GridView grid = new GridView();
            DataTable dt = new DataTable();
            List<Etapa> lista = new List<Etapa>();
            EtapaBL ebl = new EtapaBL();

            lista = ebl.buscaEtapas();

            DataColumn c1 = new DataColumn("id", Type.GetType("System.String"));
            DataColumn c2 = new DataColumn("nome", Type.GetType("System.String"));
            DataColumn c3 = new DataColumn("editar", Type.GetType("System.String"));

            dt.Columns.Add(c1);
            dt.Columns.Add(c2);
            dt.Columns.Add(c3);

            foreach (Etapa e in lista)
            {
                DataRow dr = dt.NewRow();
                dr["id"] = e.id.ToString();
                dr["nome"] = e.tituloEtapa.ToString();
                dr["editar"] = "~/EditaEtapa.aspx?id_etapa=" + e.id.ToString();
                dt.Rows.Add(dr);
            }
            griEtapas.DataSource = dt.Copy();
            griEtapas.DataBind();
        }
    }
}