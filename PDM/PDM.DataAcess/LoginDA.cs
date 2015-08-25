using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDM.DataObjects;
using System.Data.SqlClient;

namespace PDM.DataAcess
{
    public class LoginDA
    {
        public bool existeUsuario(Usuario user)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            int count = 0;
            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT email FROM Usuario WHERE email = '" + user.email + "' AND senha = '" + user.senha + "' ";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    count++;
                }
                conexao.Close();
                if(count >0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                conexao.Close();
                return false;
            }
        }
        public Usuario buscaUsuario(string email, string senha)
        {
            Usuario user = new Usuario();
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT email, senha, nome, idEmpresa, tipo, dataFimLicenca, ativo FROM Usuario WHERE email = '" + email + "' AND senha = '" + senha + "'";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    user.email = leitor["email"].ToString();
                    user.senha = leitor["senha"].ToString();
                    user.nome = leitor["nome"].ToString();
                    user.idEmpresa = Convert.ToInt16(leitor["idEmpresa"].ToString());
                    user.dataFimLicenca = Convert.ToDateTime(leitor["dataFimLicenca"].ToString());
                    user.tipo = Convert.ToInt16(leitor["tipo"].ToString());
                    user.ativo = Convert.ToInt16(leitor["ativo"]);
                }
            }
            catch (Exception)
            {
                conexao.Close();
                return null;
            }
                conexao.Close();
            return user;
        }
    }
}
