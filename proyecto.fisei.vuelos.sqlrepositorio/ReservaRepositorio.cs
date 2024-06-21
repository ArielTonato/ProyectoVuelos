using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto.fisei.vuelos.dominio;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using proyecto.fisei.vuelos.utils;
using proyecto.fisei.vuelos.ContratoRepositorio;

namespace proyecto.fisei.vuelos.sqlrepositorio
{
    public class ReservaRepositorio : IResevaRepositorio
    {
        Reserva IResevaRepositorio.ActualizarReserva(Reserva reserva)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(ConexionRepository.ObtenerCadenaConexion()))
                { 
                    conexion.Open();
                    var parametros = new DynamicParameters();
                    parametros.Add("ReservaID", reserva.ReservaID);
                    parametros.Add("Estado", reserva.Estado);

                    var result = conexion.Execute("dbo.actualizarReserva", parametros, commandType: CommandType.StoredProcedure);
                    return result > 0 ? reserva: new Reserva();
                }
                }catch(Exception ex )
            {
                throw ex;
            }
        }

        IEnumerable<Reserva> IResevaRepositorio.ListarReservas(Usuario usuario)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(ConexionRepository.ObtenerCadenaConexion()))
                {
                    conexion.Open();
                    var parametros = new DynamicParameters();
                    parametros.Add("UsuarioId", usuario.UsuarioId);
                    var reservas = conexion.Query<Reserva>("dbo.listarReservas", parametros, commandType: CommandType.StoredProcedure);
                    return reservas;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        Reserva IResevaRepositorio.RegistrarReserva(Reserva reserva)
        {
            try{
                using (IDbConnection conexion = new SqlConnection(ConexionRepository.ObtenerCadenaConexion()))
                {
                    conexion.Open();
                    var parametros = new DynamicParameters();
                    parametros.Add("UsuarioId", reserva.UsuarioId);
                    parametros.Add("VueloID", reserva.VueloID);
                    var reservaRegistrada = conexion.Query<Reserva>("dbo.insertarReserva", parametros, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return reserva;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
