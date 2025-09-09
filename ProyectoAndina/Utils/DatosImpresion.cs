using System;
using System.Text;

namespace ProyectoAndina.Utils
{
    internal class DatosImpresion
    {
        // 🎯 Comandos ESC/POS optimizados
        private const string ESC = "\x1B";
        private const string GS = "\x1D";

        // Comandos básicos
        private readonly string INIT = ESC + "@";          // Inicializar impresora
        private readonly string BOLD_ON = ESC + "E\x01";   // Negrita ON
        private readonly string BOLD_OFF = ESC + "E\x00";  // Negrita OFF
        private readonly string CENTER = ESC + "a\x01";    // Centrar
        private readonly string LEFT = ESC + "a\x00";      // Alinear izquierda
        private readonly string SMALL_FONT = ESC + "!\x00"; // Fuente normal
        private readonly string NORMAL_FONT = ESC + "!\x00"; // Fuente normal

        // 🔥 COMANDO OPTIMIZADO PARA CORTE SIN DESPERDICIO
        private readonly string CUT_PARTIAL = GS + "V\x01"; // Corte parcial (más eficiente)
        private readonly string FEED_MINIMAL = "\n\n";      // Solo 2 líneas en blanco mínimas

        public void ImprimirConsumidorFinal()
        {
            string printerName = "SAT 22TUE";

            StringBuilder ticket = new StringBuilder();

            // 🚀 Inicialización
            ticket.Append(INIT);

            // 🏫 Encabezado
            ticket.Append(CENTER + BOLD_ON);
            ticket.AppendLine("UNIVERSIDAD ANDINA SIMON BOLIVAR");
            ticket.Append(BOLD_OFF);

            // 📋 Datos de contacto (más compactos)
            ticket.Append(SMALL_FONT);
            ticket.AppendLine("RUC 1791233417001");
            ticket.AppendLine("Telefono Quito 1701143 Ecuador");
            ticket.AppendLine("+593 86 307 2166");
            ticket.AppendLine("Quito - Ecuador");

            // 🎯 DINERS CLUB
            ticket.Append(NORMAL_FONT + BOLD_ON);
            ticket.AppendLine("\nDINERS CLUB");
            ticket.Append(BOLD_OFF);

            // 🏷️ Sistema de pago
            ticket.Append(CENTER + BOLD_ON);
            ticket.AppendLine($"{SessionFactura.SistemaPago ?? "DATAFAST"}");
            ticket.Append(BOLD_OFF + LEFT);

            // 💰 Desglose financiero
            ticket.Append(SMALL_FONT);
            ticket.AppendLine($"BASE CONSUMO TARIFA 15    US$ {SessionFactura.BaseConsumoTarifa15:F2}");
            ticket.AppendLine($"BASE CONSUMO TARIFA 0     US$ {SessionFactura.BaseConsumoTarifa0:F2}");
            ticket.AppendLine($"SUBTOTAL CONSUMO          US$ {SessionFactura.SubtotalConsumo:F2}");
            ticket.AppendLine($"IVA                       US$ {SessionFactura.IVA:F2}");

            // 📊 Total
            ticket.Append(NORMAL_FONT + BOLD_ON);
            ticket.AppendLine($"VR TOTAL    US$           {SessionFactura.Total:F2}");
            ticket.Append(BOLD_OFF);

            // 🙏 Agradecimiento
            ticket.Append(CENTER + SMALL_FONT);
            ticket.AppendLine("\n...Gracias por su compra!");

            // ✂️ CORTE OPTIMIZADO - Solo las líneas necesarias
            ticket.Append(FEED_MINIMAL);  // Mínimo espacio antes del corte
            ticket.Append(CUT_PARTIAL);   // Corte parcial para ahorrar papel

            RawPrinterHelper.SendStringToPrinter(printerName, ticket.ToString());
        }

        public void ImprimirFacturaCliente()
        {
            string printerName = "SAT 22TUE";

            StringBuilder ticket = new StringBuilder();

            // 🚀 Inicialización
            ticket.Append(INIT);

            // 🏫 Encabezado
            ticket.Append(CENTER + BOLD_ON);
            ticket.AppendLine("UNIVERSIDAD ANDINA SIMON BOLIVAR");
            ticket.Append(BOLD_OFF);

            // 📋 Datos de contacto
            ticket.Append(SMALL_FONT);
            ticket.AppendLine("RUC 1791233417001");
            ticket.AppendLine("Telefono Quito 1701143 Ecuador");
            ticket.AppendLine("+593 86 307 2166");
            ticket.AppendLine("Quito - Ecuador");

            // 🎯 DINERS CLUB
            ticket.Append(NORMAL_FONT + BOLD_ON);
            ticket.AppendLine("\nDINERS CLUB");
            ticket.Append(BOLD_OFF + LEFT);

            // 💳 Información de tarjeta (si existe)
            if (!string.IsNullOrEmpty(SessionFactura.NumeroTarjeta))
            {
                ticket.Append(SMALL_FONT);
                ticket.AppendLine($"TARJETA    {SessionFactura.NumeroTarjeta}");
                ticket.AppendLine($"LOTE#      {SessionFactura.Lote}          REF {SessionFactura.Referencia}");
                ticket.AppendLine($"FECHA      {SessionFactura.FechaHora:dd/MM/yy}         HORA {SessionFactura.FechaHora:HH:mm}");
            }

            // 🏷️ Sistema de pago
            ticket.Append(CENTER + BOLD_ON);
            ticket.AppendLine($"{SessionFactura.SistemaPago ?? "DATAFAST"}");
            ticket.Append(BOLD_OFF + LEFT);

            // 💰 Desglose financiero
            ticket.Append(SMALL_FONT);
            ticket.AppendLine($"BASE CONSUMO TARIFA 15    US$ {SessionFactura.BaseConsumoTarifa15:F2}");
            ticket.AppendLine($"BASE CONSUMO TARIFA 0     US$ {SessionFactura.BaseConsumoTarifa0:F2}");
            ticket.AppendLine($"SUBTOTAL CONSUMO          US$ {SessionFactura.SubtotalConsumo:F2}");
            ticket.AppendLine($"IVA                       US$ {SessionFactura.IVA:F2}");

            // 📊 Total
            ticket.Append(NORMAL_FONT + BOLD_ON);
            ticket.AppendLine($"VR TOTAL    US$           {SessionFactura.Total:F2}");
            ticket.Append(BOLD_OFF);

            // 🙏 Agradecimiento
            ticket.Append(CENTER + SMALL_FONT);
            ticket.AppendLine("\n...Gracias por su compra!");

            // ✂️ CORTE OPTIMIZADO
            ticket.Append(FEED_MINIMAL);
            ticket.Append(CUT_PARTIAL);

            RawPrinterHelper.SendStringToPrinter(printerName, ticket.ToString());
        }

        // 🎯 MÉTODO UNIFICADO QUE REPLICA EL CONTENIDO DEL PDF
        public void ImprimirTicketCompleto()
        {
            string printerName = "SAT 22TUE";
            StringBuilder ticket = new StringBuilder();

            // Inicialización
            ticket.Append(INIT);

            // Encabezado completo como en el PDF
            ticket.Append(CENTER + BOLD_ON);
            ticket.AppendLine("UNIVERSIDAD ANDINA SIMON BOLI"); // Como en el PDF original
            ticket.Append(BOLD_OFF + SMALL_FONT);

            // Datos de contacto exactos del PDF
            ticket.AppendLine("RUC 1791233417001");
            ticket.AppendLine("Telefono Quito 1701143 Ecuador");
            ticket.AppendLine("+593 86 307 2166");
            ticket.AppendLine("Quito - Ecuador");

            // DINERS CLUB
            ticket.Append(NORMAL_FONT + BOLD_ON);
            ticket.AppendLine("\nDINERS CLUB");
            ticket.Append(BOLD_OFF + LEFT + SMALL_FONT);

            // Información de tarjeta solo si NO es consumidor final
            if (!SessionFactura.EsConsumidorFinal && !string.IsNullOrEmpty(SessionFactura.NumeroTarjeta))
            {
                ticket.AppendLine($"TARJETA    {SessionFactura.NumeroTarjeta}");
                ticket.AppendLine($"LOTE#      {SessionFactura.Lote}          REF {SessionFactura.Referencia}");
                ticket.AppendLine($"FECHA      {SessionFactura.FechaHora:dd/MM/yy}         HORA {SessionFactura.FechaHora:HH:mm}");
            }

            // Sistema de pago centrado
            ticket.Append(CENTER + NORMAL_FONT + BOLD_ON);
            ticket.AppendLine($"{SessionFactura.SistemaPago ?? "DATAFAST"}");
            ticket.Append(BOLD_OFF + LEFT + SMALL_FONT);

            // Desglose exacto como en PDF
            ticket.AppendLine($"BASE CONSUMO TARIFA 15      US$    {SessionFactura.BaseConsumoTarifa15:F2}");
            ticket.AppendLine($"BASE CONSUMO TARIFA 0       US$    {SessionFactura.BaseConsumoTarifa0:F2}");
            ticket.AppendLine($"SUBTOTAL CONSUMO            US$    {SessionFactura.SubtotalConsumo:F2}");
            ticket.AppendLine($"IVA                         US$    {SessionFactura.IVA:F2}");

            // Total final bold
            ticket.Append(NORMAL_FONT + BOLD_ON);
            ticket.AppendLine($"VR TOTAL    US$                {SessionFactura.Total:F2}");
            ticket.Append(BOLD_OFF);

            // Agradecimiento centrado
            ticket.Append(CENTER + SMALL_FONT);
            ticket.AppendLine("\n...Gracias por su compra!");

            // Corte eficiente
            ticket.Append(FEED_MINIMAL);
            ticket.Append(CUT_PARTIAL);

            RawPrinterHelper.SendStringToPrinter(printerName, ticket.ToString());
        }
    }
}
