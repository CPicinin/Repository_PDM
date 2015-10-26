using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDM.DataObjects;
using System.Data.SqlClient;

namespace PDM.DataAcess
{
    public class UsuarioDA
    {
        public List<Usuario> buscaUsuariosEmpresa(int empresa)
        {
            List<Usuario> lista = new List<Usuario>();
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT email, senha, nome, idEmpresa, tipo, dataFimLicenca, ativo FROM Usuario WHERE idEmpresa = " + empresa + " ORDER BY nome ";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    Usuario user = new Usuario();
                    user.email = leitor["email"].ToString();
                    user.senha = leitor["senha"].ToString();
                    user.nome = leitor["nome"].ToString();
                    user.idEmpresa = Convert.ToInt16(leitor["idEmpresa"].ToString());
                    user.dataFimLicenca = Convert.ToDateTime(leitor["dataFimLicenca"].ToString());
                    user.tipo = Convert.ToInt16(leitor["tipo"].ToString());
                    user.ativo = Convert.ToInt16(leitor["ativo"]);
                    lista.Add(user);
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

        public bool cadastraUsuario(Usuario user)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            DateTime licenca = DateTime.Now.AddDays(365);
            try
            {
                conexao.Open();
                comando.CommandText = @"INSERT INTO dbo.Usuario (email,senha,nome,idEmpresa,tipo,dataFimLicenca, ativo) VALUES " +
                    "('" + user.email + "', '" + user.senha.GetHashCode() + "', '" + user.nome + "', " + user.idEmpresa + ", " + user.tipo + ", '" + licenca + "', " + user.ativo + ") ";
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

        public Usuario buscaUsuarioAtivo(string email)
        {
            Usuario user = new Usuario();
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT email, senha, nome, idEmpresa, tipo, dataFimLicenca, ativo FROM Usuario WHERE email = '" + email + "' ";
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
        public bool editaUsuario(Usuario user)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            try
            {
                conexao.Open();
                comando.CommandText = @"UPDATE dbo.Usuario SET senha = '" + user.senha.GetHashCode() + "' , nome = '" + user.nome + "' , tipo = " + user.tipo + " " +
                                ", ativo = " + user.ativo + " WHERE email =  '" + user.email + "' ";
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
        public bool excluiUsuario(string email)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            DateTime licenca = DateTime.Now.AddDays(365);
            try
            {
                conexao.Open();
                comando.CommandText = @"DELETE FROM dbo.Usuario WHERE email = '" + email + "' ";
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
        public string buscaNome(string email)
        {
            string user = "";
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT TOP 1 nome FROM Usuario WHERE email = '" + email + "' ";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    user = leitor["nome"].ToString();
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
        public string buscaHash(string email)
        {
            string hashTemp = "";
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT TOP 1 hashTemp FROM Usuario WHERE email = '" + email + "' ";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    hashTemp = leitor["hashTemp"].ToString();
                }
            }
            catch (Exception)
            {
                conexao.Close();
                return null;
            }
            conexao.Close();
            return hashTemp;
        }
        public bool alteraSenhaUsuario(string email, string senha)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            try
            {
                conexao.Open();
                comando.CommandText = @"UPDATE dbo.Usuario SET senha = '" + senha.GetHashCode() + "' WHERE email =  '" + email + "' ";
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
        public bool limpaHash(string email)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            try
            {
                conexao.Open();
                comando.CommandText = @"UPDATE dbo.Usuario SET hashTemp = '' WHERE email =  '" + email + "' ";
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
        public bool insereHashTemp(string email, string hashTemp)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            try
            {
                conexao.Open();
                comando.CommandText = @"UPDATE dbo.Usuario SET hashTemp = '" + hashTemp.GetHashCode() + "' WHERE email =  '" + email + "' ";
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
