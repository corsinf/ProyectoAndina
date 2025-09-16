using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace ProyectoAndina.Utils
{
    public static class StyleButton
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



        public static void CrearBotonElegante(
    Button boton,
    IconChar icono,
    EventHandler onClick = null,
    int radioBorde = 20
)
        {
            if (boton == null) return;

            // Colores dinámicos según el color actual del botón
            Color colorBase = boton.BackColor;
            Color colorTexto = EsBrillante(colorBase) ? Color.White : Color.FromArgb(40, 40, 40);

            // Propiedades básicas
            boton.ForeColor = colorTexto;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.Cursor = Cursors.Hand;
            boton.Dock = DockStyle.Fill;
            boton.Margin = new Padding(0);
            if (onClick != null) boton.Click += onClick;

            Color colorOriginal = boton.BackColor;

            boton.MouseEnter += (s, e) =>
            {
                boton.BackColor = AjustarBrillo(colorOriginal, 0.85f);
                boton.FlatAppearance.BorderSize = 1;
                boton.FlatAppearance.BorderColor = Color.FromArgb(100, Color.White);
            };

            boton.MouseLeave += (s, e) =>
            {
                boton.BackColor = colorOriginal;
            };

            boton.MouseDown += (s, e) =>
            {
                boton.BackColor = AjustarBrillo(colorOriginal, 0.7f);
            };

            boton.MouseUp += (s, e) =>
            {
                boton.BackColor = AjustarBrillo(colorOriginal, 0.85f);
            };

            // Ajuste de contenido mejorado - SIEMPRE layout vertical
            void AjustarContenido()
            {
                if (boton.Width <= 0 || boton.Height <= 0) return;

                // Siempre usar layout vertical (icono arriba, texto abajo)
                boton.TextAlign = ContentAlignment.BottomCenter;
                boton.ImageAlign = ContentAlignment.TopCenter;
                boton.TextImageRelation = TextImageRelation.ImageAboveText;

                // Escala basada en las dimensiones del botón
                float escalaAncho = boton.Width / 120f;
                float escalaAlto = boton.Height / 80f;
                float escala = Math.Min(escalaAncho, escalaAlto);
                escala = Math.Max(0.6f, Math.Min(2.0f, escala));

                // Calcular tamaño de icono proporcional al botón
                int tamanoIcono = (int)(Math.Min(boton.Width * 0.4f, boton.Height * 0.35f) * escala);
                tamanoIcono = Math.Max(12, Math.Min(48, tamanoIcono));

                // Tamaño de fuente proporcional
                float tamanoFuente = Math.Max(7f, Math.Min(14f, 9f * escala));
                boton.Font = new Font("Segoe UI", tamanoFuente, FontStyle.Bold);

                // Calcular padding para centrado perfecto
                try
                {
                    using (var g = boton.CreateGraphics())
                    {
                        var tamanoTexto = g.MeasureString(boton.Text ?? "", boton.Font);

                        // Espacio total disponible para distribución
                        float espacioTotal = boton.Height;
                        float espacioContenido = tamanoIcono + tamanoTexto.Height;
                        float espacioLibre = espacioTotal - espacioContenido;

                        // Distribución del espacio libre
                        int espacioSuperior = Math.Max(4, (int)(espacioLibre * 0.4f));
                        int espacioInferior = Math.Max(4, (int)(espacioLibre * 0.4f));
                        int espacioMedio = Math.Max(2, (int)(espacioLibre * 0.2f));

                        // Aplicar padding calculado
                        boton.Padding = new Padding(6, espacioSuperior, 6, espacioInferior);
                    }
                }
                catch
                {
                    // Fallback si hay error con Graphics
                    int paddingVertical = Math.Max(4, boton.Height / 8);
                    boton.Padding = new Padding(6, paddingVertical, 6, paddingVertical);
                }

                RedimensionarIcono(boton, icono, tamanoIcono);

                // Bordes redondeados
                int radioFinal = Math.Min(radioBorde, Math.Min(boton.Width, boton.Height) / 4);
                boton.Region = new Region(RoundedRect(boton.ClientRectangle, radioFinal));
            }

            boton.HandleCreated += (s, e) => AjustarContenido();
            boton.Resize += (s, e) => AjustarContenido();
            boton.SizeChanged += (s, e) => AjustarContenido(); // Agregado para mejor respuesta
            if (boton.IsHandleCreated) AjustarContenido();
        }

        // ------------------- FUNCIONES AUXILIARES MEJORADAS -------------------

        private static void RedimensionarIcono(Button boton, IconChar icono, int nuevoTamano)
        {
            try
            {
                nuevoTamano = Math.Max(14, Math.Min(48, nuevoTamano));
                using (var ico = new IconPictureBox())
                {
                    ico.BackColor = Color.Transparent;
                    ico.IconChar = icono;

                    // Color del icono según el estado del botón
                    if (boton.Enabled)
                    {
                        ico.IconColor = boton.ForeColor;
                    }
                    else
                    {
                        ico.IconColor = Color.FromArgb(120, boton.ForeColor); // Más sutil cuando está deshabilitado
                    }

                    ico.IconFont = IconFont.Auto;
                    ico.Size = new Size(nuevoTamano, nuevoTamano);

                    Bitmap bmp = new Bitmap(nuevoTamano, nuevoTamano);
                    using (var g = Graphics.FromImage(bmp))
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        ico.DrawToBitmap(bmp, new Rectangle(0, 0, nuevoTamano, nuevoTamano));
                    }
                    bmp.MakeTransparent();

                    // Liberar imagen anterior
                    boton.Image?.Dispose();
                    boton.Image = bmp;
                }
            }
            catch (Exception ex)
            {
                // Log del error si es necesario
                System.Diagnostics.Debug.WriteLine($"Error redimensionando icono: {ex.Message}");
            }
        }

        private static System.Drawing.Drawing2D.GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            if (radius <= 0)
                radius = 1;

            int d = Math.Min(radius * 2, Math.Min(bounds.Width, bounds.Height));
            var path = new System.Drawing.Drawing2D.GraphicsPath();

            if (d < bounds.Width && d < bounds.Height)
            {
                path.StartFigure();
                path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
                path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
                path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
                path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
                path.CloseFigure();
            }
            else
            {
                path.AddRectangle(bounds);
            }

            return path;
        }

        private static bool EsBrillante(Color color)
        {
            double luminancia = (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;
            return luminancia < 0.6;
        }

        private static Color AjustarBrillo(Color color, float factor)
        {
            return Color.FromArgb(
                color.A,
                Math.Max(0, Math.Min(255, (int)(color.R * factor))),
                Math.Max(0, Math.Min(255, (int)(color.G * factor))),
                Math.Max(0, Math.Min(255, (int)(color.B * factor)))
            );
        }



    }

}

/* 
=== EJEMPLOS DE USO ===

// Botón cuadrado pequeño - icono arriba, texto abajo
StyleButton.EstilizarBoton(buttonPequeno, FontAwesome.Sharp.IconChar.Plus, StyleButton.Colors.VerdeUASB);

// Botón rectangular ancho - icono a la izquierda, texto a la derecha  
StyleButton.EstilizarBoton(buttonAncho, FontAwesome.Sharp.IconChar.Save, StyleButton.Colors.AmarilloUASB);

// Se adapta automáticamente al tamaño del botón
StyleButton.EstilizarBoton(button_agregar_rol, FontAwesome.Sharp.IconChar.UserPlus, Color.FromArgb(52, 152, 219));
*/