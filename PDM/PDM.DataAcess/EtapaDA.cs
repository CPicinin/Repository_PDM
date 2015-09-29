using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PDM.DataObjects;

namespace PDM.DataAcess
{
    public class EtapaDA
    {
        public int buscaIdEtapa(string descricao)
        {
            int numero = 0;
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT TOP 1 id FROM Etapa WHERE descricao = '" + descricao + "'";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    numero = Convert.ToInt16(leitor["id"].ToString());
                }
                conexao.Close();
                return numero;
            }
            catch (Exception)
            {
                conexao.Close();
                return 0;
            }
        }
        public List<string> buscaDescicaoEtapas()
        {
            List<string> lista = new List<string>();
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT tituloEtapa FROM Etapa";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    lista.Add(leitor["tituloEtapa"].ToString());
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
        public string buscaDescricaoEtapa(int id)
        {
            string desc = "";
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT TOP 1 descricao FROM Etapa WHERE id = '" + id + "'";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    desc = leitor["descricao"].ToString();
                }
                conexao.Close();
                return desc;
            }
            catch (Exception)
            {
                conexao.Close();
                return null;
            }
        }
        public List<Etapa> buscaEtapas()
        {
            List<Etapa> lista = new List<Etapa>();
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT id,tituloEtapa,tipoEtapa FROM Etapa";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    Etapa e = new Etapa();
                    e.id = Convert.ToInt16(leitor["id"].ToString());
                    e.tituloEtapa = leitor["tituloEtapa"].ToString();
                    e.tipo = Convert.ToInt16(leitor["tipoEtapa"].ToString());
                    lista.Add(e);
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
        public Etapa buscaEtapa(int id)
        {
            Etapa e = new Etapa();
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT id,tituloEtapa,tipoEtapa FROM Etapa WHERE id = " + id + " ";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    e.id = Convert.ToInt16(leitor["id"].ToString());
                    e.tituloEtapa = leitor["tituloEtapa"].ToString();
                    e.tipo = Convert.ToInt16(leitor["tipoEtapa"].ToString());
                }
                conexao.Close();
                return e;
            }
            catch (Exception)
            {
                conexao.Close();
                return null;
            }
        }
        public bool excluiEtapa(int id)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            try
            {
                conexao.Open();
                comando.CommandText = @"DELETE FROM dbo.Etapa WHERE id = " + id + " ";
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
        public bool editaEtapa(Etapa e)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            try
            {
                conexao.Open();
                comando.CommandText = @"UPDATE dbo.Etapa SET tituloEtapa = '" + e.tituloEtapa + "' WHERE id = " + e.id + " ";
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
