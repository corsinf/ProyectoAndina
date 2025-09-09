using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProyectoAndina.Utils
{
    public static class StyleComboBox
    {

        public static void ConfigurarComboBox(ComboBox comboBox, Panel contenedor, int altura = 50, int margenHorizontal = 20)
        {
            // Ancho dinámico: contenedor menos márgenes
            int ancho = contenedor.Width - (margenHorizontal * 2);

            // Panel que actúa como borde redondeado
            Panel panelCombo = new Panel
            {
                Width = ancho,
                Height = altura,
                BackColor = Color.White,
                Top = (contenedor.Height - altura) / 2,          // Centrado vertical
                Left = margenHorizontal,                         // margen horizontal
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            // Paint para borde redondeado
            panelCombo.Paint += (s, e) =>
            {
                int borderRadius = 10;
                var rect = new Rectangle(0, 0, panelCombo.Width - 1, panelCombo.Height - 1);
                using (var pen = new Pen(Color.Green, 2))
                using (var path = RoundedRect(rect, borderRadius))
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.DrawPath(pen, path);
                }
            };

            contenedor.Controls.Add(panelCombo);

            // Configuración del ComboBox
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.BackColor = Color.White;
            comboBox.ForeColor = Color.Black;
            comboBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            comboBox.Dock = DockStyle.Fill;  // llena todo el panel
            comboBox.Margin = new Padding(2);

            panelCombo.Controls.Add(comboBox);

            // Recalcular posición si el contenedor cambia de tamaño
            contenedor.Resize += (s, e) =>
            {
                panelCombo.Width = contenedor.Width - (margenHorizontal * 2);
                panelCombo.Left = margenHorizontal;
                panelCombo.Top = (contenedor.Height - altura) / 2;
            };
        }

        // Método para rectángulo redondeado
        private static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

    }
}
