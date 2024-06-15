using proyecto.fisei.vuelos.ContratoRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto.fisei.vuelos.dominio;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace proyecto.fisei.vuelos.sqlrepositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        IEnumerable<Usuario> IUsuarioRepositorio.ListarUsuarios()
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepository.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var usuario = conexion.Query<Usuario>("dbo.listarUsuarios", commandType: CommandType.StoredProcedure);
                return usuario;
            }
        }

        Usuario IUsuarioRepositorio.RegistrarUsuario(Usuario usuario)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepository.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();
                parametros.Add("Nombre", usuario.Nombre);
                parametros.Add("Apellido", usuario.Apellido);
                parametros.Add("CorreoElectronico", usuario.CorreoElectronico);
                parametros.Add("ClaveHash", usuario.ClaveHash);
                var usuarioRegistrado = conexion.Query<Usuario>("dbo.insertarUsuario", parametros, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return usuario;
            }
        }
    }
}
