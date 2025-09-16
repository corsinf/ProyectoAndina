using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace ProyectoAndina.Utils
{
    public class StyleSystem
    {
        public static void PanelBoton(Panel panel,PictureBox img=null)
        {
            // Configuración básica del panel
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.None; // Quitamos el borde estándar

            // Evento Paint para dibujar bordes redondeados COMPLETOS
            panel.Paint += (sender, e) =>
            {
                // Crear camino gráfico para los bordes redondeados
                using (GraphicsPath path = new GraphicsPath())
                {
                    int radius = 15; // Radio de las esquinas
                    Rectangle rect = panel.ClientRectangle;

                    // Ajustar para que el dibujo sea completo
                    rect.Width -= 1;  // Ajustar para bordes completos
                    rect.Height -= 1; // Ajustar para bordes completos

                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
                    path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
                    path.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);

                    path.CloseAllFigures(); // Cerrar el camino

                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(new SolidBrush(panel.BackColor), path);
                    e.Graphics.DrawPath(new Pen(Color.LightGray, 1), path);
                }
            };

            panel.MouseEnter += (s, e) =>
            {
                panel.BackColor = Color.FromArgb(240, 240, 240);
                panel.Refresh(); // Forzar redibujado
            };

            panel.MouseLeave += (s, e) =>
            {
                panel.BackColor = Color.White;
                panel.Refresh(); // Forzar redibujado
            };

            //Size tamanoImagen = new Size(150, 150);
            //img.SizeMode = PictureBoxSizeMode.Zoom; // Mantiene la proporción
            //img.BackColor = Color.Transparent;
            //img.Size = tamanoImagen; // Tamaño fijo
            //img.Cursor = Cursors.Hand;

        }

        public static void BotonRedondeado(Button boton,Color color)
        {
            int radio = 30;
            int grosorBorde = 10;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radio, radio), 180, 90);
            path.AddArc(new Rectangle(boton.Width - radio, 0, radio, radio), 270, 90);
            path.AddArc(new Rectangle(boton.Width - radio, boton.Height - radio, radio, radio), 0, 90);
            path.AddArc(new Rectangle(0, boton.Height - radio, radio, radio), 90, 90);
            path.CloseFigure();

            boton.Region = new Region(path);

            // Redibuja borde negro por defecto
            boton.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, grosorBorde)) // Negro por defecto
                {
                    e.Graphics.DrawPath(pen, path);
                }
            };
        }

        public static void EstiloTextBox(TextBox textBox, bool esBusqueda = false)
        {
            // Configurar el TextBox
            int borderRadius = 10;
            textBox.BorderStyle = BorderStyle.None;
            textBox.BackColor = Color.White; // Fondo blanco
            textBox.ForeColor = Color.FromArgb(64, 64, 64);
            textBox.Font = new Font("Segoe UI", 12);
            textBox.Padding = new Padding(26, 20,26, 20);

            // IMPORTANTE: Establecer el estilo de control para double buffering
            textBox.GetType().GetMethod("SetStyle", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)?
                .Invoke(textBox, new object[] { ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true });

            // Evento Paint CORREGIDO
            textBox.Paint += (sender, e) =>
            {
                // Suavizado para bordes perfectos
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Obtener el área completa del TextBox
                Rectangle rect = textBox.ClientRectangle;

                // Ajustar para bordes visibles
                rect.Width -= 1;
                rect.Height -= 1;

                // Crear camino para bordes redondeados
                using (GraphicsPath path = new GraphicsPath())
                {
                    // Esquina superior izquierda
                    path.AddArc(rect.X, rect.Y, borderRadius, borderRadius, 180, 90);

                    // Esquina superior derecha  
                    path.AddArc(rect.X + rect.Width - borderRadius, rect.Y, borderRadius, borderRadius, 270, 90);

                    // Esquina inferior derecha
                    path.AddArc(rect.X + rect.Width - borderRadius, rect.Y + rect.Height - borderRadius,
                               borderRadius, borderRadius, 0, 90);

                    // Esquina inferior izquierda
                    path.AddArc(rect.X, rect.Y + rect.Height - borderRadius, borderRadius, borderRadius, 90, 90);

                    path.CloseAllFigures();

                    // 1. LIMPIAR el área con el color del formulario padre
                    if (textBox.Parent != null)
                    {
                        using (var brush = new SolidBrush(textBox.Parent.BackColor))
                        {
                            e.Graphics.FillRectangle(brush, rect);
                        }
                    }

                    // 2. Dibujar el fondo blanco DEL TextBox
                    using (var brush = new SolidBrush(textBox.BackColor))
                    {
                        e.Graphics.FillPath(brush, path);
                    }

                    // 3. Dibujar el BORDE (visible ahora)
                    Color colorBorde = textBox.Focused ? Color.FromArgb(86, 156, 214) : Color.FromArgb(200, 200, 200);
                    using (Pen pen = new Pen(colorBorde, 2))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };

            // Eventos para redibujar cuando cambia el estado
            //textBox.Enter += (s, e) => textBox.Invalidate();
            //textBox.Leave += (s, e) => textBox.Invalidate();
            //textBox.TextChanged += (s, e) => textBox.Invalidate();

            // Forzar redibujado inicial
            textBox.Invalidate();
        }

        public static void tableBorder(TableLayoutPanel tablelayout,Color? colorBorde = null,int radio = 20,int grosorBorde = 3)
        {
            // Color por defecto (naranja)
            Color borde = colorBorde ?? Color.FromArgb(255, 128, 0);

            // Eliminar suscripciones previas para evitar duplicados
            tablelayout.Paint -= (s, e) => DibujarBorde(tablelayout, e, borde, radio, grosorBorde);
            tablelayout.Paint += (s, e) => DibujarBorde(tablelayout, e, borde, radio, grosorBorde);
        }

        private static void DibujarBorde(TableLayoutPanel tablelayout,PaintEventArgs e,Color colorBorde,int radio,int grosorBorde)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, radio, radio, 180, 90);
            path.AddArc(tablelayout.Width - radio, 0, radio, radio, 270, 90);
            path.AddArc(tablelayout.Width - radio, tablelayout.Height - radio, radio, radio, 0, 90);
            path.AddArc(0, tablelayout.Height - radio, radio, radio, 90, 90);
            path.CloseFigure();

            // Redondear el contorno
            tablelayout.Region = new Region(path);

            // Dibujar el borde
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(colorBorde, grosorBorde))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }
    }
}
