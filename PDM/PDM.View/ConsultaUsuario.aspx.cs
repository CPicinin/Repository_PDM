using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PDM.BusinessLayer;
using PDM.DataObjects;

namespace PDM.View
{
    public partial class ConsultaUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView grid = new GridView();
            DataTable dt = new DataTable();
            List<Usuario> lista = new List<Usuario>();
            UsuarioBL uBL = new UsuarioBL();
            lista = uBL.buscaUsuariosEmpresa(Convert.ToInt16(Session["empresa"].ToString()));

            DataColumn c1 = new DataColumn("Email", Type.GetType("System.String"));
            DataColumn c2 = new DataColumn("Nome", Type.GetType("System.String"));
            DataColumn c3 = new DataColumn("Empresa", Type.GetType("System.String"));
            DataColumn c4 = new DataColumn("Licença", Type.GetType("System.String"));
            DataColumn c5 = new DataColumn("editar", Type.GetType("System.String"));

            dt.Columns.Add(c1);
            dt.Columns.Add(c2);
            dt.Columns.Add(c3);
            dt.Columns.Add(c4);
            dt.Columns.Add(c5);
            
            foreach (Usuario u in lista)
            {
                DataRow dr = dt.NewRow();
                dr["Email"] = u.email.ToString();
                dr["Nome"] = u.nome.ToString();
                dr["Empresa"] = u.idEmpresa.ToString();
                dr["Licença"] = u.dataFimLicenca.ToShortDateString();
                dr["editar"] = "~/EditarUsuario.aspx?user_mail=" + u.email.ToString();
                dt.Rows.Add(dr);
            }
            gridUsuarios.DataSource = dt.Copy();
            gridUsuarios.DataBind();
        }
    }
}