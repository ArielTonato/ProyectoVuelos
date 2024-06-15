using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace proyecto.fisei.vuelos.sqlrepositorio
{
    public class ConexionRepository
    {
        public static string ObtenerCadenaConexion()
        {
            return ConfigurationManager.ConnectionStrings["Proyecto"].ToString();
        }
    }
}
