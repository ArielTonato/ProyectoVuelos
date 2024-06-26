﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace proyecto.fisei.vuelos.dominio
{
    [DataContract]
    public class Reserva
    {
        [DataMember]
        public int ReservaID { get; set; }
        [DataMember]
        public int UsuarioId{ get; set; }
        [DataMember]
        public int VueloID { get; set; }
        [DataMember]
        public DateTime FechaReserva { get; set; }
        [DataMember]
        public string Estado { get; set; }
    }
}
