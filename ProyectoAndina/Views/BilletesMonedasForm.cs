using ProyectoAndina.Controllers;
using ProyectoAndina.Helper;
using ProyectoAndina.Models;
using ProyectoAndina.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProyectoAndina.Utils.StylesAlertas;

namespace ProyectoAndina.Views
{
    public partial class BilletesMonedasForm : Form
    {
        private readonly ArqueoBilletesController _ArqueoBilletesController;
        private readonly ArqueoCajaController _ArqueoCajaController;
        private readonly FuncionesGenerales _FuncionesGenerales;
        private Label label_total_monto;
        private Label label_total_monto_valor;
        private Label label_total_monto_arqueo;
        private Label label_total_monto_arqueo_valor;
        public int total_contado;
        private Label label_notificacion_cambio;
        private Panel panel_viente_dolar;
        private Panel panel_diez_dolar;
        private Panel panel_cincuenta_dolar;
        private Panel panel_cien_dolar;
        private Panel panel_uno_dolar;
        private Panel panel_dos_dolar;
        private Panel panel_cinco_dolar;
        private Panel panel_uno_ctvs;
        private Panel panel_cinco_ctvs;
        private Panel panel_diez_ctvs;
        private Panel panel_veinticinco_ctvs;
        private Panel panel_cincuenta_ctvs;
        private Panel panel_uno_moneda;
        private Panel panel_controles;
        private Panel panel_valor_total;
        private Panel panel_valor_arqueo;
        private TextBox textBox_25_ctvs;
        private TableLayoutPanel tableLayoutPanel_logueado;
        private Panel panel1;
        private PictureBox pictureBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel5;
        public int id_arqueo_caja;
                
        public BilletesMonedasForm()
        {
            _ArqueoBilletesController = new ArqueoBilletesController();
            _ArqueoCajaController = new ArqueoCajaController();
            _FuncionesGenerales = new FuncionesGenerales();

            InitializeComponent();
            ConfigurarEstilo();
            this.Paint += BilletesMonedasForm_Paint;
            this.DoubleBuffered = true;

            this.Load += BilletesMonedasForm_Load;

            realizar_total_monto();

            int arqueo_caja_id = SessionArqueoCaja.id_arqueo_caja;

            if (arqueo_caja_id > 0)
            {
                if (SessionArqueoCaja.estadoArqueo == "A")
                {
                    mostrar_arqueo_billetes(arqueo_caja_id, SessionArqueoCaja.estadoArqueo);
                    id_arqueo_caja = arqueo_caja_id;
                    verificar_monto_arqueo_caja();
                }
                if (SessionArqueoCaja.estadoArqueo == "C")
                {
                    mostrar_arqueo_billetes(arqueo_caja_id, SessionArqueoCaja.estadoArqueo);
                    verificar_monto_arqueo_caja();
                }
            }
        }


        private void BilletesMonedasForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }

        public void ConfigurarEstilo()
        {
            StyleManager.ConfigurarFormPrincipal(this, "Menu de dominaciones de dinero");
            this.BackColor = StyleManager.Colors.GrisClaro;

            // Configurar labels con estilos UASB
            StyleManager.ConfigurarLabel(label_titulo_billetes, TipoLabel.TituloGrande);

            // esto es de los labels
            StyleManager.ConfigurarLabel(label_total_monto, TipoLabel.Subtitulo);
            StyleManager.ConfigurarLabel(label_total_monto_arqueo, TipoLabel.Subtitulo);
            StyleManager.ConfigurarLabel(label_total_monto_arqueo_valor, TipoLabel.Subtitulo);
            StyleManager.ConfigurarLabel(label_total_monto_valor, TipoLabel.Subtitulo);



            // este es de los inputs
            StyleManager.ConfigurarTextBox(textBox_100_dollar, "valor");
            StyleManager.ConfigurarTextBox(textBox_50_dollar, "valor");
            StyleManager.ConfigurarTextBox(textBox_20_dollar, "valor");
            StyleManager.ConfigurarTextBox(textBox_10_dollar, "valor");
            StyleManager.ConfigurarTextBox(textBox_5_dollar, "valor");
            StyleManager.ConfigurarTextBox(textBox_2_dollar, "valor");
            StyleManager.ConfigurarTextBox(textBox_1_dollar, "valor");

            //aqui para los text box de moneda
            StyleManager.ConfigurarTextBox(textBox_1_dollar_moneda, "valor");
            StyleManager.ConfigurarTextBox(textBox_50_ctvs, "valor");
            StyleManager.ConfigurarTextBox(textBox_25_ctvs, "valor");
            StyleManager.ConfigurarTextBox(textBox_10_ctvs, "valor");
            StyleManager.ConfigurarTextBox(textBox_5_ctvs, "valor");
            StyleManager.ConfigurarTextBox(textBox_1_ctvs, "valor");


            //configurar los botones para los de dolar
            // ---- Billetes ----
            // ---- Billetes ----
            // ---- Billetes ----
            StyleManager.AplicarEstiloBotonesConIcono(panel_cien_dolar, button_valor_cien, FontAwesome.Sharp.IconChar.MoneyBill1Wave, "$100", Color.FromArgb(46, 204, 113));
            StyleManager.AplicarEstiloBotonesConIcono(panel_cincuenta_dolar, button_valor_cincuenta, FontAwesome.Sharp.IconChar.MoneyBill1Wave, "$50", Color.FromArgb(46, 204, 113));
            StyleManager.AplicarEstiloBotonesConIcono(panel_viente_dolar, button_valor_veinte, FontAwesome.Sharp.IconChar.MoneyBill1Wave, "$20", Color.FromArgb(46, 204, 113));
            StyleManager.AplicarEstiloBotonesConIcono(panel_diez_dolar, button_valor_diez, FontAwesome.Sharp.IconChar.MoneyBill1Wave, "$10", Color.FromArgb(46, 204, 113));
            StyleManager.AplicarEstiloBotonesConIcono(panel_cinco_dolar, button_valor_cinco, FontAwesome.Sharp.IconChar.MoneyBill1Wave, "$5", Color.FromArgb(46, 204, 113));
            StyleManager.AplicarEstiloBotonesConIcono(panel_dos_dolar, button_valor_dos, FontAwesome.Sharp.IconChar.MoneyBill1Wave, "$2", Color.FromArgb(46, 204, 113));
            StyleManager.AplicarEstiloBotonesConIcono(panel_uno_dolar, button_valor_uno, FontAwesome.Sharp.IconChar.MoneyBill1Wave, "$1", Color.FromArgb(46, 204, 113));

            // ---- Monedas ----
            StyleManager.AplicarEstiloBotonesConIcono(panel_uno_moneda, button_valor_uno_dolar_moneda, FontAwesome.Sharp.IconChar.Coins, "$1 Moneda", Color.FromArgb(241, 196, 15));
            StyleManager.AplicarEstiloBotonesConIcono(panel_cincuenta_ctvs, button_valor_cincuenta_ctvs, FontAwesome.Sharp.IconChar.Coins, "50¢", Color.FromArgb(241, 196, 15));
            StyleManager.AplicarEstiloBotonesConIcono(panel_veinticinco_ctvs, button_valor_veinticinco_ctvs, FontAwesome.Sharp.IconChar.Coins, "25¢", Color.FromArgb(241, 196, 15));
            StyleManager.AplicarEstiloBotonesConIcono(panel_diez_ctvs, button_valor_diez_ctvs, FontAwesome.Sharp.IconChar.Coins, "10¢", Color.FromArgb(241, 196, 15));
            StyleManager.AplicarEstiloBotonesConIcono(panel_cinco_ctvs, button_valor_cinco_ctvs, FontAwesome.Sharp.IconChar.Coins, "5¢", Color.FromArgb(241, 196, 15));
            StyleManager.AplicarEstiloBotonesConIcono(panel_uno_ctvs, button_valor_uno_ctvs, FontAwesome.Sharp.IconChar.Coins, "1¢", Color.FromArgb(241, 196, 15));


            // Configurar panel principal con sombra
            StyleManager.ConfigurarBotonPrincipalIcono(
               iconButton_regresar,
               FontAwesome.Sharp.IconChar.ArrowLeft,
               "Regresar",
               colorFondo: Color.FromArgb(231, 76, 60)
               );

            
         
        }

        private void mostrar_arqueo_billetes(int arqueo_caja_id, string estado) {

            var arqueo_caja = _ArqueoCajaController.ObtenerPorId(arqueo_caja_id);

            if (arqueo_caja != null)
            {
                var buscarArqueoBilletes = _ArqueoBilletesController.ObtenerPorIdEstado(arqueo_caja.arqueo_id, estado);

                if (buscarArqueoBilletes != null) {

                    button_agregar_arqueo_billetes.Enabled = false;
                    label_notificacion_cambio.Text = "Si necesita realizar un cambio, por favor contacte al administrador.";
                    textBox_100_dollar.Text = buscarArqueoBilletes.billetes_100.ToString();
                    textBox_50_dollar.Text = buscarArqueoBilletes.billetes_50.ToString();
                    textBox_20_dollar.Text = buscarArqueoBilletes.billetes_20.ToString();
                    textBox_10_dollar.Text = buscarArqueoBilletes.billetes_10.ToString();
                    textBox_5_dollar.Text = buscarArqueoBilletes.billetes_5.ToString();
                    textBox_1_dollar.Text = buscarArqueoBilletes.billetes_1.ToString();
                    textBox_1_dollar_moneda.Text = buscarArqueoBilletes.monedas_1.ToString();
                    textBox_50_ctvs.Text = buscarArqueoBilletes.centavos_50.ToString();
                    textBox_25_ctvs.Text = buscarArqueoBilletes.centavos_25.ToString();
                    textBox_10_ctvs.Text = buscarArqueoBilletes.centavos_10.ToString();
                    textBox_5_ctvs.Text = buscarArqueoBilletes.centavos_5.ToString();
                    textBox_1_ctvs.Text = buscarArqueoBilletes.centavos_1.ToString();
                    label_total_monto_valor.Text = buscarArqueoBilletes.total_contado.ToString();

                    //label_mensaje.Text = "Si desea realizar algun cambio contactese con el admin";
                    colocar_enabled();
                }
                else {

                    _FuncionesGenerales.LimpiarCampos(this);
                    //label_mensaje.Text = "";
                }

            }
            else { 
            
            
            
            }
        }

        public void colocar_enabled() {
            textBox_100_dollar.Enabled = false;
            textBox_50_dollar.Enabled = false;
            textBox_20_dollar.Enabled = false;
            textBox_10_dollar.Enabled = false;
            textBox_5_dollar.Enabled = false;
            textBox_2_dollar.Enabled = false;
            textBox_1_dollar.Enabled = false;
            textBox_1_dollar_moneda.Enabled = false;
            textBox_50_ctvs.Enabled = false;
            textBox_25_ctvs.Enabled = false;
            textBox_10_ctvs.Enabled = false;
            textBox_5_ctvs.Enabled = false;
            textBox_1_ctvs.Enabled = false;

            button_valor_cien.Enabled = false;
            button_valor_cincuenta.Enabled = false;
            button_valor_veinte.Enabled = false;
            button_valor_diez.Enabled = false;
            button_valor_cinco.Enabled = false;
            button_valor_uno.Enabled = false;
            button_valor_dos.Enabled = false;
            button_valor_uno_dolar_moneda.Enabled = false;
            button_valor_uno_ctvs.Enabled = false;
            button_valor_cincuenta_ctvs.Enabled = false;
            button_valor_veinticinco_ctvs.Enabled = false;
            button_valor_diez_ctvs.Enabled = false;
            button_valor_cinco_ctvs.Enabled = false;
            
            button_agregar_arqueo_billetes.Enabled = false;

        }
        

        private void verificar_monto_arqueo_caja() {

            label_total_monto_arqueo_valor.Text = SessionArqueoCaja.montoValidar.ToString();

        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y teclas de control (ej: backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BilletesMonedasForm_Load(object sender, EventArgs e)
        {
            foreach (var tb in new[] { textBox_100_dollar, textBox_50_dollar, textBox_20_dollar,
                               textBox_10_dollar, textBox_5_dollar, textBox_2_dollar, textBox_1_dollar,
                               textBox_1_dollar_moneda, textBox_50_ctvs, textBox_25_ctvs,
                               textBox_10_ctvs, textBox_5_ctvs, textBox_1_ctvs })
            {
                tb.KeyPress += SoloNumeros_KeyPress;
                tb.TextChanged += (s, ev) => realizar_total_monto();
            }
        }

        private int ToInt(string text)
        {
            return int.TryParse(text, out int value) ? value : 0;
        }

        private void realizar_total_monto()
        {
            decimal total = 0;

            // Billetes
            total += ToInt(textBox_100_dollar.Text) * 100m;
            total += ToInt(textBox_50_dollar.Text) * 50m;
            total += ToInt(textBox_20_dollar.Text) * 20m;
            total += ToInt(textBox_10_dollar.Text) * 10m;
            total += ToInt(textBox_5_dollar.Text) * 5m;
            total += ToInt(textBox_2_dollar.Text) * 2m;
            total += ToInt(textBox_1_dollar.Text) * 1m;

            // Monedas
            total += ToInt(textBox_1_dollar_moneda.Text) * 1m;
            total += ToInt(textBox_50_ctvs.Text) * 0.50m;
            total += ToInt(textBox_25_ctvs.Text) * 0.25m;
            total += ToInt(textBox_10_ctvs.Text) * 0.10m;
            total += ToInt(textBox_5_ctvs.Text) * 0.05m;
            total += ToInt(textBox_1_ctvs.Text) * 0.01m;

            // Mostrar el total (ejemplo en un Label)
            label_total_monto_valor.Text = $"{total:C2}"; // ejemplo → $123.45
        }

        private void InitializeComponent()
        {
            button_valor_cincuenta_ctvs = new FontAwesome.Sharp.IconButton();
            button_valor_uno_ctvs = new FontAwesome.Sharp.IconButton();
            button_valor_cinco_ctvs = new FontAwesome.Sharp.IconButton();
            button_valor_diez_ctvs = new FontAwesome.Sharp.IconButton();
            button_valor_veinticinco_ctvs = new FontAwesome.Sharp.IconButton();
            button_valor_cien = new FontAwesome.Sharp.IconButton();
            button_valor_cincuenta = new FontAwesome.Sharp.IconButton();
            button_valor_uno = new FontAwesome.Sharp.IconButton();
            button_valor_dos = new FontAwesome.Sharp.IconButton();
            button_valor_cinco = new FontAwesome.Sharp.IconButton();
            button_valor_diez = new FontAwesome.Sharp.IconButton();
            button_valor_veinte = new FontAwesome.Sharp.IconButton();
            button_valor_uno_dolar_moneda = new FontAwesome.Sharp.IconButton();
            label_titulo_billetes = new Label();
            iconButton_regresar = new FontAwesome.Sharp.IconButton();
            textBox_100_dollar = new TextBox();
            textBox_50_dollar = new TextBox();
            textBox_10_dollar = new TextBox();
            textBox_20_dollar = new TextBox();
            textBox_2_dollar = new TextBox();
            textBox_5_dollar = new TextBox();
            textBox_1_dollar = new TextBox();
            textBox_1_dollar_moneda = new TextBox();
            textBox_50_ctvs = new TextBox();
            textBox_10_ctvs = new TextBox();
            textBox_5_ctvs = new TextBox();
            textBox_1_ctvs = new TextBox();
            button_agregar_arqueo_billetes = new Button();
            label_total_monto = new Label();
            label_total_monto_valor = new Label();
            label_total_monto_arqueo = new Label();
            label_total_monto_arqueo_valor = new Label();
            label_notificacion_cambio = new Label();
            panel_controles = new Panel();
            panel_valor_total = new Panel();
            panel_valor_arqueo = new Panel();
            panel_uno_ctvs = new Panel();
            panel_cinco_ctvs = new Panel();
            panel_diez_ctvs = new Panel();
            panel_veinticinco_ctvs = new Panel();
            textBox_25_ctvs = new TextBox();
            panel_cincuenta_ctvs = new Panel();
            panel_uno_moneda = new Panel();
            panel_uno_dolar = new Panel();
            panel_dos_dolar = new Panel();
            panel_cinco_dolar = new Panel();
            panel_diez_dolar = new Panel();
            panel_viente_dolar = new Panel();
            panel_cincuenta_dolar = new Panel();
            panel_cien_dolar = new Panel();
            tableLayoutPanel_logueado = new TableLayoutPanel();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            panel_controles.SuspendLayout();
            panel_valor_total.SuspendLayout();
            panel_valor_arqueo.SuspendLayout();
            panel_uno_ctvs.SuspendLayout();
            panel_cinco_ctvs.SuspendLayout();
            panel_diez_ctvs.SuspendLayout();
            panel_veinticinco_ctvs.SuspendLayout();
            panel_cincuenta_ctvs.SuspendLayout();
            panel_uno_moneda.SuspendLayout();
            panel_uno_dolar.SuspendLayout();
            panel_dos_dolar.SuspendLayout();
            panel_cinco_dolar.SuspendLayout();
            panel_diez_dolar.SuspendLayout();
            panel_viente_dolar.SuspendLayout();
            panel_cincuenta_dolar.SuspendLayout();
            panel_cien_dolar.SuspendLayout();
            tableLayoutPanel_logueado.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            SuspendLayout();
            // 
            // button_valor_cincuenta_ctvs
            // 
            button_valor_cincuenta_ctvs.BackColor = Color.FromArgb(255, 255, 192);
            button_valor_cincuenta_ctvs.Cursor = Cursors.Hand;
            button_valor_cincuenta_ctvs.FlatAppearance.BorderSize = 0;
            button_valor_cincuenta_ctvs.FlatStyle = FlatStyle.Flat;
            button_valor_cincuenta_ctvs.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_valor_cincuenta_ctvs.ForeColor = Color.Black;
            button_valor_cincuenta_ctvs.IconChar = FontAwesome.Sharp.IconChar.None;
            button_valor_cincuenta_ctvs.IconColor = Color.Transparent;
            button_valor_cincuenta_ctvs.IconFont = FontAwesome.Sharp.IconFont.Auto;
            button_valor_cincuenta_ctvs.IconSize = 24;
            button_valor_cincuenta_ctvs.Location = new Point(3, 10);
            button_valor_cincuenta_ctvs.Name = "button_valor_cincuenta_ctvs";
            button_valor_cincuenta_ctvs.Size = new Size(119, 102);
            button_valor_cincuenta_ctvs.TabIndex = 73;
            button_valor_cincuenta_ctvs.Text = "0.50 ctvs";
            button_valor_cincuenta_ctvs.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_valor_cincuenta_ctvs.UseVisualStyleBackColor = false;
            button_valor_cincuenta_ctvs.Click += button_valor_cincuenta_ctvs_Click;
            // 
            // button_valor_uno_ctvs
            // 
            button_valor_uno_ctvs.BackColor = Color.FromArgb(255, 255, 192);
            button_valor_uno_ctvs.Cursor = Cursors.Hand;
            button_valor_uno_ctvs.FlatAppearance.BorderSize = 0;
            button_valor_uno_ctvs.FlatStyle = FlatStyle.Flat;
            button_valor_uno_ctvs.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_valor_uno_ctvs.ForeColor = Color.Black;
            button_valor_uno_ctvs.IconChar = FontAwesome.Sharp.IconChar.None;
            button_valor_uno_ctvs.IconColor = Color.Transparent;
            button_valor_uno_ctvs.IconFont = FontAwesome.Sharp.IconFont.Auto;
            button_valor_uno_ctvs.IconSize = 24;
            button_valor_uno_ctvs.Location = new Point(4, 10);
            button_valor_uno_ctvs.Name = "button_valor_uno_ctvs";
            button_valor_uno_ctvs.Size = new Size(119, 102);
            button_valor_uno_ctvs.TabIndex = 72;
            button_valor_uno_ctvs.Text = "0.1 ctvs";
            button_valor_uno_ctvs.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_valor_uno_ctvs.UseVisualStyleBackColor = false;
            button_valor_uno_ctvs.Click += button_valor_uno_ctvs_Click;
            // 
            // button_valor_cinco_ctvs
            // 
            button_valor_cinco_ctvs.BackColor = Color.FromArgb(255, 255, 192);
            button_valor_cinco_ctvs.Cursor = Cursors.Hand;
            button_valor_cinco_ctvs.FlatAppearance.BorderSize = 0;
            button_valor_cinco_ctvs.FlatStyle = FlatStyle.Flat;
            button_valor_cinco_ctvs.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_valor_cinco_ctvs.ForeColor = Color.Black;
            button_valor_cinco_ctvs.IconChar = FontAwesome.Sharp.IconChar.None;
            button_valor_cinco_ctvs.IconColor = Color.Transparent;
            button_valor_cinco_ctvs.IconFont = FontAwesome.Sharp.IconFont.Auto;
            button_valor_cinco_ctvs.IconSize = 24;
            button_valor_cinco_ctvs.Location = new Point(3, 10);
            button_valor_cinco_ctvs.Name = "button_valor_cinco_ctvs";
            button_valor_cinco_ctvs.Size = new Size(119, 102);
            button_valor_cinco_ctvs.TabIndex = 71;
            button_valor_cinco_ctvs.Text = " 0.5 ctvs";
            button_valor_cinco_ctvs.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_valor_cinco_ctvs.UseVisualStyleBackColor = false;
            button_valor_cinco_ctvs.Click += button_valor_cinco_ctvs_Click;
            // 
            // button_valor_diez_ctvs
            // 
            button_valor_diez_ctvs.BackColor = Color.FromArgb(255, 255, 192);
            button_valor_diez_ctvs.Cursor = Cursors.Hand;
            button_valor_diez_ctvs.FlatAppearance.BorderSize = 0;
            button_valor_diez_ctvs.FlatStyle = FlatStyle.Flat;
            button_valor_diez_ctvs.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_valor_diez_ctvs.ForeColor = Color.Black;
            button_valor_diez_ctvs.IconChar = FontAwesome.Sharp.IconChar.None;
            button_valor_diez_ctvs.IconColor = Color.Transparent;
            button_valor_diez_ctvs.IconFont = FontAwesome.Sharp.IconFont.Auto;
            button_valor_diez_ctvs.IconSize = 24;
            button_valor_diez_ctvs.Location = new Point(3, 10);
            button_valor_diez_ctvs.Name = "button_valor_diez_ctvs";
            button_valor_diez_ctvs.Size = new Size(119, 102);
            button_valor_diez_ctvs.TabIndex = 70;
            button_valor_diez_ctvs.Text = " 0.10 ctvs";
            button_valor_diez_ctvs.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_valor_diez_ctvs.UseVisualStyleBackColor = false;
            button_valor_diez_ctvs.Click += button_valor_diez_ctvs_Click;
            // 
            // button_valor_veinticinco_ctvs
            // 
            button_valor_veinticinco_ctvs.BackColor = Color.FromArgb(255, 255, 192);
            button_valor_veinticinco_ctvs.Cursor = Cursors.Hand;
            button_valor_veinticinco_ctvs.FlatAppearance.BorderSize = 0;
            button_valor_veinticinco_ctvs.FlatStyle = FlatStyle.Flat;
            button_valor_veinticinco_ctvs.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_valor_veinticinco_ctvs.ForeColor = Color.Black;
            button_valor_veinticinco_ctvs.IconChar = FontAwesome.Sharp.IconChar.None;
            button_valor_veinticinco_ctvs.IconColor = Color.Transparent;
            button_valor_veinticinco_ctvs.IconFont = FontAwesome.Sharp.IconFont.Auto;
            button_valor_veinticinco_ctvs.IconSize = 24;
            button_valor_veinticinco_ctvs.Location = new Point(3, 10);
            button_valor_veinticinco_ctvs.Name = "button_valor_veinticinco_ctvs";
            button_valor_veinticinco_ctvs.Size = new Size(119, 102);
            button_valor_veinticinco_ctvs.TabIndex = 69;
            button_valor_veinticinco_ctvs.Text = "  0.25 ctvs";
            button_valor_veinticinco_ctvs.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_valor_veinticinco_ctvs.UseVisualStyleBackColor = false;
            button_valor_veinticinco_ctvs.Click += button_valor_veinticinco_ctvs_Click;
            // 
            // button_valor_cien
            // 
            button_valor_cien.BackColor = Color.FromArgb(46, 204, 113);
            button_valor_cien.Cursor = Cursors.Hand;
            button_valor_cien.FlatAppearance.BorderSize = 0;
            button_valor_cien.FlatStyle = FlatStyle.Flat;
            button_valor_cien.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_valor_cien.ForeColor = Color.Black;
            button_valor_cien.IconChar = FontAwesome.Sharp.IconChar.None;
            button_valor_cien.IconColor = Color.Transparent;
            button_valor_cien.IconFont = FontAwesome.Sharp.IconFont.Auto;
            button_valor_cien.IconSize = 24;
            button_valor_cien.Location = new Point(3, 7);
            button_valor_cien.Name = "button_valor_cien";
            button_valor_cien.Size = new Size(120, 110);
            button_valor_cien.TabIndex = 68;
            button_valor_cien.Text = " 100 $";
            button_valor_cien.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_valor_cien.UseMnemonic = false;
            button_valor_cien.UseVisualStyleBackColor = false;
            button_valor_cien.Click += button_valor_cien_Click;
            // 
            // button_valor_cincuenta
            // 
            button_valor_cincuenta.BackColor = Color.FromArgb(46, 204, 113);
            button_valor_cincuenta.Cursor = Cursors.Hand;
            button_valor_cincuenta.FlatAppearance.BorderSize = 0;
            button_valor_cincuenta.FlatStyle = FlatStyle.Flat;
            button_valor_cincuenta.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_valor_cincuenta.ForeColor = Color.Black;
            button_valor_cincuenta.IconChar = FontAwesome.Sharp.IconChar.None;
            button_valor_cincuenta.IconColor = Color.Transparent;
            button_valor_cincuenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            button_valor_cincuenta.IconSize = 24;
            button_valor_cincuenta.Location = new Point(3, 7);
            button_valor_cincuenta.Name = "button_valor_cincuenta";
            button_valor_cincuenta.Size = new Size(120, 110);
            button_valor_cincuenta.TabIndex = 67;
            button_valor_cincuenta.Text = " 50 $";
            button_valor_cincuenta.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_valor_cincuenta.UseVisualStyleBackColor = false;
            button_valor_cincuenta.Click += button_valor_cincuenta_Click;
            // 
            // button_valor_uno
            // 
            button_valor_uno.BackColor = Color.FromArgb(46, 204, 113);
            button_valor_uno.Cursor = Cursors.Hand;
            button_valor_uno.FlatAppearance.BorderSize = 0;
            button_valor_uno.FlatStyle = FlatStyle.Flat;
            button_valor_uno.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_valor_uno.ForeColor = Color.Black;
            button_valor_uno.IconChar = FontAwesome.Sharp.IconChar.None;
            button_valor_uno.IconColor = Color.Transparent;
            button_valor_uno.IconFont = FontAwesome.Sharp.IconFont.Auto;
            button_valor_uno.IconSize = 24;
            button_valor_uno.Location = new Point(6, 7);
            button_valor_uno.Name = "button_valor_uno";
            button_valor_uno.Size = new Size(120, 110);
            button_valor_uno.TabIndex = 66;
            button_valor_uno.Text = " 1 $";
            button_valor_uno.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_valor_uno.UseVisualStyleBackColor = false;
            button_valor_uno.Click += button_valor_uno_Click;
            // 
            // button_valor_dos
            // 
            button_valor_dos.BackColor = Color.FromArgb(46, 204, 113);
            button_valor_dos.Cursor = Cursors.Hand;
            button_valor_dos.FlatAppearance.BorderSize = 0;
            button_valor_dos.FlatStyle = FlatStyle.Flat;
            button_valor_dos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_valor_dos.ForeColor = Color.Black;
            button_valor_dos.IconChar = FontAwesome.Sharp.IconChar.None;
            button_valor_dos.IconColor = Color.Transparent;
            button_valor_dos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            button_valor_dos.IconSize = 24;
            button_valor_dos.Location = new Point(3, 7);
            button_valor_dos.Name = "button_valor_dos";
            button_valor_dos.Size = new Size(120, 110);
            button_valor_dos.TabIndex = 65;
            button_valor_dos.Text = " 2 $";
            button_valor_dos.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_valor_dos.UseVisualStyleBackColor = false;
            button_valor_dos.Click += button_valor_dos_Click;
            // 
            // button_valor_cinco
            // 
            button_valor_cinco.BackColor = Color.FromArgb(46, 204, 113);
            button_valor_cinco.Cursor = Cursors.Hand;
            button_valor_cinco.FlatAppearance.BorderSize = 0;
            button_valor_cinco.FlatStyle = FlatStyle.Flat;
            button_valor_cinco.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_valor_cinco.ForeColor = Color.Black;
            button_valor_cinco.IconChar = FontAwesome.Sharp.IconChar.None;
            button_valor_cinco.IconColor = Color.Transparent;
            button_valor_cinco.IconFont = FontAwesome.Sharp.IconFont.Auto;
            button_valor_cinco.IconSize = 24;
            button_valor_cinco.Location = new Point(3, 7);
            button_valor_cinco.Name = "button_valor_cinco";
            button_valor_cinco.Size = new Size(120, 110);
            button_valor_cinco.TabIndex = 64;
            button_valor_cinco.Text = " 5 $";
            button_valor_cinco.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_valor_cinco.UseVisualStyleBackColor = false;
            button_valor_cinco.Click += button_valor_cinco_Click;
            // 
            // button_valor_diez
            // 
            button_valor_diez.BackColor = Color.FromArgb(46, 204, 113);
            button_valor_diez.Cursor = Cursors.Hand;
            button_valor_diez.FlatAppearance.BorderSize = 0;
            button_valor_diez.FlatStyle = FlatStyle.Flat;
            button_valor_diez.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_valor_diez.ForeColor = Color.Black;
            button_valor_diez.IconChar = FontAwesome.Sharp.IconChar.None;
            button_valor_diez.IconColor = Color.Transparent;
            button_valor_diez.IconFont = FontAwesome.Sharp.IconFont.Auto;
            button_valor_diez.IconSize = 24;
            button_valor_diez.Location = new Point(3, 7);
            button_valor_diez.Name = "button_valor_diez";
            button_valor_diez.Size = new Size(120, 110);
            button_valor_diez.TabIndex = 63;
            button_valor_diez.Text = "  10 $";
            button_valor_diez.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_valor_diez.UseVisualStyleBackColor = false;
            button_valor_diez.Click += button_valor_diez_Click;
            // 
            // button_valor_veinte
            // 
            button_valor_veinte.BackColor = Color.FromArgb(46, 204, 113);
            button_valor_veinte.Cursor = Cursors.Hand;
            button_valor_veinte.FlatAppearance.BorderSize = 0;
            button_valor_veinte.FlatStyle = FlatStyle.Flat;
            button_valor_veinte.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_valor_veinte.ForeColor = Color.Black;
            button_valor_veinte.IconChar = FontAwesome.Sharp.IconChar.None;
            button_valor_veinte.IconColor = Color.Transparent;
            button_valor_veinte.IconFont = FontAwesome.Sharp.IconFont.Auto;
            button_valor_veinte.IconSize = 24;
            button_valor_veinte.Location = new Point(3, 7);
            button_valor_veinte.Name = "button_valor_veinte";
            button_valor_veinte.Size = new Size(120, 110);
            button_valor_veinte.TabIndex = 58;
            button_valor_veinte.Text = "  20 $";
            button_valor_veinte.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_valor_veinte.UseVisualStyleBackColor = false;
            button_valor_veinte.Click += button_valor_veinte_Click;
            // 
            // button_valor_uno_dolar_moneda
            // 
            button_valor_uno_dolar_moneda.BackColor = Color.FromArgb(255, 255, 192);
            button_valor_uno_dolar_moneda.Cursor = Cursors.Hand;
            button_valor_uno_dolar_moneda.FlatAppearance.BorderSize = 0;
            button_valor_uno_dolar_moneda.FlatStyle = FlatStyle.Flat;
            button_valor_uno_dolar_moneda.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_valor_uno_dolar_moneda.ForeColor = Color.Black;
            button_valor_uno_dolar_moneda.IconChar = FontAwesome.Sharp.IconChar.None;
            button_valor_uno_dolar_moneda.IconColor = Color.Transparent;
            button_valor_uno_dolar_moneda.IconFont = FontAwesome.Sharp.IconFont.Auto;
            button_valor_uno_dolar_moneda.IconSize = 24;
            button_valor_uno_dolar_moneda.Location = new Point(3, 10);
            button_valor_uno_dolar_moneda.Name = "button_valor_uno_dolar_moneda";
            button_valor_uno_dolar_moneda.Size = new Size(119, 102);
            button_valor_uno_dolar_moneda.TabIndex = 74;
            button_valor_uno_dolar_moneda.Text = "1 dolar";
            button_valor_uno_dolar_moneda.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_valor_uno_dolar_moneda.UseVisualStyleBackColor = false;
            button_valor_uno_dolar_moneda.Click += iconButton1_Click;
            // 
            // label_titulo_billetes
            // 
            label_titulo_billetes.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_billetes.AutoSize = true;
            label_titulo_billetes.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_billetes.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_billetes.Location = new Point(300, 20);
            label_titulo_billetes.Name = "label_titulo_billetes";
            label_titulo_billetes.Size = new Size(589, 37);
            label_titulo_billetes.TabIndex = 77;
            label_titulo_billetes.Text = "Denominaciones de dinero";
            label_titulo_billetes.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // iconButton_regresar
            // 
            iconButton_regresar.BackColor = Color.FromArgb(41, 128, 185);
            iconButton_regresar.Cursor = Cursors.Hand;
            iconButton_regresar.FlatAppearance.BorderSize = 0;
            iconButton_regresar.FlatStyle = FlatStyle.Flat;
            iconButton_regresar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            iconButton_regresar.ForeColor = Color.Transparent;
            iconButton_regresar.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            iconButton_regresar.IconColor = Color.Transparent;
            iconButton_regresar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton_regresar.IconSize = 24;
            iconButton_regresar.Location = new Point(3, 3);
            iconButton_regresar.Name = "iconButton_regresar";
            iconButton_regresar.Size = new Size(217, 62);
            iconButton_regresar.TabIndex = 79;
            iconButton_regresar.Text = "  Regresar";
            iconButton_regresar.TextAlign = ContentAlignment.MiddleRight;
            iconButton_regresar.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton_regresar.UseVisualStyleBackColor = false;
            iconButton_regresar.Click += iconButton_regresar_Click;
            // 
            // textBox_100_dollar
            // 
            textBox_100_dollar.Location = new Point(3, 149);
            textBox_100_dollar.Name = "textBox_100_dollar";
            textBox_100_dollar.Size = new Size(120, 27);
            textBox_100_dollar.TabIndex = 80;
            // 
            // textBox_50_dollar
            // 
            textBox_50_dollar.Location = new Point(6, 149);
            textBox_50_dollar.Name = "textBox_50_dollar";
            textBox_50_dollar.Size = new Size(117, 27);
            textBox_50_dollar.TabIndex = 81;
            // 
            // textBox_10_dollar
            // 
            textBox_10_dollar.Location = new Point(6, 149);
            textBox_10_dollar.Name = "textBox_10_dollar";
            textBox_10_dollar.Size = new Size(117, 27);
            textBox_10_dollar.TabIndex = 83;
            // 
            // textBox_20_dollar
            // 
            textBox_20_dollar.Location = new Point(6, 149);
            textBox_20_dollar.Name = "textBox_20_dollar";
            textBox_20_dollar.Size = new Size(117, 27);
            textBox_20_dollar.TabIndex = 82;
            // 
            // textBox_2_dollar
            // 
            textBox_2_dollar.Location = new Point(6, 149);
            textBox_2_dollar.Name = "textBox_2_dollar";
            textBox_2_dollar.Size = new Size(117, 27);
            textBox_2_dollar.TabIndex = 85;
            // 
            // textBox_5_dollar
            // 
            textBox_5_dollar.Location = new Point(6, 149);
            textBox_5_dollar.Name = "textBox_5_dollar";
            textBox_5_dollar.Size = new Size(117, 27);
            textBox_5_dollar.TabIndex = 84;
            // 
            // textBox_1_dollar
            // 
            textBox_1_dollar.Location = new Point(6, 149);
            textBox_1_dollar.Name = "textBox_1_dollar";
            textBox_1_dollar.Size = new Size(116, 27);
            textBox_1_dollar.TabIndex = 86;
            // 
            // textBox_1_dollar_moneda
            // 
            textBox_1_dollar_moneda.Location = new Point(6, 153);
            textBox_1_dollar_moneda.Name = "textBox_1_dollar_moneda";
            textBox_1_dollar_moneda.Size = new Size(114, 27);
            textBox_1_dollar_moneda.TabIndex = 87;
            // 
            // textBox_50_ctvs
            // 
            textBox_50_ctvs.Location = new Point(3, 153);
            textBox_50_ctvs.Name = "textBox_50_ctvs";
            textBox_50_ctvs.Size = new Size(118, 27);
            textBox_50_ctvs.TabIndex = 88;
            // 
            // textBox_10_ctvs
            // 
            textBox_10_ctvs.Location = new Point(6, 153);
            textBox_10_ctvs.Name = "textBox_10_ctvs";
            textBox_10_ctvs.Size = new Size(117, 27);
            textBox_10_ctvs.TabIndex = 90;
            // 
            // textBox_5_ctvs
            // 
            textBox_5_ctvs.Location = new Point(3, 153);
            textBox_5_ctvs.Name = "textBox_5_ctvs";
            textBox_5_ctvs.Size = new Size(120, 27);
            textBox_5_ctvs.TabIndex = 91;
            textBox_5_ctvs.TextChanged += textBox_5_ctvs_TextChanged;
            // 
            // textBox_1_ctvs
            // 
            textBox_1_ctvs.Location = new Point(4, 153);
            textBox_1_ctvs.Name = "textBox_1_ctvs";
            textBox_1_ctvs.Size = new Size(120, 27);
            textBox_1_ctvs.TabIndex = 92;
            // 
            // button_agregar_arqueo_billetes
            // 
            button_agregar_arqueo_billetes.BackColor = Color.FromArgb(52, 152, 219);
            button_agregar_arqueo_billetes.Cursor = Cursors.Hand;
            button_agregar_arqueo_billetes.FlatAppearance.BorderSize = 0;
            button_agregar_arqueo_billetes.FlatStyle = FlatStyle.Flat;
            button_agregar_arqueo_billetes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_agregar_arqueo_billetes.ForeColor = Color.Transparent;
            button_agregar_arqueo_billetes.Location = new Point(37, 6);
            button_agregar_arqueo_billetes.Name = "button_agregar_arqueo_billetes";
            button_agregar_arqueo_billetes.Size = new Size(145, 40);
            button_agregar_arqueo_billetes.TabIndex = 93;
            button_agregar_arqueo_billetes.Text = "Guardar Datos";
            button_agregar_arqueo_billetes.UseVisualStyleBackColor = false;
            button_agregar_arqueo_billetes.Click += button_agregar_arqueo_billetes_Click;
            // 
            // label_total_monto
            // 
            label_total_monto.AutoSize = true;
            label_total_monto.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_total_monto.Location = new Point(4, 15);
            label_total_monto.Name = "label_total_monto";
            label_total_monto.Size = new Size(112, 23);
            label_total_monto.TabIndex = 96;
            label_total_monto.Text = "Total monto:";
            // 
            // label_total_monto_valor
            // 
            label_total_monto_valor.AutoSize = true;
            label_total_monto_valor.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_total_monto_valor.Location = new Point(154, 15);
            label_total_monto_valor.Name = "label_total_monto_valor";
            label_total_monto_valor.Size = new Size(70, 23);
            label_total_monto_valor.TabIndex = 97;
            label_total_monto_valor.Text = "$ 00.00";
            // 
            // label_total_monto_arqueo
            // 
            label_total_monto_arqueo.AutoSize = true;
            label_total_monto_arqueo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_total_monto_arqueo.Location = new Point(3, 15);
            label_total_monto_arqueo.Name = "label_total_monto_arqueo";
            label_total_monto_arqueo.Size = new Size(115, 23);
            label_total_monto_arqueo.TabIndex = 98;
            label_total_monto_arqueo.Text = "Total arqueo:";
            // 
            // label_total_monto_arqueo_valor
            // 
            label_total_monto_arqueo_valor.AutoSize = true;
            label_total_monto_arqueo_valor.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_total_monto_arqueo_valor.Location = new Point(208, 15);
            label_total_monto_arqueo_valor.Name = "label_total_monto_arqueo_valor";
            label_total_monto_arqueo_valor.Size = new Size(70, 23);
            label_total_monto_arqueo_valor.TabIndex = 99;
            label_total_monto_arqueo_valor.Text = "$ 00.00";
            // 
            // label_notificacion_cambio
            // 
            label_notificacion_cambio.AutoSize = true;
            label_notificacion_cambio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_notificacion_cambio.ForeColor = Color.Red;
            label_notificacion_cambio.Location = new Point(425, 396);
            label_notificacion_cambio.Name = "label_notificacion_cambio";
            label_notificacion_cambio.Size = new Size(0, 23);
            label_notificacion_cambio.TabIndex = 100;
            // 
            // panel_controles
            // 
            panel_controles.BackColor = Color.Transparent;
            panel_controles.Controls.Add(button_agregar_arqueo_billetes);
            panel_controles.Dock = DockStyle.Fill;
            panel_controles.Location = new Point(711, 3);
            panel_controles.Name = "panel_controles";
            panel_controles.Size = new Size(351, 57);
            panel_controles.TabIndex = 106;
            // 
            // panel_valor_total
            // 
            panel_valor_total.BackColor = Color.Transparent;
            panel_valor_total.Controls.Add(label_total_monto_arqueo);
            panel_valor_total.Controls.Add(label_total_monto_arqueo_valor);
            panel_valor_total.Dock = DockStyle.Fill;
            panel_valor_total.Location = new Point(357, 3);
            panel_valor_total.Name = "panel_valor_total";
            panel_valor_total.Size = new Size(348, 57);
            panel_valor_total.TabIndex = 107;
            // 
            // panel_valor_arqueo
            // 
            panel_valor_arqueo.BackColor = Color.Transparent;
            panel_valor_arqueo.Controls.Add(label_total_monto);
            panel_valor_arqueo.Controls.Add(label_total_monto_valor);
            panel_valor_arqueo.Dock = DockStyle.Fill;
            panel_valor_arqueo.Location = new Point(3, 3);
            panel_valor_arqueo.Name = "panel_valor_arqueo";
            panel_valor_arqueo.Size = new Size(348, 57);
            panel_valor_arqueo.TabIndex = 106;
            // 
            // panel_uno_ctvs
            // 
            panel_uno_ctvs.Anchor = AnchorStyles.None;
            panel_uno_ctvs.BackColor = Color.Transparent;
            panel_uno_ctvs.Controls.Add(button_valor_uno_ctvs);
            panel_uno_ctvs.Controls.Add(textBox_1_ctvs);
            panel_uno_ctvs.Location = new Point(906, 35);
            panel_uno_ctvs.Name = "panel_uno_ctvs";
            panel_uno_ctvs.Size = new Size(126, 193);
            panel_uno_ctvs.TabIndex = 109;
            // 
            // panel_cinco_ctvs
            // 
            panel_cinco_ctvs.Anchor = AnchorStyles.None;
            panel_cinco_ctvs.BackColor = Color.Transparent;
            panel_cinco_ctvs.Controls.Add(button_valor_cinco_ctvs);
            panel_cinco_ctvs.Controls.Add(textBox_5_ctvs);
            panel_cinco_ctvs.Location = new Point(729, 35);
            panel_cinco_ctvs.Name = "panel_cinco_ctvs";
            panel_cinco_ctvs.Size = new Size(126, 193);
            panel_cinco_ctvs.TabIndex = 108;
            // 
            // panel_diez_ctvs
            // 
            panel_diez_ctvs.Anchor = AnchorStyles.None;
            panel_diez_ctvs.BackColor = Color.Transparent;
            panel_diez_ctvs.Controls.Add(button_valor_diez_ctvs);
            panel_diez_ctvs.Controls.Add(textBox_10_ctvs);
            panel_diez_ctvs.Location = new Point(553, 35);
            panel_diez_ctvs.Name = "panel_diez_ctvs";
            panel_diez_ctvs.Size = new Size(126, 193);
            panel_diez_ctvs.TabIndex = 107;
            // 
            // panel_veinticinco_ctvs
            // 
            panel_veinticinco_ctvs.Anchor = AnchorStyles.None;
            panel_veinticinco_ctvs.BackColor = Color.Transparent;
            panel_veinticinco_ctvs.Controls.Add(textBox_25_ctvs);
            panel_veinticinco_ctvs.Controls.Add(button_valor_veinticinco_ctvs);
            panel_veinticinco_ctvs.Location = new Point(377, 35);
            panel_veinticinco_ctvs.Name = "panel_veinticinco_ctvs";
            panel_veinticinco_ctvs.Size = new Size(126, 193);
            panel_veinticinco_ctvs.TabIndex = 106;
            // 
            // textBox_25_ctvs
            // 
            textBox_25_ctvs.Location = new Point(3, 153);
            textBox_25_ctvs.Name = "textBox_25_ctvs";
            textBox_25_ctvs.Size = new Size(117, 27);
            textBox_25_ctvs.TabIndex = 91;
            // 
            // panel_cincuenta_ctvs
            // 
            panel_cincuenta_ctvs.Anchor = AnchorStyles.None;
            panel_cincuenta_ctvs.BackColor = Color.Transparent;
            panel_cincuenta_ctvs.Controls.Add(button_valor_cincuenta_ctvs);
            panel_cincuenta_ctvs.Controls.Add(textBox_50_ctvs);
            panel_cincuenta_ctvs.Location = new Point(201, 35);
            panel_cincuenta_ctvs.Name = "panel_cincuenta_ctvs";
            panel_cincuenta_ctvs.Size = new Size(126, 193);
            panel_cincuenta_ctvs.TabIndex = 105;
            // 
            // panel_uno_moneda
            // 
            panel_uno_moneda.Anchor = AnchorStyles.None;
            panel_uno_moneda.BackColor = Color.Transparent;
            panel_uno_moneda.Controls.Add(button_valor_uno_dolar_moneda);
            panel_uno_moneda.Controls.Add(textBox_1_dollar_moneda);
            panel_uno_moneda.Location = new Point(25, 35);
            panel_uno_moneda.Name = "panel_uno_moneda";
            panel_uno_moneda.Size = new Size(126, 193);
            panel_uno_moneda.TabIndex = 104;
            // 
            // panel_uno_dolar
            // 
            panel_uno_dolar.Anchor = AnchorStyles.None;
            panel_uno_dolar.BackColor = Color.Transparent;
            panel_uno_dolar.Controls.Add(button_valor_uno);
            panel_uno_dolar.Controls.Add(textBox_1_dollar);
            panel_uno_dolar.Location = new Point(915, 42);
            panel_uno_dolar.Name = "panel_uno_dolar";
            panel_uno_dolar.Size = new Size(134, 188);
            panel_uno_dolar.TabIndex = 109;
            // 
            // panel_dos_dolar
            // 
            panel_dos_dolar.Anchor = AnchorStyles.None;
            panel_dos_dolar.BackColor = Color.Transparent;
            panel_dos_dolar.Controls.Add(button_valor_dos);
            panel_dos_dolar.Controls.Add(textBox_2_dollar);
            panel_dos_dolar.Location = new Point(767, 42);
            panel_dos_dolar.Name = "panel_dos_dolar";
            panel_dos_dolar.Size = new Size(126, 188);
            panel_dos_dolar.TabIndex = 108;
            // 
            // panel_cinco_dolar
            // 
            panel_cinco_dolar.Anchor = AnchorStyles.None;
            panel_cinco_dolar.BackColor = Color.Transparent;
            panel_cinco_dolar.Controls.Add(button_valor_cinco);
            panel_cinco_dolar.Controls.Add(textBox_5_dollar);
            panel_cinco_dolar.Location = new Point(616, 42);
            panel_cinco_dolar.Name = "panel_cinco_dolar";
            panel_cinco_dolar.Size = new Size(126, 188);
            panel_cinco_dolar.TabIndex = 107;
            // 
            // panel_diez_dolar
            // 
            panel_diez_dolar.Anchor = AnchorStyles.None;
            panel_diez_dolar.BackColor = Color.Transparent;
            panel_diez_dolar.Controls.Add(button_valor_diez);
            panel_diez_dolar.Controls.Add(textBox_10_dollar);
            panel_diez_dolar.Location = new Point(465, 42);
            panel_diez_dolar.Name = "panel_diez_dolar";
            panel_diez_dolar.Size = new Size(126, 188);
            panel_diez_dolar.TabIndex = 106;
            // 
            // panel_viente_dolar
            // 
            panel_viente_dolar.Anchor = AnchorStyles.None;
            panel_viente_dolar.BackColor = Color.Transparent;
            panel_viente_dolar.Controls.Add(button_valor_veinte);
            panel_viente_dolar.Controls.Add(textBox_20_dollar);
            panel_viente_dolar.Location = new Point(314, 42);
            panel_viente_dolar.Name = "panel_viente_dolar";
            panel_viente_dolar.Size = new Size(126, 188);
            panel_viente_dolar.TabIndex = 105;
            // 
            // panel_cincuenta_dolar
            // 
            panel_cincuenta_dolar.Anchor = AnchorStyles.None;
            panel_cincuenta_dolar.BackColor = Color.Transparent;
            panel_cincuenta_dolar.Controls.Add(button_valor_cincuenta);
            panel_cincuenta_dolar.Controls.Add(textBox_50_dollar);
            panel_cincuenta_dolar.Location = new Point(163, 42);
            panel_cincuenta_dolar.Name = "panel_cincuenta_dolar";
            panel_cincuenta_dolar.Size = new Size(126, 188);
            panel_cincuenta_dolar.TabIndex = 104;
            // 
            // panel_cien_dolar
            // 
            panel_cien_dolar.Anchor = AnchorStyles.None;
            panel_cien_dolar.BackColor = Color.Transparent;
            panel_cien_dolar.Controls.Add(button_valor_cien);
            panel_cien_dolar.Controls.Add(textBox_100_dollar);
            panel_cien_dolar.Location = new Point(12, 42);
            panel_cien_dolar.Name = "panel_cien_dolar";
            panel_cien_dolar.Size = new Size(126, 188);
            panel_cien_dolar.TabIndex = 103;
            // 
            // tableLayoutPanel_logueado
            // 
            tableLayoutPanel_logueado.BackColor = Color.Transparent;
            tableLayoutPanel_logueado.ColumnCount = 3;
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel_logueado.Controls.Add(iconButton_regresar, 0, 0);
            tableLayoutPanel_logueado.Controls.Add(label_titulo_billetes, 1, 0);
            tableLayoutPanel_logueado.Controls.Add(panel1, 2, 0);
            tableLayoutPanel_logueado.Dock = DockStyle.Top;
            tableLayoutPanel_logueado.Location = new Point(0, 0);
            tableLayoutPanel_logueado.Name = "tableLayoutPanel_logueado";
            tableLayoutPanel_logueado.RowCount = 1;
            tableLayoutPanel_logueado.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_logueado.Size = new Size(1190, 77);
            tableLayoutPanel_logueado.TabIndex = 109;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(895, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(292, 71);
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
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel5, 1, 2);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 77);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.Size = new Size(1190, 693);
            tableLayoutPanel1.TabIndex = 110;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 0, 1);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(62, 37);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 269F));
            tableLayoutPanel2.Size = new Size(1065, 548);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 7;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel3.Controls.Add(panel_uno_dolar, 6, 0);
            tableLayoutPanel3.Controls.Add(panel_cien_dolar, 0, 0);
            tableLayoutPanel3.Controls.Add(panel_dos_dolar, 5, 0);
            tableLayoutPanel3.Controls.Add(panel_cincuenta_dolar, 1, 0);
            tableLayoutPanel3.Controls.Add(panel_cinco_dolar, 4, 0);
            tableLayoutPanel3.Controls.Add(panel_viente_dolar, 2, 0);
            tableLayoutPanel3.Controls.Add(panel_diez_dolar, 3, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(1059, 273);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 6;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel4.Controls.Add(panel_uno_ctvs, 5, 0);
            tableLayoutPanel4.Controls.Add(panel_uno_moneda, 0, 0);
            tableLayoutPanel4.Controls.Add(panel_cinco_ctvs, 4, 0);
            tableLayoutPanel4.Controls.Add(panel_cincuenta_ctvs, 1, 0);
            tableLayoutPanel4.Controls.Add(panel_diez_ctvs, 3, 0);
            tableLayoutPanel4.Controls.Add(panel_veinticinco_ctvs, 2, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 282);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(1059, 263);
            tableLayoutPanel4.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 3;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 356F));
            tableLayoutPanel5.Controls.Add(panel_valor_arqueo, 0, 0);
            tableLayoutPanel5.Controls.Add(panel_valor_total, 1, 0);
            tableLayoutPanel5.Controls.Add(panel_controles, 2, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(62, 591);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(1065, 63);
            tableLayoutPanel5.TabIndex = 1;
            // 
            // BilletesMonedasForm
            // 
            ClientSize = new Size(1190, 782);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tableLayoutPanel_logueado);
            Controls.Add(label_notificacion_cambio);
            Name = "BilletesMonedasForm";
            Text = " ";
            Load += BilletesMonedasForm_Load;
            panel_controles.ResumeLayout(false);
            panel_valor_total.ResumeLayout(false);
            panel_valor_total.PerformLayout();
            panel_valor_arqueo.ResumeLayout(false);
            panel_valor_arqueo.PerformLayout();
            panel_uno_ctvs.ResumeLayout(false);
            panel_uno_ctvs.PerformLayout();
            panel_cinco_ctvs.ResumeLayout(false);
            panel_cinco_ctvs.PerformLayout();
            panel_diez_ctvs.ResumeLayout(false);
            panel_diez_ctvs.PerformLayout();
            panel_veinticinco_ctvs.ResumeLayout(false);
            panel_veinticinco_ctvs.PerformLayout();
            panel_cincuenta_ctvs.ResumeLayout(false);
            panel_cincuenta_ctvs.PerformLayout();
            panel_uno_moneda.ResumeLayout(false);
            panel_uno_moneda.PerformLayout();
            panel_uno_dolar.ResumeLayout(false);
            panel_uno_dolar.PerformLayout();
            panel_dos_dolar.ResumeLayout(false);
            panel_dos_dolar.PerformLayout();
            panel_cinco_dolar.ResumeLayout(false);
            panel_cinco_dolar.PerformLayout();
            panel_diez_dolar.ResumeLayout(false);
            panel_diez_dolar.PerformLayout();
            panel_viente_dolar.ResumeLayout(false);
            panel_viente_dolar.PerformLayout();
            panel_cincuenta_dolar.ResumeLayout(false);
            panel_cincuenta_dolar.PerformLayout();
            panel_cien_dolar.ResumeLayout(false);
            panel_cien_dolar.PerformLayout();
            tableLayoutPanel_logueado.ResumeLayout(false);
            tableLayoutPanel_logueado.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }
        private FontAwesome.Sharp.IconButton button_valor_cincuenta_ctvs;
        private FontAwesome.Sharp.IconButton button_valor_uno_ctvs;
        private FontAwesome.Sharp.IconButton button_valor_cinco_ctvs;
        private FontAwesome.Sharp.IconButton button_valor_diez_ctvs;
        private FontAwesome.Sharp.IconButton button_valor_veinticinco_ctvs;
        private FontAwesome.Sharp.IconButton button_valor_cien;
        private FontAwesome.Sharp.IconButton button_valor_cincuenta;
        private FontAwesome.Sharp.IconButton button_valor_uno;
        private FontAwesome.Sharp.IconButton button_valor_dos;
        private FontAwesome.Sharp.IconButton button_valor_cinco;
        private FontAwesome.Sharp.IconButton button_valor_diez;
        private FontAwesome.Sharp.IconButton button_valor_veinte;
        private Label label_titulo_billetes;
        private FontAwesome.Sharp.IconButton iconButton_regresar;
        private TextBox textBox_100_dollar;
        private TextBox textBox_50_dollar;
        private TextBox textBox_10_dollar;
        private TextBox textBox_20_dollar;
        private TextBox textBox_2_dollar;
        private TextBox textBox_5_dollar;
        private TextBox textBox_1_dollar;
        private TextBox textBox_1_dollar_moneda;
        private TextBox textBox_50_ctvs;
        private TextBox textBox_10_ctvs;
        private TextBox textBox_5_ctvs;
        private TextBox textBox_1_ctvs;
        private Button button_agregar_arqueo_billetes;
        private FontAwesome.Sharp.IconButton button_valor_uno_dolar_moneda;



        private void iconButton_regresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_5_ctvs_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_valor_cien_Click(object sender, EventArgs e)
        {
            int valor_cien = ToInt(textBox_100_dollar.Text);

            int aumentar = valor_cien + 1;

            textBox_100_dollar.Text = aumentar.ToString();
        }

        private void button_valor_cincuenta_Click(object sender, EventArgs e)
        {
            int valor_cincuenta = ToInt(textBox_50_dollar.Text);

            int aumentar = valor_cincuenta + 1;

            textBox_50_dollar.Text = aumentar.ToString();
        }

        private void button_valor_veinte_Click(object sender, EventArgs e)
        {
            int veinte = ToInt(textBox_20_dollar.Text);

            int aumentar = veinte + 1;

            textBox_20_dollar.Text = aumentar.ToString();
        }

        private void button_valor_diez_Click(object sender, EventArgs e)
        {
            int diez = ToInt(textBox_10_dollar.Text);

            int aumentar = diez + 1;

            textBox_10_dollar.Text = aumentar.ToString();
        }

        private void button_valor_cinco_Click(object sender, EventArgs e)
        {
            int cinco = ToInt(textBox_5_dollar.Text);

            int aumentar = cinco + 1;

            textBox_5_dollar.Text = aumentar.ToString();
        }

        private void button_valor_dos_Click(object sender, EventArgs e)
        {
            int dos = ToInt(textBox_2_dollar.Text);

            int aumentar = dos + 1;

            textBox_2_dollar.Text = aumentar.ToString();
        }

        private void button_valor_uno_Click(object sender, EventArgs e)
        {
            int uno = ToInt(textBox_1_dollar.Text);

            int aumentar = uno + 1;

            textBox_1_dollar.Text = aumentar.ToString();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            int uno = ToInt(textBox_1_dollar_moneda.Text);

            int aumentar = uno + 1;

            textBox_1_dollar_moneda.Text = aumentar.ToString();
        }

        private void button_valor_cincuenta_ctvs_Click(object sender, EventArgs e)
        {
            int ciencuenta = ToInt(textBox_50_ctvs.Text);

            int aumentar = ciencuenta + 1;

            textBox_50_ctvs.Text = aumentar.ToString();
        }

        private void button_valor_veinticinco_ctvs_Click(object sender, EventArgs e)
        {
            int veinticinco = ToInt(textBox_25_ctvs.Text);

            int aumentar = veinticinco + 1;

            textBox_25_ctvs.Text = aumentar.ToString();
        }

        private void button_valor_diez_ctvs_Click(object sender, EventArgs e)
        {
            int diez = ToInt(textBox_10_ctvs.Text);

            int aumentar = diez + 1;

            textBox_10_ctvs.Text = aumentar.ToString();
        }

        private void button_valor_cinco_ctvs_Click(object sender, EventArgs e)
        {
            int cinco = ToInt(textBox_5_ctvs.Text);

            int aumentar = cinco + 1;

            textBox_5_ctvs.Text = aumentar.ToString();
        }

        private void button_valor_uno_ctvs_Click(object sender, EventArgs e)
        {
            int uno = ToInt(textBox_1_ctvs.Text);

            int aumentar = uno + 1;

            textBox_1_ctvs.Text = aumentar.ToString();
        }

        private void button_agregar_arqueo_billetes_Click(object sender, EventArgs e)
        {
            var arqueo = new arqueo_billetesM
            {
                arqueo_id = SessionArqueoCaja.id_arqueo_caja,
                estado = SessionArqueoCaja.estadoArqueo,
                billetes_100 = ToInt(textBox_100_dollar.Text),
                billetes_50 = ToInt(textBox_50_dollar.Text),
                billetes_20 = ToInt(textBox_20_dollar.Text),
                billetes_10 = ToInt(textBox_10_dollar.Text),
                billetes_5 = ToInt(textBox_5_dollar.Text),
                billetes_1 = ToInt(textBox_1_dollar.Text),
                monedas_1 = ToInt(textBox_1_dollar_moneda.Text),
                centavos_50 = ToInt(textBox_50_ctvs.Text),
                centavos_25 = ToInt(textBox_25_ctvs.Text),
                centavos_10 = ToInt(textBox_10_ctvs.Text),
                centavos_5 = ToInt(textBox_5_ctvs.Text),
                centavos_1 = ToInt(textBox_1_ctvs.Text)
            };

            // Limpiar el símbolo de $ y espacios


            // Convertir usando CultureInfo que tenga coma como decimal
            // Obtener valores normalizados
            decimal valorArqueo = _FuncionesGenerales.ParseDecimalFromTextBoxNormalizado(label_total_monto_arqueo_valor.Text);
            decimal valorTotal = _FuncionesGenerales.ParseDecimalFromTextBoxNormalizado(label_total_monto_valor.Text);

            // Comparar con tolerancia
            if (Math.Abs(valorArqueo - valorTotal) < 0.01m) // m para literal decimal
            {
                // Insertar arqueo
                _ArqueoBilletesController.Insertar(arqueo);

                // Mensaje según estado del arqueo
                if (SessionArqueoCaja.estadoArqueo == "A")
                {
                    StylesAlertas.MostrarAlerta(this, "Los valores son iguales ✅\nSe creó correctamente la apertura", tipo: TipoAlerta.Success);
                }
                else if (SessionArqueoCaja.estadoArqueo == "C")
                {
                    _ArqueoCajaController.ActualizarTotalEnCaja(SessionArqueoCaja.id_arqueo_caja, SessionArqueoCaja.montoValidar);
                    StylesAlertas.MostrarAlerta(this, "Los valores son iguales ✅\nSe creó correctamente la apertura", tipo: TipoAlerta.Success);
                }

                // Cerrar formulario con OK
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                StylesAlertas.MostrarAlerta(this, "Los valores NO coinciden ❌", "¡Error!", TipoAlerta.Error);
            }

        }
    }
}
