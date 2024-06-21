using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using proyecto.fisei.vuelos.dominio;

namespace proyecto.fisei.vuelos.contrato
{
    [ServiceContract]
    public interface IVueloService
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ListarVuelos", Method = "GET", BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<Vuelo> ListarVuelos();

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/BuscarVuelos", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<Vuelo> BuscarVuelo(Vuelo vuelo);
    }
}
