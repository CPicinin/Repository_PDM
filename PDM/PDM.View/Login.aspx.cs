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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            LoginBL lbl = new LoginBL();

            if ((email.Value.ToString() == "") || (email.Value.Contains("@") == false) || (email.Value.Length < 7))
            {
                Response.Write("<script>alert('Informe um e-mail!')</script>");
             
            }
            else if(password.Value == "")
            {
                Response.Write("<script>alert('Informe uma senha!')</script>");
            }
            else
            {
                Usuario user = new Usuario();
                user.email = email.Value.ToString();
                string senha = password.Value.ToString();
                user.senha = senha.GetHashCode().ToString();
                bool existeUsuario = lbl.usuarioValido(user);
                if(existeUsuario)
                {
                    Home.userLogged = true;
                    user = lbl.buscaUsuario(user.email, user.senha);
                    Session["email"] = user.email;
                    Session["senha"] = user.senha;
                    Session["empresa"] = user.empresa;
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Usuário ou Senha Inválidos!')</script>");
                    
                }              
            }
        }
    }
}