using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PDM.DataObjects;

namespace PDM.DataAcess
{
    public class EmpresaDA
    {
        public Empresa buscaEmpresa(int idEmpresa)
        {
            Empresa e = new Empresa();
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT id, cnpj, razao, email FROM Empresa WHERE id = " + idEmpresa + " ";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    e.id = Convert.ToInt16(leitor["id"].ToString());
                    e.email = leitor["email"].ToString();
                    e.razao = leitor["razao"].ToString();
                    e.cnpj = leitor["cnpj"].ToString();
                }
                return e;
            }
            catch (Exception)
            {
                conexao.Close();
                return null;
            }
        }
        public int cadastraEmpresa(Empresa emp)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            int id = 0;
            try
            {
                conexao.Open();
                comando.CommandText = @"INSERT INTO dbo.Empresa (cnpj, razao, email) VALUES ('" + emp.cnpj + "', '" + emp.razao + "', '" + emp.email + "') ";
                comando.Connection = conexao;
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception)
            {
                conexao.Close();
            }
            finally
            {
                try
                {
                    SqlDataReader leitor;

                    conexao.Open();
                    comando.CommandText = @"SELECT TOP 1 id FROM Empresa WHERE cnpj = '" + emp.cnpj + "' AND razao = '" + emp.razao + "' ORDER BY id DESC";
                    comando.Connection = conexao;
                    leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        id = Convert.ToInt16(leitor["id"].ToString());
                    }
                }
                catch (Exception)
                {
                    conexao.Close();
                }
            }
            return id;
        }
    }
}
