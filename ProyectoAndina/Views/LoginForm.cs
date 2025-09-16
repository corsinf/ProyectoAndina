using ProyectoAndina.Controllers;
using ProyectoAndina.Utils; // Aquí agregas la referencia al StyleManager
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace ProyectoAndina.Views
{
    /* Para habilitar el diseñador */
    //public partial class LoginForm : Form

    /* Para habilitar lo del kiosko */
    public partial class LoginForm : KioskForm

    {
        private readonly LoginController _loginController;
        private readonly PersonaRolController _PersonaRolController;

        // Controles
        private Panel panelPrincipal;
        private Panel panelLogo;
        private Panel panelLogin;
        private Panel panelFormulario;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblCedula;
        private Label lblPassword;
        private TextBox txtCorreo;
        private TextBox txtPassword;
        private Button btnLogin;
        private PictureBox pictureBoxLogo;
        private Label lblMensaje;


        public LoginForm()
        {
            _loginController = new LoginController();
            _PersonaRolController = new PersonaRolController();
            InitializeComponent();

            ConfigurarEstilo();
        }

        private void InitializeComponent()
        {
            panelPrincipal = new Panel();
            panelLogo = new Panel();
            pictureBoxLogo = new PictureBox();
            panelLogin = new Panel();
            panelFormulario = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            lblCedula = new Label();
            txtCorreo = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            lblMensaje = new Label();
            panelPrincipal.SuspendLayout();
            panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            panelLogin.SuspendLayout();
            panelFormulario.SuspendLayout();
            SuspendLayout();
            // 
            // panelPrincipal
            // 
            panelPrincipal.Controls.Add(panelLogo);
            panelPrincipal.Controls.Add(panelLogin);
            panelPrincipal.Location = new Point(15, 15);
            panelPrincipal.Name = "panelPrincipal";
            panelPrincipal.Size = new Size(987, 627);
            panelPrincipal.TabIndex = 0;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(0, 71, 80);
            panelLogo.Controls.Add(pictureBoxLogo);
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(500, 627);
            panelLogo.TabIndex = 0;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor = Color.Transparent;
            pictureBoxLogo.Location = new Point(0, 0);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(300, 120);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;

            // 
            // panelLogin
            // 
            panelLogin.BackColor = Color.FromArgb(248, 249, 250);
            panelLogin.Controls.Add(panelFormulario);
            panelLogin.Location = new Point(500, 0);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(487, 627);
            panelLogin.TabIndex = 1;
            // 
            // panelFormulario
            // 
            panelFormulario.BackColor = Color.White;
            panelFormulario.Controls.Add(lblTitulo);
            panelFormulario.Controls.Add(lblSubtitulo);
            panelFormulario.Controls.Add(lblCedula);
            panelFormulario.Controls.Add(txtCorreo);
            panelFormulario.Controls.Add(lblPassword);
            panelFormulario.Controls.Add(txtPassword);
            panelFormulario.Controls.Add(btnLogin);
            panelFormulario.Controls.Add(lblMensaje);
            panelFormulario.Location = new Point(0, 0);
            panelFormulario.Name = "panelFormulario";
            panelFormulario.Size = new Size(484, 624);
            panelFormulario.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.Location = new Point(94, 50);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(300, 40);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "SISTEMA ANDINA";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.Location = new Point(94, 110);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(300, 25);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Bienvenido, ingresa tus credenciales";
            lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCedula
            // 
            lblCedula.Location = new Point(94, 167);
            lblCedula.Name = "lblCedula";
            lblCedula.Size = new Size(300, 37);
            lblCedula.TabIndex = 2;
            lblCedula.Text = "Correo Electrónico:";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(94, 215);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(300, 23);
            txtCorreo.TabIndex = 3;
            txtCorreo.Click += txtCorreo_Click;
            // 
            // lblPassword
            // 
            lblPassword.Location = new Point(94, 260);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(300, 30);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Contraseña:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(94, 306);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(300, 23);
            txtPassword.TabIndex = 5;
            txtPassword.Click += txtPassword_Click;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(94, 364);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(300, 59);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "INICIAR SESIÓN";
            btnLogin.Click += BtnLogin_Click;
            // 
            // lblMensaje
            // 
            lblMensaje.Location = new Point(94, 506);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(300, 86);
            lblMensaje.TabIndex = 8;
            lblMensaje.TextAlign = ContentAlignment.MiddleCenter;
            lblMensaje.Visible = false;
            // 
            // LoginForm
            // 
            ClientSize = new Size(1021, 668);
            ControlBox = false;
            Controls.Add(panelPrincipal);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema UASB - Iniciar Sesión";
            TopMost = true;
            WindowState = FormWindowState.Maximized;
            panelPrincipal.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            panelLogin.ResumeLayout(false);
            panelFormulario.ResumeLayout(false);
            panelFormulario.PerformLayout();
            ResumeLayout(false);
        }

        private void ConfigurarEstilo()
        {
            // Configurar el form principal con colores UASB
            StyleManager.ConfigurarFormPrincipal(this, "Sistema Andina - Iniciar Sesión");
            this.BackColor = StyleManager.Colors.GrisClaro;

            // Configurar panel principal con sombra
            StyleManager.ConfigurarPanel(panelFormulario, true);

            // Configurar labels con estilos UASB
            StyleManager.ConfigurarLabel(lblTitulo, TipoLabel.TituloMedio);
            StyleManager.ConfigurarLabel(lblSubtitulo, TipoLabel.CuerpoSmall);
            StyleManager.ConfigurarLabel(lblCedula, TipoLabel.Subtitulo);
            StyleManager.ConfigurarLabel(lblPassword, TipoLabel.Subtitulo);


            // Configurar TextBoxes con estilo UASB
            StyleManager.ConfigurarTextBox(txtCorreo, "ejemplo@correo.com");
            StyleManager.ConfigurarTextBox(txtPassword, "Ingresa tu contraseña");

            // Configurar botones con estilos UASB
            StyleManager.ConfigurarBotonPrincipal(btnLogin);

            // Configurar el panel con logo
            ConfigurarPanelLogo();

            // Hacer responsive
            this.Resize += LoginForm_Resize;

            // Configurar eventos adicionales
            ConfigurarEventos();

            // Sombra para panel principal (mantener tu estilo original mejorado)
            panelPrincipal.Paint += (s, e) =>
            {
                // Sombra más suave
                using (var shadowBrush = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
                {
                    e.Graphics.FillRectangle(shadowBrush, 3, 3, panelPrincipal.Width, panelPrincipal.Height);
                }
                // Borde
                using (var borderPen = new Pen(StyleManager.Colors.GrisMedio, 1))
                {
                    e.Graphics.DrawRectangle(borderPen, 0, 0, panelPrincipal.Width - 1, panelPrincipal.Height - 1);
                }
            };
        }

        private void ConfigurarPanelLogo()
        {
            // Fondo degradado
            panelLogo.Paint += (sender, e) =>
            {
                using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                    panelLogo.ClientRectangle,
                    StyleManager.Colors.VerdeUASB,
                    StyleManager.Colors.VerdeMedioUASB,
                    45f))
                {
                    e.Graphics.FillRectangle(brush, panelLogo.ClientRectangle);
                }
            };

            // Cargar logo desde recursos
            pictureBoxLogo.Image = Properties.Resources.Logotipo_un_color; // 👈 tu logo aquí
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.BackColor = Color.Transparent;
            pictureBoxLogo.Dock = DockStyle.Fill; // que ocupe todo el panel
        }


        private void CentrarLogo()
        {
            if (panelLogo != null && pictureBoxLogo != null)
            {
                pictureBoxLogo.Location = new Point(
                    (panelLogo.Width - pictureBoxLogo.Width) / 2,
                    (panelLogo.Height - pictureBoxLogo.Height) / 2
                );
            }
        }

        private void ConfigurarEventos()
        {
            // Evento Enter en los TextBox para navegación y login
            txtCorreo.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPassword.Focus();
                }
            };

            txtPassword.KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    BtnLogin_Click(btnLogin, EventArgs.Empty);
                }
            };

            // Evento para ocultar mensajes al escribir
            txtCorreo.TextChanged += (sender, e) => StyleManager.OcultarMensaje(lblMensaje);
            txtPassword.TextChanged += (sender, e) => StyleManager.OcultarMensaje(lblMensaje);
        }

        private void LoginForm_Resize(object sender, EventArgs e)
        {
            // Mantener proporciones responsive
            if (panelPrincipal != null)
            {
                int totalWidth = this.ClientSize.Width - 30; // Margen de 15 px cada lado
                int totalHeight = this.ClientSize.Height - 30;

                panelPrincipal.Size = new Size(totalWidth, totalHeight);

                // Ajustar paneles internos
                panelLogo.Size = new Size(totalWidth / 2, totalHeight);
                panelLogin.Location = new Point(totalWidth / 2, 0);
                panelLogin.Size = new Size(totalWidth / 2, totalHeight);

                // Centrar panel de formulario
                if (panelFormulario != null)
                {
                    panelFormulario.Location = new Point(
                        (panelLogin.Width - panelFormulario.Width) / 2,
                        (panelLogin.Height - panelFormulario.Height) / 2
                    );
                }

                // Recentrar logo
                CentrarLogo();
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            StyleManager.OcultarMensaje(lblMensaje);

            // Validar que no sean placeholders
            string correo = txtCorreo.Text.Trim();
            string password = txtPassword.Text;

            if (correo == "ejemplo@correo.com" || string.IsNullOrEmpty(correo) ||
                password == "Ingresa tu contraseña" || string.IsNullOrEmpty(password))
            {
                StyleManager.MostrarError(lblMensaje, "Por favor ingrese correo y contraseña");
                return;
            }

            try
            {
                // Cambiar estado del botón
                btnLogin.Enabled = false;
                btnLogin.Text = "Verificando...";

                var Persona = _loginController.Autenticar(correo, password);

                if (Persona == null)
                {
                    StyleManager.MostrarError(lblMensaje, "No existe ninguna persona con esos datos");
                    return;
                }

                if (Persona.EsValido)
                {
                    var lista = _PersonaRolController.ObtenerPersonaRolValidacacion(Persona.per_id);
                    var personaRol = lista.FirstOrDefault();

                    if (personaRol != null)
                    {
                        var id = personaRol.IdPersonaRol;
                        SessionUser.id_persona_rol = personaRol.IdPersonaRol;
                    }

                    SessionUser.PerId = Persona.per_id;
                    SessionUser.NombreCompleto = Persona.nombre_completo;
                    SessionUser.Correo = Persona.correo;

                    StyleManager.MostrarExito(lblMensaje, "Inicio de sesión exitoso");


                    // Pequeña pausa para mostrar mensaje de éxito

                    // Timer de WinForms
                    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                    timer.Interval = 1000; // 1 segundo
                    timer.Tick += (s, args) =>
                    {
                        timer.Stop(); // detener el timer después de ejecutarse
                        var menuPrincipalForm = new MenuPrincipalForm();
                        this.Hide();
                        menuPrincipalForm.ShowDialog();
                        this.Close();
                    };
                    timer.Start();

                }
                else
                {
                    StyleManager.MostrarError(lblMensaje, "Correo o contraseña incorrecta");
                    txtPassword.Clear();
                    txtCorreo.Focus();
                }
            }
            catch (Exception ex)
            {
                StyleManager.MostrarError(lblMensaje, "Error al conectar con la base de datos");
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "INICIAR SESIÓN";
            }
        }

        private void txtCorreo_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();
        }


        /*
         * Logica para el la barra de tareas y bloquear la pantalla
         * **/

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Activa el tap secreto sobre el logo
            SetSecretExit(pictureBoxLogo, taps: 7, window: TimeSpan.FromSeconds(5));
            txtCorreo.Focus();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try { TaskbarHelper.ShowTaskbar(); } catch { }
            base.OnFormClosing(e);
        }

    }
}