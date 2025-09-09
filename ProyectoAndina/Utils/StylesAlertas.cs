using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulpep.NotificationWindow;

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

        public static void MostrarAlerta(Form owner, string mensaje, string titulo = "", TipoAlerta tipo = TipoAlerta.Info, int duracionMs = 2000)
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

            // Mensaje
            Label lblMensaje = new Label()
            {
                Text = mensaje,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(80, 60),
                Size = new Size(alerta.Width - 100, 50)
            };

            alerta.Controls.Add(icono);
            alerta.Controls.Add(lblTitulo);
            alerta.Controls.Add(lblMensaje);

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
