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
    public partial class EditaTerceiro : System.Web.UI.Page
    {
        int codigoTerceiro = 0;

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Request["id_terceiro"] != null)
            {
                codigoTerceiro = Convert.ToInt16(Request["id_terceiro"].ToString());
                Terceiro t = new Terceiro();
                TerceiroBL tbl = new TerceiroBL();
            }
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
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if(codigoTerceiro != 0)
            {
                TerceiroBL tbl = new TerceiroBL();
                bool excluiu = tbl.excluiTerceiro(codigoTerceiro);
                if(excluiu)
                {
                    Response.Write("<script>alert('Registro editado com sucesso!')</script>");
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultaTerceiro.aspx");
        }
    }
}