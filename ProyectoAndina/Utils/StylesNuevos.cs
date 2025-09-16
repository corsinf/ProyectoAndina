using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProyectoAndina.Utils.StylesAlertas;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProyectoAndina.Utils
{
    public class StylesNuevos
    {

        public static void EstilizarCardAcceso(
            TableLayoutPanel panelContainer,
            bool acceso = true,
            Action onAcceso = null,
            Form form = null)
        {
            if (panelContainer == null) return;

            // --- Estilo moderno de la Card ---
            panelContainer.BorderStyle = BorderStyle.None;
            panelContainer.BackColor = acceso ? Color.FromArgb(248, 250, 252) : Color.FromArgb(254, 249, 249);
            panelContainer.Padding = new Padding(15);
            panelContainer.Margin = new Padding(12);
            panelContainer.Cursor = Cursors.Hand;

            // Estructura 3 filas
            panelContainer.RowCount = 3;
            panelContainer.ColumnCount = 1;
            panelContainer.RowStyles.Clear();
            panelContainer.ColumnStyles.Clear();
            panelContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            panelContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 25)); // Título
            panelContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 45)); // Imagen
            panelContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 30)); // Descripción

            // Variables para animación
            Color colorBase = acceso ? Color.FromArgb(248, 250, 252) : Color.FromArgb(254, 249, 249);
            Color colorHover = acceso ? Color.FromArgb(241, 245, 249) : Color.FromArgb(252, 235, 235);

            // Redibujar card con estilo moderno
            panelContainer.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle rect = new Rectangle(0, 0, panelContainer.Width - 1, panelContainer.Height - 1);

                // 🎨 Sombras múltiples para efecto depth
                using (var shadowBrush1 = new SolidBrush(Color.FromArgb(10, 0, 0, 0)))
                using (var shadowBrush2 = new SolidBrush(Color.FromArgb(15, 0, 0, 0)))
                using (var shadowBrush3 = new SolidBrush(Color.FromArgb(25, 0, 0, 0)))
                {
                    Rectangle shadow1 = rect; shadow1.Offset(1, 1);
                    Rectangle shadow2 = rect; shadow2.Offset(3, 3);
                    Rectangle shadow3 = rect; shadow3.Offset(6, 6);

                    FillRoundedRectangle(e.Graphics, shadowBrush3, shadow3, 16);
                    FillRoundedRectangle(e.Graphics, shadowBrush2, shadow2, 16);
                    FillRoundedRectangle(e.Graphics, shadowBrush1, shadow1, 16);
                }

                // Gradiente de fondo
                using (var gradientBrush = new LinearGradientBrush(
                    rect,
                    panelContainer.BackColor,
                    Color.FromArgb(Math.Max(0, panelContainer.BackColor.R - 5),
                                  Math.Max(0, panelContainer.BackColor.G - 5),
                                  Math.Max(0, panelContainer.BackColor.B - 5)),
                    45f))
                {
                    FillRoundedRectangle(e.Graphics, gradientBrush, rect, 16);
                }

                // Borde sutil con gradiente
                Color borderColor = acceso ? Color.FromArgb(203, 213, 225) : Color.FromArgb(248, 113, 113);
                using (var borderPen = new Pen(borderColor, 1.5f))
                {
                    DrawRoundedRectangle(e.Graphics, borderPen, rect, 16);
                }

                // Highlight superior para efecto glass
                Rectangle highlight = new Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height / 3);
                using (var highlightBrush = new LinearGradientBrush(
                    highlight,
                    Color.FromArgb(40, 255, 255, 255),
                    Color.FromArgb(0, 255, 255, 255),
                    LinearGradientMode.Vertical))
                {
                    FillRoundedRectangle(e.Graphics, highlightBrush, highlight, 15);
                }
            };

            // 🎯 SOLUCIÓN DEFINITIVA PARA EL CLICK
            EventHandler clickHandler = (sender, e) =>
            {
                if (acceso)
                {
                    // Efecto visual de click
                    panelContainer.BackColor = Color.FromArgb(226, 232, 240);
                    panelContainer.Invalidate();

                    // Restaurar color después de 100ms
                    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                    timer.Interval = 100;
                    timer.Tick += (ts, te) =>
                    {
                        panelContainer.BackColor = colorBase;
                        panelContainer.Invalidate();
                        timer.Stop();
                        timer.Dispose();
                    };
                    timer.Start();

                    onAcceso?.Invoke();
                }
                else
                {
                    // Aquí deberías usar tu método de alerta
                    MessageBox.Show("❌ No tiene acceso a esta sección", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // StylesAlertas.MostrarAlerta(form, "❌ No tiene acceso a esta sección", "¡Error!", TipoAlerta.Error);
                }
            };

            // Configurar controles existentes
            foreach (Control ctrl in panelContainer.Controls)
            {
                ConfigurarControlHijo(ctrl, acceso, clickHandler, colorBase, colorHover, panelContainer);
            }

            // Manejar controles que se agreguen dinámicamente
            panelContainer.ControlAdded += (s, e) =>
            {
                ConfigurarControlHijo(e.Control, acceso, clickHandler, colorBase, colorHover, panelContainer);
            };

            // --- Evento Click principal del TableLayoutPanel ---
            panelContainer.Click += clickHandler;

            // --- Efectos hover mejorados ---
            panelContainer.MouseEnter += (s, e) =>
            {
                panelContainer.BackColor = colorHover;
                panelContainer.Invalidate();
            };

            panelContainer.MouseLeave += (s, e) =>
            {
                panelContainer.BackColor = colorBase;
                panelContainer.Invalidate();
            };
        }

        // Método auxiliar para configurar cada control hijo
        private static void ConfigurarControlHijo(Control ctrl, bool acceso, EventHandler clickHandler,
            Color colorBase, Color colorHover, TableLayoutPanel parent)
        {
            // Hacer que el control hijo propague el click al padre
            ctrl.Click += clickHandler;
            ctrl.Cursor = Cursors.Hand;

            // Propagar eventos de hover al padre
            ctrl.MouseEnter += (s, e) =>
            {
                parent.BackColor = colorHover;
                parent.Invalidate();
            };

            ctrl.MouseLeave += (s, e) =>
            {
                parent.BackColor = colorBase;
                parent.Invalidate();
            };

            if (ctrl is Label lbl)
            {
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Dock = DockStyle.Fill;
                lbl.BackColor = Color.Transparent;
                lbl.Font = new Font("Segoe UI", 10, FontStyle.Regular);

                // Colores modernos
                if (acceso)
                {
                    lbl.ForeColor = Color.FromArgb(15, 118, 110); // Teal 700
                }
                else
                {
                    lbl.ForeColor = Color.FromArgb(185, 28, 28); // Red 700
                }
            }
            else if (ctrl is PictureBox pic)
            {
                pic.SizeMode = PictureBoxSizeMode.Zoom;
                pic.Dock = DockStyle.Fill;
                pic.BackColor = Color.Transparent;
            }

            // Aplicar configuración recursivamente a controles anidados
            foreach (Control hijo in ctrl.Controls)
            {
                ConfigurarControlHijo(hijo, acceso, clickHandler, colorBase, colorHover, parent);
            }
        }

        // Métodos para dibujar rectángulos redondeados
        private static void FillRoundedRectangle(Graphics graphics, Brush brush, Rectangle bounds, int radius)
        {
            using (var path = CreateRoundedRectanglePath(bounds, radius))
            {
                graphics.FillPath(brush, path);
            }
        }

        private static void DrawRoundedRectangle(Graphics graphics, Pen pen, Rectangle bounds, int radius)
        {
            using (var path = CreateRoundedRectanglePath(bounds, radius))
            {
                graphics.DrawPath(pen, path);
            }
        }

        private static GraphicsPath CreateRoundedRectanglePath(Rectangle bounds, int radius)
        {
            var path = new GraphicsPath();

            if (radius <= 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            int diameter = radius * 2;
            Rectangle arc = new Rectangle(bounds.Location, new Size(diameter, diameter));

            // Top left arc
            path.AddArc(arc, 180, 90);

            // Top right arc
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // Bottom right arc
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // Bottom left arc
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }


    }
}
