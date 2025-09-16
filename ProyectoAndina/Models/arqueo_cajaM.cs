using System;

namespace ProyectoAndina.Models
{
    public class arqueo_cajaM
    {
        public int arqueo_id { get; set; }
        public int caja_id { get; set; }
        public int id_persona_rol { get; set; }
        public string turno { get; set; }
        public DateTime fecha_apertura { get; set; }
        public decimal valor_apertura { get; set; }
        public DateTime hora_cierre { get; set; }
        public decimal total_transacciones { get; set; }
        public decimal total_efectivo { get; set; }
        public decimal total_transferencia { get; set; }
        public decimal total_tarjeta { get; set; }
        public decimal total_en_caja { get; set; }
        public decimal faltante { get; set; }
        public decimal sobrante { get; set; }
        public string observaciones { get; set; }
        public string estado { get; set; }
        public string pinpad_lote { get; set; }
        public string pinpad_referencia { get; set; }
    }
}
