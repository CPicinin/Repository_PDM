using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PDM.DataObjects;

namespace PDM.DataAcess
{
    public class TerceiroDA
    {
        public List<Terceiro> buscaTerceiros(int empresa)
        {
            List<Terceiro> lista = new List<Terceiro>();
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT id, idEmpresa, cpfCnpj, nome, email, telefone, tipoPessoa, tipoTerceiro, ativo FROM Terceiro ORDER BY nome ";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    Terceiro t = new Terceiro();
                    t.id = Convert.ToInt16(leitor["id"].ToString());
                    t.idEmpresa = Convert.ToInt16(leitor["idEmpresa"].ToString());
                    t.cpfCnpj = leitor["cpfCnpj"].ToString();
                    t.nome = leitor["nome"].ToString();
                    t.email = leitor["email"].ToString();
                    t.telefone = leitor["telefone"].ToString();
                    t.tipoPessoa = Convert.ToInt16(leitor["tipoPessoa"].ToString());
                    t.tipoTerceiro = Convert.ToInt16(leitor["tipoTerceiro"].ToString());
                    t.ativo = Convert.ToInt16(leitor["ativo"]);
                    lista.Add(t);
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

        public bool cadastraTerceiro(Terceiro t)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            DateTime licenca = DateTime.Now.AddDays(365);
            try
            {
                conexao.Open();
                comando.CommandText = @"INSERT INTO dbo.Terceiro (idEmpresa, cpfCnpj, nome, email, telefone, tipoPessoa, tipoTerceiro, ativo) VALUES " +
                    "(" + t.idEmpresa + ", '" + t.cpfCnpj + "', '" + t.nome + "', '" + t.email + "', '" + t.telefone + "', " + t.tipoPessoa + ", " + t.tipoTerceiro + ", " + t.ativo + " ) ";
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

        public Terceiro buscaTerceiro(string nome, int codigo)
        {
            Terceiro t = new Terceiro();
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            string where;
            if((nome!= null) && (codigo != null))
            {
                where = "WHERE nome = " + nome + " AND id = " + codigo + " ";
            }
            else if (nome != null)
            {
                where = "WHERE nome = " + nome + " ";
            }
            else if (codigo != null)
            {
                where = "WHERE id = " + codigo + " ";
            }
            else
            {
                where = "";
            }
            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT id, idEmpresa, cpfCnpj, nome, email, telefone, tipoPessoa, tipoTerceiro, ativo FROM Terceiro " + where + " ";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    t.id = Convert.ToInt16(leitor["id"].ToString());
                    t.idEmpresa = Convert.ToInt16(leitor["idEmpresa"].ToString());
                    t.cpfCnpj = leitor["cpfCnpj"].ToString();
                    t.nome = leitor["nome"].ToString();
                    t.email = leitor["email"].ToString();
                    t.telefone = leitor["telefone"].ToString();
                    t.tipoPessoa = Convert.ToInt16(leitor["tipoPessoa"].ToString());
                    t.tipoTerceiro = Convert.ToInt16(leitor["tipoTerceiro"].ToString());
                    t.ativo = Convert.ToInt16(leitor["ativo"]);
                }
            }
            catch (Exception)
            {
                conexao.Close();
                return null;
            }
            conexao.Close();
            return t;
        }
        public bool editaTerceiro(Terceiro t)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            try
            {
                conexao.Open();
                comando.CommandText = @"UPDATE dbo.Terceiro SET cpfCnpj ='" + t.cpfCnpj + "', nome = '" + t.nome + "', email = '" + t.email + "', telefone = '" + t.telefone + "', tipoPessoa = " + t.tipoPessoa + ", " +
                                " tipoTerceiro = " + t.tipoTerceiro + ", ativo = " + t.ativo + "  WHERE id = " + t.id + " ";
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
        public bool excluiTerceiro(int id)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            DateTime licenca = DateTime.Now.AddDays(365);
            try
            {
                conexao.Open();
                comando.CommandText = @"DELETE FROM dbo.Terceiro WHERE id = " + id + " ";
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
