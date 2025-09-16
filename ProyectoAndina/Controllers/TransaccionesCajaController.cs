using ProyectoAndina.Data;
using ProyectoAndina.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProyectoAndina.Controllers
{
    public class TransaccionCajaController
    {
        private readonly DatabaseConnection _dbConnection;

        public TransaccionCajaController()
        {
            _dbConnection = new DatabaseConnection();
        }

        // INSERTAR
        public void Insertar(TransaccionCajaM transaccion)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                string query = @"
                    INSERT INTO transaccion_caja
                    (arqueo_id, per_id_cliente, fecha_transaccion, valor_a_cobrar, valor_entregado, 
                      tipo_pago_id, descripcion, placa)
                    VALUES
                    (@arqueo_id, @per_id_cliente, @fecha_transaccion, @valor_a_cobrar, @valor_entregado, 
                     @tipo_pago_id, @descripcion, @placa)";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@arqueo_id", transaccion.arqueo_id);
                    cmd.Parameters.AddWithValue("@per_id_cliente", transaccion.per_id_cliente);
                    cmd.Parameters.AddWithValue("@fecha_transaccion", transaccion.fecha_transaccion);
                    cmd.Parameters.AddWithValue("@valor_a_cobrar", transaccion.valor_a_cobrar);
                    cmd.Parameters.AddWithValue("@valor_entregado", transaccion.valor_entregado);
                    cmd.Parameters.AddWithValue("@tipo_pago_id", transaccion.tipo_pago_id);
                    cmd.Parameters.AddWithValue("@descripcion", transaccion.descripcion ?? "");
                    cmd.Parameters.AddWithValue("@placa", transaccion.placa ?? "");

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ACTUALIZAR
        public void Actualizar(TransaccionCajaM transaccion)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                string query = @"
                    UPDATE transaccion_caja SET
                        arqueo_id = @arqueo_id,
                        per_id_cliente = @per_id_cliente,
                        fecha_transaccion = @fecha_transaccion,
                        valor_a_cobrar = @valor_a_cobrar,
                        valor_entregado = @valor_entregado,
                        valor_cambio = @valor_cambio,
                        tipo_pago_id = @tipo_pago_id,
                        descripcion = @descripcion,
                        placa = @placa
                    WHERE trans_id = @trans_id";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@trans_id", transaccion.trans_id);
                    cmd.Parameters.AddWithValue("@arqueo_id", transaccion.arqueo_id);
                    cmd.Parameters.AddWithValue("@per_id_cliente", transaccion.per_id_cliente);
                    cmd.Parameters.AddWithValue("@fecha_transaccion", transaccion.fecha_transaccion);
                    cmd.Parameters.AddWithValue("@valor_a_cobrar", transaccion.valor_a_cobrar);
                    cmd.Parameters.AddWithValue("@valor_entregado", transaccion.valor_entregado);
                    cmd.Parameters.AddWithValue("@valor_cambio", transaccion.valor_cambio);
                    cmd.Parameters.AddWithValue("@tipo_pago_id", transaccion.tipo_pago_id);
                    cmd.Parameters.AddWithValue("@descripcion", transaccion.descripcion ?? "");
                    cmd.Parameters.AddWithValue("@placa", transaccion.placa ?? "");

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ELIMINAR (borrado físico, si quieres lógico cámbialo)
        public void Eliminar(int trans_id)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                string query = "DELETE FROM transaccion_caja WHERE trans_id = @trans_id";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@trans_id", trans_id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // OBTENER TODAS
        public List<TransaccionCajaM> ObtenerTodas()
        {
            var lista = new List<TransaccionCajaM>();

            using (var connection = _dbConnection.GetConnection())
            {
                string query = "SELECT * FROM transaccion_caja";

                using (var cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(MapearTransaccion(reader));
                        }
                    }
                }
            }

            return lista;
        }

        // OBTENER POR ID
        public TransaccionCajaM ObtenerPorId(int trans_id)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                string query = "SELECT * FROM transaccion_caja WHERE trans_id = @trans_id";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@trans_id", trans_id);
                    connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapearTransaccion(reader);
                        }
                    }
                }
            }

            return null;
        }

        //sacar todas las transacciones

        public (int totalTransacciones, decimal totalACobrar) ObtenerResumenPorArqueo(int arqueoId)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                string query = @"
            SELECT 
                COUNT(*) AS total_transacciones,
                ISNULL(SUM(valor_a_cobrar), 0) AS total_a_cobrar
            FROM transaccion_caja
            WHERE arqueo_id = @arqueo_id";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@arqueo_id", arqueoId);
                    connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int totalTransacciones = reader.GetInt32(reader.GetOrdinal("total_transacciones"));
                            decimal totalACobrar = reader.GetDecimal(reader.GetOrdinal("total_a_cobrar"));
                            return (totalTransacciones, totalACobrar);
                        }
                    }
                }
            }

            return (0, 0m);
        }

        // MAPEAR LECTOR A MODELO
        private TransaccionCajaM MapearTransaccion(SqlDataReader reader)
        {
            return new TransaccionCajaM
            {
                trans_id = Convert.ToInt32(reader["trans_id"]),
                arqueo_id = Convert.ToInt32(reader["arqueo_id"]),
                per_id_cliente = Convert.ToInt32(reader["per_id_cliente"]),
                fecha_transaccion = Convert.ToDateTime(reader["fecha_transaccion"]),
                valor_a_cobrar = Convert.ToDecimal(reader["valor_a_cobrar"]),
                valor_entregado = Convert.ToDecimal(reader["valor_entregado"]),
                valor_cambio = Convert.ToDecimal(reader["valor_cambio"]),
                tipo_pago_id = Convert.ToInt32(reader["tipo_pago_id"]),
                descripcion = reader["descripcion"].ToString(),
                placa = reader["placa"].ToString()
            };
        }
    }
}
