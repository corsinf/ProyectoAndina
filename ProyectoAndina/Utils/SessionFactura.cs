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

        // 📌 Total calculado
        public static decimal Total => Cantidad * PrecioUnitario;

        // 📌 Método para limpiar datos (si quieres reiniciar entre facturas)
        public static void Limpiar()
        {
            ClienteNombre = string.Empty;
            ClienteRuc = string.Empty;
            Producto = string.Empty;
            Cantidad = 0;
            PrecioUnitario = 0;
        }
    }
}
