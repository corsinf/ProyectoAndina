
using System;

namespace ProyectoAndina.Utils
{
    public static class SessionFactura
    {
        // 📌 Datos del cliente
        public static string ClienteNombre { get; set; }
        public static string ClienteRuc { get; set; }

        // 📌 Datos de la compra
        public static string Producto { get; set; }
        public static int Cantidad { get; set; }
        public static decimal PrecioUnitario { get; set; }

        // 📌 NUEVOS CAMPOS según el ticket real
        public static string NumeroTarjeta { get; set; }  // 364173XXXXX000
        public static string Lote { get; set; }           // 003005
        public static string Referencia { get; set; }     // 000025
        public static DateTime FechaHora { get; set; } = DateTime.Now;

        // 📌 Información del sistema DATAFAST
        public static string SistemaPago { get; set; } = "DATAFAST";

        // 📌 Consumos y tarifas (según imagen)
        public static decimal BaseConsumoTarifa15 { get; set; }
        public static decimal BaseConsumoTarifa0 { get; set; }
        public static decimal SubtotalConsumo { get; set; }
        public static decimal IVA { get; set; }

        // 📌 Total calculado
        public static decimal Total => SubtotalConsumo + IVA;

        // 📌 Indicador si es consumidor final
        public static bool EsConsumidorFinal { get; set; }

        // 📌 Método para limpiar datos
        public static void Limpiar()
        {
            ClienteNombre = string.Empty;
            ClienteRuc = string.Empty;
            Producto = string.Empty;
            Cantidad = 0;
            PrecioUnitario = 0;
            NumeroTarjeta = string.Empty;
            Lote = string.Empty;
            Referencia = string.Empty;
            FechaHora = DateTime.Now;
            SistemaPago = "SISTEMA DE ESCRITORIO";
            BaseConsumoTarifa15 = 0;
            BaseConsumoTarifa0 = 0;
            SubtotalConsumo = 0;
            IVA = 0;
            EsConsumidorFinal = false;
        }
    }
}
