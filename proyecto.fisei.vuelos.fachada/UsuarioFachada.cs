using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto.fisei.vuelos.dominio;
using proyecto.fisei.vuelos.sqlrepositorio;
using proyecto.fisei.vuelos.ContratoRepositorio;

namespace proyecto.fisei.vuelos.fachada
{
    public class UsuarioFachada:IDisposable
    {
        public IEnumerable<Usuario> ListarUsuarios()
        {
            IUsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
            return usuarioRepositorio.ListarUsuarios();
        }

        public Usuario RegistrarUsuario(Usuario usuario)
        {
            IUsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
            return usuarioRepositorio.RegistrarUsuario(usuario);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
