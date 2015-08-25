using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDM.DataObjects;
using PDM.DataAcess;

namespace PDM.BusinessLayer
{
    public class EmpresaBL
    {
        public Empresa buscaEmpresa(int idEmpresa)
        {
            EmpresaDA eda = new EmpresaDA();
            Empresa e = new Empresa();
            e = eda.buscaEmpresa(idEmpresa);
            return e;
        }

        public int cadastraEmpresa(Empresa emp)
        {
            EmpresaDA eda = new EmpresaDA();
            int id = eda.cadastraEmpresa(emp);
            return id;
        }
    }
}
