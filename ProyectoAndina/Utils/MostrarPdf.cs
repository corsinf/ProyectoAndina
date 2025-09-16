using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextFont = iTextSharp.text.Font;
using iTextRectangle = iTextSharp.text.Rectangle;

namespace ProyectoAndina.Utils
{
    public static class MostrarPdf
    {
        public static void GenerarPDFTicket(ReciboModel recibo)
        {
            string ruta = recibo.Cliente == "CONSUMIDOR FINAL"
                ? "ticket_consumidor_final.pdf"
                : "ticket_factura.pdf";

            // 📏 80mm ticket (226 puntos)
            var pageSize = new iTextRectangle(226, 650);
            Document doc = new Document(pageSize, 10, 10, 10, 10);

            PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
            doc.Open();

            // 🏫 Encabezado - Empresa
            var universidad = new Paragraph(recibo.RazonSocial,
                new iTextFont(iTextFont.FontFamily.HELVETICA, 8, iTextFont.BOLD));
            universidad.Alignment = Element.ALIGN_CENTER;
            doc.Add(universidad);

            // 📋 RUC y datos de contacto
            doc.Add(new Paragraph($"RUC {recibo.RUC}",
                new iTextFont(iTextFont.FontFamily.HELVETICA, 7))
            { Alignment = Element.ALIGN_CENTER });
            doc.Add(new Paragraph(recibo.Direccion,
                new iTextFont(iTextFont.FontFamily.HELVETICA, 7))
            { Alignment = Element.ALIGN_CENTER });
            doc.Add(new Paragraph(recibo.Ciudad,
                new iTextFont(iTextFont.FontFamily.HELVETICA, 7))
            { Alignment = Element.ALIGN_CENTER });
            doc.Add(new Paragraph($"Tel: {recibo.Telefono}",
                new iTextFont(iTextFont.FontFamily.HELVETICA, 7))
            { Alignment = Element.ALIGN_CENTER });

           
                doc.Add(new Paragraph($"FECHA      {recibo.Fecha:dd/MM/yy}   HORA {recibo.Hora:HH:mm}",
                    new iTextFont(iTextFont.FontFamily.HELVETICA, 7)));
                doc.Add(new Paragraph("", new iTextFont(iTextFont.FontFamily.HELVETICA, 4))); // Espaciado

            // 🏷️ Sistema de pago (si tienes campo para eso)
            if (!string.IsNullOrEmpty(recibo.SistemaPago))
            {
                var datafast = new Paragraph($"{recibo.SistemaPago}\n",
                    new iTextFont(iTextFont.FontFamily.HELVETICA, 9, iTextFont.BOLD));
                datafast.Alignment = Element.ALIGN_CENTER;
                doc.Add(datafast);
            }

            // 💰 Desglose de consumos
            doc.Add(new Paragraph($"BASE CONSUMO TARIFA 15   US$ {recibo.Subtotal:F2}",
                new iTextFont(iTextFont.FontFamily.HELVETICA, 7)));
            doc.Add(new Paragraph($"BASE CONSUMO TARIFA 0    US$ {recibo.BaseConsumoTarifa0:F2}",
                new iTextFont(iTextFont.FontFamily.HELVETICA, 7)));
            doc.Add(new Paragraph($"SUBTOTAL CONSUMO         US$ {recibo.Subtotal:F2}",
                new iTextFont(iTextFont.FontFamily.HELVETICA, 7)));
            doc.Add(new Paragraph($"IVA                      US$ {recibo.IVA15:F2}",
                new iTextFont(iTextFont.FontFamily.HELVETICA, 7)));

            // 📊 Total final
            var totalFinal = new Paragraph($"VR TOTAL            US$ {recibo.Total:F2}",
                new iTextFont(iTextFont.FontFamily.HELVETICA, 8, iTextFont.BOLD));
            totalFinal.Alignment = Element.ALIGN_LEFT;
            doc.Add(totalFinal);

            // 🙏 Mensaje de agradecimiento
            var gracias = new Paragraph("\n...Gracias por su compra!",
                new iTextFont(iTextFont.FontFamily.HELVETICA, 7, iTextFont.ITALIC));
            gracias.Alignment = Element.ALIGN_CENTER;
            doc.Add(gracias);

            doc.Close();
        }

        // 🎯 Métodos específicos si quieres mantenerlos
        public static void GenerarPDFConsumidorFinal()
        {
            var recibo = new ReciboModel
            {
                RazonSocial = "UNIVERSIDAD ANDINA SIMON BOLIVAR",
                RUC = "1791233417001",
                Direccion = "Telefono Quito 1701143",
                Ciudad = "Quito - Ecuador",
                Telefono = "+593 86 307 2166",
                Cliente = "CONSUMIDOR FINAL",
                CI_RUC = "9999999999",
                Fecha = DateTime.Now,
                Hora = DateTime.Now,
                Subtotal = 1.00m,
                IVA15 = 0.00m,
                Total = 1.00m,
                BaseConsumoTarifa0 = 0,
                SistemaPago = "SISTEMA DE ESCRITORIO"
            };

            GenerarPDFTicket(recibo);
        }

        public static void GenerarPDFFactura(ReciboModel recibo)
        {
            GenerarPDFTicket(recibo);
        }
    }
}
