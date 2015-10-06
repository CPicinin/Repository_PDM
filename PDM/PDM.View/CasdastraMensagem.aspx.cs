using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PDM.DataObjects;
using PDM.BusinessLayer;

namespace PDM.View
{
    public partial class CasdastraMensagem : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            List<Usuario> listaU = new List<Usuario>();
            UsuarioBL ubl = new UsuarioBL();
            listaU = ubl.buscaUsuariosEmpresa(Convert.ToInt16(Session["empresa"].ToString()));
            foreach (Usuario u in listaU)
            {
                listaUsuarios.Items.Add(u.email);
            }
            listaUsuarios.DataBind();

        }

        protected void btnCancela_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Mensagem m = new Mensagem();
            m.remetente = Session["email"].ToString();
            m.responsavel = listaUsuarios.SelectedItem.Value.ToString();
            m.mensagem = txtmensagem.Value;
            m.lida = 0;
            MensagemBL mbl = new MensagemBL();
            bool foi = mbl.cadastraMensagem(m);
            if(foi)
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Write("Falha ao enviar a mensagem!");
            }

        }
    }
}