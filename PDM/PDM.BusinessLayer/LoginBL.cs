using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDM.DataAcess;
using PDM.DataObjects;

namespace PDM.BusinessLayer
{
    public class LoginBL
    {
        public bool usuarioValido(Usuario user)
        {
            LoginDA lda = new LoginDA();
            bool existe = lda.existeUsuario(user);
            return existe;
        }
        public Usuario buscaUsuario(string email, string senha)
        {
            Usuario user = new Usuario();
            LoginDA lda = new LoginDA();
            user = lda.buscaUsuario(email, senha);
            return user;
        }
    }
}
