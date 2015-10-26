using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PDM.BusinessLayer;
using PDM.DataObjects;

namespace PDM.View
{
    public partial class EditaEtapa : System.Web.UI.Page
    {
        int id;
        Etapa etp;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["id_etapa"] != null)
            {
                id = Convert.ToInt16(Request["id_etapa"].ToString());
            }
            EtapaBL ebl = new EtapaBL();
            etp = new Etapa();
            etp = ebl.buscaEtapa(id);
            if (!IsPostBack)
            {
                txtTitulo.Value = etp.tituloEtapa;
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Etapa et = new Etapa();
            et.id = id;
            et.tituloEtapa = txtTitulo.Value;
            et.tipo = 0;
            EtapaBL ebl = new EtapaBL();
            bool foi = ebl.editaEtapa(et);
            if (foi)
            {
                Response.Write("<script>alert('Etapa editada com sucesso!')</script>");
            }
            LogEventoBL lbl = new LogEventoBL();
            Log l = new Log();
            l.email = Session["email"].ToString();
            l.data = DateTime.Now;
            l.descricao = "Editada Etapa " + et.id + "-" + et.tituloEtapa + " ";
            lbl.adicionaLog(l);
            Response.Redirect("ConsultaEtapa.aspx");
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            EtapaBL ebl = new EtapaBL();
            bool foi = ebl.excluiEtapa(id);
            if (foi)
            {
                Response.Write("<script>alert('Etapa excluída com sucesso!')</script>");
            }
            LogEventoBL lbl = new LogEventoBL();
            Log l = new Log();
            l.email = Session["email"].ToString();
            l.data = DateTime.Now;
            l.descricao = "Removida Etapa " + id + " ";
            lbl.adicionaLog(l);
            Response.Redirect("ConsultaEtapa.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultaEtapa.aspx");
        }
    }
}