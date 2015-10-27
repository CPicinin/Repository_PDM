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
                comando.CommandText = @"SELECT id, emailResponsavel, titulo, idTipo, dataInicio, status FROM Projeto WHERE emailResponsavel = '" + email + "' ";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    Projeto p = new Projeto();
                    p.id = Convert.ToInt16(leitor["id"].ToString());
                    p.titulo = leitor["titulo"].ToString();
                    p.emailResponsavel = leitor["emailResponsavel"].ToString();
                    p.status = Convert.ToInt16(leitor["status"].ToString());
                    p.tipo = Convert.ToInt16(leitor["idTipo"].ToString());
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
                comando.CommandText = @"INSERT INTO Projeto(emailResponsavel, titulo, idTipo, dataInicio, status) VALUES " +
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
                comando.CommandText = @"SELECT id, emailResponsavel, titulo, idTipo, dataInicio, status FROM Projeto " + where + " ";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    p.id = Convert.ToInt16(leitor["id"].ToString());
                    p.titulo = leitor["titulo"].ToString();
                    p.emailResponsavel = leitor["emailResponsavel"].ToString();
                    p.status = Convert.ToInt16(leitor["status"].ToString());
                    p.tipo = Convert.ToInt16(leitor["idTipo"].ToString());
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
                comando.CommandText = @"UPDATE Projeto SET emailResponsavel = '" + p.emailResponsavel +"', titulo = '" + p.titulo + "', " +
                    " idTipo = " + p.tipo + ", dataInicio = '" + p.dataInicio + "', status = " + p.status + " WHERE id = " + p.id + " ";
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
        public int contaProjetosEmpresa(int idEmpresa, string where)
        {
            int qnt = 0;
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            if((where != "") && (where != null))
            {
                try
            {
                conexao.Open();
                comando.CommandText = @"SELECT COUNT(id) AS 'quantidade' FROM Projeto WHERE emailResponsavel IN (SELECT email from Usuario WHERE idEmpresa = " + idEmpresa + ") " + where + " ";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    qnt = Convert.ToInt16(leitor["quantidade"].ToString());
                }
                conexao.Close();
                return qnt;
            }
            catch (Exception ex) { return 0; }
            }
            else
            {
                try
            {
                conexao.Open();
                comando.CommandText = @"SELECT COUNT(id) AS 'quantidade' FROM Projeto WHERE emailResponsavel IN (SELECT email from Usuario WHERE idEmpresa = " + idEmpresa + ")";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    qnt = Convert.ToInt16(leitor["quantidade"].ToString());
                }
                conexao.Close();
                return qnt;
            }
            catch (Exception ex) { return 0; }
            }
        }
        public Dictionary<string, string> buscaTiposProjeto()
        {
            Dictionary<string, string> lista = new Dictionary<string, string>();
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT id, descricao FROM TipoProjeto ORDER BY id ";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    string item = leitor["id"].ToString();
                    string item2 = leitor["descricao"].ToString();
                    lista.Add(item, item2);
                }
                conexao.Close();
                return lista;
            }
            catch (Exception ex) { }
            return null;
        }
        public string buscaNomeTipoProjeto(int id)
        {
            string item = "";
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT descricao FROM TipoProjeto WHERE id= " + id + "";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    item = leitor["descricao"].ToString();
                }
                conexao.Close();
                return item;
            }
            catch (Exception ex) { }
            return null;
        }
    }
}
