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
    public class VueloFachada:IDisposable
    {

        public IEnumerable<Vuelo> ListarVuelos()
        {
            IVueloRepositorio vueloRepositorio = new VueloRepositorio();
            return vueloRepositorio.ListarVuelos();
        }

        public IEnumerable<Vuelo> BuscarVuelo(Vuelo vuelo)
        {
            IVueloRepositorio vueloRepositorio = new VueloRepositorio();
            return vueloRepositorio.BuscarVuelo(vuelo);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
