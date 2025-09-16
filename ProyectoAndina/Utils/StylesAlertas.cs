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

            // Calcular tamaño dinámico según el mensaje
            Size tamaño = CalcularTamañoDialog(mensaje, titulo);

            // Crear form con el estilo exacto de Guna2MessageDialog
            Form dialogForm = new Form
            {
                Text = "",
                Size = tamaño,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.None,
                MaximizeBox = false,
                MinimizeBox = false,
                ShowInTaskbar = false,
                Owner = owner,
                BackColor = Color.FromArgb(240, 240, 240), // Color de fondo como Guna2
                Font = new Font("Segoe UI", 9)
            };

            // Panel principal con el estilo exacto de Guna2MessageDialog
            Guna2Panel panelPrincipal = new Guna2Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                BorderRadius = 8,
                BorderThickness = 1,
                BorderColor = Color.FromArgb(213, 218, 223),
            };

            // Header panel (parte superior morada como en tu imagen)
            Guna2Panel headerPanel = new Guna2Panel
            {
                Size = new Size(tamaño.Width - 2, 50),
                Location = new Point(1, 1),
                BackColor = Color.FromArgb(155, 126, 189), // Color morado del header
                BorderRadius = 8
            };

            // Título en el header
            Label lblTitulo = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(45, 15),
                Size = new Size(tamaño.Width - 100, 25),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // Icono en el header
            PictureBox iconoHeader = new PictureBox
            {
                Location = new Point(15, 13),
                Size = new Size(24, 24),
                SizeMode = PictureBoxSizeMode.CenterImage,
                BackColor = Color.Transparent
            };

            // Botón X para cerrar
            Guna2Button btnCerrar = new Guna2Button
            {
                Text = "×",
                Size = new Size(25, 25),
                Location = new Point(tamaño.Width - 35, 12),
                FillColor = Color.Transparent,
                HoverState = { FillColor = Color.FromArgb(200, 200, 200) },
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.White,
                BorderRadius = 4,
                Cursor = Cursors.Hand
            };

            // Configurar icono según tipo
            ConfigurarIconoHeader(iconoHeader, tipo);

            // Mensaje principal
            Label lblMensaje = new Label
            {
                Text = mensaje,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(64, 64, 64),
                Location = new Point(20, 70),
                Size = new Size(tamaño.Width - 40, tamaño.Height - 140),
                TextAlign = ContentAlignment.TopLeft,
                AutoSize = false
            };

            // Botón Sí con colores según el tipo
            Guna2Button btnSi = new Guna2Button
            {
                Text = "Sí",
                Size = new Size(80, 35),
                Location = new Point(tamaño.Width - 180, tamaño.Height - 50),
                BorderRadius = 6,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };

            // Botón Cancelar
            Guna2Button btnCancelar = new Guna2Button
            {
                Text = "Cancelar",
                Size = new Size(80, 35),
                Location = new Point(tamaño.Width - 90, tamaño.Height - 50),
                BorderRadius = 6,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(64, 64, 64),
                FillColor = Color.FromArgb(240, 240, 240),
                BorderThickness = 1,
                BorderColor = Color.FromArgb(213, 218, 223),
                Cursor = Cursors.Hand
            };

            // Configurar colores del botón Sí según el tipo
            ConfigurarBotonSi(btnSi, tipo);

            // Variable para el resultado
            DialogResult resultado = DialogResult.Cancel;

            // Eventos
            btnSi.Click += (s, e) => {
                resultado = DialogResult.Yes;
                dialogForm.Close();
            };

            btnCancelar.Click += (s, e) => {
                resultado = DialogResult.Cancel;
                dialogForm.Close();
            };

            btnCerrar.Click += (s, e) => {
                resultado = DialogResult.Cancel;
                dialogForm.Close();
            };

            // Eventos de teclado
            dialogForm.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Enter)
                {
                    resultado = DialogResult.Yes;
                    dialogForm.Close();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    resultado = DialogResult.Cancel;
                    dialogForm.Close();
                }
            };

            dialogForm.KeyPreview = true;

            // Ensamblar controles
            headerPanel.Controls.Add(lblTitulo);
            headerPanel.Controls.Add(iconoHeader);
            headerPanel.Controls.Add(btnCerrar);

            panelPrincipal.Controls.Add(headerPanel);
            panelPrincipal.Controls.Add(lblMensaje);
            panelPrincipal.Controls.Add(btnSi);
            panelPrincipal.Controls.Add(btnCancelar);

            dialogForm.Controls.Add(panelPrincipal);

            // Mostrar y devolver resultado
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