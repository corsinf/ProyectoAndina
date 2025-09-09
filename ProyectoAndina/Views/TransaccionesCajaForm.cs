using Newtonsoft.Json;
using ProyectoAndina.Controllers;
using ProyectoAndina.Funciones_Generales;
using ProyectoAndina.Helper;
using ProyectoAndina.Models;
using ProyectoAndina.Services;
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
    public partial class TransaccionesCajaForm : Form
    {
        private readonly PersonaController _PersonaController;
        private readonly TransaccionCajaController _TransaccionCajaController;
        private readonly ApiService _apiService;
        private readonly FuncionesGenerales _funcionesGenerales = new FuncionesGenerales();
        private TableLayoutPanel tableLayoutPanel_logueado;
        private Panel panel1;
        private PictureBox pictureBox1;
        private TableLayoutPanel tableLayoutPanel_footer;
        private Panel panel_col_cancelar;
        private Button button_cancelar_transaccion;
        private Panel panel_col_cobrar;
        private Button button_realizar_transaccion;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel_datos_placa;
        private TableLayoutPanel tableLayoutPanel8;
        private Label label_valor_de_cambio;
        private Label label_valor_cambio;
        private Label label_valor_cobrar;
        private Label label_valor_a_cobrar;
        private TableLayoutPanel tableLayoutPanel7;
        private Label label_valor_tiempo;
        private Label label_hora_estacionamiento;
        private Label label_valor_hora_ingreso;
        private Label label_hora_ingreso;
        private Label label_titulo_datos_placas;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private Panel panel_tarjeta;
        private Button button_tarjeta;
        private Panel panel_transferencia;
        private Button button_transferencia;
        private Panel panel_efectivo;
        private Button button_efectivo;
        private Label label_tipo_de_pago;
        private TableLayoutPanel tableLayoutPanel3;
        private TextBox textBox_valor_entregado;
        private TableLayoutPanel tableLayoutPanel6;
        private TableLayoutPanel tableLayoutPanel11;
        private Panel panel_consumidor_final;
        private Button button_consumidor_final;
        private Panel panel_con_datos;
        private Button button_con_datos;
        private Panel panel_buscar_usuarios;
        private Button button_agregar_user;
        private TableLayoutPanel tableLayoutPanel10;
        private Panel panel_controls_placas;
        private Button button_buscar_placa;
        private Panel panel_image_placa;
        private PictureBox pictureBox_image_placa;
        private TableLayoutPanel tableLayoutPanel9;
        private TextBox textBox_buscar_placa;
        private Label label_placa;
        private Panel panel_verificar_monto;
        private Button button_verificar_monto;
        private Panel panel2;
        private Label label_valor_entregado;
        private TableLayoutPanel tableLayoutPanel_buscar_user;
        private Panel panel_control_boton_busqueda;
        private Button button_buscar_usuario;
        private Label label_titulo_usuario;
        private TextBox textBox_usuario_encontrar;
        private TableLayoutPanel tableLayoutPanel_usuario_encontrado;
        private Label label_nombre;
        private Label label_telefono;
        private Label label_cedula;
        private Label label_correo;
        private int id_usuario;

        public int tipo_factura;

        public TransaccionesCajaForm()
        {

            _PersonaController = new PersonaController();
            _apiService = new ApiService();
            _TransaccionCajaController = new TransaccionCajaController();
            InitializeComponent();
            ConfigurarEstilo();
            this.Paint += TransaccionesCajaForm_Paint;
            this.DoubleBuffered = true;
            // se despliega en toda la pantalla
            this.WindowState = FormWindowState.Maximized;

        }

        private void TransaccionesCajaForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }

        public void ConfigurarEstilo()
        {
            StyleManager.ConfigurarFormPrincipal(this, "Menu de Roles");
            this.BackColor = StyleManager.Colors.GrisClaro;



            // Configurar labels con estilos UASB
            StyleManager.ConfigurarLabel(label_titulo_transacciones, TipoLabel.TituloGrande);

            StyleManager.ConfigurarLabel(label_titulo_usuario, TipoLabel.TituloMedio);

            // esto es de los labels

            StyleLabel.ConfigurarLabel(label_tipo_de_pago, TipoLabel.TituloPequeno);
            StyleLabel.ConfigurarLabel(label_hora_estacionamiento,  TipoLabel.TituloPequeno);
            StyleLabel.ConfigurarLabel(label_hora_ingreso,  TipoLabel.TituloPequeno);
            StyleLabel.ConfigurarLabel(label_valor_cobrar,  TipoLabel.TituloPequeno);
            StyleLabel.ConfigurarLabel(label_valor_entregado,  TipoLabel.TituloMedio);
            StyleLabel.ConfigurarLabel(label_valor_cambio, TipoLabel.TituloPequeno);
            StyleLabel.ConfigurarLabel(label_placa, TipoLabel.TituloMedio);
            StyleLabel.ConfigurarLabel(label_titulo_datos_placas, TipoLabel.TituloMedio);

            // este es de los inputs
            StyleManager.ConfigurarTextBox(textBox_valor_entregado, "");
            StyleManager.ConfigurarTextBox(textBox_buscar_placa, "");



            // Configurar panel principal con sombra
            StyleManager.ConfigurarBotonPrincipalIcono(
              iconButton_regresar,
              FontAwesome.Sharp.IconChar.SignOutAlt,
              "Regresar",
              colorFondo: Color.FromArgb(231, 76, 60)
              );
            

            StyleImage.ConfigurarImagenEnPanel(panel_image_placa, pictureBox_image_placa, Properties.Resources.placa_blanco_negro);


            StyleManager.ConfigurarBotonIconoEnPanel(
     panel_col_cancelar,
     button_cancelar_transaccion,
     FontAwesome.Sharp.IconChar.Ban,                 // 🚫 Prohibición → cancelar definitivamente
     Color.FromArgb(231, 76, 60)                     // Rojo crítico (#E74C3C)
 );

            // ⚠️ VERIFICAR MONTO (Validación/advertencia)
            StyleManager.ConfigurarBotonIconoEnPanel(
                panel_verificar_monto,
                button_verificar_monto,
                FontAwesome.Sharp.IconChar.ExclamationTriangle, // ⚠️ Triángulo de advertencia → verificación
                Color.FromArgb(255, 152, 0)                     // Naranja advertencia (#FF9800)
            );

            // ✅ REALIZAR TRANSACCIÓN (Acción principal exitosa)
            StyleManager.ConfigurarBotonIconoEnPanel(
                panel_col_cobrar,
                button_realizar_transaccion,
                FontAwesome.Sharp.IconChar.CheckCircle,         // ✅ Check circular → completar transacción
                Color.FromArgb(76, 175, 80)                     // Verde éxito Material (#4CAF50)
            );

            // 👤 CONSUMIDOR FINAL (Cliente individual)
            StyleManager.ConfigurarBotonIconoEnPanel(
                panel_consumidor_final,
                button_consumidor_final,
                FontAwesome.Sharp.IconChar.UserTag,             // 🏷️ Usuario con etiqueta → cliente individual
                Color.FromArgb(33, 150, 243)                    // Azul Material (#2196F3)
            );

            // 🏢 CON DATOS (Cliente empresarial/RUC)
            StyleManager.ConfigurarBotonIconoEnPanel(
                panel_con_datos,
                button_con_datos,
                FontAwesome.Sharp.IconChar.BuildingUser,        // 🏢👤 Edificio con usuario → cliente empresarial
                Color.FromArgb(103, 58, 183)                    // Púrpura Material (#673AB7)
            );

            // 🚗 BUSCAR PLACA (Vehículos/parking)
            StyleManager.ConfigurarBotonIconoEnPanel(
                panel_controls_placas,
                button_buscar_placa,
                FontAwesome.Sharp.IconChar.IdCard,              // 🆔 Tarjeta ID → placa de identificación
                Color.FromArgb(0, 150, 136)                     // Verde azulado Material (#009688)
            );

            // 🔍 BUSCAR USUARIO (Búsqueda general)
            StyleManager.ConfigurarBotonIconoEnPanel(
                panel_control_boton_busqueda,
                button_buscar_usuario,
                FontAwesome.Sharp.IconChar.User,          // 🔍👤 Buscar usuario específicamente
                Color.FromArgb(96, 125, 139)                    // Azul gris Material (#607D8B)
            );

            // ➕ AGREGAR USUARIO (Nuevo cliente)
            StyleManager.ConfigurarBotonIconoEnPanel(
                panel_buscar_usuarios,
                button_agregar_user,
                FontAwesome.Sharp.IconChar.UserPlus,            // ➕👤 Agregar usuario → mantener ícono
                Color.FromArgb(255, 87, 34)                     // Naranja Material (#FF5722)
            );

            // 🏦 TRANSFERENCIA BANCARIA (Pago electrónico)
            StyleManager.ConfigurarBotonIconoEnPanel(
                panel_transferencia,
                button_transferencia,
                FontAwesome.Sharp.IconChar.CreditCardAlt,       // 💳 Tarjeta alternativa → transferencia
                Color.FromArgb(63, 81, 181)                     // Índigo Material (#3F51B5)
            );

            // 💵 EFECTIVO (Pago en cash)
            StyleManager.ConfigurarBotonIconoEnPanel(
                panel_efectivo,
                button_efectivo,
                FontAwesome.Sharp.IconChar.HandHoldingDollar,   // 💰 Mano con dinero → pago efectivo
                Color.FromArgb(255, 193, 7)                     // Amarillo Material (#FFC107)
            );

            // 💳 TARJETA (Pago con tarjeta)
            StyleManager.ConfigurarBotonIconoEnPanel(
                panel_tarjeta,
                button_tarjeta,
                FontAwesome.Sharp.IconChar.CreditCard,          // 💳 Tarjeta de crédito → mantener ícono
                Color.FromArgb(0, 188, 212)                     // Cian Material (#00BCD4)
            );



            //para el form de la apertura 

            StyleContenedores.EstilizarTableLayout(tableLayoutPanel_datos_placa, Color.FromArgb(0, 110, 99));
            StyleContenedores.EstilizarTableLayout(tableLayoutPanel_usuario_encontrado, Color.FromArgb(0, 110, 99));

            


        }

        private void InitializeComponent()
        {
            label_titulo_transacciones = new Label();
            iconButton_regresar = new FontAwesome.Sharp.IconButton();
            tableLayoutPanel_logueado = new TableLayoutPanel();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            tableLayoutPanel_footer = new TableLayoutPanel();
            panel_col_cancelar = new Panel();
            button_cancelar_transaccion = new Button();
            panel_col_cobrar = new Panel();
            button_realizar_transaccion = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            panel_tarjeta = new Panel();
            button_tarjeta = new Button();
            panel_transferencia = new Panel();
            button_transferencia = new Button();
            panel_efectivo = new Panel();
            button_efectivo = new Button();
            label_tipo_de_pago = new Label();
            label_titulo_datos_placas = new Label();
            tableLayoutPanel_datos_placa = new TableLayoutPanel();
            tableLayoutPanel8 = new TableLayoutPanel();
            label_valor_de_cambio = new Label();
            label_valor_cambio = new Label();
            label_valor_cobrar = new Label();
            label_valor_a_cobrar = new Label();
            tableLayoutPanel7 = new TableLayoutPanel();
            label_valor_tiempo = new Label();
            label_hora_estacionamiento = new Label();
            label_valor_hora_ingreso = new Label();
            label_hora_ingreso = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            panel_verificar_monto = new Panel();
            button_verificar_monto = new Button();
            panel2 = new Panel();
            textBox_valor_entregado = new TextBox();
            label_valor_entregado = new Label();
            tableLayoutPanel6 = new TableLayoutPanel();
            tableLayoutPanel10 = new TableLayoutPanel();
            panel_controls_placas = new Panel();
            button_buscar_placa = new Button();
            panel_image_placa = new Panel();
            pictureBox_image_placa = new PictureBox();
            tableLayoutPanel9 = new TableLayoutPanel();
            textBox_buscar_placa = new TextBox();
            label_placa = new Label();
            tableLayoutPanel11 = new TableLayoutPanel();
            panel_buscar_usuarios = new Panel();
            button_agregar_user = new Button();
            panel_con_datos = new Panel();
            tableLayoutPanel_usuario_encontrado = new TableLayoutPanel();
            label_nombre = new Label();
            label_telefono = new Label();
            label_cedula = new Label();
            label_correo = new Label();
            button_con_datos = new Button();
            panel_consumidor_final = new Panel();
            tableLayoutPanel_buscar_user = new TableLayoutPanel();
            panel_control_boton_busqueda = new Panel();
            button_buscar_usuario = new Button();
            label_titulo_usuario = new Label();
            textBox_usuario_encontrar = new TextBox();
            button_consumidor_final = new Button();
            tableLayoutPanel_logueado.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel_footer.SuspendLayout();
            panel_col_cancelar.SuspendLayout();
            panel_col_cobrar.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            panel_tarjeta.SuspendLayout();
            panel_transferencia.SuspendLayout();
            panel_efectivo.SuspendLayout();
            tableLayoutPanel_datos_placa.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panel_verificar_monto.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel10.SuspendLayout();
            panel_controls_placas.SuspendLayout();
            panel_image_placa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_image_placa).BeginInit();
            tableLayoutPanel9.SuspendLayout();
            tableLayoutPanel11.SuspendLayout();
            panel_buscar_usuarios.SuspendLayout();
            panel_con_datos.SuspendLayout();
            tableLayoutPanel_usuario_encontrado.SuspendLayout();
            panel_consumidor_final.SuspendLayout();
            tableLayoutPanel_buscar_user.SuspendLayout();
            panel_control_boton_busqueda.SuspendLayout();
            SuspendLayout();
            // 
            // label_titulo_transacciones
            // 
            label_titulo_transacciones.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_transacciones.AutoSize = true;
            label_titulo_transacciones.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_transacciones.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_transacciones.Location = new Point(301, 20);
            label_titulo_transacciones.Name = "label_titulo_transacciones";
            label_titulo_transacciones.Size = new Size(591, 37);
            label_titulo_transacciones.TabIndex = 14;
            label_titulo_transacciones.Text = "Transacciones";
            label_titulo_transacciones.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // iconButton_regresar
            // 
            iconButton_regresar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
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
            iconButton_regresar.Location = new Point(41, 3);
            iconButton_regresar.Name = "iconButton_regresar";
            iconButton_regresar.Size = new Size(215, 71);
            iconButton_regresar.TabIndex = 51;
            iconButton_regresar.Text = "  Regresar";
            iconButton_regresar.TextAlign = ContentAlignment.MiddleRight;
            iconButton_regresar.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton_regresar.UseVisualStyleBackColor = false;
            iconButton_regresar.Click += iconButton_regresar_Click;
            // 
            // tableLayoutPanel_logueado
            // 
            tableLayoutPanel_logueado.BackColor = Color.Transparent;
            tableLayoutPanel_logueado.ColumnCount = 3;
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel_logueado.Controls.Add(iconButton_regresar, 0, 0);
            tableLayoutPanel_logueado.Controls.Add(label_titulo_transacciones, 1, 0);
            tableLayoutPanel_logueado.Controls.Add(panel1, 2, 0);
            tableLayoutPanel_logueado.Dock = DockStyle.Top;
            tableLayoutPanel_logueado.Location = new Point(0, 0);
            tableLayoutPanel_logueado.Name = "tableLayoutPanel_logueado";
            tableLayoutPanel_logueado.RowCount = 1;
            tableLayoutPanel_logueado.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_logueado.Size = new Size(1194, 77);
            tableLayoutPanel_logueado.TabIndex = 107;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(898, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(293, 71);
            panel1.TabIndex = 78;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Logotipo_color;
            pictureBox1.Location = new Point(21, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(235, 60);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 64;
            pictureBox1.TabStop = false;
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
            tableLayoutPanel_footer.Controls.Add(panel_col_cancelar, 1, 0);
            tableLayoutPanel_footer.Controls.Add(panel_col_cobrar, 3, 0);
            tableLayoutPanel_footer.Dock = DockStyle.Bottom;
            tableLayoutPanel_footer.Location = new Point(0, 569);
            tableLayoutPanel_footer.Name = "tableLayoutPanel_footer";
            tableLayoutPanel_footer.RowCount = 2;
            tableLayoutPanel_footer.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_footer.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel_footer.Size = new Size(1194, 177);
            tableLayoutPanel_footer.TabIndex = 108;
            // 
            // panel_col_cancelar
            // 
            panel_col_cancelar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_col_cancelar.BackColor = Color.Transparent;
            panel_col_cancelar.Controls.Add(button_cancelar_transaccion);
            panel_col_cancelar.Location = new Point(122, 3);
            panel_col_cancelar.Name = "panel_col_cancelar";
            panel_col_cancelar.Size = new Size(352, 136);
            panel_col_cancelar.TabIndex = 115;
            // 
            // button_cancelar_transaccion
            // 
            button_cancelar_transaccion.BackColor = Color.FromArgb(219, 52, 52);
            button_cancelar_transaccion.Cursor = Cursors.Hand;
            button_cancelar_transaccion.Enabled = false;
            button_cancelar_transaccion.FlatAppearance.BorderSize = 0;
            button_cancelar_transaccion.FlatStyle = FlatStyle.Flat;
            button_cancelar_transaccion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_cancelar_transaccion.ForeColor = Color.White;
            button_cancelar_transaccion.Location = new Point(78, 48);
            button_cancelar_transaccion.Name = "button_cancelar_transaccion";
            button_cancelar_transaccion.Size = new Size(184, 40);
            button_cancelar_transaccion.TabIndex = 73;
            button_cancelar_transaccion.Text = "Cancelar";
            button_cancelar_transaccion.UseVisualStyleBackColor = false;
            button_cancelar_transaccion.Click += button_cancelar_transaccion_Click;
            // 
            // panel_col_cobrar
            // 
            panel_col_cobrar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_col_cobrar.BackColor = Color.Transparent;
            panel_col_cobrar.Controls.Add(button_realizar_transaccion);
            panel_col_cobrar.Location = new Point(718, 3);
            panel_col_cobrar.Name = "panel_col_cobrar";
            panel_col_cobrar.Size = new Size(352, 136);
            panel_col_cobrar.TabIndex = 116;
            // 
            // button_realizar_transaccion
            // 
            button_realizar_transaccion.BackColor = Color.FromArgb(52, 152, 219);
            button_realizar_transaccion.Cursor = Cursors.Hand;
            button_realizar_transaccion.Enabled = false;
            button_realizar_transaccion.FlatAppearance.BorderSize = 0;
            button_realizar_transaccion.FlatStyle = FlatStyle.Flat;
            button_realizar_transaccion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_realizar_transaccion.ForeColor = Color.White;
            button_realizar_transaccion.Location = new Point(75, 48);
            button_realizar_transaccion.Name = "button_realizar_transaccion";
            button_realizar_transaccion.Size = new Size(176, 40);
            button_realizar_transaccion.TabIndex = 72;
            button_realizar_transaccion.Text = "Cobrar";
            button_realizar_transaccion.UseVisualStyleBackColor = false;
            button_realizar_transaccion.Click += button_realizar_transaccion_Click;
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
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 2, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel6, 3, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel11, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 77);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1194, 492);
            tableLayoutPanel1.TabIndex = 109;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 0, 2);
            tableLayoutPanel2.Controls.Add(label_titulo_datos_placas, 0, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel_datos_placa, 0, 1);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 3);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(413, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 24.260355F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 75.73965F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 151F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 165F));
            tableLayoutPanel2.Size = new Size(367, 486);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(tableLayoutPanel5, 0, 1);
            tableLayoutPanel4.Controls.Add(label_tipo_de_pago, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 172);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 30.7189541F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 69.281044F));
            tableLayoutPanel4.Size = new Size(361, 145);
            tableLayoutPanel4.TabIndex = 95;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 3;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel5.Controls.Add(panel_tarjeta, 2, 0);
            tableLayoutPanel5.Controls.Add(panel_transferencia, 1, 0);
            tableLayoutPanel5.Controls.Add(panel_efectivo, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 47);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new Size(355, 95);
            tableLayoutPanel5.TabIndex = 91;
            // 
            // panel_tarjeta
            // 
            panel_tarjeta.BackColor = Color.Transparent;
            panel_tarjeta.Controls.Add(button_tarjeta);
            panel_tarjeta.Dock = DockStyle.Fill;
            panel_tarjeta.Location = new Point(239, 3);
            panel_tarjeta.Name = "panel_tarjeta";
            panel_tarjeta.Size = new Size(113, 89);
            panel_tarjeta.TabIndex = 94;
            // 
            // button_tarjeta
            // 
            button_tarjeta.BackColor = Color.FromArgb(52, 152, 219);
            button_tarjeta.Cursor = Cursors.Hand;
            button_tarjeta.FlatAppearance.BorderSize = 0;
            button_tarjeta.FlatStyle = FlatStyle.Flat;
            button_tarjeta.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_tarjeta.ForeColor = Color.White;
            button_tarjeta.Location = new Point(3, 3);
            button_tarjeta.Name = "button_tarjeta";
            button_tarjeta.Size = new Size(119, 63);
            button_tarjeta.TabIndex = 75;
            button_tarjeta.Text = "Tarjeta";
            button_tarjeta.UseVisualStyleBackColor = false;
            button_tarjeta.Click += button_tarjeta_Click;
            // 
            // panel_transferencia
            // 
            panel_transferencia.BackColor = Color.Transparent;
            panel_transferencia.Controls.Add(button_transferencia);
            panel_transferencia.Dock = DockStyle.Fill;
            panel_transferencia.Location = new Point(121, 3);
            panel_transferencia.Name = "panel_transferencia";
            panel_transferencia.Size = new Size(112, 89);
            panel_transferencia.TabIndex = 93;
            // 
            // button_transferencia
            // 
            button_transferencia.BackColor = Color.FromArgb(52, 152, 219);
            button_transferencia.Cursor = Cursors.Hand;
            button_transferencia.FlatAppearance.BorderSize = 0;
            button_transferencia.FlatStyle = FlatStyle.Flat;
            button_transferencia.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_transferencia.ForeColor = Color.White;
            button_transferencia.Location = new Point(3, 3);
            button_transferencia.Name = "button_transferencia";
            button_transferencia.Size = new Size(119, 63);
            button_transferencia.TabIndex = 73;
            button_transferencia.Text = "Transferencia";
            button_transferencia.UseVisualStyleBackColor = false;
            button_transferencia.Click += button_transferencia_Click;
            // 
            // panel_efectivo
            // 
            panel_efectivo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_efectivo.BackColor = Color.Transparent;
            panel_efectivo.Controls.Add(button_efectivo);
            panel_efectivo.Location = new Point(3, 3);
            panel_efectivo.Name = "panel_efectivo";
            panel_efectivo.Size = new Size(112, 89);
            panel_efectivo.TabIndex = 92;
            // 
            // button_efectivo
            // 
            button_efectivo.BackColor = Color.FromArgb(52, 152, 219);
            button_efectivo.Cursor = Cursors.Hand;
            button_efectivo.Enabled = false;
            button_efectivo.FlatAppearance.BorderSize = 0;
            button_efectivo.FlatStyle = FlatStyle.Flat;
            button_efectivo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_efectivo.ForeColor = Color.White;
            button_efectivo.Location = new Point(3, 2);
            button_efectivo.Name = "button_efectivo";
            button_efectivo.Size = new Size(119, 63);
            button_efectivo.TabIndex = 74;
            button_efectivo.Text = "Efectivo";
            button_efectivo.UseVisualStyleBackColor = false;
            button_efectivo.Click += button_efectivo_Click;
            // 
            // label_tipo_de_pago
            // 
            label_tipo_de_pago.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_tipo_de_pago.AutoSize = true;
            label_tipo_de_pago.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_tipo_de_pago.Location = new Point(3, 10);
            label_tipo_de_pago.Name = "label_tipo_de_pago";
            label_tipo_de_pago.Size = new Size(355, 23);
            label_tipo_de_pago.TabIndex = 66;
            label_tipo_de_pago.Text = "Tipo de pago:";
            label_tipo_de_pago.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_titulo_datos_placas
            // 
            label_titulo_datos_placas.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_datos_placas.AutoSize = true;
            label_titulo_datos_placas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_titulo_datos_placas.Location = new Point(3, 9);
            label_titulo_datos_placas.Name = "label_titulo_datos_placas";
            label_titulo_datos_placas.Size = new Size(361, 23);
            label_titulo_datos_placas.TabIndex = 94;
            label_titulo_datos_placas.Text = "Datos de la placa";
            label_titulo_datos_placas.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel_datos_placa
            // 
            tableLayoutPanel_datos_placa.ColumnCount = 2;
            tableLayoutPanel_datos_placa.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_datos_placa.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_datos_placa.Controls.Add(tableLayoutPanel8, 1, 0);
            tableLayoutPanel_datos_placa.Controls.Add(tableLayoutPanel7, 0, 0);
            tableLayoutPanel_datos_placa.Dock = DockStyle.Fill;
            tableLayoutPanel_datos_placa.Location = new Point(3, 44);
            tableLayoutPanel_datos_placa.Name = "tableLayoutPanel_datos_placa";
            tableLayoutPanel_datos_placa.RowCount = 1;
            tableLayoutPanel_datos_placa.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_datos_placa.Size = new Size(361, 122);
            tableLayoutPanel_datos_placa.TabIndex = 93;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 1;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel8.Controls.Add(label_valor_de_cambio, 0, 3);
            tableLayoutPanel8.Controls.Add(label_valor_cambio, 0, 2);
            tableLayoutPanel8.Controls.Add(label_valor_cobrar, 0, 0);
            tableLayoutPanel8.Controls.Add(label_valor_a_cobrar, 0, 1);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(183, 3);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 4;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel8.Size = new Size(175, 116);
            tableLayoutPanel8.TabIndex = 1;
            // 
            // label_valor_de_cambio
            // 
            label_valor_de_cambio.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_valor_de_cambio.AutoSize = true;
            label_valor_de_cambio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_valor_de_cambio.Location = new Point(3, 90);
            label_valor_de_cambio.Name = "label_valor_de_cambio";
            label_valor_de_cambio.Size = new Size(169, 23);
            label_valor_de_cambio.TabIndex = 92;
            label_valor_de_cambio.Text = "Valor cambio";
            // 
            // label_valor_cambio
            // 
            label_valor_cambio.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_valor_cambio.AutoSize = true;
            label_valor_cambio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_valor_cambio.Location = new Point(3, 61);
            label_valor_cambio.Name = "label_valor_cambio";
            label_valor_cambio.Size = new Size(169, 23);
            label_valor_cambio.TabIndex = 90;
            label_valor_cambio.Text = "Valor cambio:";
            // 
            // label_valor_cobrar
            // 
            label_valor_cobrar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_valor_cobrar.AutoSize = true;
            label_valor_cobrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_valor_cobrar.Location = new Point(3, 3);
            label_valor_cobrar.Name = "label_valor_cobrar";
            label_valor_cobrar.Size = new Size(169, 23);
            label_valor_cobrar.TabIndex = 58;
            label_valor_cobrar.Text = "Valor a cobrar:";
            // 
            // label_valor_a_cobrar
            // 
            label_valor_a_cobrar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_valor_a_cobrar.AutoSize = true;
            label_valor_a_cobrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_valor_a_cobrar.Location = new Point(3, 32);
            label_valor_a_cobrar.Name = "label_valor_a_cobrar";
            label_valor_a_cobrar.Size = new Size(169, 23);
            label_valor_a_cobrar.TabIndex = 89;
            label_valor_a_cobrar.Text = "Valor a cobrar";
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 1;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.Controls.Add(label_valor_tiempo, 0, 3);
            tableLayoutPanel7.Controls.Add(label_hora_estacionamiento, 0, 2);
            tableLayoutPanel7.Controls.Add(label_valor_hora_ingreso, 0, 1);
            tableLayoutPanel7.Controls.Add(label_hora_ingreso, 0, 0);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(3, 3);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 4;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel7.Size = new Size(174, 116);
            tableLayoutPanel7.TabIndex = 0;
            // 
            // label_valor_tiempo
            // 
            label_valor_tiempo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_valor_tiempo.AutoSize = true;
            label_valor_tiempo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_valor_tiempo.Location = new Point(3, 90);
            label_valor_tiempo.Name = "label_valor_tiempo";
            label_valor_tiempo.Size = new Size(168, 23);
            label_valor_tiempo.TabIndex = 90;
            label_valor_tiempo.Text = "Valor tiempo";
            // 
            // label_hora_estacionamiento
            // 
            label_hora_estacionamiento.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_hora_estacionamiento.AutoSize = true;
            label_hora_estacionamiento.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_hora_estacionamiento.Location = new Point(3, 61);
            label_hora_estacionamiento.Name = "label_hora_estacionamiento";
            label_hora_estacionamiento.Size = new Size(168, 23);
            label_hora_estacionamiento.TabIndex = 89;
            label_hora_estacionamiento.Text = "Tiempo:";
            // 
            // label_valor_hora_ingreso
            // 
            label_valor_hora_ingreso.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_valor_hora_ingreso.AutoSize = true;
            label_valor_hora_ingreso.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_valor_hora_ingreso.Location = new Point(3, 32);
            label_valor_hora_ingreso.Name = "label_valor_hora_ingreso";
            label_valor_hora_ingreso.Size = new Size(168, 23);
            label_valor_hora_ingreso.TabIndex = 88;
            label_valor_hora_ingreso.Text = "Hora Ingreso";
            // 
            // label_hora_ingreso
            // 
            label_hora_ingreso.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_hora_ingreso.AutoSize = true;
            label_hora_ingreso.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_hora_ingreso.Location = new Point(3, 3);
            label_hora_ingreso.Name = "label_hora_ingreso";
            label_hora_ingreso.Size = new Size(168, 23);
            label_hora_ingreso.TabIndex = 75;
            label_hora_ingreso.Text = "Hora de ingreso:";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(panel_verificar_monto, 0, 1);
            tableLayoutPanel3.Controls.Add(panel2, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 323);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 28.75F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 71.25F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(361, 160);
            tableLayoutPanel3.TabIndex = 96;
            // 
            // panel_verificar_monto
            // 
            panel_verificar_monto.Controls.Add(button_verificar_monto);
            panel_verificar_monto.Dock = DockStyle.Fill;
            panel_verificar_monto.Location = new Point(3, 49);
            panel_verificar_monto.Name = "panel_verificar_monto";
            panel_verificar_monto.Size = new Size(355, 108);
            panel_verificar_monto.TabIndex = 90;
            // 
            // button_verificar_monto
            // 
            button_verificar_monto.BackColor = Color.FromArgb(52, 152, 219);
            button_verificar_monto.Cursor = Cursors.Hand;
            button_verificar_monto.Enabled = false;
            button_verificar_monto.FlatAppearance.BorderSize = 0;
            button_verificar_monto.FlatStyle = FlatStyle.Flat;
            button_verificar_monto.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_verificar_monto.ForeColor = Color.White;
            button_verificar_monto.Location = new Point(85, 34);
            button_verificar_monto.Name = "button_verificar_monto";
            button_verificar_monto.Size = new Size(176, 40);
            button_verificar_monto.TabIndex = 73;
            button_verificar_monto.Text = "Verificar monto";
            button_verificar_monto.UseVisualStyleBackColor = false;
            button_verificar_monto.Click += textBox_valor_entregado_Leave;
            // 
            // panel2
            // 
            panel2.Controls.Add(textBox_valor_entregado);
            panel2.Controls.Add(label_valor_entregado);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(355, 40);
            panel2.TabIndex = 89;
            // 
            // textBox_valor_entregado
            // 
            textBox_valor_entregado.Anchor = AnchorStyles.Bottom;
            textBox_valor_entregado.Location = new Point(155, 9);
            textBox_valor_entregado.Name = "textBox_valor_entregado";
            textBox_valor_entregado.Size = new Size(197, 27);
            textBox_valor_entregado.TabIndex = 87;
            textBox_valor_entregado.Leave += textBox_valor_entregado_Leave;
            // 
            // label_valor_entregado
            // 
            label_valor_entregado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label_valor_entregado.AutoSize = true;
            label_valor_entregado.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_valor_entregado.Location = new Point(5, 10);
            label_valor_entregado.Name = "label_valor_entregado";
            label_valor_entregado.Size = new Size(144, 23);
            label_valor_entregado.TabIndex = 87;
            label_valor_entregado.Text = "Valor entregado:";
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 1;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Controls.Add(tableLayoutPanel10, 0, 1);
            tableLayoutPanel6.Controls.Add(tableLayoutPanel9, 0, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(786, 3);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 2;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 26.7489719F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 73.25103F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel6.Size = new Size(367, 486);
            tableLayoutPanel6.TabIndex = 1;
            // 
            // tableLayoutPanel10
            // 
            tableLayoutPanel10.ColumnCount = 1;
            tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel10.Controls.Add(panel_controls_placas, 0, 1);
            tableLayoutPanel10.Controls.Add(panel_image_placa, 0, 0);
            tableLayoutPanel10.Dock = DockStyle.Fill;
            tableLayoutPanel10.Location = new Point(3, 133);
            tableLayoutPanel10.Name = "tableLayoutPanel10";
            tableLayoutPanel10.RowCount = 2;
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Absolute, 161F));
            tableLayoutPanel10.Size = new Size(361, 350);
            tableLayoutPanel10.TabIndex = 119;
            // 
            // panel_controls_placas
            // 
            panel_controls_placas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_controls_placas.BackColor = Color.Transparent;
            panel_controls_placas.Controls.Add(button_buscar_placa);
            panel_controls_placas.Location = new Point(3, 192);
            panel_controls_placas.Name = "panel_controls_placas";
            panel_controls_placas.Size = new Size(355, 155);
            panel_controls_placas.TabIndex = 90;
            // 
            // button_buscar_placa
            // 
            button_buscar_placa.BackColor = Color.FromArgb(52, 152, 219);
            button_buscar_placa.Cursor = Cursors.Hand;
            button_buscar_placa.FlatAppearance.BorderSize = 0;
            button_buscar_placa.FlatStyle = FlatStyle.Flat;
            button_buscar_placa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_buscar_placa.ForeColor = Color.White;
            button_buscar_placa.Location = new Point(107, 47);
            button_buscar_placa.Name = "button_buscar_placa";
            button_buscar_placa.Size = new Size(146, 40);
            button_buscar_placa.TabIndex = 55;
            button_buscar_placa.Text = "Buscar";
            button_buscar_placa.UseVisualStyleBackColor = false;
            button_buscar_placa.Click += button_buscar_placa_Click;
            // 
            // panel_image_placa
            // 
            panel_image_placa.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_image_placa.BackColor = Color.Transparent;
            panel_image_placa.Controls.Add(pictureBox_image_placa);
            panel_image_placa.Location = new Point(3, 3);
            panel_image_placa.Name = "panel_image_placa";
            panel_image_placa.Size = new Size(355, 183);
            panel_image_placa.TabIndex = 89;
            // 
            // pictureBox_image_placa
            // 
            pictureBox_image_placa.Image = Properties.Resources.Logotipo_color;
            pictureBox_image_placa.Location = new Point(1, 3);
            pictureBox_image_placa.Name = "pictureBox_image_placa";
            pictureBox_image_placa.Size = new Size(354, 122);
            pictureBox_image_placa.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_image_placa.TabIndex = 66;
            pictureBox_image_placa.TabStop = false;
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.ColumnCount = 1;
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel9.Controls.Add(textBox_buscar_placa, 0, 1);
            tableLayoutPanel9.Controls.Add(label_placa, 0, 0);
            tableLayoutPanel9.Dock = DockStyle.Fill;
            tableLayoutPanel9.Location = new Point(3, 3);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 2;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 32.2580643F));
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 67.7419357F));
            tableLayoutPanel9.Size = new Size(361, 124);
            tableLayoutPanel9.TabIndex = 118;
            // 
            // textBox_buscar_placa
            // 
            textBox_buscar_placa.Anchor = AnchorStyles.None;
            textBox_buscar_placa.Location = new Point(84, 68);
            textBox_buscar_placa.Name = "textBox_buscar_placa";
            textBox_buscar_placa.Size = new Size(193, 27);
            textBox_buscar_placa.TabIndex = 57;
            // 
            // label_placa
            // 
            label_placa.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_placa.AutoSize = true;
            label_placa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_placa.Location = new Point(3, 8);
            label_placa.Name = "label_placa";
            label_placa.Size = new Size(355, 23);
            label_placa.TabIndex = 58;
            label_placa.Text = "Digitar la placa:";
            label_placa.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel11
            // 
            tableLayoutPanel11.ColumnCount = 1;
            tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel11.Controls.Add(panel_buscar_usuarios, 0, 2);
            tableLayoutPanel11.Controls.Add(panel_con_datos, 0, 1);
            tableLayoutPanel11.Controls.Add(panel_consumidor_final, 0, 0);
            tableLayoutPanel11.Dock = DockStyle.Fill;
            tableLayoutPanel11.Location = new Point(40, 3);
            tableLayoutPanel11.Name = "tableLayoutPanel11";
            tableLayoutPanel11.RowCount = 3;
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 36.7418175F));
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 36.41975F));
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 26.8384323F));
            tableLayoutPanel11.Size = new Size(367, 486);
            tableLayoutPanel11.TabIndex = 2;
            // 
            // panel_buscar_usuarios
            // 
            panel_buscar_usuarios.BackColor = Color.Transparent;
            panel_buscar_usuarios.Controls.Add(button_agregar_user);
            panel_buscar_usuarios.Dock = DockStyle.Fill;
            panel_buscar_usuarios.Location = new Point(3, 357);
            panel_buscar_usuarios.Name = "panel_buscar_usuarios";
            panel_buscar_usuarios.Size = new Size(361, 126);
            panel_buscar_usuarios.TabIndex = 96;
            // 
            // button_agregar_user
            // 
            button_agregar_user.BackColor = Color.FromArgb(52, 152, 219);
            button_agregar_user.Cursor = Cursors.Hand;
            button_agregar_user.FlatAppearance.BorderSize = 0;
            button_agregar_user.FlatStyle = FlatStyle.Flat;
            button_agregar_user.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_agregar_user.ForeColor = Color.White;
            button_agregar_user.Location = new Point(92, 47);
            button_agregar_user.Name = "button_agregar_user";
            button_agregar_user.Size = new Size(176, 40);
            button_agregar_user.TabIndex = 73;
            button_agregar_user.Text = "Agregar";
            button_agregar_user.UseVisualStyleBackColor = false;
            button_agregar_user.Click += button_buscar_user_Click;
            // 
            // panel_con_datos
            // 
            panel_con_datos.BackColor = Color.Transparent;
            panel_con_datos.Controls.Add(tableLayoutPanel_usuario_encontrado);
            panel_con_datos.Controls.Add(button_con_datos);
            panel_con_datos.Dock = DockStyle.Fill;
            panel_con_datos.Location = new Point(3, 181);
            panel_con_datos.Name = "panel_con_datos";
            panel_con_datos.Size = new Size(361, 170);
            panel_con_datos.TabIndex = 95;
            // 
            // tableLayoutPanel_usuario_encontrado
            // 
            tableLayoutPanel_usuario_encontrado.ColumnCount = 1;
            tableLayoutPanel_usuario_encontrado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_usuario_encontrado.Controls.Add(label_nombre, 0, 0);
            tableLayoutPanel_usuario_encontrado.Controls.Add(label_telefono, 0, 3);
            tableLayoutPanel_usuario_encontrado.Controls.Add(label_cedula, 0, 1);
            tableLayoutPanel_usuario_encontrado.Controls.Add(label_correo, 0, 2);
            tableLayoutPanel_usuario_encontrado.Dock = DockStyle.Fill;
            tableLayoutPanel_usuario_encontrado.Location = new Point(0, 0);
            tableLayoutPanel_usuario_encontrado.Name = "tableLayoutPanel_usuario_encontrado";
            tableLayoutPanel_usuario_encontrado.RowCount = 4;
            tableLayoutPanel_usuario_encontrado.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_usuario_encontrado.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_usuario_encontrado.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_usuario_encontrado.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_usuario_encontrado.Size = new Size(361, 170);
            tableLayoutPanel_usuario_encontrado.TabIndex = 82;
            tableLayoutPanel_usuario_encontrado.Visible = false;
            // 
            // label_nombre
            // 
            label_nombre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_nombre.AutoSize = true;
            label_nombre.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_nombre.Location = new Point(3, 9);
            label_nombre.Name = "label_nombre";
            label_nombre.Size = new Size(355, 23);
            label_nombre.TabIndex = 76;
            label_nombre.Text = "Nombre";
            // 
            // label_telefono
            // 
            label_telefono.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_telefono.AutoSize = true;
            label_telefono.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_telefono.Location = new Point(3, 136);
            label_telefono.Name = "label_telefono";
            label_telefono.Size = new Size(355, 23);
            label_telefono.TabIndex = 79;
            label_telefono.Text = "telefono";
            // 
            // label_cedula
            // 
            label_cedula.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_cedula.AutoSize = true;
            label_cedula.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_cedula.Location = new Point(3, 51);
            label_cedula.Name = "label_cedula";
            label_cedula.Size = new Size(355, 23);
            label_cedula.TabIndex = 77;
            label_cedula.Text = "cedula";
            // 
            // label_correo
            // 
            label_correo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_correo.AutoSize = true;
            label_correo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_correo.Location = new Point(3, 93);
            label_correo.Name = "label_correo";
            label_correo.Size = new Size(355, 23);
            label_correo.TabIndex = 78;
            label_correo.Text = "correo";
            // 
            // button_con_datos
            // 
            button_con_datos.BackColor = Color.FromArgb(52, 152, 219);
            button_con_datos.Cursor = Cursors.Hand;
            button_con_datos.FlatAppearance.BorderSize = 0;
            button_con_datos.FlatStyle = FlatStyle.Flat;
            button_con_datos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_con_datos.ForeColor = Color.White;
            button_con_datos.Location = new Point(100, 45);
            button_con_datos.Name = "button_con_datos";
            button_con_datos.Size = new Size(146, 40);
            button_con_datos.TabIndex = 55;
            button_con_datos.Text = "Con Datos";
            button_con_datos.UseVisualStyleBackColor = false;
            button_con_datos.Click += button_con_datos_Click;
            // 
            // panel_consumidor_final
            // 
            panel_consumidor_final.BackColor = Color.Transparent;
            panel_consumidor_final.Controls.Add(tableLayoutPanel_buscar_user);
            panel_consumidor_final.Controls.Add(button_consumidor_final);
            panel_consumidor_final.Dock = DockStyle.Fill;
            panel_consumidor_final.Location = new Point(3, 3);
            panel_consumidor_final.Name = "panel_consumidor_final";
            panel_consumidor_final.Size = new Size(361, 172);
            panel_consumidor_final.TabIndex = 94;
            // 
            // tableLayoutPanel_buscar_user
            // 
            tableLayoutPanel_buscar_user.ColumnCount = 1;
            tableLayoutPanel_buscar_user.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_buscar_user.Controls.Add(panel_control_boton_busqueda, 0, 2);
            tableLayoutPanel_buscar_user.Controls.Add(label_titulo_usuario, 0, 0);
            tableLayoutPanel_buscar_user.Controls.Add(textBox_usuario_encontrar, 0, 1);
            tableLayoutPanel_buscar_user.Dock = DockStyle.Fill;
            tableLayoutPanel_buscar_user.Location = new Point(0, 0);
            tableLayoutPanel_buscar_user.Name = "tableLayoutPanel_buscar_user";
            tableLayoutPanel_buscar_user.RowCount = 3;
            tableLayoutPanel_buscar_user.RowStyles.Add(new RowStyle(SizeType.Percent, 40.19608F));
            tableLayoutPanel_buscar_user.RowStyles.Add(new RowStyle(SizeType.Percent, 59.80392F));
            tableLayoutPanel_buscar_user.RowStyles.Add(new RowStyle(SizeType.Absolute, 92F));
            tableLayoutPanel_buscar_user.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_buscar_user.Size = new Size(361, 172);
            tableLayoutPanel_buscar_user.TabIndex = 98;
            tableLayoutPanel_buscar_user.Visible = false;
            // 
            // panel_control_boton_busqueda
            // 
            panel_control_boton_busqueda.BackColor = Color.Transparent;
            panel_control_boton_busqueda.Controls.Add(button_buscar_usuario);
            panel_control_boton_busqueda.Dock = DockStyle.Fill;
            panel_control_boton_busqueda.Location = new Point(3, 82);
            panel_control_boton_busqueda.Name = "panel_control_boton_busqueda";
            panel_control_boton_busqueda.Size = new Size(355, 87);
            panel_control_boton_busqueda.TabIndex = 82;
            // 
            // button_buscar_usuario
            // 
            button_buscar_usuario.BackColor = Color.FromArgb(52, 152, 219);
            button_buscar_usuario.Cursor = Cursors.Hand;
            button_buscar_usuario.FlatAppearance.BorderSize = 0;
            button_buscar_usuario.FlatStyle = FlatStyle.Flat;
            button_buscar_usuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_buscar_usuario.ForeColor = Color.White;
            button_buscar_usuario.Location = new Point(97, 18);
            button_buscar_usuario.Name = "button_buscar_usuario";
            button_buscar_usuario.Size = new Size(179, 40);
            button_buscar_usuario.TabIndex = 74;
            button_buscar_usuario.Text = "Buscar";
            button_buscar_usuario.UseVisualStyleBackColor = false;
            button_buscar_usuario.Click += button_buscar_usuario_Click;
            // 
            // label_titulo_usuario
            // 
            label_titulo_usuario.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_usuario.AutoSize = true;
            label_titulo_usuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_titulo_usuario.Location = new Point(3, 4);
            label_titulo_usuario.Name = "label_titulo_usuario";
            label_titulo_usuario.Size = new Size(355, 23);
            label_titulo_usuario.TabIndex = 60;
            label_titulo_usuario.Text = "Ingrese la cédula";
            label_titulo_usuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox_usuario_encontrar
            // 
            textBox_usuario_encontrar.Anchor = AnchorStyles.None;
            textBox_usuario_encontrar.Location = new Point(80, 42);
            textBox_usuario_encontrar.Name = "textBox_usuario_encontrar";
            textBox_usuario_encontrar.Size = new Size(201, 27);
            textBox_usuario_encontrar.TabIndex = 61;
            // 
            // button_consumidor_final
            // 
            button_consumidor_final.BackColor = Color.FromArgb(52, 152, 219);
            button_consumidor_final.Cursor = Cursors.Hand;
            button_consumidor_final.FlatAppearance.BorderSize = 0;
            button_consumidor_final.FlatStyle = FlatStyle.Flat;
            button_consumidor_final.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_consumidor_final.ForeColor = Color.White;
            button_consumidor_final.Location = new Point(100, 77);
            button_consumidor_final.Name = "button_consumidor_final";
            button_consumidor_final.Size = new Size(146, 40);
            button_consumidor_final.TabIndex = 55;
            button_consumidor_final.Text = "Consumidor Final";
            button_consumidor_final.UseVisualStyleBackColor = false;
            button_consumidor_final.Click += button_consumidor_final_Click;
            // 
            // TransaccionesCajaForm
            // 
            ClientSize = new Size(1194, 746);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tableLayoutPanel_footer);
            Controls.Add(tableLayoutPanel_logueado);
            Name = "TransaccionesCajaForm";
            Load += TransaccionesCajaForm_Load;
            tableLayoutPanel_logueado.ResumeLayout(false);
            tableLayoutPanel_logueado.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel_footer.ResumeLayout(false);
            panel_col_cancelar.ResumeLayout(false);
            panel_col_cobrar.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            panel_tarjeta.ResumeLayout(false);
            panel_transferencia.ResumeLayout(false);
            panel_efectivo.ResumeLayout(false);
            tableLayoutPanel_datos_placa.ResumeLayout(false);
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            panel_verificar_monto.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel10.ResumeLayout(false);
            panel_controls_placas.ResumeLayout(false);
            panel_image_placa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_image_placa).EndInit();
            tableLayoutPanel9.ResumeLayout(false);
            tableLayoutPanel9.PerformLayout();
            tableLayoutPanel11.ResumeLayout(false);
            panel_buscar_usuarios.ResumeLayout(false);
            panel_con_datos.ResumeLayout(false);
            tableLayoutPanel_usuario_encontrado.ResumeLayout(false);
            tableLayoutPanel_usuario_encontrado.PerformLayout();
            panel_consumidor_final.ResumeLayout(false);
            tableLayoutPanel_buscar_user.ResumeLayout(false);
            tableLayoutPanel_buscar_user.PerformLayout();
            panel_control_boton_busqueda.ResumeLayout(false);
            ResumeLayout(false);

        }
        private Label label_titulo_transacciones;
        private FontAwesome.Sharp.IconButton iconButton_regresar;

        private void iconButton_regresar_Click(object sender, EventArgs e)
        {
            var MenuPrincipalForm = new MenuPrincipalForm();
            this.Hide();                 // Opcional: ocultas la ventana actual
            MenuPrincipalForm.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
            this.Close();
        }

        private async void button_buscar_placa_Click(object sender, EventArgs e)
        {
            try
            {
                string placa = textBox_buscar_placa.Text.Trim();

                if (placa == "")
                {
                    StylesAlertas.MostrarAlerta(this, "No hay ningun campo en la placa", "¡Error!", TipoAlerta.Error);
                    return;
                }
                var persona = _PersonaController.ObtenerPorId(SessionUser.PerId);

                if (persona != null)
                {
                    // Esperar el resultado del login
                    string loginResponse = await _apiService.LoginAsync(persona.correo, persona.password);

                    if (!string.IsNullOrEmpty(loginResponse) && !loginResponse.StartsWith("Error") && !loginResponse.StartsWith("Excepción"))
                    {
                        // Aquí normalmente viene un JSON con el token
                        // Ejemplo: { "token": "eyJhbGciOi..." }
                        var obj = JsonConvert.DeserializeObject<dynamic>(loginResponse);
                        string token = obj?.token;


                        if (!string.IsNullOrEmpty(token))
                        {
                            // ✅ Ya tienes el token. Ahora puedes usarlo para otra operación
                            string respuesta = await _apiService.VerificarPlacaAsync(placa, token);

                            var objRespuesta = JsonConvert.DeserializeObject<dynamic>(respuesta);


                            if (objRespuesta.code != null)
                            {
                                string codigo = objRespuesta.code;
                                string mensaje = objRespuesta.msg;

                                // Si el código no es "0" (éxito), hay un error
                                if (codigo == "0")
                                {
                                    StylesAlertas.MostrarAlerta(this, "No hay respuesta del servidor", "¡Error!", TipoAlerta.Error);


                                    _funcionesGenerales.LimpiarCampos(this);

                                    return; // Salir del método
                                }
                                if (codigo == "128")
                                {
                                    StylesAlertas.MostrarAlerta(this, "No existe el vehiculo", "¡Error!", TipoAlerta.Error);


                                    _funcionesGenerales.LimpiarCampos(this);

                                    return; // Salir del método
                                }
                            }

                            if (objRespuesta?.traducido != null)
                            {
                                // Acceder correctamente a las propiedades (sin .Artemis)
                                string placaActual = objRespuesta.traducido.Placa;
                                string HoraIngreso = objRespuesta.traducido.HoraIngreso;
                                string TiempoEstacionamiento = objRespuesta.traducido.TiempoEstacionado;
                                string TipoRegla = objRespuesta.traducido.TipoRegla;
                                string NombreRegla = objRespuesta.traducido.NombreRegla;
                                string MontoPagar = objRespuesta.traducido.MontoAPagar;

                                if (MontoPagar == "0.00")
                                {
                                    label_valor_hora_ingreso.Text = "⏰" + HoraIngreso;
                                    label_valor_tiempo.Text = "⌛" + TiempoEstacionamiento;
                                    label_valor_a_cobrar.Text = "💰 " + MontoPagar;
                                    button_realizar_transaccion.Enabled = false;
                                    textBox_valor_entregado.Enabled = false;

                                }
                                else
                                {
                                    label_valor_hora_ingreso.Text = "⏰" + HoraIngreso;
                                    label_valor_tiempo.Text = "⌛" + TiempoEstacionamiento;
                                    label_valor_a_cobrar.Text = "💰 " + MontoPagar;
                                    button_realizar_transaccion.Enabled = true;
                                    textBox_valor_entregado.Enabled = true;

                                }

                                // Asignar a los TextBox

                                StylesAlertas.MostrarAlerta(this, "Datos cargados correctamente", tipo: TipoAlerta.Success);
                            }
                            else
                            {
                                StylesAlertas.MostrarAlerta(this, "La respuesta no contiene la estructura esperada", "¡Error!", TipoAlerta.Error);
                            }



                            //string montoPagar = objRespuesta.Artemis.traducido.Placa;

                        }
                        else
                        {
                            StylesAlertas.MostrarAlerta(this, "No se pudo obtener el token del login.", "¡Error!", TipoAlerta.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error en login: " + loginResponse);
                    }
                }
                else
                {
                    StylesAlertas.MostrarAlerta(this, "No hay un usuario logueado.", "¡Error!", TipoAlerta.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en apertura de caja: " + ex.Message);
            }
        }

        private async void button_realizar_transaccion_Click(object sender, EventArgs e)
        {
            string valorEntregadoEncerado = textBox_valor_entregado.Text.Trim();
            string valorCambioEncerado = label_valor_a_cobrar.Text.Trim();

            if (valorEntregadoEncerado == "" || valorCambioEncerado == "")
            {
                StylesAlertas.MostrarAlerta(this, "Agregar un valor entregado por el usuario", "¡Error!", TipoAlerta.Error);
                return;
            }
            string texto = label_valor_de_cambio.Text.Replace("💰", "").Trim();
            decimal valorEntregado = _funcionesGenerales.ParseDecimalFromTextBoxNormalizado(textBox_valor_entregado.Text);
            decimal valorCambio = _funcionesGenerales.ParseDecimalFromTextBoxNormalizado(texto);

            if (id_usuario == 0 || label_nombre.Text.Trim() == "")
            {
                StylesAlertas.MostrarAlerta(this, "Seleccionar un usuario", "¡Error!", TipoAlerta.Error);
                return;
            }
            // Validar que los valores sean mayores o iguales a cero (opcional)
            if (valorEntregado >= 0 && valorCambio >= 0)
            {
                string descripcion = "Generado desde la aplicacion de escritorio";
                int id_arqueo_caja = SessionArqueoCaja.id_arqueo_caja;

                string valor_cobrar = label_valor_a_cobrar.Text.Replace("💰", "").Trim();
                decimal valor_a_cobrar = _funcionesGenerales.ParseDecimalFromTextBoxNormalizado(valor_cobrar);

                
                string placa = textBox_buscar_placa.Text.Trim();

                var transaccionCaja = new TransaccionCajaM
                {
                    arqueo_id = id_arqueo_caja,
                    per_id_cliente = id_usuario,
                    fecha_transaccion = DateTime.Now,
                    valor_a_cobrar = valor_a_cobrar,
                    valor_entregado = valorEntregado,
                    tipo_pago_id = sacarTipoPago(),
                    descripcion = descripcion,
                    placa = placa
                };

                var persona = _PersonaController.ObtenerPorId(SessionUser.PerId);

                if (persona != null)
                {
                    // Esperar el resultado del login
                    string loginResponse = await _apiService.LoginAsync(persona.correo, persona.password);

                    if (!string.IsNullOrEmpty(loginResponse) && !loginResponse.StartsWith("Error") && !loginResponse.StartsWith("Excepción"))
                    {
                        // Aquí normalmente viene un JSON con el token
                        // Ejemplo: { "token": "eyJhbGciOi..." }
                        var obj = JsonConvert.DeserializeObject<dynamic>(loginResponse);
                        string token = obj?.token;


                        if (!string.IsNullOrEmpty(token))
                        {
                            string PagoResponse = await _apiService.PagarPlacaAsync(placa, valorEntregado, token);

                            var objPago = JsonConvert.DeserializeObject<dynamic>(PagoResponse);

                            if (objPago.code != null)
                            {
                                string codigo = objPago.code;
                                string mensaje = objPago.msg;

                                // Si el código no es "0" (éxito), hay un error
                                if (codigo != "0")
                                {
                                    StylesAlertas.MostrarAlerta(this, "No existe ningun vehiculo con esos datos", "¡Error!", TipoAlerta.Error);

                                    _funcionesGenerales.LimpiarCampos(this);

                                    return; // Salir del método
                                }
                            }
                            //inserta en la bdd
                            //_TransaccionCajaController.Insertar(transaccionCaja);
                            //insertar en el olimpo

                            string Transaccion = await _apiService.CrearTransaccionCajaAsync(transaccionCaja,token);

                            if (Transaccion.StartsWith("Error") || Transaccion.StartsWith("Excepción"))
                            {
                                //MessageBox.Show("❌ No se pudo registrar la transacción: " + Transaccion,
                                 //               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                StylesAlertas.MostrarAlerta(this, "No se pudo completar la transacción", "¡Error!", TipoAlerta.Error);
                            }
                            else
                            {
                                // Si tu API devuelve la transacción creada en JSON
                                var objTransaccion = JsonConvert.DeserializeObject<TransaccionCajaM>(Transaccion);
                               // MessageBox.Show("✅ Transacción registrada con ID: " + objTransaccion.arqueo_id,
                               //                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                StylesAlertas.MostrarAlerta(this, "Transacción realizada correctamente ID:"+ objTransaccion.arqueo_id, tipo: TipoAlerta.Success);


                                if (tipo_factura == 1)
                                {
                                    MostrarPdf.GenerarPDFConsumidorFinal();
                                }
                                else {
                                    SessionFactura.Cantidad = 1;
                                    SessionFactura.PrecioUnitario = valor_a_cobrar;
                                    MostrarPdf.GenerarPDFFactura();

                                }
                            }


                            _funcionesGenerales.LimpiarCampos(this);

                            label_valor_hora_ingreso.Text = "";
                            label_valor_tiempo.Text = "";
                            label_valor_a_cobrar.Text = "";
                            label_valor_de_cambio.Text = "";

                            label_nombre.Text = "";
                            label_correo.Text = "";
                            label_cedula.Text = "";
                            label_telefono.Text = "";


                        }
                        else
                        {
                            StylesAlertas.MostrarAlerta(this, "No se pudo obtener el token del login.", "Aviso", TipoAlerta.Info);
                        }

                    }
                }

            }
            else
            {
                StylesAlertas.MostrarAlerta(this, "Por favor ingrese un número válido.", "Aviso", TipoAlerta.Info);
            }
        }

        private void button_cancelar_transaccion_Click(object sender, EventArgs e)
        {
            _funcionesGenerales.LimpiarCampos(this);
        }

        private void TransaccionesCajaForm_Load(object sender, EventArgs e)
        {
            foreach (var tb in new[] { textBox_valor_entregado })
            {
                tb.KeyPress += _funcionesGenerales.SoloNumerosDecimal_KeyPress;
            }
        }

        private void textBox_valor_entregado_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_valor_entregado.Text))
            {
                label_valor_de_cambio.Text = "0.00";
                return;
            }

            // Configurar cultura para usar punto como separador decimal
            CultureInfo cultura = CultureInfo.InvariantCulture;

            // Procesar valor entregado
            string textoEntregado = textBox_valor_entregado.Text.Trim();
            decimal valorEntregado;

            // Intentar parsear el valor entregado
            if (!decimal.TryParse(textoEntregado, NumberStyles.Number, cultura, out valorEntregado))
            {
                MessageBox.Show("Por favor ingrese un número válido en valor entregado.",
                               "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                label_valor_de_cambio.Text = "0.00";
                button_realizar_transaccion.Enabled = false;

                return;
            }

            // Procesar valor a cobrar
            string texto = label_valor_a_cobrar.Text.Replace("💰", "").Trim();
            string textoCobrar = texto;

            // Quitar símbolos de moneda y espacios
            textoCobrar = textoCobrar.Replace("$", "")
                                    .Replace("USD", "")
                                    .Replace("€", "")
                                    .Replace("£", "")
                                    .Trim();

            decimal valorCobrar;

            // Intentar parsear el valor a cobrar
            if (!decimal.TryParse(textoCobrar, NumberStyles.Number, cultura, out valorCobrar))
            {
                MessageBox.Show("El valor a cobrar no es válido.",
                               "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                label_valor_de_cambio.Text = "0.00";
                button_realizar_transaccion.Enabled = false;

                return;
            }

            // Calcular el cambio
            decimal valorCambio = valorEntregado - valorCobrar;

            // Validar que el valor entregado sea suficiente
            if (valorCambio < 0)
            {
                MessageBox.Show($"El valor entregado (${valorEntregado:0.00}) no puede ser menor al valor a cobrar (${valorCobrar:0.00}).",
                               "Valor insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                label_valor_de_cambio.Text = "0.00";
                button_realizar_transaccion.Enabled = false;
                return;
            }

            // Mostrar el resultado con formato de moneda
            label_valor_de_cambio.Text = "💰" + valorCambio.ToString("0.00", cultura);
            button_realizar_transaccion.Enabled = true;
        }


        async private void button_buscar_usuario_Click(object sender, EventArgs e)
        {
            string cedula = textBox_usuario_encontrar.Text.Trim();

            if (cedula == "")
            {
                StylesAlertas.MostrarAlerta(this, "Ingrese el CI/RUC del usuario", "¡Error!", TipoAlerta.Error);
                return;
            }
            else
            {


                var persona = _PersonaController.ObtenerPorId(SessionUser.PerId);

                if (persona != null)
                {
                    // Esperar el resultado del login
                    string loginResponse = await _apiService.LoginAsync(persona.correo, persona.password);

                    if (!string.IsNullOrEmpty(loginResponse) && !loginResponse.StartsWith("Error") && !loginResponse.StartsWith("Excepción"))
                    {
                        // Aquí normalmente viene un JSON con el token
                        // Ejemplo: { "token": "eyJhbGciOi..." }
                        var obj = JsonConvert.DeserializeObject<dynamic>(loginResponse);
                        string token = obj?.token;


                        if (!string.IsNullOrEmpty(token))
                        {
                            // ✅ Ya tienes el token. Ahora puedes usarlo para otra operación
                            string respuesta = await _apiService.GetPersonaPorCedulaAsync(cedula, token);
                            if (respuesta.Contains("\"status\":404") || respuesta.Contains("\"title\":\"Not Found\""))
                            {
                                StylesAlertas.MostrarAlerta(this, "No se encontro el usuario", "¡Error!", TipoAlerta.Error);
                                return;
                            }
                            var objRespuesta = JsonConvert.DeserializeObject<dynamic>(respuesta);

                            if (objRespuesta != null)
                            {
                                label_nombre.Text = "👤 Nombre: " + objRespuesta.nombre_completo;
                                label_correo.Text = "📧 Correo: " + objRespuesta.correo;
                                label_cedula.Text = "🆔 Cédula: " + objRespuesta.cedula;
                                label_telefono.Text = "📞 Teléfono: " + objRespuesta.telefono_1;
                                id_usuario = objRespuesta.per_id;

                                SessionFactura.ClienteNombre = objRespuesta.nombre_completo;
                                SessionFactura.ClienteRuc = objRespuesta.cedula;
                                SessionFactura.Producto = "Pago parqueadero";

                               StylesAlertas.MostrarAlerta(this, "Datos cargados correctamente", tipo: TipoAlerta.Success);
                            }

                        }
                    }

                }



            }
        }

        private void button_consumidor_final_Click(object sender, EventArgs e)
        {

            tableLayoutPanel_buscar_user.Visible = true;
            tableLayoutPanel_usuario_encontrado.Visible = true;

            tipo_factura = 1;

        }

        private void button_con_datos_Click(object sender, EventArgs e)
        {

            tableLayoutPanel_buscar_user.Visible = true;
            tableLayoutPanel_usuario_encontrado.Visible = true;

            tipo_factura = 2;

        }


        private void textBox_usuario_encontrar_Click(object sender, EventArgs e)
        {
            TecladoDesplegable.MostrarTeclado(this, textBox_usuario_encontrar, TipoTeclado.Numerico, button_buscar_usuario);
        }

        private void textBox_buscar_placa_Click(object sender, EventArgs e)
        {
            TecladoDesplegable.MostrarTeclado(this, textBox_buscar_placa, TipoTeclado.Numerico, button_buscar_placa);
        }

        private void button_buscar_user_Click(object sender, EventArgs e)
        {
            var UsuarioForm = new UsuarioForm();
            UsuarioForm.StartPosition = FormStartPosition.CenterParent;
            UsuarioForm.FormClosed += (s, args) =>
            {
            };
            var result = UsuarioForm.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                var personaUltima = _PersonaController.ObtenerUltima();
                if (personaUltima != null)
                {
                    label_nombre.Text = personaUltima.primer_nombre + " " + personaUltima.primer_apellido;
                    label_nombre.Text = "👤 Nombre: " + personaUltima.primer_nombre + " " + personaUltima.primer_apellido;
                    label_correo.Text = "📧 Correo: " + personaUltima.correo;
                    label_cedula.Text = "🆔 Cédula: " + personaUltima.cedula;
                    label_telefono.Text = "📞 Teléfono: " + personaUltima.telefono_1;
                    id_usuario = personaUltima.per_id;
                    textBox_usuario_encontrar.Text = personaUltima.cedula;
                }
                else
                {
                    StylesAlertas.MostrarAlerta(this, "No se pudo sacar los datos", "¡Error!", TipoAlerta.Error);
                }

            }
        }

        private void textBox_valor_entregado_Click(object sender, EventArgs e)
        {
            TecladoDesplegable.MostrarTeclado(this, textBox_valor_entregado, TipoTeclado.Numerico, soloNumerico: true);
        }

        private void button_efectivo_Click(object sender, EventArgs e)
        {
            button_efectivo.Enabled = false;
            button_tarjeta.Enabled = true;
            button_transferencia.Enabled = true;
        }

        private void button_tarjeta_Click(object sender, EventArgs e)
        {
            button_efectivo.Enabled = true;
            button_tarjeta.Enabled = false;
            button_transferencia.Enabled = true;
        }

        private void button_transferencia_Click(object sender, EventArgs e)
        {
            button_efectivo.Enabled = true;
            button_tarjeta.Enabled = true;
            button_transferencia.Enabled = false;
        }

        private int sacarTipoPago() {

            int valor = 0;

            if (button_tarjeta.Enabled == false)
            {
                return valor = 3;
            }
            else if (button_transferencia.Enabled == false)
            {
                return valor = 2;
            }
            else if (button_efectivo.Enabled == false) {
                return valor = 1;
            }

                return valor;
        }
    }
}
