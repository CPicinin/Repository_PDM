using PDM.DataAcess;
using PDM.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDM.BusinessLayer
{
    public class LogEventoBL
    {
        LogEventoDA lda = new LogEventoDA();

        public void adicionaLog(Log l)
        {
            lda.adicionaLog(l);
        }
        public List<Log> buscaLogs(string where)
        {
            List<Log> lista = new List<Log>();
            lista = lda.buscaLogs(where);
            return lista;
        }
        public static string buscaArquivoTxt()
        {
            string texto = StaticObjects.arquivoTxt;
            return texto;
        }
    }
}
