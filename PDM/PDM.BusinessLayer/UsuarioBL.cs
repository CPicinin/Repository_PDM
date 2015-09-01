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
        public List<Usuario> buscaUsuariosEmpresa(int empresa)
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
        public Usuario buscaUsuarioAtivo(string email)
        {
            UsuarioDA uda = new UsuarioDA();
            Usuario u = new Usuario();
            u = uda.buscaUsuarioAtivo(email);
            return u;
        }
        public bool editaUsuario(Usuario user)
        {
            UsuarioDA uDA = new UsuarioDA();
            bool editou = uDA.editaUsuario(user);
            return editou;
        }
        public bool excluiUsuario(string email)
        {
            UsuarioDA uDA = new UsuarioDA();
            bool excluiu = uDA.excluiUsuario(email);
            return excluiu;
        }
    }
}
