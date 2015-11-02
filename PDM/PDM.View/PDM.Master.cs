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
    public partial class PDM : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioBL ubl = new UsuarioBL();
            Usuario u = new Usuario();
            u = ubl.buscaUsuarioAtivo(Session["email"].ToString());
            lblDataFimLicenca.Text = u.dataFimLicenca.ToShortDateString();
            lblNome01.Text = u.nome;
            lblNome02.Text = u.nome;
            MensagemBL mbl = new MensagemBL();
            lblQntMensagem.Text = mbl.contaMensagens(Session["email"].ToString());
            
            TarefaBL tbl = new TarefaBL();
            lblQntTarefas.Text = tbl.contaTarefasUsuario(Session["email"].ToString()).ToString();
        }
        protected void OnClick(object sender, ImageClickEventArgs e)
        {
            string exit = "sim";
            Session["email"] = null;
            Session["senha"] = null;
            Session["empresa"] = null;
            Session["nome"] = null;
            Response.Redirect("Login.aspx?end_session=" + exit);
        }
    }
}