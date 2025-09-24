namespace ProyectoAndina.Views
{
    partial class CajaCrudForm
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
            pictureBox_logo_tipo = new PictureBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            button_accion = new Button();
            panel1 = new Panel();
            label_codigo = new Label();
            textBox_codigo = new TextBox();
            textBox_nombre = new TextBox();
            label_ubicacion = new Label();
            label_nombre = new Label();
            label_error_nombre = new Label();
            textBox_ubicacion = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_tipo).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panel1.SuspendLayout();
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
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(495, 75);
            tableLayoutPanel1.TabIndex = 87;
            // 
            // pictureBox_logo_tipo
            // 
            pictureBox_logo_tipo.BackColor = Color.Transparent;
            pictureBox_logo_tipo.Dock = DockStyle.Fill;
            pictureBox_logo_tipo.Image = Properties.Resources.Logotipo_color;
            pictureBox_logo_tipo.Location = new Point(3, 3);
            pictureBox_logo_tipo.Name = "pictureBox_logo_tipo";
            pictureBox_logo_tipo.Size = new Size(489, 69);
            pictureBox_logo_tipo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_logo_tipo.TabIndex = 66;
            pictureBox_logo_tipo.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.Transparent;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 1);
            tableLayoutPanel2.Controls.Add(panel1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 75);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 61.31579F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 38.68421F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(495, 401);
            tableLayoutPanel2.TabIndex = 88;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.Controls.Add(button_accion, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 236);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(489, 141);
            tableLayoutPanel3.TabIndex = 93;
            // 
            // button_accion
            // 
            button_accion.BackColor = Color.FromArgb(52, 152, 219);
            button_accion.Cursor = Cursors.Hand;
            button_accion.Dock = DockStyle.Fill;
            button_accion.FlatAppearance.BorderSize = 0;
            button_accion.FlatStyle = FlatStyle.Flat;
            button_accion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_accion.ForeColor = Color.White;
            button_accion.Location = new Point(165, 3);
            button_accion.Name = "button_accion";
            button_accion.Size = new Size(156, 135);
            button_accion.TabIndex = 27;
            button_accion.Text = "Accion";
            button_accion.UseVisualStyleBackColor = false;
            button_accion.Click += button_accion_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(label_codigo);
            panel1.Controls.Add(textBox_codigo);
            panel1.Controls.Add(textBox_nombre);
            panel1.Controls.Add(label_ubicacion);
            panel1.Controls.Add(label_nombre);
            panel1.Controls.Add(label_error_nombre);
            panel1.Controls.Add(textBox_ubicacion);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(489, 227);
            panel1.TabIndex = 91;
            // 
            // label_codigo
            // 
            label_codigo.AutoSize = true;
            label_codigo.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_codigo.Location = new Point(60, 19);
            label_codigo.Name = "label_codigo";
            label_codigo.Size = new Size(97, 31);
            label_codigo.TabIndex = 12;
            label_codigo.Text = "Codigo:";
            // 
            // textBox_codigo
            // 
            textBox_codigo.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_codigo.Location = new Point(60, 60);
            textBox_codigo.Name = "textBox_codigo";
            textBox_codigo.Size = new Size(125, 43);
            textBox_codigo.TabIndex = 13;
            textBox_codigo.Click += textBox_codigo_Click;
            // 
            // textBox_nombre
            // 
            textBox_nombre.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_nombre.Location = new Point(274, 60);
            textBox_nombre.Name = "textBox_nombre";
            textBox_nombre.Size = new Size(125, 43);
            textBox_nombre.TabIndex = 15;
            textBox_nombre.Click += textBox_nombre_Click;
            // 
            // label_ubicacion
            // 
            label_ubicacion.AutoSize = true;
            label_ubicacion.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_ubicacion.Location = new Point(60, 123);
            label_ubicacion.Name = "label_ubicacion";
            label_ubicacion.Size = new Size(127, 31);
            label_ubicacion.TabIndex = 16;
            label_ubicacion.Text = "Ubicación:";
            // 
            // label_nombre
            // 
            label_nombre.AutoSize = true;
            label_nombre.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_nombre.Location = new Point(274, 19);
            label_nombre.Name = "label_nombre";
            label_nombre.Size = new Size(108, 31);
            label_nombre.TabIndex = 14;
            label_nombre.Text = "Nombre:";
            // 
            // label_error_nombre
            // 
            label_error_nombre.AutoSize = true;
            label_error_nombre.Location = new Point(227, 134);
            label_error_nombre.Name = "label_error_nombre";
            label_error_nombre.Size = new Size(0, 20);
            label_error_nombre.TabIndex = 29;
            // 
            // textBox_ubicacion
            // 
            textBox_ubicacion.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_ubicacion.Location = new Point(59, 160);
            textBox_ubicacion.Name = "textBox_ubicacion";
            textBox_ubicacion.Size = new Size(340, 43);
            textBox_ubicacion.TabIndex = 17;
            textBox_ubicacion.Click += textBox_ubicacion_Click;
            // 
            // CajaCrudForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(495, 476);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CajaCrudForm";
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_tipo).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox_logo_tipo;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        private Label label_codigo;
        private TextBox textBox_codigo;
        private TextBox textBox_nombre;
        private Label label_ubicacion;
        private Label label_nombre;
        private Label label_error_nombre;
        private TextBox textBox_ubicacion;
        private TableLayoutPanel tableLayoutPanel3;
        private Button button_accion;
    }
}