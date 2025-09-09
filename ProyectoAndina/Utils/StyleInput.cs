using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;                       // Para Color, Font, Rectangle, Pen, etc.
using System.Windows.Forms;                  // Para TextBox, Panel, EventHandler, etc.
using System.Drawing.Drawing2D;

namespace ProyectoAndina.Utils
{
    public static class StyleInput
    {

        public static class Colors
        {
            public static readonly Color VerdeUASB = Color.FromArgb(0, 71, 80);        // #004750
            public static readonly Color AmarilloUASB = Color.FromArgb(235, 179, 0);   // #EBB300
            public static readonly Color NegroUASB = Color.FromArgb(33, 39, 33);       // #212721
            public static readonly Color VerdeMedioUASB = Color.FromArgb(0, 110, 99);  // #006e63
            public static readonly Color VerdeClaroUASB = Color.FromArgb(0, 148, 144); // #009490

            // Colores complementarios
            public static readonly Color Blanco = Color.White;
            public static readonly Color GrisClaro = Color.FromArgb(248, 249, 250);
            public static readonly Color GrisMedio = Color.FromArgb(206, 212, 218);
            public static readonly Color GrisOscuro = Color.FromArgb(108, 117, 125);

            // Estados para botones
            public static readonly Color VerdeHover = Color.FromArgb(0, 91, 100);
            public static readonly Color VerdePressed = Color.FromArgb(0, 51, 60);
            public static readonly Color Error = Color.FromArgb(220, 53, 69);
            public static readonly Color Success = Color.FromArgb(40, 167, 69);
        }

        // Fuentes según el manual (aproximadas)
        public static class Fonts
        {
            public static readonly Font TituloGrande = new Font("Segoe UI", 28F, FontStyle.Bold);
            public static readonly Font TituloMedio = new Font("Segoe UI", 20F, FontStyle.Bold);
            public static readonly Font TituloPequeno = new Font("Segoe UI", 16F, FontStyle.Bold);
            public static readonly Font Subtitulo = new Font("Segoe UI", 14F, FontStyle.Regular);
            public static readonly Font Cuerpo = new Font("Segoe UI", 12F, FontStyle.Regular);
            public static readonly Font CuerpoSmall = new Font("Segoe UI", 10F, FontStyle.Regular);
            public static readonly Font Boton = new Font("Segoe UI", 12F, FontStyle.Regular);
        }

        private static void ConfigurarPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Colors.GrisOscuro;

            textBox.Enter += (sender, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Colors.NegroUASB;
                }
            };

            textBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Colors.GrisOscuro;
                }
            };
        }

        public static void ConfigurarInputEnPanelVertical(
     Panel contenedor,
     Label label,
     TextBox input,
     FontAwesome.Sharp.IconPictureBox icono = null,
     int margenHorizontal = 10,
     int margenVertical = 8,
     float proporcionLabel = 0.2f,           // porcentaje del alto del contenedor para el label
     int margenSuperiorLabel = 5,            // margen extra arriba del label
     int margenEntreLabelInput = 5,          // separación entre label e input
     int altoMinimoLabel = 20,               // alto mínimo del label
     int altoMinimoInput = 25                // alto mínimo del input
 )
        {
            if (contenedor == null || label == null || input == null) return;

            // Agregar controles al contenedor si no están
            if (!contenedor.Controls.Contains(label)) contenedor.Controls.Add(label);
            if (!contenedor.Controls.Contains(input)) contenedor.Controls.Add(input);
            if (icono != null && !contenedor.Controls.Contains(icono)) contenedor.Controls.Add(icono);

            void Ajustar()
            {
                if (contenedor == null || input == null || label == null) return;

                int anchoDisponible = Math.Max(100, contenedor.ClientSize.Width - (margenHorizontal * 2));
                int altoDisponible = Math.Max(60, contenedor.ClientSize.Height - (margenVertical * 2));

                // Altura del label con mínimo
                int altoLabel = Math.Max(altoMinimoLabel, (int)(altoDisponible * proporcionLabel));

                // Si hay icono, ajustar ancho del label
                int anchoIcono = (icono != null) ? altoLabel : 0;
                int anchoLabel = anchoDisponible - anchoIcono - 5;

                // Label
                label.SetBounds(margenHorizontal + anchoIcono, margenVertical + margenSuperiorLabel, anchoLabel, altoLabel);
                label.TextAlign = ContentAlignment.MiddleLeft;

                // Icono al lado del label
                if (icono != null)
                {
                    icono.SetBounds(margenHorizontal, margenVertical + margenSuperiorLabel, altoLabel, altoLabel);
                    icono.IconSize = Math.Min(24, altoLabel - 4);
                    icono.BackColor = Color.Transparent;
                }

                // Input debajo del label + margen entre label e input

                int yInput = margenVertical + margenSuperiorLabel + altoLabel + margenEntreLabelInput;
                int altoInput = Math.Max(altoMinimoInput, contenedor.ClientSize.Height - yInput - margenVertical);

                input.SetBounds(margenHorizontal, yInput, anchoDisponible, altoInput);
            }

            contenedor.HandleCreated += (s, e) => Ajustar();
            contenedor.Resize += (s, e) => Ajustar();
        }

        public static void ConfigurarTextBox(TextBox textBox, Panel contenedor, string placeholder = "", int margenHorizontal = 20)
        {
            // Fuente y colores
            textBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            textBox.BackColor = Color.White;
            textBox.ForeColor = Color.Black;
            textBox.BorderStyle = BorderStyle.None;
            textBox.Multiline = true;
            textBox.Height = 80;
            textBox.Width = contenedor.Width - (margenHorizontal * 2); // usar margenHorizontal
            textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox.Margin = new Padding(margenHorizontal, 5, margenHorizontal, 5);
            textBox.Padding = new Padding(5, 15, 5, 15);

            // Efectos focus
            textBox.Enter += (sender, e) =>
            {
                textBox.BackColor = Color.FromArgb(245, 248, 250);
                textBox.ForeColor = Color.Black;
                textBox.Invalidate();
            };
            textBox.Leave += (sender, e) =>
            {
                textBox.BackColor = Color.White;
                textBox.Invalidate();
            };

#if NET6_0_OR_GREATER
            if (!string.IsNullOrEmpty(placeholder))
                textBox.PlaceholderText = placeholder;
#endif

            // Paint para borde siempre visible
            textBox.Paint += (sender, e) =>
            {
                int borderRadius = 10;
                var rect = new Rectangle(0, 0, textBox.Width - 1, textBox.Height - 1);
                Color bordeColor = textBox.Focused ? Color.Green : Color.Black; // negro por defecto
                using (var pen = new Pen(bordeColor, 2))
                using (var path = RoundedRect(rect, borderRadius))
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.DrawPath(pen, path);
                }
            };

            textBox.Invalidate(); // dibujar borde inicial
        }




        // Método de borde redondeado
        private static System.Drawing.Drawing2D.GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            var path = new System.Drawing.Drawing2D.GraphicsPath();

            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }



    }
}
