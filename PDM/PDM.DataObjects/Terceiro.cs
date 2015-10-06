using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDM.DataObjects
{
    public class Terceiro
    {
        public int id { get; set; }
        public string cpfCnpj { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public int tipoPessoa { get; set; }
        public int tipoTerceiro { get; set; }
        public int ativo { get; set; }
    }
}
