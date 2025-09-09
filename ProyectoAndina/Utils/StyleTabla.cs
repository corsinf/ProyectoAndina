using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAndina.Utils
{
    public static class StyleTabla
    {

        public static void CentrarControlEnPanel(Panel panel, Control control)
        {
            if (control != null && panel != null)
            {
                // Mantener la posición Y original (Top fijo)
                int topOriginal = control.Location.Y;

                // Márgenes
                int margenHorizontal = 20; // izquierda y derecha
                int margenInferior = 20;   // espacio inferior

                // Centrar horizontalmente con margen
                int nuevoX = margenHorizontal;
                int nuevoAncho = panel.Width - (margenHorizontal * 2);

                // Expandir hacia abajo hasta el borde inferior con margen
                int nuevoAlto = panel.Height - topOriginal - margenInferior;

                control.Location = new Point(nuevoX, topOriginal);
                control.Size = new Size(nuevoAncho, nuevoAlto);
            }
        }

        public static void ConfigurarResponsividadEnPanel(Panel panel, Control control)
        {
            if (panel == null || control == null) return;

            // Configurar inicialmente
            CentrarControlEnPanel(panel, control);

            // Reconfigurar cuando cambie el tamaño del panel
            panel.Resize += (s, e) => CentrarControlEnPanel(panel, control);

            // Si también necesitas reaccionar al cambio de tamaño del form padre
            Form formPadre = panel.FindForm();
            if (formPadre != null)
            {
                formPadre.Resize += (s, e) => CentrarControlEnPanel(panel, control);
            }
        }

    }
}
