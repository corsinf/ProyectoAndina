using ProyectoAndina.Data;
using ProyectoAndina.Models;
using ProyectoAndina.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAndina.Controllers
{
    public class PersonaRolController
    {
        private readonly DatabaseConnection _dbConnection;
       
        public PersonaRolController()
        {
            _dbConnection = new DatabaseConnection();
            
        }

        public List<persona_rolM> ObtenerPersonaRoles()
        {
            var lista = new List<persona_rolM>();

            string query = @"
        SELECT pr.id_persona_rol, pr.per_id, pr.rol_id, pr.fecha_asignacion, pr.estado,
               p.primer_nombre, p.primer_apellido, p.cedula, 
               r.nombre, r.descripcion
        FROM personas_roles pr
        INNER JOIN personas p ON pr.per_id = p.per_id
        INNER JOIN roles r ON pr.rol_id = r.rol_id";

            using (var connection = _dbConnection.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new persona_rolM
                        {
                            IdPersonaRol = (int)reader["id_persona_rol"],
                            PerId = (int)reader["per_id"],
                            RolId = (int)reader["rol_id"],
                            FechaAsignacion = reader["fecha_asignacion"] as DateTime?,
                            Estado = Convert.ToBoolean(reader["estado"]),
                            NombrePersona = $"{reader["primer_nombre"]} {reader["primer_apellido"]}",
                            Cedula = reader["cedula"]?.ToString(),
                            NombreRol = reader["nombre"]?.ToString(),
                            DescripcionRol = reader["descripcion"]?.ToString()
                        });
                    }
                }
            }

            return lista;
        }

        //paginado
        public ResultadoPaginado<persona_rolM> ObtenerPersonaRolesPaginados(
    int pagina = 1,
    int registrosPorPagina = 20,
    string filtro = "")
        {
            var resultado = new ResultadoPaginado<persona_rolM>
            {
                PaginaActual = pagina,
                RegistrosPorPagina = registrosPorPagina
            };

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                // --- 1. Contar total de registros ---
                string countQuery = @"
            SELECT COUNT(*)
            FROM personas_roles pr
            INNER JOIN personas p ON pr.per_id = p.per_id
            INNER JOIN roles r ON pr.rol_id = r.rol_id
            WHERE pr.estado = 1 AND (@Filtro = '' OR
                   p.primer_nombre LIKE '%' + @Filtro + '%' OR
                   p.primer_apellido LIKE '%' + @Filtro + '%' OR
                   p.cedula LIKE '%' + @Filtro + '%' OR
                   r.nombre LIKE '%' + @Filtro + '%' OR
                   r.descripcion LIKE '%' + @Filtro + '%')";

                using (var countCmd = new SqlCommand(countQuery, connection))
                {
                    countCmd.Parameters.AddWithValue("@Filtro", filtro ?? "");
                    resultado.TotalRegistros = (int)countCmd.ExecuteScalar();
                }

                // --- 2. Consultar registros paginados ---
                string dataQuery = @"
            SELECT pr.id_persona_rol, pr.per_id, pr.rol_id, pr.fecha_asignacion, pr.estado,
                   p.primer_nombre, p.primer_apellido, p.cedula, 
                   r.nombre, r.descripcion
            FROM personas_roles pr
            INNER JOIN personas p ON pr.per_id = p.per_id
            INNER JOIN roles r ON pr.rol_id = r.rol_id
            WHERE (@Filtro = '' OR
                   p.primer_nombre LIKE '%' + @Filtro + '%' OR
                   p.primer_apellido LIKE '%' + @Filtro + '%' OR
                   p.cedula LIKE '%' + @Filtro + '%' OR
                   r.nombre LIKE '%' + @Filtro + '%' OR
                   r.descripcion LIKE '%' + @Filtro + '%')
            ORDER BY pr.id_persona_rol DESC
            OFFSET @Offset ROWS 
            FETCH NEXT @PageSize ROWS ONLY";

                using (var dataCmd = new SqlCommand(dataQuery, connection))
                {
                    var offset = (pagina - 1) * registrosPorPagina;

                    dataCmd.Parameters.AddWithValue("@Filtro", filtro ?? "");
                    dataCmd.Parameters.AddWithValue("@Offset", offset);
                    dataCmd.Parameters.AddWithValue("@PageSize", registrosPorPagina);

                    using (var reader = dataCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resultado.Datos.Add(new persona_rolM
                            {
                                IdPersonaRol = (int)reader["id_persona_rol"],
                                PerId = (int)reader["per_id"],
                                RolId = (int)reader["rol_id"],
                                FechaAsignacion = reader["fecha_asignacion"] as DateTime?,
                                Estado = Convert.ToBoolean(reader["estado"]),
                                NombrePersona = $"{reader["primer_nombre"]} {reader["primer_apellido"]}",
                                Cedula = reader["cedula"]?.ToString(),
                                NombreRol = reader["nombre"]?.ToString(),
                                DescripcionRol = reader["descripcion"]?.ToString()
                            });
                        }
                    }
                }
            }

            return resultado;
        }


        public persona_rolM ObtenerPersonaRolId(int idPersonaRol)
        {
            persona_rolM personaRol = null;

            string query = @"
SELECT pr.id_persona_rol, pr.per_id, pr.rol_id, pr.fecha_asignacion, pr.estado,
       p.primer_nombre, p.primer_apellido, p.cedula, 
       r.nombre, r.descripcion
FROM personas_roles pr
INNER JOIN personas p ON pr.per_id = p.per_id
INNER JOIN roles r ON pr.rol_id = r.rol_id
WHERE pr.id_persona_rol = @IdPersonaRol";

            using (var connection = _dbConnection.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdPersonaRol", idPersonaRol);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read()) // 👈 solo uno
                    {
                        personaRol = new persona_rolM
                        {
                            IdPersonaRol = (int)reader["id_persona_rol"],
                            PerId = (int)reader["per_id"],
                            RolId = (int)reader["rol_id"],
                            FechaAsignacion = reader["fecha_asignacion"] as DateTime?,
                            Estado = Convert.ToBoolean(reader["estado"]),
                            NombrePersona = $"{reader["primer_nombre"]} {reader["primer_apellido"]}",
                            Cedula = reader["cedula"]?.ToString(),
                            NombreRol = reader["nombre"]?.ToString(),
                            DescripcionRol = reader["descripcion"]?.ToString()
                        };
                    }
                }
            }

            return personaRol;
        }


        //tener las personas sin rol 

        public List<persona_rolM> ObtenerPersonasSinRol()
        {
            var lista = new List<persona_rolM>();

            string query = @"
            SELECT 
    p.per_id, 
    p.primer_nombre, 
    p.primer_apellido, 
    p.cedula
FROM personas p
LEFT JOIN personas_roles pr ON p.per_id = pr.per_id
WHERE pr.per_id IS NULL
  AND p.estado = 1";

            using (var connection = _dbConnection.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new persona_rolM
                        {
                            PerId = (int)reader["per_id"],
                            NombrePersona = $"{reader["primer_nombre"]} {reader["primer_apellido"]}",
                            Cedula = reader["cedula"]?.ToString(),
                            // Los demás campos relacionados con rol estarán vacíos porque no tiene
                        });
                    }
                }
            }

            return lista;
        }


        public List<persona_rolM> ObtenerPersonaRolValidacacion(int per_id)
        {
            var lista = new List<persona_rolM>();

            string query = @"
SELECT pr.id_persona_rol, pr.per_id, pr.rol_id, pr.fecha_asignacion, pr.estado,
       p.primer_nombre, p.primer_apellido, p.cedula, 
       r.nombre, r.descripcion
FROM personas_roles pr
INNER JOIN personas p ON pr.per_id = p.per_id
INNER JOIN roles r ON pr.rol_id = r.rol_id
WHERE pr.per_id = @per_id";

            using (var connection = _dbConnection.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@per_id", per_id);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new persona_rolM
                        {
                            IdPersonaRol = (int)reader["id_persona_rol"],
                            PerId = (int)reader["per_id"],
                            RolId = (int)reader["rol_id"],
                            FechaAsignacion = reader["fecha_asignacion"] as DateTime?,
                            Estado = Convert.ToBoolean(reader["estado"]),
                            NombrePersona = $"{reader["primer_nombre"]} {reader["primer_apellido"]}",
                            Cedula = reader["cedula"]?.ToString(),
                            NombreRol = reader["nombre"]?.ToString(),
                            DescripcionRol = reader["descripcion"]?.ToString()
                        });
                    }
                }
            }

            return lista;
        }


        public void InsertarPersonaRol(persona_rolM personaRol)
        {
            string query = @"
        INSERT INTO personas_roles (per_id, rol_id, fecha_asignacion, estado)
        VALUES (@ThPerId, @IdRol, @FechaAsignacion, @Estado)";

            using (var connection = _dbConnection.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ThPerId", personaRol.PerId);
                command.Parameters.AddWithValue("@IdRol", personaRol.RolId);
                command.Parameters.AddWithValue("@FechaAsignacion", personaRol.FechaAsignacion ?? DateTime.Now);
                command.Parameters.AddWithValue("@Estado", personaRol.Estado);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void ActualizarPersonaRol(persona_rolM personaRol)
        {
            string query = @"
        UPDATE personas_roles
        SET per_id = @PerId,
            rol_id = @RolId
        WHERE id_persona_rol = @IdPersonaRol";

            using (var connection = _dbConnection.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdPersonaRol", personaRol.IdPersonaRol);
                command.Parameters.AddWithValue("@PerId", personaRol.PerId);
                command.Parameters.AddWithValue("@RolId", personaRol.RolId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public void EliminarPersonaRol(int idPersonaRol)
        {
            string query = "DELETE FROM personas_roles WHERE id_persona_rol = @Id";

            using (var connection = _dbConnection.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", idPersonaRol);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }



    }
}
