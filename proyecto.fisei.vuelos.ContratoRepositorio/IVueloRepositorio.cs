using proyecto.fisei.vuelos.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.fisei.vuelos.ContratoRepositorio
{
    public interface IVueloRepositorio
    {
        IEnumerable<Vuelo> ListarVuelos();
        IEnumerable<Vuelo> BuscarVuelo(Vuelo vuelo);
    }
}
