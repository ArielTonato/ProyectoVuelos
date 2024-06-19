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
    public class ReservaRepositorio : IReservaRepositorio
    {
        Reserva IReservaRepositorio.ActualizarReserva(Reserva reserva)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(ConexionRepository.ObtenerCadenaConexion()))
                {
                    conexion.Open();
                    var parametros = new DynamicParameters();
                    parametros.Add("ReservaId", reserva.ReservaID);
                    parametros.Add("VueloId", reserva.VueloID);
                    parametros.Add("FechaReserva", reserva.FechaReserva);
                    parametros.Add("Estado", reserva.Estado);
                    conexion.Execute("dbo.actualizarReserva", parametros, commandType: CommandType.StoredProcedure);
                    return reserva;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        IEnumerable<Reserva> IReservaRepositorio.ListarReservas(Usuario usuario)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(ConexionRepository.ObtenerCadenaConexion()))
                {
                    conexion.Open();
                    var parametros = new DynamicParameters();
                    parametros.Add("UsuarioId", usuario.UsuarioId);
                    var reserva = conexion.Query<Reserva>("dbo.listarReservas", parametros,commandType: CommandType.StoredProcedure);
                    return reserva;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        Reserva IReservaRepositorio.RegistrarReserva(Reserva reserva)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(ConexionRepository.ObtenerCadenaConexion()))
                {
                    conexion.Open();
                    var parametros = new DynamicParameters();
                    parametros.Add("UsuarioId", reserva.UsuarioID);
                    parametros.Add("VueloId", reserva.VueloID);
                    parametros.Add("Estado", reserva.Estado);
                    var reservaRegistrada = conexion.Query<Reserva>("dbo.InsertarReserva", parametros, commandType: CommandType.StoredProcedure).FirstOrDefault();
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
