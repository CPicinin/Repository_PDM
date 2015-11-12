using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDM.DataObjects
{
    public class Projeto
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string emailResponsavel { get; set; }
        public int tipo { get; set; }
        public DateTime dataInicio { get; set; }
        public int status { get; set; }
        public int vaiTerceiro { get; set; }
        public int idTerceiro { get; set; }
    }
}
