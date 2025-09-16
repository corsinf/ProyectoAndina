namespace ProyectoAndina.Views
{
    partial class CrearUsuario
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
            pictureBox_logo_tipo = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel_titulo = new Panel();
            textBox_cedula = new TextBox();
            label_cedula = new Label();
            textBox_correo = new TextBox();
            label_gmail = new Label();
            textBox_direccion = new TextBox();
            label_direccion = new Label();
            textBox_telefono = new TextBox();
            label_telefono = new Label();
            textBox_pri_apellido = new TextBox();
            textBox_pri_nombre = new TextBox();
            label_apellido = new Label();
            label_nombre = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            button_agregar_usuario = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_tipo).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel_titulo.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox_logo_tipo
            // 
            pictureBox_logo_tipo.BackColor = Color.White;
            pictureBox_logo_tipo.Dock = DockStyle.Top;
            pictureBox_logo_tipo.Image = Properties.Resources.Logotipo_color;
            pictureBox_logo_tipo.Location = new Point(0, 0);
            pictureBox_logo_tipo.Name = "pictureBox_logo_tipo";
            pictureBox_logo_tipo.Size = new Size(503, 69);
            pictureBox_logo_tipo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_logo_tipo.TabIndex = 82;
            pictureBox_logo_tipo.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel_titulo, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 69);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 68.82591F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 31.17409F));
            tableLayoutPanel1.Size = new Size(503, 645);
            tableLayoutPanel1.TabIndex = 83;
            // 
            // panel_titulo
            // 
            panel_titulo.BackColor = Color.Transparent;
            panel_titulo.Controls.Add(textBox_cedula);
            panel_titulo.Controls.Add(label_cedula);
            panel_titulo.Controls.Add(textBox_correo);
            panel_titulo.Controls.Add(label_gmail);
            panel_titulo.Controls.Add(textBox_direccion);
            panel_titulo.Controls.Add(label_direccion);
            panel_titulo.Controls.Add(textBox_telefono);
            panel_titulo.Controls.Add(label_telefono);
            panel_titulo.Controls.Add(textBox_pri_apellido);
            panel_titulo.Controls.Add(textBox_pri_nombre);
            panel_titulo.Controls.Add(label_apellido);
            panel_titulo.Controls.Add(label_nombre);
            panel_titulo.Dock = DockStyle.Fill;
            panel_titulo.Location = new Point(3, 3);
            panel_titulo.Name = "panel_titulo";
            panel_titulo.Size = new Size(497, 437);
            panel_titulo.TabIndex = 81;
            // 
            // textBox_cedula
            // 
            textBox_cedula.Font = new Font("Segoe UI", 16.2F);
            textBox_cedula.Location = new Point(13, 50);
            textBox_cedula.Name = "textBox_cedula";
            textBox_cedula.Size = new Size(475, 43);
            textBox_cedula.TabIndex = 26;
            textBox_cedula.Click += textBox_cedula_Click;
            // 
            // label_cedula
            // 
            label_cedula.AutoSize = true;
            label_cedula.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label_cedula.Location = new Point(13, 12);
            label_cedula.Name = "label_cedula";
            label_cedula.Size = new Size(114, 38);
            label_cedula.TabIndex = 25;
            label_cedula.Text = "Cedula:";
            // 
            // textBox_correo
            // 
            textBox_correo.Font = new Font("Segoe UI", 16.2F);
            textBox_correo.Location = new Point(14, 212);
            textBox_correo.Name = "textBox_correo";
            textBox_correo.Size = new Size(469, 43);
            textBox_correo.TabIndex = 24;
            textBox_correo.Click += textBox_correo_Click;
            // 
            // label_gmail
            // 
            label_gmail.AutoSize = true;
            label_gmail.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label_gmail.Location = new Point(14, 174);
            label_gmail.Name = "label_gmail";
            label_gmail.Size = new Size(113, 38);
            label_gmail.TabIndex = 23;
            label_gmail.Text = "Correo:";
            // 
            // textBox_direccion
            // 
            textBox_direccion.Font = new Font("Segoe UI", 16.2F);
            textBox_direccion.Location = new Point(13, 374);
            textBox_direccion.Name = "textBox_direccion";
            textBox_direccion.Size = new Size(470, 43);
            textBox_direccion.TabIndex = 22;
            textBox_direccion.Click += textBox_direccion_Click;
            // 
            // label_direccion
            // 
            label_direccion.AutoSize = true;
            label_direccion.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label_direccion.Location = new Point(13, 336);
            label_direccion.Name = "label_direccion";
            label_direccion.Size = new Size(148, 38);
            label_direccion.TabIndex = 21;
            label_direccion.Text = "Dirección:";
            // 
            // textBox_telefono
            // 
            textBox_telefono.Font = new Font("Segoe UI", 16.2F);
            textBox_telefono.Location = new Point(13, 293);
            textBox_telefono.Name = "textBox_telefono";
            textBox_telefono.Size = new Size(470, 43);
            textBox_telefono.TabIndex = 20;
            textBox_telefono.Click += textBox_telefono_Click;
            // 
            // label_telefono
            // 
            label_telefono.AutoSize = true;
            label_telefono.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label_telefono.Location = new Point(13, 255);
            label_telefono.Name = "label_telefono";
            label_telefono.Size = new Size(138, 38);
            label_telefono.TabIndex = 19;
            label_telefono.Text = "Telefono:";
            // 
            // textBox_pri_apellido
            // 
            textBox_pri_apellido.Font = new Font("Segoe UI", 16.2F);
            textBox_pri_apellido.Location = new Point(240, 131);
            textBox_pri_apellido.Name = "textBox_pri_apellido";
            textBox_pri_apellido.Size = new Size(243, 43);
            textBox_pri_apellido.TabIndex = 11;
            textBox_pri_apellido.Click += textBox_pri_apellido_Click;
            // 
            // textBox_pri_nombre
            // 
            textBox_pri_nombre.Font = new Font("Segoe UI", 16.2F);
            textBox_pri_nombre.Location = new Point(13, 131);
            textBox_pri_nombre.Name = "textBox_pri_nombre";
            textBox_pri_nombre.Size = new Size(221, 43);
            textBox_pri_nombre.TabIndex = 10;
            textBox_pri_nombre.Click += textBox_pri_nombre_Click;
            // 
            // label_apellido
            // 
            label_apellido.AutoSize = true;
            label_apellido.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label_apellido.Location = new Point(307, 93);
            label_apellido.Name = "label_apellido";
            label_apellido.Size = new Size(135, 38);
            label_apellido.TabIndex = 9;
            label_apellido.Text = "Apellido:";
            // 
            // label_nombre
            // 
            label_nombre.AutoSize = true;
            label_nombre.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label_nombre.Location = new Point(13, 93);
            label_nombre.Name = "label_nombre";
            label_nombre.Size = new Size(133, 38);
            label_nombre.TabIndex = 8;
            label_nombre.Text = "Nombre:";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Controls.Add(button_agregar_usuario, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 446);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(497, 196);
            tableLayoutPanel2.TabIndex = 82;
            // 
            // button_agregar_usuario
            // 
            button_agregar_usuario.BackColor = Color.FromArgb(52, 152, 219);
            button_agregar_usuario.Cursor = Cursors.Hand;
            button_agregar_usuario.Dock = DockStyle.Fill;
            button_agregar_usuario.FlatAppearance.BorderSize = 0;
            button_agregar_usuario.FlatStyle = FlatStyle.Flat;
            button_agregar_usuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_agregar_usuario.ForeColor = Color.White;
            button_agregar_usuario.Location = new Point(168, 3);
            button_agregar_usuario.Name = "button_agregar_usuario";
            button_agregar_usuario.Size = new Size(159, 170);
            button_agregar_usuario.TabIndex = 27;
            button_agregar_usuario.Text = "Accion";
            button_agregar_usuario.UseVisualStyleBackColor = false;
            button_agregar_usuario.Click += button_agregar_usuario_Click;
            // 
            // CrearUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(503, 714);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(pictureBox_logo_tipo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CrearUsuario";
            Text = "CrearUsuario";
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_tipo).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            panel_titulo.ResumeLayout(false);
            panel_titulo.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox_logo_tipo;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel_titulo;
        private TextBox textBox_cedula;
        private Label label_cedula;
        private TextBox textBox_correo;
        private Label label_gmail;
        private TextBox textBox_direccion;
        private Label label_direccion;
        private TextBox textBox_telefono;
        private Label label_telefono;
        private TextBox textBox_pri_apellido;
        private TextBox textBox_pri_nombre;
        private Label label_apellido;
        private Label label_nombre;
        private TableLayoutPanel tableLayoutPanel2;
        private Button button_agregar_usuario;
    }
}