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
    public class VueloService:IVueloService
    {
        public IEnumerable<Vuelo> ListarVuelos()
        {
            using (VueloFachada vueloFachada = new VueloFachada())
            {
                return vueloFachada.ListarVuelos();
            }
        }

        public IEnumerable<Vuelo> BuscarVuelo(Vuelo vuelo)
        {
            using (VueloFachada vueloFachada = new VueloFachada())
            {
                return vueloFachada.BuscarVuelo(vuelo);
            }
        }
    }
}
