using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDM.DataObjects;
using PDM.DataAcess;

namespace PDM.BusinessLayer
{
    public class UsuarioBL
    {
        public List<Usuario> buscaUsuariosEmpresa(string empresa)
        {
            List<Usuario> lista = new List<Usuario>();
            UsuarioDA uDA = new UsuarioDA();
            lista = uDA.buscaUsuariosEmpresa(empresa);
            return lista;
        }
        public bool cadastraUsuario(Usuario user)
        {
            UsuarioDA uDA = new UsuarioDA();
            bool cadastrou = uDA.cadastraUsuario(user);
            return cadastrou;
        }
    }
}
