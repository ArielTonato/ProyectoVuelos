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
    public class ReservaFachada : IDisposable
    {
        public Reserva ActualizarReserva(Reserva reserva)
        {
            IReservaRepositorio reservaRepositorio = new ReservaRepositorio();
            return reservaRepositorio.ActualizarReserva(reserva);
        }

        public IEnumerable<Reserva> ListarReservas(Usuario usuario)
        {
            IReservaRepositorio reservaRepositorio = new ReservaRepositorio();
            return reservaRepositorio.ListarReservas(usuario);
        }

        public Reserva RegistrarReserva(Reserva reserva)
        {
            IReservaRepositorio reservaRepositorio = new ReservaRepositorio();
            return reservaRepositorio.RegistrarReserva(reserva);
        }

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
