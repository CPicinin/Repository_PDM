using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDM.DataObjects
{
    public class Empresa
    {
        public int id { get; set; }
        public string cnpj { get; set; }
        public string razao { get; set; }
        public string email { get; set; }
    }
}
