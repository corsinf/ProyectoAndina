using ProyectoAndina.Controllers;
using ProyectoAndina.Funciones_Generales;
using ProyectoAndina.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProyectoAndina.Utils.StylesAlertas;

namespace ProyectoAndina.Views
{
    public partial class CajaForm : Form
    {

        private readonly CajaController _CajaController;
        private readonly StyleTablas _styleTablas = new StyleTablas();
        private TableLayoutPanel tableLayoutPanel_logueado;
        private FontAwesome.Sharp.IconButton button_regresar;
        private Panel panel1;
        private PictureBox pictureBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel_crear;
        private Button button_agregar_caja;
        private Label label_titulo_acciones;
        private TableLayoutPanel tableLayoutPanel_caja;
        private Label label_titulo_cajas;
        public int caja_id;

        public CajaForm()
        {
            InitializeComponent();
            _CajaController = new CajaController();

            CargarCajaTable();
            ConfigurarEstilo();
            this.Paint += CajaFormForm_Paint;
            this.DoubleBuffered = true;
            // se despliega en toda la pantalla
            this.WindowState = FormWindowState.Maximized;

            // Nuevo: Configurar evento de editar
            _styleTablas.OnEditarClicked = (id) =>
            {
                AbrirFormularioEdicion(id);
            };

            // Nuevo: Configurar evento de eliminar
            _styleTablas.OnEliminarClicked = (id) =>
            {
                ConfirmarEliminarRol(id);
            };
        }


        private void AbrirFormularioEdicion(int idCaja)
        {

            var CajaCrudForm = new CajaCrudForm(idCaja, this);
            CajaCrudForm.StartPosition = FormStartPosition.CenterParent;

            DialogResult resultado = CajaCrudForm.ShowDialog(this);

            if (CajaCrudForm.DialogResult == DialogResult.OK)
            {
                CargarCajaTable();

            }


        }

        // Método para confirmar eliminación
        private void ConfirmarEliminarRol(int idCaja)
        {
            try
            {
                var resultado = MessageBox.Show(
                    $"¿Estás seguro de que quieres eliminar el rol con ID {idCaja}?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    MessageBox.Show($"Rol con ID {idCaja} eliminado correctamente.", "Éxito",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _CajaController.Eliminar(idCaja);
                    StylesAlertas.MostrarAlerta(this, "Registro eliminado correctamente", tipo: TipoAlerta.Success);
                    CargarCajaTable();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar rol: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CajaFormForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }

        public void ConfigurarEstilo()
        {
            StyleManager.ConfigurarFormPrincipal(this, "Menu de Roles");
            this.BackColor = StyleManager.Colors.GrisClaro;



            // Configurar labels con estilos UASB
            StyleManager.ConfigurarLabel(label_titulo_cajas, TipoLabel.TituloGrande);
            StyleManager.ConfigurarLabel(label_titulo_acciones, TipoLabel.TituloMedio);

            // esto es de los labels


            // este es de los inputs
            //configurar los botones
            StyleManager.ConfigurarBotonIconoEnPanel(panel_crear, button_agregar_caja, FontAwesome.Sharp.IconChar.PlusCircle, Color.MediumAquamarine);

            // Configurar panel principal con sombra
            StyleManager.ConfigurarBotonPrincipalIcono(
             button_regresar,
             FontAwesome.Sharp.IconChar.ArrowLeft,
             "Regresar",
             colorFondo: Color.FromArgb(231, 76, 60)
             );



        }


        

        public void seleccionarCaja(int id)
        {

            var caja = _CajaController.ObtenerPorId(id);

        }


        public void CargarCajaTable()
        {
            try
            {
                var todasLasCajas = _CajaController.ObtenerTodas();
                var panel = tableLayoutPanel_caja;
                panel.SuspendLayout();
                panel.Controls.Clear();
                panel.RowStyles.Clear();
                panel.ColumnStyles.Clear();
                panel.ColumnCount = 6; // Aumentamos a 6 columnas (agregamos columna de acciones)
                panel.RowCount = 1;
                panel.AutoScroll = true;
                panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                panel.BackColor = Color.FromArgb(245, 245, 245);

                // Configuración de columnas
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 0)); // ID (oculto)
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F)); // Código
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F)); // Nombre
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F)); // Ubicación
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F)); // IP
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F)); // Acciones
                panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));

                // Encabezados
                _styleTablas.AgregarCelda(panel, "", 0, 0, true); // ID oculto
                _styleTablas.AgregarCelda(panel, "Código", 1, 0, true);
                _styleTablas.AgregarCelda(panel, "Nombre", 2, 0, true);
                _styleTablas.AgregarCelda(panel, "Ubicación", 3, 0, true);
                _styleTablas.AgregarCelda(panel, "IP Equipo", 4, 0, true);
                _styleTablas.AgregarCelda(panel, "Acciones", 5, 0, true);

                int fila = 1;
                foreach (var caja in todasLasCajas)
                {
                    panel.RowCount++;
                    panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F)); // Aumentamos altura para los botones

                    _styleTablas.AgregarCelda(panel, caja.caja_id.ToString(), 0, fila);
                    _styleTablas.AgregarCelda(panel, caja.codigo ?? "N/A", 1, fila);
                    _styleTablas.AgregarCelda(panel, caja.nombre ?? "N/A", 2, fila);
                    _styleTablas.AgregarCelda(panel, caja.ubicacion ?? "N/A", 3, fila);
                    _styleTablas.AgregarCelda(panel, caja.ip_equipo ?? "N/A", 4, fila);

                    // Agregar panel de botones de acción
                    _styleTablas.AgregarPanelAcciones(panel, caja.caja_id, 5, fila);

                    fila++;
                }
                panel.ResumeLayout(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar cajas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void InitializeComponent()
        {
            tableLayoutPanel_logueado = new TableLayoutPanel();
            button_regresar = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel_crear = new Panel();
            button_agregar_caja = new Button();
            label_titulo_acciones = new Label();
            tableLayoutPanel_caja = new TableLayoutPanel();
            label_titulo_cajas = new Label();
            tableLayoutPanel_logueado.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel_crear.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel_logueado
            // 
            tableLayoutPanel_logueado.BackColor = Color.Transparent;
            tableLayoutPanel_logueado.ColumnCount = 3;
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_logueado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel_logueado.Controls.Add(label_titulo_cajas, 1, 0);
            tableLayoutPanel_logueado.Controls.Add(button_regresar, 0, 0);
            tableLayoutPanel_logueado.Controls.Add(panel1, 2, 0);
            tableLayoutPanel_logueado.Dock = DockStyle.Top;
            tableLayoutPanel_logueado.Location = new Point(0, 0);
            tableLayoutPanel_logueado.Name = "tableLayoutPanel_logueado";
            tableLayoutPanel_logueado.RowCount = 1;
            tableLayoutPanel_logueado.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_logueado.Size = new Size(1087, 77);
            tableLayoutPanel_logueado.TabIndex = 109;
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
            button_regresar.Click += iconButton_regresar_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(817, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(267, 71);
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
            tableLayoutPanel1.Controls.Add(tableLayoutPanel_caja, 2, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 77);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.Size = new Size(1087, 488);
            tableLayoutPanel1.TabIndex = 110;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(panel_crear, 0, 2);
            tableLayoutPanel2.Controls.Add(label_titulo_acciones, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(61, 27);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 227F));
            tableLayoutPanel2.Size = new Size(237, 433);
            tableLayoutPanel2.TabIndex = 9;
            // 
            // panel_crear
            // 
            panel_crear.BackColor = Color.Transparent;
            panel_crear.Controls.Add(button_agregar_caja);
            panel_crear.Dock = DockStyle.Fill;
            panel_crear.Location = new Point(3, 209);
            panel_crear.Name = "panel_crear";
            panel_crear.Size = new Size(231, 221);
            panel_crear.TabIndex = 78;
            // 
            // button_agregar_caja
            // 
            button_agregar_caja.BackColor = Color.FromArgb(52, 152, 219);
            button_agregar_caja.Cursor = Cursors.Hand;
            button_agregar_caja.FlatAppearance.BorderSize = 0;
            button_agregar_caja.FlatStyle = FlatStyle.Flat;
            button_agregar_caja.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_agregar_caja.ForeColor = Color.White;
            button_agregar_caja.Location = new Point(35, 47);
            button_agregar_caja.Name = "button_agregar_caja";
            button_agregar_caja.Size = new Size(135, 58);
            button_agregar_caja.TabIndex = 24;
            button_agregar_caja.Text = "Agregar";
            button_agregar_caja.UseVisualStyleBackColor = false;
            button_agregar_caja.Click += button_agregar_caja_Click;
            // 
            // label_titulo_acciones
            // 
            label_titulo_acciones.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_acciones.AutoSize = true;
            label_titulo_acciones.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_acciones.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_acciones.Location = new Point(3, 136);
            label_titulo_acciones.Name = "label_titulo_acciones";
            label_titulo_acciones.Size = new Size(231, 37);
            label_titulo_acciones.TabIndex = 28;
            label_titulo_acciones.Text = "Acciones";
            // 
            // tableLayoutPanel_caja
            // 
            tableLayoutPanel_caja.ColumnCount = 2;
            tableLayoutPanel_caja.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_caja.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_caja.Dock = DockStyle.Fill;
            tableLayoutPanel_caja.Location = new Point(304, 27);
            tableLayoutPanel_caja.Name = "tableLayoutPanel_caja";
            tableLayoutPanel_caja.RowCount = 2;
            tableLayoutPanel_caja.RowStyles.Add(new RowStyle(SizeType.Percent, 50.56818F));
            tableLayoutPanel_caja.RowStyles.Add(new RowStyle(SizeType.Percent, 49.43182F));
            tableLayoutPanel_caja.Size = new Size(719, 433);
            tableLayoutPanel_caja.TabIndex = 8;
            // 
            // label_titulo_cajas
            // 
            label_titulo_cajas.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_cajas.AutoSize = true;
            label_titulo_cajas.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_cajas.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_cajas.Location = new Point(274, 20);
            label_titulo_cajas.Name = "label_titulo_cajas";
            label_titulo_cajas.Size = new Size(537, 37);
            label_titulo_cajas.TabIndex = 79;
            label_titulo_cajas.Text = "Listado de Cajas";
            label_titulo_cajas.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CajaForm
            // 
            ClientSize = new Size(1087, 565);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tableLayoutPanel_logueado);
            Name = "CajaForm";
            Load += CajaForm_Load;
            tableLayoutPanel_logueado.ResumeLayout(false);
            tableLayoutPanel_logueado.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel_crear.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void iconButton_regresar_Click(object sender, EventArgs e)
        {
            var AdministracionFrom = new AdministracionFrom();
            this.Hide();                 // Opcional: ocultas la ventana actual
            AdministracionFrom.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
            this.Close();
        }

        private void CajaForm_Load(object sender, EventArgs e)
        {

        }

        private void button_agregar_caja_Click(object sender, EventArgs e)
        {
            var CajaCrudForm = new CajaCrudForm(0, this);
            CajaCrudForm.StartPosition = FormStartPosition.CenterParent;
            CajaCrudForm.FormClosed += (s, args) =>
            {
                CargarCajaTable();
            };

            CajaCrudForm.ShowDialog(this);
        }

        
    }
}
