using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDM.DataObjects
{
    public class Etapa
    {
        public int id { get; set; }
        public int idProjeto { get; set; }
        public string emailResponsavel { get; set; }
        public int numeroEtapaNoProjeto { get; set; }
        public string tituloEtapa { get; set; }
        public int statusConclusao { get; set; }
    }
}
