using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAndina.Utils
{
    public class AppConfig
    {
        // Configuración de la API
        public string Url { get; set; }
        public int Puerto { get; set; }

        // Configuración de la impresora
        public string Impresora { get; set; }

        // Configuración de la base de datos
        public string Server { get; set; }
        public int Port { get; set; }
        public string Database { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        // Método helper para obtener la cadena de conexión completa
        public string GetConnectionString()
        {
            return $"Server={Server},{Port};Database={Database};User Id={User};Password={Password};";
        }
    }
}
