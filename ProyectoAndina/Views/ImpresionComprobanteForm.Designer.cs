namespace ProyectoAndina.Views
{
    partial class ImpresionComprobanteForm
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
            panel_formulario = new Panel();
            panel1 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            button_imprimir = new Button();
            comboBoxImpresoras = new ComboBox();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_tipo).BeginInit();
            panel_formulario.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
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
            tableLayoutPanel1.Size = new Size(404, 75);
            tableLayoutPanel1.TabIndex = 84;
            // 
            // pictureBox_logo_tipo
            // 
            pictureBox_logo_tipo.BackColor = Color.White;
            pictureBox_logo_tipo.Dock = DockStyle.Fill;
            pictureBox_logo_tipo.Image = Properties.Resources.Logotipo_color;
            pictureBox_logo_tipo.Location = new Point(3, 3);
            pictureBox_logo_tipo.Name = "pictureBox_logo_tipo";
            pictureBox_logo_tipo.Size = new Size(398, 69);
            pictureBox_logo_tipo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_logo_tipo.TabIndex = 66;
            pictureBox_logo_tipo.TabStop = false;
            // 
            // panel_formulario
            // 
            panel_formulario.BackColor = Color.Transparent;
            panel_formulario.Controls.Add(panel1);
            panel_formulario.Dock = DockStyle.Fill;
            panel_formulario.Location = new Point(0, 75);
            panel_formulario.Name = "panel_formulario";
            panel_formulario.Size = new Size(404, 375);
            panel_formulario.TabIndex = 85;
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(404, 375);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(button_imprimir, 0, 1);
            tableLayoutPanel2.Controls.Add(comboBoxImpresoras, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(404, 375);
            tableLayoutPanel2.TabIndex = 33;
            // 
            // button_imprimir
            // 
            button_imprimir.Anchor = AnchorStyles.None;
            button_imprimir.BackColor = Color.RoyalBlue;
            button_imprimir.ForeColor = Color.White;
            button_imprimir.Location = new Point(105, 234);
            button_imprimir.Name = "button_imprimir";
            button_imprimir.Size = new Size(194, 93);
            button_imprimir.TabIndex = 31;
            button_imprimir.Text = "Imprimir";
            button_imprimir.UseVisualStyleBackColor = false;
            button_imprimir.Click += button_imprimir_Click;
            // 
            // comboBoxImpresoras
            // 
            comboBoxImpresoras.Anchor = AnchorStyles.None;
            comboBoxImpresoras.Font = new Font("Segoe UI", 16F);
            comboBoxImpresoras.FormattingEnabled = true;
            comboBoxImpresoras.Location = new Point(84, 71);
            comboBoxImpresoras.Margin = new Padding(3, 2, 3, 2);
            comboBoxImpresoras.Name = "comboBoxImpresoras";
            comboBoxImpresoras.Size = new Size(236, 45);
            comboBoxImpresoras.TabIndex = 35;
            comboBoxImpresoras.SelectedIndexChanged += comboBoxImpresoras_SelectedIndexChanged;
            // 
            // ImpresionComprobanteForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 450);
            Controls.Add(panel_formulario);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ImpresionComprobanteForm";
            Load += ImpresionComprobanteForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_tipo).EndInit();
            panel_formulario.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox_logo_tipo;
        private Panel panel_formulario;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button button_imprimir;
        private ComboBox comboBoxImpresoras;
    }
}