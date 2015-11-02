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
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Request["user_mail"] != null)
            {
                if(Request["user_mail"].ToString() == "ownUser")
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
                else
                {
                    UsuarioBL ubl = new UsuarioBL();
                    Usuario u = new Usuario();
                    u = ubl.buscaUsuarioAtivo(Request["user_mail"].ToString());
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
            else
            {

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
            bool cadastrou = ubl.editaUsuario(user);
            LogEventoBL lbl = new LogEventoBL();
            Log l = new Log();
            l.email = Session["email"].ToString();
            l.data = DateTime.Now;
            l.descricao = "Alterado Usuário " + user.email + " ";
            lbl.adicionaLog(l);
            Response.Redirect("ConsultaEtapa.aspx");
            if (cadastrou)
            {
                Response.Write("<script>alert('Registro editado com sucesso!')</script>");
            }
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultaUsuario.aspx");
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            //falta uma confirmação de você tem certeza que deseja excluir?
            UsuarioBL ubl = new UsuarioBL();
            bool deletou = ubl.excluiUsuario(emailUser.Value.ToString());
            LogEventoBL lbl = new LogEventoBL();
            Log l = new Log();
            l.email = Session["email"].ToString();
            l.data = DateTime.Now;
            l.descricao = "Removido Usuário " + emailUser.Value.ToString() + " ";
            lbl.adicionaLog(l);
            Response.Redirect("ConsultaEtapa.aspx");
            if (deletou)
            {
                Response.Write("<script>alert('Registro removido com sucesso!')</script>");
                Response.Redirect("ConsultaUsuario.aspx");
            }
        }
    }
}