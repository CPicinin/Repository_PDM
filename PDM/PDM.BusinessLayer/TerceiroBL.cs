using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDM.DataObjects;
using PDM.DataAcess;
namespace PDM.BusinessLayer
{
    public class TerceiroBL
    {
        public List<Terceiro> buscaTerceiros(int empresa)
        {
            List<Terceiro> lista = new List<Terceiro>();
            TerceiroDA tDA = new TerceiroDA();
            lista = tDA.buscaTerceiros(empresa);
            return lista;
        }

        public bool cadastraTerceiro(Terceiro t)
        {
            TerceiroDA tDA = new TerceiroDA();
            bool cadastrou = tDA.cadastraTerceiro(t);
            return cadastrou;
        }

        public Terceiro buscaTerceiro(string nome, int codigo)
        {
            Terceiro t = new Terceiro();
            TerceiroDA tDA = new TerceiroDA();
            t = tDA.buscaTerceiro(nome, codigo);
            return t;
        }
        public bool editaTerceiro(Terceiro t)
        {
            TerceiroDA tDA = new TerceiroDA();
            bool editou = tDA.editaTerceiro(t);
            return editou;
        }
        public bool excluiTerceiro(int id)
        {
            TerceiroDA tDA= new TerceiroDA();
            bool excluiu = tDA.excluiTerceiro(id);
            return excluiu;
        }
    }
}
