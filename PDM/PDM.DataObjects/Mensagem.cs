using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDM.DataObjects
{
    public class Mensagem
    {
        public int id { get; set; }
        public string responsavel { get; set; }
        public string remetente { get; set; }
        public DateTime data { get; set; }
        public string mensagem { get; set; }
        public int lida { get; set; }
    }
}
