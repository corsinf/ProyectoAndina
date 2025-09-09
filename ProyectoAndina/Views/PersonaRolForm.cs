
using FontAwesome.Sharp;
using ProyectoAndina.Controllers;
using ProyectoAndina.Funciones_Generales;
using ProyectoAndina.Models;
using ProyectoAndina.Utils;
using System;
using System.Data;
using System.Reflection.Emit;
using System.Windows.Forms;
using static ProyectoAndina.Utils.StylesAlertas;

namespace ProyectoAndina.Views
{
    public partial class PersonaRolForm : Form
    {
        private readonly RolController _rolController;
        private readonly PersonaController _personaController;
        private readonly PersonaRolController _personaRolController;
        private readonly StyleTablas _styleTablas = new StyleTablas();
        private List<persona_rolM> _todasLasPersonasRol;
        private List<RolM> _todasLosRoles;
        private Button button_cancelar_editar;
        private Button button_eliminar;
        private Button button_editar_persona_rol;
        private Panel panel_controls_uno;
        private Panel panel_eliminar;
        private Panel panel_controls_dos;
        private Panel panel_editar;
        private Panel panel_cancelar;
        private TableLayoutPanel tableLayoutPanel_logueado;
        private IconButton button_regresar;
        private Panel panel1;
        private PictureBox pictureBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel_crear;
        private Button button_agregar_rol_persona;
        private System.Windows.Forms.Label label_titulo_acciones;
        private TableLayoutPanel tableLayoutPanel_persona_rol;
        private System.Windows.Forms.Label label_titulo_persona_rol;
        private int idPersonaRol;
        public PersonaRolForm()
        {
            //controladores
            _rolController = new RolController();
            _personaController = new PersonaController();
            _personaRolController = new PersonaRolController();


            //funciones
            InitializeComponent();
            
            CargarPersonaRolTable();

            ConfigurarEstilo();
            this.Paint += PersonaRolForm_Paint;
            this.DoubleBuffered = true;
            // se despliega en toda la pantalla
            this.WindowState = FormWindowState.Maximized;

            _styleTablas.OnIdSeleccionado = (id) =>
            {
                idPersonaRol = id;

            };

            _styleTablas.OnEditarClicked = (id) =>
            {
                AbrirFormularioEdicion(id);
            };

            // Nuevo: Configurar evento de eliminar
            _styleTablas.OnEliminarClicked = (id) =>
            {
                ConfirmarEliminar(id);
            };

        }

        private void AbrirFormularioEdicion(int perRolId)
        {

            var PersonaRolCrudForm = new PersonaRolCrudForm(perRolId, this);
            PersonaRolCrudForm.StartPosition = FormStartPosition.CenterParent;

            DialogResult resultado = PersonaRolCrudForm.ShowDialog(this);

            if (PersonaRolCrudForm.DialogResult == DialogResult.OK)
            {
                CargarPersonaRolTable();

            }


        }

        // Método para confirmar eliminación
        private void ConfirmarEliminar(int idPerRol)
        {
            try
            {
                var resultado = MessageBox.Show(
                    $"¿Estás seguro de que quieres eliminar el rol de la persona con ID {idPerRol}?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    _personaRolController.EliminarPersonaRol(idPerRol);
                    StylesAlertas.MostrarAlerta(this, "Registro eliminado correctamente", tipo: TipoAlerta.Success);
                    CargarPersonaRolTable();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar rol: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PersonaRolForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }

        public void ConfigurarEstilo()
        {
            StyleManager.ConfigurarFormPrincipal(this, "Menu de Roles");
            this.BackColor = StyleManager.Colors.GrisClaro;



            // Configurar labels con estilos UASB
            StyleManager.ConfigurarLabel(label_titulo_persona_rol, TipoLabel.TituloGrande);
            StyleManager.ConfigurarLabel(label_titulo_acciones, TipoLabel.TituloMedio);

            //configurar los botones
            StyleManager.ConfigurarBotonIconoEnPanel(panel_crear, button_agregar_rol_persona, FontAwesome.Sharp.IconChar.PlusCircle, Color.MediumAquamarine);
            

            // Configurar panel principal con sombra
            StyleManager.ConfigurarBotonPrincipalIcono(
              button_regresar,
              FontAwesome.Sharp.IconChar.SignOutAlt,
              "Regresar",
              colorFondo: Color.FromArgb(231, 76, 60)
              );

        }

       

        private void CargarPersonaRolTable()
        {
            try
            {
                _todasLasPersonasRol = _personaRolController.ObtenerPersonaRoles();
                var panel = tableLayoutPanel_persona_rol;
                panel.SuspendLayout();
                panel.Controls.Clear();
                panel.RowStyles.Clear();
                panel.ColumnStyles.Clear();
                panel.ColumnCount = 5; // Aumentamos a 5 columnas para incluir acciones
                panel.RowCount = 1;
                panel.AutoScroll = true;
                panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                panel.BackColor = Color.FromArgb(245, 245, 245);

                // Configuración de columnas
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 0)); // ID (oculto)
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F)); // Nombre
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F)); // Cédula
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F)); // Rol
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F)); // Acciones

                panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));

                // Encabezados
                _styleTablas.AgregarCelda(panel, "", 0, 0, true); // ID oculto
                _styleTablas.AgregarCelda(panel, "Nombre", 1, 0, true);
                _styleTablas.AgregarCelda(panel, "Cédula", 2, 0, true);
                _styleTablas.AgregarCelda(panel, "Rol", 3, 0, true);
                _styleTablas.AgregarCelda(panel, "Acciones", 4, 0, true);

                int fila = 1;
                foreach (var personaRol in _todasLasPersonasRol)
                {
                    panel.RowCount++;
                    panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F)); // Aumentamos altura para los botones

                    _styleTablas.AgregarCelda(panel, personaRol.IdPersonaRol.ToString() ?? "N/A", 0, fila);
                    _styleTablas.AgregarCelda(panel, personaRol.NombrePersona ?? "N/A", 1, fila);
                    _styleTablas.AgregarCelda(panel, personaRol.Cedula ?? "N/A", 2, fila);
                    _styleTablas.AgregarCelda(panel, personaRol.NombreRol ?? "N/A", 3, fila);

                    // Agregar panel de botones de acción
                    _styleTablas.AgregarPanelAcciones(panel, personaRol.IdPersonaRol, 4, fila);
                    fila++;
                }

                panel.ResumeLayout(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private void InitializeComponent()
        {
            tableLayoutPanel_logueado = new TableLayoutPanel();
            label_titulo_persona_rol = new System.Windows.Forms.Label();
            button_regresar = new IconButton();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel_crear = new Panel();
            button_agregar_rol_persona = new Button();
            label_titulo_acciones = new System.Windows.Forms.Label();
            tableLayoutPanel_persona_rol = new TableLayoutPanel();
            tableLayoutPanel_logueado.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel_crear.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel_logueado
            // 
            tableLayoutPanel_logueado.BackColor = Color.Transparent;
            tableLayoutPanel_logueado.ColumnCount = 3;
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel_logueado.Controls.Add(label_titulo_persona_rol, 1, 0);
            tableLayoutPanel_logueado.Controls.Add(button_regresar, 0, 0);
            tableLayoutPanel_logueado.Controls.Add(panel1, 2, 0);
            tableLayoutPanel_logueado.Dock = DockStyle.Top;
            tableLayoutPanel_logueado.Location = new Point(0, 0);
            tableLayoutPanel_logueado.Name = "tableLayoutPanel_logueado";
            tableLayoutPanel_logueado.RowCount = 1;
            tableLayoutPanel_logueado.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_logueado.Size = new Size(1082, 77);
            tableLayoutPanel_logueado.TabIndex = 109;
            // 
            // label_titulo_persona_rol
            // 
            label_titulo_persona_rol.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_persona_rol.AutoSize = true;
            label_titulo_persona_rol.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_persona_rol.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_persona_rol.Location = new Point(273, 20);
            label_titulo_persona_rol.Name = "label_titulo_persona_rol";
            label_titulo_persona_rol.Size = new Size(535, 37);
            label_titulo_persona_rol.TabIndex = 79;
            label_titulo_persona_rol.Text = "Lista de persona con rol";
            label_titulo_persona_rol.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button_regresar
            // 
            button_regresar.BackColor = Color.FromArgb(41, 128, 185);
            button_regresar.Cursor = Cursors.Hand;
            button_regresar.FlatAppearance.BorderSize = 0;
            button_regresar.FlatStyle = FlatStyle.Flat;
            button_regresar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_regresar.ForeColor = Color.White;
            button_regresar.IconChar = IconChar.ArrowLeft;
            button_regresar.IconColor = Color.White;
            button_regresar.IconFont = IconFont.Auto;
            button_regresar.IconSize = 24;
            button_regresar.Location = new Point(3, 3);
            button_regresar.Name = "button_regresar";
            button_regresar.Size = new Size(232, 63);
            button_regresar.TabIndex = 29;
            button_regresar.Text = "  Regresar";
            button_regresar.TextAlign = ContentAlignment.MiddleRight;
            button_regresar.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_regresar.UseVisualStyleBackColor = false;
            button_regresar.Click += button_regresar_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(814, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(265, 71);
            panel1.TabIndex = 78;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Logotipo_color;
            pictureBox1.Location = new Point(21, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(235, 60);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 64;
            pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.405406F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.4137936F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.6969147F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.405405F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel_persona_rol, 2, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 77);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.Size = new Size(1082, 517);
            tableLayoutPanel1.TabIndex = 110;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(panel_crear, 0, 2);
            tableLayoutPanel2.Controls.Add(label_titulo_acciones, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(61, 28);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 227F));
            tableLayoutPanel2.Size = new Size(236, 459);
            tableLayoutPanel2.TabIndex = 9;
            // 
            // panel_crear
            // 
            panel_crear.BackColor = Color.Transparent;
            panel_crear.Controls.Add(button_agregar_rol_persona);
            panel_crear.Dock = DockStyle.Fill;
            panel_crear.Location = new Point(3, 235);
            panel_crear.Name = "panel_crear";
            panel_crear.Size = new Size(230, 221);
            panel_crear.TabIndex = 78;
            // 
            // button_agregar_rol_persona
            // 
            button_agregar_rol_persona.BackColor = Color.FromArgb(52, 152, 219);
            button_agregar_rol_persona.Cursor = Cursors.Hand;
            button_agregar_rol_persona.FlatAppearance.BorderSize = 0;
            button_agregar_rol_persona.FlatStyle = FlatStyle.Flat;
            button_agregar_rol_persona.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_agregar_rol_persona.ForeColor = Color.White;
            button_agregar_rol_persona.Location = new Point(35, 47);
            button_agregar_rol_persona.Name = "button_agregar_rol_persona";
            button_agregar_rol_persona.Size = new Size(135, 58);
            button_agregar_rol_persona.TabIndex = 24;
            button_agregar_rol_persona.Text = "Agregar";
            button_agregar_rol_persona.UseVisualStyleBackColor = false;
            button_agregar_rol_persona.Click += button_agregar_rol_persona_Click;
            // 
            // label_titulo_acciones
            // 
            label_titulo_acciones.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_acciones.AutoSize = true;
            label_titulo_acciones.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_acciones.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_acciones.Location = new Point(3, 155);
            label_titulo_acciones.Name = "label_titulo_acciones";
            label_titulo_acciones.Size = new Size(230, 37);
            label_titulo_acciones.TabIndex = 28;
            label_titulo_acciones.Text = "Acciones";
            // 
            // tableLayoutPanel_persona_rol
            // 
            tableLayoutPanel_persona_rol.ColumnCount = 2;
            tableLayoutPanel_persona_rol.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_persona_rol.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_persona_rol.Dock = DockStyle.Fill;
            tableLayoutPanel_persona_rol.Location = new Point(303, 28);
            tableLayoutPanel_persona_rol.Name = "tableLayoutPanel_persona_rol";
            tableLayoutPanel_persona_rol.RowCount = 2;
            tableLayoutPanel_persona_rol.RowStyles.Add(new RowStyle(SizeType.Percent, 50.56818F));
            tableLayoutPanel_persona_rol.RowStyles.Add(new RowStyle(SizeType.Percent, 49.43182F));
            tableLayoutPanel_persona_rol.Size = new Size(716, 459);
            tableLayoutPanel_persona_rol.TabIndex = 8;
            // 
            // PersonaRolForm
            // 
            ClientSize = new Size(1082, 594);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tableLayoutPanel_logueado);
            Name = "PersonaRolForm";
            tableLayoutPanel_logueado.ResumeLayout(false);
            tableLayoutPanel_logueado.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel_crear.ResumeLayout(false);
            ResumeLayout(false);

        }

        private void tableLayoutPanel_persona_rol_Paint(object? sender, PaintEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void button_agregar_rol_persona_Click(object sender, EventArgs e)
        {
            var PersonaRolCrudForm = new PersonaRolCrudForm(0, this);
            PersonaRolCrudForm.StartPosition = FormStartPosition.CenterParent;

            DialogResult resultado = PersonaRolCrudForm.ShowDialog(this);

            if (PersonaRolCrudForm.DialogResult == DialogResult.OK)
            {
                CargarPersonaRolTable();

            }
        }

        private void listBox_personas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
        
      
      

        private void button_regresar_Click(object sender, EventArgs e)
        {
            var AdministracionFrom = new AdministracionFrom();
            this.Hide();                 // Opcional: ocultas la ventana actual
            AdministracionFrom.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
            this.Close();
        }
    }
}

public class RolItem
{
    public int IdRol { get; set; }
    public string NombreRol { get; set; }

    public override string ToString()
    {
        return NombreRol; // Esto es lo que se muestra en el ListBox
    }
}

public class PersonaItem
{
    public int IdPersona { get; set; }
    public string Nombre { get; set; }

    public override string ToString()
    {
        return Nombre; // Esto es lo que se muestra en el ListBox
    }
}

