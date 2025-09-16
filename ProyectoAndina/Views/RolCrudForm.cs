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
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProyectoAndina.Utils.StylesAlertas;

namespace ProyectoAndina.Views
{
    public partial class RolCrudForm : Form
    {
        private readonly RolController _RolController;
        private readonly FuncionesGenerales _FuncionesGenerales;
        private Form _formularioPadre;
        private ValidacionHelper validador;
        public int id;
        public RolCrudForm(int id_rol, Form formularioPadre = null)
        {

            InitializeComponent();
            _RolController = new RolController();
            _FuncionesGenerales = new FuncionesGenerales();
            validador = new ValidacionHelper(this);
            ConfigurarValidacion();
            BuscarRol(id_rol);
            _formularioPadre = formularioPadre;
            this.Paint += RolCrudForm_Paint;
            // Config típica de diálogo modal
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.TopMost = true;
            this.KeyPreview = false;
        }

        private void ConfigurarValidacion()
        {
            validador = new ValidacionHelper(this);
            validador.AgregarControlRequerido(textBox_nombre, "El campo nombre es requerido");
            validador.AgregarControlRequerido(textBox_descripcion, "la campo descripción es requerido");
        }


        private void RolCrudForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
            //configurar los botones


        }



        private void BuscarRol(int id_rol)
        {

            if (id_rol != 0)
            {
               StyleButton.CrearBotonElegante(button_accion, FontAwesome.Sharp.IconChar.Rotate);
                button_accion.Text = "Actualizar";
                var rol = _RolController.ObtenerRolPorId(id_rol);
                textBox_nombre.Text = rol.Nombre;
                textBox_descripcion.Text = rol.Descripcion;
                id = id_rol;

            }
            else
            {
                StyleButton.CrearBotonElegante(button_accion, FontAwesome.Sharp.IconChar.PlusCircle);
                button_accion.Text = "Crear";
                _FuncionesGenerales.LimpiarCampos(this);

            }



        }

        private void button_accion_Click(object sender, EventArgs e)
        {
            string nombre = textBox_nombre.Text.Trim();
            string descripcion = textBox_descripcion.Text.Trim();

            if (!validador.ValidarTodosLosControles())
            {
                validador.MostrarMensajeValidacion();
                return;
           
            }

            try
            {
                // Crear objeto Rol usando las propiedades del modelo
                RolM Rol = new RolM
                {
                    Nombre = nombre,
                    Descripcion = descripcion,
                    Estado = true,
                    FechaCreacion = DateTime.Now
                };

                string accion = button_accion.Text.Trim();

                if (accion == "Actualizar")
                {
                    Rol.RolId = id;
                    _RolController.ActualizarRol(Rol);

                    StylesAlertas.MostrarAlerta(this, "Registro actualizado correctamente", tipo: TipoAlerta.Success);
                }
                if (accion == "Crear")
                {

                    _RolController.InsertarRol(Rol);
                    StylesAlertas.MostrarAlerta(this, "Registro creado correctamente", tipo: TipoAlerta.Success);

                }

                this.DialogResult = DialogResult.OK;
                this.Close();




            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar rol: " + ex.Message);
            }
        }
        private void textBox_nombre_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();
        }

        private void textBox_descripcion_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();
        }
    }
}
