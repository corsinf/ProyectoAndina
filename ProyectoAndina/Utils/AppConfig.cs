using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace ProyectoAndina.Utils
    {
        public class AppConfig
        {
            public ApiConfig ApiConfig { get; set; }
            public PrinterConfig PrinterConfig { get; set; }
            public DatabaseConfig DatabaseConfig { get; set; }
            public SistemConfig SistemConfig { get; set; }
        }

        public class ApiConfig
        {
            public string Url { get; set; }
            public int Puerto { get; set; }
        }

        public class PrinterConfig
        {
            public string Nombre { get; set; }
        }

        public class DatabaseConfig
        {
            public string Server { get; set; }
            public int Port { get; set; }
            public string Database { get; set; }
            public string User { get; set; }
            public string Password { get; set; }

            public string GetConnectionString()
            {
                return $"Server={Server},{Port};Database={Database};User Id={User};Password={Password};TrustServerCertificate=True;";
            }
        }

        public class SistemConfig
        {
            public int Caja { get; set; }
        }
    }

