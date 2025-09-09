using ProyectoAndina.Controllers;
using ProyectoAndina.Utils;
using static ProyectoAndina.Utils.StylesAlertas;

namespace ProyectoAndina.Views
{
    public partial class MenuPrincipalForm : Form
    {
        private readonly ArqueoCajaController _ArqueoCajaController;
        private readonly ArqueoBilletesController _ArqueoBilletesController;
        private readonly RolController _RolController;
        private readonly PersonaRolController _PersonaRolController;
        private Label label_titulo_modulos;
        private FontAwesome.Sharp.IconButton button_cerrar_session;
        private PictureBox pictureBox_logo_tipo;

        public bool estado_admin;
        public bool estado_arqueo;
        private TableLayoutPanel tableLayoutPanel_logueado;
        private Panel panel_logo_empresa;
        private Panel panel_boton_regresar;
        private TableLayoutPanel tableLayoutPanelLogin;
        private TableLayoutPanel tableLayoutPanel_contenido;
        private Panel panel_logueado;
        private Label label_persona_logueada;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox_usuario;
        private Panel panel_rol_persona;
        private Label label_rol;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox_rol;
        private Panel panel_administración;
        private Panel panel_admin_container;
        private Panel panel_admin_descripcion;
        private Label label_acceso_admin;
        private Panel panel_admin_image;
        private PictureBox pictureBox_otra;
        private Panel panel_admin_titulo;
        private Label label_titulo_admin;
        private Panel panel_arqueo;
        private Panel panel_arqueo_container;
        private Panel panel_arqueo_descripcion;
        private Label label_acceso_arqueo;
        private Panel panel_arqueo_image;
        private PictureBox pictureBox_arqueo_caja;
        private Panel panel_arqueo_titulo;
        private Label label_titulo_recaudacion;
        private Panel panel_transaccion;
        private Panel panel_transaccion_container;
        private Panel panel_transacciones_descripcion;
        private Label label_acceso_transacciones;
        private Panel panel_transaccion_image;
        private PictureBox pictureBox_transacciones;
        private Panel panel_transaccion_titulo;
        private Label label_titulo_transacciones;
        public bool estado_transacciones;




        public MenuPrincipalForm()
        {
            _ArqueoCajaController = new ArqueoCajaController();
            _ArqueoBilletesController = new ArqueoBilletesController();
            _RolController = new RolController();
            _PersonaRolController = new PersonaRolController();
            InitializeComponent();
            CargarUsuarioLogueado();
            ConfigurarEstilo();

            this.Paint += LoginForm_Paint;
            this.DoubleBuffered = true;
            // se despliega en toda la pantalla
            this.WindowState = FormWindowState.Maximized;

        }

        private void LoginForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }





        public void CargarUsuarioLogueado()
        {
            label_persona_logueada.Text = "Bienvenido : " + SessionUser.Correo;

            var rolPersonaList = _PersonaRolController.ObtenerPersonaRolId(SessionUser.id_persona_rol);
            if (rolPersonaList != null)
            {
                var rolPersona = rolPersonaList; // Tomamos el primero
                var rol = _RolController.ObtenerRolPorId(rolPersona.RolId);

                if (rol != null)
                {
                    label_rol.Text = "Rol : " + rol.Nombre.ToString();

                    if (rol.Nombre == "admin" || rol.RolId == 1)
                    {
                        estado_admin = true;
                        estado_arqueo = true;
                        estado_transacciones = true;
                    }

                    if (rol.Nombre == "cajero" || rol.RolId == 2)
                    {
                        estado_admin = false;
                        estado_arqueo = true;
                        estado_transacciones = true;
                    }

                }

            }
            else
            {
                label_rol.Text = "Rol : Sin rol";
                estado_admin = false;
                estado_arqueo = false;
                estado_transacciones = false;

            }

        }


        private void InitializeComponent()
        {
            label_titulo_modulos = new Label();
            pictureBox_logo_tipo = new PictureBox();
            button_cerrar_session = new FontAwesome.Sharp.IconButton();
            tableLayoutPanel_logueado = new TableLayoutPanel();
            panel_logo_empresa = new Panel();
            panel_boton_regresar = new Panel();
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
            panel_admin_descripcion = new Panel();
            label_acceso_admin = new Label();
            panel_admin_image = new Panel();
            pictureBox_otra = new PictureBox();
            panel_admin_titulo = new Panel();
            label_titulo_admin = new Label();
            panel_arqueo = new Panel();
            panel_arqueo_container = new Panel();
            panel_arqueo_descripcion = new Panel();
            label_acceso_arqueo = new Label();
            panel_arqueo_image = new Panel();
            pictureBox_arqueo_caja = new PictureBox();
            panel_arqueo_titulo = new Panel();
            label_titulo_recaudacion = new Label();
            panel_transaccion = new Panel();
            panel_transaccion_container = new Panel();
            panel_transacciones_descripcion = new Panel();
            label_acceso_transacciones = new Label();
            panel_transaccion_image = new Panel();
            pictureBox_transacciones = new PictureBox();
            panel_transaccion_titulo = new Panel();
            label_titulo_transacciones = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_tipo).BeginInit();
            tableLayoutPanel_logueado.SuspendLayout();
            panel_logo_empresa.SuspendLayout();
            panel_boton_regresar.SuspendLayout();
            tableLayoutPanelLogin.SuspendLayout();
            panel_rol_persona.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox_rol).BeginInit();
            panel_logueado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox_usuario).BeginInit();
            tableLayoutPanel_contenido.SuspendLayout();
            panel_administración.SuspendLayout();
            panel_admin_container.SuspendLayout();
            panel_admin_descripcion.SuspendLayout();
            panel_admin_image.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_otra).BeginInit();
            panel_admin_titulo.SuspendLayout();
            panel_arqueo.SuspendLayout();
            panel_arqueo_container.SuspendLayout();
            panel_arqueo_descripcion.SuspendLayout();
            panel_arqueo_image.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_arqueo_caja).BeginInit();
            panel_arqueo_titulo.SuspendLayout();
            panel_transaccion.SuspendLayout();
            panel_transaccion_container.SuspendLayout();
            panel_transacciones_descripcion.SuspendLayout();
            panel_transaccion_image.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_transacciones).BeginInit();
            panel_transaccion_titulo.SuspendLayout();
            SuspendLayout();
            // 
            // label_titulo_modulos
            // 
            label_titulo_modulos.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_modulos.AutoSize = true;
            label_titulo_modulos.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_modulos.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_modulos.Location = new Point(262, 20);
            label_titulo_modulos.Name = "label_titulo_modulos";
            label_titulo_modulos.Size = new Size(513, 37);
            label_titulo_modulos.TabIndex = 13;
            label_titulo_modulos.Text = "Módulos del sistema";
            label_titulo_modulos.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox_logo_tipo
            // 
            pictureBox_logo_tipo.Anchor = AnchorStyles.None;
            pictureBox_logo_tipo.Image = Properties.Resources.Logotipo_color;
            pictureBox_logo_tipo.Location = new Point(-10, 5);
            pictureBox_logo_tipo.Name = "pictureBox_logo_tipo";
            pictureBox_logo_tipo.Size = new Size(268, 60);
            pictureBox_logo_tipo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_logo_tipo.TabIndex = 64;
            pictureBox_logo_tipo.TabStop = false;
            // 
            // button_cerrar_session
            // 
            button_cerrar_session.Anchor = AnchorStyles.None;
            button_cerrar_session.BackColor = Color.FromArgb(41, 128, 185);
            button_cerrar_session.Cursor = Cursors.Hand;
            button_cerrar_session.FlatAppearance.BorderSize = 0;
            button_cerrar_session.FlatStyle = FlatStyle.Flat;
            button_cerrar_session.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_cerrar_session.ForeColor = Color.White;
            button_cerrar_session.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            button_cerrar_session.IconColor = Color.White;
            button_cerrar_session.IconFont = FontAwesome.Sharp.IconFont.Auto;
            button_cerrar_session.IconSize = 24;
            button_cerrar_session.Location = new Point(-21, 3);
            button_cerrar_session.Name = "button_cerrar_session";
            button_cerrar_session.Size = new Size(213, 62);
            button_cerrar_session.TabIndex = 30;
            button_cerrar_session.TextAlign = ContentAlignment.MiddleRight;
            button_cerrar_session.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_cerrar_session.UseVisualStyleBackColor = false;
            button_cerrar_session.Click += button_cerrar_session_Click;
            // 
            // tableLayoutPanel_logueado
            // 
            tableLayoutPanel_logueado.BackColor = Color.Transparent;
            tableLayoutPanel_logueado.ColumnCount = 3;
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel_logueado.Controls.Add(label_titulo_modulos, 1, 0);
            tableLayoutPanel_logueado.Controls.Add(panel_logo_empresa, 2, 0);
            tableLayoutPanel_logueado.Controls.Add(panel_boton_regresar, 0, 0);
            tableLayoutPanel_logueado.Dock = DockStyle.Top;
            tableLayoutPanel_logueado.Location = new Point(0, 0);
            tableLayoutPanel_logueado.Name = "tableLayoutPanel_logueado";
            tableLayoutPanel_logueado.RowCount = 1;
            tableLayoutPanel_logueado.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_logueado.Size = new Size(1038, 77);
            tableLayoutPanel_logueado.TabIndex = 77;
            // 
            // panel_logo_empresa
            // 
            panel_logo_empresa.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_logo_empresa.BackColor = Color.Transparent;
            panel_logo_empresa.Controls.Add(pictureBox_logo_tipo);
            panel_logo_empresa.Location = new Point(781, 3);
            panel_logo_empresa.Name = "panel_logo_empresa";
            panel_logo_empresa.Size = new Size(254, 71);
            panel_logo_empresa.TabIndex = 78;
            // 
            // panel_boton_regresar
            // 
            panel_boton_regresar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_boton_regresar.BackColor = Color.Transparent;
            panel_boton_regresar.Controls.Add(button_cerrar_session);
            panel_boton_regresar.Location = new Point(3, 3);
            panel_boton_regresar.Name = "panel_boton_regresar";
            panel_boton_regresar.Size = new Size(253, 71);
            panel_boton_regresar.TabIndex = 77;
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
            tableLayoutPanelLogin.Location = new Point(0, 77);
            tableLayoutPanelLogin.Name = "tableLayoutPanelLogin";
            tableLayoutPanelLogin.RowCount = 1;
            tableLayoutPanelLogin.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelLogin.Size = new Size(1038, 76);
            tableLayoutPanelLogin.TabIndex = 78;
            // 
            // panel_rol_persona
            // 
            panel_rol_persona.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            panel_rol_persona.BackColor = Color.Transparent;
            panel_rol_persona.Controls.Add(label_rol);
            panel_rol_persona.Controls.Add(iconPictureBox_rol);
            panel_rol_persona.Location = new Point(526, 3);
            panel_rol_persona.Name = "panel_rol_persona";
            panel_rol_persona.Size = new Size(505, 70);
            panel_rol_persona.TabIndex = 77;
            // 
            // label_rol
            // 
            label_rol.Anchor = AnchorStyles.None;
            label_rol.AutoSize = true;
            label_rol.Location = new Point(111, 31);
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
            iconPictureBox_rol.Location = new Point(23, 22);
            iconPictureBox_rol.Name = "iconPictureBox_rol";
            iconPictureBox_rol.Size = new Size(39, 38);
            iconPictureBox_rol.TabIndex = 74;
            iconPictureBox_rol.TabStop = false;
            // 
            // panel_logueado
            // 
            panel_logueado.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            panel_logueado.BackColor = Color.Transparent;
            panel_logueado.Controls.Add(label_persona_logueada);
            panel_logueado.Controls.Add(iconPictureBox_usuario);
            panel_logueado.Location = new Point(9, 3);
            panel_logueado.Name = "panel_logueado";
            panel_logueado.Size = new Size(500, 70);
            panel_logueado.TabIndex = 76;
            // 
            // label_persona_logueada
            // 
            label_persona_logueada.Anchor = AnchorStyles.None;
            label_persona_logueada.AutoSize = true;
            label_persona_logueada.Location = new Point(110, 31);
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
            iconPictureBox_usuario.Location = new Point(22, 13);
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
            tableLayoutPanel_contenido.Location = new Point(0, 153);
            tableLayoutPanel_contenido.Name = "tableLayoutPanel_contenido";
            tableLayoutPanel_contenido.RowCount = 1;
            tableLayoutPanel_contenido.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_contenido.Size = new Size(1038, 461);
            tableLayoutPanel_contenido.TabIndex = 79;
            // 
            // panel_administración
            // 
            panel_administración.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            panel_administración.BackColor = Color.Transparent;
            panel_administración.Controls.Add(panel_admin_container);
            panel_administración.Location = new Point(77, 3);
            panel_administración.Name = "panel_administración";
            panel_administración.Size = new Size(290, 455);
            panel_administración.TabIndex = 67;
            // 
            // panel_admin_container
            // 
            panel_admin_container.Anchor = AnchorStyles.None;
            panel_admin_container.BackColor = Color.Transparent;
            panel_admin_container.Controls.Add(panel_admin_descripcion);
            panel_admin_container.Controls.Add(panel_admin_image);
            panel_admin_container.Controls.Add(panel_admin_titulo);
            panel_admin_container.Location = new Point(22, 13);
            panel_admin_container.Name = "panel_admin_container";
            panel_admin_container.Size = new Size(265, 308);
            panel_admin_container.TabIndex = 77;
            // 
            // panel_admin_descripcion
            // 
            panel_admin_descripcion.BackColor = Color.Transparent;
            panel_admin_descripcion.Controls.Add(label_acceso_admin);
            panel_admin_descripcion.Location = new Point(7, 261);
            panel_admin_descripcion.Name = "panel_admin_descripcion";
            panel_admin_descripcion.Size = new Size(244, 43);
            panel_admin_descripcion.TabIndex = 79;
            // 
            // label_acceso_admin
            // 
            label_acceso_admin.AutoSize = true;
            label_acceso_admin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_acceso_admin.Location = new Point(69, 2);
            label_acceso_admin.Name = "label_acceso_admin";
            label_acceso_admin.Size = new Size(89, 23);
            label_acceso_admin.TabIndex = 62;
            label_acceso_admin.Text = "Permitido";
            // 
            // panel_admin_image
            // 
            panel_admin_image.BackColor = Color.Transparent;
            panel_admin_image.Controls.Add(pictureBox_otra);
            panel_admin_image.Location = new Point(7, 73);
            panel_admin_image.Name = "panel_admin_image";
            panel_admin_image.Size = new Size(242, 183);
            panel_admin_image.TabIndex = 79;
            // 
            // pictureBox_otra
            // 
            pictureBox_otra.Image = Properties.Resources.admin;
            pictureBox_otra.Location = new Point(21, 7);
            pictureBox_otra.Name = "pictureBox_otra";
            pictureBox_otra.Size = new Size(191, 168);
            pictureBox_otra.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_otra.TabIndex = 12;
            pictureBox_otra.TabStop = false;
            // 
            // panel_admin_titulo
            // 
            panel_admin_titulo.BackColor = Color.Transparent;
            panel_admin_titulo.Controls.Add(label_titulo_admin);
            panel_admin_titulo.Location = new Point(5, 5);
            panel_admin_titulo.Name = "panel_admin_titulo";
            panel_admin_titulo.Size = new Size(244, 64);
            panel_admin_titulo.TabIndex = 78;
            // 
            // label_titulo_admin
            // 
            label_titulo_admin.AutoSize = true;
            label_titulo_admin.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_admin.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_admin.Location = new Point(11, 15);
            label_titulo_admin.Name = "label_titulo_admin";
            label_titulo_admin.Size = new Size(213, 37);
            label_titulo_admin.TabIndex = 17;
            label_titulo_admin.Text = "Administración";
            // 
            // panel_arqueo
            // 
            panel_arqueo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            panel_arqueo.BackColor = Color.Transparent;
            panel_arqueo.Controls.Add(panel_arqueo_container);
            panel_arqueo.Location = new Point(373, 3);
            panel_arqueo.Name = "panel_arqueo";
            panel_arqueo.Size = new Size(290, 455);
            panel_arqueo.TabIndex = 68;
            // 
            // panel_arqueo_container
            // 
            panel_arqueo_container.Anchor = AnchorStyles.None;
            panel_arqueo_container.BackColor = Color.Transparent;
            panel_arqueo_container.Controls.Add(panel_arqueo_descripcion);
            panel_arqueo_container.Controls.Add(panel_arqueo_image);
            panel_arqueo_container.Controls.Add(panel_arqueo_titulo);
            panel_arqueo_container.Location = new Point(11, 18);
            panel_arqueo_container.Name = "panel_arqueo_container";
            panel_arqueo_container.Size = new Size(265, 308);
            panel_arqueo_container.TabIndex = 80;
            // 
            // panel_arqueo_descripcion
            // 
            panel_arqueo_descripcion.BackColor = Color.Transparent;
            panel_arqueo_descripcion.Controls.Add(label_acceso_arqueo);
            panel_arqueo_descripcion.Location = new Point(9, 260);
            panel_arqueo_descripcion.Name = "panel_arqueo_descripcion";
            panel_arqueo_descripcion.Size = new Size(244, 43);
            panel_arqueo_descripcion.TabIndex = 80;
            // 
            // label_acceso_arqueo
            // 
            label_acceso_arqueo.AutoSize = true;
            label_acceso_arqueo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_acceso_arqueo.Location = new Point(74, 10);
            label_acceso_arqueo.Name = "label_acceso_arqueo";
            label_acceso_arqueo.Size = new Size(89, 23);
            label_acceso_arqueo.TabIndex = 61;
            label_acceso_arqueo.Text = "Permitido";
            // 
            // panel_arqueo_image
            // 
            panel_arqueo_image.BackColor = Color.Transparent;
            panel_arqueo_image.Controls.Add(pictureBox_arqueo_caja);
            panel_arqueo_image.Location = new Point(7, 73);
            panel_arqueo_image.Name = "panel_arqueo_image";
            panel_arqueo_image.Size = new Size(243, 183);
            panel_arqueo_image.TabIndex = 79;
            // 
            // pictureBox_arqueo_caja
            // 
            pictureBox_arqueo_caja.Image = Properties.Resources.caja_registradora;
            pictureBox_arqueo_caja.Location = new Point(16, 6);
            pictureBox_arqueo_caja.Name = "pictureBox_arqueo_caja";
            pictureBox_arqueo_caja.Size = new Size(191, 168);
            pictureBox_arqueo_caja.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_arqueo_caja.TabIndex = 11;
            pictureBox_arqueo_caja.TabStop = false;
            // 
            // panel_arqueo_titulo
            // 
            panel_arqueo_titulo.BackColor = Color.Transparent;
            panel_arqueo_titulo.Controls.Add(label_titulo_recaudacion);
            panel_arqueo_titulo.Location = new Point(5, 5);
            panel_arqueo_titulo.Name = "panel_arqueo_titulo";
            panel_arqueo_titulo.Size = new Size(250, 64);
            panel_arqueo_titulo.TabIndex = 78;
            // 
            // label_titulo_recaudacion
            // 
            label_titulo_recaudacion.AutoSize = true;
            label_titulo_recaudacion.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_recaudacion.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_recaudacion.Location = new Point(27, 15);
            label_titulo_recaudacion.Name = "label_titulo_recaudacion";
            label_titulo_recaudacion.Size = new Size(174, 37);
            label_titulo_recaudacion.TabIndex = 15;
            label_titulo_recaudacion.Text = "Arqueo Caja";
            // 
            // panel_transaccion
            // 
            panel_transaccion.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            panel_transaccion.BackColor = Color.Transparent;
            panel_transaccion.Controls.Add(panel_transaccion_container);
            panel_transaccion.Location = new Point(672, 3);
            panel_transaccion.Name = "panel_transaccion";
            panel_transaccion.Size = new Size(284, 455);
            panel_transaccion.TabIndex = 69;
            // 
            // panel_transaccion_container
            // 
            panel_transaccion_container.Anchor = AnchorStyles.None;
            panel_transaccion_container.BackColor = Color.Transparent;
            panel_transaccion_container.Controls.Add(panel_transacciones_descripcion);
            panel_transaccion_container.Controls.Add(panel_transaccion_image);
            panel_transaccion_container.Controls.Add(panel_transaccion_titulo);
            panel_transaccion_container.Location = new Point(16, 29);
            panel_transaccion_container.Name = "panel_transaccion_container";
            panel_transaccion_container.Size = new Size(265, 308);
            panel_transaccion_container.TabIndex = 81;
            // 
            // panel_transacciones_descripcion
            // 
            panel_transacciones_descripcion.BackColor = Color.Transparent;
            panel_transacciones_descripcion.Controls.Add(label_acceso_transacciones);
            panel_transacciones_descripcion.Location = new Point(7, 260);
            panel_transacciones_descripcion.Name = "panel_transacciones_descripcion";
            panel_transacciones_descripcion.Size = new Size(244, 43);
            panel_transacciones_descripcion.TabIndex = 80;
            // 
            // label_acceso_transacciones
            // 
            label_acceso_transacciones.AutoSize = true;
            label_acceso_transacciones.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_acceso_transacciones.Location = new Point(69, 7);
            label_acceso_transacciones.Name = "label_acceso_transacciones";
            label_acceso_transacciones.Size = new Size(89, 23);
            label_acceso_transacciones.TabIndex = 63;
            label_acceso_transacciones.Text = "Permitido";
            // 
            // panel_transaccion_image
            // 
            panel_transaccion_image.BackColor = Color.Transparent;
            panel_transaccion_image.Controls.Add(pictureBox_transacciones);
            panel_transaccion_image.Location = new Point(7, 73);
            panel_transaccion_image.Name = "panel_transaccion_image";
            panel_transaccion_image.Size = new Size(242, 183);
            panel_transaccion_image.TabIndex = 79;
            // 
            // pictureBox_transacciones
            // 
            pictureBox_transacciones.Image = Properties.Resources.recaudacion_actual;
            pictureBox_transacciones.Location = new Point(15, 6);
            pictureBox_transacciones.Name = "pictureBox_transacciones";
            pictureBox_transacciones.Size = new Size(191, 168);
            pictureBox_transacciones.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_transacciones.TabIndex = 19;
            pictureBox_transacciones.TabStop = false;
            // 
            // panel_transaccion_titulo
            // 
            panel_transaccion_titulo.BackColor = Color.Transparent;
            panel_transaccion_titulo.Controls.Add(label_titulo_transacciones);
            panel_transaccion_titulo.Location = new Point(5, 5);
            panel_transaccion_titulo.Name = "panel_transaccion_titulo";
            panel_transaccion_titulo.Size = new Size(244, 64);
            panel_transaccion_titulo.TabIndex = 78;
            // 
            // label_titulo_transacciones
            // 
            label_titulo_transacciones.AutoSize = true;
            label_titulo_transacciones.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_transacciones.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_transacciones.Location = new Point(17, 15);
            label_titulo_transacciones.Name = "label_titulo_transacciones";
            label_titulo_transacciones.Size = new Size(194, 37);
            label_titulo_transacciones.TabIndex = 18;
            label_titulo_transacciones.Text = "Transacciones";
            // 
            // MenuPrincipalForm
            // 
            ClientSize = new Size(1038, 614);
            Controls.Add(tableLayoutPanel_contenido);
            Controls.Add(tableLayoutPanelLogin);
            Controls.Add(tableLayoutPanel_logueado);
            Name = "MenuPrincipalForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_tipo).EndInit();
            tableLayoutPanel_logueado.ResumeLayout(false);
            tableLayoutPanel_logueado.PerformLayout();
            panel_logo_empresa.ResumeLayout(false);
            panel_boton_regresar.ResumeLayout(false);
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
            panel_admin_descripcion.ResumeLayout(false);
            panel_admin_descripcion.PerformLayout();
            panel_admin_image.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_otra).EndInit();
            panel_admin_titulo.ResumeLayout(false);
            panel_admin_titulo.PerformLayout();
            panel_arqueo.ResumeLayout(false);
            panel_arqueo_container.ResumeLayout(false);
            panel_arqueo_descripcion.ResumeLayout(false);
            panel_arqueo_descripcion.PerformLayout();
            panel_arqueo_image.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_arqueo_caja).EndInit();
            panel_arqueo_titulo.ResumeLayout(false);
            panel_arqueo_titulo.PerformLayout();
            panel_transaccion.ResumeLayout(false);
            panel_transaccion_container.ResumeLayout(false);
            panel_transacciones_descripcion.ResumeLayout(false);
            panel_transacciones_descripcion.PerformLayout();
            panel_transaccion_image.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_transacciones).EndInit();
            panel_transaccion_titulo.ResumeLayout(false);
            panel_transaccion_titulo.PerformLayout();
            ResumeLayout(false);

        }


        private void pictureBox_recaudacion_Click(object sender, EventArgs e)
        {
           




        }

        private void AbrirArqueoCaja()
        {
            var buscarArqueo = _ArqueoCajaController.ObtenerPorArqueoCajaPendiente(SessionUser.id_persona_rol);

            if (buscarArqueo != null)
            {
                SessionArqueoCaja.id_arqueo_caja = buscarArqueo.arqueo_id;
                StylesAlertas.MostrarAlerta(this, "Tiene una arqueo de caja abierto", "Aviso", TipoAlerta.Info);
                var ArqueoCajaForm = new ArqueoCajaForm(buscarArqueo.arqueo_id);
                this.Hide();
                ArqueoCajaForm.ShowDialog();
                this.Close();
            }
            else
            {
                var ArqueoCajaForm = new ArqueoCajaForm(0);
                this.Hide();
                ArqueoCajaForm.ShowDialog();
                this.Close();
            }
        }
        private void AbrirTransacciones()
        {
            var buscarArqueo = _ArqueoCajaController.ObtenerPorArqueoCajaPendiente(SessionUser.id_persona_rol);

            if (buscarArqueo != null)
            {
                var buscarArqueoBilletes = _ArqueoBilletesController.obtener_arqueo_billetes(buscarArqueo.arqueo_id);

                if (buscarArqueoBilletes != null)
                {

                    SessionArqueoCaja.id_arqueo_caja = buscarArqueo.arqueo_id;
                    var TransaccionesCajaForm = new TransaccionesCajaForm();
                    this.Hide();                 // Opcional: ocultas la ventana actual
                    TransaccionesCajaForm.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
                    this.Close();
                }
                else
                {
                    StylesAlertas.MostrarAlerta(this, "Complete el arqueo de caja para continuar", "¡Error!", TipoAlerta.Error);
                }
            }
            else
            {
                StylesAlertas.MostrarAlerta(this, "No existe ningun arqueo de caja pendiente", "¡Error!", TipoAlerta.Error);
            }
        }
        private void AbrirAdministrado()
        {
            var AdministracionFrom = new AdministracionFrom();
            this.Hide();                 // Opcional: ocultas la ventana actual
            AdministracionFrom.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
            this.Close();
        }
        private void ConfigurarEstilo()
        {
            StyleManager.ConfigurarFormPrincipal(this, "Menu Principal");
            this.BackColor = StyleManager.Colors.GrisClaro;

            // Configurar panel principal con sombra

            // Configurar labels con estilos UASB
            StyleManager.ConfigurarLabel(label_titulo_modulos, TipoLabel.TituloGrande);

            StyleManager.ConfigurarLabel(label_titulo_recaudacion, TipoLabel.TituloMedio);
            StyleManager.ConfigurarLabel(label_titulo_admin, TipoLabel.TituloMedio);
            StyleManager.ConfigurarLabel(label_titulo_transacciones, TipoLabel.TituloMedio);
            // COnfigurar labels 
            StyleManager.ConfigurarLabel(label_acceso_admin, TipoLabel.TituloPequeno);
            StyleManager.ConfigurarLabel(label_acceso_arqueo, TipoLabel.TituloPequeno);
            StyleManager.ConfigurarLabel(label_acceso_transacciones, TipoLabel.TituloPequeno);
            StyleManager.ConfigurarLabel(label_persona_logueada, TipoLabel.TituloPequeno);
            StyleManager.ConfigurarLabel(label_rol, TipoLabel.TituloPequeno);

            StyleManager.ConfigurarBotonPrincipalIcono(
            button_cerrar_session,
            FontAwesome.Sharp.IconChar.SignOutAlt,
            "Cerrar Sessión",
            colorFondo: Color.FromArgb(231, 76, 60)
            );

            StyleContenedores.EstilizarCardAcceso(
            panel_admin_container,
            panel_admin_titulo,
            panel_admin_image,
            panel_admin_descripcion,
            "Administrador",
            Properties.Resources.admin,
            estado_admin == false ? "Acceso Denegado" : "Acceso Permitido",
            estado_admin,
            () =>
            {
             AbrirAdministrado();
             },
             this
            );

            StyleContenedores.EstilizarCardAcceso(
                panel_arqueo_container,
                panel_arqueo_titulo,
                panel_arqueo_image,
                panel_arqueo_descripcion,
                "Arqueo de Caja",
                Properties.Resources.caja_registradora,
                estado_arqueo == false ? "Acceso Denegado" :  "Acceso Permitido",
                estado_arqueo,
                () =>
                {
                    AbrirArqueoCaja();
                },
                this
            );

            StyleContenedores.EstilizarCardAcceso(
                panel_transaccion_container,
                panel_transaccion_titulo,
                panel_transaccion_image,
                panel_transacciones_descripcion,
                "Transacciones",
                Properties.Resources.recaudacion_actual,
                 estado_transacciones == false ? "Acceso Denegado" : "Acceso Permitido",
                estado_transacciones,
                () =>
                {
                    AbrirTransacciones();
                }
                ,
                 this
            );




        }




        private void label_titulo_recaudacion_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox_otra_Click(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox_transacciones_Click(object sender, EventArgs e)
        {
            

        }

        private void button_cerrar_session_Click(object sender, EventArgs e)
        {
            var LoginForm = new LoginForm();
            this.Hide();                 // Opcional: ocultas la ventana actual
            LoginForm.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
            this.Close();
        }
    }
}