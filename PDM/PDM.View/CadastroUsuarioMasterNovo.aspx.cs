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
    public partial class CadastroUsuarioMasterNovo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Empresa emp = new Empresa();
            EmpresaBL ebl = new EmpresaBL();
            Usuario user = new Usuario();
            UsuarioBL ubl = new UsuarioBL();

            emp.cnpj = cnpj.Value;
            emp.razao = razao.Value;
            emp.email = emailEmpresa.Value;
            int idEmpresa = ebl.cadastraEmpresa(emp);
            user.email = email.Value;
            user.senha = senha.Value;
            user.nome = nome.Value;
            user.tipo = 2;
            user.ativo = 1;
            user.dataFimLicenca = DateTime.Now.AddDays(30);
            user.idEmpresa = idEmpresa;
            bool cadastrou = ubl.cadastraUsuario(user);
            if(cadastrou)
            {
                //Response.Write("<script>alert('Novo usuário e empresa cadastrados com sucesso!')</script>");
                //fazer um modal cipah pra msgm acima, daí no click do ok redirecionar
                Response.Redirect("Login.aspx");
            }
            else
            {
                Response.Write("<script>alert('Dados inválidos, revise o cadastro!')</script>");
            }
        }
    }
}