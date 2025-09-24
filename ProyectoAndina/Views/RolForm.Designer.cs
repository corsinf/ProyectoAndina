namespace ProyectoAndina.Views
{
    partial class RolForm
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
            label_titulo_roles = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label_titulo_acciones = new Label();
            button_agregar_rol = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            btnUltima = new Button();
            btnSiguiente = new Button();
            btnAnterior = new Button();
            btnPrimera = new Button();
            dgvDatos = new DataGridView();
            tableLayoutPanel4 = new TableLayoutPanel();
            label_info = new Label();
            txtBuscar = new TextBox();
            cmbRegistrosPorPagina = new ComboBox();
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
            tableLayoutPanel_logueado.Controls.Add(label_titulo_roles, 1, 0);
            tableLayoutPanel_logueado.Dock = DockStyle.Top;
            tableLayoutPanel_logueado.Location = new Point(0, 0);
            tableLayoutPanel_logueado.Name = "tableLayoutPanel_logueado";
            tableLayoutPanel_logueado.RowCount = 1;
            tableLayoutPanel_logueado.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_logueado.Size = new Size(1078, 108);
            tableLayoutPanel_logueado.TabIndex = 109;
            // 
            // label_titulo_roles
            // 
            label_titulo_roles.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_roles.AutoSize = true;
            label_titulo_roles.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_titulo_roles.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_roles.Location = new Point(272, 23);
            label_titulo_roles.Name = "label_titulo_roles";
            label_titulo_roles.Size = new Size(533, 62);
            label_titulo_roles.TabIndex = 79;
            label_titulo_roles.Text = "Roles";
            label_titulo_roles.TextAlign = ContentAlignment.MiddleCenter;
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
            tableLayoutPanel1.Location = new Point(0, 108);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.4490242F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 67.4620361F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 19.0889378F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1078, 452);
            tableLayoutPanel1.TabIndex = 112;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(label_titulo_acciones, 0, 1);
            tableLayoutPanel2.Controls.Add(button_agregar_rol, 0, 2);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(61, 61);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 227F));
            tableLayoutPanel2.Size = new Size(218, 285);
            tableLayoutPanel2.TabIndex = 9;
            // 
            // label_titulo_acciones
            // 
            label_titulo_acciones.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_acciones.AutoSize = true;
            label_titulo_acciones.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_acciones.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_acciones.Location = new Point(3, 29);
            label_titulo_acciones.Name = "label_titulo_acciones";
            label_titulo_acciones.Size = new Size(212, 29);
            label_titulo_acciones.TabIndex = 28;
            label_titulo_acciones.Text = "Acciones";
            // 
            // button_agregar_rol
            // 
            button_agregar_rol.BackColor = Color.FromArgb(52, 152, 219);
            button_agregar_rol.Cursor = Cursors.Hand;
            button_agregar_rol.Dock = DockStyle.Fill;
            button_agregar_rol.FlatAppearance.BorderSize = 0;
            button_agregar_rol.FlatStyle = FlatStyle.Flat;
            button_agregar_rol.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_agregar_rol.ForeColor = Color.White;
            button_agregar_rol.Location = new Point(3, 61);
            button_agregar_rol.Name = "button_agregar_rol";
            button_agregar_rol.Size = new Size(212, 221);
            button_agregar_rol.TabIndex = 29;
            button_agregar_rol.Text = "Agregar";
            button_agregar_rol.UseVisualStyleBackColor = false;
            button_agregar_rol.Click += button_agregar_rol_Click;
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
            tableLayoutPanel3.Location = new Point(285, 352);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 65.7894745F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 34.2105255F));
            tableLayoutPanel3.Size = new Size(730, 76);
            tableLayoutPanel3.TabIndex = 10;
            // 
            // btnUltima
            // 
            btnUltima.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnUltima.Font = new Font("Segoe UI", 10.8F);
            btnUltima.Location = new Point(549, 3);
            btnUltima.Name = "btnUltima";
            btnUltima.Size = new Size(178, 44);
            btnUltima.TabIndex = 3;
            btnUltima.Text = "Ultima";
            btnUltima.UseVisualStyleBackColor = true;
            btnUltima.UseWaitCursor = true;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnSiguiente.Font = new Font("Segoe UI", 10.8F);
            btnSiguiente.Location = new Point(367, 3);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(152, 44);
            btnSiguiente.TabIndex = 2;
            btnSiguiente.Text = "Siguiente";
            btnSiguiente.UseVisualStyleBackColor = true;
            // 
            // btnAnterior
            // 
            btnAnterior.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnAnterior.Font = new Font("Segoe UI", 10.8F);
            btnAnterior.Location = new Point(209, 3);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(152, 44);
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
            btnPrimera.Size = new Size(176, 44);
            btnPrimera.TabIndex = 0;
            btnPrimera.Text = "Primera";
            btnPrimera.UseVisualStyleBackColor = true;
            // 
            // dgvDatos
            // 
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(285, 61);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.RowHeadersWidth = 51;
            dgvDatos.Size = new Size(730, 285);
            dgvDatos.TabIndex = 11;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.Controls.Add(label_info, 0, 1);
            tableLayoutPanel4.Controls.Add(txtBuscar, 1, 1);
            tableLayoutPanel4.Controls.Add(cmbRegistrosPorPagina, 2, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(285, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 17.3076916F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 82.69231F));
            tableLayoutPanel4.Size = new Size(730, 52);
            tableLayoutPanel4.TabIndex = 12;
            // 
            // label_info
            // 
            label_info.AutoSize = true;
            label_info.Dock = DockStyle.Fill;
            label_info.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_info.Location = new Point(3, 8);
            label_info.Name = "label_info";
            label_info.Size = new Size(237, 44);
            label_info.TabIndex = 4;
            label_info.Text = "label1";
            // 
            // txtBuscar
            // 
            txtBuscar.Dock = DockStyle.Fill;
            txtBuscar.Font = new Font("Segoe UI", 13.8F);
            txtBuscar.Location = new Point(246, 11);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(237, 38);
            txtBuscar.TabIndex = 5;
            txtBuscar.Click += txtBuscar_Click;
            // 
            // cmbRegistrosPorPagina
            // 
            cmbRegistrosPorPagina.Font = new Font("Segoe UI", 13.8F);
            cmbRegistrosPorPagina.FormattingEnabled = true;
            cmbRegistrosPorPagina.Location = new Point(489, 11);
            cmbRegistrosPorPagina.Name = "cmbRegistrosPorPagina";
            cmbRegistrosPorPagina.Size = new Size(151, 39);
            cmbRegistrosPorPagina.TabIndex = 6;
            // 
            // RolForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1078, 560);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tableLayoutPanel_logueado);
            FormBorderStyle = FormBorderStyle.None;
            MinimizeBox = false;
            Name = "RolForm";
            Text = "RolesForm";
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
        private Label label_titulo_roles;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label_titulo_acciones;
        private Button button_agregar_rol;
        private TableLayoutPanel tableLayoutPanel3;
        private Button btnUltima;
        private Button btnSiguiente;
        private Button btnAnterior;
        private Button btnPrimera;
        private DataGridView dgvDatos;
        private TableLayoutPanel tableLayoutPanel4;
        private Label label_info;
        private TextBox txtBuscar;
        private ComboBox cmbRegistrosPorPagina;
    }
}