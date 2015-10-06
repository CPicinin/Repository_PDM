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
    public partial class ConsultaMensagens : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView grid = new GridView();
            DataTable dt = new DataTable();
            List<Mensagem> lista = new List<Mensagem>();
            MensagemBL mbl = new MensagemBL();
            UsuarioBL ubl = new UsuarioBL();

            lista = mbl.buscaMensagensusuario(Session["email"].ToString());

            DataColumn c1 = new DataColumn("data", Type.GetType("System.String"));
            DataColumn c2 = new DataColumn("remetente", Type.GetType("System.String"));
            DataColumn c3 = new DataColumn("nome", Type.GetType("System.String"));
            DataColumn c4 = new DataColumn("abrir", Type.GetType("System.String"));

            dt.Columns.Add(c1);
            dt.Columns.Add(c2);
            dt.Columns.Add(c3);
            dt.Columns.Add(c4);

            foreach (Mensagem m in lista)
            {
                DataRow dr = dt.NewRow();
                dr["data"] = m.data.ToShortDateString();
                dr["remetente"] = m.remetente.ToString();
                dr["nome"] = ubl.buscaNome(m.remetente.ToString());
                dr["abrir"] = "~/LerMensagem.aspx?id_mensagem=" + m.id.ToString();
                dt.Rows.Add(dr);
            }
            gridMensagens.DataSource = dt.Copy();
            gridMensagens.DataBind();
        }
    }
}