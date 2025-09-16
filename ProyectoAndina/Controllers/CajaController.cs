using ProyectoAndina.Data;
using ProyectoAndina.Models;
using ProyectoAndina.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProyectoAndina.Controllers
{
    public class CajaController
    {
        private readonly DatabaseConnection _dbConnection;

        public CajaController()
        {
            _dbConnection = new DatabaseConnection();
        }

        // INSERTAR
        public void Insertar(CajaM caja)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                string query = @"
                    INSERT INTO caja
                    (codigo, nombre, ubicacion, ip_equipo, estado, fecha_creacion)
                    VALUES
                    (@codigo, @nombre, @ubicacion, @ip_equipo, @estado, @fecha_creacion)";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@codigo", caja.codigo ?? "");
                    cmd.Parameters.AddWithValue("@nombre", caja.nombre ?? "");
                    cmd.Parameters.AddWithValue("@ubicacion", caja.ubicacion ?? "");
                    cmd.Parameters.AddWithValue("@ip_equipo", caja.ip_equipo ?? "");
                    cmd.Parameters.AddWithValue("@estado", caja.estado);
                    cmd.Parameters.AddWithValue("@fecha_creacion", caja.fecha_creacion);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ACTUALIZAR
        public void Actualizar(CajaM caja)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                string query = @"
                    UPDATE caja SET
                        codigo = @codigo,
                        nombre = @nombre,
                        ubicacion = @ubicacion,
                        ip_equipo = @ip_equipo,
                        estado = @estado,
                        fecha_creacion = @fecha_creacion
                    WHERE caja_id = @caja_id";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@caja_id", caja.caja_id);
                    cmd.Parameters.AddWithValue("@codigo", caja.codigo ?? "");
                    cmd.Parameters.AddWithValue("@nombre", caja.nombre ?? "");
                    cmd.Parameters.AddWithValue("@ubicacion", caja.ubicacion ?? "");
                    cmd.Parameters.AddWithValue("@ip_equipo", caja.ip_equipo ?? "");
                    cmd.Parameters.AddWithValue("@estado", caja.estado);
                    cmd.Parameters.AddWithValue("@fecha_creacion", caja.fecha_creacion);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ELIMINAR (cambiar estado a false)
        public void Eliminar(int caja_id)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                string query = "UPDATE caja SET estado = 0 WHERE caja_id = @caja_id";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@caja_id", caja_id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // OBTENER TODAS
        public List<CajaM> ObtenerTodas()
        {
            var lista = new List<CajaM>();

            using (var connection = _dbConnection.GetConnection())
            {
                string query = "SELECT * FROM caja where estado = 1";

                using (var cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(MapearCaja(reader));
                        }
                    }
                }
            }

            return lista;
        }

        public ResultadoPaginado<CajaM> ObtenerCajasPaginadas(
    int pagina = 1,
    int registrosPorPagina = 20,
    string filtro = "")
        {
            var resultado = new ResultadoPaginado<CajaM>
            {
                PaginaActual = pagina,
                RegistrosPorPagina = registrosPorPagina
            };

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                // 1. Contar total de registros
                string countQuery = @"
        SELECT COUNT(*)
        FROM caja
        WHERE estado = 1
          AND (@Filtro = '' OR 
               codigo LIKE '%' + @Filtro + '%' OR
               nombre LIKE '%' + @Filtro + '%' OR
               ubicacion LIKE '%' + @Filtro + '%' OR
               ip_equipo LIKE '%' + @Filtro + '%')";

                using (var countCmd = new SqlCommand(countQuery, connection))
                {
                    countCmd.Parameters.AddWithValue("@Filtro", filtro ?? "");
                    resultado.TotalRegistros = (int)countCmd.ExecuteScalar();
                }

                // 2. Obtener datos paginados
                string dataQuery = @"
        SELECT caja_id, codigo, nombre, ubicacion, ip_equipo, estado, fecha_creacion
        FROM caja
        WHERE estado = 1
          AND (@Filtro = '' OR 
               codigo LIKE '%' + @Filtro + '%' OR
               nombre LIKE '%' + @Filtro + '%' OR
               ubicacion LIKE '%' + @Filtro + '%' OR
               ip_equipo LIKE '%' + @Filtro + '%')
        ORDER BY nombre
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
                            resultado.Datos.Add(MapearCaja(reader));
                        }
                    }
                }
            }

            return resultado;
        }


        // OBTENER POR ID
        public CajaM ObtenerPorId(int caja_id)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                string query = "SELECT * FROM caja WHERE caja_id = @caja_id";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@caja_id", caja_id);
                    connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapearCaja(reader);
                        }
                    }
                }
            }

            return null;
        }



        public CajaM ObtenerPorcodigo(string codigo )
        {
            using (var connection = _dbConnection.GetConnection())
            {
                string query = "SELECT * FROM caja WHERE codigo = @codigo";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapearCaja(reader);
                        }
                    }
                }
            }

            return null;
        }

        //Obtener cajas disponibles 
        public List<CajaM> obtener_cajas_cerradas()
        {
            var lista = new List<CajaM>();

            using (var connection = _dbConnection.GetConnection())
            {
                string query = @"
            SELECT c.*
            FROM caja c
            LEFT JOIN arqueo_caja a 
                ON c.caja_id = a.caja_id AND a.estado = 'A'
            WHERE a.arqueo_id IS NULL AND c.estado = 1"; // Solo cajas que NO tengan arqueo abierto

                using (var cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(MapearCaja(reader));
                        }
                    }
                }
            }

            return lista;
        }


        // MAPEAR LECTOR A MODELO
        private CajaM MapearCaja(SqlDataReader reader)
        {
            return new CajaM
            {
                caja_id = Convert.ToInt32(reader["caja_id"]),
                codigo = reader["codigo"].ToString(),
                nombre = reader["nombre"].ToString(),
                ubicacion = reader["ubicacion"].ToString(),
                ip_equipo = reader["ip_equipo"].ToString(),
                estado = Convert.ToBoolean(reader["estado"]),
                fecha_creacion = Convert.ToDateTime(reader["fecha_creacion"])
            };
        }
    }
}
