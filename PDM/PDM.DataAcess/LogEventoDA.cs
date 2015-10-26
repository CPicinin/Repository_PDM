using PDM.DataObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDM.DataAcess
{
    public class LogEventoDA
    {
        public void adicionaLog(Log l)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            DateTime licenca = DateTime.Now.AddDays(365);
            try
            {
                conexao.Open();
                comando.CommandText = @"INSERT INTO dbo.LogEventos(data,usuario,descricao) VALUES " +
                    "('" + l.data + "', '" + l.email + "', '" + l.descricao + "') ";
                comando.Connection = conexao;
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception)
            {
                conexao.Close();
            }
        }
        public List<Log> buscaLogs(string where)
        {
            List<Log> lista = new List<Log>();
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT id,data,usuario,descricao FROM LogEventos " + where + " ";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    Log log = new Log();
                    log.id = Convert.ToInt16(leitor["email"].ToString());
                    log.data = Convert.ToDateTime(leitor["senha"].ToString());
                    log.email = leitor["nome"].ToString();
                    log.descricao = leitor["idEmpresa"].ToString();
                    lista.Add(log);
                }
                conexao.Close();
                return lista;
            }
            catch(Exception ex)
            {
                return null;
            }
            return lista;
        }
    }
}
