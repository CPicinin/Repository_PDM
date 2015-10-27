using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDM.DataAcess;
using PDM.DataObjects;

namespace PDM.BusinessLayer
{
    public class ProjetoBL
    {
        public List<Projeto> buscaProjetos(string email)
        {
            List<Projeto> lista = new List<Projeto>();
            ProjetoDA pda = new ProjetoDA();
            lista = pda.buscaProjetos(email);
            return lista;
        }

        public bool cadastraProjeto(Projeto p)
        {
            ProjetoDA pda = new ProjetoDA();
            bool cadastrou = pda.cadastraProjeto(p);
            return cadastrou;
        }

        public Projeto buscaProjeto(string titulo, int codigo)
        {
            Projeto p = new Projeto();
            ProjetoDA pda = new ProjetoDA();
            p = pda.buscaProjeto(titulo, codigo);
            return p;
        }
        public bool editaProjeto(Projeto p)
        {
            ProjetoDA pda = new ProjetoDA();
            bool editou = pda.editaProjeto(p);
            return editou;
        }
        public bool excluiProjeto(int id)
        {
            ProjetoDA pda = new ProjetoDA();
            bool excluiu = pda.excluiProjeto(id);
            return excluiu;
        }
        public List<string> buscaTiposProjeto()
        {
            
            List<string> lista = new List<string>();
            ProjetoDA pda = new ProjetoDA();
            lista = pda.buscaTiposProjeto();
            return lista;
        }
        public string buscaNomeTipoProjeto(int id)
        {
            ProjetoDA pda = new ProjetoDA();
            string item = pda.buscaNomeTipoProjeto(id);
            return item;
        }
        public List<Projeto> teste()
        {

            List<string> lista = new List<string>();
            ProjetoDA pda = new ProjetoDA();
            var bind = pda.buscaProjetos("");

            return bind;
        }
        public int contaProjetosEmpresa(int idEmpresa, string where)
        {
            ProjetoDA pda = new ProjetoDA();
            int qnt = pda.contaProjetosEmpresa(idEmpresa, where);
            return qnt;
        }
        
    }
}
