namespace ProyectoAndina.Views
{
    partial class RolCrudForm
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
            panel_formulario = new Panel();
            lbl_nombre = new Label();
            textBox_nombre = new TextBox();
            textBox_descripcion = new TextBox();
            label_descripcion = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            button_accion = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_tipo).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            panel_formulario.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
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
            tableLayoutPanel1.Size = new Size(438, 75);
            tableLayoutPanel1.TabIndex = 83;
            // 
            // pictureBox_logo_tipo
            // 
            pictureBox_logo_tipo.BackColor = Color.White;
            pictureBox_logo_tipo.Dock = DockStyle.Fill;
            pictureBox_logo_tipo.Image = Properties.Resources.Logotipo_color;
            pictureBox_logo_tipo.Location = new Point(3, 3);
            pictureBox_logo_tipo.Name = "pictureBox_logo_tipo";
            pictureBox_logo_tipo.Size = new Size(432, 69);
            pictureBox_logo_tipo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_logo_tipo.TabIndex = 66;
            pictureBox_logo_tipo.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.Transparent;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(panel_formulario, 0, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 75);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 60.6356964F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 39.3643036F));
            tableLayoutPanel2.Size = new Size(438, 409);
            tableLayoutPanel2.TabIndex = 84;
            // 
            // panel_formulario
            // 
            panel_formulario.BackColor = Color.Transparent;
            panel_formulario.Controls.Add(lbl_nombre);
            panel_formulario.Controls.Add(textBox_nombre);
            panel_formulario.Controls.Add(textBox_descripcion);
            panel_formulario.Controls.Add(label_descripcion);
            panel_formulario.Dock = DockStyle.Fill;
            panel_formulario.Location = new Point(3, 3);
            panel_formulario.Name = "panel_formulario";
            panel_formulario.Size = new Size(432, 242);
            panel_formulario.TabIndex = 86;
            // 
            // lbl_nombre
            // 
            lbl_nombre.AutoSize = true;
            lbl_nombre.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lbl_nombre.Location = new Point(9, 7);
            lbl_nombre.Name = "lbl_nombre";
            lbl_nombre.Size = new Size(115, 32);
            lbl_nombre.TabIndex = 29;
            lbl_nombre.Text = "Nombre:";
            // 
            // textBox_nombre
            // 
            textBox_nombre.Font = new Font("Segoe UI", 16F);
            textBox_nombre.Location = new Point(9, 55);
            textBox_nombre.Name = "textBox_nombre";
            textBox_nombre.Size = new Size(300, 43);
            textBox_nombre.TabIndex = 28;
            textBox_nombre.Click += textBox_nombre_Click;
            // 
            // textBox_descripcion
            // 
            textBox_descripcion.Font = new Font("Segoe UI", 16F);
            textBox_descripcion.Location = new Point(9, 162);
            textBox_descripcion.Name = "textBox_descripcion";
            textBox_descripcion.Size = new Size(300, 43);
            textBox_descripcion.TabIndex = 30;
            textBox_descripcion.Click += textBox_descripcion_Click;
            // 
            // label_descripcion
            // 
            label_descripcion.AutoSize = true;
            label_descripcion.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label_descripcion.Location = new Point(9, 114);
            label_descripcion.Name = "label_descripcion";
            label_descripcion.Size = new Size(156, 32);
            label_descripcion.TabIndex = 31;
            label_descripcion.Text = "Descripción:";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.Controls.Add(button_accion, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 251);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tableLayoutPanel3.Size = new Size(432, 155);
            tableLayoutPanel3.TabIndex = 87;
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
            button_accion.Location = new Point(146, 3);
            button_accion.Name = "button_accion";
            button_accion.Size = new Size(137, 113);
            button_accion.TabIndex = 28;
            button_accion.Text = "Accion";
            button_accion.UseVisualStyleBackColor = false;
            button_accion.Click += button_accion_Click;
            // 
            // RolCrudForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(438, 484);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RolCrudForm";
            Text = "RolesCrudForm";
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_tipo).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            panel_formulario.ResumeLayout(false);
            panel_formulario.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox_logo_tipo;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel_formulario;
        private Label lbl_nombre;
        private TextBox textBox_nombre;
        private TextBox textBox_descripcion;
        private Label label_descripcion;
        private TableLayoutPanel tableLayoutPanel3;
        private Button button_accion;
    }
}