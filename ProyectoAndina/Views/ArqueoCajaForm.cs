using ProyectoAndina.Controllers;
using ProyectoAndina.Helper;
using ProyectoAndina.Models;
using ProyectoAndina.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProyectoAndina.Utils.StylesAlertas;

namespace ProyectoAndina.Views
{
    public partial class ArqueoCajaForm : Form
    {
        private readonly ArqueoCajaController _AperturaCajaController;
        private readonly CajaController _CajaController;
        private readonly TransaccionCajaController _TransaccionesCaja;
        private readonly FuncionesGenerales _FuncionesGenerales;
        private PictureBox pictureBox_logo_tipo;
        private Panel panel_form_apertura;
        private Panel panel_button_apertura;
        private TableLayoutPanel tableLayoutPanel_logueado;
        private Panel panel1;
        private Panel panel_crear_arqueo;
        private Button button_apertura_de_caja;
        private Panel panel_cerrar_arqueo;
        private Button button_parar_apertura_caja;
        private TableLayoutPanel tableLayoutPanel_sobrante;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox_sobrante;
        private Label label_sobtrante;
        private TextBox textBox_sobrante;
        private TableLayoutPanel tableLayoutPanel_faltante;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox_faltante;
        private TextBox textBox_faltante;
        private Label label_faltante;
        private TableLayoutPanel tableLayoutPanel_footer;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel_configuracion_complementaria;
        private TableLayoutPanel tableLayoutPanel_configuracion_inicial;
        private TableLayoutPanel tableLayoutPanel13;
        private TextBox textBox_total_transacciones;
        private Label label_total_transacciones;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox_transacciones_realizadas;
        private TableLayoutPanel tableLayoutPanel_campos;
        private Label label_descripcion;
        private Label label_caja;
        private ComboBox comboBox_cajas;
        private TextBox textBox_descripcion;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel_config_turnos;
        private Panel panel_noche;
        private Button button_noche;
        private Panel panel_tarde;
        private Button button_tarde;
        private Panel panel_maniana;
        private Button button_maniana;
        private Label label_turno;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel_;
        private TableLayoutPanel tableLayoutPanel_transacciones;
        private Label label_titulo_transacciones;
        private TableLayoutPanel tableLayoutPanel7;
        private Label label_total_transacciones_valor;
        private TextBox textBox_total_transacciones_valor;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox_valor_transaciones;
        private Label label_titulo_configuracion;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel9;
        private Panel panel_button_cierre;
        private Button button_valor_cierre;
        private Label label_total_en_caja;
        private TextBox textBox_total_en_caja;
        private TableLayoutPanel tableLayoutPanel8;
        private Panel panel_button_abrir;
        private Button button_valor_apertura;
        private TextBox textBox_valor_apertura;
        private Label label_valor_apertura;
        public int arqueo_caja_id;
        public ArqueoCajaForm(int id_arqueo_caja)
        {
            _AperturaCajaController = new ArqueoCajaController();
            _CajaController = new CajaController();
            _TransaccionesCaja = new TransaccionCajaController();
            _FuncionesGenerales = new FuncionesGenerales();

            InitializeComponent();
            CargarListaCajas();

            ConfigurarEstilo();

            this.Paint += ArqueoCajaForm_Paint;
            this.DoubleBuffered = true;

            // se despliega en toda la pantalla
            this.WindowState = FormWindowState.Maximized;

            if (id_arqueo_caja > 0)
            {
                arqueo_caja_id = id_arqueo_caja;
                cargar_datos_caja_abierta(id_arqueo_caja);
                actulizarCamposCierreCaja();
            }
            else
            {
                enabled_apertura_caja();

            }
        }


        public void enabled_apertura_caja()
        {

            textBox_total_en_caja.Enabled = false;
            button_valor_cierre.Enabled = false;

        }

        private void ArqueoCajaForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }

        public void ConfigurarEstilo()
        {
            StyleManager.ConfigurarFormPrincipal(this, "Menu Arqueo Caja");
            this.BackColor = StyleManager.Colors.GrisClaro;

            // Configurar panel principal con sombra

            // Configurar labels con estilos UASB
            StyleManager.ConfigurarLabel(label_titulo_arqueo, TipoLabel.TituloGrande);
            StyleManager.ConfigurarLabel(label_turno, TipoLabel.TituloMedio);
            StyleManager.ConfigurarLabel(label_caja, TipoLabel.TituloMedio);
            StyleManager.ConfigurarLabel(label_descripcion, TipoLabel.TituloMedio);
            StyleManager.ConfigurarLabel(label_total_transacciones_valor, TipoLabel.TituloMedio);
            StyleManager.ConfigurarLabel(label_total_transacciones, TipoLabel.TituloMedio);
            StyleManager.ConfigurarLabel(label_sobtrante, TipoLabel.TituloMedio);
            StyleManager.ConfigurarLabel(label_faltante, TipoLabel.TituloMedio);
            StyleManager.ConfigurarLabel(label_titulo_configuracion, TipoLabel.TituloMedio);
            StyleManager.ConfigurarLabel(label_valor_apertura, TipoLabel.TituloMedio);
            StyleManager.ConfigurarLabel(label_total_en_caja, TipoLabel.TituloMedio);
            StyleManager.ConfigurarLabel(label_titulo_transacciones, TipoLabel.TituloMedio);

            // configurar los textBox

            //botones
            StyleManager.ConfigurarBotonPrincipal(button_apertura_de_caja);
            StyleManager.ConfigurarBotonPrincipal(button_parar_apertura_caja);

            // para centrar el titulo
            StyleManager.ConfigurarBotonPrincipalIcono(
              iconButton_regresar,
              FontAwesome.Sharp.IconChar.ArrowLeft,
              "Regresar",
              colorFondo: Color.FromArgb(231, 76, 60)
              );


            StyleManager.ConfigurarBotonIconoEnPanel(
    panel_cerrar_arqueo,
    button_parar_apertura_caja,
    FontAwesome.Sharp.IconChar.LockOpen,        // 🔓 Candado abierto → cerrar sesión
    Color.FromArgb(231, 76, 60)                 // Rojo elegante (#E74C3C)
);

            // 🟢 CREAR/ABRIR ARQUEO (Acción de inicio/apertura)  
            StyleManager.ConfigurarBotonIconoEnPanel(
                panel_crear_arqueo,
                button_apertura_de_caja,
                FontAwesome.Sharp.IconChar.Lock,            // 🔒 Candado cerrado → abrir sesión
                Color.FromArgb(39, 174, 96)                 // Verde éxito (#27AE60)
            );

            // 💰 VALOR DE APERTURA (Dinero inicial en caja)
            StyleManager.ConfigurarBotonIconoEnPanel(
                panel_button_abrir,
                button_valor_apertura,
                FontAwesome.Sharp.IconChar.Coins,           // 🪙 Monedas → valor inicial
                Color.FromArgb(26, 188, 156)                // Turquesa (#1ABC9C)
            );

            // 📊 VALOR DE CIERRE (Balance final)
            StyleManager.ConfigurarBotonIconoEnPanel(
                panel_button_cierre,
                button_valor_cierre,
                FontAwesome.Sharp.IconChar.Coins,      // 🧮 Calculadora → cálculo final
               Color.FromArgb(26, 188, 156)              // Púrpura profesional (#9B59B6)
            );

            // ☀️ TURNO MAÑANA (6:00 - 14:00)
            StyleManager.ConfigurarBotonIconoEnPanel(
                panel_maniana,
                button_maniana,
                FontAwesome.Sharp.IconChar.Sun,       // ☀️ Sol brillante → mañana
                Color.FromArgb(241, 196, 15)                // Amarillo dorado (#F1C40F)
            );

            // 🌤️ TURNO TARDE (14:00 - 22:00)
            StyleManager.ConfigurarBotonIconoEnPanel(
                panel_tarde,
                button_tarde,
                FontAwesome.Sharp.IconChar.CloudSun,        // 🌤️ Sol con nubes → tarde
                Color.FromArgb(230, 126, 34)                // Naranja atardecer (#E67E22)
            );

            // 🌙 TURNO NOCHE (22:00 - 6:00)
            StyleManager.ConfigurarBotonIconoEnPanel(
                panel_noche,
                button_noche,
                FontAwesome.Sharp.IconChar.Moon,            // 🌙 Luna → noche
                Color.FromArgb(52, 73, 94)                  // Azul nocturno (#34495E)
            );

            //StyleImage.ConfigurarImagenEnPanel(panel_image_apertura, pictureBox_image_apertura, Properties.Resources.dolares_monedas);
            //StyleImage.ConfigurarImagenEnPanel(panel_image_cierre, pictureBox_image_cierre, Properties.Resources.dolares_monedas);

            StyleContenedores.EstilizarTableLayout(tableLayoutPanel_faltante, Color.Red);
            StyleContenedores.EstilizarTableLayout(tableLayoutPanel_sobrante, Color.Orange);
            StyleContenedores.EstilizarTableLayout(tableLayoutPanel_transacciones, Color.FromArgb(0, 110, 99));


        }

        public void cargar_datos_caja_abierta(int id_arqueo_caja)
        {

            var cajaAbierta = _AperturaCajaController.ObtenerPorId(id_arqueo_caja);

            if (cajaAbierta != null)
            {

                textBox_valor_apertura.Enabled = false;
                button_valor_apertura.Enabled = true;
                button_apertura_de_caja.Enabled = false;
                button_parar_apertura_caja.Enabled = true;
                textBox_descripcion.Text = cajaAbierta.observaciones;
                comboBox_cajas.SelectedValue = cajaAbierta.caja_id;
                textBox_valor_apertura.Text = cajaAbierta.valor_apertura.ToString();
                textBox_total_transacciones.Text = cajaAbierta.total_transacciones.ToString();
                textBox_faltante.Text = cajaAbierta.faltante.ToString();
                textBox_sobrante.Text = cajaAbierta.sobrante.ToString();
            }
            else
            {
                _FuncionesGenerales.LimpiarCampos(this);
            }

        }


        private void CargarListaCajas()
        {
            var cajas = _CajaController.obtener_cajas_cerradas();

            // Llenar con DataSource directamente
            comboBox_cajas.DataSource = cajas
                .Select(c => new KeyValuePair<int, string>(c.caja_id, c.nombre))
                .ToList();

            comboBox_cajas.DisplayMember = "Value"; // Lo que ve el usuario
            comboBox_cajas.ValueMember = "Key";     // Lo que se guarda como valor
            comboBox_cajas.SelectedIndex = -1;      // Para que arranque sin seleccionar
        }




        private void ArqueoCajaForm_Load_1(object sender, EventArgs e)
        {
            foreach (var tb in new[] {textBox_total_transacciones, textBox_faltante,
            textBox_sobrante,  textBox_total_en_caja, textBox_valor_apertura})
            {
                tb.KeyPress += _FuncionesGenerales.SoloNumerosDecimal_KeyPress;
            }
        }

        public void InitializeComponent()
        {
            label_titulo_arqueo = new Label();
            iconButton_regresar = new FontAwesome.Sharp.IconButton();
            pictureBox_logo_tipo = new PictureBox();
            tableLayoutPanel_logueado = new TableLayoutPanel();
            panel1 = new Panel();
            panel_crear_arqueo = new Panel();
            button_apertura_de_caja = new Button();
            panel_cerrar_arqueo = new Panel();
            button_parar_apertura_caja = new Button();
            tableLayoutPanel_sobrante = new TableLayoutPanel();
            iconPictureBox_sobrante = new FontAwesome.Sharp.IconPictureBox();
            label_sobtrante = new Label();
            textBox_sobrante = new TextBox();
            tableLayoutPanel_faltante = new TableLayoutPanel();
            iconPictureBox_faltante = new FontAwesome.Sharp.IconPictureBox();
            textBox_faltante = new TextBox();
            label_faltante = new Label();
            tableLayoutPanel_footer = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel_configuracion_inicial = new TableLayoutPanel();
            label_titulo_configuracion = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel9 = new TableLayoutPanel();
            panel_button_cierre = new Panel();
            button_valor_cierre = new Button();
            label_total_en_caja = new Label();
            textBox_total_en_caja = new TextBox();
            tableLayoutPanel8 = new TableLayoutPanel();
            panel_button_abrir = new Panel();
            button_valor_apertura = new Button();
            textBox_valor_apertura = new TextBox();
            label_valor_apertura = new Label();
            tableLayoutPanel_configuracion_complementaria = new TableLayoutPanel();
            tableLayoutPanel_campos = new TableLayoutPanel();
            label_descripcion = new Label();
            label_caja = new Label();
            comboBox_cajas = new ComboBox();
            textBox_descripcion = new TextBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel_config_turnos = new TableLayoutPanel();
            panel_noche = new Panel();
            button_noche = new Button();
            panel_tarde = new Panel();
            button_tarde = new Button();
            panel_maniana = new Panel();
            button_maniana = new Button();
            label_turno = new Label();
            tableLayoutPanel5 = new TableLayoutPanel();
            tableLayoutPanel_ = new TableLayoutPanel();
            tableLayoutPanel_transacciones = new TableLayoutPanel();
            label_titulo_transacciones = new Label();
            tableLayoutPanel13 = new TableLayoutPanel();
            textBox_total_transacciones = new TextBox();
            label_total_transacciones = new Label();
            iconPictureBox_transacciones_realizadas = new FontAwesome.Sharp.IconPictureBox();
            tableLayoutPanel7 = new TableLayoutPanel();
            label_total_transacciones_valor = new Label();
            textBox_total_transacciones_valor = new TextBox();
            iconPictureBox_valor_transaciones = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_tipo).BeginInit();
            tableLayoutPanel_logueado.SuspendLayout();
            panel1.SuspendLayout();
            panel_crear_arqueo.SuspendLayout();
            panel_cerrar_arqueo.SuspendLayout();
            tableLayoutPanel_sobrante.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox_sobrante).BeginInit();
            tableLayoutPanel_faltante.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox_faltante).BeginInit();
            tableLayoutPanel_footer.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel_configuracion_inicial.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel9.SuspendLayout();
            panel_button_cierre.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            panel_button_abrir.SuspendLayout();
            tableLayoutPanel_configuracion_complementaria.SuspendLayout();
            tableLayoutPanel_campos.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel_config_turnos.SuspendLayout();
            panel_noche.SuspendLayout();
            panel_tarde.SuspendLayout();
            panel_maniana.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel_.SuspendLayout();
            tableLayoutPanel_transacciones.SuspendLayout();
            tableLayoutPanel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox_transacciones_realizadas).BeginInit();
            tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox_valor_transaciones).BeginInit();
            SuspendLayout();
            // 
            // label_titulo_arqueo
            // 
            label_titulo_arqueo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_arqueo.AutoSize = true;
            label_titulo_arqueo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_arqueo.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_arqueo.Location = new Point(315, 20);
            label_titulo_arqueo.Name = "label_titulo_arqueo";
            label_titulo_arqueo.Size = new Size(619, 37);
            label_titulo_arqueo.TabIndex = 31;
            label_titulo_arqueo.Text = "Arqueo Caja";
            label_titulo_arqueo.TextAlign = ContentAlignment.MiddleCenter;
            label_titulo_arqueo.Click += label_titulo_usuarios_Click;
            // 
            // iconButton_regresar
            // 
            iconButton_regresar.BackColor = Color.FromArgb(41, 128, 185);
            iconButton_regresar.Cursor = Cursors.Hand;
            iconButton_regresar.FlatAppearance.BorderSize = 0;
            iconButton_regresar.FlatStyle = FlatStyle.Flat;
            iconButton_regresar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            iconButton_regresar.ForeColor = Color.White;
            iconButton_regresar.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            iconButton_regresar.IconColor = Color.White;
            iconButton_regresar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton_regresar.IconSize = 24;
            iconButton_regresar.Location = new Point(3, 3);
            iconButton_regresar.Name = "iconButton_regresar";
            iconButton_regresar.Size = new Size(181, 62);
            iconButton_regresar.TabIndex = 50;
            iconButton_regresar.Text = "  Regresar";
            iconButton_regresar.TextAlign = ContentAlignment.MiddleRight;
            iconButton_regresar.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton_regresar.UseVisualStyleBackColor = false;
            iconButton_regresar.Click += iconButton1_Click;
            // 
            // pictureBox_logo_tipo
            // 
            pictureBox_logo_tipo.Image = Properties.Resources.Logotipo_color;
            pictureBox_logo_tipo.Location = new Point(21, 3);
            pictureBox_logo_tipo.Name = "pictureBox_logo_tipo";
            pictureBox_logo_tipo.Size = new Size(235, 60);
            pictureBox_logo_tipo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_logo_tipo.TabIndex = 64;
            pictureBox_logo_tipo.TabStop = false;
            // 
            // tableLayoutPanel_logueado
            // 
            tableLayoutPanel_logueado.BackColor = Color.Transparent;
            tableLayoutPanel_logueado.ColumnCount = 3;
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel_logueado.Controls.Add(panel1, 2, 0);
            tableLayoutPanel_logueado.Controls.Add(label_titulo_arqueo, 1, 0);
            tableLayoutPanel_logueado.Controls.Add(iconButton_regresar, 0, 0);
            tableLayoutPanel_logueado.Dock = DockStyle.Top;
            tableLayoutPanel_logueado.Location = new Point(0, 0);
            tableLayoutPanel_logueado.Name = "tableLayoutPanel_logueado";
            tableLayoutPanel_logueado.RowCount = 1;
            tableLayoutPanel_logueado.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_logueado.Size = new Size(1250, 77);
            tableLayoutPanel_logueado.TabIndex = 90;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(pictureBox_logo_tipo);
            panel1.Location = new Point(940, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(307, 71);
            panel1.TabIndex = 78;
            // 
            // panel_crear_arqueo
            // 
            panel_crear_arqueo.BackColor = Color.Transparent;
            panel_crear_arqueo.Controls.Add(button_apertura_de_caja);
            panel_crear_arqueo.Dock = DockStyle.Fill;
            panel_crear_arqueo.Location = new Point(753, 3);
            panel_crear_arqueo.Name = "panel_crear_arqueo";
            panel_crear_arqueo.Size = new Size(369, 177);
            panel_crear_arqueo.TabIndex = 84;
            // 
            // button_apertura_de_caja
            // 
            button_apertura_de_caja.BackColor = Color.FromArgb(52, 152, 219);
            button_apertura_de_caja.Cursor = Cursors.Hand;
            button_apertura_de_caja.FlatAppearance.BorderSize = 0;
            button_apertura_de_caja.FlatStyle = FlatStyle.Flat;
            button_apertura_de_caja.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_apertura_de_caja.ForeColor = Color.White;
            button_apertura_de_caja.Location = new Point(82, 65);
            button_apertura_de_caja.Name = "button_apertura_de_caja";
            button_apertura_de_caja.Size = new Size(176, 40);
            button_apertura_de_caja.TabIndex = 28;
            button_apertura_de_caja.Text = "Crear Apertura";
            button_apertura_de_caja.UseVisualStyleBackColor = false;
            button_apertura_de_caja.Click += button_apertura_de_caja_Click;
            // 
            // panel_cerrar_arqueo
            // 
            panel_cerrar_arqueo.BackColor = Color.Transparent;
            panel_cerrar_arqueo.Controls.Add(button_parar_apertura_caja);
            panel_cerrar_arqueo.Dock = DockStyle.Fill;
            panel_cerrar_arqueo.Location = new Point(128, 3);
            panel_cerrar_arqueo.Name = "panel_cerrar_arqueo";
            panel_cerrar_arqueo.Size = new Size(369, 177);
            panel_cerrar_arqueo.TabIndex = 83;
            // 
            // button_parar_apertura_caja
            // 
            button_parar_apertura_caja.BackColor = Color.FromArgb(219, 52, 52);
            button_parar_apertura_caja.Cursor = Cursors.Hand;
            button_parar_apertura_caja.Enabled = false;
            button_parar_apertura_caja.FlatAppearance.BorderSize = 0;
            button_parar_apertura_caja.FlatStyle = FlatStyle.Flat;
            button_parar_apertura_caja.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_parar_apertura_caja.ForeColor = Color.White;
            button_parar_apertura_caja.Location = new Point(62, 65);
            button_parar_apertura_caja.Name = "button_parar_apertura_caja";
            button_parar_apertura_caja.Size = new Size(184, 40);
            button_parar_apertura_caja.TabIndex = 71;
            button_parar_apertura_caja.Text = "Cerrar Apertura";
            button_parar_apertura_caja.UseVisualStyleBackColor = false;
            button_parar_apertura_caja.Click += button_parar_apertura_caja_Click;
            // 
            // tableLayoutPanel_sobrante
            // 
            tableLayoutPanel_sobrante.ColumnCount = 1;
            tableLayoutPanel_sobrante.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_sobrante.Controls.Add(iconPictureBox_sobrante, 0, 2);
            tableLayoutPanel_sobrante.Controls.Add(label_sobtrante, 0, 0);
            tableLayoutPanel_sobrante.Controls.Add(textBox_sobrante, 0, 1);
            tableLayoutPanel_sobrante.Dock = DockStyle.Fill;
            tableLayoutPanel_sobrante.Location = new Point(3, 3);
            tableLayoutPanel_sobrante.Name = "tableLayoutPanel_sobrante";
            tableLayoutPanel_sobrante.RowCount = 3;
            tableLayoutPanel_sobrante.RowStyles.Add(new RowStyle(SizeType.Percent, 36.53846F));
            tableLayoutPanel_sobrante.RowStyles.Add(new RowStyle(SizeType.Percent, 63.46154F));
            tableLayoutPanel_sobrante.RowStyles.Add(new RowStyle(SizeType.Absolute, 116F));
            tableLayoutPanel_sobrante.Size = new Size(183, 187);
            tableLayoutPanel_sobrante.TabIndex = 85;
            // 
            // iconPictureBox_sobrante
            // 
            iconPictureBox_sobrante.Anchor = AnchorStyles.None;
            iconPictureBox_sobrante.BackColor = Color.Transparent;
            iconPictureBox_sobrante.ForeColor = Color.Tomato;
            iconPictureBox_sobrante.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
            iconPictureBox_sobrante.IconColor = Color.Tomato;
            iconPictureBox_sobrante.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox_sobrante.IconSize = 62;
            iconPictureBox_sobrante.Location = new Point(56, 97);
            iconPictureBox_sobrante.Name = "iconPictureBox_sobrante";
            iconPictureBox_sobrante.Size = new Size(70, 62);
            iconPictureBox_sobrante.TabIndex = 67;
            iconPictureBox_sobrante.TabStop = false;
            // 
            // label_sobtrante
            // 
            label_sobtrante.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_sobtrante.AutoSize = true;
            label_sobtrante.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_sobtrante.ForeColor = Color.FromArgb(255, 128, 0);
            label_sobtrante.Location = new Point(3, 1);
            label_sobtrante.Name = "label_sobtrante";
            label_sobtrante.Size = new Size(177, 23);
            label_sobtrante.TabIndex = 64;
            label_sobtrante.Text = "Sobrante:";
            label_sobtrante.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox_sobrante
            // 
            textBox_sobrante.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_sobrante.Enabled = false;
            textBox_sobrante.Location = new Point(3, 34);
            textBox_sobrante.Name = "textBox_sobrante";
            textBox_sobrante.Size = new Size(177, 27);
            textBox_sobrante.TabIndex = 66;
            // 
            // tableLayoutPanel_faltante
            // 
            tableLayoutPanel_faltante.ColumnCount = 1;
            tableLayoutPanel_faltante.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_faltante.Controls.Add(iconPictureBox_faltante, 0, 2);
            tableLayoutPanel_faltante.Controls.Add(textBox_faltante, 0, 1);
            tableLayoutPanel_faltante.Controls.Add(label_faltante, 0, 0);
            tableLayoutPanel_faltante.Dock = DockStyle.Fill;
            tableLayoutPanel_faltante.Location = new Point(192, 3);
            tableLayoutPanel_faltante.Name = "tableLayoutPanel_faltante";
            tableLayoutPanel_faltante.RowCount = 3;
            tableLayoutPanel_faltante.RowStyles.Add(new RowStyle(SizeType.Percent, 36.9047623F));
            tableLayoutPanel_faltante.RowStyles.Add(new RowStyle(SizeType.Percent, 63.0952377F));
            tableLayoutPanel_faltante.RowStyles.Add(new RowStyle(SizeType.Absolute, 117F));
            tableLayoutPanel_faltante.Size = new Size(183, 187);
            tableLayoutPanel_faltante.TabIndex = 87;
            // 
            // iconPictureBox_faltante
            // 
            iconPictureBox_faltante.Anchor = AnchorStyles.None;
            iconPictureBox_faltante.BackColor = Color.Transparent;
            iconPictureBox_faltante.ForeColor = Color.Red;
            iconPictureBox_faltante.IconChar = FontAwesome.Sharp.IconChar.CircleExclamation;
            iconPictureBox_faltante.IconColor = Color.Red;
            iconPictureBox_faltante.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox_faltante.IconSize = 62;
            iconPictureBox_faltante.Location = new Point(56, 97);
            iconPictureBox_faltante.Name = "iconPictureBox_faltante";
            iconPictureBox_faltante.Size = new Size(70, 62);
            iconPictureBox_faltante.TabIndex = 66;
            iconPictureBox_faltante.TabStop = false;
            // 
            // textBox_faltante
            // 
            textBox_faltante.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_faltante.Enabled = false;
            textBox_faltante.Location = new Point(3, 33);
            textBox_faltante.Name = "textBox_faltante";
            textBox_faltante.Size = new Size(177, 27);
            textBox_faltante.TabIndex = 65;
            // 
            // label_faltante
            // 
            label_faltante.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_faltante.AutoSize = true;
            label_faltante.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_faltante.ForeColor = Color.Red;
            label_faltante.Location = new Point(3, 1);
            label_faltante.Name = "label_faltante";
            label_faltante.Size = new Size(177, 23);
            label_faltante.TabIndex = 63;
            label_faltante.Text = "Faltante:";
            label_faltante.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel_footer
            // 
            tableLayoutPanel_footer.BackColor = Color.Transparent;
            tableLayoutPanel_footer.ColumnCount = 5;
            tableLayoutPanel_footer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel_footer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel_footer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel_footer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel_footer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel_footer.Controls.Add(panel_cerrar_arqueo, 1, 0);
            tableLayoutPanel_footer.Controls.Add(panel_crear_arqueo, 3, 0);
            tableLayoutPanel_footer.Dock = DockStyle.Bottom;
            tableLayoutPanel_footer.Location = new Point(0, 617);
            tableLayoutPanel_footer.Name = "tableLayoutPanel_footer";
            tableLayoutPanel_footer.RowCount = 2;
            tableLayoutPanel_footer.RowStyles.Add(new RowStyle(SizeType.Percent, 85.46512F));
            tableLayoutPanel_footer.RowStyles.Add(new RowStyle(SizeType.Percent, 14.5348835F));
            tableLayoutPanel_footer.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_footer.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_footer.Size = new Size(1250, 215);
            tableLayoutPanel_footer.TabIndex = 92;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 3.125F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 3.125F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel_configuracion_inicial, 1, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel_configuracion_complementaria, 2, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel5, 3, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 77);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1250, 540);
            tableLayoutPanel1.TabIndex = 94;
            // 
            // tableLayoutPanel_configuracion_inicial
            // 
            tableLayoutPanel_configuracion_inicial.ColumnCount = 1;
            tableLayoutPanel_configuracion_inicial.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_configuracion_inicial.Controls.Add(label_titulo_configuracion, 0, 0);
            tableLayoutPanel_configuracion_inicial.Controls.Add(tableLayoutPanel4, 0, 1);
            tableLayoutPanel_configuracion_inicial.Dock = DockStyle.Fill;
            tableLayoutPanel_configuracion_inicial.Location = new Point(42, 3);
            tableLayoutPanel_configuracion_inicial.Name = "tableLayoutPanel_configuracion_inicial";
            tableLayoutPanel_configuracion_inicial.RowCount = 2;
            tableLayoutPanel_configuracion_inicial.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel_configuracion_inicial.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel_configuracion_inicial.Size = new Size(384, 534);
            tableLayoutPanel_configuracion_inicial.TabIndex = 0;
            // 
            // label_titulo_configuracion
            // 
            label_titulo_configuracion.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_configuracion.AutoSize = true;
            label_titulo_configuracion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_titulo_configuracion.Location = new Point(3, 15);
            label_titulo_configuracion.Name = "label_titulo_configuracion";
            label_titulo_configuracion.Size = new Size(378, 23);
            label_titulo_configuracion.TabIndex = 81;
            label_titulo_configuracion.Text = "Configuración Inicial";
            label_titulo_configuracion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(tableLayoutPanel9, 0, 1);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel8, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 56);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(378, 475);
            tableLayoutPanel4.TabIndex = 82;
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.ColumnCount = 1;
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel9.Controls.Add(panel_button_cierre, 0, 2);
            tableLayoutPanel9.Controls.Add(label_total_en_caja, 0, 0);
            tableLayoutPanel9.Controls.Add(textBox_total_en_caja, 0, 1);
            tableLayoutPanel9.Dock = DockStyle.Fill;
            tableLayoutPanel9.Location = new Point(3, 240);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 3;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 65F));
            tableLayoutPanel9.Size = new Size(372, 232);
            tableLayoutPanel9.TabIndex = 88;
            // 
            // panel_button_cierre
            // 
            panel_button_cierre.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_button_cierre.BackColor = Color.Transparent;
            panel_button_cierre.Controls.Add(button_valor_cierre);
            panel_button_cierre.Location = new Point(3, 83);
            panel_button_cierre.Name = "panel_button_cierre";
            panel_button_cierre.Size = new Size(366, 146);
            panel_button_cierre.TabIndex = 96;
            // 
            // button_valor_cierre
            // 
            button_valor_cierre.BackColor = Color.FromArgb(52, 152, 219);
            button_valor_cierre.Cursor = Cursors.Hand;
            button_valor_cierre.FlatAppearance.BorderSize = 0;
            button_valor_cierre.FlatStyle = FlatStyle.Flat;
            button_valor_cierre.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_valor_cierre.ForeColor = Color.White;
            button_valor_cierre.Location = new Point(3, 3);
            button_valor_cierre.Name = "button_valor_cierre";
            button_valor_cierre.Size = new Size(148, 40);
            button_valor_cierre.TabIndex = 76;
            button_valor_cierre.Text = "Valor Cierre";
            button_valor_cierre.UseVisualStyleBackColor = false;
            button_valor_cierre.Click += button_valor_cierre_Click;
            // 
            // label_total_en_caja
            // 
            label_total_en_caja.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_total_en_caja.AutoSize = true;
            label_total_en_caja.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_total_en_caja.Location = new Point(3, 5);
            label_total_en_caja.Name = "label_total_en_caja";
            label_total_en_caja.Size = new Size(366, 23);
            label_total_en_caja.TabIndex = 79;
            label_total_en_caja.Text = "Total en caja:";
            // 
            // textBox_total_en_caja
            // 
            textBox_total_en_caja.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox_total_en_caja.Location = new Point(3, 50);
            textBox_total_en_caja.Name = "textBox_total_en_caja";
            textBox_total_en_caja.Size = new Size(366, 27);
            textBox_total_en_caja.TabIndex = 80;
            textBox_total_en_caja.Click += textBox_total_en_caja_Click;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 1;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel8.Controls.Add(panel_button_abrir, 0, 2);
            tableLayoutPanel8.Controls.Add(textBox_valor_apertura, 0, 1);
            tableLayoutPanel8.Controls.Add(label_valor_apertura, 0, 0);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(3, 3);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 3;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 65F));
            tableLayoutPanel8.Size = new Size(372, 231);
            tableLayoutPanel8.TabIndex = 89;
            // 
            // panel_button_abrir
            // 
            panel_button_abrir.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_button_abrir.BackColor = Color.Transparent;
            panel_button_abrir.Controls.Add(button_valor_apertura);
            panel_button_abrir.Location = new Point(3, 83);
            panel_button_abrir.Name = "panel_button_abrir";
            panel_button_abrir.Size = new Size(366, 145);
            panel_button_abrir.TabIndex = 97;
            // 
            // button_valor_apertura
            // 
            button_valor_apertura.BackColor = Color.FromArgb(52, 152, 219);
            button_valor_apertura.Cursor = Cursors.Hand;
            button_valor_apertura.FlatAppearance.BorderSize = 0;
            button_valor_apertura.FlatStyle = FlatStyle.Flat;
            button_valor_apertura.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_valor_apertura.ForeColor = Color.White;
            button_valor_apertura.Location = new Point(4, 3);
            button_valor_apertura.Name = "button_valor_apertura";
            button_valor_apertura.Size = new Size(148, 40);
            button_valor_apertura.TabIndex = 29;
            button_valor_apertura.Text = "Valor Apertura";
            button_valor_apertura.UseVisualStyleBackColor = false;
            button_valor_apertura.Click += button_valor_apertura_Click;
            // 
            // textBox_valor_apertura
            // 
            textBox_valor_apertura.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox_valor_apertura.Location = new Point(3, 50);
            textBox_valor_apertura.Name = "textBox_valor_apertura";
            textBox_valor_apertura.Size = new Size(366, 27);
            textBox_valor_apertura.TabIndex = 84;
            textBox_valor_apertura.Click += textBox_valor_apertura_Click;
            // 
            // label_valor_apertura
            // 
            label_valor_apertura.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_valor_apertura.AutoSize = true;
            label_valor_apertura.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_valor_apertura.Location = new Point(3, 11);
            label_valor_apertura.Name = "label_valor_apertura";
            label_valor_apertura.Size = new Size(366, 23);
            label_valor_apertura.TabIndex = 83;
            label_valor_apertura.Text = "Valor Apertura:";
            // 
            // tableLayoutPanel_configuracion_complementaria
            // 
            tableLayoutPanel_configuracion_complementaria.ColumnCount = 1;
            tableLayoutPanel_configuracion_complementaria.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_configuracion_complementaria.Controls.Add(tableLayoutPanel_campos, 0, 1);
            tableLayoutPanel_configuracion_complementaria.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel_configuracion_complementaria.Dock = DockStyle.Fill;
            tableLayoutPanel_configuracion_complementaria.Location = new Point(432, 3);
            tableLayoutPanel_configuracion_complementaria.Name = "tableLayoutPanel_configuracion_complementaria";
            tableLayoutPanel_configuracion_complementaria.RowCount = 2;
            tableLayoutPanel_configuracion_complementaria.RowStyles.Add(new RowStyle(SizeType.Percent, 40.3812828F));
            tableLayoutPanel_configuracion_complementaria.RowStyles.Add(new RowStyle(SizeType.Percent, 59.6187172F));
            tableLayoutPanel_configuracion_complementaria.Size = new Size(384, 534);
            tableLayoutPanel_configuracion_complementaria.TabIndex = 1;
            // 
            // tableLayoutPanel_campos
            // 
            tableLayoutPanel_campos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel_campos.ColumnCount = 1;
            tableLayoutPanel_campos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_campos.Controls.Add(label_descripcion, 0, 2);
            tableLayoutPanel_campos.Controls.Add(label_caja, 0, 0);
            tableLayoutPanel_campos.Controls.Add(comboBox_cajas, 0, 1);
            tableLayoutPanel_campos.Controls.Add(textBox_descripcion, 0, 3);
            tableLayoutPanel_campos.Location = new Point(3, 218);
            tableLayoutPanel_campos.Name = "tableLayoutPanel_campos";
            tableLayoutPanel_campos.RowCount = 4;
            tableLayoutPanel_campos.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_campos.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_campos.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_campos.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_campos.Size = new Size(378, 313);
            tableLayoutPanel_campos.TabIndex = 86;
            // 
            // label_descripcion
            // 
            label_descripcion.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_descripcion.AutoSize = true;
            label_descripcion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_descripcion.Location = new Point(3, 183);
            label_descripcion.Name = "label_descripcion";
            label_descripcion.Size = new Size(372, 23);
            label_descripcion.TabIndex = 103;
            label_descripcion.Text = "Descripción:";
            label_descripcion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_caja
            // 
            label_caja.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_caja.AutoSize = true;
            label_caja.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_caja.Location = new Point(3, 27);
            label_caja.Name = "label_caja";
            label_caja.Size = new Size(372, 23);
            label_caja.TabIndex = 81;
            label_caja.Text = "Caja: ";
            label_caja.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBox_cajas
            // 
            comboBox_cajas.Anchor = AnchorStyles.None;
            comboBox_cajas.FormattingEnabled = true;
            comboBox_cajas.Location = new Point(87, 103);
            comboBox_cajas.Name = "comboBox_cajas";
            comboBox_cajas.Size = new Size(204, 28);
            comboBox_cajas.TabIndex = 82;
            // 
            // textBox_descripcion
            // 
            textBox_descripcion.Anchor = AnchorStyles.None;
            textBox_descripcion.Location = new Point(88, 260);
            textBox_descripcion.Name = "textBox_descripcion";
            textBox_descripcion.Size = new Size(201, 27);
            textBox_descripcion.TabIndex = 102;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(tableLayoutPanel_config_turnos, 0, 1);
            tableLayoutPanel3.Controls.Add(label_turno, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 143F));
            tableLayoutPanel3.Size = new Size(378, 209);
            tableLayoutPanel3.TabIndex = 87;
            // 
            // tableLayoutPanel_config_turnos
            // 
            tableLayoutPanel_config_turnos.ColumnCount = 3;
            tableLayoutPanel_config_turnos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel_config_turnos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel_config_turnos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel_config_turnos.Controls.Add(panel_noche, 2, 0);
            tableLayoutPanel_config_turnos.Controls.Add(panel_tarde, 1, 0);
            tableLayoutPanel_config_turnos.Controls.Add(panel_maniana, 0, 0);
            tableLayoutPanel_config_turnos.Dock = DockStyle.Top;
            tableLayoutPanel_config_turnos.Location = new Point(3, 69);
            tableLayoutPanel_config_turnos.Name = "tableLayoutPanel_config_turnos";
            tableLayoutPanel_config_turnos.RowCount = 1;
            tableLayoutPanel_config_turnos.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_config_turnos.Size = new Size(372, 137);
            tableLayoutPanel_config_turnos.TabIndex = 103;
            // 
            // panel_noche
            // 
            panel_noche.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_noche.BackColor = Color.Transparent;
            panel_noche.Controls.Add(button_noche);
            panel_noche.Location = new Point(251, 3);
            panel_noche.Name = "panel_noche";
            panel_noche.Size = new Size(118, 131);
            panel_noche.TabIndex = 106;
            // 
            // button_noche
            // 
            button_noche.BackColor = Color.FromArgb(52, 152, 219);
            button_noche.Cursor = Cursors.Hand;
            button_noche.FlatAppearance.BorderSize = 0;
            button_noche.FlatStyle = FlatStyle.Flat;
            button_noche.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_noche.ForeColor = Color.White;
            button_noche.Location = new Point(6, 9);
            button_noche.Name = "button_noche";
            button_noche.Size = new Size(56, 45);
            button_noche.TabIndex = 30;
            button_noche.Text = "Noche";
            button_noche.UseVisualStyleBackColor = false;
            button_noche.Click += button_noche_Click;
            // 
            // panel_tarde
            // 
            panel_tarde.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_tarde.BackColor = Color.Transparent;
            panel_tarde.Controls.Add(button_tarde);
            panel_tarde.Location = new Point(127, 3);
            panel_tarde.Name = "panel_tarde";
            panel_tarde.Size = new Size(118, 131);
            panel_tarde.TabIndex = 105;
            // 
            // button_tarde
            // 
            button_tarde.BackColor = Color.FromArgb(52, 152, 219);
            button_tarde.Cursor = Cursors.Hand;
            button_tarde.FlatAppearance.BorderSize = 0;
            button_tarde.FlatStyle = FlatStyle.Flat;
            button_tarde.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_tarde.ForeColor = Color.White;
            button_tarde.Location = new Point(3, 3);
            button_tarde.Name = "button_tarde";
            button_tarde.Size = new Size(56, 45);
            button_tarde.TabIndex = 30;
            button_tarde.Text = "Tarde";
            button_tarde.UseVisualStyleBackColor = false;
            button_tarde.Click += button_tarde_Click;
            // 
            // panel_maniana
            // 
            panel_maniana.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_maniana.BackColor = Color.Transparent;
            panel_maniana.Controls.Add(button_maniana);
            panel_maniana.Location = new Point(3, 3);
            panel_maniana.Name = "panel_maniana";
            panel_maniana.Size = new Size(118, 131);
            panel_maniana.TabIndex = 102;
            // 
            // button_maniana
            // 
            button_maniana.BackColor = Color.FromArgb(52, 152, 219);
            button_maniana.Cursor = Cursors.Hand;
            button_maniana.FlatAppearance.BorderSize = 0;
            button_maniana.FlatStyle = FlatStyle.Flat;
            button_maniana.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_maniana.ForeColor = Color.White;
            button_maniana.Location = new Point(6, 9);
            button_maniana.Name = "button_maniana";
            button_maniana.Size = new Size(54, 45);
            button_maniana.TabIndex = 30;
            button_maniana.Text = "Mañana";
            button_maniana.UseVisualStyleBackColor = false;
            button_maniana.Click += button_maniana_Click;
            // 
            // label_turno
            // 
            label_turno.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_turno.AutoSize = true;
            label_turno.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_turno.Location = new Point(3, 21);
            label_turno.Name = "label_turno";
            label_turno.Size = new Size(372, 23);
            label_turno.TabIndex = 102;
            label_turno.Text = "Turnos:";
            label_turno.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(tableLayoutPanel_, 0, 1);
            tableLayoutPanel5.Controls.Add(tableLayoutPanel_transacciones, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(822, 3);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 62.9116135F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 37.0883865F));
            tableLayoutPanel5.Size = new Size(384, 534);
            tableLayoutPanel5.TabIndex = 2;
            // 
            // tableLayoutPanel_
            // 
            tableLayoutPanel_.ColumnCount = 2;
            tableLayoutPanel_.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_.Controls.Add(tableLayoutPanel_sobrante, 0, 0);
            tableLayoutPanel_.Controls.Add(tableLayoutPanel_faltante, 1, 0);
            tableLayoutPanel_.Dock = DockStyle.Fill;
            tableLayoutPanel_.Location = new Point(3, 338);
            tableLayoutPanel_.Name = "tableLayoutPanel_";
            tableLayoutPanel_.RowCount = 1;
            tableLayoutPanel_.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_.Size = new Size(378, 193);
            tableLayoutPanel_.TabIndex = 1;
            // 
            // tableLayoutPanel_transacciones
            // 
            tableLayoutPanel_transacciones.ColumnCount = 1;
            tableLayoutPanel_transacciones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_transacciones.Controls.Add(label_titulo_transacciones, 0, 0);
            tableLayoutPanel_transacciones.Controls.Add(tableLayoutPanel13, 0, 2);
            tableLayoutPanel_transacciones.Controls.Add(tableLayoutPanel7, 0, 1);
            tableLayoutPanel_transacciones.Dock = DockStyle.Fill;
            tableLayoutPanel_transacciones.Location = new Point(3, 3);
            tableLayoutPanel_transacciones.Name = "tableLayoutPanel_transacciones";
            tableLayoutPanel_transacciones.RowCount = 3;
            tableLayoutPanel_transacciones.RowStyles.Add(new RowStyle(SizeType.Percent, 15.7894735F));
            tableLayoutPanel_transacciones.RowStyles.Add(new RowStyle(SizeType.Percent, 42.1052628F));
            tableLayoutPanel_transacciones.RowStyles.Add(new RowStyle(SizeType.Percent, 42.1052628F));
            tableLayoutPanel_transacciones.Size = new Size(378, 329);
            tableLayoutPanel_transacciones.TabIndex = 0;
            // 
            // label_titulo_transacciones
            // 
            label_titulo_transacciones.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_transacciones.AutoSize = true;
            label_titulo_transacciones.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_titulo_transacciones.Location = new Point(3, 14);
            label_titulo_transacciones.Name = "label_titulo_transacciones";
            label_titulo_transacciones.Size = new Size(372, 23);
            label_titulo_transacciones.TabIndex = 105;
            label_titulo_transacciones.Text = "Transacciones";
            label_titulo_transacciones.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel13
            // 
            tableLayoutPanel13.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel13.ColumnCount = 1;
            tableLayoutPanel13.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel13.Controls.Add(textBox_total_transacciones, 0, 2);
            tableLayoutPanel13.Controls.Add(label_total_transacciones, 0, 1);
            tableLayoutPanel13.Controls.Add(iconPictureBox_transacciones_realizadas, 0, 0);
            tableLayoutPanel13.Location = new Point(3, 192);
            tableLayoutPanel13.Name = "tableLayoutPanel13";
            tableLayoutPanel13.RowCount = 3;
            tableLayoutPanel13.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel13.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel13.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel13.Size = new Size(372, 134);
            tableLayoutPanel13.TabIndex = 104;
            // 
            // textBox_total_transacciones
            // 
            textBox_total_transacciones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_total_transacciones.Enabled = false;
            textBox_total_transacciones.Location = new Point(3, 91);
            textBox_total_transacciones.Name = "textBox_total_transacciones";
            textBox_total_transacciones.Size = new Size(366, 27);
            textBox_total_transacciones.TabIndex = 59;
            // 
            // label_total_transacciones
            // 
            label_total_transacciones.AutoSize = true;
            label_total_transacciones.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_total_transacciones.Location = new Point(3, 44);
            label_total_transacciones.Name = "label_total_transacciones";
            label_total_transacciones.Size = new Size(207, 23);
            label_total_transacciones.TabIndex = 57;
            label_total_transacciones.Text = "Transacciones realizadas:";
            label_total_transacciones.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // iconPictureBox_transacciones_realizadas
            // 
            iconPictureBox_transacciones_realizadas.Anchor = AnchorStyles.Top;
            iconPictureBox_transacciones_realizadas.BackColor = Color.Transparent;
            iconPictureBox_transacciones_realizadas.ForeColor = Color.ForestGreen;
            iconPictureBox_transacciones_realizadas.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
            iconPictureBox_transacciones_realizadas.IconColor = Color.ForestGreen;
            iconPictureBox_transacciones_realizadas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox_transacciones_realizadas.IconSize = 38;
            iconPictureBox_transacciones_realizadas.Location = new Point(156, 3);
            iconPictureBox_transacciones_realizadas.Name = "iconPictureBox_transacciones_realizadas";
            iconPictureBox_transacciones_realizadas.Size = new Size(59, 38);
            iconPictureBox_transacciones_realizadas.TabIndex = 60;
            iconPictureBox_transacciones_realizadas.TabStop = false;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel7.ColumnCount = 1;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.Controls.Add(label_total_transacciones_valor, 0, 1);
            tableLayoutPanel7.Controls.Add(textBox_total_transacciones_valor, 0, 2);
            tableLayoutPanel7.Controls.Add(iconPictureBox_valor_transaciones, 0, 0);
            tableLayoutPanel7.Location = new Point(3, 54);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 3;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel7.Size = new Size(372, 132);
            tableLayoutPanel7.TabIndex = 104;
            // 
            // label_total_transacciones_valor
            // 
            label_total_transacciones_valor.AutoSize = true;
            label_total_transacciones_valor.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_total_transacciones_valor.Location = new Point(3, 44);
            label_total_transacciones_valor.Name = "label_total_transacciones_valor";
            label_total_transacciones_valor.Size = new Size(162, 23);
            label_total_transacciones_valor.TabIndex = 75;
            label_total_transacciones_valor.Text = "Valor transacciones";
            label_total_transacciones_valor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox_total_transacciones_valor
            // 
            textBox_total_transacciones_valor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_total_transacciones_valor.Enabled = false;
            textBox_total_transacciones_valor.Location = new Point(3, 91);
            textBox_total_transacciones_valor.Name = "textBox_total_transacciones_valor";
            textBox_total_transacciones_valor.Size = new Size(366, 27);
            textBox_total_transacciones_valor.TabIndex = 76;
            // 
            // iconPictureBox_valor_transaciones
            // 
            iconPictureBox_valor_transaciones.Anchor = AnchorStyles.Top;
            iconPictureBox_valor_transaciones.BackColor = Color.Transparent;
            iconPictureBox_valor_transaciones.ForeColor = Color.ForestGreen;
            iconPictureBox_valor_transaciones.IconChar = FontAwesome.Sharp.IconChar.Usd;
            iconPictureBox_valor_transaciones.IconColor = Color.ForestGreen;
            iconPictureBox_valor_transaciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox_valor_transaciones.IconSize = 38;
            iconPictureBox_valor_transaciones.Location = new Point(151, 3);
            iconPictureBox_valor_transaciones.Name = "iconPictureBox_valor_transaciones";
            iconPictureBox_valor_transaciones.Size = new Size(70, 38);
            iconPictureBox_valor_transaciones.TabIndex = 77;
            iconPictureBox_valor_transaciones.TabStop = false;
            // 
            // ArqueoCajaForm
            // 
            ClientSize = new Size(1250, 832);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tableLayoutPanel_footer);
            Controls.Add(tableLayoutPanel_logueado);
            Name = "ArqueoCajaForm";
            Load += ArqueoCajaForm_Load_1;
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_tipo).EndInit();
            tableLayoutPanel_logueado.ResumeLayout(false);
            tableLayoutPanel_logueado.PerformLayout();
            panel1.ResumeLayout(false);
            panel_crear_arqueo.ResumeLayout(false);
            panel_cerrar_arqueo.ResumeLayout(false);
            tableLayoutPanel_sobrante.ResumeLayout(false);
            tableLayoutPanel_sobrante.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox_sobrante).EndInit();
            tableLayoutPanel_faltante.ResumeLayout(false);
            tableLayoutPanel_faltante.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox_faltante).EndInit();
            tableLayoutPanel_footer.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel_configuracion_inicial.ResumeLayout(false);
            tableLayoutPanel_configuracion_inicial.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel9.ResumeLayout(false);
            tableLayoutPanel9.PerformLayout();
            panel_button_cierre.ResumeLayout(false);
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
            panel_button_abrir.ResumeLayout(false);
            tableLayoutPanel_configuracion_complementaria.ResumeLayout(false);
            tableLayoutPanel_campos.ResumeLayout(false);
            tableLayoutPanel_campos.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel_config_turnos.ResumeLayout(false);
            panel_noche.ResumeLayout(false);
            panel_tarde.ResumeLayout(false);
            panel_maniana.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel_.ResumeLayout(false);
            tableLayoutPanel_transacciones.ResumeLayout(false);
            tableLayoutPanel_transacciones.PerformLayout();
            tableLayoutPanel13.ResumeLayout(false);
            tableLayoutPanel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox_transacciones_realizadas).EndInit();
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox_valor_transaciones).EndInit();
            ResumeLayout(false);
        }


        private void button_apertura_de_caja_Click(object sender, EventArgs e)
        {

            if (!validarCamposApertura())
            {
                StylesAlertas.MostrarAlerta(this, "Completar todos los campos para la apertura", "¡Error!", TipoAlerta.Error);
                return;
            }

            var cajas = _CajaController.obtener_cajas_cerradas();
            if (cajas == null)
            {
                StylesAlertas.MostrarAlerta(this, "No existen cajas disponibles para la apertura", "¡Error!", TipoAlerta.Error);
                return;
            }
            decimal valor_apertura_normalizado = _FuncionesGenerales.ParseDecimalFromTextBoxNormalizado(textBox_valor_apertura.Text);
            decimal total_en_caja = _FuncionesGenerales.ParseDecimalFromTextBoxNormalizado(textBox_total_en_caja.Text);
            decimal faltante = _FuncionesGenerales.ParseDecimalFromTextBoxNormalizado(textBox_faltante.Text);
            decimal sobrante = _FuncionesGenerales.ParseDecimalFromTextBoxNormalizado(textBox_sobrante.Text);

            var arqueo = new arqueo_cajaM
            {
                caja_id = Convert.ToInt32(comboBox_cajas.SelectedValue), // el ID real de la caja
                id_persona_rol = SessionUser.id_persona_rol,            // del login o sesión
                turno = buscarTurnoDisponible(),
                fecha_apertura = DateTime.Now,                           // apertura actual
                hora_cierre = DateTime.Now,
                valor_apertura = valor_apertura_normalizado,
                total_en_caja = total_en_caja,
                faltante = faltante,
                sobrante = sobrante,
                observaciones = textBox_descripcion.Text.Trim(),
                estado = "A",
                pinpad_lote = "",        // si luego implementas
                pinpad_referencia = ""   // idem
            };

            if (arqueo != null)
            {
                arqueo_caja_id = _AperturaCajaController.Insertar_ReturnId(arqueo);
                StylesAlertas.MostrarAlerta(this, "Arqueo de Caja Creado Correctamente", tipo: TipoAlerta.Success);

                //estado controles
                textBox_total_en_caja.Enabled = true;
                textBox_valor_apertura.Enabled = false;


                SessionArqueoCaja.id_arqueo_caja = arqueo_caja_id;
                SessionArqueoCaja.montoValidar = valor_apertura_normalizado;
                SessionArqueoCaja.estadoArqueo = "A";

                var BilletesMonedasForm = new BilletesMonedasForm();
                BilletesMonedasForm.StartPosition = FormStartPosition.CenterParent;
                BilletesMonedasForm.FormClosed += (s, args) =>
                {
                    button_valor_cierre.Enabled = true;
                    button_apertura_de_caja.Enabled = false;
                    button_parar_apertura_caja.Enabled = true;
                };
                BilletesMonedasForm.ShowDialog(this);
            }



        }

        private bool validarCamposApertura()
        {

            bool estado = true;

            string turno = buscarTurnoDisponible();

            if (turno == "Asignado" || Convert.ToInt32(comboBox_cajas.SelectedValue) == 0)
            {

                return estado = false;
            }
            if (textBox_valor_apertura.Text.Trim() == "")
            {

                return estado = false;
            }


            return estado;
        }


        private bool validarCamposCierre()
        {
            bool estado = true;

            if (textBox_total_en_caja.Text.Trim() == "")
            {

                return estado = false;
            }

            return estado;
        }

        private string buscarTurnoDisponible()
        {

            string valor = "";

            if (button_maniana.Enabled == false)
            {
                return valor = "mañana";
            }
            else if (button_tarde.Enabled == false)
            {
                return valor = "tarde";
            }
            else if (button_noche.Enabled == false)
            {
                return valor = "noche";
            }
            return "Asignado";
        }
        private void textBox_saldo_inicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite dígitos, retroceso y punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Solo un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
            {
                e.Handled = true;
            }
        }


        private Label label_titulo_arqueo;
        private FontAwesome.Sharp.IconButton iconButton_regresar;

        private void label_titulo_usuarios_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            var MenuPrincipalForm = new MenuPrincipalForm();
            this.Hide();                 // Opcional: ocultas la ventana actual
            MenuPrincipalForm.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
            this.Close();
        }



        private void button_parar_apertura_caja_Click(object sender, EventArgs e)
        {

            if (!validarCamposCierre())
            {
                StylesAlertas.MostrarAlerta(this, "Completar todos los campos para la apertura", "¡Error!", TipoAlerta.Error);
                return;
            }
            decimal total_en_caja = _FuncionesGenerales.ParseDecimalFromTextBoxNormalizado(textBox_total_en_caja.Text);
            decimal faltante = _FuncionesGenerales.ParseDecimalFromTextBoxNormalizado(textBox_faltante.Text);
            decimal sobrante = _FuncionesGenerales.ParseDecimalFromTextBoxNormalizado(textBox_sobrante.Text);

            var arqueo = new arqueo_cajaM
            {
                arqueo_id = SessionArqueoCaja.id_arqueo_caja,
                id_persona_rol = SessionUser.id_persona_rol,
                hora_cierre = DateTime.Now,
                total_transacciones = decimal.TryParse(textBox_total_transacciones.Text, out var trans) ? trans : 0,
                total_en_caja = total_en_caja,
                faltante = faltante,
                sobrante = sobrante,
                observaciones = textBox_descripcion.Text.Trim(),
                estado = "C",
            };

            var ArqueoCajaAbierto = _AperturaCajaController.ObtenerPorId(arqueo_caja_id);

            if (arqueo_caja_id > 0)
            {
                var resultado = MessageBox.Show(
                    $"¿Desea cerrar este arqueo de caja?",
                    "Confirmar",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (resultado == DialogResult.OK)
                {
                    int idArqueoCaja = arqueo_caja_id;

                    if (idArqueoCaja > 0)
                    {
                        _AperturaCajaController.Actualizar(arqueo);
                        StylesAlertas.MostrarAlerta(this, "Arqueo de caja cerrado correctamente.", tipo: TipoAlerta.Success);
                        var MenuPrincipalForm = new MenuPrincipalForm();
                        this.Hide();                 // Opcional: ocultas la ventana actual
                        MenuPrincipalForm.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
                        this.Close();

                    }
                    else
                    {
                        StylesAlertas.MostrarAlerta(this, "ID del arqueo de caja no válido.", "¡Error!", TipoAlerta.Error);
                    }
                }
            }
            else
            {
                StylesAlertas.MostrarAlerta(this, "Seleccione una caja que desea eliminar.", "¡Error!", TipoAlerta.Error);
            }
        }



        public void actulizarCamposCierreCaja()
        {

            var datos_transacciones = _TransaccionesCaja.ObtenerResumenPorArqueo(SessionArqueoCaja.id_arqueo_caja);

            textBox_total_transacciones.Text = datos_transacciones.totalTransacciones.ToString();

            textBox_total_transacciones_valor.Text = datos_transacciones.totalACobrar.ToString("0.##", CultureInfo.InvariantCulture);

            decimal total_en_caja = _FuncionesGenerales.ParseDecimalFromTextBox(textBox_total_en_caja.Text);
            decimal total_valor_apertura = _FuncionesGenerales.ParseDecimalFromTextBox(textBox_valor_apertura.Text);
            decimal valor_total_transacciones = _FuncionesGenerales.ParseDecimalFromTextBox(textBox_total_transacciones_valor.Text);

            // Inicializar sobrante/faltante

            decimal total_dia = total_valor_apertura + valor_total_transacciones;
            decimal sobrante = 0;
            decimal faltante = 0;

            // Calcular sobrante/faltante con respecto al total del día
            if (total_en_caja > total_dia)
            {
                sobrante = total_en_caja - total_dia;
                textBox_sobrante.Text = sobrante.ToString("0.##", CultureInfo.InvariantCulture);
                textBox_faltante.Text = "0.00";
            }
            else if (total_en_caja < total_dia)
            {
                faltante = total_dia - total_en_caja;
                textBox_faltante.Text = faltante.ToString("0.##", CultureInfo.InvariantCulture);
                textBox_sobrante.Text = "0.00";
            }
            else
            {
                textBox_sobrante.Text = "0.00";
                textBox_faltante.Text = "0.00";
            }

        }

        private void textBox_valor_apertura_Click(object sender, EventArgs e)
        {
            TecladoDesplegable.MostrarTeclado(this, textBox_valor_apertura, TipoTeclado.Numerico, soloNumerico: true);
        }

        private void textBox_total_en_caja_Click(object sender, EventArgs e)
        {
            TecladoDesplegable.MostrarTeclado(this, textBox_total_en_caja, TipoTeclado.Numerico, soloNumerico: true);
        }

        private void textBox_descripcion_Click(object sender, EventArgs e)
        {
            TecladoDesplegable.MostrarTeclado(this, textBox_descripcion);
        }

        private void button_valor_apertura_Click(object sender, EventArgs e)
        {
            SessionArqueoCaja.estadoArqueo = "A";

            SessionArqueoCaja.montoValidar = _FuncionesGenerales.ParseDecimalFromTextBoxNormalizado(textBox_valor_apertura.Text);
            var BilletesMonedasForm = new BilletesMonedasForm();
            BilletesMonedasForm.StartPosition = FormStartPosition.CenterParent;
            BilletesMonedasForm.FormClosed += (s, args) =>
            {

            };
            BilletesMonedasForm.ShowDialog(this);
        }

        private void button_valor_cierre_Click(object sender, EventArgs e)
        {
            SessionArqueoCaja.estadoArqueo = "C";
            SessionArqueoCaja.montoValidar = _FuncionesGenerales.ParseDecimalFromTextBoxNormalizado(textBox_total_en_caja.Text);
            var BilletesMonedasForm = new BilletesMonedasForm();
            BilletesMonedasForm.StartPosition = FormStartPosition.CenterParent;
            BilletesMonedasForm.FormClosed += (s, args) =>
            {
                actulizarCamposCierreCaja();
            };
            BilletesMonedasForm.ShowDialog(this);
        }

        private void button_maniana_Click(object sender, EventArgs e)
        {
            button_maniana.Enabled = false;
            button_tarde.Enabled = true;
            button_noche.Enabled = true;
        }

        private void button_tarde_Click(object sender, EventArgs e)
        {
            button_maniana.Enabled = true;
            button_tarde.Enabled = false;
            button_noche.Enabled = true;
        }

        private void button_noche_Click(object sender, EventArgs e)
        {
            button_maniana.Enabled = true;
            button_tarde.Enabled = true;
            button_noche.Enabled = false;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
