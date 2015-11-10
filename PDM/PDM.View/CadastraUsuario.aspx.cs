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
        EmpresaBL ebl = new EmpresaBL();
        Empresa emp;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                emp = new Empresa();
                emp = ebl.buscaEmpresa(Convert.ToInt16(Session["empresa"]));
                EmpresaUser.Value = emp.razao;
            }
        }
        public CadastraUsuario()
        {

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
            
            LogEventoBL lbl = new LogEventoBL();
            Log l = new Log();
            l.email = Session["email"].ToString();
            l.data = DateTime.Now;
            l.descricao = "Incluído usuário nome: " + user.nome + " ";
            lbl.adicionaLog(l);
            
            if (cadastrou)
            {
                Response.Write("<script>alert('Registro efetuado com sucesso!')</script>");
            }
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Consultausuario.aspx");
        }
    }
}