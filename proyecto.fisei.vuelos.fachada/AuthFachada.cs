using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto.fisei.vuelos.ContratoRepositorio;
using proyecto.fisei.vuelos.dominio;
using proyecto.fisei.vuelos.sqlrepositorio;

namespace proyecto.fisei.vuelos.fachada
{
    public class AuthFachada:IDisposable
    {
        public Usuario IniciarSesion(Usuario usuario)
        {
            IAuthRepositorio authRepositorio = new AuthRepositorio();
            return authRepositorio.IniciarSesion(usuario);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
