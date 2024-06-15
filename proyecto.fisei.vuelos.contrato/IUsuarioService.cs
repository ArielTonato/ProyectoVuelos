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
    public interface IUsuarioService
    {
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ListarUsuarios", BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<Usuario> ListarUsuarios();

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/RegistrarUsuario", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        Usuario RegistrarUsuario(Usuario usuario);

        //[OperationContract]
        //[WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/IniciarSesion", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        //Usuario IniciarSesion(string correoElectronico, string claveHash);

    }
}
