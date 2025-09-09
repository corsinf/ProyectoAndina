using ProyectoAndina.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAndina.Views
{
    public partial class AdministracionFrom : Form
    {


        public AdministracionFrom()
        {
            InitializeComponent();

            //configuracion de estilo

            //ConfigurarEstilo();
            // se despliega en toda la pantalla
            this.WindowState = FormWindowState.Maximized;

            this.Paint += AdministracionFrom_Paint;
            this.DoubleBuffered = true;
        }

        private void AdministracionFrom_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }

        public void ConfigurarEstilo()
        {
            StyleManager.ConfigurarFormPrincipal(this, "Menu Principal");
            this.BackColor = StyleManager.Colors.GrisClaro;

            // Configurar panel principal con sombra

            // Configurar labels con estilos UASB
            StyleManager.ConfigurarLabel(label_titulo_administración, TipoLabel.TituloGrande);



            // Hacer responsive y centrar el titulo
            StyleManager.ConfigurarBotonPrincipalIcono(
             iconButton_regresar,
             FontAwesome.Sharp.IconChar.ArrowLeft,
             "Regresar",
             colorFondo: Color.FromArgb(231, 76, 60)
             );
            

            StyleGenerales.EstilizarCardVertical(panel_persona, "Center", Color.Transparent);
            StyleGenerales.EstilizarCardVertical(panel_rol, "Center", Color.Transparent);
            StyleGenerales.EstilizarCardVertical(panel_asignar_rol, "Center", Color.Transparent);
            StyleGenerales.EstilizarCardVertical(panel_arqueo_caja, "Center", Color.Transparent);
            StyleGenerales.EstilizarCardVertical(panel_transacciones, "Center", Color.Transparent);
            StyleGenerales.EstilizarCardVertical(panel_caja, "Center", Color.Transparent);
            StyleContenedores.EstilizarCard(
               panel_roles_container,
               panel_rol_titulo,
               panel_rol_image,
               label_titulo_rol.Text,
               Properties.Resources.logo_rol,
               () =>
               {
                   redirigirRol(); 
               }
           );

            StyleContenedores.EstilizarCard(
              panel_persona_container,
              panel_persona_titulo,
              panel_persona_image,
              label_titulo_persona.Text,
              Properties.Resources.logo_persona,
               () =>
               {
                   redirigirPersonas();
               }

          );
            StyleContenedores.EstilizarCard(
              panel_asignar_rol_container,
              panel_asignar_titulo,
              panel_asignar_image,
              label_titulo_asignar_rol.Text,
              Properties.Resources.logo_persona_rol,
               () =>
               {
                   redirigirPersonaRol();
               }
          );
            StyleContenedores.EstilizarCard(
              panel_caja_container,
              panel_caja_titulo,
              panel_caja_image,
              label_titulo_caja.Text,
              Properties.Resources.logo_caja,
               () =>
               {
                   redirigirCaja();
               }
          );
            StyleContenedores.EstilizarCard(
              panel_arqueo_container,
              panel_arqueo_titulo,
              panel_arqueo_image,
              label_titulo_arqueo.Text,
              Properties.Resources.logo_arqueo,
               () =>
               {
                   redirigirArqueoCaja();
               }
          );
            StyleContenedores.EstilizarCard(
              panel_transacciones_container,
              panel_transaccion_titulo,
              panel_transaccion_image,
              label_titulo_transacciones.Text,
              Properties.Resources.logo_transacciones,
               () =>
               {
                   redirigirTransacciones();
               }
          );


        }
        public void InitializeComponent()
        {
            label_titulo_administración = new Label();
            iconButton_regresar = new FontAwesome.Sharp.IconButton();
            tableLayoutPanel_contenedor_uno = new TableLayoutPanel();
            pictureBox_logo_tipo = new PictureBox();
            tableLayoutPanel_contenido = new TableLayoutPanel();
            panel_asignar_rol = new Panel();
            panel_asignar_rol_container = new Panel();
            panel_asignar_titulo = new Panel();
            label_titulo_asignar_rol = new Label();
            panel_asignar_image = new Panel();
            pictureBox_asignar_rol = new PictureBox();
            panel_rol = new Panel();
            panel_roles_container = new Panel();
            panel_rol_titulo = new Panel();
            label_titulo_rol = new Label();
            panel_rol_image = new Panel();
            pictureBox_roles = new PictureBox();
            panel_persona = new Panel();
            panel_persona_container = new Panel();
            panel_persona_titulo = new Panel();
            label_titulo_persona = new Label();
            panel_persona_image = new Panel();
            pictureBox_personas = new PictureBox();
            panel_caja = new Panel();
            panel_caja_container = new Panel();
            panel_caja_titulo = new Panel();
            label_titulo_caja = new Label();
            panel_caja_image = new Panel();
            pictureBox2 = new PictureBox();
            panel_arqueo_caja = new Panel();
            label_titulo_arqueo = new Label();
            panel_transacciones = new Panel();
            panel_transacciones_container = new Panel();
            panel_transaccion_titulo = new Panel();
            label_titulo_transacciones = new Label();
            panel_transaccion_image = new Panel();
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            pictureBox3 = new PictureBox();
            tableLayoutPanel_contenedor_uno.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_tipo).BeginInit();
            tableLayoutPanel_contenido.SuspendLayout();
            panel_asignar_rol.SuspendLayout();
            panel_asignar_rol_container.SuspendLayout();
            panel_asignar_titulo.SuspendLayout();
            panel_asignar_image.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_asignar_rol).BeginInit();
            panel_rol.SuspendLayout();
            panel_roles_container.SuspendLayout();
            panel_rol_titulo.SuspendLayout();
            panel_rol_image.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_roles).BeginInit();
            panel_persona.SuspendLayout();
            panel_persona_container.SuspendLayout();
            panel_persona_titulo.SuspendLayout();
            panel_persona_image.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_personas).BeginInit();
            panel_caja.SuspendLayout();
            panel_caja_container.SuspendLayout();
            panel_caja_titulo.SuspendLayout();
            panel_caja_image.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel_arqueo_caja.SuspendLayout();
            panel_transacciones.SuspendLayout();
            panel_transacciones_container.SuspendLayout();
            panel_transaccion_titulo.SuspendLayout();
            panel_transaccion_image.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // label_titulo_administración
            // 
            label_titulo_administración.AutoSize = true;
            label_titulo_administración.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_administración.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_administración.Location = new Point(330, 0);
            label_titulo_administración.Name = "label_titulo_administración";
            label_titulo_administración.RightToLeft = RightToLeft.Yes;
            label_titulo_administración.Size = new Size(288, 30);
            label_titulo_administración.TabIndex = 10;
            label_titulo_administración.Text = "Todo sobre administración";
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
            iconButton_regresar.Size = new Size(179, 64);
            iconButton_regresar.TabIndex = 80;
            iconButton_regresar.Text = "  Regresar";
            iconButton_regresar.TextAlign = ContentAlignment.MiddleRight;
            iconButton_regresar.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton_regresar.UseVisualStyleBackColor = false;
            iconButton_regresar.Click += iconButton_regresar_Click;
            // 
            // tableLayoutPanel_contenedor_uno
            // 
            tableLayoutPanel_contenedor_uno.ColumnCount = 3;
            tableLayoutPanel_contenedor_uno.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36.7541771F));
            tableLayoutPanel_contenedor_uno.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 63.2458229F));
            tableLayoutPanel_contenedor_uno.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 238F));
            tableLayoutPanel_contenedor_uno.Controls.Add(pictureBox_logo_tipo, 2, 0);
            tableLayoutPanel_contenedor_uno.Controls.Add(iconButton_regresar, 0, 0);
            tableLayoutPanel_contenedor_uno.Controls.Add(label_titulo_administración, 1, 0);
            tableLayoutPanel_contenedor_uno.Dock = DockStyle.Top;
            tableLayoutPanel_contenedor_uno.Location = new Point(0, 0);
            tableLayoutPanel_contenedor_uno.Name = "tableLayoutPanel_contenedor_uno";
            tableLayoutPanel_contenedor_uno.RowCount = 1;
            tableLayoutPanel_contenedor_uno.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_contenedor_uno.Size = new Size(1128, 78);
            tableLayoutPanel_contenedor_uno.TabIndex = 89;
            // 
            // pictureBox_logo_tipo
            // 
            pictureBox_logo_tipo.Image = Properties.Resources.Logotipo_color;
            pictureBox_logo_tipo.Location = new Point(892, 3);
            pictureBox_logo_tipo.Name = "pictureBox_logo_tipo";
            pictureBox_logo_tipo.Size = new Size(233, 56);
            pictureBox_logo_tipo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_logo_tipo.TabIndex = 64;
            pictureBox_logo_tipo.TabStop = false;
            // 
            // tableLayoutPanel_contenido
            // 
            tableLayoutPanel_contenido.ColumnCount = 3;
            tableLayoutPanel_contenido.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel_contenido.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel_contenido.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel_contenido.Controls.Add(panel_asignar_rol, 2, 0);
            tableLayoutPanel_contenido.Controls.Add(panel_rol, 1, 0);
            tableLayoutPanel_contenido.Controls.Add(panel_persona, 0, 0);
            tableLayoutPanel_contenido.Controls.Add(panel_caja, 0, 1);
            tableLayoutPanel_contenido.Controls.Add(panel_arqueo_caja, 1, 1);
            tableLayoutPanel_contenido.Controls.Add(panel_transacciones, 2, 1);
            tableLayoutPanel_contenido.Dock = DockStyle.Fill;
            tableLayoutPanel_contenido.Location = new Point(0, 78);
            tableLayoutPanel_contenido.Name = "tableLayoutPanel_contenido";
            tableLayoutPanel_contenido.RowCount = 2;
            tableLayoutPanel_contenido.RowStyles.Add(new RowStyle(SizeType.Percent, 50.2475243F));
            tableLayoutPanel_contenido.RowStyles.Add(new RowStyle(SizeType.Percent, 49.7524757F));
            tableLayoutPanel_contenido.Size = new Size(1128, 671);
            tableLayoutPanel_contenido.TabIndex = 90;
            // 
            // panel_asignar_rol
            // 
            panel_asignar_rol.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_asignar_rol.BackColor = Color.Transparent;
            panel_asignar_rol.Controls.Add(panel_asignar_rol_container);
            panel_asignar_rol.Location = new Point(755, 3);
            panel_asignar_rol.Name = "panel_asignar_rol";
            panel_asignar_rol.Size = new Size(370, 331);
            panel_asignar_rol.TabIndex = 72;
            // 
            // panel_asignar_rol_container
            // 
            panel_asignar_rol_container.Anchor = AnchorStyles.None;
            panel_asignar_rol_container.BackColor = Color.Transparent;
            panel_asignar_rol_container.Controls.Add(panel_asignar_titulo);
            panel_asignar_rol_container.Controls.Add(panel_asignar_image);
            panel_asignar_rol_container.Location = new Point(48, 17);
            panel_asignar_rol_container.Name = "panel_asignar_rol_container";
            panel_asignar_rol_container.Size = new Size(265, 271);
            panel_asignar_rol_container.TabIndex = 81;
            // 
            // panel_asignar_titulo
            // 
            panel_asignar_titulo.BackColor = Color.Transparent;
            panel_asignar_titulo.Controls.Add(label_titulo_asignar_rol);
            panel_asignar_titulo.Location = new Point(12, 218);
            panel_asignar_titulo.Name = "panel_asignar_titulo";
            panel_asignar_titulo.Size = new Size(244, 53);
            panel_asignar_titulo.TabIndex = 79;
            // 
            // label_titulo_asignar_rol
            // 
            label_titulo_asignar_rol.AutoSize = true;
            label_titulo_asignar_rol.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_asignar_rol.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_asignar_rol.Location = new Point(47, 15);
            label_titulo_asignar_rol.Name = "label_titulo_asignar_rol";
            label_titulo_asignar_rol.Size = new Size(130, 30);
            label_titulo_asignar_rol.TabIndex = 18;
            label_titulo_asignar_rol.Text = "Asignar Rol";
            // 
            // panel_asignar_image
            // 
            panel_asignar_image.BackColor = Color.Transparent;
            panel_asignar_image.Controls.Add(pictureBox_asignar_rol);
            panel_asignar_image.Location = new Point(14, 14);
            panel_asignar_image.Name = "panel_asignar_image";
            panel_asignar_image.Size = new Size(242, 183);
            panel_asignar_image.TabIndex = 79;
            // 
            // pictureBox_asignar_rol
            // 
            pictureBox_asignar_rol.Image = Properties.Resources.recaudacion_actual;
            pictureBox_asignar_rol.Location = new Point(30, 7);
            pictureBox_asignar_rol.Name = "pictureBox_asignar_rol";
            pictureBox_asignar_rol.Size = new Size(191, 168);
            pictureBox_asignar_rol.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_asignar_rol.TabIndex = 22;
            pictureBox_asignar_rol.TabStop = false;
            // 
            // panel_rol
            // 
            panel_rol.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_rol.BackColor = Color.Transparent;
            panel_rol.Controls.Add(panel_roles_container);
            panel_rol.Location = new Point(379, 3);
            panel_rol.Name = "panel_rol";
            panel_rol.Size = new Size(370, 331);
            panel_rol.TabIndex = 71;
            // 
            // panel_roles_container
            // 
            panel_roles_container.Anchor = AnchorStyles.None;
            panel_roles_container.BackColor = Color.Transparent;
            panel_roles_container.Controls.Add(panel_rol_titulo);
            panel_roles_container.Controls.Add(panel_rol_image);
            panel_roles_container.Location = new Point(53, 17);
            panel_roles_container.Name = "panel_roles_container";
            panel_roles_container.Size = new Size(271, 271);
            panel_roles_container.TabIndex = 80;
            // 
            // panel_rol_titulo
            // 
            panel_rol_titulo.BackColor = Color.Transparent;
            panel_rol_titulo.Controls.Add(label_titulo_rol);
            panel_rol_titulo.Location = new Point(6, 218);
            panel_rol_titulo.Name = "panel_rol_titulo";
            panel_rol_titulo.Size = new Size(250, 53);
            panel_rol_titulo.TabIndex = 80;
            // 
            // label_titulo_rol
            // 
            label_titulo_rol.AutoSize = true;
            label_titulo_rol.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_rol.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_rol.Location = new Point(27, 15);
            label_titulo_rol.Name = "label_titulo_rol";
            label_titulo_rol.Size = new Size(67, 30);
            label_titulo_rol.TabIndex = 15;
            label_titulo_rol.Text = "Roles";
            // 
            // panel_rol_image
            // 
            panel_rol_image.BackColor = Color.Transparent;
            panel_rol_image.Controls.Add(pictureBox_roles);
            panel_rol_image.Location = new Point(13, 14);
            panel_rol_image.Name = "panel_rol_image";
            panel_rol_image.Size = new Size(243, 183);
            panel_rol_image.TabIndex = 79;
            // 
            // pictureBox_roles
            // 
            pictureBox_roles.Image = Properties.Resources.recaudacion_actual;
            pictureBox_roles.Location = new Point(18, 7);
            pictureBox_roles.Name = "pictureBox_roles";
            pictureBox_roles.Size = new Size(191, 168);
            pictureBox_roles.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_roles.TabIndex = 21;
            pictureBox_roles.TabStop = false;
            // 
            // panel_persona
            // 
            panel_persona.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_persona.BackColor = Color.Transparent;
            panel_persona.Controls.Add(panel_persona_container);
            panel_persona.Location = new Point(3, 3);
            panel_persona.Name = "panel_persona";
            panel_persona.Size = new Size(370, 331);
            panel_persona.TabIndex = 70;
            // 
            // panel_persona_container
            // 
            panel_persona_container.Anchor = AnchorStyles.None;
            panel_persona_container.BackColor = Color.Transparent;
            panel_persona_container.Controls.Add(panel_persona_titulo);
            panel_persona_container.Controls.Add(panel_persona_image);
            panel_persona_container.Location = new Point(22, 17);
            panel_persona_container.Name = "panel_persona_container";
            panel_persona_container.Size = new Size(271, 271);
            panel_persona_container.TabIndex = 77;
            // 
            // panel_persona_titulo
            // 
            panel_persona_titulo.BackColor = Color.Transparent;
            panel_persona_titulo.Controls.Add(label_titulo_persona);
            panel_persona_titulo.Location = new Point(10, 218);
            panel_persona_titulo.Name = "panel_persona_titulo";
            panel_persona_titulo.Size = new Size(244, 53);
            panel_persona_titulo.TabIndex = 80;
            // 
            // label_titulo_persona
            // 
            label_titulo_persona.AutoSize = true;
            label_titulo_persona.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_persona.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_persona.Location = new Point(14, 12);
            label_titulo_persona.Name = "label_titulo_persona";
            label_titulo_persona.Size = new Size(105, 30);
            label_titulo_persona.TabIndex = 17;
            label_titulo_persona.Text = "Personas";
            // 
            // panel_persona_image
            // 
            panel_persona_image.BackColor = Color.Transparent;
            panel_persona_image.Controls.Add(pictureBox_personas);
            panel_persona_image.Location = new Point(10, 14);
            panel_persona_image.Name = "panel_persona_image";
            panel_persona_image.Size = new Size(242, 183);
            panel_persona_image.TabIndex = 79;
            // 
            // pictureBox_personas
            // 
            pictureBox_personas.Image = Properties.Resources.recaudacion_actual;
            pictureBox_personas.Location = new Point(26, 7);
            pictureBox_personas.Name = "pictureBox_personas";
            pictureBox_personas.Size = new Size(191, 168);
            pictureBox_personas.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_personas.TabIndex = 20;
            pictureBox_personas.TabStop = false;
            // 
            // panel_caja
            // 
            panel_caja.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_caja.BackColor = Color.Transparent;
            panel_caja.Controls.Add(panel_caja_container);
            panel_caja.Location = new Point(3, 340);
            panel_caja.Name = "panel_caja";
            panel_caja.Size = new Size(370, 328);
            panel_caja.TabIndex = 67;
            // 
            // panel_caja_container
            // 
            panel_caja_container.Anchor = AnchorStyles.None;
            panel_caja_container.BackColor = Color.Transparent;
            panel_caja_container.Controls.Add(panel_caja_titulo);
            panel_caja_container.Controls.Add(panel_caja_image);
            panel_caja_container.Location = new Point(22, 28);
            panel_caja_container.Name = "panel_caja_container";
            panel_caja_container.Size = new Size(271, 259);
            panel_caja_container.TabIndex = 77;
            // 
            // panel_caja_titulo
            // 
            panel_caja_titulo.BackColor = Color.Transparent;
            panel_caja_titulo.Controls.Add(label_titulo_caja);
            panel_caja_titulo.Location = new Point(12, 211);
            panel_caja_titulo.Name = "panel_caja_titulo";
            panel_caja_titulo.Size = new Size(244, 48);
            panel_caja_titulo.TabIndex = 79;
            // 
            // label_titulo_caja
            // 
            label_titulo_caja.AutoSize = true;
            label_titulo_caja.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_caja.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_caja.Location = new Point(11, 15);
            label_titulo_caja.Name = "label_titulo_caja";
            label_titulo_caja.Size = new Size(67, 30);
            label_titulo_caja.TabIndex = 17;
            label_titulo_caja.Text = "Cajas";
            // 
            // panel_caja_image
            // 
            panel_caja_image.BackColor = Color.Transparent;
            panel_caja_image.Controls.Add(pictureBox2);
            panel_caja_image.Location = new Point(14, 22);
            panel_caja_image.Name = "panel_caja_image";
            panel_caja_image.Size = new Size(242, 183);
            panel_caja_image.TabIndex = 79;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.recaudacion_actual;
            pictureBox2.Location = new Point(26, 7);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(191, 168);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 20;
            pictureBox2.TabStop = false;
            // 
            // panel_arqueo_caja
            // 
            panel_arqueo_caja.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_arqueo_caja.BackColor = Color.Transparent;
            panel_arqueo_caja.Controls.Add(groupBox1);
            panel_arqueo_caja.Location = new Point(379, 340);
            panel_arqueo_caja.Name = "panel_arqueo_caja";
            panel_arqueo_caja.Size = new Size(370, 328);
            panel_arqueo_caja.TabIndex = 68;
            // 
            // label_titulo_arqueo
            // 
            label_titulo_arqueo.AutoSize = true;
            label_titulo_arqueo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_arqueo.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_arqueo.Location = new Point(64, 240);
            label_titulo_arqueo.Name = "label_titulo_arqueo";
            label_titulo_arqueo.Size = new Size(149, 30);
            label_titulo_arqueo.TabIndex = 15;
            label_titulo_arqueo.Text = "Arqueo Cajas";
            // 
            // panel_transacciones
            // 
            panel_transacciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_transacciones.BackColor = Color.Transparent;
            panel_transacciones.Controls.Add(panel_transacciones_container);
            panel_transacciones.Location = new Point(755, 340);
            panel_transacciones.Name = "panel_transacciones";
            panel_transacciones.Size = new Size(370, 328);
            panel_transacciones.TabIndex = 69;
            // 
            // panel_transacciones_container
            // 
            panel_transacciones_container.Anchor = AnchorStyles.None;
            panel_transacciones_container.BackColor = Color.Transparent;
            panel_transacciones_container.Controls.Add(panel_transaccion_titulo);
            panel_transacciones_container.Controls.Add(panel_transaccion_image);
            panel_transacciones_container.Location = new Point(48, 28);
            panel_transacciones_container.Name = "panel_transacciones_container";
            panel_transacciones_container.Size = new Size(265, 259);
            panel_transacciones_container.TabIndex = 81;
            // 
            // panel_transaccion_titulo
            // 
            panel_transaccion_titulo.BackColor = Color.Transparent;
            panel_transaccion_titulo.Controls.Add(label_titulo_transacciones);
            panel_transaccion_titulo.Location = new Point(12, 211);
            panel_transaccion_titulo.Name = "panel_transaccion_titulo";
            panel_transaccion_titulo.Size = new Size(244, 48);
            panel_transaccion_titulo.TabIndex = 79;
            // 
            // label_titulo_transacciones
            // 
            label_titulo_transacciones.AutoSize = true;
            label_titulo_transacciones.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_titulo_transacciones.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_transacciones.Location = new Point(17, 15);
            label_titulo_transacciones.Name = "label_titulo_transacciones";
            label_titulo_transacciones.Size = new Size(156, 30);
            label_titulo_transacciones.TabIndex = 18;
            label_titulo_transacciones.Text = "Transacciones";
            // 
            // panel_transaccion_image
            // 
            panel_transaccion_image.BackColor = Color.Transparent;
            panel_transaccion_image.Controls.Add(pictureBox1);
            panel_transaccion_image.Location = new Point(9, 14);
            panel_transaccion_image.Name = "panel_transaccion_image";
            panel_transaccion_image.Size = new Size(242, 183);
            panel_transaccion_image.TabIndex = 79;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.recaudacion_actual;
            pictureBox1.Location = new Point(30, 7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(191, 168);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label_titulo_arqueo);
            groupBox1.Controls.Add(pictureBox3);
            groupBox1.Location = new Point(53, 14);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(288, 286);
            groupBox1.TabIndex = 78;
            groupBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.recaudacion_actual;
            pictureBox3.Location = new Point(51, 35);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(191, 168);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 21;
            pictureBox3.TabStop = false;
            // 
            // AdministracionFrom
            // 
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1128, 749);
            Controls.Add(tableLayoutPanel_contenido);
            Controls.Add(tableLayoutPanel_contenedor_uno);
            Name = "AdministracionFrom";
            Load += AdministracionFrom_Load;
            tableLayoutPanel_contenedor_uno.ResumeLayout(false);
            tableLayoutPanel_contenedor_uno.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_tipo).EndInit();
            tableLayoutPanel_contenido.ResumeLayout(false);
            panel_asignar_rol.ResumeLayout(false);
            panel_asignar_rol_container.ResumeLayout(false);
            panel_asignar_titulo.ResumeLayout(false);
            panel_asignar_titulo.PerformLayout();
            panel_asignar_image.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_asignar_rol).EndInit();
            panel_rol.ResumeLayout(false);
            panel_roles_container.ResumeLayout(false);
            panel_rol_titulo.ResumeLayout(false);
            panel_rol_titulo.PerformLayout();
            panel_rol_image.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_roles).EndInit();
            panel_persona.ResumeLayout(false);
            panel_persona_container.ResumeLayout(false);
            panel_persona_titulo.ResumeLayout(false);
            panel_persona_titulo.PerformLayout();
            panel_persona_image.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_personas).EndInit();
            panel_caja.ResumeLayout(false);
            panel_caja_container.ResumeLayout(false);
            panel_caja_titulo.ResumeLayout(false);
            panel_caja_titulo.PerformLayout();
            panel_caja_image.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel_arqueo_caja.ResumeLayout(false);
            panel_transacciones.ResumeLayout(false);
            panel_transacciones_container.ResumeLayout(false);
            panel_transaccion_titulo.ResumeLayout(false);
            panel_transaccion_titulo.PerformLayout();
            panel_transaccion_image.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);

        }

        private void button_pagina_roles_Click(object sender, EventArgs e)
        {
            var RolForm = new RolForm();
            this.Hide();                 // Opcional: ocultas la ventana actual
            RolForm.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
            this.Close();
        }

        private void button_pagina_personas_Click(object sender, EventArgs e)
        {
            var PersonaForm = new PersonaForm();
            this.Hide();                 // Opcional: ocultas la ventana actual
            PersonaForm.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
            this.Close();
        }

        private void button_asignar_rol_persona_Click(object sender, EventArgs e)
        {
            var PersonaRolForm = new PersonaRolForm();
            this.Hide();                 // Opcional: ocultas la ventana actual
            PersonaRolForm.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
            this.Close();
        }

        private Label label_titulo_administración;
        private Label label_opciones;
        private FontAwesome.Sharp.IconButton iconButton_regresar;
        private PictureBox pictureBox_logo_tipo;
        private TableLayoutPanel tableLayoutPanel_contenido;
        private Panel panel_caja;
        private Panel panel_caja_container;
        private Panel panel_caja_titulo;
        private Label label_titulo_caja;
        private Panel panel_caja_image;
        private PictureBox pictureBox2;
        private Panel panel_arqueo_caja;
        private Panel panel_arqueo_container;
        private Panel panel_arqueo_titulo;
        private Label label_titulo_arqueo;
        private Panel panel_arqueo_image;
        private PictureBox pictureBox3;
        private Panel panel_persona;
        private Panel panel_persona_container;
        private Panel panel_persona_titulo;
        private Label label_titulo_persona;
        private Panel panel_persona_image;
        private PictureBox pictureBox_personas;
        private Panel panel_rol;
        private Panel panel_roles_container;
        private Panel panel_rol_titulo;
        private Label label_titulo_rol;
        private Panel panel_rol_image;
        private PictureBox pictureBox_roles;
        private Panel panel_asignar_rol;
        private Panel panel_asignar_rol_container;
        private Panel panel_asignar_titulo;
        private Label label_titulo_asignar_rol;
        private Panel panel_asignar_image;
        private PictureBox pictureBox_asignar_rol;
        private Panel panel_transacciones;
        private Panel panel_transacciones_container;
        private Panel panel_transaccion_titulo;
        private Label label_titulo_transacciones;
        private Panel panel_transaccion_image;
        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private Button button1;
        private TableLayoutPanel tableLayoutPanel_contenedor_uno;

        private void redirigirCaja()
        {
            var CajaForm = new CajaForm();
            this.Hide();                 // Opcional: ocultas la ventana actual
            CajaForm.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
            this.Close();
        }

        private void redirigirRol()
        {
            var RolForm = new RolForm();
            this.Hide();                 // Opcional: ocultas la ventana actual
            RolForm.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
            this.Close();
        }

        private void redirigirPersonas()
        {
            var PersonaForm = new PersonaForm();
            this.Hide();                 // Opcional: ocultas la ventana actual
            PersonaForm.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
            this.Close();

        }

        private void redirigirPersonaRol()
        {
            var PersonaRolForm = new PersonaRolForm();
            this.Hide();                 // Opcional: ocultas la ventana actual
            PersonaRolForm.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
            this.Close();
        }

        private void iconButton_regresar_Click(object sender, EventArgs e)
        {
            var MenuPrincipalForm = new MenuPrincipalForm();
            this.Hide();
            MenuPrincipalForm.ShowDialog();
            this.Close();
        }

        private void redirigirArqueoCaja()
        {
            var ArqueosCajasForm = new ArqueosCajasForm();
            this.Hide();
            ArqueosCajasForm.ShowDialog();
            this.Close();
        }

        private void AdministracionFrom_Load(object sender, EventArgs e)
        {

        }

        private void panel_posicion_izquierda_Paint(object sender, PaintEventArgs e)
        {

        }

        private void redirigirTransacciones()
        {
            var TransaccionesForm = new TransaccionesForm();
            this.Hide();
            TransaccionesForm.ShowDialog();
            this.Close();
        }
    }
}