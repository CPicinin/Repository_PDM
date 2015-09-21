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
                comando.CommandText = @"SELECT TOP 1 id FROM etapa WHERE descricao = '" + descricao + "'";
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
    }
}
