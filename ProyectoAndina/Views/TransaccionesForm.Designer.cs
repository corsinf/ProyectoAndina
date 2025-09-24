namespace ProyectoAndina.Views
{
    partial class TransaccionesForm
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
            label_titulo_arqueos_cajas = new Label();
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
            tableLayoutPanel_logueado.Controls.Add(label_titulo_arqueos_cajas, 1, 0);
            tableLayoutPanel_logueado.Dock = DockStyle.Top;
            tableLayoutPanel_logueado.Location = new Point(0, 0);
            tableLayoutPanel_logueado.Name = "tableLayoutPanel_logueado";
            tableLayoutPanel_logueado.RowCount = 1;
            tableLayoutPanel_logueado.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_logueado.Size = new Size(1030, 77);
            tableLayoutPanel_logueado.TabIndex = 111;
            // 
            // label_titulo_arqueos_cajas
            // 
            label_titulo_arqueos_cajas.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_arqueos_cajas.AutoSize = true;
            label_titulo_arqueos_cajas.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_titulo_arqueos_cajas.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_arqueos_cajas.Location = new Point(260, 7);
            label_titulo_arqueos_cajas.Name = "label_titulo_arqueos_cajas";
            label_titulo_arqueos_cajas.Size = new Size(509, 62);
            label_titulo_arqueos_cajas.TabIndex = 79;
            label_titulo_arqueos_cajas.Text = "Transacciones";
            label_titulo_arqueos_cajas.TextAlign = ContentAlignment.MiddleCenter;
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
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5.785124F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.5289249F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 77.38419F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 69F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tableLayoutPanel1.Size = new Size(1030, 448);
            tableLayoutPanel1.TabIndex = 112;
            // 
            // dgvDatos
            // 
            dgvDatos.BackgroundColor = SystemColors.ActiveCaption;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(106, 84);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.RowHeadersWidth = 51;
            dgvDatos.Size = new Size(818, 276);
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
            tableLayoutPanel2.Location = new Point(106, 366);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(818, 63);
            tableLayoutPanel2.TabIndex = 13;
            // 
            // btnUltima
            // 
            btnUltima.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnUltima.Location = new Point(615, 3);
            btnUltima.Name = "btnUltima";
            btnUltima.Size = new Size(200, 57);
            btnUltima.TabIndex = 4;
            btnUltima.Text = "btnUltima";
            btnUltima.UseVisualStyleBackColor = true;
            btnUltima.UseWaitCursor = true;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnSiguiente.Location = new Point(411, 3);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(152, 57);
            btnSiguiente.TabIndex = 3;
            btnSiguiente.Text = "btnSiguiente";
            btnSiguiente.UseVisualStyleBackColor = true;
            // 
            // btnAnterior
            // 
            btnAnterior.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnAnterior.Location = new Point(253, 3);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(152, 57);
            btnAnterior.TabIndex = 2;
            btnAnterior.Text = "btnAnterior";
            btnAnterior.UseVisualStyleBackColor = true;
            // 
            // btnPrimera
            // 
            btnPrimera.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnPrimera.Location = new Point(3, 3);
            btnPrimera.Name = "btnPrimera";
            btnPrimera.Size = new Size(198, 57);
            btnPrimera.TabIndex = 1;
            btnPrimera.Text = "btnPrimera";
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
            tableLayoutPanel3.Location = new Point(106, 24);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(818, 54);
            tableLayoutPanel3.TabIndex = 14;
            // 
            // cmbRegistrosPorPagina
            // 
            cmbRegistrosPorPagina.Font = new Font("Segoe UI", 13.8F);
            cmbRegistrosPorPagina.FormattingEnabled = true;
            cmbRegistrosPorPagina.Location = new Point(547, 3);
            cmbRegistrosPorPagina.Name = "cmbRegistrosPorPagina";
            cmbRegistrosPorPagina.Size = new Size(151, 39);
            cmbRegistrosPorPagina.TabIndex = 7;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Font = new Font("Segoe UI", 13.8F);
            txtBuscar.Location = new Point(275, 3);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(266, 38);
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
            label_info.Size = new Size(266, 54);
            label_info.TabIndex = 5;
            label_info.Text = "label1";
            // 
            // TransaccionesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1030, 525);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tableLayoutPanel_logueado);
            FormBorderStyle = FormBorderStyle.None;
            MinimizeBox = false;
            Name = "TransaccionesForm";
            Text = "TransaccionForm";
            WindowState = FormWindowState.Maximized;
            tableLayoutPanel_logueado.ResumeLayout(false);
            tableLayoutPanel_logueado.PerformLayout();
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
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dgvDatos;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnUltima;
        private Button btnSiguiente;
        private Button btnAnterior;
        private Button btnPrimera;
        private TableLayoutPanel tableLayoutPanel3;
        private ComboBox cmbRegistrosPorPagina;
        private TextBox txtBuscar;
        private Label label_info;
    }
}