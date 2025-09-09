using System;

namespace ProyectoAndina.Utils
{
    internal class DatosImpresion
    {
        public void ImprimirConsumidorFinal()
        {
            string printerName = "SAT 22TUE"; // cámbialo al nombre real en Windows

            string init = "\x1B\x40"; // reset
            string boldOn = "\x1B\x45\x01";
            string boldOff = "\x1B\x45\x00";
            string center = "\x1B\x61\x01";
            string left = "\x1B\x61\x00";
            string cut = "\x1D\x56\x00"; // corte

            string ticket =
                init +
                center + boldOn + "UNIVERSIDAD ANDINA SIMON BOLIVAR\n" + boldOff +
                center + "RUC: 9999999999\n" +
                center + "Quito - Ecuador\n\n" +
                boldOn + "FACTURA\n" + boldOff +
                left + "Cliente: CONSUMIDOR FINAL\n" +
                "CI/RUC: 9999999999\n\n" +
                "--------------------------------\n" +
                "Producto       Cant   Precio   Total\n" +
                "Parqueadero    1      1.00     1.00\n" +
                "--------------------------------\n" +
                "TOTAL: $1.00\n\n" +
                center + "¡Gracias por su compra!\n\n\n" +
                cut;

            RawPrinterHelper.SendStringToPrinter(printerName, ticket);
        }

        public void ImprimirFacturaCliente()
        {
            string printerName = "SAT 22TUE";

            string init = "\x1B\x40"; // reset
            string boldOn = "\x1B\x45\x01";
            string boldOff = "\x1B\x45\x00";
            string center = "\x1B\x61\x01";
            string left = "\x1B\x61\x00";
            string cut = "\x1D\x56\x00"; // corte

            string ticket =
                init +
                center + boldOn + "UNIVERSIDAD ANDINA SIMON BOLIVAR\n" + boldOff +
                center + "RUC: 9999999999\n" +
                center + "Quito - Ecuador\n\n" +
                boldOn + "FACTURA\n" + boldOff +
                left + $"Cliente: {SessionFactura.ClienteNombre}\n" +
                $"CI/RUC: {SessionFactura.ClienteRuc}\n\n" +
                "--------------------------------\n" +
                "Producto       Cant   Precio   Total\n" +
                $"{SessionFactura.Producto,-12}{SessionFactura.Cantidad,5}{SessionFactura.PrecioUnitario,8:C}{SessionFactura.Total,8:C}\n" +
                "--------------------------------\n" +
                $"TOTAL: {SessionFactura.Total:C}\n\n" +
                center + "¡Gracias por su compra!\n\n\n" +
                cut;

            RawPrinterHelper.SendStringToPrinter(printerName, ticket);
        }
    }
}
