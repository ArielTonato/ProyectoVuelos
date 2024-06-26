﻿using System;
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
    public interface IReservaService
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ListarReservas", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<Reserva> ListarReservas(Usuario usuario);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/RegistrarReserva", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        Reserva RegistrarReserva(Reserva reserva);
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ActualizarReserva", Method = "PUT", BodyStyle = WebMessageBodyStyle.Bare)]
        Reserva ActualizarReserva(Reserva reserva);
    }
}
