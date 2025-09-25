using Newtonsoft.Json;
using ProyectoAndina.Controllers;
using ProyectoAndina.Models;
using ProyectoAndina.Services;
using ProyectoAndina.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProyectoAndina.Utils.StylesAlertas;

namespace ProyectoAndina.Views
{
    public partial class NuevoLoginForm : Form
    {

        private readonly LoginController _loginController;
        private readonly PersonaRolController _PersonaRolController;
        private readonly PersonaController _PersonaController;
        private readonly ApiService _apiService;
        private readonly FuncionesJson _FuncionesJson;
        private readonly CajaController _CajaController;

        public NuevoLoginForm()
        {
            _loginController = new LoginController();
            _PersonaRolController = new PersonaRolController();
            _PersonaController = new PersonaController();
            _apiService = new ApiService();
            _FuncionesJson = new FuncionesJson();
            _CajaController = new CajaController();
            InitializeComponent();
            

        }




        private async void BtnLogin_Click(object sender, EventArgs e)
        {

            

            string correo = txtCorreo.Text.Trim();
            string password = txtPassword.Text;

            if (correo == "ejemplo@correo.com" || string.IsNullOrEmpty(correo) ||
                password == "Ingresa tu contraseña" || string.IsNullOrEmpty(password))
            {
                StylesAlertas.MostrarAlerta(this, "Por favor ingrese correo y contraseña", "¡Error!", TipoAlerta.Error);
                return;
            }
            int cajaConfig = _FuncionesJson.CargarCajaDesdeConfig();
            var arqueoCaja = _CajaController.ObtenerPorId(cajaConfig);

            string MacAdrres = _FuncionesJson.GetMacAddress();

            if (arqueoCaja == null)
            {
                StylesAlertas.MostrarAlerta(this, "No existe esa caja", "¡Error!", TipoAlerta.Error);
                return;
            }

            try
            {

                // Esperar el resultado del login

                string loginResponse = await _apiService.LoginAsync(correo, password, MacAdrres);

                if (loginResponse.StartsWith("Error"))
                {
                    string mensajeError = "Error desconocido";

                    // Buscar el mensaje entre "error":" y "}
                    int inicioError = loginResponse.IndexOf("\"error\":\"");
                    if (inicioError != -1)
                    {
                        inicioError += 9; // Saltar "error":"
                        int finError = loginResponse.IndexOf("\"", inicioError);
                        if (finError != -1)
                        {
                            mensajeError = loginResponse.Substring(inicioError, finError - inicioError);
                        }
                    }

                    StylesAlertas.MostrarAlerta(this, mensajeError, "¡Error!", TipoAlerta.Error);
                    return;
                }

                if (!string.IsNullOrEmpty(loginResponse) && !loginResponse.StartsWith("Error") && !loginResponse.StartsWith("Excepción"))
                {
                    var obj = JsonConvert.DeserializeObject<dynamic>(loginResponse);
                    string token = obj?.token;

                    if (!string.IsNullOrEmpty(token))
                    {
                        btnLogin.Enabled = false;
                        btnLogin.Text = "Verificando...";
                        var datosToken = ApiService.DecodeJwtPayload(token);
                        var objDatosToken = JsonConvert.DeserializeObject<dynamic>(datosToken);

                        SessionUser.PerId = objDatosToken.per_id;
                        SessionUser.NombreCompleto = objDatosToken.name;
                        SessionUser.Correo = objDatosToken.email;
                        SessionUser.Rol = objDatosToken.role;
                        SessionUser.Mac = MacAdrres;
                        int per_id = objDatosToken.per_id;
                        var lista = _PersonaRolController.ObtenerPersonaRolValidacacion(per_id);
                        var personaRol = lista.FirstOrDefault();
                        if (personaRol != null)
                        {
                            SessionUser.id_persona_rol = personaRol.IdPersonaRol;
                        }
                       
                        TecladoHelper.CerrarTeclado();

                        var NuevoMenuForm = new NuevoMenuForm();
                        this.Hide();
                        NuevoMenuForm.ShowDialog();
                        this.Close();

                    }
                    else
                    {
                        StylesAlertas.MostrarAlerta(this, "Correo o contraseña incorrecta", "¡Error!", TipoAlerta.Error);
                        txtPassword.Clear();
                        txtCorreo.Focus();
                    }
                }




            }
            catch (Exception ex)
            {
               
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
            //SetSecretExit(pictureBoxLogo, taps: 7, window: TimeSpan.FromSeconds(5));
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

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
