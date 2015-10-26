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
    public partial class LerMensagem : System.Web.UI.Page
    {
        int idMensagem;

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Request["id_mensagem"] != null)
            {
                idMensagem = Convert.ToInt16(Request["id_mensagem"].ToString());
                MensagemBL mbl = new MensagemBL();
                Mensagem m = new Mensagem();
                m = mbl.buscamensagem(idMensagem);
                txtDataEnvio.Value = m.data.ToShortDateString();
                txtemail.Value = m.remetente;
                UsuarioBL ubl = new UsuarioBL();
                txtNome.Value = ubl.buscaNome(m.remetente);
                txtmensagem.Value = m.mensagem;
            }
            else
            {
                Response.Redirect("ConsultaMensagens.aspx");
            }
        }

        protected void btnCancela_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultaMensagens.aspx");
        }

        protected void btnLida_Click(object sender, EventArgs e)
        {
            MensagemBL mbl = new MensagemBL();
            mbl.marcaMensagemLida(idMensagem);
            Response.Redirect("ConsultaMensagens.aspx");
            LogEventoBL lbl = new LogEventoBL();
            Log l = new Log();
            l.email = Session["email"].ToString();
            l.data = DateTime.Now;
            l.descricao = "Leu mensagem " + idMensagem + " ";
            lbl.adicionaLog(l);
        }
    }
}