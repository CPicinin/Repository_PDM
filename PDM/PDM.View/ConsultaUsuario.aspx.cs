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
            lista = uBL.buscaUsuariosEmpresa(Session["empresa"].ToString());
            dt.Columns.Add("email");
            dt.Columns.Add("nome");
            dt.Columns.Add("empresa");
            dt.Columns.Add("licenca");

            foreach (Usuario u in lista)
            {
                DataRow dr = dt.NewRow();
                dr["email"] = u.email.ToString();
                dr["nome"] = u.nome.ToString();
                dr["empresa"] = u.empresa.ToString();
                dr["licenca"] = u.dataFimLicenca.ToShortDateString();
                dt.Rows.Add(dr);
            }
            gridUsuarios.DataSource = dt.Copy();
            gridUsuarios.DataBind();
        }
    }
}