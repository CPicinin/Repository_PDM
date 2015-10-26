using PDM.BusinessLayer;
using PDM.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PDM.View
{
    public partial class LoginRecupera : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            string zero = "0";
            if (Request["recover"] != null)
            {
                string teste = Request["recover"].ToString();
                if (teste == zero.GetHashCode().ToString())
                {
                    
                }
                else
                {
                    Response.Redirect("Index.aspx");
                }

            }
            else
            {
                Response.Redirect("Index.aspx");
            }
        }

        protected void lnkRecupera_Click(object sender, EventArgs e)
        {
            if(txtSenha.Value == txtSenha2.Value)
            {
                if ((txtSenha.Value != "") && (txtSenha.Value != null))
                {
                    UsuarioBL ubl = new UsuarioBL();
                    string hashTemp = ubl.buscaHash(txtEmail.Value.ToString());
                    if (hashTemp == password.Value.GetHashCode().ToString())
                    {
                        bool foi = ubl.alteraSenhaUsuario(txtEmail.Value, txtSenha.Value);
                        if (foi)
                        {
                            Response.Write("<script>alert('Nova Senha Cadastrada Com Sucesso!')</script>");
                        }
                        ubl.limpaHash(txtEmail.Value);
                        LogEventoBL lbl = new LogEventoBL();
                        Log l = new Log();
                        l.email = Session["email"].ToString();
                        l.data = DateTime.Now;
                        l.descricao = "Recuperada senha de Usuário " + txtEmail + " ";
                        lbl.adicionaLog(l);
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Senha Temporária Incorreta!')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Favor Informar Uma Senha!')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Informe A Mesma Senha Nos Campos <Nova Senha> e <Confirme Nova Senha>!')</script>");
            }
        }
    }
}