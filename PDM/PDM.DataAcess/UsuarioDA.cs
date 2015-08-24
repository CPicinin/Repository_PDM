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
        public List<Usuario> buscaUsuariosEmpresa(string empresa)
        {
            List<Usuario> lista = new List<Usuario>();
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            int count = 0;
            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT email, nome, empresa, dataFimLicenca FROM Usuario WHERE empresa = '" + empresa + "' ORDER BY nome ";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    Usuario u = new Usuario();
                    u.email = leitor["email"].ToString();
                    u.nome = leitor["nome"].ToString();
                    u.empresa = leitor["empresa"].ToString();
                    u.dataFimLicenca = Convert.ToDateTime(leitor["dataFimLicenca"].ToString());
                    lista.Add(u);
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
                comando.CommandText = @"INSERT INTO dbo.Usuario (email,senha,nome,empresa,tipo,dataFimLicenca) VALUES " +
                    "('" + user.email + "', '" + user.senha.GetHashCode() + "', '" + user.nome + "', '" + user.empresa + "', " + user.tipo + ", '" + licenca + "') ";
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
