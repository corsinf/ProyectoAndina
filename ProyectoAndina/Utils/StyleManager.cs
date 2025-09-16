using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoAndina.Utils
{
    public static class StyleManager
    {
        // Colores UASB según el manual de marca
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

        // Configurar Form principal con diseño UASB
        public static void ConfigurarFormPrincipal(Form form, string titulo = "")
        {
            form.BackColor = Colors.GrisClaro;
            form.Font = Fonts.Cuerpo;
            form.Text = titulo;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimumSize = new Size(400, 300);

            // Permitir redimensionar
            form.FormBorderStyle = FormBorderStyle.Sizable;
            form.MaximizeBox = true;

            // Hacer responsive

            form.Resize += (s, e) =>
            {
                foreach (Control ctrl in form.Controls)
                {
                    if (ctrl is Button boton)
                    {
                        ConfigurarBotonPrincipal(boton);
                    }
                    if (ctrl is TextBox txt)
                    {
                        ConfigurarTextBox(txt);
                    }
                }
            };
        }


        // Configurar botón principal estilo UASB
        public static void ConfigurarBotonPrincipal(Button boton)
        {
            boton.BackColor = Colors.VerdeUASB;
            boton.ForeColor = Colors.Blanco;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.Font = Fonts.Boton;
            boton.Cursor = Cursors.Hand;
            boton.Padding = new Padding(20, 10, 20, 10);

            // Mantener ancho fijo (no lo tocamos, el que tenga ya)
            int anchoFijo = boton.Width;

            // Calcular altura necesaria según texto + padding
            using (Graphics g = boton.CreateGraphics())
            {
                SizeF textoSize = g.MeasureString(boton.Text, boton.Font);
                boton.Height = (int)textoSize.Height + boton.Padding.Vertical + 10; // margen extra
            }

            boton.Width = anchoFijo;

            // Efectos hover
            boton.MouseEnter += (sender, e) =>
            {
                boton.BackColor = Colors.VerdeHover;
                
            };

            boton.MouseLeave += (sender, e) =>
            {
                boton.BackColor = Colors.VerdeUASB;
               
            };

            boton.MouseDown += (sender, e) =>
            {
                boton.BackColor = Colors.VerdePressed;
            };

            boton.MouseUp += (sender, e) =>
            {
                boton.BackColor = Colors.VerdeHover;
            };
        }

        // Configurar botón secundario
        public static void ConfigurarBotonSecundario(Button boton)
        {
            boton.BackColor = Colors.Blanco;
            boton.ForeColor = Colors.VerdeUASB;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderColor = Colors.VerdeUASB;
            boton.FlatAppearance.BorderSize = 2;
            boton.Font = Fonts.Boton;
            boton.Cursor = Cursors.Hand;
            boton.Padding = new Padding(20, 10, 20, 10);
            // Mantener ancho fijo (no lo tocamos, el que tenga ya)
            int anchoFijo = boton.Width;

            // Calcular altura necesaria según texto + padding
            using (Graphics g = boton.CreateGraphics())
            {
                SizeF textoSize = g.MeasureString(boton.Text, boton.Font);
                boton.Height = (int)textoSize.Height + boton.Padding.Vertical + 10; // margen extra
            }

            boton.Width = anchoFijo;

            boton.MouseEnter += (sender, e) =>
            {
                boton.BackColor = Colors.VerdeUASB;
                boton.ForeColor = Colors.Blanco;
            };

            boton.MouseLeave += (sender, e) =>
            {
                boton.BackColor = Colors.Blanco;
                boton.ForeColor = Colors.VerdeUASB;
            };
        }

        public static void ConfigurarBotonIcono(
    Button boton,
    FontAwesome.Sharp.IconChar icono,
    string texto,
    int ancho = 200,
    int alto = 180,
    int radioBorde = 20, // radio para esquinas redondeadas
    EventHandler onClick = null,
    Color? colorFondo = null
)
        {
            Color fondoBase = colorFondo ?? Colors.VerdeUASB;

            // Variaciones hover y pressed
            Color fondoHover = ControlPaint.Light(fondoBase, 0.2f);
            Color fondoPressed = ControlPaint.Dark(fondoBase, 0.2f);

            // Estilo base
            boton.Size = new Size(ancho, alto);
            boton.BackColor = fondoBase;
            boton.ForeColor = Color.White;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.Font = Fonts.Boton;
            boton.Cursor = Cursors.Hand;
            boton.Padding = new Padding(0, alto / 4, 0, 15);
            boton.Text = texto;
            boton.TextAlign = ContentAlignment.BottomCenter;
            boton.ImageAlign = ContentAlignment.TopCenter;
            boton.TextImageRelation = TextImageRelation.ImageAboveText;

            // Dibujar icono
            using (var ico = new FontAwesome.Sharp.IconPictureBox())
            {
                ico.BackColor = Color.Transparent;
                ico.IconChar = icono;
                ico.IconColor = Color.White;
                ico.IconFont = FontAwesome.Sharp.IconFont.Auto;
                ico.Size = new Size(64, 64);

                Bitmap bmp = new Bitmap(ico.Width, ico.Height);
                ico.DrawToBitmap(bmp, new Rectangle(0, 0, ico.Width, ico.Height));
                bmp.MakeTransparent();
                boton.Image = bmp;
            }

            // Redondear el botón
            boton.Region = new Region(RoundedRect(boton.ClientRectangle, radioBorde));

            // Redibujar cuando cambie de tamaño
            boton.Resize += (s, e) =>
            {
                boton.Region = new Region(RoundedRect(boton.ClientRectangle, radioBorde));
            };

            // Aplicar sombra en el evento Paint
            boton.Paint += (s, e) =>
            {
                using (SolidBrush sombra = new SolidBrush(Color.FromArgb(60, Color.Black)))
                {
                    Rectangle rectSombra = new Rectangle(5, 5, boton.Width - 1, boton.Height - 1);
                    e.Graphics.FillPath(sombra, RoundedRect(rectSombra, radioBorde));
                }
            };

            // Estados (Enabled/Disabled)
            void AplicarEstado()
            {
                if (boton.Enabled)
                {
                    boton.BackColor = fondoBase;
                    boton.ForeColor = Color.White;
                    boton.Cursor = Cursors.Hand;
                }
                else
                {
                    boton.BackColor = Color.Gray;
                    boton.ForeColor = Color.LightGray;
                    boton.Cursor = Cursors.Default;
                    boton.Image = CambiarColorIcono(boton.Image, Color.LightGray);
                }
            }

            boton.EnabledChanged += (s, e) => AplicarEstado();
            AplicarEstado();

            // Hover/Pressed dinámicos
            boton.MouseEnter += (s, e) => { if (boton.Enabled) boton.BackColor = fondoHover; };
            boton.MouseLeave += (s, e) => { if (boton.Enabled) boton.BackColor = fondoBase; };
            boton.MouseDown += (s, e) => { if (boton.Enabled) boton.BackColor = fondoPressed; };
            boton.MouseUp += (s, e) => { if (boton.Enabled) boton.BackColor = fondoHover; };

            if (onClick != null)
                boton.Click += onClick;
        }

        // 🔹 Método auxiliar para crear rectángulos redondeados
        private static System.Drawing.Drawing2D.GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int d = radius * 2;
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.StartFigure();
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }




        public static void AplicarEstiloBotonesConIcono(
 Panel contenedor,
 Button boton,
 FontAwesome.Sharp.IconChar icono,
 string texto,
 Color colorFondo,
 EventHandler onClick = null)
        {
            if (contenedor == null || boton == null) return;

            // Ajustar ancho al del panel, mantener altura adecuada
            boton.Width = contenedor.Width - 10; // Margen de 5px a cada lado
            boton.Height = 120; // Altura fija suficiente para icono y texto
            boton.Location = new Point(5, 5); // Centrar con margen
            boton.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

            // Aplicar estilo base
            AplicarEstiloBotonesConIcono(boton, icono, texto, colorFondo, onClick);

            // Redimensionar dinámicamente si cambia el ancho del panel
            contenedor.Resize += (s, e) => {
                boton.Width = contenedor.Width - 10;
                boton.Location = new Point(5, boton.Location.Y);
            };
        }

        // Sin Panel (aplica estilo base)
        public static void AplicarEstiloBotonesConIcono(
            Button boton,
            FontAwesome.Sharp.IconChar icono,
            string texto,
            Color? colorFondo = null,
            EventHandler onClick = null)
        {
            if (boton == null) return;

            Color fondoBase = colorFondo ?? Colors.VerdeUASB;
            Color fondoHover = ControlPaint.Light(fondoBase, 0.15f);
            Color fondoPressed = ControlPaint.Dark(fondoBase, 0.15f);

            // Ajustar tamaño y estilo base - dimensiones más pequeñas pero proporcionales
            boton.Size = new Size(120, 100); // Reducido para que quepa mejor
            boton.BackColor = fondoBase;
            boton.ForeColor = Color.White;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.Font = new Font("Segoe UI", 9F, FontStyle.Regular); // Fuente más pequeña
            boton.Cursor = Cursors.Hand;
            boton.Padding = new Padding(5, 15, 5, 8); // Padding ajustado
            boton.Text = texto;
            boton.TextAlign = ContentAlignment.BottomCenter;
            boton.ImageAlign = ContentAlignment.TopCenter;
            boton.TextImageRelation = TextImageRelation.ImageAboveText;

            // 🔹 Redondear bordes
            boton.Paint += (s, e) =>
            {
                using var path = new System.Drawing.Drawing2D.GraphicsPath();
                int radius = 12; // Radio más pequeño
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(boton.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(boton.Width - radius, boton.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, boton.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();
                boton.Region = new Region(path);
            };

            // 🔹 Icono FontAwesome - tamaño reducido
            using (var ico = new FontAwesome.Sharp.IconPictureBox())
            {
                ico.BackColor = Color.Transparent;
                ico.IconChar = icono;
                ico.IconColor = Color.White;
                ico.IconFont = FontAwesome.Sharp.IconFont.Auto;
                ico.Size = new Size(32, 32); // Icono más pequeño
                Bitmap bmp = new Bitmap(ico.Width, ico.Height);
                ico.DrawToBitmap(bmp, new Rectangle(0, 0, ico.Width, ico.Height));
                bmp.MakeTransparent();
                boton.Image = bmp;
            }

            // 🔹 Hover, pressed y estado
            void ActualizarColor() => boton.BackColor = boton.Enabled ? fondoBase : Color.Gray;

            boton.EnabledChanged += (s, e) =>
            {
                ActualizarColor();
                boton.ForeColor = boton.Enabled ? Color.White : Color.LightGray;
                boton.Cursor = boton.Enabled ? Cursors.Hand : Cursors.Default;
                if (!boton.Enabled)
                    boton.Image = CambiarColorIcono(boton.Image, Color.LightGray);
            };

            boton.MouseEnter += (s, e) => { if (boton.Enabled) boton.BackColor = fondoHover; };
            boton.MouseLeave += (s, e) => { if (boton.Enabled) boton.BackColor = fondoBase; };
            boton.MouseDown += (s, e) => { if (boton.Enabled) boton.BackColor = fondoPressed; };
            boton.MouseUp += (s, e) => { if (boton.Enabled) boton.BackColor = fondoHover; };

            if (onClick != null)
                boton.Click += onClick;
        }

        // Método auxiliar para cambiar color del icono (si no lo tienes)
        

        public static void ConfigurarBotonPrincipalIcono(
    Button boton,
    FontAwesome.Sharp.IconChar icono,
    string texto,
    Color? colorFondo = null)
        {
            if (boton == null) return;

            // Colores
            Color fondoBase = colorFondo ?? Colors.VerdeUASB;
            Color fondoPressed = ControlPaint.Dark(fondoBase, 0.2f);

            // Limpiar contenido anterior
            boton.Text = string.Empty;
            boton.Image = null;
            boton.Controls.Clear();
            boton.Padding = new Padding(0);

            // Estilo base
            boton.UseVisualStyleBackColor = false;   // importante para respetar BackColor
            boton.BackColor = fondoBase;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.Font = Fonts.Boton;
            boton.Cursor = Cursors.Hand;

            // Contenedor
            var tabla = new TableLayoutPanel
            {
                RowCount = 1,
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                Padding = new Padding(20, 0, 20, 0)
            };
            tabla.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));          // icono
            tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));     // texto

            // Icono
            var ico = new FontAwesome.Sharp.IconPictureBox
            {
                IconChar = icono,
                IconColor = Color.White,
                IconFont = FontAwesome.Sharp.IconFont.Auto,
                Size = new Size(20, 20),
                SizeMode = PictureBoxSizeMode.CenterImage,
                Anchor = AnchorStyles.None,
                Margin = new Padding(0, 0, 15, 0),
                BackColor = Color.Transparent
            };

            // Texto
            var lbl = new Label
            {
                Text = texto,
                ForeColor = Color.White,          // letras blancas
                Font = Fonts.Boton,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Margin = new Padding(0),
                BackColor = Color.Transparent
            };

            // Agregar hijos
            tabla.Controls.Add(ico, 0, 0);
            tabla.Controls.Add(lbl, 1, 0);
            boton.Controls.Add(tabla);

            // Altura mínima
            boton.Height = Math.Max(48, ico.Height + 16);

            // Efecto SOLO en click (sin hover)
            boton.MouseDown += (s, e) => { if (boton.Enabled) boton.BackColor = fondoPressed; };
            boton.MouseUp += (s, e) => { if (boton.Enabled) boton.BackColor = fondoBase; };

            // Reenviar eventos desde los hijos al botón (para que el Click funcione siempre)
            void WirePassthrough(Control c)
            {
                c.MouseDown += (s, e) => { if (boton.Enabled) boton.BackColor = fondoPressed; };
                c.MouseUp += (s, e) => {
                    if (boton.Enabled)
                    {
                        boton.BackColor = fondoBase;
                        // dispara el Click asignado al botón
                        boton.PerformClick();
                    }
                };

                foreach (Control child in c.Controls)
                    WirePassthrough(child);
            }
            WirePassthrough(tabla);

            // Estado enabled/disabled
            boton.EnabledChanged += (s, e) =>
            {
                if (boton.Enabled)
                {
                    boton.BackColor = fondoBase;
                    lbl.ForeColor = Color.White;
                    ico.IconColor = Color.White;
                    boton.Cursor = Cursors.Hand;
                }
                else
                {
                    boton.BackColor = Color.Gray;
                    lbl.ForeColor = Color.LightGray;
                    ico.IconColor = Color.LightGray;
                    boton.Cursor = Cursors.Default;
                }
            };
        }


        // 🔹 Función auxiliar para recolorear iconos (cuando está deshabilitado)
        private static Bitmap CambiarColorIcono(Image original, Color nuevoColor)
        {
            Bitmap bmp = new Bitmap(original.Width, original.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                var attributes = new System.Drawing.Imaging.ImageAttributes();
                attributes.SetColorMatrix(new System.Drawing.Imaging.ColorMatrix(
                    new float[][]
                    {
                new float[] {0,0,0,0,0},
                new float[] {0,0,0,0,0},
                new float[] {0,0,0,0,0},
                new float[] {0,0,0,1,0},
                new float[] {nuevoColor.R/255f, nuevoColor.G/255f, nuevoColor.B/255f, 0, 1}
                    }));

                g.DrawImage(original,
                    new Rectangle(0, 0, bmp.Width, bmp.Height),
                    0, 0, original.Width, original.Height,
                    GraphicsUnit.Pixel, attributes);
            }
            return bmp;
        }



        // Configurar TextBox estilo UASB (versión simplificada)
        public static void ConfigurarTextBox(TextBox textBox, string placeholder = "")
        {
            textBox.Font = Fonts.Cuerpo;
            textBox.BackColor = Colors.Blanco;
            textBox.ForeColor = Colors.NegroUASB;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Height = 35;

            // Efectos focus con bordes
            textBox.Enter += (sender, e) =>
            {
                textBox.BackColor = Color.FromArgb(245, 248, 250);
                textBox.ForeColor = Colors.NegroUASB;
            };

            textBox.Leave += (sender, e) =>
            {
                textBox.BackColor = Colors.Blanco;
            };

            // Placeholder
            if (!string.IsNullOrEmpty(placeholder))
            {
                ConfigurarPlaceholder(textBox, placeholder);
            }

            // Paint event para borde personalizado
            textBox.Paint += (sender, e) =>
            {
                if (textBox.Focused)
                {
                    using (var pen = new Pen(Colors.VerdeUASB, 2))
                    {
                        e.Graphics.DrawRectangle(pen, 0, 0, textBox.Width - 1, textBox.Height - 1);
                    }
                }
            };
        }

        // Configurar ComboBox estilo UASB
        public static void ConfigurarComboBox(ComboBox comboBox)
        {
            comboBox.Font = Fonts.Cuerpo;
            comboBox.BackColor = Colors.Blanco;
            comboBox.ForeColor = Colors.NegroUASB;
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.Height = 35;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // Configurar Label estilo UASB
        public static void ConfigurarLabel(Label label, TipoLabel tipo = TipoLabel.Cuerpo)
        {
            label.BackColor = Color.Transparent;
            label.ForeColor = Colors.NegroUASB;

            switch (tipo)
            {
                case TipoLabel.TituloGrande:
                    label.Font = Fonts.TituloGrande;
                    label.ForeColor = Colors.VerdeUASB;
                    break;
                case TipoLabel.TituloMedio:
                    label.Font = Fonts.TituloMedio;
                    label.ForeColor = Colors.VerdeUASB;
                    break;
                case TipoLabel.TituloPequeno:
                    label.Font = Fonts.TituloPequeno;
                    label.ForeColor = Colors.VerdeUASB;
                    break;
                case TipoLabel.Subtitulo:
                    label.Font = Fonts.Subtitulo;
                    break;
                case TipoLabel.Cuerpo:
                    label.Font = Fonts.Cuerpo;
                    break;
                case TipoLabel.CuerpoSmall:
                    label.Font = Fonts.CuerpoSmall;
                    label.ForeColor = Colors.GrisOscuro;
                    break;
            }
        }

        // Configurar Panel con estilo UASB
        public static void ConfigurarPanel(Panel panel, bool conSombra = false)
        {
            panel.BackColor = Colors.Blanco;

            if (conSombra)
            {
                // Simulación de sombra con bordes
                panel.Paint += (sender, e) =>
                {
                    var p = sender as Panel;
                    using (var pen = new Pen(Color.FromArgb(50, 0, 0, 0), 1))
                    {
                        e.Graphics.DrawRectangle(pen, new Rectangle(2, 2, p.Width - 3, p.Height - 3));
                    }
                };
            }
        }

        // Configurar placeholder para TextBox
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

        // Hacer controles responsive
        private static void AjustarResponsive(Form form)
        {
            int width = form.ClientSize.Width;
            int height = form.ClientSize.Height;

            // Ajustar tamaños según resolución
            float scaleFactor = Math.Min(width / 800f, height / 600f);
            scaleFactor = Math.Max(0.8f, Math.Min(scaleFactor, 1.5f));

            AjustarControles(form.Controls, scaleFactor);
        }

        private static void AjustarControles(Control.ControlCollection controls, float scaleFactor)
        {
            foreach (Control control in controls)
            {
                if (control.HasChildren)
                {
                    AjustarControles(control.Controls, scaleFactor);
                }

                // Ajustar fuentes responsivamente
                if (control.Font != null)
                {
                    float newSize = control.Font.Size * scaleFactor;
                    newSize = Math.Max(8f, Math.Min(newSize, 32f));

                    if (Math.Abs(control.Font.Size - newSize) > 0.5f)
                    {
                        control.Font = new Font(control.Font.FontFamily, newSize, control.Font.Style);
                    }
                }
            }
        }

        // Mostrar mensaje de error
        public static void MostrarError(Label lblMensaje, string mensaje)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = Colors.Error;
            lblMensaje.Visible = true;
        }

        // Mostrar mensaje de éxito
        public static void MostrarExito(Label lblMensaje, string mensaje)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = Colors.Success;
            lblMensaje.Visible = true;
        }

        // Ocultar mensaje
        public static void OcultarMensaje(Label lblMensaje)
        {
            lblMensaje.Visible = false;
        }

        public static void ConfigurarBotonIconoEnPanel(
    Panel contenedor,
    Button boton,
    FontAwesome.Sharp.IconChar icono,
    Color colorFondo,
    int radioBorde = 15,          // Radio más suave por defecto
    EventHandler onClick = null,
    int margenHorizontal = 4,     // Márgenes más generosos
    int margenVertical = 4
)
        {
            if (boton == null) return;

            // 🌟 Aplicar estilo base mejorado
            ConfigurarBotonIconoElegante(boton, icono, boton.Text, colorFondo, radioBorde, onClick);

            void Ajustar()
            {
                if (contenedor != null && boton != null)
                {
                    int nuevoAncho = contenedor.ClientSize.Width - (margenHorizontal * 2);
                    int nuevoAlto = contenedor.ClientSize.Height - (margenVertical * 2);
                    nuevoAncho = Math.Max(60, nuevoAncho);  // Tamaño mínimo más grande
                    nuevoAlto = Math.Max(45, nuevoAlto);

                    boton.Size = new Size(nuevoAncho, nuevoAlto);

                    // 📏 Escalar fuente e ícono proporcionalmente
                    float escala = Math.Min(nuevoAncho / 180f, nuevoAlto / 70f);
                    escala = Math.Max(0.7f, Math.Min(1.4f, escala)); // Límites de escala

                    // 🔤 Fuente más elegante
                    boton.Font = new Font("Segoe UI", Math.Max(9f, 11f * escala), FontStyle.Bold);

                    if (nuevoAlto > 75) // Layout vertical para botones altos
                    {
                        boton.TextAlign = ContentAlignment.BottomCenter;
                        boton.ImageAlign = ContentAlignment.TopCenter;
                        boton.TextImageRelation = TextImageRelation.ImageAboveText;

                        int paddingTop = Math.Max(10, (int)(nuevoAlto * 0.15f));
                        int paddingBottom = Math.Max(10, (int)(nuevoAlto * 0.12f));
                        boton.Padding = new Padding(8, paddingTop, 8, paddingBottom);

                        int tamanoIcono = (int)(Math.Min(nuevoAncho, nuevoAlto) * 0.28f * escala);
                        RedimensionarIcono(boton, icono, Math.Max(20, Math.Min(48, tamanoIcono)));
                    }
                    else // Layout horizontal para botones anchos
                    {
                        boton.TextAlign = ContentAlignment.MiddleCenter;
                        boton.ImageAlign = ContentAlignment.MiddleLeft;
                        boton.TextImageRelation = TextImageRelation.ImageBeforeText;

                        int tamanoIcono = Math.Max(16, Math.Min(28, (int)(nuevoAlto * 0.55f * escala)));
                        int paddingLeft = tamanoIcono + 12;
                        int paddingRight = Math.Max(12, (int)(nuevoAncho * 0.06f));

                        boton.Padding = new Padding(paddingLeft, 4, paddingRight, 4);
                        RedimensionarIcono(boton, icono, tamanoIcono);
                    }

                    // 🎯 Región redondeada más suave
                    int radioFinal = Math.Min(radioBorde, Math.Min(nuevoAncho, nuevoAlto) / 5);
                    boton.Region = new Region(RoundedRect(boton.ClientRectangle, radioFinal));

                    // 📍 Centrar en el contenedor
                    int nuevoX = (contenedor.ClientSize.Width - boton.Width) / 2;
                    int nuevoY = (contenedor.ClientSize.Height - boton.Height) / 2;
                    boton.Location = new Point(Math.Max(0, nuevoX), Math.Max(0, nuevoY));
                }
            }

            // 🔧 Eventos para ajuste responsivo
            contenedor.HandleCreated += (s, e) => Ajustar();
            contenedor.Resize += (s, e) => Ajustar();

            // Ajustar inmediatamente si ya está creado
            if (contenedor.IsHandleCreated)
                Ajustar();
        }

        // 🌟 FUNCIÓN BASE MEJORADA PARA ESTILO ELEGANTE
        private static void ConfigurarBotonIconoElegante(
            Button boton,
            FontAwesome.Sharp.IconChar icono,
            string texto,
            Color colorFondo,
            int radioBorde,
            EventHandler onClick = null)
        {
            if (boton == null) return;

            // 🎨 Colores calculados para mejor contraste
            Color colorTexto = EsBrillante(colorFondo) ? Color.White : Color.FromArgb(40, 40, 40);
            Color colorHover = AjustarBrillo(colorFondo, 0.9f);
            Color colorPress = AjustarBrillo(colorFondo, 0.8f);

            boton.Text = texto;
            boton.BackColor = colorFondo;
            boton.ForeColor = colorTexto;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.UseVisualStyleBackColor = false;
            boton.Cursor = Cursors.Hand;

            // 🎭 Efectos hover mejorados
            boton.MouseEnter += (s, e) =>
            {
                boton.BackColor = colorHover;
                boton.FlatAppearance.BorderSize = 1;
                boton.FlatAppearance.BorderColor = Color.FromArgb(100, Color.White);
            };

            boton.MouseLeave += (s, e) =>
            {
                boton.BackColor = colorFondo;
                boton.FlatAppearance.BorderSize = 0;
            };

            boton.MouseDown += (s, e) => boton.BackColor = colorPress;
            boton.MouseUp += (s, e) => boton.BackColor = colorHover;

            if (onClick != null)
                boton.Click += onClick;

            // También necesitarás esta función para actualizar el ícono según el estado:
        }

        // 🔧 MÉTODOS AUXILIARES MEJORADOS
        private static bool EsBrillante(Color color)
        {
            // Algoritmo de luminancia mejorado
            double luminancia = (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;
            return luminancia < 0.6; // Invertido: colores oscuros necesitan texto blanco
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


        // 🔹 Método auxiliar mejorado para redimensionar el ícono dinámicamente
        private static void RedimensionarIcono(Button boton, FontAwesome.Sharp.IconChar icono, int nuevoTamano)
        {
            try
            {
                // Limitar el tamaño mínimo y máximo del ícono
                nuevoTamano = Math.Max(12, Math.Min(48, nuevoTamano));

                using (var ico = new FontAwesome.Sharp.IconPictureBox())
                {
                    ico.BackColor = Color.Transparent;
                    ico.IconChar = icono;
                    ico.IconColor = boton.Enabled ? Color.White : Color.LightGray;
                    ico.IconFont = FontAwesome.Sharp.IconFont.Auto;
                    ico.Size = new Size(nuevoTamano, nuevoTamano);

                    Bitmap bmp = new Bitmap(ico.Width, ico.Height);
                    ico.DrawToBitmap(bmp, new Rectangle(0, 0, ico.Width, ico.Height));
                    bmp.MakeTransparent();

                    // Liberar imagen anterior para evitar memory leaks
                    boton.Image?.Dispose();
                    boton.Image = bmp;
                }
            }
            catch
            {
                // Si falla la redimensión, mantener imagen actual
            }
        }


    }

    public enum TipoLabel
    {
        TituloGrande,
        TituloMedio,
        TituloPequeno,
        Subtitulo,
        Cuerpo,
        CuerpoSmall
    }
}