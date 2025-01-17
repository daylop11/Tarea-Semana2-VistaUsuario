using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Mi_Primera_Vez.Datos;

namespace _01_Mi_Primera_Vez.Presentacion.Usuarios
{
    class cls_usuario
    {
        private readonly conexion cn = new conexion();

        public string Insertar(dto_usuario Usuario)
        {
            using (var conexion = cn.obtenerConexion())
            {
                string cadena1 = "INSERT INTO Usuarios(NombreApellido, Edad) VALUES(@nombre, @edad)";
                using (var comando = new SqlCommand(cadena1, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", Usuario.nombre);
                    comando.Parameters.AddWithValue("@edad", Usuario.edad);

                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();
                        return "ok";
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                }
            }
        }

        public List<dto_usuario> todos()
        {
            var listausuario = new List<dto_usuario>();
            using (var conexion = cn.obtenerConexion())
            {
                string cadena = "SELECT NombreApellido as Nombre, Edad, ID FROM Usuarios";
                using (var comando = new SqlCommand(cadena, conexion))
                {
                    conexion.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            var usuario = new dto_usuario
                            {
                                IdPersonal = (int)lector["ID"],
                                nombre = lector["Nombre"].ToString(),
                                edad = (int)lector["Edad"]
                            };
                            listausuario.Add(usuario);
                        }
                    }
                }
            } 

            return listausuario;
        }

        public string Editar(dto_usuario Usuario)
        {
            using (var conexion = cn.obtenerConexion())
            {
                string cadena = "UPDATE usuario SET NombreApellido = @nombre ,Edad = @edad";
                using (var comando = new SqlCommand(cadena, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", Usuario.nombre);

                    comando.Parameters.AddWithValue("@edad", Usuario.edad);
                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();
                        return "ok";
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                }

            }
        }
        public string Eliminar(int idUsuario)
        {
            using (var conexion = cn.obtenerConexion())
            {
                string cadena = "DELETE FROM Usuarios WHERE ID = @idUsuario";
                using (var comando = new SqlCommand(cadena, conexion))
                {
                    comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();
                        return "ok";
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                }

            }
        }
    }
}
// te hare el listar

