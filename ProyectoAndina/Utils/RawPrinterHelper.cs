using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAndina.Utils
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    public class RawPrinterHelper
    {
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true)]
        public static extern bool OpenPrinter(string src, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, int level, IntPtr di);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true)]
        public static extern bool WritePrinter(IntPtr hPrinter, byte[] bytes, int count, out int written);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        public static void SendBytesToPrinter(string printerName, byte[] bytes)
        {
            IntPtr hPrinter;
            if (OpenPrinter(printerName, out hPrinter, IntPtr.Zero))
            {
                StartDocPrinter(hPrinter, 1, IntPtr.Zero);
                StartPagePrinter(hPrinter);

                WritePrinter(hPrinter, bytes, bytes.Length, out int written);

                EndPagePrinter(hPrinter);
                EndDocPrinter(hPrinter);
                ClosePrinter(hPrinter);
            }
        }

        public static void SendStringToPrinter(string printerName, string texto)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(texto);
            SendBytesToPrinter(printerName, bytes);
        }
    }
}
