using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDM.DataAcess;
using PDM.DataObjects;

namespace PDM.BusinessLayer
{
    public class MensagemBL
    {
        MensagemDA mda = new MensagemDA();

        public List<Mensagem> buscaMensagensusuario(string email)
        {
            List<Mensagem> lista = new List<Mensagem>();
            lista = mda.buscaMensagensusuario(email);
            return lista;
        }
        public string contaMensagens(string email)
        {
            string count = mda.contaMensagens(email);
            return count;
        }
        public bool marcaMensagemLida(int id)
        {
            bool leu = mda.marcaMensagemLida(id);
            return leu;
        }
        public Mensagem buscamensagem(int id)
        {
            Mensagem m = new Mensagem();
            m = mda.buscamensagem(id);
            return m;
        }
        public bool cadastraMensagem(Mensagem m)
        {
            bool foi = mda.cadastraMensagem(m);
            return foi;
        }
    }
}
