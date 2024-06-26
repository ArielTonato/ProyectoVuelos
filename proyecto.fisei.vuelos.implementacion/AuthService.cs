using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using proyecto.fisei.vuelos.contrato;
using proyecto.fisei.vuelos.dominio;
using proyecto.fisei.vuelos.fachada;

namespace proyecto.fisei.vuelos.implementacion
{
    public class AuthService : IAuthService
    {
        Usuario IAuthService.IniciarSesion(Usuario usuario)
        {
            using (AuthFachada authFachada = new AuthFachada())
            {
                return authFachada.IniciarSesion(usuario);
            }
        }
    }
}
