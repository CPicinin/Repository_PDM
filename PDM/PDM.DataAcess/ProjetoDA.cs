using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PDM.DataObjects;

namespace PDM.DataAcess
{
    public class ProjetoDA
    {

        public List<Projeto> buscaProjetos(string email)
        {
            List<Projeto> lista = new List<Projeto>();
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT id, emailResponsavel, titulo, tipoProjeto, dataInicio, status FROM Projeto WHERE emailResponsavel = '" + email + "' ";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    Projeto p = new Projeto();
                    p.id = Convert.ToInt16(leitor["id"].ToString());
                    p.titulo = leitor["titulo"].ToString();
                    p.emailResponsavel = leitor["emailResponsavel"].ToString();
                    p.status = Convert.ToInt16(leitor["status"].ToString());
                    p.tipo = Convert.ToInt16(leitor["tipoProjeto"].ToString());
                    p.dataInicio = Convert.ToDateTime(leitor["dataInicio"].ToString());
                    lista.Add(p);
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

        public bool cadastraProjeto(Projeto p)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            try
            {
                conexao.Open();
                comando.CommandText = @"INSERT INTO Projeto(emailResponsavel, titulo, tipoProjeto, dataInicio, status) VALUES " +
                " ('" + p.emailResponsavel +"', '" + p.titulo + "', " + p.tipo + ", '" + p.dataInicio + "', " + p.status + ")";
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

        public Projeto buscaProjeto(string titulo, int codigo)
        {
            Projeto p = new Projeto();
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            string where;
            // mudar os titulos para LIKE
            if ((titulo != "") && (codigo != 0))
            {
                where = "WHERE titulo LIKE '%" + titulo + "%' AND id = " + codigo + " ";
            }
            else if (titulo != "")
            {
                where = "WHERE titulo LIKE '%" + titulo + "%' ";
            }
            else if (codigo != 0)
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
                comando.CommandText = @"SELECT id, emailResponsavel, titulo, tipoProjeto, dataInicio, status FROM Projeto " + where + " ";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    p.id = Convert.ToInt16(leitor["id"].ToString());
                    p.titulo = leitor["titulo"].ToString();
                    p.emailResponsavel = leitor["emailResponsavel"].ToString();
                    p.status = Convert.ToInt16(leitor["status"].ToString());
                    p.tipo = Convert.ToInt16(leitor["tipoProjeto"].ToString());
                    p.dataInicio = Convert.ToDateTime(leitor["dataInicio"].ToString());
                }
            }
            catch (Exception)
            {
                conexao.Close();
                return null;
            }
            conexao.Close();
            return p;
        }
        public bool editaProjeto(Projeto p)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            try
            {
                conexao.Open();
                comando.CommandText = @"UPDATE Projeto SET emailResponsavel = emailResponsavel, titulo = titulo, tipoProjeto = tipoProjeto, dataInicio = dataInicio, status = status WHERE id = id";
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
        public bool excluiProjeto(int id)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            DateTime licenca = DateTime.Now.AddDays(365);
            try
            {
                conexao.Open();
                comando.CommandText = @"DELETE FROM Projeto WHERE id = " + id + " ";
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

        public List<string> buscaTiposProjeto()
        {
            List<string> lista = new List<string>();
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT descricao FROM TipoProjeto ORDER BY id ";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    string item = leitor["descricao"].ToString();
                    lista.Add(item);
                }
                conexao.Close();
                return lista;
            }
            catch (Exception ex) { }
            return null;
        }
    }
}
