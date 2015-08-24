using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDM.DataObjects
{
    public class Usuario
    {
        public string email { get; set; }
        public string password { get; set; }
        public bool lembrarSenha { get; set; }
    }
}
