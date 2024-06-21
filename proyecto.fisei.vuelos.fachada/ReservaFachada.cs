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
    public class ReservaFachada:IDisposable
    {
        public IEnumerable<Reserva> ListarReservas(Usuario usuario)
        {
            IResevaRepositorio reservaRepositorio = new ReservaRepositorio();
            return reservaRepositorio.ListarReservas(usuario);
        }

        public Reserva RegistrarReserva(Reserva reserva)
        {
            IResevaRepositorio reservaRepositorio = new ReservaRepositorio();
            return reservaRepositorio.RegistrarReserva(reserva);
        }

        public Reserva ActualizarReserva(Reserva reserva)
        {
            IResevaRepositorio reservaRepositorio = new ReservaRepositorio();
            return reservaRepositorio.ActualizarReserva(reserva);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
