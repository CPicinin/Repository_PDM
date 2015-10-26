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
        protected void Page_Init(object sender, EventArgs e)
        {
            if(Request["end_session"] != null)
            {
                string teste = Request["end_session"].ToString();
                if(teste == "sim")
                {
                    Home.userLogged = false;
                }
                
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
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
                    Session["empresa"] = user.idEmpresa;
                    LogEventoBL lbl = new LogEventoBL();
                    Log l = new Log();
                    l.email = Session["email"].ToString();
                    l.data = DateTime.Now;
                    l.descricao = "Logou no PDM: " + user.email + " ";
                    lbl.adicionaLog(l);
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    LogEventoBL lbl = new LogEventoBL();
                    Log l = new Log();
                    l.email = Session["email"].ToString();
                    l.data = DateTime.Now;
                    l.descricao = "Tentativa falha de login " + user.email + " ";
                    lbl.adicionaLog(l);
                    Response.Write("<script>alert('Usuário ou Senha Inválidos!')</script>");
                }              
            }
        }
    }
}