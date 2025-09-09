using ProyectoAndina.Controllers;
using ProyectoAndina.Data;
using ProyectoAndina.Helper;
using ProyectoAndina.Models;
using ProyectoAndina.Utils;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static ProyectoAndina.Utils.StylesAlertas;

namespace ProyectoAndina.Views
{
    public partial class PersonaCrudForm : Form
    {

        private readonly PersonaController _PersonaController;
        private readonly FuncionesGenerales _FuncionesGenerales;
        private int idPersona;
        private bool mostrarContrasenia = false;
        private Label label_titulo_persona;
        private TableLayoutPanel tableLayoutPanel_logueado;
        private FontAwesome.Sharp.IconButton button_regresar;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label_sexo;
        private TextBox textBox_direccion;
        private Label label_estado_civil;
        private Label label_direccion;
        private Label label_seg_nombre;
        private TextBox textBox_telefono;
        private Label label_seg_apellido;
        private Label label_telefono;
        private TextBox textBox_seg_nombre;
        private TextBox textBox_seg_apellido;
        private Label label_nacionalidad;
        private Label label_nacimiento;
        private TextBox textBox_fecha_nacimiento;
        private ComboBox comboBox_sexo;
        private ComboBox comboBox_estado_civil;
        private ComboBox comboBox_nacionalidad;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private Label label_nombre;
        private Label label_apellido;
        private TextBox textBox_contrasenia;
        private TextBox textBox_correo;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox_eye_password;
        private TextBox textBox_cedula;
        private Label label_cedula;
        private TextBox textBox_pri_apellido;
        private TextBox textBox_pri_nombre;
        private Label label_gmail;
        private Label label_password;
        private Panel panel3;
        private Panel panel4;
        private Panel panel_accion;
        private Button button_agregar_persona;
        private Form _formularioPadre;
        public PersonaCrudForm(int idPer, Form formularioPadre = null)
        {
            _PersonaController = new PersonaController();
            _FuncionesGenerales = new FuncionesGenerales();

            InitializeComponent();
            CargarComboBox();
            ConfigurarEstilo();
            this.Paint += PersonaCrudForm_Paint;
            this.DoubleBuffered = true;
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            if (idPer > 0)
            {
                cargarDatosPersona(idPer);
                idPersona = idPer;
                _formularioPadre = formularioPadre;

            }
            else
            {
                encerarVariables();
            }

        }

        private void PersonaCrudForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }

        public void ConfigurarEstilo()
        {
            StyleManager.ConfigurarFormPrincipal(this, "Menu de Usuarios");
            this.BackColor = StyleManager.Colors.GrisClaro;

            // Configurar labels con estilos UASB
            StyleManager.ConfigurarLabel(label_titulo_persona, TipoLabel.TituloGrande);

            //configurar los botones
            if (idPersona == 0)
            {
                StyleManager.ConfigurarBotonIconoEnPanel(panel_accion,button_agregar_persona, FontAwesome.Sharp.IconChar.Rotate, Color.LightSteelBlue);
            }
            else
            {
                StyleManager.ConfigurarBotonIconoEnPanel(panel_accion,button_agregar_persona, FontAwesome.Sharp.IconChar.PlusCircle, Color.MediumAquamarine);
            }

            //configurar los botones


            // Configurar panel principal con sombra
            StyleManager.ConfigurarBotonPrincipalIcono(
             button_regresar,
             FontAwesome.Sharp.IconChar.SignOutAlt,
             "Regresar",
             colorFondo: Color.FromArgb(231, 76, 60)
             );

        }

        public void encerarVariables()
        {
            _FuncionesGenerales.LimpiarCampos(this);
            label_titulo_persona.Text = "Crear usuario";
            button_agregar_persona.Text = "Crear";

            comboBox_sexo.SelectedIndex = -1;
            comboBox_estado_civil.SelectedIndex = -1;
            comboBox_nacionalidad.SelectedIndex = -1;
        }

        private void InitializeComponent()
        {
            label_titulo_persona = new Label();
            tableLayoutPanel_logueado = new TableLayoutPanel();
            button_regresar = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label_sexo = new Label();
            textBox_direccion = new TextBox();
            label_estado_civil = new Label();
            label_direccion = new Label();
            label_seg_nombre = new Label();
            textBox_telefono = new TextBox();
            label_seg_apellido = new Label();
            label_telefono = new Label();
            textBox_seg_nombre = new TextBox();
            textBox_seg_apellido = new TextBox();
            label_nacionalidad = new Label();
            label_nacimiento = new Label();
            textBox_fecha_nacimiento = new TextBox();
            comboBox_sexo = new ComboBox();
            comboBox_estado_civil = new ComboBox();
            comboBox_nacionalidad = new ComboBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            label_nombre = new Label();
            label_apellido = new Label();
            textBox_contrasenia = new TextBox();
            textBox_correo = new TextBox();
            iconPictureBox_eye_password = new FontAwesome.Sharp.IconPictureBox();
            textBox_cedula = new TextBox();
            label_cedula = new Label();
            textBox_pri_apellido = new TextBox();
            textBox_pri_nombre = new TextBox();
            label_gmail = new Label();
            label_password = new Label();
            panel3 = new Panel();
            panel4 = new Panel();
            panel_accion = new Panel();
            button_agregar_persona = new Button();
            tableLayoutPanel_logueado.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox_eye_password).BeginInit();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel_accion.SuspendLayout();
            SuspendLayout();
            // 
            // label_titulo_persona
            // 
            label_titulo_persona.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_persona.AutoSize = true;
            label_titulo_persona.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_persona.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_persona.Location = new Point(276, 20);
            label_titulo_persona.Name = "label_titulo_persona";
            label_titulo_persona.Size = new Size(541, 37);
            label_titulo_persona.TabIndex = 75;
            label_titulo_persona.Text = "Datos de la persona";
            label_titulo_persona.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel_logueado
            // 
            tableLayoutPanel_logueado.BackColor = Color.Transparent;
            tableLayoutPanel_logueado.ColumnCount = 3;
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel_logueado.Controls.Add(label_titulo_persona, 1, 0);
            tableLayoutPanel_logueado.Controls.Add(button_regresar, 0, 0);
            tableLayoutPanel_logueado.Controls.Add(panel1, 2, 0);
            tableLayoutPanel_logueado.Dock = DockStyle.Top;
            tableLayoutPanel_logueado.Location = new Point(0, 0);
            tableLayoutPanel_logueado.Name = "tableLayoutPanel_logueado";
            tableLayoutPanel_logueado.RowCount = 1;
            tableLayoutPanel_logueado.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_logueado.Size = new Size(1094, 77);
            tableLayoutPanel_logueado.TabIndex = 109;
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
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(823, 3);
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
            // label_sexo
            // 
            label_sexo.AutoSize = true;
            label_sexo.Location = new Point(17, 11);
            label_sexo.Name = "label_sexo";
            label_sexo.Size = new Size(44, 20);
            label_sexo.TabIndex = 19;
            label_sexo.Text = "Sexo:";
            // 
            // textBox_direccion
            // 
            textBox_direccion.Location = new Point(3, 235);
            textBox_direccion.Name = "textBox_direccion";
            textBox_direccion.Size = new Size(227, 27);
            textBox_direccion.TabIndex = 18;
            textBox_direccion.Click += textBox_direccion_Click;
            // 
            // label_estado_civil
            // 
            label_estado_civil.AutoSize = true;
            label_estado_civil.Location = new Point(17, 74);
            label_estado_civil.Name = "label_estado_civil";
            label_estado_civil.Size = new Size(89, 20);
            label_estado_civil.TabIndex = 21;
            label_estado_civil.Text = "Estado Civil:";
            // 
            // label_direccion
            // 
            label_direccion.AutoSize = true;
            label_direccion.Location = new Point(3, 206);
            label_direccion.Name = "label_direccion";
            label_direccion.Size = new Size(75, 20);
            label_direccion.TabIndex = 17;
            label_direccion.Text = "Dirección:";
            // 
            // label_seg_nombre
            // 
            label_seg_nombre.AutoSize = true;
            label_seg_nombre.Location = new Point(3, 11);
            label_seg_nombre.Name = "label_seg_nombre";
            label_seg_nombre.Size = new Size(130, 20);
            label_seg_nombre.TabIndex = 23;
            label_seg_nombre.Text = "Segundo Nombre:";
            // 
            // textBox_telefono
            // 
            textBox_telefono.Location = new Point(3, 170);
            textBox_telefono.Name = "textBox_telefono";
            textBox_telefono.Size = new Size(227, 27);
            textBox_telefono.TabIndex = 16;
            textBox_telefono.Click += textBox_telefono_Click;
            // 
            // label_seg_apellido
            // 
            label_seg_apellido.AutoSize = true;
            label_seg_apellido.Location = new Point(3, 76);
            label_seg_apellido.Name = "label_seg_apellido";
            label_seg_apellido.Size = new Size(132, 20);
            label_seg_apellido.TabIndex = 24;
            label_seg_apellido.Text = "Segundo Apellido:";
            // 
            // label_telefono
            // 
            label_telefono.AutoSize = true;
            label_telefono.Location = new Point(3, 141);
            label_telefono.Name = "label_telefono";
            label_telefono.Size = new Size(70, 20);
            label_telefono.TabIndex = 15;
            label_telefono.Text = "Telefono:";
            // 
            // textBox_seg_nombre
            // 
            textBox_seg_nombre.Location = new Point(3, 40);
            textBox_seg_nombre.Name = "textBox_seg_nombre";
            textBox_seg_nombre.Size = new Size(227, 27);
            textBox_seg_nombre.TabIndex = 25;
            textBox_seg_nombre.Click += textBox_seg_nombre_Click;
            // 
            // textBox_seg_apellido
            // 
            textBox_seg_apellido.Location = new Point(3, 105);
            textBox_seg_apellido.Name = "textBox_seg_apellido";
            textBox_seg_apellido.Size = new Size(227, 27);
            textBox_seg_apellido.TabIndex = 26;
            textBox_seg_apellido.Click += textBox_seg_apellido_Click;
            // 
            // label_nacionalidad
            // 
            label_nacionalidad.AutoSize = true;
            label_nacionalidad.Location = new Point(17, 138);
            label_nacionalidad.Name = "label_nacionalidad";
            label_nacionalidad.Size = new Size(101, 20);
            label_nacionalidad.TabIndex = 27;
            label_nacionalidad.Text = "Nacionalidad:";
            // 
            // label_nacimiento
            // 
            label_nacimiento.AutoSize = true;
            label_nacimiento.Location = new Point(3, 271);
            label_nacimiento.Name = "label_nacimiento";
            label_nacimiento.Size = new Size(149, 20);
            label_nacimiento.TabIndex = 29;
            label_nacimiento.Text = "Fecha de Nacimiento";
            // 
            // textBox_fecha_nacimiento
            // 
            textBox_fecha_nacimiento.Location = new Point(3, 300);
            textBox_fecha_nacimiento.Name = "textBox_fecha_nacimiento";
            textBox_fecha_nacimiento.Size = new Size(227, 27);
            textBox_fecha_nacimiento.TabIndex = 30;
            textBox_fecha_nacimiento.Click += textBox_fecha_nacimiento_Click;
            // 
            // comboBox_sexo
            // 
            comboBox_sexo.FormattingEnabled = true;
            comboBox_sexo.Location = new Point(17, 33);
            comboBox_sexo.Name = "comboBox_sexo";
            comboBox_sexo.Size = new Size(151, 28);
            comboBox_sexo.TabIndex = 31;
            // 
            // comboBox_estado_civil
            // 
            comboBox_estado_civil.FormattingEnabled = true;
            comboBox_estado_civil.Location = new Point(17, 98);
            comboBox_estado_civil.Name = "comboBox_estado_civil";
            comboBox_estado_civil.Size = new Size(151, 28);
            comboBox_estado_civil.TabIndex = 32;
            // 
            // comboBox_nacionalidad
            // 
            comboBox_nacionalidad.FormattingEnabled = true;
            comboBox_nacionalidad.Location = new Point(17, 164);
            comboBox_nacionalidad.Name = "comboBox_nacionalidad";
            comboBox_nacionalidad.Size = new Size(151, 28);
            comboBox_nacionalidad.TabIndex = 33;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.Controls.Add(panel2, 1, 1);
            tableLayoutPanel1.Controls.Add(panel3, 2, 1);
            tableLayoutPanel1.Controls.Add(panel4, 3, 1);
            tableLayoutPanel1.Controls.Add(panel_accion, 2, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 77);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.Size = new Size(1094, 552);
            tableLayoutPanel1.TabIndex = 110;
            // 
            // panel2
            // 
            panel2.Controls.Add(label_nombre);
            panel2.Controls.Add(label_apellido);
            panel2.Controls.Add(textBox_contrasenia);
            panel2.Controls.Add(textBox_correo);
            panel2.Controls.Add(iconPictureBox_eye_password);
            panel2.Controls.Add(textBox_cedula);
            panel2.Controls.Add(label_cedula);
            panel2.Controls.Add(textBox_pri_apellido);
            panel2.Controls.Add(textBox_pri_nombre);
            panel2.Controls.Add(label_gmail);
            panel2.Controls.Add(label_password);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(57, 30);
            panel2.Name = "panel2";
            panel2.Size = new Size(322, 380);
            panel2.TabIndex = 0;
            // 
            // label_nombre
            // 
            label_nombre.AutoSize = true;
            label_nombre.Location = new Point(3, 11);
            label_nombre.Name = "label_nombre";
            label_nombre.Size = new Size(67, 20);
            label_nombre.TabIndex = 0;
            label_nombre.Text = "Nombre:";
            // 
            // label_apellido
            // 
            label_apellido.AutoSize = true;
            label_apellido.Location = new Point(3, 76);
            label_apellido.Name = "label_apellido";
            label_apellido.Size = new Size(69, 20);
            label_apellido.TabIndex = 1;
            label_apellido.Text = "Apellido:";
            // 
            // textBox_contrasenia
            // 
            textBox_contrasenia.Location = new Point(3, 300);
            textBox_contrasenia.Name = "textBox_contrasenia";
            textBox_contrasenia.PasswordChar = '●';
            textBox_contrasenia.Size = new Size(227, 27);
            textBox_contrasenia.TabIndex = 10;
            textBox_contrasenia.Click += textBox_contrasenia_Click;
            // 
            // textBox_correo
            // 
            textBox_correo.Location = new Point(3, 235);
            textBox_correo.Name = "textBox_correo";
            textBox_correo.Size = new Size(227, 27);
            textBox_correo.TabIndex = 9;
            textBox_correo.Click += textBox_correo_Click;
            // 
            // iconPictureBox_eye_password
            // 
            iconPictureBox_eye_password.BackColor = Color.Transparent;
            iconPictureBox_eye_password.ForeColor = SystemColors.ControlText;
            iconPictureBox_eye_password.IconChar = FontAwesome.Sharp.IconChar.Eye;
            iconPictureBox_eye_password.IconColor = SystemColors.ControlText;
            iconPictureBox_eye_password.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox_eye_password.IconSize = 38;
            iconPictureBox_eye_password.Location = new Point(248, 300);
            iconPictureBox_eye_password.Name = "iconPictureBox_eye_password";
            iconPictureBox_eye_password.Size = new Size(39, 38);
            iconPictureBox_eye_password.TabIndex = 74;
            iconPictureBox_eye_password.TabStop = false;
            iconPictureBox_eye_password.Click += iconPictureBox_eye_password_Click;
            // 
            // textBox_cedula
            // 
            textBox_cedula.Location = new Point(3, 170);
            textBox_cedula.Name = "textBox_cedula";
            textBox_cedula.Size = new Size(227, 27);
            textBox_cedula.TabIndex = 8;
            textBox_cedula.Click += textBox_cedula_Click;
            // 
            // label_cedula
            // 
            label_cedula.AutoSize = true;
            label_cedula.Location = new Point(3, 141);
            label_cedula.Name = "label_cedula";
            label_cedula.Size = new Size(58, 20);
            label_cedula.TabIndex = 2;
            label_cedula.Text = "Cedula:";
            // 
            // textBox_pri_apellido
            // 
            textBox_pri_apellido.Location = new Point(3, 105);
            textBox_pri_apellido.Name = "textBox_pri_apellido";
            textBox_pri_apellido.Size = new Size(227, 27);
            textBox_pri_apellido.TabIndex = 7;
            textBox_pri_apellido.Click += textBox_pri_apellido_Click;
            // 
            // textBox_pri_nombre
            // 
            textBox_pri_nombre.Location = new Point(3, 40);
            textBox_pri_nombre.Name = "textBox_pri_nombre";
            textBox_pri_nombre.Size = new Size(227, 27);
            textBox_pri_nombre.TabIndex = 6;
            textBox_pri_nombre.Click += textBox_pri_nombre_Click;
            // 
            // label_gmail
            // 
            label_gmail.AutoSize = true;
            label_gmail.Location = new Point(3, 206);
            label_gmail.Name = "label_gmail";
            label_gmail.Size = new Size(57, 20);
            label_gmail.TabIndex = 3;
            label_gmail.Text = "Correo:";
            // 
            // label_password
            // 
            label_password.AutoSize = true;
            label_password.Location = new Point(3, 271);
            label_password.Name = "label_password";
            label_password.Size = new Size(86, 20);
            label_password.TabIndex = 4;
            label_password.Text = "Contraseña:";
            // 
            // panel3
            // 
            panel3.Controls.Add(label_seg_nombre);
            panel3.Controls.Add(textBox_direccion);
            panel3.Controls.Add(label_direccion);
            panel3.Controls.Add(textBox_telefono);
            panel3.Controls.Add(textBox_fecha_nacimiento);
            panel3.Controls.Add(label_seg_apellido);
            panel3.Controls.Add(label_nacimiento);
            panel3.Controls.Add(label_telefono);
            panel3.Controls.Add(textBox_seg_nombre);
            panel3.Controls.Add(textBox_seg_apellido);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(385, 30);
            panel3.Name = "panel3";
            panel3.Size = new Size(322, 380);
            panel3.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Controls.Add(label_sexo);
            panel4.Controls.Add(comboBox_nacionalidad);
            panel4.Controls.Add(label_estado_civil);
            panel4.Controls.Add(comboBox_estado_civil);
            panel4.Controls.Add(label_nacionalidad);
            panel4.Controls.Add(comboBox_sexo);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(713, 30);
            panel4.Name = "panel4";
            panel4.Size = new Size(322, 380);
            panel4.TabIndex = 2;
            // 
            // panel_accion
            // 
            panel_accion.Controls.Add(button_agregar_persona);
            panel_accion.Dock = DockStyle.Fill;
            panel_accion.Location = new Point(385, 416);
            panel_accion.Name = "panel_accion";
            panel_accion.Size = new Size(322, 104);
            panel_accion.TabIndex = 3;
            // 
            // button_agregar_persona
            // 
            button_agregar_persona.BackColor = Color.FromArgb(52, 152, 219);
            button_agregar_persona.Cursor = Cursors.Hand;
            button_agregar_persona.FlatAppearance.BorderSize = 0;
            button_agregar_persona.FlatStyle = FlatStyle.Flat;
            button_agregar_persona.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_agregar_persona.ForeColor = Color.White;
            button_agregar_persona.Location = new Point(85, 29);
            button_agregar_persona.Name = "button_agregar_persona";
            button_agregar_persona.Size = new Size(145, 40);
            button_agregar_persona.TabIndex = 14;
            button_agregar_persona.Text = "Accion";
            button_agregar_persona.UseVisualStyleBackColor = false;
            // 
            // PersonaCrudForm
            // 
            ClientSize = new Size(1094, 629);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tableLayoutPanel_logueado);
            Name = "PersonaCrudForm";
            tableLayoutPanel_logueado.ResumeLayout(false);
            tableLayoutPanel_logueado.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox_eye_password).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel_accion.ResumeLayout(false);
            ResumeLayout(false);

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
                textBox_fecha_nacimiento.Text = persona.fecha_nacimiento.ToString() ?? "";
                textBox_contrasenia.Text = persona.password ?? "";

                // Fecha de nacimiento
                textBox_fecha_nacimiento.Text = persona.fecha_nacimiento?.ToString("yyyy-MM-dd") ?? "";

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



        private void button_actualizar_persona_Click(object? sender, EventArgs e)
        {

        }

        private void button_agregar_persona_Click(object? sender, EventArgs e)
        {

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
                fecha_nacimiento = DateTime.TryParse(textBox_fecha_nacimiento?.Text.Trim(), out var fecha) ? fecha : (DateTime?)null,
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
                    this.DialogResult = DialogResult.OK; // opcional, útil si quieres saber desde el form padre que se creó
                    this.Close();
                }
                else
                {
                    _PersonaController.Insertar(persona);

                    StylesAlertas.MostrarAlerta(this, "Registro actualizado correctamente", tipo: TipoAlerta.Success);
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
            TecladoDesplegable.MostrarTeclado(_formularioPadre, textBox_pri_nombre);
        }

        private void textBox_pri_apellido_Click(object sender, EventArgs e)
        {
            TecladoDesplegable.MostrarTeclado(_formularioPadre, textBox_pri_apellido);

        }

        private void textBox_cedula_Click(object sender, EventArgs e)
        {
            TecladoDesplegable.MostrarTeclado(_formularioPadre, textBox_cedula, TipoTeclado.Numerico, soloNumerico: true);
        }

        private void textBox_correo_Click(object sender, EventArgs e)
        {
            TecladoDesplegable.MostrarTeclado(_formularioPadre, textBox_correo);

        }

        private void textBox_contrasenia_Click(object sender, EventArgs e)
        {
            TecladoDesplegable.MostrarTeclado(_formularioPadre, textBox_contrasenia);

        }

        private void textBox_seg_nombre_Click(object sender, EventArgs e)
        {
            TecladoDesplegable.MostrarTeclado(_formularioPadre, textBox_seg_nombre);

        }

        private void textBox_seg_apellido_Click(object sender, EventArgs e)
        {
            TecladoDesplegable.MostrarTeclado(_formularioPadre, textBox_seg_apellido);

        }

        private void textBox_telefono_Click(object sender, EventArgs e)
        {
            TecladoDesplegable.MostrarTeclado(_formularioPadre, textBox_telefono, TipoTeclado.Numerico, soloNumerico: true);
        }

        private void textBox_direccion_Click(object sender, EventArgs e)
        {
            TecladoDesplegable.MostrarTeclado(_formularioPadre, textBox_direccion);

        }

        private void textBox_fecha_nacimiento_Click(object sender, EventArgs e)
        {

        }

        private void button_regresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
