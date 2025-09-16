// Views/RecuperarPasswordForm.cs
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ProyectoAndina.Controllers;

namespace ProyectoAndina.Views
{
    public partial class RecuperarPasswordForm : Form
    {
        private readonly PersonaController _personaController;

        // Controles
        private Panel panelPrincipal;
        private Panel panelFormulario;
        private PictureBox pictureBoxIcon;
        private Label lblTitulo;
        private Label lblInstrucciones;
        private Label lblCorreo;
        private TextBox txtCorreo;
        private Button btnEnviar;
        private Button btnCancelar;
        private Button btnVolverLogin;
        private Label lblMensaje;
        private ProgressBar progressBar;

        // Estados del formulario
        private enum EstadoFormulario
        {
            SolicitarCorreo,
            Procesando,
            Completado
        }

        public RecuperarPasswordForm()
        {
            _personaController = new PersonaController();
            InitializeComponent();
            ConfigurarEstilo();
            EstablecerEstado(EstadoFormulario.SolicitarCorreo);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Configuración del formulario
            this.Text = "Sistema Andina - Recuperar Contraseña";
            this.Size = new Size(500, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(236, 240, 241);

            // Panel principal
            panelPrincipal = new Panel();
            panelPrincipal.Size = new Size(460, 500);
            panelPrincipal.Location = new Point(20, 20);
            panelPrincipal.BackColor = Color.White;

            // Panel del formulario
            panelFormulario = new Panel();
            panelFormulario.Size = new Size(400, 450);
            panelFormulario.Location = new Point(30, 25);
            panelFormulario.BackColor = Color.White;

            int yPosition = 20;

            // Icono
            pictureBoxIcon = new PictureBox();
            pictureBoxIcon.Size = new Size(80, 80);
            pictureBoxIcon.Location = new Point(160, yPosition);
            pictureBoxIcon.BackColor = Color.FromArgb(52, 152, 219);
            pictureBoxIcon.BorderStyle = BorderStyle.None;
            // Aquí podrías agregar un icono de candado o email
            yPosition += 100;

            // Título
            lblTitulo = new Label();
            lblTitulo.Text = "RECUPERAR CONTRASEÑA";
            lblTitulo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(52, 73, 94);
            lblTitulo.Location = new Point(50, yPosition);
            lblTitulo.Size = new Size(300, 35);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            yPosition += 50;

            // Instrucciones
            lblInstrucciones = new Label();
            lblInstrucciones.Text = "Ingrese su correo electrónico registrado. Le enviaremos una nueva contraseña temporal.";
            lblInstrucciones.Font = new Font("Segoe UI", 10);
            lblInstrucciones.ForeColor = Color.FromArgb(127, 140, 141);
            lblInstrucciones.Location = new Point(20, yPosition);
            lblInstrucciones.Size = new Size(360, 50);
            lblInstrucciones.TextAlign = ContentAlignment.MiddleCenter;
            yPosition += 70;

            // Label Correo
            lblCorreo = new Label();
            lblCorreo.Text = "Correo Electrónico:";
            lblCorreo.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblCorreo.ForeColor = Color.FromArgb(52, 73, 94);
            lblCorreo.Location = new Point(30, yPosition);
            lblCorreo.Size = new Size(200, 25);
            yPosition += 30;

            // TextBox Correo
            txtCorreo = new TextBox();
            txtCorreo.Font = new Font("Segoe UI", 12);
            txtCorreo.Location = new Point(30, yPosition);
            txtCorreo.Size = new Size(340, 35);
            txtCorreo.BorderStyle = BorderStyle.FixedSingle;
            txtCorreo.KeyPress += TxtCorreo_KeyPress;
            yPosition += 50;

            // ProgressBar (inicialmente oculto)
            progressBar = new ProgressBar();
            progressBar.Location = new Point(30, yPosition);
            progressBar.Size = new Size(340, 10);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.Visible = false;
            yPosition += 30;

            // Mensaje
            lblMensaje = new Label();
            lblMensaje.Font = new Font("Segoe UI", 10);
            lblMensaje.Location = new Point(30, yPosition);
            lblMensaje.Size = new Size(340, 40);
            lblMensaje.TextAlign = ContentAlignment.MiddleCenter;
            yPosition += 50;

            // Botón Enviar
            btnEnviar = new Button();
            btnEnviar.Text = "ENVIAR NUEVA CONTRASEÑA";
            btnEnviar.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnEnviar.BackColor = Color.FromArgb(52, 152, 219);
            btnEnviar.ForeColor = Color.White;
            btnEnviar.Location = new Point(30, yPosition);
            btnEnviar.Size = new Size(340, 45);
            btnEnviar.FlatStyle = FlatStyle.Flat;
            btnEnviar.FlatAppearance.BorderSize = 0;
            btnEnviar.Cursor = Cursors.Hand;
            btnEnviar.Click += BtnEnviar_Click;
            yPosition += 60;

            // Botón Cancelar
            btnCancelar = new Button();
            btnCancelar.Text = "CANCELAR";
            btnCancelar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnCancelar.BackColor = Color.FromArgb(149, 165, 166);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(30, yPosition);
            btnCancelar.Size = new Size(160, 40);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Click += BtnCancelar_Click;

            // Botón Volver al Login
            btnVolverLogin = new Button();
            btnVolverLogin.Text = "VOLVER AL LOGIN";
            btnVolverLogin.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnVolverLogin.BackColor = Color.FromArgb(46, 204, 113);
            btnVolverLogin.ForeColor = Color.White;
            btnVolverLogin.Location = new Point(210, yPosition);
            btnVolverLogin.Size = new Size(160, 40);
            btnVolverLogin.FlatStyle = FlatStyle.Flat;
            btnVolverLogin.FlatAppearance.BorderSize = 0;
            btnVolverLogin.Cursor = Cursors.Hand;
            btnVolverLogin.Click += BtnVolverLogin_Click;

            // Agregar controles al panel del formulario
            panelFormulario.Controls.AddRange(new Control[] {
                pictureBoxIcon, lblTitulo, lblInstrucciones, lblCorreo, txtCorreo,
                progressBar, lblMensaje, btnEnviar, btnCancelar, btnVolverLogin
            });

            panelPrincipal.Controls.Add(panelFormulario);
            this.Controls.Add(panelPrincipal);

            this.ResumeLayout(false);
        }

        private void ConfigurarEstilo()
        {
            // Agregar sombra al panel principal
            panelPrincipal.Paint += (s, e) =>
            {
                var rect = panelPrincipal.ClientRectangle;
                rect.Width -= 1;
                rect.Height -= 1;
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(189, 195, 199), 2), rect);
            };

            // Efectos hover para botones
            btnEnviar.MouseEnter += (s, e) => btnEnviar.BackColor = Color.FromArgb(41, 128, 185);
            btnEnviar.MouseLeave += (s, e) => btnEnviar.BackColor = Color.FromArgb(52, 152, 219);

            btnCancelar.MouseEnter += (s, e) => btnCancelar.BackColor = Color.FromArgb(127, 140, 141);
            btnCancelar.MouseLeave += (s, e) => btnCancelar.BackColor = Color.FromArgb(149, 165, 166);

            btnVolverLogin.MouseEnter += (s, e) => btnVolverLogin.BackColor = Color.FromArgb(39, 174, 96);
            btnVolverLogin.MouseLeave += (s, e) => btnVolverLogin.BackColor = Color.FromArgb(46, 204, 113);

            // Efecto focus en el textbox
            txtCorreo.Enter += (s, e) => txtCorreo.BackColor = Color.FromArgb(250, 250, 250);
            txtCorreo.Leave += (s, e) => txtCorreo.BackColor = Color.White;
        }

        private void EstablecerEstado(EstadoFormulario estado)
        {
            switch (estado)
            {
                case EstadoFormulario.SolicitarCorreo:
                    txtCorreo.Enabled = true;
                    btnEnviar.Enabled = true;
                    btnEnviar.Text = "ENVIAR NUEVA CONTRASEÑA";
                    btnCancelar.Visible = true;
                    btnVolverLogin.Visible = false;
                    progressBar.Visible = false;
                    lblMensaje.Text = "";
                    pictureBoxIcon.BackColor = Color.FromArgb(52, 152, 219);
                    break;

                case EstadoFormulario.Procesando:
                    txtCorreo.Enabled = false;
                    btnEnviar.Enabled = false;
                    btnEnviar.Text = "ENVIANDO...";
                    btnCancelar.Visible = false;
                    btnVolverLogin.Visible = false;
                    progressBar.Visible = true;
                    lblMensaje.Text = "Procesando solicitud...";
                    lblMensaje.ForeColor = Color.FromArgb(52, 152, 219);
                    break;

                case EstadoFormulario.Completado:
                    txtCorreo.Enabled = false;
                    btnEnviar.Visible = false;
                    btnCancelar.Visible = false;
                    btnVolverLogin.Visible = true;
                    progressBar.Visible = false;
                    pictureBoxIcon.BackColor = Color.FromArgb(46, 204, 113);
                    break;
            }
        }

        private void TxtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnEnviar_Click(btnEnviar, EventArgs.Empty);
            }
        }

        private bool ValidarCorreo(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo))
            {
                MostrarError("Por favor ingrese su correo electrónico");
                return false;
            }

            try
            {
                var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                if (!regex.IsMatch(correo))
                {
                    MostrarError("Por favor ingrese un correo electrónico válido");
                    return false;
                }
            }
            catch
            {
                MostrarError("Formato de correo inválido");
                return false;
            }

            return true;
        }

        private void MostrarError(string mensaje)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = Color.FromArgb(231, 76, 60);
        }

        private void MostrarExito(string mensaje)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = Color.FromArgb(46, 204, 113);
        }

        private async void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (!ValidarCorreo(txtCorreo.Text.Trim())) return;

            try
            {
                EstablecerEstado(EstadoFormulario.Procesando);

                // Simular procesamiento
                await System.Threading.Tasks.Task.Delay(2000);

                string token;
                bool resultado = true;
                //_personaController.GenerarTokenRecuperacion(txtCorreo.Text.Trim().ToLower(), out token);

                if (resultado)
                {
                    EstablecerEstado(EstadoFormulario.Completado);
                    MostrarExito($"¡Correo enviado exitosamente!\n\nSe ha enviado una nueva contraseña temporal a {txtCorreo.Text}.\n\nPor favor revise su bandeja de entrada y spam.");

                    lblInstrucciones.Text = "Nueva contraseña enviada correctamente. Use la contraseña temporal para iniciar sesión y luego cámbiela por una de su preferencia.";
                    lblInstrucciones.ForeColor = Color.FromArgb(46, 204, 113);
                }
                else
                {
                    EstablecerEstado(EstadoFormulario.SolicitarCorreo);
                    MostrarError("El correo electrónico no está registrado en el sistema.\n\nVerifique que sea correcto o contacte al administrador.");
                    txtCorreo.Focus();
                    txtCorreo.SelectAll();
                }
            }
            catch (Exception ex)
            {
                EstablecerEstado(EstadoFormulario.SolicitarCorreo);
                MostrarError($"Error al procesar la solicitud:\n{ex.Message}");
                txtCorreo.Focus();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
                "¿Está seguro que desea cancelar la recuperación de contraseña?",
                "Confirmar Cancelación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void BtnVolverLogin_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}