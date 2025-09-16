namespace ProyectoAndina.Views
{
    partial class MenuPrincipalForm
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
            pictureBox_logo_tipo = new PictureBox();
            label_titulo_modulos = new Label();
            button_cerrar_session = new FontAwesome.Sharp.IconButton();
            tableLayoutPanelLogin = new TableLayoutPanel();
            panel_rol_persona = new Panel();
            label_rol = new Label();
            iconPictureBox_rol = new FontAwesome.Sharp.IconPictureBox();
            panel_logueado = new Panel();
            label_persona_logueada = new Label();
            iconPictureBox_usuario = new FontAwesome.Sharp.IconPictureBox();
            tableLayoutPanel_contenido = new TableLayoutPanel();
            panel_administración = new Panel();
            panel_admin_container = new Panel();
            tableLayoutPanel_admin = new TableLayoutPanel();
            label_acceso_admin = new Label();
            label_titulo_admin = new Label();
            pictureBox_otra = new PictureBox();
            panel_arqueo = new Panel();
            panel_arqueo_container = new Panel();
            tableLayoutPanel_arqueo = new TableLayoutPanel();
            label_acceso_arqueo = new Label();
            pictureBox_arqueo_caja = new PictureBox();
            label_titulo_recaudacion = new Label();
            panel_transaccion = new Panel();
            panel_transaccion_container = new Panel();
            tableLayoutPanel_transacciones = new TableLayoutPanel();
            pictureBox_transacciones = new PictureBox();
            label_titulo_transacciones = new Label();
            label_acceso_transacciones = new Label();
            tableLayoutPanel_logueado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_tipo).BeginInit();
            tableLayoutPanelLogin.SuspendLayout();
            panel_rol_persona.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox_rol).BeginInit();
            panel_logueado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox_usuario).BeginInit();
            tableLayoutPanel_contenido.SuspendLayout();
            panel_administración.SuspendLayout();
            panel_admin_container.SuspendLayout();
            tableLayoutPanel_admin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_otra).BeginInit();
            panel_arqueo.SuspendLayout();
            panel_arqueo_container.SuspendLayout();
            tableLayoutPanel_arqueo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_arqueo_caja).BeginInit();
            panel_transaccion.SuspendLayout();
            panel_transaccion_container.SuspendLayout();
            tableLayoutPanel_transacciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_transacciones).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel_logueado
            // 
            tableLayoutPanel_logueado.BackColor = Color.Transparent;
            tableLayoutPanel_logueado.ColumnCount = 3;
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel_logueado.Controls.Add(pictureBox_logo_tipo, 0, 0);
            tableLayoutPanel_logueado.Controls.Add(label_titulo_modulos, 1, 0);
            tableLayoutPanel_logueado.Controls.Add(button_cerrar_session, 2, 0);
            tableLayoutPanel_logueado.Dock = DockStyle.Top;
            tableLayoutPanel_logueado.Location = new Point(0, 0);
            tableLayoutPanel_logueado.Name = "tableLayoutPanel_logueado";
            tableLayoutPanel_logueado.RowCount = 2;
            tableLayoutPanel_logueado.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_logueado.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
            tableLayoutPanel_logueado.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_logueado.Size = new Size(1135, 134);
            tableLayoutPanel_logueado.TabIndex = 78;
            // 
            // pictureBox_logo_tipo
            // 
            pictureBox_logo_tipo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox_logo_tipo.Image = Properties.Resources.Logotipo_color;
            pictureBox_logo_tipo.Location = new Point(3, 3);
            pictureBox_logo_tipo.Name = "pictureBox_logo_tipo";
            pictureBox_logo_tipo.Size = new Size(277, 85);
            pictureBox_logo_tipo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_logo_tipo.TabIndex = 80;
            pictureBox_logo_tipo.TabStop = false;
            // 
            // label_titulo_modulos
            // 
            label_titulo_modulos.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_modulos.AutoSize = true;
            label_titulo_modulos.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_modulos.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_modulos.Location = new Point(286, 27);
            label_titulo_modulos.Name = "label_titulo_modulos";
            label_titulo_modulos.Size = new Size(561, 37);
            label_titulo_modulos.TabIndex = 13;
            label_titulo_modulos.Text = "Módulos del sistema";
            label_titulo_modulos.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button_cerrar_session
            // 
            button_cerrar_session.Anchor = AnchorStyles.None;
            button_cerrar_session.BackColor = Color.IndianRed;
            button_cerrar_session.Cursor = Cursors.Hand;
            button_cerrar_session.FlatAppearance.BorderSize = 0;
            button_cerrar_session.FlatStyle = FlatStyle.Flat;
            button_cerrar_session.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_cerrar_session.ForeColor = Color.White;
            button_cerrar_session.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            button_cerrar_session.IconColor = Color.White;
            button_cerrar_session.IconFont = FontAwesome.Sharp.IconFont.Auto;
            button_cerrar_session.IconSize = 24;
            button_cerrar_session.Location = new Point(886, 14);
            button_cerrar_session.Name = "button_cerrar_session";
            button_cerrar_session.Size = new Size(213, 62);
            button_cerrar_session.TabIndex = 79;
            button_cerrar_session.Text = "Cerra Session";
            button_cerrar_session.TextAlign = ContentAlignment.MiddleRight;
            button_cerrar_session.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_cerrar_session.UseVisualStyleBackColor = false;
            button_cerrar_session.Click += button_cerrar_session_Click;
            // 
            // tableLayoutPanelLogin
            // 
            tableLayoutPanelLogin.BackColor = Color.Transparent;
            tableLayoutPanelLogin.ColumnCount = 2;
            tableLayoutPanelLogin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelLogin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelLogin.Controls.Add(panel_rol_persona, 1, 0);
            tableLayoutPanelLogin.Controls.Add(panel_logueado, 0, 0);
            tableLayoutPanelLogin.Dock = DockStyle.Top;
            tableLayoutPanelLogin.Location = new Point(0, 134);
            tableLayoutPanelLogin.Name = "tableLayoutPanelLogin";
            tableLayoutPanelLogin.RowCount = 1;
            tableLayoutPanelLogin.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelLogin.Size = new Size(1135, 76);
            tableLayoutPanelLogin.TabIndex = 79;
            // 
            // panel_rol_persona
            // 
            panel_rol_persona.BackColor = Color.Transparent;
            panel_rol_persona.Controls.Add(label_rol);
            panel_rol_persona.Controls.Add(iconPictureBox_rol);
            panel_rol_persona.Dock = DockStyle.Fill;
            panel_rol_persona.Location = new Point(570, 3);
            panel_rol_persona.Name = "panel_rol_persona";
            panel_rol_persona.Size = new Size(562, 70);
            panel_rol_persona.TabIndex = 77;
            // 
            // label_rol
            // 
            label_rol.Anchor = AnchorStyles.None;
            label_rol.AutoSize = true;
            label_rol.Location = new Point(96, 25);
            label_rol.Name = "label_rol";
            label_rol.Size = new Size(34, 20);
            label_rol.TabIndex = 20;
            label_rol.Text = "Rol:";
            // 
            // iconPictureBox_rol
            // 
            iconPictureBox_rol.Anchor = AnchorStyles.None;
            iconPictureBox_rol.BackColor = Color.Transparent;
            iconPictureBox_rol.Enabled = false;
            iconPictureBox_rol.ForeColor = SystemColors.ControlText;
            iconPictureBox_rol.IconChar = FontAwesome.Sharp.IconChar.UserShield;
            iconPictureBox_rol.IconColor = SystemColors.ControlText;
            iconPictureBox_rol.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox_rol.IconSize = 38;
            iconPictureBox_rol.Location = new Point(40, 16);
            iconPictureBox_rol.Name = "iconPictureBox_rol";
            iconPictureBox_rol.Size = new Size(39, 38);
            iconPictureBox_rol.TabIndex = 74;
            iconPictureBox_rol.TabStop = false;
            // 
            // panel_logueado
            // 
            panel_logueado.BackColor = Color.Transparent;
            panel_logueado.Controls.Add(label_persona_logueada);
            panel_logueado.Controls.Add(iconPictureBox_usuario);
            panel_logueado.Dock = DockStyle.Fill;
            panel_logueado.Location = new Point(3, 3);
            panel_logueado.Name = "panel_logueado";
            panel_logueado.Size = new Size(561, 70);
            panel_logueado.TabIndex = 76;
            // 
            // label_persona_logueada
            // 
            label_persona_logueada.Anchor = AnchorStyles.None;
            label_persona_logueada.AutoSize = true;
            label_persona_logueada.Location = new Point(114, 25);
            label_persona_logueada.Name = "label_persona_logueada";
            label_persona_logueada.Size = new Size(86, 20);
            label_persona_logueada.TabIndex = 16;
            label_persona_logueada.Text = "Bienvenido:";
            // 
            // iconPictureBox_usuario
            // 
            iconPictureBox_usuario.Anchor = AnchorStyles.None;
            iconPictureBox_usuario.BackColor = Color.Transparent;
            iconPictureBox_usuario.Enabled = false;
            iconPictureBox_usuario.ForeColor = SystemColors.ControlText;
            iconPictureBox_usuario.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            iconPictureBox_usuario.IconColor = SystemColors.ControlText;
            iconPictureBox_usuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox_usuario.IconSize = 38;
            iconPictureBox_usuario.Location = new Point(42, 16);
            iconPictureBox_usuario.Name = "iconPictureBox_usuario";
            iconPictureBox_usuario.Size = new Size(39, 38);
            iconPictureBox_usuario.TabIndex = 73;
            iconPictureBox_usuario.TabStop = false;
            // 
            // tableLayoutPanel_contenido
            // 
            tableLayoutPanel_contenido.BackColor = Color.Transparent;
            tableLayoutPanel_contenido.ColumnCount = 5;
            tableLayoutPanel_contenido.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.142857F));
            tableLayoutPanel_contenido.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.5714283F));
            tableLayoutPanel_contenido.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.5714283F));
            tableLayoutPanel_contenido.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.5714283F));
            tableLayoutPanel_contenido.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.142857F));
            tableLayoutPanel_contenido.Controls.Add(panel_administración, 1, 0);
            tableLayoutPanel_contenido.Controls.Add(panel_arqueo, 2, 0);
            tableLayoutPanel_contenido.Controls.Add(panel_transaccion, 3, 0);
            tableLayoutPanel_contenido.Dock = DockStyle.Fill;
            tableLayoutPanel_contenido.Location = new Point(0, 210);
            tableLayoutPanel_contenido.Name = "tableLayoutPanel_contenido";
            tableLayoutPanel_contenido.RowCount = 1;
            tableLayoutPanel_contenido.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_contenido.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_contenido.Size = new Size(1135, 361);
            tableLayoutPanel_contenido.TabIndex = 80;
            // 
            // panel_administración
            // 
            panel_administración.BackColor = Color.Transparent;
            panel_administración.Controls.Add(panel_admin_container);
            panel_administración.Dock = DockStyle.Fill;
            panel_administración.Location = new Point(84, 3);
            panel_administración.Name = "panel_administración";
            panel_administración.Size = new Size(318, 355);
            panel_administración.TabIndex = 67;
            // 
            // panel_admin_container
            // 
            panel_admin_container.Anchor = AnchorStyles.None;
            panel_admin_container.BackColor = Color.Transparent;
            panel_admin_container.Controls.Add(tableLayoutPanel_admin);
            panel_admin_container.Location = new Point(17, 34);
            panel_admin_container.Name = "panel_admin_container";
            panel_admin_container.Size = new Size(265, 308);
            panel_admin_container.TabIndex = 77;
            // 
            // tableLayoutPanel_admin
            // 
            tableLayoutPanel_admin.ColumnCount = 1;
            tableLayoutPanel_admin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_admin.Controls.Add(label_acceso_admin, 0, 2);
            tableLayoutPanel_admin.Controls.Add(label_titulo_admin, 0, 0);
            tableLayoutPanel_admin.Controls.Add(pictureBox_otra, 0, 1);
            tableLayoutPanel_admin.Dock = DockStyle.Fill;
            tableLayoutPanel_admin.Location = new Point(0, 0);
            tableLayoutPanel_admin.Name = "tableLayoutPanel_admin";
            tableLayoutPanel_admin.RowCount = 3;
            tableLayoutPanel_admin.RowStyles.Add(new RowStyle(SizeType.Percent, 18.75F));
            tableLayoutPanel_admin.RowStyles.Add(new RowStyle(SizeType.Percent, 62.5F));
            tableLayoutPanel_admin.RowStyles.Add(new RowStyle(SizeType.Percent, 18.75F));
            tableLayoutPanel_admin.Size = new Size(265, 308);
            tableLayoutPanel_admin.TabIndex = 0;
            tableLayoutPanel_admin.Click += tableLayoutPanel_admin_Click;
            // 
            // label_acceso_admin
            // 
            label_acceso_admin.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_acceso_admin.AutoSize = true;
            label_acceso_admin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_acceso_admin.Location = new Point(3, 267);
            label_acceso_admin.Name = "label_acceso_admin";
            label_acceso_admin.Size = new Size(259, 23);
            label_acceso_admin.TabIndex = 63;
            label_acceso_admin.Text = "Permitido";
            label_acceso_admin.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_titulo_admin
            // 
            label_titulo_admin.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_admin.AutoSize = true;
            label_titulo_admin.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_admin.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_admin.Location = new Point(3, 10);
            label_titulo_admin.Name = "label_titulo_admin";
            label_titulo_admin.Size = new Size(259, 37);
            label_titulo_admin.TabIndex = 18;
            label_titulo_admin.Text = "Administración";
            label_titulo_admin.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox_otra
            // 
            pictureBox_otra.Dock = DockStyle.Fill;
            pictureBox_otra.Image = Properties.Resources.admin;
            pictureBox_otra.Location = new Point(3, 60);
            pictureBox_otra.Name = "pictureBox_otra";
            pictureBox_otra.Size = new Size(259, 186);
            pictureBox_otra.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_otra.TabIndex = 13;
            pictureBox_otra.TabStop = false;
            pictureBox_otra.Click += tableLayoutPanel_admin_Click;
            // 
            // panel_arqueo
            // 
            panel_arqueo.BackColor = Color.Transparent;
            panel_arqueo.Controls.Add(panel_arqueo_container);
            panel_arqueo.Dock = DockStyle.Fill;
            panel_arqueo.Location = new Point(408, 3);
            panel_arqueo.Name = "panel_arqueo";
            panel_arqueo.Size = new Size(318, 355);
            panel_arqueo.TabIndex = 68;
            // 
            // panel_arqueo_container
            // 
            panel_arqueo_container.Anchor = AnchorStyles.None;
            panel_arqueo_container.BackColor = Color.Transparent;
            panel_arqueo_container.Controls.Add(tableLayoutPanel_arqueo);
            panel_arqueo_container.Location = new Point(27, 39);
            panel_arqueo_container.Name = "panel_arqueo_container";
            panel_arqueo_container.Size = new Size(265, 308);
            panel_arqueo_container.TabIndex = 80;
            // 
            // tableLayoutPanel_arqueo
            // 
            tableLayoutPanel_arqueo.ColumnCount = 1;
            tableLayoutPanel_arqueo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_arqueo.Controls.Add(label_acceso_arqueo, 0, 2);
            tableLayoutPanel_arqueo.Controls.Add(pictureBox_arqueo_caja, 0, 1);
            tableLayoutPanel_arqueo.Controls.Add(label_titulo_recaudacion, 0, 0);
            tableLayoutPanel_arqueo.Dock = DockStyle.Fill;
            tableLayoutPanel_arqueo.Location = new Point(0, 0);
            tableLayoutPanel_arqueo.Name = "tableLayoutPanel_arqueo";
            tableLayoutPanel_arqueo.RowCount = 3;
            tableLayoutPanel_arqueo.RowStyles.Add(new RowStyle(SizeType.Percent, 18.75F));
            tableLayoutPanel_arqueo.RowStyles.Add(new RowStyle(SizeType.Percent, 62.5F));
            tableLayoutPanel_arqueo.RowStyles.Add(new RowStyle(SizeType.Percent, 18.75F));
            tableLayoutPanel_arqueo.Size = new Size(265, 308);
            tableLayoutPanel_arqueo.TabIndex = 0;
            tableLayoutPanel_arqueo.Click += tableLayoutPanel_arqueo_Click;
            // 
            // label_acceso_arqueo
            // 
            label_acceso_arqueo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_acceso_arqueo.AutoSize = true;
            label_acceso_arqueo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_acceso_arqueo.Location = new Point(3, 267);
            label_acceso_arqueo.Name = "label_acceso_arqueo";
            label_acceso_arqueo.Size = new Size(259, 23);
            label_acceso_arqueo.TabIndex = 61;
            label_acceso_arqueo.Text = "Permitido";
            label_acceso_arqueo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox_arqueo_caja
            // 
            pictureBox_arqueo_caja.Dock = DockStyle.Fill;
            pictureBox_arqueo_caja.Image = Properties.Resources.registration;
            pictureBox_arqueo_caja.Location = new Point(3, 60);
            pictureBox_arqueo_caja.Name = "pictureBox_arqueo_caja";
            pictureBox_arqueo_caja.Size = new Size(259, 186);
            pictureBox_arqueo_caja.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_arqueo_caja.TabIndex = 17;
            pictureBox_arqueo_caja.TabStop = false;
            pictureBox_arqueo_caja.Click += tableLayoutPanel_arqueo_Click;
            // 
            // label_titulo_recaudacion
            // 
            label_titulo_recaudacion.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_recaudacion.AutoSize = true;
            label_titulo_recaudacion.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_recaudacion.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_recaudacion.Location = new Point(3, 10);
            label_titulo_recaudacion.Name = "label_titulo_recaudacion";
            label_titulo_recaudacion.Size = new Size(259, 37);
            label_titulo_recaudacion.TabIndex = 16;
            label_titulo_recaudacion.Text = "Arqueo Caja";
            label_titulo_recaudacion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_transaccion
            // 
            panel_transaccion.BackColor = Color.Transparent;
            panel_transaccion.Controls.Add(panel_transaccion_container);
            panel_transaccion.Dock = DockStyle.Fill;
            panel_transaccion.Location = new Point(732, 3);
            panel_transaccion.Name = "panel_transaccion";
            panel_transaccion.Size = new Size(318, 355);
            panel_transaccion.TabIndex = 69;
            // 
            // panel_transaccion_container
            // 
            panel_transaccion_container.Anchor = AnchorStyles.None;
            panel_transaccion_container.BackColor = Color.Transparent;
            panel_transaccion_container.Controls.Add(tableLayoutPanel_transacciones);
            panel_transaccion_container.Location = new Point(32, 34);
            panel_transaccion_container.Name = "panel_transaccion_container";
            panel_transaccion_container.Size = new Size(265, 308);
            panel_transaccion_container.TabIndex = 81;
            // 
            // tableLayoutPanel_transacciones
            // 
            tableLayoutPanel_transacciones.ColumnCount = 1;
            tableLayoutPanel_transacciones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_transacciones.Controls.Add(pictureBox_transacciones, 0, 1);
            tableLayoutPanel_transacciones.Controls.Add(label_titulo_transacciones, 0, 0);
            tableLayoutPanel_transacciones.Controls.Add(label_acceso_transacciones, 0, 2);
            tableLayoutPanel_transacciones.Dock = DockStyle.Fill;
            tableLayoutPanel_transacciones.Location = new Point(0, 0);
            tableLayoutPanel_transacciones.Name = "tableLayoutPanel_transacciones";
            tableLayoutPanel_transacciones.RowCount = 3;
            tableLayoutPanel_transacciones.RowStyles.Add(new RowStyle(SizeType.Percent, 18.75F));
            tableLayoutPanel_transacciones.RowStyles.Add(new RowStyle(SizeType.Percent, 62.5F));
            tableLayoutPanel_transacciones.RowStyles.Add(new RowStyle(SizeType.Percent, 18.75F));
            tableLayoutPanel_transacciones.Size = new Size(265, 308);
            tableLayoutPanel_transacciones.TabIndex = 0;
            tableLayoutPanel_transacciones.Click += tableLayoutPanel_transacciones_Click;
            // 
            // pictureBox_transacciones
            // 
            pictureBox_transacciones.Dock = DockStyle.Fill;
            pictureBox_transacciones.Image = Properties.Resources.recaudacion_actual;
            pictureBox_transacciones.Location = new Point(3, 60);
            pictureBox_transacciones.Name = "pictureBox_transacciones";
            pictureBox_transacciones.Size = new Size(259, 186);
            pictureBox_transacciones.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_transacciones.TabIndex = 20;
            pictureBox_transacciones.TabStop = false;
            pictureBox_transacciones.Click += tableLayoutPanel_transacciones_Click;
            // 
            // label_titulo_transacciones
            // 
            label_titulo_transacciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_transacciones.AutoSize = true;
            label_titulo_transacciones.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_transacciones.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_transacciones.Location = new Point(3, 0);
            label_titulo_transacciones.Name = "label_titulo_transacciones";
            label_titulo_transacciones.Size = new Size(259, 57);
            label_titulo_transacciones.TabIndex = 19;
            label_titulo_transacciones.Text = "Transacciones";
            label_titulo_transacciones.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_acceso_transacciones
            // 
            label_acceso_transacciones.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_acceso_transacciones.AutoSize = true;
            label_acceso_transacciones.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_acceso_transacciones.Location = new Point(3, 267);
            label_acceso_transacciones.Name = "label_acceso_transacciones";
            label_acceso_transacciones.Size = new Size(259, 23);
            label_acceso_transacciones.TabIndex = 64;
            label_acceso_transacciones.Text = "Permitido";
            label_acceso_transacciones.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MenuPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1135, 571);
<<<<<<< HEAD
=======
            ControlBox = false;
>>>>>>> 1fbbfaa8fccc06aecd2a96cd1ee224c331cfbff2
            Controls.Add(tableLayoutPanel_contenido);
            Controls.Add(tableLayoutPanelLogin);
            Controls.Add(tableLayoutPanel_logueado);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = false;
            Name = "MenuPrincipalForm";
            Text = "MenuPrincipalNuevo";
            WindowState = FormWindowState.Maximized;
            tableLayoutPanel_logueado.ResumeLayout(false);
            tableLayoutPanel_logueado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_tipo).EndInit();
            tableLayoutPanelLogin.ResumeLayout(false);
            panel_rol_persona.ResumeLayout(false);
            panel_rol_persona.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox_rol).EndInit();
            panel_logueado.ResumeLayout(false);
            panel_logueado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox_usuario).EndInit();
            tableLayoutPanel_contenido.ResumeLayout(false);
            panel_administración.ResumeLayout(false);
            panel_admin_container.ResumeLayout(false);
            tableLayoutPanel_admin.ResumeLayout(false);
            tableLayoutPanel_admin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_otra).EndInit();
            panel_arqueo.ResumeLayout(false);
            panel_arqueo_container.ResumeLayout(false);
            tableLayoutPanel_arqueo.ResumeLayout(false);
            tableLayoutPanel_arqueo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_arqueo_caja).EndInit();
            panel_transaccion.ResumeLayout(false);
            panel_transaccion_container.ResumeLayout(false);
            tableLayoutPanel_transacciones.ResumeLayout(false);
            tableLayoutPanel_transacciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_transacciones).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel_logueado;
        private Label label_titulo_modulos;
        private TableLayoutPanel tableLayoutPanelLogin;
        private Panel panel_rol_persona;
        private Label label_rol;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox_rol;
        private Panel panel_logueado;
        private Label label_persona_logueada;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox_usuario;
        private TableLayoutPanel tableLayoutPanel_contenido;
        private Panel panel_administración;
        private Panel panel_admin_container;
        private Panel panel_arqueo;
        private Panel panel_arqueo_container;
        private Panel panel_transaccion;
        private Panel panel_transaccion_container;
        private FontAwesome.Sharp.IconButton button_cerrar_session;
        private PictureBox pictureBox_logo_tipo;
        private TableLayoutPanel tableLayoutPanel_admin;
        private Label label_acceso_admin;
        private Label label_titulo_admin;
        private PictureBox pictureBox_otra;
        private TableLayoutPanel tableLayoutPanel_arqueo;
        private Label label_acceso_arqueo;
        private PictureBox pictureBox_arqueo_caja;
        private Label label_titulo_recaudacion;
        private TableLayoutPanel tableLayoutPanel_transacciones;
        private PictureBox pictureBox_transacciones;
        private Label label_titulo_transacciones;
        private Label label_acceso_transacciones;
    }
}