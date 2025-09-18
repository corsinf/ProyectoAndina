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
            validador.AgregarControlRequerido(textBox_pri_apellido, "El primer apellido es requerido");
            validador.AgregarControlRequerido(textBox_pri_nombre, "El primer nombre es requerido");
            validador.AgregarControlRequerido(textBox_seg_apellido, "El segundo apellido es requerido");
            validador.AgregarControlRequerido(textBox_seg_nombre, "El segundo nombre es requerido");
            validador.AgregarControlRequerido(textBox_contrasenia, "El campo contraseña es requerido");
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
                textBox_correo.Text = persona.correo ?? "";
                textBox_contrasenia.Text = persona.password ?? "";
                label_titulo_persona.Text = "Actualizar los datos";
                button_agregar_persona.Text = "Actualizar";

            }
            else
            {
                MessageBox.Show("No se encontró la persona.");
            }



        }
       

        private void button_agregar_persona_Click(object? sender, EventArgs e)
        {
         
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
                correo = textBox_correo.Text.Trim(),
                password = textBox_contrasenia.Text.Trim(),
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
