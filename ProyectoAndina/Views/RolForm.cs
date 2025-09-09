using ProyectoAndina.Controllers;
using ProyectoAndina.Data;
using ProyectoAndina.Funciones_Generales;
using ProyectoAndina.Models;
using ProyectoAndina.Utils;
using System;
using System.Windows.Forms;
using static ProyectoAndina.Utils.StylesAlertas;

namespace ProyectoAndina.Views
{
    public partial class RolForm : Form
    {

        private readonly RolController _RolController;
        private OpenFileDialog openFileDialog1;
        private FontAwesome.Sharp.IconButton button_regresar;
        private Panel panel_mensaje;
        private Label label_mensaje;
        private TableLayoutPanel tableLayoutPanel_logueado;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label_titulo_roles;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel_crear;
        private Button button_agregar_rol;
        private Label label_titulo_acciones;
        private TableLayoutPanel tableLayoutPanel_roles;
        private int idRol;

        public RolForm()
        {
            InitializeComponent();
            _RolController = new RolController();
            CargarRolesTable();
            ConfigurarEstilo();
            this.Paint += RolForm_Paint;
            this.DoubleBuffered = true;
            // se despliega en toda la pantalla
            this.WindowState = FormWindowState.Maximized;


            // Nuevo: Configurar evento de editar
            _styleTablas.OnEditarClicked = (id) =>
            {
                AbrirFormularioEdicion(id);
            };

            // Nuevo: Configurar evento de eliminar
            _styleTablas.OnEliminarClicked = (id) =>
            {
                ConfirmarEliminarRol(id);
            };

        }
        private void AbrirFormularioEdicion(int idRol)
        {
           
            var RolCrudForm = new RolCrudForm(idRol, this);
            RolCrudForm.StartPosition = FormStartPosition.CenterParent;

            DialogResult resultado = RolCrudForm.ShowDialog(this);

            if (RolCrudForm.DialogResult == DialogResult.OK)
            {
                CargarRolesTable();

            }
           
              
        }

        // Método para confirmar eliminación
        private void ConfirmarEliminarRol(int idRol)
        {
            try
            {
                var resultado = MessageBox.Show(
                    $"¿Estás seguro de que quieres eliminar el rol con ID {idRol}?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                   
                    MessageBox.Show($"Rol con ID {idRol} eliminado correctamente.", "Éxito",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RolController.EliminarRol(idRol);
                    StylesAlertas.MostrarAlerta(this, "Registro eliminado correctamente", tipo: TipoAlerta.Success);
                    CargarRolesTable();

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar rol: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RolForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }

        public void ConfigurarEstilo()
        {
            StyleManager.ConfigurarFormPrincipal(this, "Menu de Roles");
            this.BackColor = StyleManager.Colors.GrisClaro;



            // Configurar labels con estilos UASB
            StyleManager.ConfigurarLabel(label_titulo_roles, TipoLabel.TituloGrande);
            StyleManager.ConfigurarLabel(label_titulo_acciones, TipoLabel.TituloMedio);


            //configurar los botones
            StyleManager.ConfigurarBotonIconoEnPanel(panel_crear, button_agregar_rol, FontAwesome.Sharp.IconChar.PlusCircle, Color.MediumAquamarine);
           

            // Configurar panel principal con sombra
            StyleManager.ConfigurarBotonPrincipalIcono(
              button_regresar,
              FontAwesome.Sharp.IconChar.SignOutAlt,
              "Regresar",
              colorFondo: Color.FromArgb(231, 76, 60)
              );


        }

        private void InitializeComponent()
        {
            openFileDialog1 = new OpenFileDialog();
            button_regresar = new FontAwesome.Sharp.IconButton();
            tableLayoutPanel_logueado = new TableLayoutPanel();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label_titulo_roles = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel_crear = new Panel();
            button_agregar_rol = new Button();
            label_titulo_acciones = new Label();
            tableLayoutPanel_roles = new TableLayoutPanel();
            tableLayoutPanel_logueado.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel_crear.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // button_regresar
            // 
            button_regresar.BackColor = Color.FromArgb(41, 128, 185);
            button_regresar.Cursor = Cursors.Hand;
            button_regresar.FlatAppearance.BorderSize = 0;
            button_regresar.FlatStyle = FlatStyle.Flat;
            button_regresar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_regresar.ForeColor = Color.White;
            button_regresar.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            button_regresar.IconColor = Color.White;
            button_regresar.IconFont = FontAwesome.Sharp.IconFont.Auto;
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
            // tableLayoutPanel_logueado
            // 
            tableLayoutPanel_logueado.BackColor = Color.Transparent;
            tableLayoutPanel_logueado.ColumnCount = 3;
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel_logueado.Controls.Add(button_regresar, 0, 0);
            tableLayoutPanel_logueado.Controls.Add(panel1, 2, 0);
            tableLayoutPanel_logueado.Controls.Add(label_titulo_roles, 1, 0);
            tableLayoutPanel_logueado.Dock = DockStyle.Top;
            tableLayoutPanel_logueado.Location = new Point(0, 0);
            tableLayoutPanel_logueado.Name = "tableLayoutPanel_logueado";
            tableLayoutPanel_logueado.RowCount = 1;
            tableLayoutPanel_logueado.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_logueado.Size = new Size(1102, 77);
            tableLayoutPanel_logueado.TabIndex = 108;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(829, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(270, 71);
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
            // label_titulo_roles
            // 
            label_titulo_roles.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_roles.AutoSize = true;
            label_titulo_roles.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_roles.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_roles.Location = new Point(278, 20);
            label_titulo_roles.Name = "label_titulo_roles";
            label_titulo_roles.Size = new Size(545, 37);
            label_titulo_roles.TabIndex = 79;
            label_titulo_roles.Text = "Lista de roles";
            label_titulo_roles.TextAlign = ContentAlignment.MiddleCenter;
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
            tableLayoutPanel1.Controls.Add(tableLayoutPanel_roles, 2, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 77);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.Size = new Size(1102, 458);
            tableLayoutPanel1.TabIndex = 109;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(panel_crear, 0, 2);
            tableLayoutPanel2.Controls.Add(label_titulo_acciones, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(62, 25);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 227F));
            tableLayoutPanel2.Size = new Size(241, 406);
            tableLayoutPanel2.TabIndex = 9;
            // 
            // panel_crear
            // 
            panel_crear.BackColor = Color.Transparent;
            panel_crear.Controls.Add(button_agregar_rol);
            panel_crear.Dock = DockStyle.Fill;
            panel_crear.Location = new Point(3, 181);
            panel_crear.Name = "panel_crear";
            panel_crear.Size = new Size(235, 222);
            panel_crear.TabIndex = 78;
            // 
            // button_agregar_rol
            // 
            button_agregar_rol.BackColor = Color.FromArgb(52, 152, 219);
            button_agregar_rol.Cursor = Cursors.Hand;
            button_agregar_rol.FlatAppearance.BorderSize = 0;
            button_agregar_rol.FlatStyle = FlatStyle.Flat;
            button_agregar_rol.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_agregar_rol.ForeColor = Color.White;
            button_agregar_rol.Location = new Point(35, 47);
            button_agregar_rol.Name = "button_agregar_rol";
            button_agregar_rol.Size = new Size(135, 58);
            button_agregar_rol.TabIndex = 24;
            button_agregar_rol.Text = "Agregar";
            button_agregar_rol.UseVisualStyleBackColor = false;
            button_agregar_rol.Click += button_agregar_rol_Click;
            // 
            // label_titulo_acciones
            // 
            label_titulo_acciones.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_acciones.AutoSize = true;
            label_titulo_acciones.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_acciones.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_acciones.Location = new Point(3, 115);
            label_titulo_acciones.Name = "label_titulo_acciones";
            label_titulo_acciones.Size = new Size(235, 37);
            label_titulo_acciones.TabIndex = 28;
            label_titulo_acciones.Text = "Acciones";
            // 
            // tableLayoutPanel_roles
            // 
            tableLayoutPanel_roles.ColumnCount = 2;
            tableLayoutPanel_roles.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_roles.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_roles.Dock = DockStyle.Fill;
            tableLayoutPanel_roles.Location = new Point(309, 25);
            tableLayoutPanel_roles.Name = "tableLayoutPanel_roles";
            tableLayoutPanel_roles.RowCount = 2;
            tableLayoutPanel_roles.RowStyles.Add(new RowStyle(SizeType.Percent, 50.56818F));
            tableLayoutPanel_roles.RowStyles.Add(new RowStyle(SizeType.Percent, 49.43182F));
            tableLayoutPanel_roles.Size = new Size(729, 406);
            tableLayoutPanel_roles.TabIndex = 8;
            // 
            // RolForm
            // 
            ClientSize = new Size(1102, 535);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tableLayoutPanel_logueado);
            Name = "RolForm";
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






        private readonly StyleTablas _styleTablas = new StyleTablas();
        private void CargarRolesTable()
        {
            try
            {
                var roles = _RolController.ObtenerRoles();
                var panel = tableLayoutPanel_roles;
                panel.SuspendLayout();
                panel.Controls.Clear();
                panel.RowStyles.Clear();
                panel.ColumnStyles.Clear();
                panel.ColumnCount = 5; // Aumentamos a 5 columnas (agregamos columna de acciones)
                panel.RowCount = 1;
                panel.AutoScroll = true;
                panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                panel.BackColor = Color.FromArgb(245, 245, 245);

                // Configuración de columnas
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 0)); // ID (oculto)
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F)); // Nombre
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F)); // Descripción
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F)); // Estado
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F)); // Acciones
                panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));

                // Encabezados
                _styleTablas.AgregarCelda(panel, "", 0, 0, true);
                _styleTablas.AgregarCelda(panel, "Nombre", 1, 0, true);
                _styleTablas.AgregarCelda(panel, "Descripción", 2, 0, true);
                _styleTablas.AgregarCelda(panel, "Estado", 3, 0, true);
                _styleTablas.AgregarCelda(panel, "Acciones", 4, 0, true);

                int fila = 1;
                foreach (var rol in roles)
                {
                    panel.RowCount++;
                    panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F)); // Aumentamos altura para los botones

                    _styleTablas.AgregarCelda(panel, rol.RolId.ToString() ?? "N/A", 0, fila);
                    _styleTablas.AgregarCelda(panel, rol.Nombre ?? "N/A", 1, fila);
                    _styleTablas.AgregarCelda(panel, rol.Descripcion ?? "N/A", 2, fila);
                    _styleTablas.AgregarCelda(panel, rol.Estado ? "Activo" : "Inactivo", 3, fila);

                    // Agregar panel de botones de acción
                    _styleTablas.AgregarPanelAcciones(panel, rol.RolId, 4, fila);

                    fila++;
                }
                panel.ResumeLayout(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar roles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void button_regresar_Click(object sender, EventArgs e)
        {
            var AdministracionFrom = new AdministracionFrom();
            this.Hide();                 // Opcional: ocultas la ventana actual
            AdministracionFrom.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
            this.Close();
        }

       



        private void button_eliminar_rol_Click(object sender, EventArgs e)
        {

            var rol = _RolController.ObtenerRolPorId(idRol);


            if (idRol > 0)
            {
                var resultado = MessageBox.Show(
                    $"¿Desea eliminar el rol: \"{rol.Nombre}\"?",
                    "Confirmar eliminación",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (resultado == DialogResult.OK)
                {
                    int idRolEliminar = idRol;

                    if (idRolEliminar > 0)
                    {

                        // Recargar lista u otros datos
                        CargarRolesTable(); // si tienes una función así

                    }
                    else
                    {
                        StylesAlertas.MostrarAlerta(this, "ID de rol no válido.", "¡Error!", TipoAlerta.Error);
                    }
                }
            }
            else
            {
                StylesAlertas.MostrarAlerta(this, "Seleccione un rol que desea eliminar.", "¡Error!", TipoAlerta.Error);

            }

        }

        private void button_agregar_rol_Click(object sender, EventArgs e)
        {
            var RolCrudForm = new RolCrudForm(0, this);
            RolCrudForm.StartPosition = FormStartPosition.CenterParent;

            DialogResult resultado = RolCrudForm.ShowDialog(this);

            if (RolCrudForm.DialogResult == DialogResult.OK)
            {
                CargarRolesTable();

            }
        }
    }
}