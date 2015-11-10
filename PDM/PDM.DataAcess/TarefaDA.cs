using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PDM.DataObjects;

namespace PDM.DataAcess
{
    public class TarefaDA
    {
        public List<Tarefa> buscaTarefasProjeto(int numero, bool filtraEtapa, string etapa)
        {
            List<Tarefa> lista = new List<Tarefa>();
            string where = "";
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            int idEtapa = 0;
            if(filtraEtapa)
            {
                EtapaDA eda = new EtapaDA();
                idEtapa = eda.buscaIdEtapa(etapa);
                where = " WHERE idProjeto = " + numero + " AND idEtapa = " + idEtapa + " ";
            }
            else
            {
                where = " WHERE idProjeto = " + numero + " ";
            }

            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT id,idProjeto,idEtapa,emailResponsavel,titulo,dataInicio,dataFim,prazoEstimado,observacao, " +
                    "status FROM dbo.Tarefa " + where + " ";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    Tarefa t = new Tarefa();
                    t.id = Convert.ToInt16(leitor["id"].ToString());
                    t.idProjeto = Convert.ToInt16(leitor["idProjeto"].ToString());
                    t.idEtapa = Convert.ToInt16(leitor["idEtapa"].ToString());
                    t.titulo = leitor["titulo"].ToString();
                    t.emailResponsavel = leitor["emailResponsavel"].ToString();
                    t.status = Convert.ToInt16(leitor["status"].ToString());
                    t.dataInicio = Convert.ToDateTime(leitor["dataInicio"].ToString());
                    t.dataFim = Convert.ToDateTime(leitor["dataFim"].ToString());
                    t.prazoEstimado = Convert.ToInt16(leitor["prazoEstimado"].ToString());
                    t.observacao = leitor["observacao"].ToString();
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
        public Tarefa buscaTarefa(int id)
        {
            Tarefa t = new Tarefa();
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT id,idProjeto,idEtapa,emailResponsavel,titulo,dataInicio,dataFim,prazoEstimado,observacao, " +
                    "status FROM dbo.Tarefa WHERE id = " + id + " ";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    t.id = Convert.ToInt16(leitor["id"].ToString());
                    t.idProjeto = Convert.ToInt16(leitor["idProjeto"].ToString());
                    t.idEtapa = Convert.ToInt16(leitor["idEtapa"].ToString());
                    t.titulo = leitor["titulo"].ToString();
                    t.emailResponsavel = leitor["emailResponsavel"].ToString();
                    t.status = Convert.ToInt16(leitor["status"].ToString());
                    t.dataInicio = Convert.ToDateTime(leitor["dataInicio"].ToString());
                    t.dataFim = Convert.ToDateTime(leitor["dataFim"].ToString());
                    t.prazoEstimado = Convert.ToInt16(leitor["prazoEstimado"].ToString());
                    t.observacao = leitor["observacao"].ToString();
                }
                conexao.Close();
                return t;
            }
            catch (Exception)
            {
                conexao.Close();
                return null;
            }
        }
        public bool cadastraTarefa(Tarefa t)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            try
            {
                conexao.Open();
                comando.CommandText = @"INSERT INTO dbo.Tarefa (idProjeto,idEtapa,emailResponsavel,titulo,dataInicio,dataFim,prazoEstimado,observacao,status) " +
                            " VALUES (" + t.idProjeto + "," + t.idEtapa + ",'" + t.emailResponsavel + "','" + t.titulo +"', " +
                            " '" + t.dataInicio + "','" + t.dataFim + "'," + t.prazoEstimado + ",'" + t.observacao + "'," + t.status +")";
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
        public bool editaTarefa(Tarefa t)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            try
            {
                conexao.Open();
                comando.CommandText = @"UPDATE dbo.Tarefa SET idProjeto = " + t.idProjeto + ",idEtapa = " + t.idEtapa + ", " +
                    " emailResponsavel = '" + t.emailResponsavel + "',titulo = '" + t.titulo + "', dataInicio = '" + t.dataInicio + "', " +
                    " dataFim = '" + t.dataFim + "',prazoEstimado = " + t.prazoEstimado + ",observacao = '" + t.observacao + "', " + 
                    " status = " + t.status + " WHERE id = " + t.id + " ";
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
        public bool excluiTarefa(int id)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            try
            {
                conexao.Open();
                comando.CommandText = @"DELETE FROM Tarefa WHERE id = " + id + " ";
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
        public List<Tarefa> buscaTarefasUsuario(string email)
        {
            List<Tarefa> lista = new List<Tarefa>();
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT id,idProjeto,idEtapa,emailResponsavel,titulo,dataInicio,dataFim,prazoEstimado,observacao, " +
                    "status FROM dbo.Tarefa WHERE emailResponsavel = '" + email + "' AND status <> 3 AND status <> 2";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    Tarefa t = new Tarefa();
                    t.id = Convert.ToInt16(leitor["id"].ToString());
                    t.idProjeto = Convert.ToInt16(leitor["idProjeto"].ToString());
                    t.idEtapa = Convert.ToInt16(leitor["idEtapa"].ToString());
                    t.titulo = leitor["titulo"].ToString();
                    t.emailResponsavel = leitor["emailResponsavel"].ToString();
                    t.status = Convert.ToInt16(leitor["status"].ToString());
                    t.dataInicio = Convert.ToDateTime(leitor["dataInicio"].ToString());
                    t.dataFim = Convert.ToDateTime(leitor["dataFim"].ToString());
                    t.prazoEstimado = Convert.ToInt16(leitor["prazoEstimado"].ToString());
                    t.observacao = leitor["observacao"].ToString();
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
        public bool adicionarItem(ItemTarefa i)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            try
            {
                conexao.Open();
                comando.CommandText = @"INSERT INTO dbo.ItensTarefa (idTarefa,data,descricao) " +
                            " VALUES (" + i.idTarefa + ",'" + i.data.ToShortDateString() + "', '" + i.descricao + "')";
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
        public bool removerItem(int id)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            try
            {
                conexao.Open();
                comando.CommandText = @"DELETE FROM dbo.ItensTarefa WHERE id = " + id + " ";
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
        public int contaTarefasUsuario(string email)
        {
            int numero = 0;
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT COUNT(id) AS 'quantidade' FROM dbo.Tarefa WHERE emailResponsavel = '" + email + "' AND status <> 3 AND status <> 2";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    numero = Convert.ToInt16(leitor["quantidade"].ToString());
                }
                conexao.Close();
                return numero;
            }
            catch (Exception)
            {
                conexao.Close();
                return numero;
            }
        }
        public List<ItemTarefa> buscaItensTarefa(int id)
        {
            List<ItemTarefa> listaItens = new List<ItemTarefa>();
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT id,idTarefa,data,descricao FROM dbo.ItensTarefa WHERE idTarefa = " + id + " ";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    ItemTarefa it = new ItemTarefa();
                    it.id = Convert.ToInt16(leitor["id"]);
                    it.idTarefa = Convert.ToInt16(leitor["idTarefa"]);
                    it.data = Convert.ToDateTime(leitor["data"]);
                    it.descricao = leitor["descricao"].ToString();
                    listaItens.Add(it);
                }
                conexao.Close();
                return listaItens;
            }
            catch (Exception)
            {
                conexao.Close();
                return null;
            }
        }
        public bool mudaStatusTarefa(int status, int id)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            try
            {
                conexao.Open();
                comando.CommandText = @"UPDATE dbo.Tarefa SET status = " + status + " WHERE id = " + id + " ";
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
        public int contaTarefasProjeto(int id)
        {
            int qnt = 0;
            Tarefa t = new Tarefa();
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT COUNT(id) AS 'quantidade' FROM dbo.Tarefa WHERE idProjeto = " + id + " ";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    qnt = Convert.ToInt16(leitor["quantidade"].ToString());
                }
                conexao.Close();
                return qnt;
            }
            catch (Exception)
            {
                conexao.Close();
                return 0;
            }
            return qnt;
        }
        public int contaTarefaFinalizadasProjeto(int id)
        {
            int qnt = 0;
            Tarefa t = new Tarefa();
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            try
            {
                conexao.Open();
                comando.CommandText = @"SELECT COUNT(id) AS 'quantidade' FROM dbo.Tarefa WHERE idProjeto = " + id + " AND status <> 0 AND status <> 1";
                comando.Connection = conexao;
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    qnt = Convert.ToInt16(leitor["quantidade"].ToString());
                }
                conexao.Close();
                return qnt;
            }
            catch (Exception)
            {
                conexao.Close();
                return 0;
            }
            return qnt;
        }
        public int contaTarefasEmpresa(int idEmpresa, string where)
        {
            int qnt = 0;
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = StaticObjects.strConexao;
            SqlCommand comando = new SqlCommand();
            SqlDataReader leitor;
            if ((where != "") && (where != null))
            {
                try
                {
                    conexao.Open();
                    comando.CommandText = @"SELECT COUNT(id) AS 'quantidade' FROM Tarefa WHERE emailResponsavel IN (SELECT email from Usuario WHERE idEmpresa  = " + idEmpresa + ") " + where + " ";
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
                    comando.CommandText = @"SELECT COUNT(id) AS 'quantidade' FROM Tarefa WHERE emailResponsavel IN (SELECT email from Usuario WHERE idEmpresa  = " + idEmpresa + ")";
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
    }
}
