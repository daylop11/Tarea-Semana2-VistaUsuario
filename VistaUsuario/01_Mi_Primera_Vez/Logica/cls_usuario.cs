using System;
namespace _01_Mi_Primera_Vez.Logica
{
    public class cls_usuario
    {
        public cls_usuario()
        {
        }
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

        public string Editar(dto_usuario Usuario)
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