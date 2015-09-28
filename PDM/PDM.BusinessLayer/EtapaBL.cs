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
    }
}
