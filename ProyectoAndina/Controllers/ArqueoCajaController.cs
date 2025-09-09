using ProyectoAndina.Data;
using ProyectoAndina.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoAndina.Controllers
{
    public class ArqueoCajaController
    {
        private readonly DatabaseConnection _dbConnection;

        public ArqueoCajaController()
        {
            _dbConnection = new DatabaseConnection();
        }

        // INSERTAR
        public void Insertar(arqueo_cajaM arqueo)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                string query = @"
                    INSERT INTO arqueo_caja
                    (caja_id, id_persona_rol, turno, fecha_apertura, valor_apertura, hora_cierre,
                     total_transacciones, total_efectivo, total_transferencia, total_tarjeta, total_en_caja,
                     faltante, sobrante, observaciones, estado, pinpad_lote, pinpad_referencia)
                    VALUES
                    (@caja_id, @id_persona_rol, @turno, @fecha_apertura, @valor_apertura, @hora_cierre,
                     @total_transacciones, @total_efectivo, @total_transferencia, @total_tarjeta, @total_en_caja,
                     @faltante, @sobrante, @observaciones, @estado, @pinpad_lote, @pinpad_referencia)";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@caja_id", arqueo.caja_id);
                    cmd.Parameters.AddWithValue("@id_persona_rol", arqueo.id_persona_rol);
                    cmd.Parameters.AddWithValue("@turno", arqueo.turno ?? "");
                    cmd.Parameters.AddWithValue("@fecha_apertura", arqueo.fecha_apertura);
                    cmd.Parameters.AddWithValue("@valor_apertura", arqueo.valor_apertura);
                    cmd.Parameters.AddWithValue("@hora_cierre",arqueo.hora_cierre);
                    cmd.Parameters.AddWithValue("@total_transacciones", arqueo.total_transacciones);
                    cmd.Parameters.AddWithValue("@total_efectivo", arqueo.total_efectivo);
                    cmd.Parameters.AddWithValue("@total_transferencia", arqueo.total_transferencia);
                    cmd.Parameters.AddWithValue("@total_tarjeta", arqueo.total_tarjeta);
                    cmd.Parameters.AddWithValue("@total_en_caja", arqueo.total_en_caja);
                    cmd.Parameters.AddWithValue("@faltante", arqueo.faltante);
                    cmd.Parameters.AddWithValue("@sobrante", arqueo.sobrante);
                    cmd.Parameters.AddWithValue("@observaciones", arqueo.observaciones ?? "");
                    cmd.Parameters.AddWithValue("@estado", arqueo.estado);
                    cmd.Parameters.AddWithValue("@pinpad_lote", arqueo.pinpad_lote ?? "");
                    cmd.Parameters.AddWithValue("@pinpad_referencia", arqueo.pinpad_referencia ?? "");

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        //insertar y sacar el id
        public int Insertar_ReturnId(arqueo_cajaM arqueo)
        {
            int nuevoId = 0;

            using (var connection = _dbConnection.GetConnection())
            {
                string query = @"
            INSERT INTO arqueo_caja
            (caja_id, id_persona_rol, turno, fecha_apertura, valor_apertura, hora_cierre,
             total_transacciones, total_efectivo, total_transferencia, total_tarjeta, total_en_caja,
             faltante, sobrante, observaciones, estado, pinpad_lote, pinpad_referencia)
            VALUES
            (@caja_id, @id_persona_rol, @turno, @fecha_apertura, @valor_apertura, @hora_cierre,
             @total_transacciones, @total_efectivo, @total_transferencia, @total_tarjeta, @total_en_caja,
             @faltante, @sobrante, @observaciones, @estado, @pinpad_lote, @pinpad_referencia);
            SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@caja_id", arqueo.caja_id);
                    cmd.Parameters.AddWithValue("@id_persona_rol", arqueo.id_persona_rol);
                    cmd.Parameters.AddWithValue("@turno", arqueo.turno ?? "");
                    cmd.Parameters.AddWithValue("@fecha_apertura", arqueo.fecha_apertura);
                    cmd.Parameters.AddWithValue("@valor_apertura", arqueo.valor_apertura);
                    cmd.Parameters.AddWithValue("@hora_cierre", arqueo.hora_cierre);
                    cmd.Parameters.AddWithValue("@total_transacciones", arqueo.total_transacciones);
                    cmd.Parameters.AddWithValue("@total_efectivo", arqueo.total_efectivo);
                    cmd.Parameters.AddWithValue("@total_transferencia", arqueo.total_transferencia);
                    cmd.Parameters.AddWithValue("@total_tarjeta", arqueo.total_tarjeta);
                    cmd.Parameters.AddWithValue("@total_en_caja", arqueo.total_en_caja);
                    cmd.Parameters.AddWithValue("@faltante", arqueo.faltante);
                    cmd.Parameters.AddWithValue("@sobrante", arqueo.sobrante);
                    cmd.Parameters.AddWithValue("@observaciones", arqueo.observaciones ?? "");
                    cmd.Parameters.AddWithValue("@estado", arqueo.estado);
                    cmd.Parameters.AddWithValue("@pinpad_lote", arqueo.pinpad_lote ?? "");
                    cmd.Parameters.AddWithValue("@pinpad_referencia", arqueo.pinpad_referencia ?? "");

                    connection.Open();
                    // ExecuteScalar devuelve el primer valor de la primera fila: el nuevo ID
                    nuevoId = (int)cmd.ExecuteScalar();
                }
            }

            // Retornar el ID generado
            return nuevoId;
        }

        // ACTUALIZAR
        public void Actualizar(arqueo_cajaM arqueo)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                string query = @"
        UPDATE arqueo_caja SET
            id_persona_rol = @id_persona_rol,
            hora_cierre = @hora_cierre,
            total_transacciones = @total_transacciones,
            total_efectivo = @total_efectivo,
            total_transferencia = @total_transferencia,
            total_tarjeta = @total_tarjeta,
            total_en_caja = @total_en_caja,
            faltante = @faltante,
            sobrante = @sobrante,
            observaciones = @observaciones,
            estado = @estado,
            pinpad_lote = @pinpad_lote,
            pinpad_referencia = @pinpad_referencia
        WHERE arqueo_id = @arqueo_id";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@arqueo_id", arqueo.arqueo_id);
                    cmd.Parameters.AddWithValue("@id_persona_rol", arqueo.id_persona_rol);
                    cmd.Parameters.AddWithValue("@hora_cierre", arqueo.hora_cierre);
                    cmd.Parameters.AddWithValue("@total_transacciones", arqueo.total_transacciones);
                    cmd.Parameters.AddWithValue("@total_efectivo", arqueo.total_efectivo);
                    cmd.Parameters.AddWithValue("@total_transferencia", arqueo.total_transferencia);
                    cmd.Parameters.AddWithValue("@total_tarjeta", arqueo.total_tarjeta);
                    cmd.Parameters.AddWithValue("@total_en_caja", arqueo.total_en_caja);
                    cmd.Parameters.AddWithValue("@faltante", arqueo.faltante);
                    cmd.Parameters.AddWithValue("@sobrante", arqueo.sobrante);
                    cmd.Parameters.AddWithValue("@observaciones", arqueo.observaciones ?? "");
                    cmd.Parameters.AddWithValue("@estado", arqueo.estado);
                    cmd.Parameters.AddWithValue("@pinpad_lote", arqueo.pinpad_lote ?? "");
                    cmd.Parameters.AddWithValue("@pinpad_referencia", arqueo.pinpad_referencia ?? "");

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        //Actualizar el estado a cerrado

        public void ActualizarEstado(int arqueoId, string nuevoEstado)
{
    using (var connection = _dbConnection.GetConnection())
    {
        string query = @"
            UPDATE arqueo_caja
            SET estado = @estado
            WHERE arqueo_id = @arqueo_id";

        using (var cmd = new SqlCommand(query, connection))
        {
            cmd.Parameters.AddWithValue("@estado", nuevoEstado);
            cmd.Parameters.AddWithValue("@arqueo_id", arqueoId);

            connection.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
        public void ActualizarTotalEnCaja(int arqueoId, decimal totalEnCaja)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                string query = @"
            UPDATE arqueo_caja
            SET total_en_caja = @total_en_caja
            WHERE arqueo_id = @arqueo_id";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@total_en_caja", totalEnCaja);
                    cmd.Parameters.AddWithValue("@arqueo_id", arqueoId);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        // ELIMINAR (cambiar estado a 0)
        public void Eliminar(int arqueo_id)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                string query = "UPDATE arqueo_caja SET estado = 0 WHERE arqueo_id = @arqueo_id";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@arqueo_id", arqueo_id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // OBTENER TODAS
        public List<arqueo_cajaM> ObtenerTodas()
        {
            var lista = new List<arqueo_cajaM>();

            using (var connection = _dbConnection.GetConnection())
            {
                string query = "SELECT * FROM arqueo_caja";

                using (var cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(MapearArqueo(reader));
                        }
                    }
                }
            }

            return lista;
        }

        // OBTENER POR ID
        public arqueo_cajaM ObtenerPorId(int arqueo_id)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                string query = "SELECT * FROM arqueo_caja WHERE arqueo_id = @arqueo_id";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@arqueo_id", arqueo_id);
                    connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapearArqueo(reader);
                        }
                    }
                }
            }

            return null;
        }


        //obtener con el id y el estado 

        

        public arqueo_cajaM ObtenerPorArqueoCajaPendiente(int id_persona_rol)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                string query = "SELECT * FROM arqueo_caja WHERE id_persona_rol = @id_persona_rol AND estado = 'A' ";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id_persona_rol", id_persona_rol);
                    connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapearArqueo(reader);
                        }
                    }
                }
            }

            return null;
        }
        //Obtener arqueos con personas

        public List<arqueo_con_persona_rolM> ObtenerArqueosConRoles()
        {
            var lista = new List<arqueo_con_persona_rolM>();

            using (var connection = _dbConnection.GetConnection())
            {
                string query = @"
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
ORDER BY ac.arqueo_id DESC


";

                using (var cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new arqueo_con_persona_rolM
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
                                rol_id = reader["rol_id"] != null ? Convert.ToInt32(reader["rol_id"]) : 0,
                                nombre_rol = reader["nombre_rol"].ToString()
                            });
                        }
                    }
                }
            }

            return lista;
        }




        // MAPEAR LECTOR A MODELO
        private arqueo_cajaM MapearArqueo(SqlDataReader reader)
        {
            return new arqueo_cajaM
            {
                arqueo_id = Convert.ToInt32(reader["arqueo_id"]),
                caja_id = Convert.ToInt32(reader["caja_id"]),
                id_persona_rol = Convert.ToInt32(reader["id_persona_rol"]),
                turno = reader["turno"].ToString(),
                fecha_apertura = Convert.ToDateTime(reader["fecha_apertura"]),
                valor_apertura = Convert.ToDecimal(reader["valor_apertura"]),
                total_transacciones = Convert.ToDecimal(reader["total_transacciones"]),
                total_efectivo = Convert.ToDecimal(reader["total_efectivo"]),
                total_transferencia = Convert.ToDecimal(reader["total_transferencia"]),
                total_tarjeta = Convert.ToDecimal(reader["total_tarjeta"]),
                total_en_caja = Convert.ToDecimal(reader["total_en_caja"]),
                faltante = Convert.ToDecimal(reader["faltante"]),
                sobrante = Convert.ToDecimal(reader["sobrante"]),
                observaciones = reader["observaciones"].ToString(),
                estado = reader["estado"].ToString(),
                pinpad_lote = reader["pinpad_lote"].ToString(),
                pinpad_referencia = reader["pinpad_referencia"].ToString()
            };
        }
    }
}
