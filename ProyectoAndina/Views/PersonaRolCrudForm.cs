using ProyectoAndina.Controllers;
using ProyectoAndina.Models;
using ProyectoAndina.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProyectoAndina.Utils.StylesAlertas;

namespace ProyectoAndina.Views
{
    public partial class PersonaRolCrudForm : Form
    {
        private readonly RolController _rolController;
        private readonly PersonaController _personaController;
        private readonly PersonaRolController _personaRolController;
        private Form _formularioPadre;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox_logo_tipo;
        private Panel panel_button_accion;
        private Button button_accion;
        private Panel panel_formulario;
        private Label label_personas;
        private ComboBox comboBox_personas;
        private Label label_roles;
        private ComboBox comboBox_roles;
        private TableLayoutPanel tableLayoutPanel2;
        private int _PerRolId;


        public PersonaRolCrudForm(int PerRolId, Form FormularioPadre = null)
        {

            _rolController = new RolController();
            _personaController = new PersonaController();
            _personaRolController = new PersonaRolController();
            InitializeComponent();
            CargarDatosComboBox();
            _formularioPadre = FormularioPadre;
            _PerRolId = PerRolId;
            carga_persona_rol(PerRolId);
            this.Paint += PersonaRolCrudForm_Paint;

        }
        private void PersonaRolCrudForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }
        private void carga_persona_rol(int per_rol_id)
        {

            if (per_rol_id != 0)
            {
                StyleManager.ConfigurarBotonIconoEnPanel(panel_button_accion, button_accion, FontAwesome.Sharp.IconChar.Rotate, Color.LightSteelBlue);

                var persona_rol = _personaRolController.ObtenerPersonaRolId(per_rol_id);

                if (persona_rol != null)
                {
                    //textBox_persona_seleccionada.Text = persona_rol.NombrePersona + " - " + persona_rol.Cedula;
                    comboBox_personas.Enabled = false;
                    comboBox_roles.SelectedValue = persona_rol.RolId;
                }
            }
            else {
                StyleManager.ConfigurarBotonIconoEnPanel(panel_button_accion, button_accion, FontAwesome.Sharp.IconChar.PlusCircle, Color.MediumAquamarine);

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
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBox_logo_tipo = new PictureBox();
            panel_button_accion = new Panel();
            button_accion = new Button();
            panel_formulario = new Panel();
            comboBox_roles = new ComboBox();
            label_roles = new Label();
            comboBox_personas = new ComboBox();
            label_personas = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_tipo).BeginInit();
            panel_button_accion.SuspendLayout();
            panel_formulario.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(pictureBox_logo_tipo, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(399, 75);
            tableLayoutPanel1.TabIndex = 88;
            // 
            // pictureBox_logo_tipo
            // 
            pictureBox_logo_tipo.BackColor = Color.White;
            pictureBox_logo_tipo.Image = Properties.Resources.Logotipo_color;
            pictureBox_logo_tipo.Location = new Point(3, 3);
            pictureBox_logo_tipo.Name = "pictureBox_logo_tipo";
            pictureBox_logo_tipo.Size = new Size(391, 62);
            pictureBox_logo_tipo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_logo_tipo.TabIndex = 66;
            pictureBox_logo_tipo.TabStop = false;
            // 
            // panel_button_accion
            // 
            panel_button_accion.BackColor = Color.Transparent;
            panel_button_accion.Controls.Add(button_accion);
            panel_button_accion.Dock = DockStyle.Fill;
            panel_button_accion.Location = new Point(3, 250);
            panel_button_accion.Name = "panel_button_accion";
            panel_button_accion.Size = new Size(393, 122);
            panel_button_accion.TabIndex = 83;
            // 
            // button_accion
            // 
            button_accion.BackColor = Color.FromArgb(52, 152, 219);
            button_accion.Cursor = Cursors.Hand;
            button_accion.FlatAppearance.BorderSize = 0;
            button_accion.FlatStyle = FlatStyle.Flat;
            button_accion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_accion.ForeColor = Color.White;
            button_accion.Location = new Point(124, 41);
            button_accion.Name = "button_accion";
            button_accion.Size = new Size(145, 40);
            button_accion.TabIndex = 28;
            button_accion.Text = "Accion";
            button_accion.UseVisualStyleBackColor = false;
            button_accion.Click += button_accion_Click;
            // 
            // panel_formulario
            // 
            panel_formulario.BackColor = Color.Transparent;
            panel_formulario.Controls.Add(label_personas);
            panel_formulario.Controls.Add(comboBox_personas);
            panel_formulario.Controls.Add(label_roles);
            panel_formulario.Controls.Add(comboBox_roles);
            panel_formulario.Dock = DockStyle.Fill;
            panel_formulario.Location = new Point(3, 3);
            panel_formulario.Name = "panel_formulario";
            panel_formulario.Size = new Size(393, 241);
            panel_formulario.TabIndex = 82;
            // 
            // comboBox_roles
            // 
            comboBox_roles.FormattingEnabled = true;
            comboBox_roles.Location = new Point(153, 136);
            comboBox_roles.Name = "comboBox_roles";
            comboBox_roles.Size = new Size(195, 28);
            comboBox_roles.TabIndex = 74;
            // 
            // label_roles
            // 
            label_roles.AutoSize = true;
            label_roles.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_roles.Location = new Point(36, 137);
            label_roles.Name = "label_roles";
            label_roles.Size = new Size(57, 23);
            label_roles.TabIndex = 76;
            label_roles.Text = "Roles:";
            // 
            // comboBox_personas
            // 
            comboBox_personas.FormattingEnabled = true;
            comboBox_personas.Location = new Point(150, 31);
            comboBox_personas.Name = "comboBox_personas";
            comboBox_personas.Size = new Size(195, 28);
            comboBox_personas.TabIndex = 73;
            // 
            // label_personas
            // 
            label_personas.AutoSize = true;
            label_personas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_personas.Location = new Point(27, 32);
            label_personas.Name = "label_personas";
            label_personas.Size = new Size(83, 23);
            label_personas.TabIndex = 75;
            label_personas.Text = "Personas:";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.Transparent;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(panel_formulario, 0, 0);
            tableLayoutPanel2.Controls.Add(panel_button_accion, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 75);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 128F));
            tableLayoutPanel2.Size = new Size(399, 375);
            tableLayoutPanel2.TabIndex = 89;
            // 
            // PersonaRolCrudForm
            // 
            ClientSize = new Size(399, 450);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            Name = "PersonaRolCrudForm";
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_tipo).EndInit();
            panel_button_accion.ResumeLayout(false);
            panel_formulario.ResumeLayout(false);
            panel_formulario.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);

        }

        private void button_accion_Click(object sender, EventArgs e)
        {
            if (_PerRolId != 0) {
                if (comboBox_roles.SelectedValue != null && comboBox_personas.SelectedValue != null)
                {
                    var PersonaRol = new persona_rolM
                    {
                        PerId = (int)comboBox_personas.SelectedValue, // ID oculto de persona
                        RolId = (int)comboBox_roles.SelectedValue,           // ID oculto de rol
                        FechaAsignacion = DateTime.Now,
                        Estado = true
                    };

                    _personaRolController.InsertarPersonaRol(PersonaRol);
                    StylesAlertas.MostrarAlerta(this, "Registro creado correctamente", tipo: TipoAlerta.Success);
                    CargarDatosComboBox();

                    _personaRolController.ActualizarPersonaRol(PersonaRol);
                    StylesAlertas.MostrarAlerta(this, "Registro creado correctamente", tipo: TipoAlerta.Success);
                }
                else
                {
                    StylesAlertas.MostrarAlerta(this, "Seleccione una persona y un rol.", "¡Error!", TipoAlerta.Error);
                }

            }
        }
    }
}
