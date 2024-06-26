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
    public class ReservaService : IReservaService
    {
        IEnumerable<Reserva> IReservaService.ListarReservas(Usuario usuario)
        {
            using (ReservaFachada reservaFachada = new ReservaFachada())
            {
                return reservaFachada.ListarReservas(usuario);
            }
        }

        Reserva IReservaService.RegistrarReserva(Reserva reserva)
        {
            using (ReservaFachada reservaFachada = new ReservaFachada())
            {
                return reservaFachada.RegistrarReserva(reserva);
            }
        }
        Reserva IReservaService.ActualizarReserva(Reserva reserva)
        {
            using (ReservaFachada reservaFachada = new ReservaFachada())
            {
                return reservaFachada.ActualizarReserva(reserva);
            }
        }   
    }
}
