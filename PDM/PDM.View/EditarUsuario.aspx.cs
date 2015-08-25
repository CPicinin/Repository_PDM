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
    public partial class EditarUsuario : System.Web.UI.Page
    {
        EmpresaBL ebl = new EmpresaBL();
        Empresa emp;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsuarioBL ubl = new UsuarioBL();
                Usuario u = new Usuario();
                u = ubl.buscaUsuarioAtivo(Session["email"].ToString());
                emailUser.Value = u.email;
                nomeUser.Value = u.nome;

                emp = new Empresa();
                emp = ebl.buscaEmpresa(u.idEmpresa);
                EmpresaUser.Value = emp.razao;

                if (u.tipo == 1)
                {
                    admSim.Checked = true;
                }
                else
                {
                    admNao.Checked = true;
                }
                if (u.ativo == 0)
                {
                    AtivoNao.Checked = true;
                }
                else
                {
                    ativoSim.Checked = true;
                }
            }
        }
        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            user.email = emailUser.Value;
            user.nome = nomeUser.Value;
            user.idEmpresa = Convert.ToInt16(Session["empresa"]);
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
                user.ativo = 1;
            }
            else if (AtivoNao.Checked == true)
            {
                user.ativo = 0;
            }
            UsuarioBL ubl = new UsuarioBL();
            bool cadastrou = ubl.cadastraUsuario(user);
            if (cadastrou)
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