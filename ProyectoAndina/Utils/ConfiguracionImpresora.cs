using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAndina.Utils
{
    public static class ConfiguracionImpresora
    {
        public static string ImpresoraSeleccionada { get; set; }

        public static List<string> ObtenerImpresoras()
        {
            var impresoras = new List<string>();

            foreach (string impresora in PrinterSettings.InstalledPrinters)
            {
                impresoras.Add(impresora);
            }

            return impresoras;
        }

        /// <summary>
        /// Obtiene el nombre de la impresora predeterminada del sistema.
        /// </summary>
        public static string ObtenerImpresoraPredeterminada()
        {
            return new PrinterSettings().PrinterName;
        }
    }
}
