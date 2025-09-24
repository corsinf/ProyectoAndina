using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAndina.Utils
{
   
        public static class SessionUser
        {
            public static int PerId { get; set; }
            public static int id_persona_rol { get; set; }
            public static string NombreCompleto { get; set; }
            public static string Correo { get; set; }
            public static string Rol { get; set; }

             public static string Mac { get; set; }

        // Agrega más campos si lo necesitas, como:
        public static bool EsAdmin { get; set; }
        }
}
