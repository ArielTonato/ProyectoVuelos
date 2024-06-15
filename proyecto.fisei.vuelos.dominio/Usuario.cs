using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace proyecto.fisei.vuelos.dominio
{
    [DataContract]
    public class Usuario
    {
        [DataMember]
        public int UsuarioId { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Apellido { get; set; }
        [DataMember]
        public string CorreoElectronico { get; set; }
        [DataMember]
        public string ClaveHash { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
    }
}
