using proyecto.fisei.vuelos.contrato;
using proyecto.fisei.vuelos.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto.fisei.vuelos.fachada;


namespace proyecto.fisei.vuelos.implementacion
{
    public class ReservaService : IReservaService
    {
        Reserva IReservaService.ActualizarReserva(Reserva reserva)
        {
            using (ReservaFachada reservaFachada = new ReservaFachada())
            {
                return reservaFachada.ActualizarReserva(reserva);
            }
        }

        IEnumerable<Reserva> IReservaService.ListarReservas(Usuario usuario)
        {
            using (ReservaFachada reservaFachada = new ReservaFachada())
            {
                return reservaFachada.ListarReservas(usuario);
            }
        }

        Reserva IReservaService.RegistrarReserva(Reserva reserva)
        {
            using(ReservaFachada reservaFachada = new ReservaFachada())
            {
                return reservaFachada.RegistrarReserva(reserva);
            }
        }
    }
}
