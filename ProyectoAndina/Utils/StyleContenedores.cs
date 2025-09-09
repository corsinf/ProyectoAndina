using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProyectoAndina.Utils.StylesAlertas;

namespace ProyectoAndina.Utils
{
    public static class StyleContenedores
    {

        public static void EstilizarCardAcceso(
     Panel panelContainer,
     Panel panelTitulo,
     Panel panelImagen,
     Panel panelDescripcion,
     string titulo,
     Image imagen,
     string descripcion,
     bool acceso = true,
     Action onAcceso = null,
          Form form = null)
        {
            if (panelContainer == null) return;

            // --- Estilo principal de la Card ---
            panelContainer.BorderStyle = BorderStyle.None;
            panelContainer.BackColor = Color.White;
            panelContainer.Padding = new Padding(15);
            panelContainer.Margin = new Padding(10);

            panelContainer.Cursor = Cursors.Hand;

            // Borde redondeado
            panelContainer.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Rectangle rect = new Rectangle(0, 0, panelContainer.Width - 1, panelContainer.Height - 1);
                using (var brush = new SolidBrush(panelContainer.BackColor))
                using (var pen = new Pen(Color.LightGray, 2))
                {
                    e.Graphics.FillRoundedRectangle(brush, rect, 20);
                    e.Graphics.DrawRoundedRectangle(pen, rect, 20);
                }
            };

            // --- Título ---
            if (panelTitulo != null)
            {
                panelTitulo.Dock = DockStyle.Top;
                panelTitulo.Height = 40;
                panelTitulo.BackColor = Color.Transparent;
                panelTitulo.Padding = new Padding(5);

                var lblTitulo = new Label
                {
                    Text = titulo,
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.Black,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                panelTitulo.Controls.Clear();
                panelTitulo.Controls.Add(lblTitulo);
            }

            // --- Imagen ---
            if (panelImagen != null && imagen != null)
            {
                panelImagen.Dock = DockStyle.Top;
                panelImagen.Height = 120;
                panelImagen.BackColor = Color.Transparent;

                var picture = new PictureBox
                {
                    Image = imagen,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(0, 10, 0, 10)
                };

                panelImagen.Controls.Clear();
                panelImagen.Controls.Add(picture);
            }

            // --- Descripción ---
            if (panelDescripcion != null)
            {
                panelDescripcion.Dock = DockStyle.Fill;
                panelDescripcion.BackColor = Color.Transparent;
                panelDescripcion.Padding = new Padding(10);

                var lblDescripcion = new Label
                {
                    Text = descripcion,
                    Dock = DockStyle.Top,
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    ForeColor = acceso ? Color.Green : Color.Red,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                panelDescripcion.Controls.Clear();
                panelDescripcion.Controls.Add(lblDescripcion);
            }

            // --- Evento Click para toda la card ---
            void CardClick(object sender, EventArgs e)
            {
                if (acceso)
                {
                    onAcceso?.Invoke();
                }
                else
                {
                    StylesAlertas.MostrarAlerta(form, "❌ No tiene acceso a esta sección", "¡Error!", TipoAlerta.Error);
                }
            }

            // Registrar click en panel principal y todos los subpaneles y controles internos
            RegisterClickRecursive(panelContainer, CardClick);

            // --- Hover visual ---
            panelContainer.MouseEnter += (s, e) => panelContainer.BackColor = Color.FromArgb(240, 240, 240);
            panelContainer.MouseLeave += (s, e) => panelContainer.BackColor = Color.White;
        }

        public static void EstilizarCard(
    Panel panelContainer,
    Panel panelTitulo,
    Panel panelImagen,
    string titulo,
    Image imagen,
    Action onClick = null)
        {
            if (panelContainer == null) return;

            // --- Estilo principal de la Card ---
            panelContainer.BorderStyle = BorderStyle.None;
            panelContainer.BackColor = Color.White;
            panelContainer.Padding = new Padding(15);
            panelContainer.Margin = new Padding(10);
            panelContainer.Cursor = Cursors.Hand;

            // Borde redondeado
            panelContainer.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Rectangle rect = new Rectangle(0, 0, panelContainer.Width - 1, panelContainer.Height - 1);
                using (var brush = new SolidBrush(panelContainer.BackColor))
                using (var pen = new Pen(Color.LightGray, 2))
                {
                    e.Graphics.FillRoundedRectangle(brush, rect, 20);
                    e.Graphics.DrawRoundedRectangle(pen, rect, 20);
                }
            };

            // --- Imagen primero ---
            if (panelImagen != null && imagen != null)
            {
                panelImagen.Dock = DockStyle.Top;
                panelImagen.Height = 170; // aumentamos un poco la altura total
                panelImagen.BackColor = Color.Transparent;

                var picture = new PictureBox
                {
                    Image = imagen,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(100, 100),
                    Dock = DockStyle.None,
                    Anchor = AnchorStyles.None,
                    Margin = new Padding(0, 25, 0, 0) // 👈 margen superior de 15px
                };

                // Centrado dentro del panel
                picture.Location = new Point(
                    (panelImagen.Width - picture.Width) / 2,
                    (panelImagen.Height - picture.Height) / 2
                );

                panelImagen.Resize += (s, e) =>
                {
                    picture.Location = new Point(
                        (panelImagen.Width - picture.Width) / 2,
                        (panelImagen.Height - picture.Height) / 2
                    );
                };

                panelImagen.Controls.Clear();
                panelImagen.Controls.Add(picture);
            }

            // --- Título después ---
            if (panelTitulo != null)
            {
                panelTitulo.Dock = DockStyle.Top;
                panelTitulo.Height = 40;
                panelTitulo.BackColor = Color.Transparent;
                panelTitulo.Padding = new Padding(5);

                var lblTitulo = new Label
                {
                    Text = titulo,
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.Black,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                panelTitulo.Controls.Clear();
                panelTitulo.Controls.Add(lblTitulo);
            }

            // --- Evento Click ---
            void CardClick(object sender, EventArgs e) => onClick?.Invoke();
            RegisterClickRecursive(panelContainer, CardClick);

            // --- Hover visual ---
            panelContainer.MouseEnter += (s, e) => panelContainer.BackColor = Color.FromArgb(240, 240, 240);
            panelContainer.MouseLeave += (s, e) => panelContainer.BackColor = Color.White;
        }


        // Helper para propagar el click a todos los controles hijos
        private static void RegisterClickRecursive(Control control, EventHandler handler)
        {
            control.Click += handler;
            foreach (Control child in control.Controls)
            {
                RegisterClickRecursive(child, handler);
            }
        }


        /// <summary>
        /// Aplica hover al panel completo
        /// </summary>
        private static void AddHoverEffect(Control control, Color backNormal, Color backHover)
        {
            control.MouseEnter += (s, e) =>
            {
                var parentPanel = GetRootPanel(control);
                parentPanel.BackColor = backHover;
                parentPanel.Invalidate();
            };

            control.MouseLeave += (s, e) =>
            {
                var parentPanel = GetRootPanel(control);

                if (!parentPanel.ClientRectangle.Contains(parentPanel.PointToClient(Cursor.Position)))
                {
                    parentPanel.BackColor = backNormal;
                    parentPanel.Invalidate();
                }
            };

            foreach (Control child in control.Controls)
                AddHoverEffect(child, backNormal, backHover);
        }

       

        private static Panel GetRootPanel(Control control)
        {
            while (control.Parent != null && !(control is Panel))
                control = control.Parent;

            return control as Panel;
        }

        // Métodos gráficos auxiliares
        public static void FillRoundedRectangle(this Graphics g, Brush brush, Rectangle bounds, int cornerRadius)
        {
            using (var path = RoundedRect(bounds, cornerRadius))
            {
                g.FillPath(brush, path);
            }
        }

        public static void DrawRoundedRectangle(this Graphics g, Pen pen, Rectangle bounds, int cornerRadius)
        {
            using (var path = RoundedRect(bounds, cornerRadius))
            {
                g.DrawPath(pen, path);
            }
        }

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


        public static void AjustarPanelEnContenedor(Panel contenedor, Panel panel, int margenHorizontal = 20, int margenInferior = 20, int margenSuperior = 20)
        {
            if (contenedor != null && panel != null)
            {
                // Márgenes izquierda y derecha
                int nuevoX = margenHorizontal;
                int nuevoAncho = contenedor.ClientSize.Width - (margenHorizontal * 2);

                // Mantener espacio arriba y abajo
                int nuevoY = margenSuperior;
                int nuevoAlto = contenedor.ClientSize.Height - margenSuperior - margenInferior;

                // Ajustar panel dentro del contenedor
                panel.Location = new Point(nuevoX, nuevoY);
                panel.Size = new Size(nuevoAncho, nuevoAlto);
            }
        }

        public static void ConfigurarResponsividadEnContenedor(Panel contenedor, Panel panel, int margenHorizontal = 20, int margenInferior = 20, int margenSuperior = 20)
        {
            contenedor.HandleCreated += (s, e) =>
            {
                AjustarPanelEnContenedor(contenedor, panel, margenHorizontal, margenInferior, margenSuperior);
            };

            // Ajuste en cada redimensionamiento
            contenedor.Resize += (s, e) =>
            {
                AjustarPanelEnContenedor(contenedor, panel, margenHorizontal, margenInferior, margenSuperior);
            }; if (contenedor.IsHandleCreated)
            {
                AjustarPanelEnContenedor(contenedor, panel, margenHorizontal, margenInferior, margenSuperior);
            }
        }


       
        public static void EstilizarPanel(Panel panel, Color bordeColor, int borderRadius = 10, int sombraOffset = 5)
        {
            if (panel == null) return;

            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.None;

            // Paint para borde y sombra
            panel.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);

                // Sombra
                Rectangle sombraRect = new Rectangle(sombraOffset, sombraOffset, panel.Width - 1, panel.Height - 1);
                using (var sombraBrush = new SolidBrush(Color.FromArgb(50, Color.Transparent)))
                using (var sombraPath = RoundedRect(sombraRect, borderRadius))
                {
                    e.Graphics.FillPath(sombraBrush, sombraPath);
                }

                // Borde
                using (var pen = new Pen(bordeColor, 2))
                using (var path = RoundedRect(rect, borderRadius))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            };

            panel.Invalidate(); // forzar redibujado
        }



        public static void EstilizarTableLayout(
    TableLayoutPanel tableLayout,
    Color borderColor,
    int borderRadius = 12,
    int borderWidth = 2,
    int shadowOffset = 4,
    Color? backgroundColor = null // por defecto blanco
)
        {
            if (tableLayout == null) return;

            tableLayout.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            var bgColor = backgroundColor ?? Color.White;

            tableLayout.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                var rect = new Rectangle(0, 0, tableLayout.Width - 1, tableLayout.Height - 1);

                // ☁️ SOMBRA
                if (shadowOffset > 0)
                {
                    var shadowRect = new Rectangle(shadowOffset, shadowOffset,
                        tableLayout.Width - shadowOffset, tableLayout.Height - shadowOffset);

                    using (var shadowBrush = new SolidBrush(Color.FromArgb(25, 0, 0, 0)))
                    using (var shadowPath = CreateRoundedRect(shadowRect, borderRadius))
                    {
                        e.Graphics.FillPath(shadowBrush, shadowPath);
                    }
                }

                // 🎨 FONDO BLANCO (interior limpio)
                using (var bgBrush = new SolidBrush(bgColor))
                using (var bgPath = CreateRoundedRect(rect, borderRadius))
                {
                    e.Graphics.FillPath(bgBrush, bgPath);
                }

                // 🔲 BORDE
                using (var borderPen = new Pen(borderColor, borderWidth))
                using (var borderPath = CreateRoundedRect(rect, borderRadius))
                {
                    e.Graphics.DrawPath(borderPen, borderPath);
                }
            };

            tableLayout.Invalidate();
        }


        // 🎯 VERSIÓN SIMPLE SIN SOMBRA (más limpia)
        public static void EstilizarTableLayoutSimple(
            TableLayoutPanel tableLayout,
            Color borderColor,
            int borderRadius = 8,
            int borderWidth = 1)
        {
            EstilizarTableLayout(tableLayout, borderColor, borderRadius, borderWidth, 0);
        }

        // 🔧 MÉTODO AUXILIAR PARA RECTÁNGULOS REDONDEADOS
        private static GraphicsPath CreateRoundedRect(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            int diameter = radius * 2;

            if (rect.Width <= diameter || rect.Height <= diameter || radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            // Crear rectángulo con esquinas redondeadas
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90); // Superior izquierda
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90); // Superior derecha
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90); // Inferior derecha
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90); // Inferior izquierda

            path.CloseAllFigures();
            return path;
        }


    }
}
