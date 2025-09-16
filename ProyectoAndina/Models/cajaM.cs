using System;

namespace ProyectoAndina.Models
{
    public class CajaM
    {
        public int caja_id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string ubicacion { get; set; }
        public string ip_equipo { get; set; }
        public bool estado { get; set; }
        public DateTime fecha_creacion { get; set; }
    }
}