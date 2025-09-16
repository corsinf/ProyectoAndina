using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAndina.Models
{
    public class arqueo_con_persona_rolM
    {
        public int arqueo_id { get; set; }
        public decimal monto_inicial { get; set; }
        public decimal monto_final { get; set; }

        public int per_id { get; set; }
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string cedula { get; set; }

        public int? rol_id { get; set; }
        public string nombre_rol { get; set; }

        public string estado { get; set; }
    }
}
