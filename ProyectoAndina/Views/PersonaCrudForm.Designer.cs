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
            panel3 = new Panel();
            textBox_seg_apellido = new TextBox();
            textBox_seg_nombre = new TextBox();
            label_password = new Label();
            label_seg_apellido = new Label();
            label_seg_nombre = new Label();
            textBox_contrasenia = new TextBox();
            iconPictureBox_eye_password = new FontAwesome.Sharp.IconPictureBox();
            panel2 = new Panel();
            label_gmail = new Label();
            textBox_pri_nombre = new TextBox();
            textBox_pri_apellido = new TextBox();
            textBox_correo = new TextBox();
            label_apellido = new Label();
            label_nombre = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            button_agregar_persona = new Button();
            panel4 = new Panel();
            tableLayoutPanel_logueado.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox_eye_password).BeginInit();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
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
            // panel3
            // 
            panel3.Controls.Add(label_seg_nombre);
            panel3.Controls.Add(label_seg_apellido);
            panel3.Controls.Add(textBox_seg_nombre);
            panel3.Controls.Add(textBox_seg_apellido);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(397, 21);
            panel3.Name = "panel3";
            panel3.Size = new Size(332, 208);
            panel3.TabIndex = 1;
            // 
            // textBox_seg_apellido
            // 
            textBox_seg_apellido.Font = new Font("Segoe UI", 16.2F);
            textBox_seg_apellido.Location = new Point(3, 140);
            textBox_seg_apellido.Name = "textBox_seg_apellido";
            textBox_seg_apellido.Size = new Size(227, 43);
            textBox_seg_apellido.TabIndex = 4;
            textBox_seg_apellido.Click += textBox_seg_apellido_Click;
            // 
            // textBox_seg_nombre
            // 
            textBox_seg_nombre.Font = new Font("Segoe UI", 16.2F);
            textBox_seg_nombre.Location = new Point(3, 50);
            textBox_seg_nombre.Name = "textBox_seg_nombre";
            textBox_seg_nombre.Size = new Size(227, 43);
            textBox_seg_nombre.TabIndex = 3;
            textBox_seg_nombre.Click += textBox_seg_nombre_Click;
            // 
            // label_password
            // 
            label_password.AutoSize = true;
            label_password.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label_password.Location = new Point(16, 101);
            label_password.Name = "label_password";
            label_password.Size = new Size(140, 31);
            label_password.TabIndex = 4;
            label_password.Text = "Contraseña:";
            // 
            // label_seg_apellido
            // 
            label_seg_apellido.AutoSize = true;
            label_seg_apellido.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label_seg_apellido.Location = new Point(3, 101);
            label_seg_apellido.Name = "label_seg_apellido";
            label_seg_apellido.Size = new Size(212, 31);
            label_seg_apellido.TabIndex = 24;
            label_seg_apellido.Text = "Segundo Apellido:";
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
            // textBox_contrasenia
            // 
            textBox_contrasenia.Font = new Font("Segoe UI", 16.2F);
            textBox_contrasenia.Location = new Point(16, 140);
            textBox_contrasenia.Name = "textBox_contrasenia";
            textBox_contrasenia.PasswordChar = '●';
            textBox_contrasenia.Size = new Size(227, 43);
            textBox_contrasenia.TabIndex = 6;
            textBox_contrasenia.Click += textBox_contrasenia_Click;
            // 
            // iconPictureBox_eye_password
            // 
            iconPictureBox_eye_password.BackColor = Color.Transparent;
            iconPictureBox_eye_password.ForeColor = SystemColors.ControlText;
            iconPictureBox_eye_password.IconChar = FontAwesome.Sharp.IconChar.Eye;
            iconPictureBox_eye_password.IconColor = SystemColors.ControlText;
            iconPictureBox_eye_password.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox_eye_password.IconSize = 38;
            iconPictureBox_eye_password.Location = new Point(261, 145);
            iconPictureBox_eye_password.Name = "iconPictureBox_eye_password";
            iconPictureBox_eye_password.Size = new Size(39, 38);
            iconPictureBox_eye_password.TabIndex = 74;
            iconPictureBox_eye_password.TabStop = false;
            iconPictureBox_eye_password.Click += iconPictureBox_eye_password_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(label_nombre);
            panel2.Controls.Add(label_apellido);
            panel2.Controls.Add(textBox_pri_apellido);
            panel2.Controls.Add(textBox_pri_nombre);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(59, 21);
            panel2.Name = "panel2";
            panel2.Size = new Size(332, 208);
            panel2.TabIndex = 0;
            // 
            // label_gmail
            // 
            label_gmail.AutoSize = true;
            label_gmail.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label_gmail.Location = new Point(16, 11);
            label_gmail.Name = "label_gmail";
            label_gmail.Size = new Size(92, 31);
            label_gmail.TabIndex = 3;
            label_gmail.Text = "Correo:";
            // 
            // textBox_pri_nombre
            // 
            textBox_pri_nombre.Font = new Font("Segoe UI", 16.2F);
            textBox_pri_nombre.Location = new Point(3, 50);
            textBox_pri_nombre.Name = "textBox_pri_nombre";
            textBox_pri_nombre.Size = new Size(227, 43);
            textBox_pri_nombre.TabIndex = 1;
            textBox_pri_nombre.Click += textBox_pri_nombre_Click;
            // 
            // textBox_pri_apellido
            // 
            textBox_pri_apellido.Font = new Font("Segoe UI", 16.2F);
            textBox_pri_apellido.Location = new Point(3, 140);
            textBox_pri_apellido.Name = "textBox_pri_apellido";
            textBox_pri_apellido.Size = new Size(227, 43);
            textBox_pri_apellido.TabIndex = 2;
            textBox_pri_apellido.Click += textBox_pri_apellido_Click;
            // 
            // textBox_correo
            // 
            textBox_correo.Font = new Font("Segoe UI", 16.2F);
            textBox_correo.Location = new Point(16, 50);
            textBox_correo.Name = "textBox_correo";
            textBox_correo.Size = new Size(227, 43);
            textBox_correo.TabIndex = 5;
            textBox_correo.Click += textBox_correo_Click;
            // 
            // label_apellido
            // 
            label_apellido.AutoSize = true;
            label_apellido.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label_apellido.Location = new Point(3, 101);
            label_apellido.Name = "label_apellido";
            label_apellido.Size = new Size(111, 31);
            label_apellido.TabIndex = 1;
            label_apellido.Text = "Apellido:";
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
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 57.99458F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 35.23035F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 1.58415842F));
            tableLayoutPanel1.Size = new Size(1129, 369);
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
            button_agregar_persona.Location = new Point(452, 259);
            button_agregar_persona.Name = "button_agregar_persona";
            button_agregar_persona.Size = new Size(221, 75);
            button_agregar_persona.TabIndex = 15;
            button_agregar_persona.Text = "Accion";
            button_agregar_persona.UseVisualStyleBackColor = false;
            button_agregar_persona.Click += button_agregar_persona_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(iconPictureBox_eye_password);
            panel4.Controls.Add(label_gmail);
            panel4.Controls.Add(textBox_correo);
            panel4.Controls.Add(textBox_contrasenia);
            panel4.Controls.Add(label_password);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(735, 21);
            panel4.Name = "panel4";
            panel4.Size = new Size(332, 208);
            panel4.TabIndex = 2;
            // 
            // PersonaCrudForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1129, 446);
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
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox_eye_password).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel_logueado;
        private Label label_titulo_persona;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Panel panel3;
        private Label label_seg_nombre;
        private Label label_seg_apellido;
        private TextBox textBox_seg_nombre;
        private TextBox textBox_seg_apellido;
        private Label label_password;
        private TextBox textBox_contrasenia;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox_eye_password;
        private Panel panel2;
        private Label label_nombre;
        private Label label_apellido;
        private TextBox textBox_pri_apellido;
        private TextBox textBox_pri_nombre;
        private Label label_gmail;
        private TextBox textBox_correo;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button_agregar_persona;
        private Panel panel4;
    }
}