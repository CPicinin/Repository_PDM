using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDM.DataObjects
{
    public static class StaticObjects
    {
        //public static string strConexao = @"Server=COLUSSI\SQLExpress; Database=pdm; User Id=sa;password=d@217799";
        public static string strConexao = @"Server=TI\SQLExpress; Database=pdm; User Id=sa;password=d@217799";
        //public static string strConexao = @"Server=VIRTUAL01\SQLExpress; Database=pdm; User Id=sa;password=*Cris159";
        
        // local onde serão salvos os PDF e local onde fica armazenado o logo
        //public static string filepathPDF = @"C:\Users\Gustavo\Source\Repos\Repository_PDM\PDM\PDM.View\pdf\";
        //public static string filepathImage = @"C:\Users\Gustavo\Source\Repos\Repository_PDM\PDM\PDM.View\template\img\pdm.png";
        //public static string filepathPDF = @"C:\Users\Development\Documents\GitHub\Repository_PDM2\PDM\PDM.View\pdf\";
        //public static string filepathImage = @"C:\Users\Development\Documents\GitHub\Repository_PDM2\PDM\PDM.View\template\img\pdm.png";
        public static string filepathPDF = @"C:\Users\Gestao_02\Source\Repos\Repository_PDM2\PDM\PDM.View\pdf\";
        public static string filepathImage = @"C:\Users\Gestao_02\Source\Repos\Repository_PDM2\PDM\PDM.View\template\img\pdm.png";
    }
}
