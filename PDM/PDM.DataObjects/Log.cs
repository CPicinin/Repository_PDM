using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDM.DataObjects
{
    public class Log
    {
        public int id { get; set; }
        public DateTime data { get; set; }
        public string email { get; set; }
        public string descricao { get; set; }
    }
}
