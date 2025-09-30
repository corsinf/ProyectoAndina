using System;
using System.Text;

namespace ProyectoAndina.Utils
{
    internal class DatosImpresion
    {
        // 🎯 Comandos ESC/POS
        private const string ESC = "\x1B";
        private const string GS = "\x1D";

        private readonly string INIT = ESC + "@";           // Inicializar
        private readonly string BOLD_ON = ESC + "E\x01";    // Negrita ON
        private readonly string BOLD_OFF = ESC + "E\x00";   // Negrita OFF
        private readonly string CENTER = ESC + "a\x01";     // Centrar
        private readonly string LEFT = ESC + "a\x00";       // Izquierda
        private readonly string SMALL_FONT = ESC + "!\x00"; // Fuente normal
        private readonly string NORMAL_FONT = ESC + "!\x00";

        private readonly string CUT_PARTIAL = GS + "V\x01"; // Corte parcial
        private readonly string FEED_MINIMAL = "\n\n";      // Salto mínimo

        public void ImprimirRecibo(ReciboModel recibo, string printerName = "SAT 22TUE")
        {
            StringBuilder ticket = new StringBuilder();

            // 🚀 Inicialización
            ticket.Append(INIT);

            // 🏫 Encabezado empresa
            ticket.Append(CENTER + BOLD_ON);
            ticket.AppendLine(recibo.RazonSocial);
            ticket.Append(BOLD_OFF);

            ticket.Append(SMALL_FONT);
            ticket.AppendLine($"RUC: {recibo.RUC}");
            ticket.AppendLine($"Tel: {recibo.Telefono}");
            ticket.AppendLine(recibo.Direccion);
            ticket.AppendLine(recibo.Ciudad);
            ticket.AppendLine("------------------------------");

            // 📄 Documento
            ticket.Append(NORMAL_FONT + BOLD_ON);
            ticket.AppendLine($"{recibo.Documento} {recibo.Secuencial}");
            ticket.Append(BOLD_OFF + LEFT);

            // 📅 Fecha y hora
            ticket.AppendLine($"Fecha: {recibo.Fecha:dd/MM/yyyy}  Hora: {recibo.Hora:HH:mm}");
            if (!string.IsNullOrEmpty(recibo.Caja)) ticket.AppendLine($"Caja: {recibo.Caja}");
            if (!string.IsNullOrEmpty(recibo.Cajero)) ticket.AppendLine($"Cajero: {recibo.Cajero}");
            ticket.AppendLine("------------------------------");
            ticket.AppendLine(BOLD_ON + "Documento sin validez tributaria" + BOLD_OFF);
            ticket.AppendLine("------------------------------");

            // 👤 Cliente (solo si aplica)
            if (recibo.SistemaPago == "ruc")
            {
                ticket.AppendLine($"Cliente: {recibo.Cliente}");
                ticket.AppendLine($"CI/RUC: {recibo.CI_RUC}");
                if (!string.IsNullOrEmpty(recibo.TelefonoCliente)) ticket.AppendLine($"Tel: {recibo.TelefonoCliente}");
                if (!string.IsNullOrEmpty(recibo.Email)) ticket.AppendLine($"Email: {recibo.Email}");
                if (!string.IsNullOrEmpty(recibo.DireccionCliente)) ticket.AppendLine($"Dir: {recibo.DireccionCliente}");
                ticket.AppendLine("------------------------------");
            }

            // 🚗 Datos de parqueo
            if (recibo.FechaEntrada.HasValue && recibo.FechaSalida.HasValue)
            {
                ticket.AppendLine($"Placa: {recibo.Placa}");
                ticket.AppendLine($"Entrada: {recibo.FechaEntrada:dd/MM/yyyy HH:mm}");
                ticket.AppendLine($"Salida : {recibo.FechaSalida:dd/MM/yyyy HH:mm}");
                ticket.AppendLine($"Tiempo : {recibo.TiempoConsumido}");
                ticket.AppendLine("------------------------------");
            }

            // 📊 Desglose financiero
            ticket.AppendLine($"Neto              US$ {recibo.Neto:F2}");
            ticket.AppendLine($"Descuento         US$ {recibo.Descuento:F2}");
            ticket.AppendLine($"BASE TARIFA 15%   US$ {recibo.Subtotal:F2}");
            ticket.AppendLine($"IVA 15%           US$ {recibo.IVA15:F2}");
            ticket.AppendLine($"BASE TARIFA 0%    US$ {recibo.BaseConsumoTarifa0:F2}");
            ticket.AppendLine($"SUBTOTAL          US$ {recibo.Subtotal:F2}");
            ticket.AppendLine("------------------------------");

            // 💰 Total
            ticket.Append(NORMAL_FONT + BOLD_ON);
            ticket.AppendLine($"TOTAL             US$ {recibo.Total:F2}");
            ticket.Append(BOLD_OFF);
            ticket.AppendLine("------------------------------");

            // 💳 Forma de pago
            if (!string.IsNullOrEmpty(recibo.SistemaPago))
            {
                ticket.AppendLine($"Forma de pago: {recibo.SistemaPago}");
                ticket.AppendLine("------------------------------");
            }

            // 🙏 Agradecimiento
            ticket.Append(CENTER + SMALL_FONT);
            ticket.AppendLine("\n*** Gracias por su visita ***");

            // 📌 Firma
            ticket.Append(CENTER + SMALL_FONT);
            ticket.AppendLine("\nSistema desarrollado por CORSINF");

            // ✂️ Corte eficiente
            ticket.Append(FEED_MINIMAL);
            ticket.Append(CUT_PARTIAL);

            // 📤 Enviar a la impresora
            RawPrinterHelper.SendStringToPrinter(printerName, ticket.ToString());
        }

    }
}
