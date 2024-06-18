using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Web;
using proyecto.fisei.vuelos.dominio;

namespace proyecto.fisei.vuelos.contrato
{
    [ServiceContract]
    public interface IAuthService
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/IniciarSesion", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        bool IniciarSesion(Usuario usuario);
    }
}
