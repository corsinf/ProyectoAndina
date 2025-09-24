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

            // Manejador de cambio de estado Enabled con mejor diseño
            void ActualizarEstadoVisual()
            {
                if (!boton.Enabled)
                {
                    // Estado deshabilitado - diseño más elegante y visible
                    boton.BackColor = Color.FromArgb(240, 240, 240); // Gris claro pero con más presencia
                    boton.ForeColor = Color.FromArgb(100, 100, 100); // Gris oscuro visible
                    boton.Cursor = Cursors.No;
                    boton.FlatAppearance.BorderSize = 2; // Borde más grueso
                    boton.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200); // Borde gris medio

                    // Aplicar un patrón sutil de líneas diagonales
                    AplicarPatronDeshabilitado(boton);
                }
                else
                {
                    // Estado habilitado - colores normales
                    boton.BackColor = colorOriginal;
                    boton.ForeColor = colorTexto;
                    boton.Cursor = Cursors.Hand;
                    boton.FlatAppearance.BorderSize = 0;

                    // Quitar cualquier patrón
                    boton.BackgroundImage?.Dispose();
                    boton.BackgroundImage = null;
                }

                // Actualizar el icono con el nuevo estado
                AjustarContenido();
            }

            // Eventos de mouse solo cuando está habilitado
            boton.MouseEnter += (s, e) =>
            {
                if (!boton.Enabled) return;
                boton.BackColor = AjustarBrillo(colorOriginal, 0.85f);
                boton.FlatAppearance.BorderSize = 1;
                boton.FlatAppearance.BorderColor = Color.FromArgb(100, Color.White);
            };

            boton.MouseLeave += (s, e) =>
            {
                if (!boton.Enabled) return;
                boton.BackColor = colorOriginal;
                boton.FlatAppearance.BorderSize = 0;
            };

            boton.MouseDown += (s, e) =>
            {
                if (!boton.Enabled) return;
                boton.BackColor = AjustarBrillo(colorOriginal, 0.7f);
            };

            boton.MouseUp += (s, e) =>
            {
                if (!boton.Enabled) return;
                boton.BackColor = AjustarBrillo(colorOriginal, 0.85f);
            };

            // Detectar cambios en la propiedad Enabled
            boton.EnabledChanged += (s, e) => ActualizarEstadoVisual();

            // Ajuste de contenido mejorado
            void AjustarContenido()
            {
                if (boton.Width <= 0 || boton.Height <= 0) return;

                float escalaAncho = boton.Width / 120f;
                float escalaAlto = boton.Height / 80f;
                float escala = Math.Min(escalaAncho, escalaAlto);
                escala = Math.Max(0.6f, Math.Min(2.0f, escala));

                int tamanoIcono = (int)(Math.Min(boton.Width * 0.4f, boton.Height * 0.35f) * escala);
                tamanoIcono = Math.Max(12, Math.Min(48, tamanoIcono));

                float tamanoFuente = Math.Max(7f, Math.Min(14f, 9f * escala));

                if (!boton.Enabled)
                {
                    boton.Font = new Font("Segoe UI", tamanoFuente, FontStyle.Bold); // Mantener negrita para mejor legibilidad
                }
                else
                {
                    boton.Font = new Font("Segoe UI", tamanoFuente, FontStyle.Bold);
                }

                // Determinar si usar layout horizontal o vertical
                bool debeUsarLayoutHorizontal = false;
                SizeF tamanoTexto = SizeF.Empty;

                try
                {
                    using (var g = boton.CreateGraphics())
                    {
                        tamanoTexto = g.MeasureString(boton.Text ?? "", boton.Font);

                        // Verificar si el layout vertical causaría superposición
                        float espacioNecesarioVertical = tamanoIcono + tamanoTexto.Height + 12; // 12px de separación mínima
                        float espacioNecesarioHorizontal = tamanoIcono + tamanoTexto.Width + 16; // 16px de separación mínima

                        // Solo usar horizontal si:
                        // 1. El contenido vertical definitivamente no cabe (con margen de seguridad)
                        // 2. Y el contenido horizontal sí cabe bien
                        // 3. Y el botón es claramente más ancho que alto
                        if (espacioNecesarioVertical > boton.Height - 4 && // No cabe verticalmente (margen pequeño)
                            espacioNecesarioHorizontal <= boton.Width - 8 && // Sí cabe horizontalmente
                            boton.Width > boton.Height * 2.2f) // Solo si es muy ancho
                        {
                            debeUsarLayoutHorizontal = true;
                        }
                    }
                }
                catch
                {
                    tamanoTexto = new SizeF(boton.Text?.Length * tamanoFuente * 0.6f ?? 0, tamanoFuente * 1.2f);
                }

                if (debeUsarLayoutHorizontal)
                {
                    // Layout horizontal: ícono a la izquierda, texto a la derecha
                    boton.TextAlign = ContentAlignment.MiddleCenter;
                    boton.ImageAlign = ContentAlignment.MiddleLeft;
                    boton.TextImageRelation = TextImageRelation.ImageBeforeText;

                    // Calcular padding para centrar el contenido
                    int espacioTotal = boton.Width;
                    int espacioContenido = tamanoIcono + (int)tamanoTexto.Width + 8; // 8px de separación
                    int espacioLibre = Math.Max(0, espacioTotal - espacioContenido);
                    int paddingLateral = espacioLibre / 2;

                    boton.Padding = new Padding(Math.Max(4, paddingLateral), 4, Math.Max(4, paddingLateral), 4);
                }
                else
                {
                    // Layout vertical original: ícono arriba, texto abajo
                    boton.TextAlign = ContentAlignment.BottomCenter;
                    boton.ImageAlign = ContentAlignment.TopCenter;
                    boton.TextImageRelation = TextImageRelation.ImageAboveText;

                    try
                    {
                        using (var g = boton.CreateGraphics())
                        {
                            var tamanoTextoMedido = g.MeasureString(boton.Text ?? "", boton.Font);
                            float espacioTotal = boton.Height;
                            float espacioContenido = tamanoIcono + tamanoTextoMedido.Height;
                            float espacioLibre = espacioTotal - espacioContenido;

                            int espacioSuperior = Math.Max(4, (int)(espacioLibre * 0.4f));
                            int espacioInferior = Math.Max(4, (int)(espacioLibre * 0.4f));

                            boton.Padding = new Padding(6, espacioSuperior, 6, espacioInferior);
                        }
                    }
                    catch
                    {
                        int paddingVertical = Math.Max(4, boton.Height / 8);
                        boton.Padding = new Padding(6, paddingVertical, 6, paddingVertical);
                    }
                }

                RedimensionarIcono(boton, icono, tamanoIcono);

                int radioFinal = Math.Min(radioBorde, Math.Min(boton.Width, boton.Height) / 4);
                boton.Region = new Region(RoundedRect(boton.ClientRectangle, radioFinal));
            }

            boton.HandleCreated += (s, e) => { AjustarContenido(); ActualizarEstadoVisual(); };
            boton.Resize += (s, e) => AjustarContenido();
            boton.SizeChanged += (s, e) => AjustarContenido();

            if (boton.IsHandleCreated)
            {
                AjustarContenido();
                ActualizarEstadoVisual();
            }
        }

        // Método para aplicar un patrón sutil a botones deshabilitados
        private static void AplicarPatronDeshabilitado(Button boton)
        {
            try
            {
                if (boton.Width <= 0 || boton.Height <= 0) return;

                Bitmap patron = new Bitmap(boton.Width, boton.Height);
                using (Graphics g = Graphics.FromImage(patron))
                {
                    // Fondo base
                    g.Clear(Color.FromArgb(240, 240, 240));

                    // Patrón sutil de líneas diagonales
                    using (Pen pen = new Pen(Color.FromArgb(30, 220, 220, 220), 1))
                    {
                        for (int i = -boton.Height; i < boton.Width + boton.Height; i += 8)
                        {
                            g.DrawLine(pen, i, 0, i + boton.Height, boton.Height);
                        }
                    }

                    // Overlay semi-transparente para suavizar
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(20, Color.White)))
                    {
                        g.FillRectangle(brush, 0, 0, boton.Width, boton.Height);
                    }
                }

                boton.BackgroundImage?.Dispose();
                boton.BackgroundImage = patron;
                boton.BackgroundImageLayout = ImageLayout.None;
            }
            catch
            {
                // Si falla, usar color sólido
                boton.BackgroundImage?.Dispose();
                boton.BackgroundImage = null;
            }
        }

        private static void RedimensionarIcono(Button boton, IconChar icono, int nuevoTamano)
        {
            try
            {
                nuevoTamano = Math.Max(14, Math.Min(48, nuevoTamano));
                using (var ico = new IconPictureBox())
                {
                    ico.BackColor = Color.Transparent;
                    ico.IconChar = icono;

                    if (boton.Enabled)
                    {
                        ico.IconColor = boton.ForeColor;
                    }
                    else
                    {
                        // Icono más visible para botones deshabilitados
                        ico.IconColor = Color.FromArgb(120, 120, 120); // Gris medio, más visible
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

                    boton.Image?.Dispose();
                    boton.Image = bmp;
                }
            }
            catch (Exception ex)
            {
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
        public static void AplicarEstiloBotonBusqueda(IconPictureBox icon, TextBox textBox, int radio = 12)
        {
            // Ancho mayor para que se vea más cómodo
            int anchoBoton = 60; // ajusta a gusto

            // Tamaño igual al TextBox en altura
            icon.Size = new Size(anchoBoton, textBox.Height);

            // Fondo gris claro estilo Bootstrap input-group
            icon.BackColor = Color.FromArgb(233, 236, 239); // #e9ecef
            icon.IconColor = Color.Black;
            icon.IconSize = 28; // icono más grande
            icon.SizeMode = PictureBoxSizeMode.CenterImage;

            // Bordes redondeados en el lado derecho
            using (GraphicsPath path = new GraphicsPath())
            {
                Rectangle rect = new Rectangle(0, 0, icon.Width, icon.Height);
                int d = radio * 2;

                path.AddLine(rect.Left, rect.Top, rect.Right - radio, rect.Top);
                path.AddArc(rect.Right - d, rect.Top, d, d, 270, 90);    // arriba derecha
                path.AddLine(rect.Right, rect.Top + radio, rect.Right, rect.Bottom - radio);
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90); // abajo derecha
                path.AddLine(rect.Right - radio, rect.Bottom, rect.Left, rect.Bottom);
                path.CloseFigure();

                icon.Region = new Region(path);
            }

            // Colocar el icono a la derecha del TextBox
            icon.Location = new Point(textBox.Right, textBox.Top);
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