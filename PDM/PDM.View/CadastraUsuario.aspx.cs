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
    public partial class CadastraUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EmpresaUser.Value = Session["empresa"].ToString();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            user.email = emailUser.Value;
            user.nome = nomeUser.Value;
            user.empresa = EmpresaUser.Value;
            if (senhaUser.Value == senha2User.Value)
            {
                user.senha = senhaUser.Value;
            }
            if (admSim.Checked == true)
            {
                user.tipo = 1;
            }
            else if (admNao.Checked == true)
            {
                user.tipo = 2;
            }
            if (ativoSim.Checked == true)
            {
                user.ativo = true;
            }
            else if (AtivoNao.Checked == true)
            {
                user.ativo = false;
            }
            UsuarioBL ubl = new UsuarioBL();
            bool cadastrou = ubl.cadastraUsuario(user);
            if(cadastrou)
            {
                Response.Write("<script>alert('Registro efetuado com sucesso!')</script>");
            }
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            emailUser.Value = "";
            nomeUser.Value = "";
            EmpresaUser.Value = "";
            senhaUser.Value = "";
            senha2User.Value = "";
            admNao.Checked = false;
            admSim.Checked = false;
            ativoSim.Checked = false;
            AtivoNao.Checked = false;
        }
    }
}