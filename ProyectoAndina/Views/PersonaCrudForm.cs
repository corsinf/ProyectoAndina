using ProyectoAndina.Controllers;
using ProyectoAndina.Helper;
using ProyectoAndina.Models;
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
    public partial class PersonaCrudForm : Form
    {
        private readonly PersonaController _PersonaController;
        private readonly FuncionesGenerales _FuncionesGenerales;
        private ValidacionHelper validador;
        private int idPersona;
        private bool mostrarContrasenia = false;
        private Form _formularioPadre;
        public PersonaCrudForm(int idPer, Form formularioPadre = null)
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

            _PersonaController = new PersonaController();
            _FuncionesGenerales = new FuncionesGenerales();
            validador = new ValidacionHelper(this);
            ConfigurarValidacion();

            CargarComboBox();
            this.Paint += PersonaCrudForm_Paint;
            

            if (idPer > 0)
            {
                StyleButton.CrearBotonElegante(button_agregar_persona, FontAwesome.Sharp.IconChar.Rotate);
                button_agregar_persona.Text = "Actualizar";
                cargarDatosPersona(idPer);
                idPersona = idPer;
                _formularioPadre = formularioPadre;

            }
            else
            {
                encerarVariables();
            }
        }
        private void ConfigurarValidacion()
        {
            validador = new ValidacionHelper(this);
            validador.AgregarControlRequerido(textBox_cedula, "El cedula es requerido");
            validador.AgregarControlRequerido(textBox_pri_apellido, "El primer apellido es requerido");
            validador.AgregarControlRequerido(textBox_pri_nombre, "El primer nombre es requerido");
            validador.AgregarControlRequerido(textBox_seg_apellido, "El segundo apellido es requerido");
            validador.AgregarControlRequerido(textBox_seg_nombre, "El segundo nombre es requerido");
            validador.AgregarControlRequerido(textBox_direccion, "El campo direccion es requerido");
            validador.AgregarControlRequerido(textBox_telefono, "El campo telefono es requerido");
            validador.AgregarControlRequerido(textBox_contrasenia, "El campo contraseña es requerido");
            validador.AgregarControlRequerido(comboBox_estado_civil, "El campo estado civil es requerido");
            validador.AgregarControlRequerido(comboBox_nacionalidad, "El campo nacionalidad es requerido");
            validador.AgregarControlRequerido(comboBox_sexo, "El campo sexo es requerido");


        }

        private void PersonaCrudForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }

        public void encerarVariables()
        {
            StyleButton.CrearBotonElegante(button_agregar_persona, FontAwesome.Sharp.IconChar.PlusCircle);
            _FuncionesGenerales.LimpiarCampos(this);
            label_titulo_persona.Text = "Crear usuario";
            button_agregar_persona.Text = "Crear";

            comboBox_sexo.SelectedIndex = -1;
            comboBox_estado_civil.SelectedIndex = -1;
            comboBox_nacionalidad.SelectedIndex = -1;
        }
        public void cargarDatosPersona(int id)
        {

            var persona = _PersonaController.ObtenerPorId(id);

            if (persona != null)
            {
                textBox_pri_nombre.Text = persona.primer_nombre ?? "";
                textBox_seg_nombre.Text = persona.segundo_nombre ?? "";
                textBox_pri_apellido.Text = persona.primer_apellido ?? "";
                textBox_seg_apellido.Text = persona.segundo_apellido ?? "";
                textBox_cedula.Text = persona.cedula ?? "";
                textBox_correo.Text = persona.correo ?? "";
                textBox_telefono.Text = persona.telefono_1 ?? "";
                textBox_direccion.Text = persona.direccion ?? "";
                textBox_contrasenia.Text = persona.password ?? "";

                // Fecha de nacimiento

                if (comboBox_sexo.Items.Contains(persona.sexo))
                    comboBox_sexo.SelectedItem = persona.sexo;

                if (comboBox_estado_civil.Items.Contains(persona.estado_civil))
                    comboBox_estado_civil.SelectedItem = persona.estado_civil;

                if (comboBox_nacionalidad.Items.Contains(persona.nacionalidad))
                    comboBox_nacionalidad.SelectedItem = persona.nacionalidad;

                label_titulo_persona.Text = "Actualizar los datos";
                button_agregar_persona.Text = "Actualizar";

            }
            else
            {
                MessageBox.Show("No se encontró la persona.");
            }



        }
        public void CargarComboBox()
        {
            // Limpiar los items actuales
            comboBox_sexo.Items.Clear();
            comboBox_estado_civil.Items.Clear();
            comboBox_nacionalidad.Items.Clear();

            // Agregar opciones al ComboBox de Sexo
            comboBox_sexo.Items.Add("Masculino");
            comboBox_sexo.Items.Add("Femenino");
            comboBox_sexo.Items.Add("Otro");

            // Agregar opciones al ComboBox de Estado Civil
            comboBox_estado_civil.Items.Add("Soltero");
            comboBox_estado_civil.Items.Add("Casado");
            comboBox_estado_civil.Items.Add("Divorciado");
            comboBox_estado_civil.Items.Add("Viudo");
            comboBox_estado_civil.Items.Add("Unión libre");

            // Agregar opciones al ComboBox de Nacionalidad
            comboBox_nacionalidad.Items.Add("Ecuatoriana");
            comboBox_nacionalidad.Items.Add("Peruana");
            comboBox_nacionalidad.Items.Add("Colombiana");
            comboBox_nacionalidad.Items.Add("Venezolana");
            comboBox_nacionalidad.Items.Add("Chilena");
            comboBox_nacionalidad.Items.Add("Otro");

            // Opcional: Seleccionar el primer ítem por defecto
            comboBox_sexo.SelectedIndex = 0;
            comboBox_estado_civil.SelectedIndex = 0;
            comboBox_nacionalidad.SelectedIndex = 0;
        }

        private void button_agregar_persona_Click(object? sender, EventArgs e)
        {

            string cedula = textBox_cedula.Text.Trim();
            var usuarioEncontrado = _PersonaController.ObtenerPorCedula(cedula);

            if (usuarioEncontrado != null) {
                StylesAlertas.MostrarAlerta(this, "Usuario ya registrado con esa cédula", "¡Error!", TipoAlerta.Error);
                return;
            }
            if (!validador.ValidarTodosLosControles())
            {
                validador.MostrarMensajeValidacion();
                return;

            }
            if (!ValidarCamposPorNombre())
                return;

            var persona = new PersonaM
            {
                primer_nombre = textBox_pri_nombre.Text.Trim(),
                segundo_nombre = textBox_seg_nombre?.Text.Trim() ?? "",
                primer_apellido = textBox_pri_apellido.Text.Trim(),
                segundo_apellido = textBox_seg_apellido?.Text.Trim() ?? "",
                cedula = textBox_cedula.Text.Trim(),
                correo = textBox_correo.Text.Trim(),
                password = textBox_contrasenia.Text.Trim(),
                telefono_1 = textBox_telefono?.Text.Trim() ?? "",
                direccion = textBox_direccion?.Text.Trim() ?? "",
                sexo = comboBox_sexo?.Text ?? "",
                estado_civil = comboBox_estado_civil?.Text ?? "",
                nacionalidad = comboBox_nacionalidad?.Text ?? "",
                fecha_nacimiento = DateTime.Now,
                estado = true,
                fecha_creacion = DateTime.Now,
                observaciones = "Creado desde la aplicacion de escritorio"
            };

            try
            {
                if (idPersona > 0)
                {

                    persona.per_id = idPersona;
                    _PersonaController.Actualizar(persona);
                    StylesAlertas.MostrarAlerta(this, "Registro creado correctamente", tipo: TipoAlerta.Success);
                    TecladoHelper.CerrarTeclado();
                    this.DialogResult = DialogResult.OK; // opcional, útil si quieres saber desde el form padre que se creó
                    this.Close();
                }
                else
                {
                    _PersonaController.Insertar(persona);

                    StylesAlertas.MostrarAlerta(this, "Registro actualizado correctamente", tipo: TipoAlerta.Success);
                    TecladoHelper.CerrarTeclado();
                    this.DialogResult = DialogResult.OK; // opcional, útil si quieres saber desde el form padre que se creó
                    this.Close();

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

                    // Validar contraseña
                    if (nombre.Contains("contrasenia") || nombre.Contains("password"))
                    {
                        if (valor.Length < 6)
                        {
                            MessageBox.Show("La contraseña debe tener al menos 6 caracteres.");
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

                    // Validar fecha de nacimiento
                    if (nombre.Contains("fecha_nacimiento"))
                    {
                        if (!DateTime.TryParse(valor, out _))
                        {
                            MessageBox.Show("Fecha de nacimiento no válida. Formato esperado: yyyy-MM-dd");
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
        private void iconPictureBox_eye_password_Click(object sender, EventArgs e)
        {
            if (mostrarContrasenia)
            {
                // Ocultar contraseña
                textBox_contrasenia.PasswordChar = '●';
                iconPictureBox_eye_password.IconChar = FontAwesome.Sharp.IconChar.Eye; // ojo cerrado
                mostrarContrasenia = false;
            }
            else
            {
                // Mostrar contraseña
                textBox_contrasenia.PasswordChar = '\0'; // sin máscara
                iconPictureBox_eye_password.IconChar = FontAwesome.Sharp.IconChar.EyeSlash; // ojo abierto
                mostrarContrasenia = true;
            }
        }

        private void iconButton_regresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_pri_nombre_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();
        }

        private void textBox_pri_apellido_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();

        }

        private void textBox_cedula_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();
        }

        private void textBox_correo_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();

        }

        private void textBox_contrasenia_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();

        }

        private void textBox_seg_nombre_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();
        }

        private void textBox_seg_apellido_Click(object sender, EventArgs e)
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
