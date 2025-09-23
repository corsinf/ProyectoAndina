// Data/DatabaseConnection.cs
using Newtonsoft.Json;
using ProyectoAndina.Models;
using ProyectoAndina.Utils;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ProyectoAndina.Data
{
    public class DatabaseConnection
    {
        private readonly string _connectionString;

        public DatabaseConnection(AppConfig? config = null)
        {
            if (config == null)
                config = CargarConfiguracion();

            _connectionString = config.DatabaseConfig.GetConnectionString();
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public static AppConfig CargarConfiguracion(string rutaArchivo = "Config/appsettings.json")
        {
            string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rutaArchivo);

            if (!File.Exists(rutaCompleta))
                throw new FileNotFoundException($"No se encontró el archivo de configuración en {rutaCompleta}");

            var json = File.ReadAllText(rutaCompleta);
            return JsonConvert.DeserializeObject<AppConfig>(json)
                   ?? throw new Exception("No se pudo cargar la configuración del JSON");
        }

       

    }
}



