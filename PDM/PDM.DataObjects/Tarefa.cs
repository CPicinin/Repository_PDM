using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDM.DataObjects
{
    public class Tarefa
    {
        public int id { get; set; }
        public int idProjeto { get; set; }
        public int idEtapa { get; set; }
        public string emailResponsavel { get; set; }
        public string titulo { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataFim { get; set; }
        public int prazoEstimado { get; set; }
        public string observacao { get; set; }
        public int status { get; set; }
    }
}