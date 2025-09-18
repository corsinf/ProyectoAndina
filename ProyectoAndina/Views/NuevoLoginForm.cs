using ProyectoAndina.Controllers;
using ProyectoAndina.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoAndina.Views
{
    public partial class NuevoLoginForm : KioskForm
    {

        private readonly LoginController _loginController;
        private readonly PersonaRolController _PersonaRolController;
        public NuevoLoginForm()
        {
            _loginController = new LoginController();
            _PersonaRolController = new PersonaRolController();
            InitializeComponent();
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
            
        }
        

        

        private void BtnLogin_Click(object sender, EventArgs e)
        {

            //TecladoHelper.CerrarTeclado();
            //return;

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
                        TecladoHelper.CerrarTeclado();

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

            //TecladoHelper.CerrarTeclado();
        }
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            //TecladoHelper.CerrarTeclado();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try { TaskbarHelper.ShowTaskbar(); } catch { }

            //TecladoHelper.CerrarTeclado();

            base.OnFormClosing(e);
        }
    }
}
