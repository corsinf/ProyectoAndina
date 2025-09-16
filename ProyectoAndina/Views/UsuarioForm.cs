using Newtonsoft.Json;
using ProyectoAndina.Controllers;
using ProyectoAndina.Models;
using ProyectoAndina.Services;
using ProyectoAndina.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static ProyectoAndina.Utils.StylesAlertas;

namespace ProyectoAndina.Views
{
    public partial class UsuarioForm : Form
    {
        private readonly PersonaController _PersonaController;
        private readonly PersonaRolController _PersonaRolController;
        private readonly RolController _RolController;
        private readonly ApiService _apiService;
        private Form _formularioPadre;

        public UsuarioForm(Form formularioPadre)
        {
            _PersonaController = new PersonaController();
            _PersonaRolController = new PersonaRolController();
            _RolController = new RolController();
            _apiService = new ApiService();
            _formularioPadre = formularioPadre;

            this.Paint += UsuarioForm_Paint;
            this.DoubleBuffered = true;
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            // Mantener visible solo el botón de cerrar
            this.ControlBox = true;

            InitializeComponent();
        }

        private void UsuarioForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }

        private void InitializeComponent()
        {
            pictureBox_logo_tipo = new PictureBox();
            panel_titulo = new Panel();
            button_agregar_usuario = new Button();
            textBox_cedula = new TextBox();
            label_cedula = new Label();
            textBox_correo = new TextBox();
            label_gmail = new Label();
            textBox_direccion = new TextBox();
            label_direccion = new Label();
            textBox_telefono = new TextBox();
            label_telefono = new Label();
            textBox_pri_apellido = new TextBox();
            textBox_pri_nombre = new TextBox();
            label_apellido = new Label();
            label_nombre = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_tipo).BeginInit();
            panel_titulo.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox_logo_tipo
            // 
            pictureBox_logo_tipo.BackColor = Color.White;
            pictureBox_logo_tipo.Image = Properties.Resources.Logotipo_color;
            pictureBox_logo_tipo.Location = new Point(12, 32);
            pictureBox_logo_tipo.Name = "pictureBox_logo_tipo";
            pictureBox_logo_tipo.Size = new Size(391, 62);
            pictureBox_logo_tipo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_logo_tipo.TabIndex = 65;
            pictureBox_logo_tipo.TabStop = false;
            // 
            // panel_titulo
            // 
            panel_titulo.BackColor = Color.Transparent;
            panel_titulo.Controls.Add(button_agregar_usuario);
            panel_titulo.Controls.Add(textBox_cedula);
            panel_titulo.Controls.Add(label_cedula);
            panel_titulo.Controls.Add(textBox_correo);
            panel_titulo.Controls.Add(label_gmail);
            panel_titulo.Controls.Add(textBox_direccion);
            panel_titulo.Controls.Add(label_direccion);
            panel_titulo.Controls.Add(textBox_telefono);
            panel_titulo.Controls.Add(label_telefono);
            panel_titulo.Controls.Add(textBox_pri_apellido);
            panel_titulo.Controls.Add(textBox_pri_nombre);
            panel_titulo.Controls.Add(label_apellido);
            panel_titulo.Controls.Add(label_nombre);
            panel_titulo.Location = new Point(12, 100);
            panel_titulo.Name = "panel_titulo";
            panel_titulo.Size = new Size(391, 451);
            panel_titulo.TabIndex = 80;
            // 
            // button_agregar_usuario
            // 
            button_agregar_usuario.BackColor = Color.FromArgb(52, 152, 219);
            button_agregar_usuario.Cursor = Cursors.Hand;
            button_agregar_usuario.FlatAppearance.BorderSize = 0;
            button_agregar_usuario.FlatStyle = FlatStyle.Flat;
            button_agregar_usuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_agregar_usuario.ForeColor = Color.White;
            button_agregar_usuario.Location = new Point(119, 396);
            button_agregar_usuario.Name = "button_agregar_usuario";
            button_agregar_usuario.Size = new Size(145, 40);
            button_agregar_usuario.TabIndex = 27;
            button_agregar_usuario.Text = "Accion";
            button_agregar_usuario.UseVisualStyleBackColor = false;
            button_agregar_usuario.Click += button_agregar_usuario_Click;
            // 
            // textBox_cedula
            // 
            textBox_cedula.Location = new Point(13, 40);
            textBox_cedula.Name = "textBox_cedula";
            textBox_cedula.Size = new Size(358, 27);
            textBox_cedula.TabIndex = 26;
            textBox_cedula.Click += textBox_cedula_Click;
            // 
            // label_cedula
            // 
            label_cedula.AutoSize = true;
            label_cedula.Location = new Point(13, 12);
            label_cedula.Name = "label_cedula";
            label_cedula.Size = new Size(58, 20);
            label_cedula.TabIndex = 25;
            label_cedula.Text = "Cedula:";
            // 
            // textBox_correo
            // 
            textBox_correo.Location = new Point(14, 166);
            textBox_correo.Name = "textBox_correo";
            textBox_correo.Size = new Size(357, 27);
            textBox_correo.TabIndex = 24;
            textBox_correo.Click += textBox_correo_Click;
            // 
            // label_gmail
            // 
            label_gmail.AutoSize = true;
            label_gmail.Location = new Point(14, 138);
            label_gmail.Name = "label_gmail";
            label_gmail.Size = new Size(57, 20);
            label_gmail.TabIndex = 23;
            label_gmail.Text = "Correo:";
            // 
            // textBox_direccion
            // 
            textBox_direccion.Location = new Point(13, 292);
            textBox_direccion.Name = "textBox_direccion";
            textBox_direccion.Size = new Size(358, 27);
            textBox_direccion.TabIndex = 22;
            textBox_direccion.Click += textBox_direccion_Click;
            // 
            // label_direccion
            // 
            label_direccion.AutoSize = true;
            label_direccion.Location = new Point(13, 264);
            label_direccion.Name = "label_direccion";
            label_direccion.Size = new Size(75, 20);
            label_direccion.TabIndex = 21;
            label_direccion.Text = "Dirección:";
            // 
            // textBox_telefono
            // 
            textBox_telefono.Location = new Point(13, 229);
            textBox_telefono.Name = "textBox_telefono";
            textBox_telefono.Size = new Size(358, 27);
            textBox_telefono.TabIndex = 20;
            textBox_telefono.Click += textBox_telefono_Click;
            // 
            // label_telefono
            // 
            label_telefono.AutoSize = true;
            label_telefono.Location = new Point(13, 201);
            label_telefono.Name = "label_telefono";
            label_telefono.Size = new Size(70, 20);
            label_telefono.TabIndex = 19;
            label_telefono.Text = "Telefono:";
            // 
            // textBox_pri_apellido
            // 
            textBox_pri_apellido.Location = new Point(195, 103);
            textBox_pri_apellido.Name = "textBox_pri_apellido";
            textBox_pri_apellido.Size = new Size(176, 27);
            textBox_pri_apellido.TabIndex = 11;
            textBox_pri_apellido.Click += textBox_pri_apellido_Click;
            // 
            // textBox_pri_nombre
            // 
            textBox_pri_nombre.Location = new Point(13, 103);
            textBox_pri_nombre.Name = "textBox_pri_nombre";
            textBox_pri_nombre.Size = new Size(176, 27);
            textBox_pri_nombre.TabIndex = 10;
            textBox_pri_nombre.Click += textBox_pri_nombre_Click;
            // 
            // label_apellido
            // 
            label_apellido.AutoSize = true;
            label_apellido.Location = new Point(195, 75);
            label_apellido.Name = "label_apellido";
            label_apellido.Size = new Size(69, 20);
            label_apellido.TabIndex = 9;
            label_apellido.Text = "Apellido:";
            // 
            // label_nombre
            // 
            label_nombre.AutoSize = true;
            label_nombre.Location = new Point(13, 75);
            label_nombre.Name = "label_nombre";
            label_nombre.Size = new Size(67, 20);
            label_nombre.TabIndex = 8;
            label_nombre.Text = "Nombre:";
            // 
            // UsuarioForm
            // 
            ClientSize = new Size(417, 563);
            Controls.Add(panel_titulo);
            Controls.Add(pictureBox_logo_tipo);
            Name = "UsuarioForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_tipo).EndInit();
            panel_titulo.ResumeLayout(false);
            panel_titulo.PerformLayout();
            ResumeLayout(false);

        }
        private PictureBox pictureBox_logo_tipo;
        private Panel panel_titulo;
        private TextBox textBox_pri_apellido;
        private TextBox textBox_pri_nombre;
        private Label label_apellido;
        private Label label_nombre;
        private TextBox textBox_direccion;
        private Label label_direccion;
        private TextBox textBox_telefono;
        private Label label_telefono;
        private TextBox textBox_correo;
        private Label label_gmail;
        private TextBox textBox_cedula;
        private Label label_cedula;
        private Button button_agregar_usuario;

        private async void button_agregar_usuario_Click(object sender, EventArgs e)
        {

            if (!ValidarCamposPorNombre())
                return;
            
            try
            {
                var persona = new PersonaApiM
                {
                    primer_nombre = textBox_pri_nombre.Text.Trim(),
                    primer_apellido = textBox_pri_apellido.Text.Trim(),
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

                            MessageBox.Show(respuesta);
                            return;


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
            TecladoDesplegable.MostrarTeclado(_formularioPadre, textBox_cedula, TipoTeclado.Numerico, soloNumerico: true);
        }

        private void textBox_pri_nombre_Click(object sender, EventArgs e)
        {
            TecladoDesplegable.MostrarTeclado(_formularioPadre, textBox_pri_nombre);
        }

        private void textBox_pri_apellido_Click(object sender, EventArgs e)
        {
            TecladoDesplegable.MostrarTeclado(_formularioPadre, textBox_pri_apellido);
        }

        private void textBox_correo_Click(object sender, EventArgs e)
        {
            TecladoDesplegable.MostrarTeclado(_formularioPadre, textBox_correo);
        }

        private void textBox_telefono_Click(object sender, EventArgs e)
        {
            TecladoDesplegable.MostrarTeclado(_formularioPadre, textBox_telefono, TipoTeclado.Numerico, soloNumerico: true);
        }

        private void textBox_direccion_Click(object sender, EventArgs e)
        {
            TecladoDesplegable.MostrarTeclado(_formularioPadre, textBox_direccion);
        }
    }
}
