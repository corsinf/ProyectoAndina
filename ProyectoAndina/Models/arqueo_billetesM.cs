using System;

namespace ProyectoAndina.Models
{
    public class arqueo_billetesM
    {
        public int billete_id { get; set; }
        public int arqueo_id { get; set; }
        public string estado { get; set; }
        public int billetes_100 { get; set; }
        public int billetes_50 { get; set; }
        public int billetes_20 { get; set; }
        public int billetes_10 { get; set; }
        public int billetes_5 { get; set; }
        public int billetes_1 { get; set; }
        public int monedas_1 { get; set; }
        public int centavos_50 { get; set; }
        public int centavos_25 { get; set; }
        public int centavos_10 { get; set; }
        public int centavos_5 { get; set; }
        public int centavos_1 { get; set; }
        public decimal total_contado { get; set; }
    }
}
