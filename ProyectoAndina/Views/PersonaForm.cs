// Views/MainForm.csusing System;
using FontAwesome.Sharp;
using ProyectoAndina.Controllers;
using ProyectoAndina.Data;
using ProyectoAndina.Funciones_Generales;
using ProyectoAndina.Models;
using ProyectoAndina.Utils;
using System.Windows.Forms;
using static ProyectoAndina.Utils.StylesAlertas;

namespace ProyectoAndina.Views
{
    public partial class PersonaForm : Form
    {
        private readonly PersonaController _PersonaController;
        private readonly StyleTablas _styleTablas = new StyleTablas();
        private Button button_actualizar_persona;
        private IconButton button_regresar;
        private Button button_eliminar_persona;
        private Button button_cancelar_editar;
        private Panel panel_descripcion;
        private Panel panel_nombre;
        private Panel panel_controls_uno;
        private Panel panel_eliminar;
        private Panel panel_controls_dos;
        private Panel panel_editar;
        private Panel panel_cancelar;
        private TableLayoutPanel tableLayoutPanel_logueado;
        private IconButton iconButton_regresar;
        private Panel panel1;
        private PictureBox pictureBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel_crear;
        private Button button_agregar_persona;
        private Label label_titulo_acciones;
        private TableLayoutPanel tableLayoutPanel_usuarios;
        private Label label_titulo_usuarios;
        public int perId;
        public PersonaForm()
        {
            _PersonaController = new PersonaController();
            InitializeComponent();
            CargarUsuariosTable();
            ConfigurarEstilo();
            this.Paint += PersonaForm_Paint;
            this.DoubleBuffered = true;
            // se despliega en toda la pantalla
            this.WindowState = FormWindowState.Maximized;

            _styleTablas.OnIdSeleccionado = (id) =>
            {
                perId = id;
                seleccionarPersona(id);
            };

            // Nuevo: Configurar evento de editar
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


        private void AbrirFormularioEdicion(int idPersona)
        {

            var PersonaCrudForm = new PersonaCrudForm(idPersona, this);
            PersonaCrudForm.StartPosition = FormStartPosition.CenterParent;
            if (PersonaCrudForm.DialogResult == DialogResult.OK)
            {
                CargarUsuariosTable();
            }
            ;

            PersonaCrudForm.ShowDialog(this);


        }

        // Método para confirmar eliminación
        private void ConfirmarEliminar(int idPersona)
        {
            try
            {
                var resultado = MessageBox.Show(
                    $"¿Estás seguro de que quieres eliminar el rol con ID {idPersona}?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    MessageBox.Show($"Rol con ID {idPersona} eliminado correctamente.", "Éxito",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _PersonaController.Eliminar(idPersona);

                    StylesAlertas.MostrarAlerta(this, "Registro eliminado correctamente", tipo: TipoAlerta.Success);
                    CargarUsuariosTable();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar rol: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PersonaForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }

        public void ConfigurarEstilo()
        {
            StyleManager.ConfigurarFormPrincipal(this, "Menu de Usuarios");
            this.BackColor = StyleManager.Colors.GrisClaro;
            // Configurar labels con estilos UASB
            StyleManager.ConfigurarLabel(label_titulo_usuarios, TipoLabel.TituloGrande);
            StyleManager.ConfigurarLabel(label_titulo_acciones, TipoLabel.TituloMedio);
            //configurar los botones
            StyleManager.ConfigurarBotonIconoEnPanel(panel_crear, button_agregar_persona, FontAwesome.Sharp.IconChar.PlusCircle, Color.MediumAquamarine);

            // Configurar panel principal con sombra
            StyleManager.ConfigurarBotonPrincipalIcono(
             button_regresar,
             FontAwesome.Sharp.IconChar.SignOutAlt,
             "Regresar",
             colorFondo: Color.FromArgb(231, 76, 60)
             );
        }


        public void seleccionarPersona(int id)
        {
            var persona = _PersonaController.ObtenerPorId(id);
            if (persona != null)
            {
            }
            else
            {
                MessageBox.Show("No existe esa persona");
            }

        }


        private void CargarUsuariosTable()
        {
            try
            {
                var todasLasPersonas = _PersonaController.ObtenerPersonasBasicas();
                var panel = tableLayoutPanel_usuarios;
                panel.SuspendLayout();
                panel.Controls.Clear();
                panel.RowStyles.Clear();
                panel.ColumnStyles.Clear();
                panel.ColumnCount = 5; // 5 columnas (agregamos columna de acciones)
                panel.RowCount = 1;
                panel.AutoScroll = true;
                panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                panel.BackColor = Color.FromArgb(245, 245, 245);

                // Configuración de columnas
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 0)); // ID (oculto)
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F)); // Nombre
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F)); // Cédula
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F)); // Correo
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F)); // Acciones

                panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));

                // Encabezados
                _styleTablas.AgregarCelda(panel, "", 0, 0, true); // ID oculto
                _styleTablas.AgregarCelda(panel, "Nombre", 1, 0, true);
                _styleTablas.AgregarCelda(panel, "Cédula", 2, 0, true);
                _styleTablas.AgregarCelda(panel, "Correo", 3, 0, true);
                _styleTablas.AgregarCelda(panel, "Acciones", 4, 0, true);

                int fila = 1;
                foreach (var persona in todasLasPersonas)
                {
                    panel.RowCount++;
                    panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F)); // Aumentamos altura para los botones

                    _styleTablas.AgregarCelda(panel, persona.per_id.ToString(), 0, fila);
                    _styleTablas.AgregarCelda(panel, persona.primer_nombre ?? "N/A", 1, fila);
                    _styleTablas.AgregarCelda(panel, persona.cedula ?? "N/A", 2, fila);
                    _styleTablas.AgregarCelda(panel, persona.correo ?? "N/A", 3, fila);

                    // Agregar panel de botones de acción
                    _styleTablas.AgregarPanelAcciones(panel, persona.per_id, 4, fila);
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
            button_regresar = new IconButton();
            tableLayoutPanel_logueado = new TableLayoutPanel();
            label_titulo_usuarios = new Label();
            iconButton_regresar = new IconButton();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel_crear = new Panel();
            button_agregar_persona = new Button();
            label_titulo_acciones = new Label();
            tableLayoutPanel_usuarios = new TableLayoutPanel();
            tableLayoutPanel_logueado.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel_crear.SuspendLayout();
            SuspendLayout();
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
            button_regresar.Location = new Point(39, 22);
            button_regresar.Name = "button_regresar";
            button_regresar.Size = new Size(160, 45);
            button_regresar.TabIndex = 0;
            button_regresar.Text = "  Regresar";
            button_regresar.TextAlign = ContentAlignment.MiddleRight;
            button_regresar.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_regresar.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel_logueado
            // 
            tableLayoutPanel_logueado.BackColor = Color.Transparent;
            tableLayoutPanel_logueado.ColumnCount = 3;
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel_logueado.Controls.Add(label_titulo_usuarios, 1, 0);
            tableLayoutPanel_logueado.Controls.Add(iconButton_regresar, 0, 0);
            tableLayoutPanel_logueado.Controls.Add(panel1, 2, 0);
            tableLayoutPanel_logueado.Dock = DockStyle.Top;
            tableLayoutPanel_logueado.Location = new Point(0, 0);
            tableLayoutPanel_logueado.Name = "tableLayoutPanel_logueado";
            tableLayoutPanel_logueado.RowCount = 1;
            tableLayoutPanel_logueado.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_logueado.Size = new Size(1093, 77);
            tableLayoutPanel_logueado.TabIndex = 109;
            // 
            // label_titulo_usuarios
            // 
            label_titulo_usuarios.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_usuarios.AutoSize = true;
            label_titulo_usuarios.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_usuarios.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_usuarios.Location = new Point(276, 20);
            label_titulo_usuarios.Name = "label_titulo_usuarios";
            label_titulo_usuarios.Size = new Size(540, 37);
            label_titulo_usuarios.TabIndex = 79;
            label_titulo_usuarios.Text = "Lista de usuarios";
            label_titulo_usuarios.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // iconButton_regresar
            // 
            iconButton_regresar.BackColor = Color.FromArgb(41, 128, 185);
            iconButton_regresar.Cursor = Cursors.Hand;
            iconButton_regresar.FlatAppearance.BorderSize = 0;
            iconButton_regresar.FlatStyle = FlatStyle.Flat;
            iconButton_regresar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            iconButton_regresar.ForeColor = Color.White;
            iconButton_regresar.IconChar = IconChar.ArrowLeft;
            iconButton_regresar.IconColor = Color.White;
            iconButton_regresar.IconFont = IconFont.Auto;
            iconButton_regresar.IconSize = 24;
            iconButton_regresar.Location = new Point(3, 3);
            iconButton_regresar.Name = "iconButton_regresar";
            iconButton_regresar.Size = new Size(232, 63);
            iconButton_regresar.TabIndex = 29;
            iconButton_regresar.Text = "  Regresar";
            iconButton_regresar.TextAlign = ContentAlignment.MiddleRight;
            iconButton_regresar.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton_regresar.UseVisualStyleBackColor = false;
            iconButton_regresar.Click += button_regresar_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(822, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(268, 71);
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
            tableLayoutPanel1.Controls.Add(tableLayoutPanel_usuarios, 2, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 77);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.Size = new Size(1093, 508);
            tableLayoutPanel1.TabIndex = 110;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(panel_crear, 0, 2);
            tableLayoutPanel2.Controls.Add(label_titulo_acciones, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(62, 28);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 227F));
            tableLayoutPanel2.Size = new Size(239, 451);
            tableLayoutPanel2.TabIndex = 9;
            // 
            // panel_crear
            // 
            panel_crear.BackColor = Color.Transparent;
            panel_crear.Controls.Add(button_agregar_persona);
            panel_crear.Dock = DockStyle.Fill;
            panel_crear.Location = new Point(3, 227);
            panel_crear.Name = "panel_crear";
            panel_crear.Size = new Size(233, 221);
            panel_crear.TabIndex = 78;
            // 
            // button_agregar_persona
            // 
            button_agregar_persona.BackColor = Color.FromArgb(52, 152, 219);
            button_agregar_persona.Cursor = Cursors.Hand;
            button_agregar_persona.FlatAppearance.BorderSize = 0;
            button_agregar_persona.FlatStyle = FlatStyle.Flat;
            button_agregar_persona.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_agregar_persona.ForeColor = Color.White;
            button_agregar_persona.Location = new Point(35, 47);
            button_agregar_persona.Name = "button_agregar_persona";
            button_agregar_persona.Size = new Size(135, 58);
            button_agregar_persona.TabIndex = 24;
            button_agregar_persona.Text = "Agregar";
            button_agregar_persona.UseVisualStyleBackColor = false;
            button_agregar_persona.Click += button_crear_usuario_Click;
            // 
            // label_titulo_acciones
            // 
            label_titulo_acciones.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_acciones.AutoSize = true;
            label_titulo_acciones.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_acciones.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_acciones.Location = new Point(3, 149);
            label_titulo_acciones.Name = "label_titulo_acciones";
            label_titulo_acciones.Size = new Size(233, 37);
            label_titulo_acciones.TabIndex = 28;
            label_titulo_acciones.Text = "Acciones";
            // 
            // tableLayoutPanel_usuarios
            // 
            tableLayoutPanel_usuarios.ColumnCount = 2;
            tableLayoutPanel_usuarios.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_usuarios.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_usuarios.Dock = DockStyle.Fill;
            tableLayoutPanel_usuarios.Location = new Point(307, 28);
            tableLayoutPanel_usuarios.Name = "tableLayoutPanel_usuarios";
            tableLayoutPanel_usuarios.RowCount = 2;
            tableLayoutPanel_usuarios.RowStyles.Add(new RowStyle(SizeType.Percent, 50.56818F));
            tableLayoutPanel_usuarios.RowStyles.Add(new RowStyle(SizeType.Percent, 49.43182F));
            tableLayoutPanel_usuarios.Size = new Size(723, 451);
            tableLayoutPanel_usuarios.TabIndex = 8;
            // 
            // PersonaForm
            // 
            ClientSize = new Size(1093, 585);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tableLayoutPanel_logueado);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PersonaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de Usuario";
            Load += RegistroForm_Load;
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


        private void RegistroForm_Load(object sender, EventArgs e)
        {

        }




        private void pictureBox_recaudacion_Click(object sender, EventArgs e)
        {
            //pictureBox_recaudacion.Image = Image.FromFile("Descargas\recaudacion_parking.jpg");
            //pictureBox_recaudacion.SizeMode = PictureBoxSizeMode.Zoom;
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_registrarse_Click(object sender, EventArgs e)
        {
            var PersonaCrudForm = new PersonaCrudForm(perId);
            PersonaCrudForm.StartPosition = FormStartPosition.CenterParent;
            PersonaCrudForm.FormClosed += (s, args) =>
            {

            };
            PersonaCrudForm.ShowDialog(this);
        }

        private void button_regresar_Click(object sender, EventArgs e)
        {

            var AdministracionFrom = new AdministracionFrom();
            this.Hide();                 // Opcional: ocultas la ventana actual
            AdministracionFrom.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
            this.Close();

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            var AdministracionFrom = new AdministracionFrom();
            this.Hide();                 // Opcional: ocultas la ventana actual
            AdministracionFrom.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
            this.Close();
        }

        private void button_crear_usuario_Click(object sender, EventArgs e)
        {
            var PersonaCrudForm = new PersonaCrudForm(0, this);
            PersonaCrudForm.StartPosition = FormStartPosition.CenterParent;
            PersonaCrudForm.FormClosed += (s, args) =>
            {
                CargarUsuariosTable();
            };

            PersonaCrudForm.ShowDialog(this);
        }



        private void button_eliminar_persona_Click(object sender, EventArgs e)
        {
            var persona = _PersonaController.ObtenerPorId(perId);


            if (perId > 0)
            {
                var resultado = MessageBox.Show(
                    $"¿Desea eliminar el rol: \"{persona.nombre_completo}\"?",
                    "Confirmar eliminación",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (resultado == DialogResult.OK)
                {
                    int idRolEliminar = perId;

                    if (idRolEliminar > 0)
                    {
                        _PersonaController.Eliminar(idRolEliminar);
                        MessageBox.Show("Rol eliminado correctamente.");

                        // Recargar lista u otros datos
                        CargarUsuariosTable(); // si tienes una función así
                       
                    }
                    else
                    {
                        MessageBox.Show("ID de la persona no válido.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un rol que desea eliminar.");
            }
        }
    }
}
