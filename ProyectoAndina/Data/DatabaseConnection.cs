// Data/DatabaseConnection.cs
using ProyectoAndina.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ProyectoAndina.Data
{
    public class DatabaseConnection
    {
        private readonly string _connectionString;

        public DatabaseConnection()
        {
            // Cambia esta cadena de conexión por la tuya
            _connectionString = @"Server=186.4.219.172,1487;Database=DB_ANDINA;User Id=sa;Password=Tango456;";
            // Para SQL Server Authentication:
            // _connectionString = @"Server=tu_servidor;Database=DB_ANDINA;User Id=tu_usuario;Password=tu_password;";
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}



