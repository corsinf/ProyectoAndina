using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulpep.NotificationWindow;
using System.Globalization;
using System.Threading;

namespace ProyectoAndina.Utils
{
    public static class StylesAlertas
    {

        public static void MostrarExito(Form owner, string mensaje, string titulo = "¡Éxito!")
        {
            if (owner == null) return;

            // Crear un diálogo
            Guna2MessageDialog dialog = new Guna2MessageDialog
            {
                Caption = titulo,
                Text = mensaje,
                Style = MessageDialogStyle.Light,             // Fondo claro
                Icon = MessageDialogIcon.Information,         // Icono de éxito/info
                Buttons = MessageDialogButtons.OK,            // Solo botón OK
                Parent = owner                                // Centrado sobre el form principal
            };

            // Personalizar el botón OK
            // Se puede cambiar el color de todos los botones de manera indirecta
            dialog.Style = MessageDialogStyle.Light;          // Fondo oscuro para que contraste
            dialog.Icon = MessageDialogIcon.None;           // Si quieres un icono personalizado
            dialog.Text = mensaje;

            // Mostrar de manera modal (bloquea el form principal)
            dialog.Show();
        }

        public enum TipoAlerta
        {
            Success,
            Info,
            Error
        }

        // NUEVO MÉTODO DE CONFIRMACIÓN

        public static DialogResult MostrarConfirmacion(Form owner, string mensaje, string titulo = "Confirmar", TipoAlerta tipo = TipoAlerta.Info)
        {
            if (owner == null) return DialogResult.Cancel;

            Size tamaño = new Size(420, 230);

            // Form sin bordes
            Form dialogForm = new Form
            {
                Text = "",
                Size = tamaño,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.None,
                MaximizeBox = false,
                MinimizeBox = false,
                ShowInTaskbar = false,
                BackColor = Color.White,
                Font = new Font("Segoe UI", 9),
                TopMost = true,
                ShowIcon = false,
                KeyPreview = true
            };

            // 🎨 Colores según tipo
            Color colorHeader;
            FontAwesome.Sharp.IconChar iconoChar;
            switch (tipo)
            {
                case TipoAlerta.Success:
                    colorHeader = Color.FromArgb(40, 180, 99);
                    iconoChar = FontAwesome.Sharp.IconChar.CheckCircle;
                    break;
                case TipoAlerta.Info:
                    colorHeader = Color.FromArgb(52, 152, 219);
                    iconoChar = FontAwesome.Sharp.IconChar.InfoCircle;
                    break;
                case TipoAlerta.Error:
                    colorHeader = Color.FromArgb(231, 76, 60);
                    iconoChar = FontAwesome.Sharp.IconChar.ExclamationCircle;
                    break;
                default:
                    colorHeader = Color.Gray;
                    iconoChar = FontAwesome.Sharp.IconChar.QuestionCircle;
                    break;
            }

            // 🌈 Header
            Guna2GradientPanel headerPanel = new Guna2GradientPanel
            {
                Dock = DockStyle.Top,
                Height = 55,
                FillColor = colorHeader,
                FillColor2 = ControlPaint.Light(colorHeader, 0.2f),
                BorderRadius = 8,
                BackColor = Color.Transparent // 👈 elimina franja blanca
            };

            // Icono
            FontAwesome.Sharp.IconPictureBox icono = new FontAwesome.Sharp.IconPictureBox
            {
                IconChar = iconoChar,
                IconColor = Color.White,
                IconFont = FontAwesome.Sharp.IconFont.Auto,
                Size = new Size(28, 28),
                Location = new Point(15, 13),
                BackColor = Color.Transparent
            };

            // Título
            Label lblTitulo = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(55, 15),
                AutoSize = true,
                BackColor = Color.Transparent // 👈 evita franja blanca
            };

            // Mensaje
            Label lblMensaje = new Label
            {
                Text = mensaje,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(64, 64, 64),
                Location = new Point(20, 75),
                Size = new Size(tamaño.Width - 40, 70),
                AutoSize = false,
                BackColor = Color.Transparent
            };

            // Botón Sí
            Guna2Button btnSi = new Guna2Button
            {
                Text = "Sí",
                Size = new Size(90, 36),
                Location = new Point(tamaño.Width - 290, tamaño.Height - 60),
                BorderRadius = 8,
                FillColor = colorHeader,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };

            // Botón No
            Guna2Button btnNo = new Guna2Button
            {
                Text = "No",
                Size = new Size(90, 36),
                Location = new Point(tamaño.Width - 190, tamaño.Height - 60),
                BorderRadius = 8,
                FillColor = Color.Orange,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };

            // Botón Cancelar
            

            // Resultado
            DialogResult resultado = DialogResult.Cancel;

            btnSi.Click += (s, e) => { resultado = DialogResult.Yes; dialogForm.Close(); };
            btnNo.Click += (s, e) => { resultado = DialogResult.No; dialogForm.Close(); };

            dialogForm.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) { resultado = DialogResult.Yes; dialogForm.Close(); }
                if (e.KeyCode == Keys.Escape) { resultado = DialogResult.Cancel; dialogForm.Close(); }
            };

            // Ensamblar
            headerPanel.Controls.Add(icono);
            headerPanel.Controls.Add(lblTitulo);

            dialogForm.Controls.Add(headerPanel);
            dialogForm.Controls.Add(lblMensaje);
            dialogForm.Controls.Add(btnSi);
            dialogForm.Controls.Add(btnNo);

            // Bordes redondeados + sombra
            Guna2Elipse elipse = new Guna2Elipse { BorderRadius = 12, TargetControl = dialogForm };
            Guna2ShadowForm shadow = new Guna2ShadowForm { TargetForm = dialogForm };

            dialogForm.ShowDialog(owner);
            dialogForm.Dispose();

            return resultado;
        }


        // Función para calcular el tamaño dinámico del diálogo
        private static Size CalcularTamañoDialog(string mensaje, string titulo)
        {
            int anchoMinimo = 450;
            int altoMinimo = 160;

            // Calcular ancho basado en título y mensaje
            int anchoTitulo = TextRenderer.MeasureText(titulo, new Font("Segoe UI", 11, FontStyle.Bold)).Width + 100;
            int anchoMensaje = TextRenderer.MeasureText(mensaje, new Font("Segoe UI", 10)).Width + 60;

            int ancho = Math.Max(anchoMinimo, Math.Max(anchoTitulo, anchoMensaje));
            if (ancho > 600) ancho = 600; // Máximo ancho

            // Calcular alto basado en el mensaje
            var tamañoMensaje = TextRenderer.MeasureText(mensaje, new Font("Segoe UI", 10), new Size(ancho - 40, 0), TextFormatFlags.WordBreak);
            int alto = Math.Max(altoMinimo, tamañoMensaje.Height + 120);

            return new Size(ancho, alto);
        }

        // Configurar icono en el header
        private static void ConfigurarIconoHeader(PictureBox icono, TipoAlerta tipo)
        {
            switch (tipo)
            {
                case TipoAlerta.Success:
                    icono.Image = SystemIcons.Information.ToBitmap();
                    break;
                case TipoAlerta.Info:
                    icono.Image = SystemIcons.Question.ToBitmap();
                    break;
                case TipoAlerta.Error:
                    icono.Image = SystemIcons.Warning.ToBitmap();
                    break;
            }
        }

        // Configurar colores del botón Sí
        private static void ConfigurarBotonSi(Guna2Button btn, TipoAlerta tipo)
        {
            switch (tipo)
            {
                case TipoAlerta.Success:
                    btn.FillColor = Color.FromArgb(46, 204, 113);
                    btn.HoverState.FillColor = Color.FromArgb(39, 174, 96);
                    break;
                case TipoAlerta.Info:
                    btn.FillColor = Color.FromArgb(155, 126, 189); // Mismo color del header
                    btn.HoverState.FillColor = Color.FromArgb(135, 106, 169);
                    break;
                case TipoAlerta.Error:
                    btn.FillColor = Color.FromArgb(231, 76, 60);
                    btn.HoverState.FillColor = Color.FromArgb(192, 57, 43);
                    break;
            }
        }


        public static void MostrarAlerta(Form owner, string mensaje, string titulo = "",
                                  TipoAlerta tipo = TipoAlerta.Info, int duracionMs = 2000)
        {
            if (owner == null) return;

            // Configuración de colores e iconos según tipo
            Color colorFondo;
            FontAwesome.Sharp.IconChar iconoChar;

            switch (tipo)
            {
                case TipoAlerta.Success:
                    colorFondo = Color.FromArgb(40, 180, 99); // verde
                    iconoChar = FontAwesome.Sharp.IconChar.CheckCircle;
                    if (string.IsNullOrEmpty(titulo)) titulo = "¡Éxito!";
                    break;
                case TipoAlerta.Info:
                    colorFondo = Color.FromArgb(52, 152, 219); // azul
                    iconoChar = FontAwesome.Sharp.IconChar.InfoCircle;
                    if (string.IsNullOrEmpty(titulo)) titulo = "Información";
                    break;
                case TipoAlerta.Error:
                    colorFondo = Color.FromArgb(231, 76, 60); // rojo
                    iconoChar = FontAwesome.Sharp.IconChar.ExclamationCircle;
                    if (string.IsNullOrEmpty(titulo)) titulo = "¡Error!";
                    break;
                default:
                    colorFondo = Color.Gray;
                    iconoChar = FontAwesome.Sharp.IconChar.QuestionCircle;
                    break;
            }

            // Crear formulario popup
            Form alerta = new Form()
            {
                Size = new Size(350, 150),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.None,
                BackColor = colorFondo,
                TopMost = true,
                ShowInTaskbar = false,
                Opacity = 0.95
            };

            // Icono de alerta
            FontAwesome.Sharp.IconPictureBox icono = new FontAwesome.Sharp.IconPictureBox()
            {
                IconChar = iconoChar,
                IconColor = Color.White,
                IconFont = FontAwesome.Sharp.IconFont.Auto,
                Size = new Size(48, 48),
                SizeMode = PictureBoxSizeMode.CenterImage,
                Location = new Point(20, 50),
                BackColor = Color.Transparent
            };

            // Título
            Label lblTitulo = new Label()
            {
                Text = titulo,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(80, 20),
                Size = new Size(alerta.Width - 100, 30)
            };

            // Mensaje (con ajuste automático de altura si es largo)
            Label lblMensaje = new Label()
            {
                Text = mensaje,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                AutoSize = true, // 🔑 Permite crecer según el texto
                MaximumSize = new Size(alerta.Width - 100, 0), // ancho máximo, altura libre
                TextAlign = ContentAlignment.TopLeft,
                Location = new Point(80, 60)
            };

            // Medir alto requerido y ajustar el form si hace falta
            alerta.Controls.Add(lblMensaje); // se debe agregar antes para medir bien
            SizeF medida = TextRenderer.MeasureText(mensaje, lblMensaje.Font,
                                                    new Size(alerta.Width - 100, 0),
                                                    TextFormatFlags.WordBreak);
            int altoRequerido = (int)medida.Height + 100; // + espacio de título e icono
            alerta.Height = Math.Max(150, altoRequerido);

            // Reajustar lblMensaje según el nuevo tamaño
            lblMensaje.MaximumSize = new Size(alerta.Width - 100, alerta.Height - 80);

            // Agregar controles
            alerta.Controls.Add(icono);
            alerta.Controls.Add(lblTitulo);

            // Timer para cerrar automáticamente
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = duracionMs;
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                alerta.Close();
                alerta.Dispose();
            };
            timer.Start();

            // Mostrar modal centrado
            alerta.ShowDialog(owner);
        }

    }
}