using ProyectoAndina.Data;
using ProyectoAndina.Models; // Asegúrate de tener el `using` correcto para el modelo Rol
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProyectoAndina.Controllers
{
    public class RolController
    {
        private readonly DatabaseConnection _dbConnection;

        public RolController()
        {
            _dbConnection = new DatabaseConnection();
        }

        // ✅ Insertar nuevo rol
        public void InsertarRol(RolM rol)
        {
            string query = @"
                INSERT INTO roles (nombre, descripcion, estado, fecha_creacion)
                VALUES (@NombreRol, @Descripcion, @Estado, GETDATE())";

            using (var connection = _dbConnection.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@NombreRol", rol.Nombre);
                command.Parameters.AddWithValue("@Descripcion", rol.Descripcion);
                command.Parameters.AddWithValue("@Estado", rol.Estado);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        // ✅ Obtener lista de roles
        public List<RolM> ObtenerRoles()
        {
            var lista = new List<RolM>();
            string query = "SELECT * FROM roles";

            using (var connection = _dbConnection.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new RolM
                        {
                            RolId = (int)reader["rol_id"],
                            Nombre = reader["nombre"].ToString(),
                            Descripcion = reader["descripcion"].ToString(),
                            Estado = Convert.ToInt32(reader["estado"]) == 1,
                            FechaCreacion = reader["fecha_creacion"] as DateTime?,
                            FechaModificacion = reader["fecha_modificacion"] as DateTime?
                        });
                    }
                }
                connection.Close();
            }

            return lista;
        }


        //sacar solo docentes y estudiantes 

        public List<RolM> ObtenerRolesDocentesEstudiantes()
        {
            var lista = new List<RolM>();
            string query = @"
        SELECT * 
        FROM roles
        WHERE UPPER(nombre) LIKE '%DOCENTE%'
           OR UPPER(nombre) LIKE '%ESTUDIANTE%'
           OR UPPER(nombre) LIKE '%INVITADO%'";

            using (var connection = _dbConnection.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new RolM
                        {
                            RolId = (int)reader["rol_id"],
                            Nombre = reader["nombre"].ToString(),
                            Descripcion = reader["descripcion"].ToString(),
                            Estado = Convert.ToInt32(reader["estado"]) == 1,
                            FechaCreacion = reader["fecha_creacion"] as DateTime?,
                            FechaModificacion = reader["fecha_modificacion"] as DateTime?
                        });
                    }
                }
                connection.Close();
            }

            return lista;
        }


        public RolM ObtenerRolPorId(int id)
        {
            RolM rol = null;
            string query = "SELECT * FROM roles WHERE rol_id = @RolId";

            using (var connection = _dbConnection.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RolId", id);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        rol = new RolM
                        {
                            RolId = (int)reader["rol_id"],
                            Nombre = reader["nombre"].ToString(),
                            Descripcion = reader["descripcion"].ToString(),
                            Estado = Convert.ToInt32(reader["estado"]) == 1,
                            FechaCreacion = reader["fecha_creacion"] as DateTime?,
                            FechaModificacion = reader["fecha_modificacion"] as DateTime?
                        };
                    }
                }
                connection.Close();
            }

            return rol;
        }


        // ✅ Actualizar un rol existente
        public void ActualizarRol(RolM rol)
        {
            string query = @"
                UPDATE roles
                SET nombre = @NombreRol,
                    descripcion = @Descripcion,
                    estado = @Estado,
                    fecha_modificacion = GETDATE()
                WHERE rol_id = @IdRol";

            using (var connection = _dbConnection.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@NombreRol", rol.Nombre);
                command.Parameters.AddWithValue("@Descripcion", rol.Descripcion);
                command.Parameters.AddWithValue("@Estado", rol.Estado);
                command.Parameters.AddWithValue("@IdRol", rol.RolId);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        // ✅ Eliminar un rol por ID
        public void EliminarRol(int idRol)
        {
            string query = "DELETE FROM roles WHERE rol_id = @IdRol";

            using (var connection = _dbConnection.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdRol", idRol);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
