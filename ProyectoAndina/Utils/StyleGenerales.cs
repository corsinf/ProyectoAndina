using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProyectoAndina.Utils
{
    public static class StyleGenerales
    {
        // Centrar un título en la parte superior y cambiar color opcionalmente
        public static void CentrarTitulo(Form form, Label titulo, int margenSuperior = 20, Color? colorTexto = null)
        {
            if (form != null && titulo != null)
            {
                // Centrar horizontalmente
                titulo.Location = new Point(
                    (form.ClientSize.Width - titulo.Width) / 2,
                    margenSuperior
                );

                // Cambiar color si se manda
                if (colorTexto.HasValue)
                {
                    titulo.ForeColor = colorTexto.Value;
                }
            }
        }

        // Configurar responsividad con color opcional
        public static void ConfigurarTituloResponsivo(Form form, Label titulo, int margenSuperior = 20, Color? colorTexto = null)
        {
            if (form != null && titulo != null)
            {
                // Centrar y aplicar color al cargar
                form.Load += (s, e) => CentrarTitulo(form, titulo, margenSuperior, colorTexto);

                // Solo centrar cuando se redimensiona
                form.Resize += (s, e) => CentrarTitulo(form, titulo, margenSuperior);
            }
        }




        // esto es para la card
        public static void EstilizarCardVertical(Panel panel, string contenidoAlignment = "Center", Color? fondo = null)
        {
            if (panel == null) return;

            panel.BorderStyle = BorderStyle.None;
            panel.BackColor = fondo ?? panel.BackColor;

            // Ajustar controles internos horizontalmente (solo alineación, no orden)
            panel.ControlAdded += (s, e) => AlinearControlesverticales(panel, contenidoAlignment);
            panel.Resize += (s, e) => AlinearControlesverticales(panel, contenidoAlignment);

            // Ajuste inicial
            AlinearControlesverticales(panel, contenidoAlignment);
        }

        private static void AlinearControlesverticales(Panel panel, string alignment)
        {
            foreach (Control c in panel.Controls)
            {
                switch (alignment.ToLower())
                {
                    case "left":
                        c.Left = 20; // margen izquierdo
                        break;
                    case "right":
                        c.Left = panel.Width - c.Width - 20; // margen derecho
                        break;
                    default: // center
                        c.Left = (panel.Width - c.Width) / 2; // centrado horizontal
                        break;
                }

                // 🔹 Nota: NO tocamos c.Top, así se mantiene donde estaba en el diseñador
            }
        }


        private static void AlinearControleshorizontal(Panel panel, string horizontalAlignment, int padding = 20)
        {
            foreach (Control c in panel.Controls)
            {
                switch (horizontalAlignment.ToLower())
                {
                    case "center":
                        c.Top = (panel.Height - c.Height) / 2;
                        break;
                    case "bottom":
                        c.Top = panel.Height - c.Height - padding;
                        break;
                    default: // top
                        c.Top = padding;
                        break;
                }

                // 🔹 NO tocamos c.Left, así mantiene su posición horizontal original
            }
        }

        public static void EstilizarCardHorizontal(Panel panel, string horizontalAlignment = "top", Color? fondo = null, int padding = 20)
        {
            if (panel == null) return;

            panel.BackColor = fondo ?? panel.BackColor;

            panel.ControlAdded += (s, e) => AlinearControleshorizontal(panel, horizontalAlignment, padding);
            panel.Resize += (s, e) => AlinearControleshorizontal(panel, horizontalAlignment, padding);

            AlinearControleshorizontal(panel, horizontalAlignment, padding);
        }






        public static void PintarFondoDiagonal(Form form, PaintEventArgs e)
        {
            if (form == null || e == null) return;

            if (form == null || e == null) return;

            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                e.Graphics.FillRectangle(brush, form.ClientRectangle);
                
            }
        }


        public static void AjustarPanelAlFormulario(Form form, Panel panel, int margenSuperior = 0, int margenInferior = 0, int margenHorizontal = 0)
        {
            if (form != null && panel != null)
            {
                // Mantener la posición Y y el alto original
                int topOriginal = panel.Location.Y;
                int altoOriginal = panel.Height;

                // Nuevo ancho centrado con margen
                int nuevoAncho = form.ClientSize.Width - 2 * margenHorizontal;
                int nuevoX = margenHorizontal;

                // Aplicar posición y tamaño
                panel.Location = new Point(nuevoX, topOriginal);
                panel.Size = new Size(nuevoAncho, altoOriginal);
            }
        }

        public static void ConfigurarPanelResponsivo(Form form, Panel panel, int margenSuperior = 0, int margenInferior = 0, int margenHorizontal = 0)
        {
            if (form != null && panel != null)
            {
                // Ajustar al cargar el formulario
                form.Load += (s, e) => AjustarPanelAlFormulario(form, panel, margenSuperior, margenInferior, margenHorizontal);

                // Ajustar al redimensionar el formulario
                form.Resize += (s, e) => AjustarPanelAlFormulario(form, panel, margenSuperior, margenInferior, margenHorizontal);
            }
        }



        public static void AlinearControlesverticalesNuevo(Panel panel, string alignment)
        {
            var controles = panel.Controls.Cast<Control>().OrderBy(c => c.Top).ToList();

            // Agrupar controles de 2 en 2
            for (int i = 0; i < controles.Count; i += 2)
            {
                var control1 = controles[i];
                Control control2 = null;

                // Verificar si hay un segundo control en el par
                if (i + 1 < controles.Count)
                {
                    control2 = controles[i + 1];
                }

                switch (alignment.ToLower())
                {
                    case "left":
                        // Primer control a la izquierda
                        control1.Left = 20;
                        // Segundo control (si existe) también a la izquierda, debajo del primero
                        if (control2 != null)
                            control2.Left = 20;
                        break;

                    case "right":
                        // Primer control a la derecha
                        control1.Left = panel.Width - control1.Width - 20;
                        // Segundo control (si existe) también a la derecha, debajo del primero
                        if (control2 != null)
                            control2.Left = panel.Width - control2.Width - 20;
                        break;

                    default: // center
                        if (control2 != null)
                        {
                            int margenLateral = 20; // margen izquierdo y derecho
                            int espacioEntreControles = 30; // separación entre pares

                            int espacioDisponible = panel.Width - (margenLateral * 2) - espacioEntreControles;
                            int anchoControl1 = espacioDisponible / 2;
                            int anchoControl2 = espacioDisponible / 2;

                            control1.Width = anchoControl1;
                            control2.Width = anchoControl2;

                            control1.Left = margenLateral;
                            control2.Left = margenLateral + anchoControl1 + espacioEntreControles;
                        }
                        else
                        {
                            // Si solo hay un control, centrarlo
                            control1.Left = (panel.Width - control1.Width) / 2;
                        }
                        break;
                }
            }
        }


        public static void EstilizarCardVerticalControls(Panel panel, int margenVertical = 10, string contenidoAlignment = "Center", Color? fondo = null)
        {
            if (panel == null) return;

            panel.BorderStyle = BorderStyle.None;
            panel.BackColor = fondo ?? panel.BackColor;

            // Ajustar controles internos
            panel.ControlAdded += (s, e) => AlinearControlesVerticales(panel, contenidoAlignment, margenVertical);
            panel.Resize += (s, e) => AlinearControlesVerticales(panel, contenidoAlignment, margenVertical);

            // Ajuste inicial
            AlinearControlesVerticales(panel, contenidoAlignment, margenVertical);
        }

        private static void AlinearControlesVerticales(Panel panel, string alignment, int margenVertical)
        {
            if (panel.Controls.Count == 0) return;

            int altoDisponible = panel.Height - (margenVertical * 2); // espacio total menos márgenes
            int totalControles = panel.Controls.Count;

            // Calcular alto por control proporcional
            int altoPorControl = altoDisponible / totalControles;

            int y = margenVertical; // iniciar desde margen superior

            foreach (Control c in panel.Controls)
            {
                c.Top = y; // posición vertical
                c.Height = altoPorControl; // alto proporcional

                // Alineación horizontal
                switch (alignment.ToLower())
                {
                    case "left":
                        c.Left = 20;
                        break;
                    case "right":
                        c.Left = panel.Width - c.Width - 20;
                        break;
                    default: // center
                        c.Left = (panel.Width - c.Width) / 2;
                        break;
                }

                y += altoPorControl; // siguiente control
            }
        }


    }
}

