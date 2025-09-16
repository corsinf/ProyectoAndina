namespace ProyectoAndina.Models
{
    public class PersonaApiM
    {
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string cedula { get; set; }
        public string estado_civil { get; set; }
        public string sexo { get; set; }
        public DateTime? fecha_nacimiento { get; set; }
        public string nacionalidad { get; set; }
        public string telefono_1 { get; set; }
        public string telefono_2 { get; set; }
        public string correo { get; set; }
        public string direccion { get; set; }
        public string foto_url { get; set; }
        public int? prov_id { get; set; }
        public int? ciu_id { get; set; }
        public int? parr_id { get; set; }
        public string postal { get; set; }
        public string observaciones { get; set; }
        public string password { get; set; }
    }
}
