using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace proyecto.fisei.vuelos.dominio
{
    [DataContract]
    public class Aeropuerto
    {
        [DataMember]
        public int AeropuertoID { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Ciudad { get; set; }
        [DataMember]
        public string Pais { get; set; }
    }
}
