using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextFont = iTextSharp.text.Font;
using iTextRectangle = iTextSharp.text.Rectangle;

namespace ProyectoAndina.Utils
{
    public static class MostrarPdf
    {


        public static void GenerarPDFTicket()
        {
            string ruta = SessionFactura.EsConsumidorFinal ?
                "ticket_consumidor_final.pdf" : "ticket_factura.pdf";

            // 📏 80mm ticket (226 puntos)
            var pageSize = new iTextRectangle(226, 650);
            Document doc = new Document(pageSize, 10, 10, 10, 10);

            PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
            doc.Open();

            // 🏫 Encabezado - Universidad
            var universidad = new Paragraph("UNIVERSIDAD ANDINA SIMON BOLI",
                new iTextFont(iTextFont.FontFamily.HELVETICA, 8, iTextFont.BOLD));
            universidad.Alignment = Element.ALIGN_CENTER;
            doc.Add(universidad);

            // 📋 RUC y datos de contacto
            doc.Add(new Paragraph("RUC 1791233417001",
                new iTextFont(iTextFont.FontFamily.HELVETICA, 7))
            { Alignment = Element.ALIGN_CENTER });
            doc.Add(new Paragraph("Telefono Quito 1701143 Ecuador",
                new iTextFont(iTextFont.FontFamily.HELVETICA, 7))
            { Alignment = Element.ALIGN_CENTER });
            doc.Add(new Paragraph("+593 86 307 2166",
                new iTextFont(iTextFont.FontFamily.HELVETICA, 7))
            { Alignment = Element.ALIGN_CENTER });
            doc.Add(new Paragraph("Quito - Ecuador",
                new iTextFont(iTextFont.FontFamily.HELVETICA, 7))
            { Alignment = Element.ALIGN_CENTER });

            // 🎯 DINERS CLUB (título del servicio)
            var dinersClub = new Paragraph("\nDINERS CLUB\n",
                new iTextFont(iTextFont.FontFamily.HELVETICA, 10, iTextFont.BOLD));
            dinersClub.Alignment = Element.ALIGN_CENTER;
            doc.Add(dinersClub);

            // 💳 Información de la tarjeta (si no es consumidor final)
            if (!SessionFactura.EsConsumidorFinal && !string.IsNullOrEmpty(SessionFactura.NumeroTarjeta))
            {
                doc.Add(new Paragraph($"TARJETA    {SessionFactura.NumeroTarjeta}",
                    new iTextFont(iTextFont.FontFamily.HELVETICA, 7)));
                doc.Add(new Paragraph($"LOTE#      {SessionFactura.Lote}          REF {SessionFactura.Referencia}",
                    new iTextFont(iTextFont.FontFamily.HELVETICA, 7)));
                doc.Add(new Paragraph($"FECHA      {SessionFactura.FechaHora:dd/MM/yy}         HORA {SessionFactura.FechaHora:HH:mm}",
                    new iTextFont(iTextFont.FontFamily.HELVETICA, 7)));
                doc.Add(new Paragraph("", new iTextFont(iTextFont.FontFamily.HELVETICA, 4))); // Espaciado
            }

            // 🏷️ Sistema de pago
            var datafast = new Paragraph($"{SessionFactura.SistemaPago}\n",
                new iTextFont(iTextFont.FontFamily.HELVETICA, 9, iTextFont.BOLD));
            datafast.Alignment = Element.ALIGN_CENTER;
            doc.Add(datafast);

            // 💰 Desglose de consumos (formato como en la imagen)
            doc.Add(new Paragraph($"BASE CONSUMO TARIFA 15      US$    {SessionFactura.BaseConsumoTarifa15:F2}",
                new iTextFont(iTextFont.FontFamily.HELVETICA, 7)));
            doc.Add(new Paragraph($"BASE CONSUMO TARIFA 0       US$    {SessionFactura.BaseConsumoTarifa0:F2}",
                new iTextFont(iTextFont.FontFamily.HELVETICA, 7)));
            doc.Add(new Paragraph($"SUBTOTAL CONSUMO            US$    {SessionFactura.SubtotalConsumo:F2}",
                new iTextFont(iTextFont.FontFamily.HELVETICA, 7)));
            doc.Add(new Paragraph($"IVA                         US$    {SessionFactura.IVA:F2}",
                new iTextFont(iTextFont.FontFamily.HELVETICA, 7)));

            // 📊 Total final
            var totalFinal = new Paragraph($"VR TOTAL    US$                {SessionFactura.Total:F2}",
                new iTextFont(iTextFont.FontFamily.HELVETICA, 8, iTextFont.BOLD));
            doc.Add(totalFinal);

            // 🙏 Mensaje de agradecimiento
            var gracias = new Paragraph("\n...Gracias por su compra!",
                new iTextFont(iTextFont.FontFamily.HELVETICA, 7, iTextFont.ITALIC));
            gracias.Alignment = Element.ALIGN_CENTER;
            doc.Add(gracias);

            doc.Close();
        }

        // 🎯 MÉTODO ESPECÍFICO PARA CONSUMIDOR FINAL
        public static void GenerarPDFConsumidorFinal()
        {
            // Configurar como consumidor final
            SessionFactura.EsConsumidorFinal = true;
            SessionFactura.ClienteNombre = "CONSUMIDOR FINAL";
            SessionFactura.ClienteRuc = "9999999999";

            // Generar el ticket
            GenerarPDFTicket();
        }

        // 🎯 MÉTODO ESPECÍFICO PARA FACTURA CON DATOS
        public static void GenerarPDFFactura()
        {
            // Configurar como factura normal
            SessionFactura.EsConsumidorFinal = false;

            // Generar el ticket
            GenerarPDFTicket();
        }

    }

}
