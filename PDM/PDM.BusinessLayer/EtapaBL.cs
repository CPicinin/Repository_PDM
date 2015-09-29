using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDM.DataAcess;
using PDM.DataObjects;

namespace PDM.BusinessLayer
{
    public class EtapaBL
    {
        public int buscaIdEtapa(string descricao)
        {
            EtapaDA eda = new EtapaDA();
            int id = eda.buscaIdEtapa(descricao);
            return id;
        }
        public List<string> buscaDescricaoEtapas()
        {
            List<string> lista = new List<string>();
            EtapaDA eda = new EtapaDA();
            lista = eda.buscaDescicaoEtapas();
            return lista;
        }
        public string buscaDescricaoEtapa(int id)
        {
            string desc = "";
            EtapaDA eda = new EtapaDA();
            desc = eda.buscaDescricaoEtapa(id);
            return desc;
        }
        public List<Etapa> buscaEtapas()
        {
            List<Etapa> lista = new List<Etapa>();
            EtapaDA eda = new EtapaDA();
            lista = eda.buscaEtapas();
            return lista;
        }
        public Etapa buscaEtapa(int id)
        {
            Etapa e = new Etapa();
            EtapaDA eda = new EtapaDA();
            e = eda.buscaEtapa(id);
            return e;
        }
        public bool excluiEtapa(int id)
        {
            EtapaDA eda = new EtapaDA();
            bool foi = eda.excluiEtapa(id);
            return foi;
        }
        public bool editaEtapa(Etapa e)
        {
            EtapaDA eda = new EtapaDA();
            bool foi = eda.editaEtapa(e);
            return foi;
        }
    }
}
