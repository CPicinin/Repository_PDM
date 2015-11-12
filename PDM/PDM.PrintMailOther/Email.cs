using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace PDM.PrintMailOther
{
    public class Email
    {
        public void notificarNovaTarefa(string email, string mensagem)
        {
            string remetente = "notificador.pdm@gmail.com";
            string assunto = "Criação de Nova Tarefa";

            try
            {

                MailMessage objEmail = new MailMessage();
                objEmail.From = new MailAddress(remetente);
                objEmail.To.Add(email);
                objEmail.Priority = MailPriority.Normal;
                objEmail.IsBodyHtml = true;
                objEmail.Subject = assunto;
                objEmail.Body = mensagem;
                objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
                objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

                SmtpClient objSmtp = new SmtpClient();
                objSmtp.Host = "smtp.gmail.com";
                objSmtp.Port = 25;
                objSmtp.EnableSsl = true;
                objSmtp.Credentials = new NetworkCredential("notificador.pdm@gmail.com", "Pdm123456");
                objSmtp.Send(objEmail);

            }
            catch (Exception ex)
            {
                //string erro = ex.InnerException.ToString();
            }
        }

        /*public string buscaEmail(string nome, string strConexao)
        {
            string destino = "";
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;

            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT TOP 1 email FROM funcionarios WHERE nome = '" + nome + "' ";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    destino = leitor["email"].ToString();
                }
            }
            catch (Exception)
            {
                conexao.Close();
                throw;
            }
            finally
            {
                conexao.Close();
            }

            return destino;
        }*/

        public bool notificaNovaSenha(string senha, string email, string mensagem)
        {
            string remetente = "notificador.pdm@gmail.com";
            string assunto = "Alteração de senha";

            try
            {
                MailMessage objEmail = new MailMessage();
                objEmail.From = new MailAddress(remetente);
                objEmail.To.Add(email);
                objEmail.Priority = MailPriority.Normal;
                objEmail.IsBodyHtml = true;
                objEmail.Subject = assunto;
                objEmail.Body = mensagem;
                objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
                objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                SmtpClient objSmtp = new SmtpClient();
                objSmtp.Host = "smtp.gmail.com";
                objSmtp.Port = 25;
                objSmtp.EnableSsl = true;
                objSmtp.Credentials = new NetworkCredential("notificador.pdm@gmail.com", "Pdm123456");
                objSmtp.Send(objEmail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
