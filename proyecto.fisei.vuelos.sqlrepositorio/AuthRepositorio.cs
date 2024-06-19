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
        public Usuario IniciarSesion(Usuario usuario)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(ConexionRepository.ObtenerCadenaConexion()))
                {
                    conexion.Open();
                    var parametros = new DynamicParameters();
                    parametros.Add("CorreoElectronico", usuario.CorreoElectronico);
                    parametros.Add("ClaveHash", usuario.ClaveHash);

                    var resultado = conexion.Query<Usuario>("dbo.iniciarSesion", parametros, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    // Verificar si no se encontró ningún usuario y devolver null explícitamente
                    if (resultado == null)
                    {
                        return null;
                    }

                    return resultado;
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                throw new Exception("Error al iniciar sesión", ex);
            }
        }
    }
}
