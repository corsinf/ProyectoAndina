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
            tableLayoutPanel1 = new TableLayoutPanel();
            panel_titulo = new Panel();
            groupBoxMetodos = new GroupBox();
            radioButton_cedula = new RadioButton();
            radioButton_otro = new RadioButton();
            radioButton_ruc = new RadioButton();
            radioButton_pasaporte = new RadioButton();
            label_tipo_identifacion = new Label();
            textBox_cedula = new TextBox();
            label_cedula = new Label();
            textBox_correo = new TextBox();
            label_gmail = new Label();
            textBox_direccion = new TextBox();
            label_direccion = new Label();
            textBox_telefono = new TextBox();
            label_telefono = new Label();
            textBox_nombre_completo = new TextBox();
            label_nombre = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            button_agregar_usuario = new Button();
            tableLayoutPanel1.SuspendLayout();
            panel_titulo.SuspendLayout();
            groupBoxMetodos.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel_titulo, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 72.8546448F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 27.145359F));
            tableLayoutPanel1.Size = new Size(819, 571);
            tableLayoutPanel1.TabIndex = 83;
            // 
            // panel_titulo
            // 
            panel_titulo.BackColor = Color.Transparent;
            panel_titulo.Controls.Add(groupBoxMetodos);
            panel_titulo.Controls.Add(label_tipo_identifacion);
            panel_titulo.Controls.Add(textBox_cedula);
            panel_titulo.Controls.Add(label_cedula);
            panel_titulo.Controls.Add(textBox_correo);
            panel_titulo.Controls.Add(label_gmail);
            panel_titulo.Controls.Add(textBox_direccion);
            panel_titulo.Controls.Add(label_direccion);
            panel_titulo.Controls.Add(textBox_telefono);
            panel_titulo.Controls.Add(label_telefono);
            panel_titulo.Controls.Add(textBox_nombre_completo);
            panel_titulo.Controls.Add(label_nombre);
            panel_titulo.Dock = DockStyle.Fill;
            panel_titulo.Location = new Point(3, 3);
            panel_titulo.Name = "panel_titulo";
            panel_titulo.Size = new Size(813, 410);
            panel_titulo.TabIndex = 81;
            // 
            // groupBoxMetodos
            // 
            groupBoxMetodos.Controls.Add(radioButton_cedula);
            groupBoxMetodos.Controls.Add(radioButton_otro);
            groupBoxMetodos.Controls.Add(radioButton_ruc);
            groupBoxMetodos.Controls.Add(radioButton_pasaporte);
            groupBoxMetodos.Location = new Point(375, 67);
            groupBoxMetodos.Name = "groupBoxMetodos";
            groupBoxMetodos.Size = new Size(416, 79);
            groupBoxMetodos.TabIndex = 31;
            groupBoxMetodos.TabStop = false;
            groupBoxMetodos.Text = "Seleccione";
            // 
            // radioButton_cedula
            // 
            radioButton_cedula.AutoSize = true;
            radioButton_cedula.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            radioButton_cedula.Location = new Point(97, 26);
            radioButton_cedula.Name = "radioButton_cedula";
            radioButton_cedula.Size = new Size(106, 35);
            radioButton_cedula.TabIndex = 28;
            radioButton_cedula.TabStop = true;
            radioButton_cedula.Text = "Cédula";
            radioButton_cedula.UseVisualStyleBackColor = true;
            // 
            // radioButton_otro
            // 
            radioButton_otro.AutoSize = true;
            radioButton_otro.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            radioButton_otro.Location = new Point(337, 26);
            radioButton_otro.Name = "radioButton_otro";
            radioButton_otro.Size = new Size(81, 35);
            radioButton_otro.TabIndex = 30;
            radioButton_otro.TabStop = true;
            radioButton_otro.Text = "Otro";
            radioButton_otro.UseVisualStyleBackColor = true;
            // 
            // radioButton_ruc
            // 
            radioButton_ruc.AutoSize = true;
            radioButton_ruc.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            radioButton_ruc.Location = new Point(12, 26);
            radioButton_ruc.Name = "radioButton_ruc";
            radioButton_ruc.Size = new Size(79, 35);
            radioButton_ruc.TabIndex = 27;
            radioButton_ruc.TabStop = true;
            radioButton_ruc.Text = "RUC";
            radioButton_ruc.UseVisualStyleBackColor = true;
            // 
            // radioButton_pasaporte
            // 
            radioButton_pasaporte.AutoSize = true;
            radioButton_pasaporte.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            radioButton_pasaporte.Location = new Point(202, 26);
            radioButton_pasaporte.Name = "radioButton_pasaporte";
            radioButton_pasaporte.Size = new Size(136, 35);
            radioButton_pasaporte.TabIndex = 29;
            radioButton_pasaporte.TabStop = true;
            radioButton_pasaporte.Text = "Pasaporte";
            radioButton_pasaporte.UseVisualStyleBackColor = true;
            // 
            // label_tipo_identifacion
            // 
            label_tipo_identifacion.AutoSize = true;
            label_tipo_identifacion.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label_tipo_identifacion.Location = new Point(398, 26);
            label_tipo_identifacion.Name = "label_tipo_identifacion";
            label_tipo_identifacion.Size = new Size(204, 38);
            label_tipo_identifacion.TabIndex = 26;
            label_tipo_identifacion.Text = "Identificación:";
            // 
            // textBox_cedula
            // 
            textBox_cedula.Enabled = false;
            textBox_cedula.Font = new Font("Segoe UI", 16.2F);
            textBox_cedula.Location = new Point(27, 208);
            textBox_cedula.Name = "textBox_cedula";
            textBox_cedula.Size = new Size(304, 43);
            textBox_cedula.TabIndex = 1;
            textBox_cedula.Click += textBox_cedula_Click;
            // 
            // label_cedula
            // 
            label_cedula.AutoSize = true;
            label_cedula.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label_cedula.Location = new Point(26, 149);
            label_cedula.Name = "label_cedula";
            label_cedula.Size = new Size(114, 38);
            label_cedula.TabIndex = 25;
            label_cedula.Text = "Cédula:";
            // 
            // textBox_correo
            // 
            textBox_correo.Font = new Font("Segoe UI", 16.2F);
            textBox_correo.Location = new Point(27, 331);
            textBox_correo.Name = "textBox_correo";
            textBox_correo.Size = new Size(304, 43);
            textBox_correo.TabIndex = 3;
            textBox_correo.Click += textBox_correo_Click;
            // 
            // label_gmail
            // 
            label_gmail.AutoSize = true;
            label_gmail.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label_gmail.Location = new Point(27, 272);
            label_gmail.Name = "label_gmail";
            label_gmail.Size = new Size(113, 38);
            label_gmail.TabIndex = 23;
            label_gmail.Text = "Correo:";
            // 
            // textBox_direccion
            // 
            textBox_direccion.Font = new Font("Segoe UI", 16.2F);
            textBox_direccion.Location = new Point(399, 331);
            textBox_direccion.Name = "textBox_direccion";
            textBox_direccion.Size = new Size(304, 43);
            textBox_direccion.TabIndex = 4;
            textBox_direccion.Click += textBox_direccion_Click;
            // 
            // label_direccion
            // 
            label_direccion.AutoSize = true;
            label_direccion.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label_direccion.Location = new Point(399, 272);
            label_direccion.Name = "label_direccion";
            label_direccion.Size = new Size(148, 38);
            label_direccion.TabIndex = 21;
            label_direccion.Text = "Dirección:";
            // 
            // textBox_telefono
            // 
            textBox_telefono.Font = new Font("Segoe UI", 16.2F);
            textBox_telefono.Location = new Point(399, 208);
            textBox_telefono.Name = "textBox_telefono";
            textBox_telefono.Size = new Size(304, 43);
            textBox_telefono.TabIndex = 2;
            textBox_telefono.Click += textBox_telefono_Click;
            // 
            // label_telefono
            // 
            label_telefono.AutoSize = true;
            label_telefono.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label_telefono.Location = new Point(399, 149);
            label_telefono.Name = "label_telefono";
            label_telefono.Size = new Size(138, 38);
            label_telefono.TabIndex = 19;
            label_telefono.Text = "Telefono:";
            // 
            // textBox_nombre_completo
            // 
            textBox_nombre_completo.Font = new Font("Segoe UI", 16.2F);
            textBox_nombre_completo.Location = new Point(27, 83);
            textBox_nombre_completo.Name = "textBox_nombre_completo";
            textBox_nombre_completo.Size = new Size(304, 43);
            textBox_nombre_completo.TabIndex = 0;
            textBox_nombre_completo.Click += textBox_pri_nombre_Click;
            // 
            // label_nombre
            // 
            label_nombre.AutoSize = true;
            label_nombre.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label_nombre.Location = new Point(26, 26);
            label_nombre.Name = "label_nombre";
            label_nombre.Size = new Size(269, 38);
            label_nombre.TabIndex = 8;
            label_nombre.Text = "Nombre Completo:";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Controls.Add(button_agregar_usuario, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 419);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tableLayoutPanel2.Size = new Size(813, 149);
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
            button_agregar_usuario.Location = new Point(273, 3);
            button_agregar_usuario.Name = "button_agregar_usuario";
            button_agregar_usuario.Size = new Size(264, 121);
            button_agregar_usuario.TabIndex = 5;
            button_agregar_usuario.Text = "Crear";
            button_agregar_usuario.UseVisualStyleBackColor = false;
            button_agregar_usuario.Click += button_agregar_usuario_Click;
            // 
            // CrearUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(819, 571);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CrearUsuario";
            tableLayoutPanel1.ResumeLayout(false);
            panel_titulo.ResumeLayout(false);
            panel_titulo.PerformLayout();
            groupBoxMetodos.ResumeLayout(false);
            groupBoxMetodos.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
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
        private TextBox textBox_nombre_completo;
        private Label label_apellido;
        private Label label_nombre;
        private TableLayoutPanel tableLayoutPanel2;
        private Button button_agregar_usuario;
        private RadioButton radioButton_otro;
        private RadioButton radioButton_pasaporte;
        private RadioButton radioButton_cedula;
        private RadioButton radioButton_ruc;
        private Label label_tipo_identifacion;
        private GroupBox groupBoxMetodos;
    }
}