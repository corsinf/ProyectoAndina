using Newtonsoft.Json;
using ProyectoAndina.Controllers;
using ProyectoAndina.Models;
using ProyectoAndina.Services;
using ProyectoAndina.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProyectoAndina.Utils.StylesAlertas;

namespace ProyectoAndina.Views
{
   
    public partial class CrearUsuario : Form
    {
        private readonly PersonaController _PersonaController;
        private readonly PersonaRolController _PersonaRolController;
        private readonly RolController _RolController;
        private readonly ApiService _apiService;
        private ValidacionHelper validador;
        private Form _formularioPadre;
        public CrearUsuario(Form formularioPadre, String cedula)
        {
            // Config típica de diálogo modal
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.TopMost = true;
            this.KeyPreview = false;
            InitializeComponent();
            StyleButton.CrearBotonElegante(button_agregar_usuario, FontAwesome.Sharp.IconChar.PlusCircle);

            _PersonaController = new PersonaController();
            _PersonaRolController = new PersonaRolController();
            _RolController = new RolController();
            _apiService = new ApiService();
            _formularioPadre = formularioPadre;
            validador = new ValidacionHelper(this);
            ConfigurarValidacion();
            textBox_cedula.Text = cedula;
            this.Paint += CrearUsuarioForm_Paint;
        }
        private void ConfigurarValidacion()
        {
            validador = new ValidacionHelper(this);
            validador.AgregarControlRequerido(textBox_cedula, "El campo cédula es requerido");
            validador.AgregarControlRequerido(textBox_nombre_completo, "El campo nombre es requerido");
            validador.AgregarControlRequerido(textBox_telefono, "El campo telefono es requerido");
            validador.AgregarControlRequerido(textBox_correo, "El campo correo es requerido");
            validador.AgregarControlRequerido(textBox_direccion, "El campo dirección es requerido");
        }

        private void CrearUsuarioForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }
        private async void button_agregar_usuario_Click(object sender, EventArgs e)
        {
            string cedula = textBox_cedula.Text.Trim();
            var usuarioEncontrado = _PersonaController.ObtenerPorCedula(cedula);

            if (usuarioEncontrado != null)
            {
                StylesAlertas.MostrarAlerta(this, "Usuario ya registrado con esa cédula", "¡Error!", TipoAlerta.Error);
            }
            //revisar sobre persona y rol
            if (!validador.ValidarTodosLosControles())
            {
                validador.MostrarMensajeValidacion();
                return;
            }


            try
            {
                var persona = new PersonaApiM
                {
                    primer_nombre = textBox_nombre_completo.Text.Trim(),
                    cedula = textBox_cedula.Text.Trim(),
                    correo = textBox_correo.Text.Trim(),
                    telefono_1 = textBox_telefono?.Text.Trim() ?? "",
                    direccion = textBox_direccion?.Text.Trim() ?? "",
                    observaciones = "Creado desde la aplicacion de escritorio"
                };


                var personaToken = _PersonaController.ObtenerPorId(SessionUser.PerId);

                if (persona != null)
                {
                    // Esperar el resultado del login
                    string loginResponse = await _apiService.LoginAsync(personaToken.correo, personaToken.password);

                    if (!string.IsNullOrEmpty(loginResponse) && !loginResponse.StartsWith("Error") && !loginResponse.StartsWith("Excepción"))
                    {
                        // Aquí normalmente viene un JSON con el token
                        // Ejemplo: { "token": "eyJhbGciOi..." }
                        var obj = JsonConvert.DeserializeObject<dynamic>(loginResponse);
                        string token = obj?.token;


                        if (!string.IsNullOrEmpty(token))
                        {
                            // ✅ Ya tienes el token. Ahora puedes usarlo para otra operación
                            string respuesta = await _apiService.CrearPersonaAsync(persona, token);

                            StylesAlertas.MostrarAlerta(this, "Registro actualizado correctamente", tipo: TipoAlerta.Success);

                            this.DialogResult = DialogResult.OK;

                            this.Close();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar usuario: " + ex.Message);
            }
        }



        private bool ValidarCamposPorNombre()
        {
            bool valido = true;

            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    string nombre = textBox.Name.ToLower();
                    string valor = textBox.Text.Trim();

                    // Validar nombre y apellido
                    if (nombre.Contains("nombre") || nombre.Contains("apellido"))
                    {
                        if (!Regex.IsMatch(valor, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
                        {
                            MessageBox.Show($"El campo '{textBox.Name}' solo debe contener letras.");
                            valido = false;
                        }
                    }

                    // Validar cédula (solo números)
                    if (nombre.Contains("cedula"))
                    {
                        if (!Regex.IsMatch(valor, @"^\d+$"))
                        {
                            MessageBox.Show("La cédula solo debe contener números.");
                            valido = false;
                        }
                    }

                    // Validar correo
                    if (nombre.Contains("correo") || nombre.Contains("gmail"))
                    {
                        if (!Regex.IsMatch(valor, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                        {
                            MessageBox.Show("El correo electrónico no es válido.");
                            valido = false;
                        }
                    }


                    // Validar teléfono (opcional: 10 dígitos)
                    if (nombre.Contains("telefono"))
                    {
                        if (!Regex.IsMatch(valor, @"^\d{7,10}$"))
                        {
                            MessageBox.Show("El teléfono debe tener entre 7 y 10 dígitos numéricos.");
                            valido = false;
                        }
                    }

                    // Validar dirección (no vacía)
                    if (nombre.Contains("direccion") && string.IsNullOrWhiteSpace(valor))
                    {
                        MessageBox.Show("La dirección no puede estar vacía.");
                        valido = false;
                    }
                }
            }

            return valido;
        }

        private void textBox_cedula_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();
        }

        private void textBox_pri_nombre_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();
        }

       

        private void textBox_correo_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();
        }

        private void textBox_telefono_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();
        }

        private void textBox_direccion_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();
        }
    }
}
