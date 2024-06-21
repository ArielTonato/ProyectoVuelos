using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto.fisei.vuelos.dominio;

namespace proyecto.fisei.vuelos.ContratoRepositorio
{
    public interface IResevaRepositorio
    {
        IEnumerable<Reserva> ListarReservas(Usuario usuario);
        Reserva RegistrarReserva(Reserva reserva);
        Reserva ActualizarReserva(Reserva reserva);
    }
}
