using System;

namespace ProyectoAndina.Models
{
    public class TransaccionCajaM
    {
        public int trans_id { get; set; }
        public int arqueo_id { get; set; }
        public int per_id_cliente { get; set; }
        public DateTime fecha_transaccion { get; set; }
        public decimal valor_a_cobrar { get; set; }
        public decimal valor_entregado { get; set; }
        public decimal valor_cambio { get; set; }
        public int tipo_pago_id { get; set; }
        public string descripcion { get; set; }
        public string placa { get; set; }
    }
}

