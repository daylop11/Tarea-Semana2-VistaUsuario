using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Mi_Primera_Vez.Datos;

namespace _01_Mi_Primera_Vez.Logica
{
    internal class cls_usuario
    {
        private readonly conexion cn = new conexion();

        public string Insertar(dto_usuario Usuario)
        {
            using (var conexion = cn.obtenerConexion())
            {
                string cadena1 = "INSERT INTO usuario (nombre, edad) VALUES(@nombre, @edad)";
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
                string cadena = "SELECT IdPersonal, nombre, edad FROM Usuario";
                using (var comando = new SqlCommand(cadena, conexion))
                {
                    conexion.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            var usuario = new dto_usuario
                            {
                                IdPersonal = (int)lector["IdPersonal"],
                                nombre = lector["nombre"].ToString(),
                                edad = (int)lector["edad"]
                            };
                            listausuario.Add(usuario);
                        }
                    }
                }
            }

            return listausuario;
        }

        public string Editar(dto_Usuario Usuario) 
        {
            using (var conexion = cn.obtenerConexion())
            {
                string cadena = "UPDATE usuario SET nombre = @nombre, apellido = @apellido, edad = @edad, fechaNacimiento = @fechaNacimiento ;
                        using (var comando = new SqlCommand(cadena, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", Usuario.nombre);
                    comando.Parameters.AddWithValue("@apellido", Usuario.apellido);
                    comando.Parameters.AddWithValue("@edad", Usuario.edad);
                    comando.Parameters.AddWithValue("@fechaNacimiento", Usuario.fechaNacimiento);


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

