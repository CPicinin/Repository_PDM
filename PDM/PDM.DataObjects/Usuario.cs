using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDM.DataObjects
{
    public class Usuario
    {
        public string email { get; set; }
        public string senha { get; set; }
        public string nome { get; set; }
        public int idEmpresa { get; set; }
        public int tipo { get; set; }
        public DateTime dataFimLicenca { get; set; }
        public int ativo { get; set; }
    }
}
