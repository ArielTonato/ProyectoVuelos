using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto.fisei.vuelos.ContratoRepositorio;
using proyecto.fisei.vuelos.dominio;
using System.Data;
using System.Data.SqlClient;
using Dapper;


namespace proyecto.fisei.vuelos.sqlrepositorio
{
    public class VueloRepositorio : IVueloRepositorio
    {
        IEnumerable<Vuelo> IVueloRepositorio.BuscarVuelo(Vuelo vuelo)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(ConexionRepository.ObtenerCadenaConexion()))
                {
                    conexion.Open();
                    var parametros = new DynamicParameters();
                    parametros.Add("Origen", vuelo.Origen);
                    parametros.Add("Destino", vuelo.Destino);
                    //parametros.Add("FechaSalida", vuelo.FechaSalida == DateTime.MinValue ? null : (DateTime?)vuelo.FechaSalida); // Manejo de fecha
                    var vueloEncontrado = conexion.Query<Vuelo>("dbo.listarVuelos", parametros, commandType: CommandType.StoredProcedure);
                    return vueloEncontrado;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message); // Muestra el mensaje de error en la consola
                return new List<Vuelo>();
            }
        }

        IEnumerable<Vuelo> IVueloRepositorio.ListarVuelos()
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(ConexionRepository.ObtenerCadenaConexion()))
                {
                    conexion.Open();
                    var vuelo = conexion.Query<Vuelo>("dbo.listarVuelos", commandType: CommandType.StoredProcedure);
                    return vuelo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
