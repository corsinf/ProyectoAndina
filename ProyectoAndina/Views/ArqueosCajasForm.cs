using ProyectoAndina.Controllers;
using ProyectoAndina.Funciones_Generales;
using ProyectoAndina.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAndina.Views
{
    public partial class ArqueosCajasForm : Form
    {

        private readonly ArqueoCajaController _ArqueoCajaController;
        private readonly StyleTablas _styleTablas = new StyleTablas();
        private TableLayoutPanel tableLayoutPanel_logueado;
        private FontAwesome.Sharp.IconButton button_regresar;
        private Panel panel1;
        private PictureBox pictureBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel_crear;
        private TableLayoutPanel tableLayoutPanel_arqueos_cajas;
        private Label label_titulo_arqueos_cajas;
        public int id_arqueo_caja;
        public ArqueosCajasForm()
        {
            _ArqueoCajaController = new ArqueoCajaController();

            InitializeComponent();

            CargarArqueosCajaTable();

            ConfigurarEstilo();
            this.Paint += ArqueosCajasForm_Paint;
            this.DoubleBuffered = true;
            // se despliega en toda la pantalla
            this.WindowState = FormWindowState.Maximized;

            _styleTablas.OnIdSeleccionado = (id) =>
            {
                id_arqueo_caja = id;
                seleccionarArqueoCaja(id);
            };

        }

        private void ArqueosCajasForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }

        public void ConfigurarEstilo()
        {
            StyleManager.ConfigurarFormPrincipal(this, "Menu de Roles");
            this.BackColor = StyleManager.Colors.GrisClaro;

            // Configurar labels con estilos UASB
            StyleManager.ConfigurarLabel(label_titulo_arqueos_cajas, TipoLabel.TituloGrande);
            StyleManager.ConfigurarBotonPrincipalIcono(
              button_regresar,
              FontAwesome.Sharp.IconChar.SignOutAlt,
              "Regresar",
              colorFondo: Color.FromArgb(231, 76, 60)
              );

        }


        public void CargarArqueosCajaTable()
        {
            try
            {
                var _todasLasArqueosCajas = _ArqueoCajaController.ObtenerArqueosConRoles();

                var panel = tableLayoutPanel_arqueos_cajas; // Asegúrate que este TableLayoutPanel exista

                panel.SuspendLayout();
                panel.Controls.Clear();
                panel.RowStyles.Clear();
                panel.ColumnStyles.Clear();

                panel.ColumnCount = 6;
                panel.RowCount = 1;
                panel.AutoScroll = true;
                panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                panel.BackColor = Color.FromArgb(245, 245, 245);

                // Definición de columnas (ajústalas según tu modelo)
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0));   // ID oculto
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F)); // Caja
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F)); // Fecha Apertura
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F)); // Fecha Cierre
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F)); // Monto Inicial
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F)); // Estado

                panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));

                // Encabezados
                _styleTablas.AgregarCelda(panel, "ID", 0, 0, false);
                _styleTablas.AgregarCelda(panel, "Nombre Persona", 1, 0, true);
                _styleTablas.AgregarCelda(panel, "valor apertura", 2, 0, true);
                _styleTablas.AgregarCelda(panel, "valor cierre", 3, 0, true);
                _styleTablas.AgregarCelda(panel, "Nombre Rol", 4, 0, true);
                _styleTablas.AgregarCelda(panel, "Estado", 5, 0, true);

                int fila = 1;
                foreach (var arqueo in _todasLasArqueosCajas)
                {
                    panel.RowCount++;
                    panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));

                    _styleTablas.AgregarCelda(panel, arqueo.arqueo_id.ToString() ?? "N/A", 0, fila);
                    _styleTablas.AgregarCelda(panel, arqueo.primer_nombre.ToString() ?? "N/A", 1, fila);
                    _styleTablas.AgregarCelda(panel, arqueo.monto_inicial.ToString() ?? "N/A", 2, fila);
                    _styleTablas.AgregarCelda(panel, arqueo.monto_final.ToString() ?? "N/A", 3, fila);
                    _styleTablas.AgregarCelda(panel, arqueo.nombre_rol.ToString() ?? "N/A", 4, fila);
                    _styleTablas.AgregarCelda(panel, arqueo.estado ?? "N/A", 5, fila);

                    fila++;
                }

                panel.ResumeLayout(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar arqueos de cajas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void seleccionarArqueoCaja(int id_arqueo)
        {
            var arqueo_Seleccionado = _ArqueoCajaController.ObtenerPorId(id_arqueo);

            if (arqueo_Seleccionado != null)
            {

            }

        }

        private void InitializeComponent()
        {
            tableLayoutPanel_logueado = new TableLayoutPanel();
            button_regresar = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel_crear = new Panel();
            tableLayoutPanel_arqueos_cajas = new TableLayoutPanel();
            label_titulo_arqueos_cajas = new Label();
            tableLayoutPanel_logueado.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
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
            tableLayoutPanel_logueado.Controls.Add(button_regresar, 0, 0);
            tableLayoutPanel_logueado.Controls.Add(panel1, 2, 0);
            tableLayoutPanel_logueado.Dock = DockStyle.Top;
            tableLayoutPanel_logueado.Location = new Point(0, 0);
            tableLayoutPanel_logueado.Name = "tableLayoutPanel_logueado";
            tableLayoutPanel_logueado.RowCount = 1;
            tableLayoutPanel_logueado.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_logueado.Size = new Size(1091, 77);
            tableLayoutPanel_logueado.TabIndex = 109;
            tableLayoutPanel_logueado.Click += iconButton_regresar_Click;
            // 
            // button_regresar
            // 
            button_regresar.BackColor = Color.FromArgb(41, 128, 185);
            button_regresar.Cursor = Cursors.Hand;
            button_regresar.FlatAppearance.BorderSize = 0;
            button_regresar.FlatStyle = FlatStyle.Flat;
            button_regresar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_regresar.ForeColor = Color.White;
            button_regresar.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            button_regresar.IconColor = Color.White;
            button_regresar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            button_regresar.IconSize = 24;
            button_regresar.Location = new Point(3, 3);
            button_regresar.Name = "button_regresar";
            button_regresar.Size = new Size(232, 63);
            button_regresar.TabIndex = 29;
            button_regresar.Text = "  Regresar";
            button_regresar.TextAlign = ContentAlignment.MiddleRight;
            button_regresar.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_regresar.UseVisualStyleBackColor = false;
            button_regresar.Click += button_regresar_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(820, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(268, 71);
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
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.405406F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.4137936F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.6969147F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.405405F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel_arqueos_cajas, 2, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 77);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.Size = new Size(1091, 442);
            tableLayoutPanel1.TabIndex = 110;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(panel_crear, 0, 2);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(62, 25);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 227F));
            tableLayoutPanel2.Size = new Size(238, 391);
            tableLayoutPanel2.TabIndex = 9;
            // 
            // panel_crear
            // 
            panel_crear.BackColor = Color.Transparent;
            panel_crear.Dock = DockStyle.Fill;
            panel_crear.Location = new Point(3, 167);
            panel_crear.Name = "panel_crear";
            panel_crear.Size = new Size(232, 221);
            panel_crear.TabIndex = 78;
            // 
            // tableLayoutPanel_arqueos_cajas
            // 
            tableLayoutPanel_arqueos_cajas.ColumnCount = 2;
            tableLayoutPanel_arqueos_cajas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_arqueos_cajas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_arqueos_cajas.Dock = DockStyle.Fill;
            tableLayoutPanel_arqueos_cajas.Location = new Point(306, 25);
            tableLayoutPanel_arqueos_cajas.Name = "tableLayoutPanel_arqueos_cajas";
            tableLayoutPanel_arqueos_cajas.RowCount = 2;
            tableLayoutPanel_arqueos_cajas.RowStyles.Add(new RowStyle(SizeType.Percent, 50.56818F));
            tableLayoutPanel_arqueos_cajas.RowStyles.Add(new RowStyle(SizeType.Percent, 49.43182F));
            tableLayoutPanel_arqueos_cajas.Size = new Size(722, 391);
            tableLayoutPanel_arqueos_cajas.TabIndex = 8;
            // 
            // label_titulo_arqueos_cajas
            // 
            label_titulo_arqueos_cajas.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_arqueos_cajas.AutoSize = true;
            label_titulo_arqueos_cajas.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_arqueos_cajas.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_arqueos_cajas.Location = new Point(275, 20);
            label_titulo_arqueos_cajas.Name = "label_titulo_arqueos_cajas";
            label_titulo_arqueos_cajas.Size = new Size(539, 37);
            label_titulo_arqueos_cajas.TabIndex = 79;
            label_titulo_arqueos_cajas.Text = "Listado de Arqueos Cajas";
            label_titulo_arqueos_cajas.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ArqueosCajasForm
            // 
            ClientSize = new Size(1091, 519);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tableLayoutPanel_logueado);
            Name = "ArqueosCajasForm";
            tableLayoutPanel_logueado.ResumeLayout(false);
            tableLayoutPanel_logueado.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);

        }

        private void iconButton_regresar_Click(object sender, EventArgs e)
        {
            var AdministracionFrom = new AdministracionFrom();
            this.Hide();                 // Opcional: ocultas la ventana actual
            AdministracionFrom.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
            this.Close();
        }

        private void button_regresar_Click(object sender, EventArgs e)
        {
            var AdministracionFrom = new AdministracionFrom();
            this.Hide();                 // Opcional: ocultas la ventana actual
            AdministracionFrom.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
            this.Close();
        }
    }
}
