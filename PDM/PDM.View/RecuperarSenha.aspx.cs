using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PDM.PrintMailOther;
using PDM.BusinessLayer;
using PDM.DataObjects;

namespace PDM.View
{
    public partial class RecuperarSenha : System.Web.UI.Page
    {
        private const string SenhaCaracteresValidos = "abcdefghijklmnopqrstuvwxyz1234567890";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkRecupera_Click(object sender, EventArgs e)
        {
            int valormaximo = SenhaCaracteresValidos.Length;
            int tamanho = 8;
            Random random = new Random(DateTime.Now.Millisecond);
            StringBuilder senha = new StringBuilder(tamanho);
            string zero = "0";
            string urlRedirecionada = "http://localhost:61700/LoginRecupera.aspx?recover=" + zero.GetHashCode();
            string urlCancela = "http://localhost:61700/LimpaHashViaEMail.aspx?recover=" + txtEmail.Value;
            for (int indice = 0; indice < tamanho; indice++)
            {
                senha.Append(SenhaCaracteresValidos[random.Next(0, valormaximo)]);
            }
            string mensagem = "<html><head><meta http-equiv='content-type' content='text/html; charset=utf-8' /></head> " +
                                                " <body><p style='font-family:Calibri;font-size:medium;'>Olá,</p>" +
                                                " <p style='font-family:Calibri;font-size:medium;'>O PDM identificou uma solicitação de recuperação de senha para seu e-mail.</p> " +
                                                " <p style='font-family:Calibri;font-size:medium;'>A senha temporária para seu primeiro acesso é <b>" + senha + "</b></p> " +
                                                " <pstyle='font-family:Calibri;font-size:medium;'> Clique no link abaixo para acessar o sistema e cadastrar uma nova senha <br> " +
                                                " <a href='" + urlRedirecionada + "'>Nova senha</a> </p>" +
                                                " <p style='font-family:Calibri;font-size:medium;'>Caso não tenha sido você, <a href='" + urlCancela + "'>clique aqui</a>.</p> " +
                                                " <p style='font-family:Calibri;font-size:medium;'>Obrigado!<br> " +
                                                " Equipe Administrativa</p><body></html>";

            UsuarioBL ubl = new UsuarioBL();
            ubl.insereHashTemp(txtEmail.Value, senha.ToString());
            Email mail = new Email();
            bool foi = mail.notificaNovaSenha(senha.ToString(), txtEmail.Value.ToString(), mensagem);
            if(foi)
            {
                Response.Write("<script>alert('Uma mensagem foi enviada para sua caixa de entrada para continuar o cadastro de sua senha!')</script>");
            }
            LogEventoBL lbl = new LogEventoBL();
            Log l = new Log();
            l.email = txtEmail.Value;
            l.data = DateTime.Now;
            l.descricao = "Solicitação de nova senha.";
            lbl.adicionaLog(l);
        }
    }
}