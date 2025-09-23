using ProyectoAndina.Data;
using ProyectoAndina.Models;
using ProyectoAndina.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProyectoAndina.Controllers
{
    public class PersonaController
    {
        private readonly DatabaseConnection _dbConnection;

        public PersonaController()
        {
            _dbConnection = new DatabaseConnection();
        }

        // INSERTAR
        public bool Insertar(PersonaM persona)
        {
            using var connection = _dbConnection.GetConnection();
            string query = @"
                INSERT INTO personas
                (primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, cedula,
                 estado_civil, sexo, fecha_nacimiento, nacionalidad, telefono_1, telefono_2,
                 correo, direccion, foto_url, prov_id, ciu_id, parr_id, postal, observaciones,
                 estado, fecha_creacion, password)
                VALUES
                (@primer_nombre, @segundo_nombre, @primer_apellido, @segundo_apellido, @cedula,
                 @estado_civil, @sexo, @fecha_nacimiento, @nacionalidad, @telefono_1, @telefono_2,
                 @correo, @direccion, @foto_url, @prov_id, @ciu_id, @parr_id, @postal, @observaciones,
                 @estado, GETDATE(), @password)";

            using var cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@primer_nombre", persona.primer_nombre ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@segundo_nombre", persona.segundo_nombre ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@primer_apellido", persona.primer_apellido ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@segundo_apellido", persona.segundo_apellido ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@cedula", persona.cedula ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@estado_civil", persona.estado_civil ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@sexo", persona.sexo ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@fecha_nacimiento", persona.fecha_nacimiento ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@nacionalidad", persona.nacionalidad ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@telefono_1", persona.telefono_1 ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@telefono_2", persona.telefono_2 ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@correo", persona.correo ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@direccion", persona.direccion ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@foto_url", persona.foto_url ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@prov_id", persona.prov_id ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ciu_id", persona.ciu_id ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@parr_id", persona.parr_id ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@postal", persona.postal ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@observaciones", persona.observaciones ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@estado", persona.estado);
            cmd.Parameters.AddWithValue("@password", persona.password ?? (object)DBNull.Value);

            connection.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        // insertar la persona y sacar su ID

        public int Insertar_ReturnId(PersonaM persona)
        {
            int nuevoId = 0;

            using (var connection = _dbConnection.GetConnection())
            {
                string query = @"
        INSERT INTO personas
        (primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, cedula,
         estado_civil, sexo, fecha_nacimiento, nacionalidad, telefono_1, telefono_2,
         correo, direccion, foto_url, prov_id, ciu_id, parr_id, postal, observaciones,
         estado, fecha_creacion, password)
        VALUES
        (@primer_nombre, @segundo_nombre, @primer_apellido, @segundo_apellido, @cedula,
         @estado_civil, @sexo, @fecha_nacimiento, @nacionalidad, @telefono_1, @telefono_2,
         @correo, @direccion, @foto_url, @prov_id, @ciu_id, @parr_id, @postal, @observaciones,
         @estado, GETDATE(), @password);
        SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@primer_nombre", persona.primer_nombre ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@segundo_nombre", persona.segundo_nombre ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@primer_apellido", persona.primer_apellido ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@segundo_apellido", persona.segundo_apellido ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@cedula", persona.cedula ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@estado_civil", persona.estado_civil ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@sexo", persona.sexo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", persona.fecha_nacimiento ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@nacionalidad", persona.nacionalidad ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@telefono_1", persona.telefono_1 ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@telefono_2", persona.telefono_2 ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@correo", persona.correo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@direccion", persona.direccion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@foto_url", persona.foto_url ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@prov_id", persona.prov_id ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ciu_id", persona.ciu_id ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@parr_id", persona.parr_id ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@postal", persona.postal ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@observaciones", persona.observaciones ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@estado", persona.estado);
                    cmd.Parameters.AddWithValue("@password", persona.password ?? (object)DBNull.Value);

                    connection.Open();
                    nuevoId = (int)cmd.ExecuteScalar(); // aquí recuperas el ID insertado
                }
            }

            return nuevoId;
        }


        // ACTUALIZAR
        public bool Actualizar(PersonaM persona)
        {
            using var connection = _dbConnection.GetConnection();
            string query = @"
                UPDATE personas SET
                    primer_nombre=@primer_nombre,
                    segundo_nombre=@segundo_nombre,
                    primer_apellido=@primer_apellido,
                    segundo_apellido=@segundo_apellido,
                    cedula=@cedula,
                    estado_civil=@estado_civil,
                    sexo=@sexo,
                    fecha_nacimiento=@fecha_nacimiento,
                    nacionalidad=@nacionalidad,
                    telefono_1=@telefono_1,
                    telefono_2=@telefono_2,
                    correo=@correo,
                    direccion=@direccion,
                    foto_url=@foto_url,
                    prov_id=@prov_id,
                    ciu_id=@ciu_id,
                    parr_id=@parr_id,
                    postal=@postal,
                    observaciones=@observaciones,
                    estado=@estado,
                    fecha_modificacion=GETDATE(),
                    password=@password
                WHERE per_id=@per_id";

            using var cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@primer_nombre", persona.primer_nombre ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@segundo_nombre", persona.segundo_nombre ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@primer_apellido", persona.primer_apellido ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@segundo_apellido", persona.segundo_apellido ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@cedula", persona.cedula ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@estado_civil", persona.estado_civil ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@sexo", persona.sexo ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@fecha_nacimiento", persona.fecha_nacimiento ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@nacionalidad", persona.nacionalidad ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@telefono_1", persona.telefono_1 ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@telefono_2", persona.telefono_2 ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@correo", persona.correo ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@direccion", persona.direccion ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@foto_url", persona.foto_url ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@prov_id", persona.prov_id ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ciu_id", persona.ciu_id ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@parr_id", persona.parr_id ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@postal", persona.postal ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@observaciones", persona.observaciones ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@estado", persona.estado);
            cmd.Parameters.AddWithValue("@password", persona.password ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@per_id", persona.per_id);

            connection.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        // ELIMINAR (cambiar estado a false)
        public bool Eliminar(int per_id)
        {
            using var connection = _dbConnection.GetConnection();
            string query = "UPDATE personas SET estado = 0 WHERE per_id=@per_id";

            using var cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@per_id", per_id);

            connection.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        // OBTENER POR ID
        public PersonaM ObtenerPorId(int per_id)
        {
            PersonaM personaEncontrada = null; // Inicializamos como null

            using var connection = _dbConnection.GetConnection();


            string query = "SELECT per_id, primer_nombre, primer_apellido,segundo_nombre, segundo_apellido,telefono_1,fecha_nacimiento, direccion, cedula, correo, password FROM personas WHERE per_id = @per_id";

            using var cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add(new SqlParameter("@per_id", per_id));

            connection.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                personaEncontrada = new PersonaM
                {
                    per_id = Convert.ToInt32(reader["per_id"]),
                    primer_nombre = reader["primer_nombre"].ToString(),
                    primer_apellido = reader["primer_apellido"].ToString(),
                    segundo_nombre = reader["segundo_nombre"].ToString(),
                    segundo_apellido = reader["segundo_apellido"].ToString(),
                    cedula = reader["cedula"].ToString(),
                    correo = reader["correo"].ToString(),
                    password = reader["password"].ToString(),
                    telefono_1 = reader["telefono_1"].ToString(),
                    direccion = reader["direccion"].ToString(),
                    //fecha_nacimiento = Convert.ToDateTime(reader["fecha_nacimiento"])
                };
            }

            return personaEncontrada;
        }


        //buscar por Cedula 

        public PersonaM ObtenerPorCedula(string cedula)
        {
            PersonaM personaEncontrada = null; // Inicializamos como null

            using var connection = _dbConnection.GetConnection();


            string query = "SELECT per_id, primer_nombre, primer_apellido,segundo_nombre, segundo_apellido,telefono_1,fecha_nacimiento, direccion, cedula, correo, password FROM personas WHERE cedula = @cedula";

            using var cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add(new SqlParameter("@cedula", cedula));

            connection.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                personaEncontrada = new PersonaM
                {
                    per_id = Convert.ToInt32(reader["per_id"]),
                    primer_nombre = reader["primer_nombre"].ToString(),
                    primer_apellido = reader["primer_apellido"].ToString(),
                    segundo_nombre = reader["segundo_nombre"].ToString(),
                    segundo_apellido = reader["segundo_apellido"].ToString(),
                    cedula = reader["cedula"].ToString(),
                    correo = reader["correo"].ToString(),
                    password = reader["password"].ToString(),
                    telefono_1 = reader["telefono_1"].ToString(),
                    direccion = reader["direccion"].ToString(),
                };
            }

            return personaEncontrada;
        }

        // OBTENER TODAS
        public List<PersonaM> ObtenerTodas()
        {
            var lista = new List<PersonaM>();
            using var connection = _dbConnection.GetConnection();
            string query = "SELECT * FROM personas";

            using var cmd = new SqlCommand(query, connection)
            {
                CommandText = query
            };

            connection.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(MapearPersona(reader));
            }

            return lista;
        }



        public List<PersonaM> ObtenerPersonasBasicas()
        {
            var lista = new List<PersonaM>();

            using (var connection = _dbConnection.GetConnection())
            {
                string query = @"
            SELECT per_id, primer_nombre, primer_apellido, cedula, correo
            FROM personas";

                using (var cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PersonaM
                            {
                                per_id = Convert.ToInt32(reader["per_id"]),
                                primer_nombre =reader["primer_nombre"].ToString(),
                                cedula = reader["cedula"].ToString(),
                                correo = reader["correo"].ToString()
                            });
                        }
                    }
                }
            }

            return lista;
        }



        //optener el ultimo usuario 

        public PersonaM ObtenerUltima()
        {
            PersonaM persona = null;

            using var connection = _dbConnection.GetConnection();
            string query = @"SELECT TOP 1 
                        per_id, 
                        primer_nombre, 
                        primer_apellido, 
                        segundo_nombre, 
                        segundo_apellido, 
                        telefono_1, 
                        direccion, 
                        cedula, 
                        correo, 
                        password
                     FROM personas 
                     ORDER BY per_id DESC";

            using var cmd = new SqlCommand(query, connection);
            connection.Open();

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                persona = new PersonaM
                {
                    per_id = Convert.ToInt32(reader["per_id"]),
                    primer_nombre = reader["primer_nombre"].ToString(),
                    primer_apellido = reader["primer_apellido"].ToString(),
                    segundo_nombre = reader["segundo_nombre"].ToString(),
                    segundo_apellido = reader["segundo_apellido"].ToString(),
                    cedula = reader["cedula"].ToString(),
                    correo = reader["correo"].ToString(),
                    password = reader["password"].ToString(),
                    telefono_1 = reader["telefono_1"].ToString(),
                    direccion = reader["direccion"].ToString(),
                };
            }

            return persona;
        }


        public PersonaM ValidarUsuario(string correo, string password)
        {
            PersonaM persona = null;

            string query = @"
            SELECT per_id, primer_nombre, primer_apellido, cedula, correo
            FROM personas
            WHERE correo = @correo AND password = @password AND (estado = 1 OR estado IS NULL)";
            // <-- estado = 1 por si manejas activos/inactivos

            using (var connection = _dbConnection.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@correo", correo);
                command.Parameters.AddWithValue("@password", password);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        persona = new PersonaM
                        {
                            per_id = Convert.ToInt32(reader["per_id"]),
                            primer_nombre = $"{reader["primer_nombre"]} {reader["primer_apellido"]}",
                            cedula = reader["cedula"].ToString(),
                            correo = reader["correo"].ToString(),
                            EsValido = true,
                        };
                            
                    }
                }
            }

            return persona;
        }

        public ResultadoPaginado<PersonaM> ObtenerPersonasPaginadas(int pagina = 1, int registrosPorPagina = 20, string filtro = "")
        {
            var resultado = new ResultadoPaginado<PersonaM>
            {
                PaginaActual = pagina,
                RegistrosPorPagina = registrosPorPagina
            };

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                // Obtener total de registros
                string countQuery = @"
            SELECT COUNT(*) 
            FROM personas 
            WHERE estado = 1 AND (@Filtro = '' OR 
                   primer_nombre LIKE '%' + @Filtro + '%' OR 
                   cedula LIKE '%' + @Filtro + '%' OR 
                   correo LIKE '%' + @Filtro + '%')";

                using (var countCmd = new SqlCommand(countQuery, connection))
                {
                    countCmd.Parameters.AddWithValue("@Filtro", filtro ?? "");
                    resultado.TotalRegistros = (int)countCmd.ExecuteScalar();
                }

                // Obtener datos paginados
                string dataQuery = @"
            SELECT per_id, primer_nombre,telefono_1, correo,direccion
            FROM personas
            WHERE estado = 1 AND (@Filtro = '' OR 
                   primer_nombre LIKE '%' + @Filtro + '%' OR 
                   cedula LIKE '%' + @Filtro + '%' OR 
                   correo LIKE '%' + @Filtro + '%')
            ORDER BY primer_nombre
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
                            resultado.Datos.Add(new PersonaM
                            {
                                per_id = Convert.ToInt32(reader["per_id"]),
                                primer_nombre = reader["primer_nombre"]?.ToString(),
                                telefono_1 = reader["telefono_1"].ToString(),
                                correo = reader["correo"]?.ToString(),
                                direccion = reader["direccion"].ToString()

                            });
                        }
                    }
                }
            }

            return resultado;
        }
        //paginado de Arqueo Caja

        public ResultadoPaginado<arqueo_con_persona_rolM> ObtenerArqueosConRolesPaginados(
    int pagina = 1,
    int registrosPorPagina = 20,
    string filtro = "")
        {
            var resultado = new ResultadoPaginado<arqueo_con_persona_rolM>
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
            FROM arqueo_caja ac
            INNER JOIN personas_roles pr ON ac.id_persona_rol = pr.id_persona_rol
            INNER JOIN personas p ON pr.per_id = p.per_id
            INNER JOIN roles r ON pr.rol_id = r.rol_id
            WHERE (@Filtro = '' OR 
                   p.primer_nombre LIKE '%' + @Filtro + '%' OR
                   p.primer_apellido LIKE '%' + @Filtro + '%' OR
                   p.cedula LIKE '%' + @Filtro + '%' OR
                   r.nombre LIKE '%' + @Filtro + '%')";

                using (var countCmd = new SqlCommand(countQuery, connection))
                {
                    countCmd.Parameters.AddWithValue("@Filtro", filtro ?? "");
                    resultado.TotalRegistros = (int)countCmd.ExecuteScalar();
                }

                // --- 2. Consultar datos paginados ---
                string dataQuery = @"
            SELECT 
                ac.arqueo_id,
                ac.caja_id,
                ac.turno,
                ac.fecha_apertura,
                ac.valor_apertura,
                ac.total_transacciones,
                ac.total_efectivo,
                ac.total_transferencia,
                ac.total_tarjeta,
                ac.total_en_caja,
                ac.faltante,
                ac.sobrante,
                ac.estado,          
                p.per_id,
                p.primer_nombre,
                p.segundo_nombre,
                p.primer_apellido,
                p.segundo_apellido,
                p.cedula,
                r.rol_id,
                r.nombre AS nombre_rol
            FROM arqueo_caja ac
            INNER JOIN personas_roles pr ON ac.id_persona_rol = pr.id_persona_rol
            INNER JOIN personas p ON pr.per_id = p.per_id
            INNER JOIN roles r ON pr.rol_id = r.rol_id
            WHERE (@Filtro = '' OR 
                   p.primer_nombre LIKE '%' + @Filtro + '%' OR
                   p.primer_apellido LIKE '%' + @Filtro + '%' OR
                   p.cedula LIKE '%' + @Filtro + '%' OR
                   r.nombre LIKE '%' + @Filtro + '%')
            ORDER BY ac.arqueo_id DESC
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
                            resultado.Datos.Add(new arqueo_con_persona_rolM
                            {
                                arqueo_id = Convert.ToInt32(reader["arqueo_id"]),
                                monto_inicial = Convert.ToDecimal(reader["valor_apertura"]),
                                monto_final = Convert.ToDecimal(reader["total_en_caja"]),
                                estado = reader["estado"].ToString(),
                                per_id = Convert.ToInt32(reader["per_id"]),
                                primer_nombre = reader["primer_nombre"].ToString(),
                                segundo_nombre = reader["segundo_nombre"].ToString(),
                                primer_apellido = reader["primer_apellido"].ToString(),
                                segundo_apellido = reader["segundo_apellido"].ToString(),
                                cedula = reader["cedula"].ToString(),
                                rol_id = reader["rol_id"] != DBNull.Value ? Convert.ToInt32(reader["rol_id"]) : 0,
                                nombre_rol = reader["nombre_rol"].ToString()
                            });
                        }
                    }
                }
            }

            return resultado;
        }



        private PersonaM MapearPersona(SqlDataReader reader)
        {
            return new PersonaM
            {
                per_id = Convert.ToInt32(reader["per_id"]),
                primer_nombre = reader["primer_nombre"].ToString(),
                segundo_nombre = reader["segundo_nombre"].ToString(),
                primer_apellido = reader["primer_apellido"].ToString(),
                segundo_apellido = reader["segundo_apellido"].ToString(),
                cedula = reader["cedula"].ToString(),
                estado_civil = reader["estado_civil"].ToString(),
                sexo = reader["sexo"].ToString(),
                fecha_nacimiento = Convert.ToDateTime(reader["fecha_nacimiento"]),
                nacionalidad = reader["nacionalidad"].ToString(),
                telefono_1 = reader["telefono_1"].ToString(),
                telefono_2 = reader["telefono_2"].ToString(),
                correo = reader["correo"].ToString(),
                direccion = reader["direccion"].ToString(),
                foto_url = reader["foto_url"].ToString(),
                prov_id = Convert.ToInt32(reader["prov_id"]),
                ciu_id = Convert.ToInt32(reader["ciu_id"]),
                parr_id = Convert.ToInt32(reader["parr_id"]),
                postal = reader["postal"].ToString(),
                observaciones = reader["observaciones"].ToString(),
                estado = Convert.ToBoolean(reader["estado"]),
                fecha_creacion = Convert.ToDateTime(reader["fecha_creacion"]),
                fecha_modificacion = Convert.ToDateTime(reader["fecha_modificacion"]),
                password = reader["password"].ToString(),
                EsValido = true
            };
        }


    }
}
