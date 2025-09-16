namespace ProyectoAndina.Views
{
    partial class PersonaRolCrudForm
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
            textBox_nombre_persona = new TextBox();
            label_personas = new Label();
            comboBox_personas = new ComboBox();
            label_roles = new Label();
            comboBox_roles = new ComboBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            button_accion = new Button();
            textBox_id_persona = new TextBox();
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
            tableLayoutPanel1.Size = new Size(437, 75);
            tableLayoutPanel1.TabIndex = 89;
            // 
            // pictureBox_logo_tipo
            // 
            pictureBox_logo_tipo.BackColor = Color.White;
            pictureBox_logo_tipo.Dock = DockStyle.Fill;
            pictureBox_logo_tipo.Image = Properties.Resources.Logotipo_color;
            pictureBox_logo_tipo.Location = new Point(3, 3);
            pictureBox_logo_tipo.Name = "pictureBox_logo_tipo";
            pictureBox_logo_tipo.Size = new Size(431, 69);
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
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 64.53333F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 35.4666672F));
            tableLayoutPanel2.Size = new Size(437, 375);
            tableLayoutPanel2.TabIndex = 90;
            // 
            // panel_formulario
            // 
            panel_formulario.BackColor = Color.Transparent;
            panel_formulario.Controls.Add(textBox_id_persona);
            panel_formulario.Controls.Add(textBox_nombre_persona);
            panel_formulario.Controls.Add(label_personas);
            panel_formulario.Controls.Add(comboBox_personas);
            panel_formulario.Controls.Add(label_roles);
            panel_formulario.Controls.Add(comboBox_roles);
            panel_formulario.Dock = DockStyle.Fill;
            panel_formulario.Location = new Point(3, 3);
            panel_formulario.Name = "panel_formulario";
            panel_formulario.Size = new Size(431, 236);
            panel_formulario.TabIndex = 92;
            // 
            // textBox_nombre_persona
            // 
            textBox_nombre_persona.Enabled = false;
            textBox_nombre_persona.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_nombre_persona.Location = new Point(177, 34);
            textBox_nombre_persona.Name = "textBox_nombre_persona";
            textBox_nombre_persona.Size = new Size(195, 43);
            textBox_nombre_persona.TabIndex = 77;
            textBox_nombre_persona.Visible = false;
            // 
            // label_personas
            // 
            label_personas.AutoSize = true;
            label_personas.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold);
            label_personas.Location = new Point(27, 32);
            label_personas.Name = "label_personas";
            label_personas.Size = new Size(123, 31);
            label_personas.TabIndex = 75;
            label_personas.Text = "Personas:";
            // 
            // comboBox_personas
            // 
            comboBox_personas.Font = new Font("Segoe UI", 16.2F);
            comboBox_personas.FormattingEnabled = true;
            comboBox_personas.Location = new Point(177, 32);
            comboBox_personas.Name = "comboBox_personas";
            comboBox_personas.Size = new Size(195, 45);
            comboBox_personas.TabIndex = 73;
            // 
            // label_roles
            // 
            label_roles.AutoSize = true;
            label_roles.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold);
            label_roles.Location = new Point(36, 137);
            label_roles.Name = "label_roles";
            label_roles.Size = new Size(83, 31);
            label_roles.TabIndex = 76;
            label_roles.Text = "Roles:";
            // 
            // comboBox_roles
            // 
            comboBox_roles.Font = new Font("Segoe UI", 16.2F);
            comboBox_roles.FormattingEnabled = true;
            comboBox_roles.Location = new Point(177, 137);
            comboBox_roles.Name = "comboBox_roles";
            comboBox_roles.Size = new Size(195, 45);
            comboBox_roles.TabIndex = 74;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.Controls.Add(button_accion, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 245);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 77.95276F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 22.047245F));
            tableLayoutPanel3.Size = new Size(431, 127);
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
            button_accion.Location = new Point(146, 3);
            button_accion.Name = "button_accion";
            button_accion.Size = new Size(137, 93);
            button_accion.TabIndex = 28;
            button_accion.Text = "Accion";
            button_accion.UseVisualStyleBackColor = false;
            button_accion.Click += button_accion_Click;
            // 
            // textBox_id_persona
            // 
            textBox_id_persona.Enabled = false;
            textBox_id_persona.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_id_persona.Location = new Point(177, 83);
            textBox_id_persona.Name = "textBox_id_persona";
            textBox_id_persona.Size = new Size(69, 43);
            textBox_id_persona.TabIndex = 78;
            textBox_id_persona.Visible = false;
            // 
            // PersonaRolCrudForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(437, 450);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PersonaRolCrudForm";
            Text = "PersonasRolForm";
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
        private Label label_personas;
        private ComboBox comboBox_personas;
        private Label label_roles;
        private ComboBox comboBox_roles;
        private TableLayoutPanel tableLayoutPanel3;
        private Button button_accion;
        private TextBox textBox_nombre_persona;
        private TextBox textBox_id_persona;
    }
}