using ProyectoAndina.Controllers;
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
    public partial class PersonaRolCrudForm : Form
    {
        private readonly RolController _rolController;
        private readonly PersonaController _personaController;
        private readonly PersonaRolController _personaRolController;
        private ValidacionHelper validador;
        private int _PerRolId;
        private Form _formularioPadre;
        public PersonaRolCrudForm(int PerRolId, Form FormularioPadre = null)
        {
            InitializeComponent();
            _rolController = new RolController();
            _personaController = new PersonaController();
            _personaRolController = new PersonaRolController();
            validador = new ValidacionHelper(this);
            ConfigurarValidacion();
            CargarDatosComboBox();
            _formularioPadre = FormularioPadre;
            _PerRolId = PerRolId;
            carga_persona_rol(PerRolId);
            this.Paint += PersonaRolCrudForm_Paint;

        }

        private void ConfigurarValidacion()
        {
            validador = new ValidacionHelper(this);
            validador.AgregarControlRequerido(comboBox_personas, "Seleccione una persona");
            validador.AgregarControlRequerido(comboBox_roles, "Seleccione un rol");
        }
        private void PersonaRolCrudForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }
        private void carga_persona_rol(int per_rol_id)
        {

            if (per_rol_id != 0)
            {

                var persona_rol = _personaRolController.ObtenerPersonaRolId(per_rol_id);

                if (persona_rol != null)
                {
                    StyleButton.CrearBotonElegante(button_accion, FontAwesome.Sharp.IconChar.Rotate);
                    button_accion.Text = "Actualizar";

                    var persona =  _personaController.ObtenerPorId(persona_rol.PerId);
                    comboBox_personas.Enabled = false;
                    textBox_nombre_persona.Visible = true;
                    comboBox_personas.Visible = false;
                    textBox_nombre_persona.Text = persona.primer_nombre;
                    textBox_id_persona.Text = persona_rol.PerId.ToString();

                    comboBox_roles.SelectedValue = persona_rol.RolId;
                }
            }
            else
            {
                StyleButton.CrearBotonElegante(button_accion, FontAwesome.Sharp.IconChar.PlusCircle);
                button_accion.Text = "Crear";
            }



        }

        private void CargarDatosComboBox()
        {
            // Roles
            var roles = _rolController.ObtenerRoles();
            comboBox_roles.DataSource = roles;
            comboBox_roles.DisplayMember = "Nombre";   // lo que se ve
            comboBox_roles.ValueMember = "RolId";      // el ID oculto

            // Personas sin rol
            var personas = _personaRolController.ObtenerPersonasSinRol();
            comboBox_personas.DataSource = personas;
            comboBox_personas.DisplayMember = "NombrePersona";  // lo que se ve
            comboBox_personas.ValueMember = "PerId";            // el ID oculto
        }

        private void button_accion_Click(object sender, EventArgs e)
        {

            //revisar sobre persona y rol
            if (!validador.ValidarTodosLosControles())
            {
                validador.MostrarMensajeValidacion();
                return;
            }


            if (comboBox_roles.SelectedValue != null && comboBox_personas.SelectedValue != null)
                {

                    var PersonaRol = new persona_rolM
                    {
                        RolId = (int)comboBox_roles.SelectedValue,           // ID oculto de rol
                        FechaAsignacion = DateTime.Now,
                        Estado = true
                    };

                    if (_PerRolId == 0)
                    {
                    PersonaRol.PerId = (int)comboBox_personas.SelectedValue;
                        _personaRolController.InsertarPersonaRol(PersonaRol);
                        StylesAlertas.MostrarAlerta(this, "Registro creado correctamente", tipo: TipoAlerta.Success);
                    }
                    else {
                    PersonaRol.PerId = int.Parse(textBox_id_persona.Text.Trim());
                    PersonaRol.IdPersonaRol = _PerRolId;
                        _personaRolController.ActualizarPersonaRol(PersonaRol);
                        StylesAlertas.MostrarAlerta(this, "Registro actualizado correctamente", tipo: TipoAlerta.Success);
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();

            }
                else
                {
                    StylesAlertas.MostrarAlerta(this, "Seleccione una persona y un rol.", "¡Error!", TipoAlerta.Error);
                }

        }
    }
}
