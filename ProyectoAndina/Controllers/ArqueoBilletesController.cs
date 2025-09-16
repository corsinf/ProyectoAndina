using ProyectoAndina.Data;
using ProyectoAndina.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProyectoAndina.Controllers
{
    public class ArqueoBilletesController
    {
        private readonly DatabaseConnection _dbConnection;

        public ArqueoBilletesController()
        {
            _dbConnection = new DatabaseConnection();
        }

        // INSERTAR
        public void Insertar(arqueo_billetesM billete)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                string query = @"
                    INSERT INTO arqueo_billetes
                    (arqueo_id, estado, billetes_100, billetes_50, billetes_20, billetes_10, billetes_5, billetes_1,
                     monedas_1, centavos_50, centavos_25, centavos_10, centavos_5, centavos_1)
                    VALUES
                    (@arqueo_id, @estado, @billetes_100, @billetes_50, @billetes_20, @billetes_10, @billetes_5, @billetes_1,
                     @monedas_1, @centavos_50, @centavos_25, @centavos_10, @centavos_5, @centavos_1)";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@arqueo_id", billete.arqueo_id);
                    cmd.Parameters.AddWithValue("@estado", billete.estado);
                    cmd.Parameters.AddWithValue("@billetes_100", billete.billetes_100);
                    cmd.Parameters.AddWithValue("@billetes_50", billete.billetes_50);
                    cmd.Parameters.AddWithValue("@billetes_20", billete.billetes_20);
                    cmd.Parameters.AddWithValue("@billetes_10", billete.billetes_10);
                    cmd.Parameters.AddWithValue("@billetes_5", billete.billetes_5);
                    cmd.Parameters.AddWithValue("@billetes_1", billete.billetes_1);
                    cmd.Parameters.AddWithValue("@monedas_1", billete.monedas_1);
                    cmd.Parameters.AddWithValue("@centavos_50", billete.centavos_50);
                    cmd.Parameters.AddWithValue("@centavos_25", billete.centavos_25);
                    cmd.Parameters.AddWithValue("@centavos_10", billete.centavos_10);
                    cmd.Parameters.AddWithValue("@centavos_5", billete.centavos_5);
                    cmd.Parameters.AddWithValue("@centavos_1", billete.centavos_1);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public arqueo_billetesM ObtenerPorIdEstado(int arqueo_id, string estado)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                string query = "SELECT * FROM arqueo_billetes WHERE arqueo_id = @arqueo_id AND estado = @estado";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@arqueo_id", arqueo_id);
                    cmd.Parameters.AddWithValue("@estado", estado);

                    connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapearBillete(reader);
                        }
                    }
                }
            }

            return null;
        }

        // ACTUALIZAR
        public void Actualizar(arqueo_billetesM billete)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                string query = @"
                    UPDATE arqueo_billetes SET
                        arqueo_id = @arqueo_id,
                        estado = @estado,
                        billetes_100 = @billetes_100,
                        billetes_50 = @billetes_50,
                        billetes_20 = @billetes_20,
                        billetes_10 = @billetes_10,
                        billetes_5 = @billetes_5,
                        billetes_1 = @billetes_1,
                        monedas_1 = @monedas_1,
                        centavos_50 = @centavos_50,
                        centavos_25 = @centavos_25,
                        centavos_10 = @centavos_10,
                        centavos_5 = @centavos_5,
                        centavos_1 = @centavos_1,
                        total_contado = @total_contado
                    WHERE billete_id = @billete_id";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@billete_id", billete.billete_id);
                    cmd.Parameters.AddWithValue("@arqueo_id", billete.arqueo_id);
                    cmd.Parameters.AddWithValue("@estado", billete.estado);
                    cmd.Parameters.AddWithValue("@billetes_100", billete.billetes_100);
                    cmd.Parameters.AddWithValue("@billetes_50", billete.billetes_50);
                    cmd.Parameters.AddWithValue("@billetes_20", billete.billetes_20);
                    cmd.Parameters.AddWithValue("@billetes_10", billete.billetes_10);
                    cmd.Parameters.AddWithValue("@billetes_5", billete.billetes_5);
                    cmd.Parameters.AddWithValue("@billetes_1", billete.billetes_1);
                    cmd.Parameters.AddWithValue("@monedas_1", billete.monedas_1);
                    cmd.Parameters.AddWithValue("@centavos_50", billete.centavos_50);
                    cmd.Parameters.AddWithValue("@centavos_25", billete.centavos_25);
                    cmd.Parameters.AddWithValue("@centavos_10", billete.centavos_10);
                    cmd.Parameters.AddWithValue("@centavos_5", billete.centavos_5);
                    cmd.Parameters.AddWithValue("@centavos_1", billete.centavos_1);
                    cmd.Parameters.AddWithValue("@total_contado", billete.total_contado);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ELIMINAR (cambiar estado a false)
        public void Eliminar(int billete_id)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                string query = "UPDATE arqueo_billetes SET estado = 0 WHERE billete_id = @billete_id";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@billete_id", billete_id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // OBTENER TODAS
        public List<arqueo_billetesM> ObtenerTodas()
        {
            var lista = new List<arqueo_billetesM>();

            using (var connection = _dbConnection.GetConnection())
            {
                string query = "SELECT * FROM arqueo_billetes";

                using (var cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(MapearBillete(reader));
                        }
                    }
                }
            }

            return lista;
        }

        // OBTENER POR ID
        public arqueo_billetesM ObtenerPorId(int billete_id)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                string query = "SELECT * FROM arqueo_billetes WHERE billete_id = @billete_id";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@billete_id", billete_id);
                    connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapearBillete(reader);
                        }
                    }
                }
            }

            return null;
        }


        public arqueo_billetesM obtener_arqueo_billetes(int arqueo_id)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                string query = "SELECT * FROM arqueo_billetes WHERE arqueo_id = @arqueo_id";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@arqueo_id", arqueo_id);
                    connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapearBillete(reader);
                        }
                    }
                }
            }

            return null;
        }

        public arqueo_billetesM obtener_arqueo_billetes_apertura(int arqueo_id)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                string query = "SELECT * FROM arqueo_billetes WHERE arqueo_id = @arqueo_id";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@arqueo_id", arqueo_id);
                    connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapearBillete(reader);
                        }
                    }
                }
            }

            return null;
        }

        // MAPEAR LECTOR A MODELO
        private arqueo_billetesM MapearBillete(SqlDataReader reader)
        {
            return new arqueo_billetesM
            {
                billete_id = Convert.ToInt32(reader["billete_id"]),
                arqueo_id = Convert.ToInt32(reader["arqueo_id"]),
                estado = reader["estado"].ToString(),
                billetes_100 = Convert.ToInt32(reader["billetes_100"]),
                billetes_50 = Convert.ToInt32(reader["billetes_50"]),
                billetes_20 = Convert.ToInt32(reader["billetes_20"]),
                billetes_10 = Convert.ToInt32(reader["billetes_10"]),
                billetes_5 = Convert.ToInt32(reader["billetes_5"]),
                billetes_1 = Convert.ToInt32(reader["billetes_1"]),
                monedas_1 = Convert.ToInt32(reader["monedas_1"]),
                centavos_50 = Convert.ToInt32(reader["centavos_50"]),
                centavos_25 = Convert.ToInt32(reader["centavos_25"]),
                centavos_10 = Convert.ToInt32(reader["centavos_10"]),
                centavos_5 = Convert.ToInt32(reader["centavos_5"]),
                centavos_1 = Convert.ToInt32(reader["centavos_1"]),
                total_contado = Convert.ToDecimal(reader["total_contado"])
            };
        }
    }
}
