namespace ProyectoAndina.Views
{
    partial class PersonaCrudForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel_logueado = new TableLayoutPanel();
            label_titulo_persona = new Label();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            button_agregar_persona = new Button();
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
            label_seg_nombre = new Label();
            textBox_direccion = new TextBox();
            label_direccion = new Label();
            textBox_telefono = new TextBox();
            textBox_fecha_nacimiento = new TextBox();
            label_seg_apellido = new Label();
            label_nacimiento = new Label();
            label_telefono = new Label();
            textBox_seg_nombre = new TextBox();
            textBox_seg_apellido = new TextBox();
            panel4 = new Panel();
            label_sexo = new Label();
            comboBox_nacionalidad = new ComboBox();
            label_estado_civil = new Label();
            comboBox_estado_civil = new ComboBox();
            label_nacionalidad = new Label();
            comboBox_sexo = new ComboBox();
            tableLayoutPanel_logueado.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox_eye_password).BeginInit();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel_logueado
            // 
            tableLayoutPanel_logueado.BackColor = Color.Transparent;
            tableLayoutPanel_logueado.ColumnCount = 3;
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel_logueado.Controls.Add(label_titulo_persona, 1, 0);
            tableLayoutPanel_logueado.Controls.Add(panel1, 2, 0);
            tableLayoutPanel_logueado.Dock = DockStyle.Top;
            tableLayoutPanel_logueado.Location = new Point(0, 0);
            tableLayoutPanel_logueado.Name = "tableLayoutPanel_logueado";
            tableLayoutPanel_logueado.RowCount = 1;
            tableLayoutPanel_logueado.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_logueado.Size = new Size(1129, 77);
            tableLayoutPanel_logueado.TabIndex = 110;
            // 
            // label_titulo_persona
            // 
            label_titulo_persona.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_persona.AutoSize = true;
            label_titulo_persona.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_persona.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_persona.Location = new Point(285, 20);
            label_titulo_persona.Name = "label_titulo_persona";
            label_titulo_persona.Size = new Size(558, 37);
            label_titulo_persona.TabIndex = 75;
            label_titulo_persona.Text = "Datos de la persona";
            label_titulo_persona.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(849, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(277, 71);
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
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.Controls.Add(button_agregar_persona, 2, 2);
            tableLayoutPanel1.Controls.Add(panel2, 1, 1);
            tableLayoutPanel1.Controls.Add(panel3, 2, 1);
            tableLayoutPanel1.Controls.Add(panel4, 3, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 77);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.Size = new Size(1129, 622);
            tableLayoutPanel1.TabIndex = 111;
            // 
            // button_agregar_persona
            // 
            button_agregar_persona.Anchor = AnchorStyles.None;
            button_agregar_persona.BackColor = Color.FromArgb(52, 152, 219);
            button_agregar_persona.Cursor = Cursors.Hand;
            button_agregar_persona.FlatAppearance.BorderSize = 0;
            button_agregar_persona.FlatStyle = FlatStyle.Flat;
            button_agregar_persona.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_agregar_persona.ForeColor = Color.White;
            button_agregar_persona.Location = new Point(452, 477);
            button_agregar_persona.Name = "button_agregar_persona";
            button_agregar_persona.Size = new Size(221, 102);
            button_agregar_persona.TabIndex = 15;
            button_agregar_persona.Text = "Accion";
            button_agregar_persona.UseVisualStyleBackColor = false;
            button_agregar_persona.Click += button_agregar_persona_Click;
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
            panel2.Location = new Point(59, 34);
            panel2.Name = "panel2";
            panel2.Size = new Size(332, 429);
            panel2.TabIndex = 0;
            // 
            // label_nombre
            // 
            label_nombre.AutoSize = true;
            label_nombre.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label_nombre.Location = new Point(3, 11);
            label_nombre.Name = "label_nombre";
            label_nombre.Size = new Size(108, 31);
            label_nombre.TabIndex = 0;
            label_nombre.Text = "Nombre:";
            // 
            // label_apellido
            // 
            label_apellido.AutoSize = true;
            label_apellido.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label_apellido.Location = new Point(3, 91);
            label_apellido.Name = "label_apellido";
            label_apellido.Size = new Size(111, 31);
            label_apellido.TabIndex = 1;
            label_apellido.Text = "Apellido:";
            // 
            // textBox_contrasenia
            // 
            textBox_contrasenia.Font = new Font("Segoe UI", 16.2F);
            textBox_contrasenia.Location = new Point(3, 365);
            textBox_contrasenia.Name = "textBox_contrasenia";
            textBox_contrasenia.PasswordChar = '●';
            textBox_contrasenia.Size = new Size(227, 43);
            textBox_contrasenia.TabIndex = 10;
            textBox_contrasenia.Click += textBox_contrasenia_Click;
            // 
            // textBox_correo
            // 
            textBox_correo.Font = new Font("Segoe UI", 16.2F);
            textBox_correo.Location = new Point(3, 285);
            textBox_correo.Name = "textBox_correo";
            textBox_correo.Size = new Size(227, 43);
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
            iconPictureBox_eye_password.Location = new Point(245, 376);
            iconPictureBox_eye_password.Name = "iconPictureBox_eye_password";
            iconPictureBox_eye_password.Size = new Size(39, 38);
            iconPictureBox_eye_password.TabIndex = 74;
            iconPictureBox_eye_password.TabStop = false;
            iconPictureBox_eye_password.Click += iconPictureBox_eye_password_Click;
            // 
            // textBox_cedula
            // 
            textBox_cedula.Font = new Font("Segoe UI", 16.2F);
            textBox_cedula.Location = new Point(3, 205);
            textBox_cedula.Name = "textBox_cedula";
            textBox_cedula.Size = new Size(227, 43);
            textBox_cedula.TabIndex = 8;
            textBox_cedula.Click += textBox_cedula_Click;
            // 
            // label_cedula
            // 
            label_cedula.AutoSize = true;
            label_cedula.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label_cedula.Location = new Point(3, 171);
            label_cedula.Name = "label_cedula";
            label_cedula.Size = new Size(93, 31);
            label_cedula.TabIndex = 2;
            label_cedula.Text = "Cedula:";
            // 
            // textBox_pri_apellido
            // 
            textBox_pri_apellido.Font = new Font("Segoe UI", 16.2F);
            textBox_pri_apellido.Location = new Point(3, 125);
            textBox_pri_apellido.Name = "textBox_pri_apellido";
            textBox_pri_apellido.Size = new Size(227, 43);
            textBox_pri_apellido.TabIndex = 7;
            textBox_pri_apellido.Click += textBox_pri_apellido_Click;
            // 
            // textBox_pri_nombre
            // 
            textBox_pri_nombre.Font = new Font("Segoe UI", 16.2F);
            textBox_pri_nombre.Location = new Point(3, 45);
            textBox_pri_nombre.Name = "textBox_pri_nombre";
            textBox_pri_nombre.Size = new Size(227, 43);
            textBox_pri_nombre.TabIndex = 6;
            textBox_pri_nombre.Click += textBox_pri_nombre_Click;
            // 
            // label_gmail
            // 
            label_gmail.AutoSize = true;
            label_gmail.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label_gmail.Location = new Point(3, 251);
            label_gmail.Name = "label_gmail";
            label_gmail.Size = new Size(92, 31);
            label_gmail.TabIndex = 3;
            label_gmail.Text = "Correo:";
            // 
            // label_password
            // 
            label_password.AutoSize = true;
            label_password.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label_password.Location = new Point(3, 331);
            label_password.Name = "label_password";
            label_password.Size = new Size(140, 31);
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
            panel3.Location = new Point(397, 34);
            panel3.Name = "panel3";
            panel3.Size = new Size(332, 429);
            panel3.TabIndex = 1;
            // 
            // label_seg_nombre
            // 
            label_seg_nombre.AutoSize = true;
            label_seg_nombre.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label_seg_nombre.Location = new Point(3, 11);
            label_seg_nombre.Name = "label_seg_nombre";
            label_seg_nombre.Size = new Size(209, 31);
            label_seg_nombre.TabIndex = 23;
            label_seg_nombre.Text = "Segundo Nombre:";
            // 
            // textBox_direccion
            // 
            textBox_direccion.Font = new Font("Segoe UI", 16.2F);
            textBox_direccion.Location = new Point(3, 285);
            textBox_direccion.Name = "textBox_direccion";
            textBox_direccion.Size = new Size(227, 43);
            textBox_direccion.TabIndex = 18;
            textBox_direccion.Click += textBox_direccion_Click;
            // 
            // label_direccion
            // 
            label_direccion.AutoSize = true;
            label_direccion.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label_direccion.Location = new Point(3, 251);
            label_direccion.Name = "label_direccion";
            label_direccion.Size = new Size(122, 31);
            label_direccion.TabIndex = 17;
            label_direccion.Text = "Dirección:";
            // 
            // textBox_telefono
            // 
            textBox_telefono.Font = new Font("Segoe UI", 16.2F);
            textBox_telefono.Location = new Point(3, 205);
            textBox_telefono.Name = "textBox_telefono";
            textBox_telefono.Size = new Size(227, 43);
            textBox_telefono.TabIndex = 16;
            textBox_telefono.Click += textBox_telefono_Click;
            // 
            // textBox_fecha_nacimiento
            // 
            textBox_fecha_nacimiento.Font = new Font("Segoe UI", 16.2F);
            textBox_fecha_nacimiento.Location = new Point(3, 365);
            textBox_fecha_nacimiento.Name = "textBox_fecha_nacimiento";
            textBox_fecha_nacimiento.Size = new Size(227, 43);
            textBox_fecha_nacimiento.TabIndex = 30;
            // 
            // label_seg_apellido
            // 
            label_seg_apellido.AutoSize = true;
            label_seg_apellido.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label_seg_apellido.Location = new Point(3, 91);
            label_seg_apellido.Name = "label_seg_apellido";
            label_seg_apellido.Size = new Size(212, 31);
            label_seg_apellido.TabIndex = 24;
            label_seg_apellido.Text = "Segundo Apellido:";
            // 
            // label_nacimiento
            // 
            label_nacimiento.AutoSize = true;
            label_nacimiento.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label_nacimiento.Location = new Point(3, 331);
            label_nacimiento.Name = "label_nacimiento";
            label_nacimiento.Size = new Size(238, 31);
            label_nacimiento.TabIndex = 29;
            label_nacimiento.Text = "Fecha de Nacimiento";
            // 
            // label_telefono
            // 
            label_telefono.AutoSize = true;
            label_telefono.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label_telefono.Location = new Point(3, 171);
            label_telefono.Name = "label_telefono";
            label_telefono.Size = new Size(113, 31);
            label_telefono.TabIndex = 15;
            label_telefono.Text = "Telefono:";
            // 
            // textBox_seg_nombre
            // 
            textBox_seg_nombre.Font = new Font("Segoe UI", 16.2F);
            textBox_seg_nombre.Location = new Point(3, 45);
            textBox_seg_nombre.Name = "textBox_seg_nombre";
            textBox_seg_nombre.Size = new Size(227, 43);
            textBox_seg_nombre.TabIndex = 25;
            textBox_seg_nombre.Click += textBox_seg_nombre_Click;
            // 
            // textBox_seg_apellido
            // 
            textBox_seg_apellido.Font = new Font("Segoe UI", 16.2F);
            textBox_seg_apellido.Location = new Point(3, 125);
            textBox_seg_apellido.Name = "textBox_seg_apellido";
            textBox_seg_apellido.Size = new Size(227, 43);
            textBox_seg_apellido.TabIndex = 26;
            textBox_seg_apellido.Click += textBox_seg_apellido_Click;
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
            panel4.Location = new Point(735, 34);
            panel4.Name = "panel4";
            panel4.Size = new Size(332, 429);
            panel4.TabIndex = 2;
            // 
            // label_sexo
            // 
            label_sexo.AutoSize = true;
            label_sexo.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label_sexo.Location = new Point(17, 11);
            label_sexo.Name = "label_sexo";
            label_sexo.Size = new Size(72, 31);
            label_sexo.TabIndex = 19;
            label_sexo.Text = "Sexo:";
            // 
            // comboBox_nacionalidad
            // 
            comboBox_nacionalidad.Font = new Font("Segoe UI", 16.2F);
            comboBox_nacionalidad.FormattingEnabled = true;
            comboBox_nacionalidad.Location = new Point(17, 199);
            comboBox_nacionalidad.Name = "comboBox_nacionalidad";
            comboBox_nacionalidad.Size = new Size(151, 45);
            comboBox_nacionalidad.TabIndex = 33;
            // 
            // label_estado_civil
            // 
            label_estado_civil.AutoSize = true;
            label_estado_civil.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label_estado_civil.Location = new Point(17, 89);
            label_estado_civil.Name = "label_estado_civil";
            label_estado_civil.Size = new Size(144, 31);
            label_estado_civil.TabIndex = 21;
            label_estado_civil.Text = "Estado Civil:";
            // 
            // comboBox_estado_civil
            // 
            comboBox_estado_civil.Font = new Font("Segoe UI", 16.2F);
            comboBox_estado_civil.FormattingEnabled = true;
            comboBox_estado_civil.Location = new Point(17, 121);
            comboBox_estado_civil.Name = "comboBox_estado_civil";
            comboBox_estado_civil.Size = new Size(151, 45);
            comboBox_estado_civil.TabIndex = 32;
            // 
            // label_nacionalidad
            // 
            label_nacionalidad.AutoSize = true;
            label_nacionalidad.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label_nacionalidad.Location = new Point(17, 167);
            label_nacionalidad.Name = "label_nacionalidad";
            label_nacionalidad.Size = new Size(162, 31);
            label_nacionalidad.TabIndex = 27;
            label_nacionalidad.Text = "Nacionalidad:";
            // 
            // comboBox_sexo
            // 
            comboBox_sexo.Font = new Font("Segoe UI", 16.2F);
            comboBox_sexo.FormattingEnabled = true;
            comboBox_sexo.Location = new Point(17, 43);
            comboBox_sexo.Name = "comboBox_sexo";
            comboBox_sexo.Size = new Size(151, 45);
            comboBox_sexo.TabIndex = 31;
            // 
            // PersonaCrudForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1129, 699);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tableLayoutPanel_logueado);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PersonaCrudForm";
            Text = "PersonasCrudForm";
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
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel_logueado;
        private Label label_titulo_persona;
        private Panel panel1;
        private PictureBox pictureBox1;
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
        private Label label_seg_nombre;
        private TextBox textBox_direccion;
        private Label label_direccion;
        private TextBox textBox_telefono;
        private TextBox textBox_fecha_nacimiento;
        private Label label_seg_apellido;
        private Label label_nacimiento;
        private Label label_telefono;
        private TextBox textBox_seg_nombre;
        private TextBox textBox_seg_apellido;
        private Panel panel4;
        private Label label_sexo;
        private ComboBox comboBox_nacionalidad;
        private Label label_estado_civil;
        private ComboBox comboBox_estado_civil;
        private Label label_nacionalidad;
        private ComboBox comboBox_sexo;
        private Button button_agregar_persona;
    }
}