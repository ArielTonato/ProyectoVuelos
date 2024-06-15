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
using System.Security.Cryptography;

namespace proyecto.fisei.vuelos.sqlrepositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        IEnumerable<Usuario> IUsuarioRepositorio.ListarUsuarios()
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(ConexionRepository.ObtenerCadenaConexion()))
                {
                    conexion.Open();
                    var usuario = conexion.Query<Usuario>("dbo.listarUsuarios", commandType: CommandType.StoredProcedure);
                    return usuario;
                }
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        Usuario IUsuarioRepositorio.RegistrarUsuario(Usuario usuario)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(ConexionRepository.ObtenerCadenaConexion()))
                {
                    conexion.Open();
                    var parametros = new DynamicParameters();
                    parametros.Add("Nombre", usuario.Nombre);
                    parametros.Add("Apellido", usuario.Apellido);
                    parametros.Add("CorreoElectronico", usuario.CorreoElectronico);
                    parametros.Add("ClaveHash",HashearClave(usuario.ClaveHash));
                    var usuarioRegistrado = conexion.Query<Usuario>("dbo.insertarUsuario", parametros, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    usuario.ClaveHash = HashearClave(usuario.ClaveHash);
                    return usuario;
                }
            }
            catch 
            {
                return new Usuario { Nombre = "El correo esta duplicado"};
            }
        }

        private string HashearClave(string clave)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convertir la clave a un arreglo de bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(clave));

                // Convertir los bytes a un string hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
