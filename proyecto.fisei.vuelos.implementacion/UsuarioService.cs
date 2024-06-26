using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto.fisei.vuelos.dominio;
using proyecto.fisei.vuelos.contrato;
using proyecto.fisei.vuelos.fachada;
using System.ServiceModel;

namespace proyecto.fisei.vuelos.implementacion
{
    public class UsuarioService : IUsuarioService
    {
        IEnumerable<Usuario> IUsuarioService.ListarUsuarios()
        {
            using (UsuarioFachada usuarioFachada = new UsuarioFachada())
            {
                return usuarioFachada.ListarUsuarios();
            }
        }

        Usuario IUsuarioService.RegistrarUsuario(Usuario usuario)
        {
            using (UsuarioFachada usuarioFachada = new UsuarioFachada())
            {
                return usuarioFachada.RegistrarUsuario(usuario);
            }
        }
    }
}
