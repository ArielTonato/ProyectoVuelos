using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace proyecto.fisei.vuelos.dominio
{
    [DataContract]
    public class Vuelo
    {
        [DataMember]
        public int VueloId { get; set; }
        [DataMember]
        public string Origen { get; set; }
        [DataMember]
        public string Destino { get; set; }
        [DataMember]
        public DateTime FechaSalida { get; set; }
        [DataMember]
        public DateTime FechaLlegada { get; set; }
        [DataMember]
        public decimal Precio { get; set; }
    }
}
