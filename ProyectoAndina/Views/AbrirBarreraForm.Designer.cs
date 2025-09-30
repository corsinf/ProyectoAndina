namespace ProyectoAndina.Views
{
    partial class AbrirBarreraForm
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
            label_placa = new Label();
            progressBar_cargar = new ProgressBar();
            label_progreso = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_tipo).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.White;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(pictureBox_logo_tipo, 0, 1);
            tableLayoutPanel1.Controls.Add(label_placa, 0, 0);
            tableLayoutPanel1.Controls.Add(progressBar_cargar, 0, 2);
            tableLayoutPanel1.Controls.Add(label_progreso, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 27.9310341F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 72.06896F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 49F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tableLayoutPanel1.Size = new Size(417, 466);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox_logo_tipo
            // 
            pictureBox_logo_tipo.Dock = DockStyle.Fill;
            pictureBox_logo_tipo.Image = Properties.Resources.barrier;
            pictureBox_logo_tipo.Location = new Point(3, 90);
            pictureBox_logo_tipo.Name = "pictureBox_logo_tipo";
            pictureBox_logo_tipo.Size = new Size(411, 218);
            pictureBox_logo_tipo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_logo_tipo.TabIndex = 82;
            pictureBox_logo_tipo.TabStop = false;
            // 
            // label_placa
            // 
            label_placa.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_placa.AutoSize = true;
            label_placa.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label_placa.Location = new Point(3, 15);
            label_placa.Name = "label_placa";
            label_placa.Size = new Size(411, 57);
            label_placa.TabIndex = 71;
            label_placa.Text = "Abriendo ";
            label_placa.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // progressBar_cargar
            // 
            progressBar_cargar.Anchor = AnchorStyles.None;
            progressBar_cargar.Location = new Point(97, 321);
            progressBar_cargar.Name = "progressBar_cargar";
            progressBar_cargar.Size = new Size(222, 29);
            progressBar_cargar.TabIndex = 83;
            // 
            // label_progreso
            // 
            label_progreso.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_progreso.AutoSize = true;
            label_progreso.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_progreso.Location = new Point(3, 366);
            label_progreso.Name = "label_progreso";
            label_progreso.Size = new Size(411, 31);
            label_progreso.TabIndex = 84;
            label_progreso.Text = "0 %";
            label_progreso.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AbrirBarreraForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(417, 466);
            Controls.Add(tableLayoutPanel1);
            Name = "AbrirBarreraForm";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_tipo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label_placa;
        private PictureBox pictureBox_logo_tipo;
        private ProgressBar progressBar_cargar;
        private Label label_progreso;
    }
}