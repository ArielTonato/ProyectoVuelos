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
    public class AuthRepositorio : IAuthRepositorio
    {
        public bool IniciarSesion(Usuario usuario)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(ConexionRepository.ObtenerCadenaConexion()))
                {
                    conexion.Open();
                    var parametros = new DynamicParameters();
                    parametros.Add("CorreoElectronico", usuario.CorreoElectronico);
                    parametros.Add("ClaveHash", usuario.ClaveHash);

                    bool resultado = conexion.ExecuteScalar<bool>("dbo.iniciarSesion", parametros, commandType: CommandType.StoredProcedure);
            
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
