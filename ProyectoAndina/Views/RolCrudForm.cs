using ProyectoAndina.Controllers;
using ProyectoAndina.Helper;
using ProyectoAndina.Models;
using ProyectoAndina.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProyectoAndina.Utils.StylesAlertas;

namespace ProyectoAndina.Views
{
    public partial class RolCrudForm : Form
    {
        private readonly RolController _RolController;
        private readonly FuncionesGenerales _FuncionesGenerales;

        public int id;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Form _formularioPadre;
        public RolCrudForm(int id_rol, Form formularioPadre = null)
        {
            _RolController = new RolController();
            _FuncionesGenerales = new FuncionesGenerales();
            InitializeComponent();
            BuscarRol(id_rol);
            _formularioPadre = formularioPadre;
            this.Paint += RolCrudForm_Paint;
            this.DoubleBuffered = true;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void RolCrudForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
            //configurar los botones
           

        }

       

        private void BuscarRol(int id_rol)
        {

            if (id_rol != 0)
            {
                StyleManager.ConfigurarBotonIconoEnPanel(panel_button_accion, button_accion, FontAwesome.Sharp.IconChar.Rotate, Color.LightSteelBlue);
                var rol = _RolController.ObtenerRolPorId(id_rol);
                textBox_nombre.Text = rol.Nombre;
                textBox_descripcion.Text = rol.Descripcion;
                id = id_rol;

            }
            else
            {
                StyleManager.ConfigurarBotonIconoEnPanel(panel_button_accion, button_accion, FontAwesome.Sharp.IconChar.PlusCircle, Color.MediumAquamarine);
                _FuncionesGenerales.LimpiarCampos(this);

            }



        }
        private PictureBox pictureBox_logo_tipo;

        private void InitializeComponent()
        {
            pictureBox_logo_tipo = new PictureBox();
            panel_button_accion = new Panel();
            button_accion = new Button();
            panel_formulario = new Panel();
            lbl_nombre = new Label();
            textBox_nombre = new TextBox();
            textBox_descripcion = new TextBox();
            label_descripcion = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_tipo).BeginInit();
            panel_button_accion.SuspendLayout();
            panel_formulario.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
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
            // panel_button_accion
            // 
            panel_button_accion.BackColor = Color.Transparent;
            panel_button_accion.Controls.Add(button_accion);
            panel_button_accion.Dock = DockStyle.Fill;
            panel_button_accion.Location = new Point(3, 286);
            panel_button_accion.Name = "panel_button_accion";
            panel_button_accion.Size = new Size(401, 122);
            panel_button_accion.TabIndex = 83;
            // 
            // button_accion
            // 
            button_accion.BackColor = Color.FromArgb(52, 152, 219);
            button_accion.Cursor = Cursors.Hand;
            button_accion.FlatAppearance.BorderSize = 0;
            button_accion.FlatStyle = FlatStyle.Flat;
            button_accion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_accion.ForeColor = Color.White;
            button_accion.Location = new Point(129, 42);
            button_accion.Name = "button_accion";
            button_accion.Size = new Size(145, 40);
            button_accion.TabIndex = 27;
            button_accion.Text = "Accion";
            button_accion.UseVisualStyleBackColor = false;
            button_accion.Click += button_accion_Click;
            // 
            // panel_formulario
            // 
            panel_formulario.BackColor = Color.Transparent;
            panel_formulario.Controls.Add(lbl_nombre);
            panel_formulario.Controls.Add(textBox_nombre);
            panel_formulario.Controls.Add(textBox_descripcion);
            panel_formulario.Controls.Add(label_descripcion);
            panel_formulario.Dock = DockStyle.Fill;
            panel_formulario.Location = new Point(3, 3);
            panel_formulario.Name = "panel_formulario";
            panel_formulario.Size = new Size(401, 277);
            panel_formulario.TabIndex = 82;
            // 
            // lbl_nombre
            // 
            lbl_nombre.AutoSize = true;
            lbl_nombre.Location = new Point(21, 31);
            lbl_nombre.Name = "lbl_nombre";
            lbl_nombre.Size = new Size(67, 20);
            lbl_nombre.TabIndex = 29;
            lbl_nombre.Text = "Nombre:";
            // 
            // textBox_nombre
            // 
            textBox_nombre.Location = new Point(21, 67);
            textBox_nombre.Name = "textBox_nombre";
            textBox_nombre.Size = new Size(201, 27);
            textBox_nombre.TabIndex = 28;
            textBox_nombre.Click += textBox_nombre_Click;
            // 
            // textBox_descripcion
            // 
            textBox_descripcion.Location = new Point(21, 150);
            textBox_descripcion.Name = "textBox_descripcion";
            textBox_descripcion.Size = new Size(201, 27);
            textBox_descripcion.TabIndex = 30;
            textBox_descripcion.Click += textBox_descripcion_Click;
            // 
            // label_descripcion
            // 
            label_descripcion.AutoSize = true;
            label_descripcion.Location = new Point(21, 113);
            label_descripcion.Name = "label_descripcion";
            label_descripcion.Size = new Size(90, 20);
            label_descripcion.TabIndex = 31;
            label_descripcion.Text = "Descripción:";
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
            tableLayoutPanel1.Size = new Size(407, 75);
            tableLayoutPanel1.TabIndex = 82;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.Transparent;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(panel_formulario, 0, 0);
            tableLayoutPanel2.Controls.Add(panel_button_accion, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 75);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 128F));
            tableLayoutPanel2.Size = new Size(407, 411);
            tableLayoutPanel2.TabIndex = 83;
            // 
            // RolCrudForm
            // 
            ClientSize = new Size(407, 486);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            Name = "RolCrudForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_tipo).EndInit();
            panel_button_accion.ResumeLayout(false);
            panel_formulario.ResumeLayout(false);
            panel_formulario.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);

        }
        private Button button_accion;
        private Panel panel_button_accion;
        private Panel panel_formulario;
        private Label lbl_nombre;
        private TextBox textBox_nombre;
        private TextBox textBox_descripcion;
        private Label label_descripcion;

        private void button_accion_Click(object sender, EventArgs e)
        {
            string nombre = textBox_nombre.Text.Trim();
            string descripcion = textBox_descripcion.Text.Trim();

            if (nombre == "" || descripcion == "")
            {

                StylesAlertas.MostrarAlerta(this, "Todos los campos son obligatorios", "Aviso", TipoAlerta.Info);
                return;
            }

            try
            {
                // Crear objeto Rol usando las propiedades del modelo
                RolM Rol = new RolM
                {
                    Nombre = nombre,
                    Descripcion = descripcion,
                    Estado = true,
                    FechaCreacion = DateTime.Now
                };

                string accion = button_accion.Text.Trim();

                if (accion == "Actualizar")
                {
                    Rol.RolId = id;
                    _RolController.ActualizarRol(Rol);

                    StylesAlertas.MostrarAlerta(this, "Registro actualizado correctamente", tipo: TipoAlerta.Success);
                }
                if (accion == "Crear")
                {
                   
                    _RolController.InsertarRol(Rol);
                    StylesAlertas.MostrarAlerta(this, "Registro creado correctamente", tipo: TipoAlerta.Success);

                }

                this.DialogResult = DialogResult.OK;
                this.Close();




            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar rol: " + ex.Message);
            }
        }

        private void textBox_nombre_Click(object sender, EventArgs e)
        {
            TecladoDesplegable.MostrarTeclado(_formularioPadre, textBox_nombre);
        }

        private void textBox_descripcion_Click(object sender, EventArgs e)
        {
            TecladoDesplegable.MostrarTeclado(_formularioPadre, textBox_descripcion);

        }
    }
}
