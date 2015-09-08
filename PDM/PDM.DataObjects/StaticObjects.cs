using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDM.DataObjects
{
    public class StaticObjects
    {
        //public static string strConexao = @"Server=COLUSSI\SQLExpress; Database=pdm; User Id=sa;password=d@217799";
        public static string strConexao = @"Server=TI\SQLExpress; Database=pdm; User Id=sa;password=d@217799";
        //public static string strConexao = @"Server=VIRTUAL01\SQLExpress; Database=pdm; User Id=sa;password=*Cris159";
        public static Usuario user = new Usuario();
    }
}
