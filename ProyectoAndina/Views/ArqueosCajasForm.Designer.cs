namespace ProyectoAndina.Views
{
    partial class ArqueosCajasForm
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
            pictureBox1 = new PictureBox();
            label_titulo_arqueos_cajas = new Label();
            button_regresar = new FontAwesome.Sharp.IconButton();
            tableLayoutPanel1 = new TableLayoutPanel();
            dgvDatos = new DataGridView();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnUltima = new Button();
            btnSiguiente = new Button();
            btnAnterior = new Button();
            btnPrimera = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            cmbRegistrosPorPagina = new ComboBox();
            txtBuscar = new TextBox();
            label_info = new Label();
            tableLayoutPanel_logueado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel_logueado
            // 
            tableLayoutPanel_logueado.BackColor = Color.Transparent;
            tableLayoutPanel_logueado.ColumnCount = 3;
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel_logueado.Controls.Add(pictureBox1, 2, 0);
            tableLayoutPanel_logueado.Controls.Add(label_titulo_arqueos_cajas, 1, 0);
            tableLayoutPanel_logueado.Controls.Add(button_regresar, 0, 0);
            tableLayoutPanel_logueado.Dock = DockStyle.Top;
            tableLayoutPanel_logueado.Location = new Point(0, 0);
            tableLayoutPanel_logueado.Name = "tableLayoutPanel_logueado";
            tableLayoutPanel_logueado.RowCount = 1;
            tableLayoutPanel_logueado.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_logueado.Size = new Size(1059, 77);
            tableLayoutPanel_logueado.TabIndex = 110;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.Logotipo_color;
            pictureBox1.Location = new Point(796, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(260, 71);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 80;
            pictureBox1.TabStop = false;
            // 
            // label_titulo_arqueos_cajas
            // 
            label_titulo_arqueos_cajas.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_arqueos_cajas.AutoSize = true;
            label_titulo_arqueos_cajas.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_arqueos_cajas.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_arqueos_cajas.Location = new Point(267, 20);
            label_titulo_arqueos_cajas.Name = "label_titulo_arqueos_cajas";
            label_titulo_arqueos_cajas.Size = new Size(523, 37);
            label_titulo_arqueos_cajas.TabIndex = 79;
            label_titulo_arqueos_cajas.Text = "Listado de Arqueos Cajas";
            label_titulo_arqueos_cajas.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button_regresar
            // 
            button_regresar.Anchor = AnchorStyles.None;
            button_regresar.BackColor = Color.FromArgb(255, 128, 128);
            button_regresar.Cursor = Cursors.Hand;
            button_regresar.FlatAppearance.BorderSize = 0;
            button_regresar.FlatStyle = FlatStyle.Flat;
            button_regresar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_regresar.ForeColor = Color.White;
            button_regresar.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            button_regresar.IconColor = Color.White;
            button_regresar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            button_regresar.IconSize = 24;
            button_regresar.Location = new Point(16, 7);
            button_regresar.Name = "button_regresar";
            button_regresar.Size = new Size(232, 63);
            button_regresar.TabIndex = 29;
            button_regresar.Text = "  Regresar";
            button_regresar.TextAlign = ContentAlignment.MiddleRight;
            button_regresar.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_regresar.UseVisualStyleBackColor = false;
            button_regresar.Click += button_regresar_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Controls.Add(dgvDatos, 1, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 3);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 77);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.629428F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.9863758F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 77.38419F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1059, 452);
            tableLayoutPanel1.TabIndex = 111;
            // 
            // dgvDatos
            // 
            dgvDatos.BackgroundColor = SystemColors.ActiveCaption;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(108, 86);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.RowHeadersWidth = 51;
            dgvDatos.Size = new Size(841, 278);
            dgvDatos.TabIndex = 12;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Controls.Add(btnUltima, 3, 0);
            tableLayoutPanel2.Controls.Add(btnSiguiente, 2, 0);
            tableLayoutPanel2.Controls.Add(btnAnterior, 1, 0);
            tableLayoutPanel2.Controls.Add(btnPrimera, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(108, 370);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(841, 58);
            tableLayoutPanel2.TabIndex = 13;
            // 
            // btnUltima
            // 
            btnUltima.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnUltima.Font = new Font("Segoe UI", 10.8F);
            btnUltima.Location = new Point(633, 3);
            btnUltima.Name = "btnUltima";
            btnUltima.Size = new Size(205, 52);
            btnUltima.TabIndex = 4;
            btnUltima.Text = "Ultima";
            btnUltima.UseVisualStyleBackColor = true;
            btnUltima.UseWaitCursor = true;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnSiguiente.Font = new Font("Segoe UI", 10.8F);
            btnSiguiente.Location = new Point(423, 3);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(152, 52);
            btnSiguiente.TabIndex = 3;
            btnSiguiente.Text = "Siguiente";
            btnSiguiente.UseVisualStyleBackColor = true;
            // 
            // btnAnterior
            // 
            btnAnterior.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnAnterior.Font = new Font("Segoe UI", 10.8F);
            btnAnterior.Location = new Point(265, 3);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(152, 52);
            btnAnterior.TabIndex = 2;
            btnAnterior.Text = "Anterior";
            btnAnterior.UseVisualStyleBackColor = true;
            // 
            // btnPrimera
            // 
            btnPrimera.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnPrimera.Font = new Font("Segoe UI", 10.8F);
            btnPrimera.Location = new Point(3, 3);
            btnPrimera.Name = "btnPrimera";
            btnPrimera.Size = new Size(204, 52);
            btnPrimera.TabIndex = 1;
            btnPrimera.Text = "Primera";
            btnPrimera.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.Controls.Add(cmbRegistrosPorPagina, 2, 0);
            tableLayoutPanel3.Controls.Add(txtBuscar, 1, 0);
            tableLayoutPanel3.Controls.Add(label_info, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(108, 31);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(841, 49);
            tableLayoutPanel3.TabIndex = 14;
            // 
            // cmbRegistrosPorPagina
            // 
            cmbRegistrosPorPagina.Font = new Font("Segoe UI", 13.8F);
            cmbRegistrosPorPagina.FormattingEnabled = true;
            cmbRegistrosPorPagina.Location = new Point(563, 3);
            cmbRegistrosPorPagina.Name = "cmbRegistrosPorPagina";
            cmbRegistrosPorPagina.Size = new Size(151, 39);
            cmbRegistrosPorPagina.TabIndex = 7;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Font = new Font("Segoe UI", 13.8F);
            txtBuscar.Location = new Point(283, 3);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(274, 38);
            txtBuscar.TabIndex = 6;
            txtBuscar.Click += txtBuscar_Click;
            // 
            // label_info
            // 
            label_info.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label_info.AutoSize = true;
            label_info.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_info.Location = new Point(3, 0);
            label_info.Name = "label_info";
            label_info.Size = new Size(274, 49);
            label_info.TabIndex = 5;
            label_info.Text = "label1";
            // 
            // ArqueosCajasForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1059, 529);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tableLayoutPanel_logueado);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = false;
            Name = "ArqueosCajasForm";
            Text = "ArqueosCajasFormNuevo";
            WindowState = FormWindowState.Maximized;
            tableLayoutPanel_logueado.ResumeLayout(false);
            tableLayoutPanel_logueado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel_logueado;
        private Label label_titulo_arqueos_cajas;
        private FontAwesome.Sharp.IconButton button_regresar;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox1;
        private DataGridView dgvDatos;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnPrimera;
        private Button btnAnterior;
        private Button btnSiguiente;
        private Button btnUltima;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label_info;
        private TextBox txtBuscar;
        private ComboBox cmbRegistrosPorPagina;
    }
}