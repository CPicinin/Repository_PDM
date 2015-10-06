using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PDM.DataObjects;

namespace PDM.DataAcess
{
    public class MensagemDA
    {
        public List<Mensagem> buscaMensagensusuario(string email)
        {
            List<Mensagem> lista = new List<Mensagem>();
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT id,emailResponsavel,emailRemetente,data,mensagem,lida FROM dbo.Mensagens WHERE emailResponsavel = '" + email + "' AND lida = 0";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    Mensagem m = new Mensagem();
                    m.id = Convert.ToInt16(leitor["id"]);
                    m.responsavel = leitor["emailResponsavel"].ToString();
                    m.remetente = leitor["emailRemetente"].ToString();
                    m.data = Convert.ToDateTime(leitor["data"]);
                    m.mensagem = leitor["mensagem"].ToString();
                    m.lida = Convert.ToInt16(leitor["lida"]);
                    lista.Add(m);
                }
                conexao.Close();
                return lista;
            }
            catch (Exception)
            {
                conexao.Close();
                return null;
            }
        }
        public string contaMensagens(string email)
        {
            List<Mensagem> lista = new List<Mensagem>();
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            string count = "";
            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT COUNT(id) as 'quantidade' FROM dbo.Mensagens WHERE emailResponsavel = '" + email + "' AND lida = 0";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    count = leitor["quantidade"].ToString();
                }
                conexao.Close();
                return count;
            }
            catch (Exception)
            {
                conexao.Close();
                return "0";
            }
        }
        public bool marcaMensagemLida(int id)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            try
            {
                conexao.Open();
                comando.CommandText = @"UPDATE dbo.Mensagens SET lida = 1 WHERE id = " + id + " ";
                comando.Connection = conexao;
                comando.ExecuteNonQuery();
                conexao.Close();
                return true;
            }
            catch (Exception)
            {
                conexao.Close();
                return false;
            }
        }
        public Mensagem buscamensagem(int id)
        {
            Mensagem m = new Mensagem();
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT id,emailResponsavel,emailRemetente,data,mensagem,lida FROM dbo.Mensagens WHERE id = " + id + " ";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    m.id = Convert.ToInt16(leitor["id"]);
                    m.responsavel = leitor["emailResponsavel"].ToString();
                    m.remetente = leitor["emailRemetente"].ToString();
                    m.data = Convert.ToDateTime(leitor["data"]);
                    m.mensagem = leitor["mensagem"].ToString();
                    m.lida = Convert.ToInt16(leitor["lida"]);
                }
                conexao.Close();
                return m;
            }
            catch (Exception)
            {
                conexao.Close();
                return null;
            }
        }
        public bool cadastraMensagem(Mensagem m)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            try
            {
                conexao.Open();
                comando.CommandText = @"INSERT INTO dbo.Mensagens (emailResponsavel,emailRemetente,data,mensagem,lida) " +
                            " VALUES ('" + m.responsavel + "','" + m.remetente + "','" + m.data + "','" + m.mensagem + "', " + m.lida + ")";
                comando.Connection = conexao;
                comando.ExecuteNonQuery();
                conexao.Close();
                return true;
            }
            catch (Exception)
            {
                conexao.Close();
                return false;
            }
        }
    }
}