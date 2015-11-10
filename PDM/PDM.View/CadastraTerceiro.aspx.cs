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
    public partial class CadatraTerceiro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Terceiro t = new Terceiro();
            TerceiroBL tbl = new TerceiroBL();
            t.nome = txtNome.Value;
            t.telefone = txtTelefone.Value;
            t.cpfCnpj = cpfCnpj.Value;
            t.email = txtEmail.Value;
            if (ativoSim.Checked == true)
            {
                t.ativo = 1;
            }
            else if (AtivoNao.Checked == true)
            {
                t.ativo = 0;
            }
            else
            {
                //preencha tudão
            }
            if (radioPessoaFisica.Checked == true)
            {
                t.tipoPessoa = 1;
            }
            else if (radioPessoaJuridica.Checked == true)
            {
                t.tipoPessoa = 2;
            }
            else
            {
                //prennche tudo
            }
            if (radioCliente.Checked == true)
            {
                t.tipoTerceiro = 1;
            }
            else if (radioFornecedor.Checked == true)
            {
                t.tipoTerceiro = 2;
            }
            else
            {
                //preencha tudo
            }
            bool gravou = tbl.cadastraTerceiro(t);
            LogEventoBL lbl = new LogEventoBL();
            Log l = new Log();
            l.email = Session["email"].ToString();
            l.data = DateTime.Now;
            l.descricao = "Incluir Terceiro nome: " + t.nome + " ";
            lbl.adicionaLog(l);
            if(gravou)
            {
                Response.Write("<script>alert('Registro efetuado com sucesso!')</script>");
            }
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultaTerceiro.aspx");
        }
    }
}