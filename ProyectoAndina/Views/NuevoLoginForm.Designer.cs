namespace ProyectoAndina.Views
{
    partial class NuevoLoginForm
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
            panelFormulario = new Panel();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel6 = new TableLayoutPanel();
            txtPassword = new TextBox();
            lblPassword = new Label();
            lblMensaje = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            tableLayoutPanel5 = new TableLayoutPanel();
            txtCorreo = new TextBox();
            lblCedula = new Label();
            btnLogin = new Button();
            panelLogo = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            pictureBoxLogo = new PictureBox();
            tableLayoutPanel1.SuspendLayout();
            panelFormulario.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            panelLogo.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panelFormulario, 1, 0);
            tableLayoutPanel1.Controls.Add(panelLogo, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(990, 630);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panelFormulario
            // 
            panelFormulario.BackColor = Color.White;
            panelFormulario.Controls.Add(tableLayoutPanel3);
            panelFormulario.Dock = DockStyle.Fill;
            panelFormulario.Location = new Point(498, 3);
            panelFormulario.Name = "panelFormulario";
            panelFormulario.Size = new Size(489, 624);
            panelFormulario.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.41529F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67.16941F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.4152946F));
            tableLayoutPanel3.Controls.Add(tableLayoutPanel6, 1, 3);
            tableLayoutPanel3.Controls.Add(lblMensaje, 1, 5);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 1, 1);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel5, 1, 2);
            tableLayoutPanel3.Controls.Add(btnLogin, 1, 4);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 7;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 9.740255F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 16.2337666F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 16.2337666F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 16.2337666F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 16.2337666F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 16.2337666F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 9.09091F));
            tableLayoutPanel3.Size = new Size(489, 624);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 1;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Controls.Add(txtPassword, 0, 1);
            tableLayoutPanel6.Controls.Add(lblPassword, 0, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(83, 265);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 2;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Size = new Size(322, 95);
            tableLayoutPanel6.TabIndex = 13;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.None;
            txtPassword.Location = new Point(11, 57);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(300, 27);
            txtPassword.TabIndex = 8;
            txtPassword.Click += txtPassword_Click;
            // 
            // lblPassword
            // 
            lblPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblPassword.Location = new Point(3, 8);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(316, 30);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "Contraseña:";
            lblPassword.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMensaje
            // 
            lblMensaje.Anchor = AnchorStyles.None;
            lblMensaje.Location = new Point(94, 481);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(300, 67);
            lblMensaje.TabIndex = 10;
            lblMensaje.TextAlign = ContentAlignment.MiddleCenter;
            lblMensaje.Visible = false;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(lblSubtitulo, 0, 0);
            tableLayoutPanel4.Controls.Add(lblTitulo, 0, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(83, 63);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(322, 95);
            tableLayoutPanel4.TabIndex = 11;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblSubtitulo.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitulo.Location = new Point(3, 11);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(316, 25);
            lblSubtitulo.TabIndex = 6;
            lblSubtitulo.Text = "Bienvenido, ingresa tus credenciales";
            lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblTitulo.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblTitulo.Location = new Point(3, 51);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(316, 40);
            lblTitulo.TabIndex = 5;
            lblTitulo.Text = "SISTEMA ANDINA";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Controls.Add(txtCorreo, 0, 1);
            tableLayoutPanel5.Controls.Add(lblCedula, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(83, 164);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(322, 95);
            tableLayoutPanel5.TabIndex = 12;
            // 
            // txtCorreo
            // 
            txtCorreo.Anchor = AnchorStyles.None;
            txtCorreo.Location = new Point(11, 57);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(300, 27);
            txtCorreo.TabIndex = 6;
            txtCorreo.Click += txtCorreo_Click;
            // 
            // lblCedula
            // 
            lblCedula.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblCedula.Location = new Point(3, 5);
            lblCedula.Name = "lblCedula";
            lblCedula.Size = new Size(316, 37);
            lblCedula.TabIndex = 5;
            lblCedula.Text = "Correo Electrónico:";
            lblCedula.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.None;
            btnLogin.Location = new Point(94, 384);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(300, 59);
            btnLogin.TabIndex = 9;
            btnLogin.Text = "INICIAR SESIÓN";
            btnLogin.Click += BtnLogin_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(0, 71, 80);
            panelLogo.Controls.Add(tableLayoutPanel2);
            panelLogo.Dock = DockStyle.Fill;
            panelLogo.Location = new Point(3, 3);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(489, 624);
            panelLogo.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(pictureBoxLogo, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Size = new Size(489, 624);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor = Color.Transparent;
            pictureBoxLogo.Dock = DockStyle.Fill;
            pictureBoxLogo.Image = Properties.Resources.Logotipo_un_color;
            pictureBoxLogo.Location = new Point(3, 211);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(483, 202);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 1;
            pictureBoxLogo.TabStop = false;
            // 
            // NuevoLoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 630);
            Controls.Add(tableLayoutPanel1);
            Name = "NuevoLoginForm";
            Text = "NuevoLoginForm";
            WindowState = FormWindowState.Maximized;
            tableLayoutPanel1.ResumeLayout(false);
            panelFormulario.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            panelLogo.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panelFormulario;
        private Panel panelLogo;
        private TableLayoutPanel tableLayoutPanel2;
        private PictureBox pictureBoxLogo;
        private TableLayoutPanel tableLayoutPanel3;
        private Label lblCedula;
        private Label lblPassword;
        private TextBox txtCorreo;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label lblMensaje;
        private TableLayoutPanel tableLayoutPanel4;
        private Label lblSubtitulo;
        private Label lblTitulo;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel6;
    }
}