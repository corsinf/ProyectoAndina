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
    public partial class TransaccionesForm : Form
    {
        private readonly TransaccionCajaController _transaccionCajaController;
        private readonly StyleTablas _styleTablas = new StyleTablas();
        public TransaccionesForm()
        {
            _transaccionCajaController = new TransaccionCajaController();
            InitializeComponent();
            CargarTransaccionesTable();
            this.Paint += TransaccionesForm_Paint;
            this.DoubleBuffered = true;
            // se despliega en toda la pantalla
            this.WindowState = FormWindowState.Maximized;

        }

        private void CargarTransaccionesTable()
        {
            try
            {
                var transacciones = _transaccionCajaController.ObtenerTodas();
                var panel = tableLayoutPanel_transacciones;

                panel.SuspendLayout();
                panel.Controls.Clear();
                panel.RowStyles.Clear();
                panel.ColumnStyles.Clear();
                panel.ColumnCount = 5; // ID, Fecha, Cliente, Valor, Tipo Pago
                panel.RowCount = 1;
                panel.AutoScroll = true;
                panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                panel.BackColor = Color.FromArgb(245, 245, 245);

                // --- Configuración columnas ---
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 0));   // ID (oculto)
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));  // Fecha
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));  // Cliente
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));  // Valor
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));  // Tipo Pago
                panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));

                // --- Encabezados ---
                _styleTablas.AgregarCelda(panel, "", 0, 0, true);
                _styleTablas.AgregarCelda(panel, "Fecha", 1, 0, true);
                _styleTablas.AgregarCelda(panel, "Cliente", 2, 0, true);
                _styleTablas.AgregarCelda(panel, "Valor", 3, 0, true);
                _styleTablas.AgregarCelda(panel, "Tipo Pago", 4, 0, true);

                // --- Llenar datos ---
                int fila = 1;
                foreach (var t in transacciones)
                {
                    panel.RowCount++;
                    panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));

                    _styleTablas.AgregarCelda(panel, t.trans_id.ToString(), 0, fila);
                    _styleTablas.AgregarCelda(panel, t.fecha_transaccion.ToString("dd/MM/yyyy HH:mm"), 1, fila);
                    _styleTablas.AgregarCelda(panel, t.per_id_cliente.ToString(), 2, fila);
                    _styleTablas.AgregarCelda(panel, t.valor_a_cobrar.ToString("C2"), 3, fila);
                    _styleTablas.AgregarCelda(panel, t.tipo_pago_id.ToString(), 4, fila);

                    fila++;
                }

                panel.ResumeLayout(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar transacciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void TransaccionesForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }

        private void InitializeComponent()
        {
            tableLayoutPanel_logueado = new TableLayoutPanel();
            label_titulo_arqueos_cajas = new Label();
            button_regresar = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel_crear = new Panel();
            tableLayoutPanel_transacciones = new TableLayoutPanel();
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
            tableLayoutPanel_logueado.Size = new Size(1108, 77);
            tableLayoutPanel_logueado.TabIndex = 110;
            // 
            // label_titulo_arqueos_cajas
            // 
            label_titulo_arqueos_cajas.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_arqueos_cajas.AutoSize = true;
            label_titulo_arqueos_cajas.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_arqueos_cajas.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_arqueos_cajas.Location = new Point(280, 20);
            label_titulo_arqueos_cajas.Name = "label_titulo_arqueos_cajas";
            label_titulo_arqueos_cajas.Size = new Size(548, 37);
            label_titulo_arqueos_cajas.TabIndex = 79;
            label_titulo_arqueos_cajas.Text = "Listado de Arqueos Cajas";
            label_titulo_arqueos_cajas.TextAlign = ContentAlignment.MiddleCenter;
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
            panel1.Location = new Point(834, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(271, 71);
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
            tableLayoutPanel1.Controls.Add(tableLayoutPanel_transacciones, 2, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 77);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.Size = new Size(1108, 440);
            tableLayoutPanel1.TabIndex = 111;
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
            tableLayoutPanel2.Size = new Size(242, 390);
            tableLayoutPanel2.TabIndex = 9;
            // 
            // panel_crear
            // 
            panel_crear.BackColor = Color.Transparent;
            panel_crear.Dock = DockStyle.Fill;
            panel_crear.Location = new Point(3, 165);
            panel_crear.Name = "panel_crear";
            panel_crear.Size = new Size(236, 222);
            panel_crear.TabIndex = 78;
            // 
            // tableLayoutPanel_transacciones
            // 
            tableLayoutPanel_transacciones.ColumnCount = 2;
            tableLayoutPanel_transacciones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_transacciones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_transacciones.Dock = DockStyle.Fill;
            tableLayoutPanel_transacciones.Location = new Point(310, 25);
            tableLayoutPanel_transacciones.Name = "tableLayoutPanel_transacciones";
            tableLayoutPanel_transacciones.RowCount = 2;
            tableLayoutPanel_transacciones.RowStyles.Add(new RowStyle(SizeType.Percent, 50.56818F));
            tableLayoutPanel_transacciones.RowStyles.Add(new RowStyle(SizeType.Percent, 49.43182F));
            tableLayoutPanel_transacciones.Size = new Size(733, 390);
            tableLayoutPanel_transacciones.TabIndex = 8;
            // 
            // TransaccionesForm
            // 
            ClientSize = new Size(1108, 517);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tableLayoutPanel_logueado);
            Name = "TransaccionesForm";
            tableLayoutPanel_logueado.ResumeLayout(false);
            tableLayoutPanel_logueado.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);

        }

        private void button_regresar_Click(object sender, EventArgs e)
        {
            var AdministracionFrom = new AdministracionFrom();
            this.Hide();                 // Opcional: ocultas la ventana actual
            AdministracionFrom.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
            this.Close();
        }

        private TableLayoutPanel tableLayoutPanel_logueado;
        private Label label_titulo_arqueos_cajas;
        private FontAwesome.Sharp.IconButton button_regresar;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel_crear;
        private TableLayoutPanel tableLayoutPanel_transacciones;
        private PictureBox pictureBox1;
    }
}
