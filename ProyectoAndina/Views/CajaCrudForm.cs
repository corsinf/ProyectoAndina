using ProyectoAndina.Controllers;
using ProyectoAndina.Funciones_Generales;
using ProyectoAndina.Models;
using ProyectoAndina.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static ProyectoAndina.Utils.StylesAlertas;

namespace ProyectoAndina.Views
{

    public partial class CajaCrudForm : Form
    {

        private readonly CajaController _CajaController;
        public int caja_id;
        private Label label_codigo;
        private TextBox textBox_codigo;
        private Label label_error_nombre;
        private TextBox textBox_ubicacion;
        private Label label_nombre;
        private Label label_ubicacion;
        private TextBox textBox_nombre;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox_logo_tipo;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        private Panel panel_button_accion;
        private Form _formularioPadre;
        public CajaCrudForm(int id , Form formularioPadre = null)
        {
            InitializeComponent();
            _CajaController = new CajaController();
            this.Paint += CajaCrudForm_Paint;
            this.DoubleBuffered = true;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            _formularioPadre = formularioPadre;


            if (id == 0)
            {
                LimpiarCampos();
            }
            else
            {
                cargarDatosCaja(id);
                caja_id = id;
            }
        }
        private void CajaCrudForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }

        public void cargarDatosCaja(int id)
        {
            button_accion.Text = "Actualizar";
            var caja = _CajaController.ObtenerPorId(id);

            if (caja != null)
            {
                StyleManager.ConfigurarBotonIconoEnPanel(
    panel_button_accion,
    button_accion,
    FontAwesome.Sharp.IconChar.Rotate,
    Color.LightSteelBlue // azul pastel → refrescar / acción
);

                textBox_nombre.Text = caja.nombre;
                textBox_codigo.Text = caja.codigo;
                textBox_ubicacion.Text = caja.ubicacion;
            }
            else {
                StyleManager.ConfigurarBotonIconoEnPanel(
    panel_button_accion,
    button_accion,
    FontAwesome.Sharp.IconChar.PlusCircle,
    Color.MediumAquamarine // verde pastel → agregar / crear
);

            }
        }

        public void LimpiarCampos()
        {

            button_accion.Text = "Crear";
            textBox_nombre.Text = "";
            textBox_codigo.Text = "";
            textBox_ubicacion.Text = "";
        }

        private void InitializeComponent()
        {
            button_accion = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBox_logo_tipo = new PictureBox();
            textBox_nombre = new TextBox();
            label_ubicacion = new Label();
            label_nombre = new Label();
            textBox_ubicacion = new TextBox();
            label_error_nombre = new Label();
            textBox_codigo = new TextBox();
            label_codigo = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel1 = new Panel();
            panel_button_accion = new Panel();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_tipo).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            panel_button_accion.SuspendLayout();
            SuspendLayout();
            // 
            // button_accion
            // 
            button_accion.BackColor = Color.FromArgb(52, 152, 219);
            button_accion.Cursor = Cursors.Hand;
            button_accion.FlatAppearance.BorderSize = 0;
            button_accion.FlatStyle = FlatStyle.Flat;
            button_accion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_accion.ForeColor = Color.White;
            button_accion.Location = new Point(132, 42);
            button_accion.Name = "button_accion";
            button_accion.Size = new Size(145, 40);
            button_accion.TabIndex = 27;
            button_accion.Text = "Accion";
            button_accion.UseVisualStyleBackColor = false;
            button_accion.Click += button_accion_Click;
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
            tableLayoutPanel1.Size = new Size(409, 75);
            tableLayoutPanel1.TabIndex = 86;
            // 
            // pictureBox_logo_tipo
            // 
            pictureBox_logo_tipo.BackColor = Color.White;
            pictureBox_logo_tipo.Image = Properties.Resources.Logotipo_color;
            pictureBox_logo_tipo.Location = new Point(3, 3);
            pictureBox_logo_tipo.Name = "pictureBox_logo_tipo";
            pictureBox_logo_tipo.Size = new Size(391, 62);
            pictureBox_logo_tipo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_logo_tipo.TabIndex = 66;
            pictureBox_logo_tipo.TabStop = false;
            // 
            // textBox_nombre
            // 
            textBox_nombre.Location = new Point(227, 92);
            textBox_nombre.Name = "textBox_nombre";
            textBox_nombre.Size = new Size(125, 27);
            textBox_nombre.TabIndex = 15;
            textBox_nombre.Click += textBox_nombre_Click;
            // 
            // label_ubicacion
            // 
            label_ubicacion.AutoSize = true;
            label_ubicacion.Location = new Point(60, 134);
            label_ubicacion.Name = "label_ubicacion";
            label_ubicacion.Size = new Size(78, 20);
            label_ubicacion.TabIndex = 16;
            label_ubicacion.Text = "Ubicación:";
            label_ubicacion.Click += label_ubicacion_Click;
            // 
            // label_nombre
            // 
            label_nombre.AutoSize = true;
            label_nombre.Location = new Point(227, 57);
            label_nombre.Name = "label_nombre";
            label_nombre.Size = new Size(67, 20);
            label_nombre.TabIndex = 14;
            label_nombre.Text = "Nombre:";
            // 
            // textBox_ubicacion
            // 
            textBox_ubicacion.Location = new Point(60, 169);
            textBox_ubicacion.Name = "textBox_ubicacion";
            textBox_ubicacion.Size = new Size(268, 27);
            textBox_ubicacion.TabIndex = 17;
            textBox_ubicacion.Click += textBox_ubicacion_Click;
            // 
            // label_error_nombre
            // 
            label_error_nombre.AutoSize = true;
            label_error_nombre.Location = new Point(227, 134);
            label_error_nombre.Name = "label_error_nombre";
            label_error_nombre.Size = new Size(0, 20);
            label_error_nombre.TabIndex = 29;
            // 
            // textBox_codigo
            // 
            textBox_codigo.Location = new Point(60, 92);
            textBox_codigo.Name = "textBox_codigo";
            textBox_codigo.Size = new Size(125, 27);
            textBox_codigo.TabIndex = 13;
            textBox_codigo.Click += textBox_codigo_Click;
            // 
            // label_codigo
            // 
            label_codigo.AutoSize = true;
            label_codigo.Location = new Point(60, 57);
            label_codigo.Name = "label_codigo";
            label_codigo.Size = new Size(61, 20);
            label_codigo.TabIndex = 12;
            label_codigo.Text = "Codigo:";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.Transparent;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(panel1, 0, 0);
            tableLayoutPanel2.Controls.Add(panel_button_accion, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 75);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 128F));
            tableLayoutPanel2.Size = new Size(409, 428);
            tableLayoutPanel2.TabIndex = 87;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(label_codigo);
            panel1.Controls.Add(textBox_codigo);
            panel1.Controls.Add(textBox_nombre);
            panel1.Controls.Add(label_ubicacion);
            panel1.Controls.Add(label_nombre);
            panel1.Controls.Add(label_error_nombre);
            panel1.Controls.Add(textBox_ubicacion);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(403, 294);
            panel1.TabIndex = 82;
            // 
            // panel_button_accion
            // 
            panel_button_accion.BackColor = Color.Transparent;
            panel_button_accion.Controls.Add(button_accion);
            panel_button_accion.Dock = DockStyle.Fill;
            panel_button_accion.Location = new Point(3, 303);
            panel_button_accion.Name = "panel_button_accion";
            panel_button_accion.Size = new Size(403, 122);
            panel_button_accion.TabIndex = 83;
            // 
            // CajaCrudForm
            // 
            ClientSize = new Size(409, 503);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            Name = "CajaCrudForm";
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_tipo).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel_button_accion.ResumeLayout(false);
            ResumeLayout(false);

        }
        private Button button_accion;

        private void label_ubicacion_Click(object sender, EventArgs e)
        {

        }

        private void button_accion_Click(object sender, EventArgs e)
        {
            var codigo = textBox_codigo.Text.Trim();
            var nombre = textBox_nombre.Text.Trim();
            var ubicacion = textBox_ubicacion.Text.Trim();
            var ip_equipo = ObtenerIpLocal();


            var Caja = new CajaM
            {
                codigo = codigo,
                nombre = nombre,
                ubicacion = ubicacion,
                ip_equipo = ip_equipo,
                estado = true,
                fecha_creacion = DateTime.Now
            };


            var accion = button_accion.Text;
            if (accion == "Crear")
            {
                _CajaController.Insertar(Caja);
                StylesAlertas.MostrarAlerta(this, "Registro creado correctamente", tipo: TipoAlerta.Success);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {

                Caja.caja_id = caja_id;
                _CajaController.Actualizar(Caja);
                StylesAlertas.MostrarAlerta(this, "Registro actualizado correctamente", tipo: TipoAlerta.Success);
                this.DialogResult = DialogResult.OK; // opcional, útil si quieres saber desde el form padre que se creó
                this.Close();
            }
        }

        private string ObtenerIpLocal()
        {
            string nombreHost = Dns.GetHostName();
            foreach (var ip in Dns.GetHostAddresses(nombreHost))
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "IP no encontrada";
        }

        private void textBox_codigo_Click(object sender, EventArgs e)
        {
            TecladoDesplegable.MostrarTeclado(_formularioPadre, textBox_codigo);
        }

        private void textBox_nombre_Click(object sender, EventArgs e)
        {
            TecladoDesplegable.MostrarTeclado(_formularioPadre, textBox_nombre);
        }

        private void textBox_ubicacion_Click(object sender, EventArgs e)
        {
            TecladoDesplegable.MostrarTeclado(_formularioPadre, textBox_ubicacion);
        }
    }
}
