using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAndina.Models
{
    public class persona_rolM
    {
        // Campos principales de la tabla PERSONAS_ROLES
        public int IdPersonaRol { get; set; }
        public int PerId { get; set; }
        public int RolId { get; set; }
        public DateTime? FechaAsignacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public bool Estado { get; set; }

        // Campos adicionales del INNER JOIN con th_personas y roles
        public string NombrePersona { get; set; }
        public string Cedula { get; set; }
        public string NombreRol { get; set; }
        public string DescripcionRol { get; set; }
    }
}

