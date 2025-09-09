using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextFont = iTextSharp.text.Font;
using iTextRectangle = iTextSharp.text.Rectangle;

namespace ProyectoAndina.Utils
{
    public static class MostrarPdf
    {


        // 📌 Ticket Consumidor Final
        public static void GenerarPDFConsumidorFinal()
        {
            string ruta = "ticket_consumidor_final.pdf";

            // 📏 80mm ticket (226 puntos)
            var pageSize = new iTextRectangle(226, 600);
            Document doc = new Document(pageSize, 10, 10, 10, 10);

            PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
            doc.Open();

            // 🏫 Encabezado
            var titulo = new Paragraph("UNIVERSIDAD ANDINA SIMÓN BOLÍVAR\n",
                new iTextFont(iTextFont.FontFamily.HELVETICA, 10, iTextFont.BOLD));
            titulo.Alignment = Element.ALIGN_CENTER;
            doc.Add(titulo);

            doc.Add(new Paragraph("RUC: 9999999999", new iTextFont(iTextFont.FontFamily.HELVETICA, 8)));
            doc.Add(new Paragraph("Quito - Ecuador\n", new iTextFont(iTextFont.FontFamily.HELVETICA, 8)));

            var factura = new Paragraph("FACTURA\n",
                new iTextFont(iTextFont.FontFamily.HELVETICA, 9, iTextFont.BOLD));
            factura.Alignment = Element.ALIGN_CENTER;
            doc.Add(factura);

            // 👤 Datos fijos de consumidor final
            doc.Add(new Paragraph("Cliente: CONSUMIDOR FINAL", new iTextFont(iTextFont.FontFamily.HELVETICA, 8)));
            doc.Add(new Paragraph("CI/RUC: 9999999999\n", new iTextFont(iTextFont.FontFamily.HELVETICA, 8)));

            // 📋 Tabla productos
            PdfPTable tabla = new PdfPTable(4);
            tabla.WidthPercentage = 100;
            tabla.SetWidths(new float[] { 40, 15, 20, 25 });

            // Encabezado
            tabla.AddCell(new PdfPCell(new Phrase("Producto", new iTextFont(iTextFont.FontFamily.HELVETICA, 7, iTextFont.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Cant", new iTextFont(iTextFont.FontFamily.HELVETICA, 7, iTextFont.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Precio", new iTextFont(iTextFont.FontFamily.HELVETICA, 7, iTextFont.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Total", new iTextFont(iTextFont.FontFamily.HELVETICA, 7, iTextFont.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });

            // Item ejemplo
            tabla.AddCell(new Phrase("Parqueadero", new iTextFont(iTextFont.FontFamily.HELVETICA, 7)));
            tabla.AddCell(new Phrase("1", new iTextFont(iTextFont.FontFamily.HELVETICA, 7)));
            tabla.AddCell(new Phrase("1.00", new iTextFont(iTextFont.FontFamily.HELVETICA, 7)));
            tabla.AddCell(new Phrase("1.00", new iTextFont(iTextFont.FontFamily.HELVETICA, 7)));

            doc.Add(tabla);

            // 💰 Total
            doc.Add(new Paragraph("\nTOTAL: $1.00",
                new iTextFont(iTextFont.FontFamily.HELVETICA, 9, iTextFont.BOLD)));

            // 🙏 Gracias
            var gracias = new Paragraph("\n¡Gracias por su compra!\n",
                new iTextFont(iTextFont.FontFamily.HELVETICA, 7, iTextFont.ITALIC));
            gracias.Alignment = Element.ALIGN_CENTER;
            doc.Add(gracias);

            doc.Close();
        }

        // 📌 Ticket Factura con datos
        public static void GenerarPDFFactura()
        {
            string ruta = "ticket_factura.pdf";

            var pageSize = new iTextRectangle(226, 600);
            Document doc = new Document(pageSize, 10, 10, 10, 10);

            PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
            doc.Open();

            // 🏫 Encabezado
            var titulo = new Paragraph("UNIVERSIDAD ANDINA SIMÓN BOLÍVAR\n",
                new iTextFont(iTextFont.FontFamily.HELVETICA, 10, iTextFont.BOLD));
            titulo.Alignment = Element.ALIGN_CENTER;
            doc.Add(titulo);

            doc.Add(new Paragraph("RUC: 9999999999", new iTextFont(iTextFont.FontFamily.HELVETICA, 8)));
            doc.Add(new Paragraph("Quito - Ecuador\n", new iTextFont(iTextFont.FontFamily.HELVETICA, 8)));

            var factura = new Paragraph("FACTURA\n",
                new iTextFont(iTextFont.FontFamily.HELVETICA, 9, iTextFont.BOLD));
            factura.Alignment = Element.ALIGN_CENTER;
            doc.Add(factura);

            // 👤 Datos cliente
            doc.Add(new Paragraph($"Cliente: {SessionFactura.ClienteNombre}", new iTextFont(iTextFont.FontFamily.HELVETICA, 8)));
            doc.Add(new Paragraph($"CI/RUC: {SessionFactura.ClienteRuc}\n", new iTextFont(iTextFont.FontFamily.HELVETICA, 8)));

            // 📋 Tabla
            PdfPTable tabla = new PdfPTable(4);
            tabla.WidthPercentage = 100;
            tabla.SetWidths(new float[] { 40, 15, 20, 25 });

            tabla.AddCell(new PdfPCell(new Phrase("Producto", new iTextFont(iTextFont.FontFamily.HELVETICA, 7, iTextFont.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Cant", new iTextFont(iTextFont.FontFamily.HELVETICA, 7, iTextFont.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Precio", new iTextFont(iTextFont.FontFamily.HELVETICA, 7, iTextFont.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabla.AddCell(new PdfPCell(new Phrase("Total", new iTextFont(iTextFont.FontFamily.HELVETICA, 7, iTextFont.BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });

            tabla.AddCell(new Phrase(SessionFactura.Producto, new iTextFont(iTextFont.FontFamily.HELVETICA, 7)));
            tabla.AddCell(new Phrase(SessionFactura.Cantidad.ToString(), new iTextFont(iTextFont.FontFamily.HELVETICA, 7)));
            tabla.AddCell(new Phrase(SessionFactura.PrecioUnitario.ToString("C"), new iTextFont(iTextFont.FontFamily.HELVETICA, 7)));
            tabla.AddCell(new Phrase(SessionFactura.Total.ToString("C"), new iTextFont(iTextFont.FontFamily.HELVETICA, 7)));

            doc.Add(tabla);

            // 💰 Total
            doc.Add(new Paragraph($"\nTOTAL: {SessionFactura.Total:C}",
                new iTextFont(iTextFont.FontFamily.HELVETICA, 9, iTextFont.BOLD)));

            // 🙏 Gracias
            var gracias = new Paragraph("\n¡Gracias por su compra!\n",
                new iTextFont(iTextFont.FontFamily.HELVETICA, 7, iTextFont.ITALIC));
            gracias.Alignment = Element.ALIGN_CENTER;
            doc.Add(gracias);

            doc.Close();
        }
    }

    }
