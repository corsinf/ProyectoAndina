namespace ProyectoAndina.Views
{
    partial class PersonaRolForm
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
            label_titulo_persona_rol = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label_titulo_acciones = new Label();
            button_agregar_rol_persona = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            btnUltima = new Button();
            btnSiguiente = new Button();
            btnAnterior = new Button();
            btnPrimera = new Button();
            dgvDatos = new DataGridView();
            tableLayoutPanel4 = new TableLayoutPanel();
            txtBuscar = new TextBox();
            cmbRegistrosPorPagina = new ComboBox();
            label_info = new Label();
            tableLayoutPanel_logueado.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            tableLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel_logueado
            // 
            tableLayoutPanel_logueado.BackColor = Color.Transparent;
            tableLayoutPanel_logueado.ColumnCount = 3;
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel_logueado.Controls.Add(label_titulo_persona_rol, 1, 0);
            tableLayoutPanel_logueado.Dock = DockStyle.Top;
            tableLayoutPanel_logueado.Location = new Point(0, 0);
            tableLayoutPanel_logueado.Name = "tableLayoutPanel_logueado";
            tableLayoutPanel_logueado.RowCount = 1;
            tableLayoutPanel_logueado.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_logueado.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_logueado.Size = new Size(1067, 77);
            tableLayoutPanel_logueado.TabIndex = 110;
            // 
            // label_titulo_persona_rol
            // 
            label_titulo_persona_rol.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_persona_rol.AutoSize = true;
            label_titulo_persona_rol.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_titulo_persona_rol.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_persona_rol.Location = new Point(269, 7);
            label_titulo_persona_rol.Name = "label_titulo_persona_rol";
            label_titulo_persona_rol.Size = new Size(527, 62);
            label_titulo_persona_rol.TabIndex = 79;
            label_titulo_persona_rol.Text = "Asignación de rol";
            label_titulo_persona_rol.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.405406F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.8445644F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 68.28392F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.405405F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 2, 2);
            tableLayoutPanel1.Controls.Add(dgvDatos, 2, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 77);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.4490242F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 67.4620361F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 19.0889378F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1067, 449);
            tableLayoutPanel1.TabIndex = 113;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(label_titulo_acciones, 0, 1);
            tableLayoutPanel2.Controls.Add(button_agregar_rol_persona, 0, 2);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(60, 60);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 227F));
            tableLayoutPanel2.Size = new Size(216, 283);
            tableLayoutPanel2.TabIndex = 9;
            // 
            // label_titulo_acciones
            // 
            label_titulo_acciones.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_acciones.AutoSize = true;
            label_titulo_acciones.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_acciones.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_acciones.Location = new Point(3, 28);
            label_titulo_acciones.Name = "label_titulo_acciones";
            label_titulo_acciones.Size = new Size(210, 28);
            label_titulo_acciones.TabIndex = 28;
            label_titulo_acciones.Text = "Acciones";
            // 
            // button_agregar_rol_persona
            // 
            button_agregar_rol_persona.BackColor = Color.FromArgb(52, 152, 219);
            button_agregar_rol_persona.Cursor = Cursors.Hand;
            button_agregar_rol_persona.Dock = DockStyle.Fill;
            button_agregar_rol_persona.FlatAppearance.BorderSize = 0;
            button_agregar_rol_persona.FlatStyle = FlatStyle.Flat;
            button_agregar_rol_persona.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_agregar_rol_persona.ForeColor = Color.White;
            button_agregar_rol_persona.Location = new Point(3, 59);
            button_agregar_rol_persona.Name = "button_agregar_rol_persona";
            button_agregar_rol_persona.Size = new Size(210, 221);
            button_agregar_rol_persona.TabIndex = 29;
            button_agregar_rol_persona.Text = "Agregar";
            button_agregar_rol_persona.UseVisualStyleBackColor = false;
            button_agregar_rol_persona.Click += button_agregar_rol_persona_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 4;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.Controls.Add(btnUltima, 3, 0);
            tableLayoutPanel3.Controls.Add(btnSiguiente, 2, 0);
            tableLayoutPanel3.Controls.Add(btnAnterior, 1, 0);
            tableLayoutPanel3.Controls.Add(btnPrimera, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(282, 349);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 65F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
            tableLayoutPanel3.Size = new Size(723, 75);
            tableLayoutPanel3.TabIndex = 10;
            // 
            // btnUltima
            // 
            btnUltima.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnUltima.Font = new Font("Segoe UI", 10.8F);
            btnUltima.Location = new Point(543, 3);
            btnUltima.Name = "btnUltima";
            btnUltima.Size = new Size(177, 42);
            btnUltima.TabIndex = 3;
            btnUltima.Text = "Ultima";
            btnUltima.UseVisualStyleBackColor = true;
            btnUltima.UseWaitCursor = true;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnSiguiente.Font = new Font("Segoe UI", 10.8F);
            btnSiguiente.Location = new Point(363, 3);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(152, 42);
            btnSiguiente.TabIndex = 2;
            btnSiguiente.Text = "Siguiente";
            btnSiguiente.UseVisualStyleBackColor = true;
            // 
            // btnAnterior
            // 
            btnAnterior.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnAnterior.Font = new Font("Segoe UI", 10.8F);
            btnAnterior.Location = new Point(205, 3);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(152, 42);
            btnAnterior.TabIndex = 1;
            btnAnterior.Text = "Anterior";
            btnAnterior.UseVisualStyleBackColor = true;
            // 
            // btnPrimera
            // 
            btnPrimera.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnPrimera.Font = new Font("Segoe UI", 10.8F);
            btnPrimera.Location = new Point(3, 3);
            btnPrimera.Name = "btnPrimera";
            btnPrimera.Size = new Size(174, 42);
            btnPrimera.TabIndex = 0;
            btnPrimera.Text = "Primera";
            btnPrimera.UseVisualStyleBackColor = true;
            // 
            // dgvDatos
            // 
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(282, 60);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.RowHeadersWidth = 51;
            dgvDatos.Size = new Size(723, 283);
            dgvDatos.TabIndex = 11;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.Controls.Add(txtBuscar, 1, 1);
            tableLayoutPanel4.Controls.Add(cmbRegistrosPorPagina, 2, 1);
            tableLayoutPanel4.Controls.Add(label_info, 0, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(282, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 15.6862745F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 84.31373F));
            tableLayoutPanel4.Size = new Size(723, 51);
            tableLayoutPanel4.TabIndex = 12;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Font = new Font("Segoe UI", 13.8F);
            txtBuscar.Location = new Point(244, 11);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(235, 38);
            txtBuscar.TabIndex = 5;
            txtBuscar.Click += txtBuscar_Click;
            // 
            // cmbRegistrosPorPagina
            // 
            cmbRegistrosPorPagina.Font = new Font("Segoe UI", 13.8F);
            cmbRegistrosPorPagina.FormattingEnabled = true;
            cmbRegistrosPorPagina.Location = new Point(485, 11);
            cmbRegistrosPorPagina.Name = "cmbRegistrosPorPagina";
            cmbRegistrosPorPagina.Size = new Size(151, 39);
            cmbRegistrosPorPagina.TabIndex = 6;
            // 
            // label_info
            // 
            label_info.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label_info.AutoSize = true;
            label_info.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_info.Location = new Point(3, 8);
            label_info.Name = "label_info";
            label_info.Size = new Size(235, 43);
            label_info.TabIndex = 4;
            label_info.Text = "label1";
            // 
            // PersonaRolForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 526);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tableLayoutPanel_logueado);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PersonaRolForm";
            Text = "PersonasRolForm";
            WindowState = FormWindowState.Maximized;
            tableLayoutPanel_logueado.ResumeLayout(false);
            tableLayoutPanel_logueado.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel_logueado;
        private Label label_titulo_persona_rol;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label_titulo_acciones;
        private Button button_agregar_rol_persona;
        private TableLayoutPanel tableLayoutPanel3;
        private Button btnUltima;
        private Button btnSiguiente;
        private Button btnAnterior;
        private Button btnPrimera;
        private DataGridView dgvDatos;
        private TableLayoutPanel tableLayoutPanel4;
        private TextBox txtBuscar;
        private ComboBox cmbRegistrosPorPagina;
        private Label label_info;
    }
}