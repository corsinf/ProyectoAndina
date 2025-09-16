namespace ProyectoAndina.Views
{
    partial class TransaccionesCajaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel_logueado = new TableLayoutPanel();
            iconButton_regresar = new FontAwesome.Sharp.IconButton();
            label_titulo_transacciones = new Label();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            tableLayoutPanel_footer = new TableLayoutPanel();
            button_realizar_transaccion = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label_titulo_datos_placas = new Label();
            tableLayoutPanel_datos_placa = new TableLayoutPanel();
            label_hora_ingreso = new Label();
            label_valor_hora_ingreso = new Label();
            label_hora_estacionamiento = new Label();
            label_valor_tiempo = new Label();
            label_valor_cobrar = new Label();
            label_valor_a_cobrar = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            flowLayoutPanel4 = new FlowLayoutPanel();
            button_efectivo = new Button();
            button_tarjeta = new Button();
            button_transferencia = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            button_consumidor_final = new Button();
            button_con_datos = new Button();
            tableLayoutPanel_usuario_encontrado = new TableLayoutPanel();
            label_telefono = new Label();
            label_correo = new Label();
            flowLayoutPanel3 = new FlowLayoutPanel();
            label_titulo_usuario = new Label();
            textBox_usuario_encontrar = new TextBox();
            button_buscar_usuario = new Button();
            button_agregar_user = new Button();
            label_cedula = new Label();
            label_nombre = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            label_valor_cambio = new Label();
            label1 = new Label();
            label_valor_de_cambio = new Label();
            textBox_val_entregado = new TextBox();
            label_tipo_de_pago = new Label();
            tableLayoutPanel9 = new TableLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            button_buscar_placa = new Button();
            tableLayoutPanel6 = new TableLayoutPanel();
            textBox_buscar_placa = new TextBox();
            label_placa = new Label();
            tableLayoutPanel_logueado.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel_footer.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel_datos_placa.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            tableLayoutPanel_usuario_encontrado.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel9.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            SuspendLayout();
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
            tableLayoutPanel_logueado.Size = new Size(1232, 77);
            tableLayoutPanel_logueado.TabIndex = 108;
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
            iconButton_regresar.Location = new Point(46, 3);
            iconButton_regresar.Name = "iconButton_regresar";
            iconButton_regresar.Size = new Size(215, 71);
            iconButton_regresar.TabIndex = 51;
            iconButton_regresar.Text = "  Regresar";
            iconButton_regresar.TextAlign = ContentAlignment.MiddleRight;
            iconButton_regresar.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton_regresar.UseVisualStyleBackColor = false;
            iconButton_regresar.Click += iconButton_regresar_Click;
            // 
            // label_titulo_transacciones
            // 
            label_titulo_transacciones.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_transacciones.AutoSize = true;
            label_titulo_transacciones.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_titulo_transacciones.ForeColor = Color.FromArgb(30, 60, 120);
            label_titulo_transacciones.Location = new Point(311, 7);
            label_titulo_transacciones.Name = "label_titulo_transacciones";
            label_titulo_transacciones.Size = new Size(610, 62);
            label_titulo_transacciones.TabIndex = 14;
            label_titulo_transacciones.Text = "Transacciones";
            label_titulo_transacciones.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(927, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(302, 71);
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
            tableLayoutPanel_footer.ColumnCount = 3;
            tableLayoutPanel_footer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel_footer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel_footer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel_footer.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_footer.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_footer.Controls.Add(button_realizar_transaccion, 1, 0);
            tableLayoutPanel_footer.Dock = DockStyle.Bottom;
            tableLayoutPanel_footer.Location = new Point(0, 885);
            tableLayoutPanel_footer.Name = "tableLayoutPanel_footer";
            tableLayoutPanel_footer.RowCount = 2;
            tableLayoutPanel_footer.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_footer.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel_footer.Size = new Size(1232, 170);
            tableLayoutPanel_footer.TabIndex = 109;
            // 
            // button_realizar_transaccion
            // 
            button_realizar_transaccion.BackColor = Color.FromArgb(46, 204, 113);
            button_realizar_transaccion.Cursor = Cursors.Hand;
            button_realizar_transaccion.Dock = DockStyle.Fill;
            button_realizar_transaccion.Enabled = false;
            button_realizar_transaccion.FlatAppearance.BorderSize = 0;
            button_realizar_transaccion.FlatStyle = FlatStyle.Flat;
            button_realizar_transaccion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_realizar_transaccion.ForeColor = Color.White;
            button_realizar_transaccion.Location = new Point(434, 3);
            button_realizar_transaccion.Name = "button_realizar_transaccion";
            button_realizar_transaccion.Size = new Size(363, 129);
            button_realizar_transaccion.TabIndex = 118;
            button_realizar_transaccion.Text = "Cobrar";
            button_realizar_transaccion.UseVisualStyleBackColor = false;
            button_realizar_transaccion.Click += button_realizar_transaccion_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 269);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 9F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel1.Size = new Size(1232, 616);
            tableLayoutPanel1.TabIndex = 115;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.None;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(label_titulo_datos_placas, 0, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel_datos_placa, 0, 1);
            tableLayoutPanel2.Location = new Point(53, 8);
            tableLayoutPanel2.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2433233F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 85.7566757F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 79F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel2.Size = new Size(509, 564);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // label_titulo_datos_placas
            // 
            label_titulo_datos_placas.Anchor = AnchorStyles.None;
            label_titulo_datos_placas.AutoSize = true;
            label_titulo_datos_placas.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label_titulo_datos_placas.Location = new Point(110, 7);
            label_titulo_datos_placas.Name = "label_titulo_datos_placas";
            label_titulo_datos_placas.Size = new Size(289, 46);
            label_titulo_datos_placas.TabIndex = 94;
            label_titulo_datos_placas.Text = "Datos de la placa";
            label_titulo_datos_placas.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel_datos_placa
            // 
            tableLayoutPanel_datos_placa.ColumnCount = 2;
            tableLayoutPanel_datos_placa.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_datos_placa.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_datos_placa.Controls.Add(label_hora_ingreso, 0, 0);
            tableLayoutPanel_datos_placa.Controls.Add(label_valor_hora_ingreso, 0, 1);
            tableLayoutPanel_datos_placa.Controls.Add(label_hora_estacionamiento, 1, 0);
            tableLayoutPanel_datos_placa.Controls.Add(label_valor_tiempo, 1, 1);
            tableLayoutPanel_datos_placa.Controls.Add(label_valor_cobrar, 0, 2);
            tableLayoutPanel_datos_placa.Controls.Add(label_valor_a_cobrar, 0, 3);
            tableLayoutPanel_datos_placa.Dock = DockStyle.Top;
            tableLayoutPanel_datos_placa.Location = new Point(3, 64);
            tableLayoutPanel_datos_placa.Name = "tableLayoutPanel_datos_placa";
            tableLayoutPanel_datos_placa.RowCount = 4;
            tableLayoutPanel_datos_placa.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_datos_placa.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_datos_placa.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_datos_placa.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_datos_placa.Size = new Size(503, 366);
            tableLayoutPanel_datos_placa.TabIndex = 93;
            // 
            // label_hora_ingreso
            // 
            label_hora_ingreso.Anchor = AnchorStyles.None;
            label_hora_ingreso.AutoSize = true;
            label_hora_ingreso.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_hora_ingreso.ForeColor = Color.Gold;
            label_hora_ingreso.Location = new Point(10, 27);
            label_hora_ingreso.Name = "label_hora_ingreso";
            label_hora_ingreso.Size = new Size(230, 37);
            label_hora_ingreso.TabIndex = 75;
            label_hora_ingreso.Text = "Hora de ingreso:";
            // 
            // label_valor_hora_ingreso
            // 
            label_valor_hora_ingreso.Anchor = AnchorStyles.None;
            label_valor_hora_ingreso.AutoSize = true;
            label_valor_hora_ingreso.Font = new Font("Segoe UI", 18F);
            label_valor_hora_ingreso.ForeColor = Color.LightSeaGreen;
            label_valor_hora_ingreso.Location = new Point(104, 116);
            label_valor_hora_ingreso.Name = "label_valor_hora_ingreso";
            label_valor_hora_ingreso.Size = new Size(42, 41);
            label_valor_hora_ingreso.TabIndex = 88;
            label_valor_hora_ingreso.Text = "--";
            // 
            // label_hora_estacionamiento
            // 
            label_hora_estacionamiento.Anchor = AnchorStyles.None;
            label_hora_estacionamiento.AutoSize = true;
            label_hora_estacionamiento.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_hora_estacionamiento.ForeColor = Color.Gold;
            label_hora_estacionamiento.Location = new Point(316, 27);
            label_hora_estacionamiento.Name = "label_hora_estacionamiento";
            label_hora_estacionamiento.Size = new Size(122, 37);
            label_hora_estacionamiento.TabIndex = 89;
            label_hora_estacionamiento.Text = "Tiempo:";
            // 
            // label_valor_tiempo
            // 
            label_valor_tiempo.Anchor = AnchorStyles.None;
            label_valor_tiempo.AutoSize = true;
            label_valor_tiempo.Font = new Font("Segoe UI", 18F);
            label_valor_tiempo.ForeColor = Color.LightSeaGreen;
            label_valor_tiempo.Location = new Point(356, 116);
            label_valor_tiempo.Name = "label_valor_tiempo";
            label_valor_tiempo.Size = new Size(42, 41);
            label_valor_tiempo.TabIndex = 90;
            label_valor_tiempo.Text = "--";
            // 
            // label_valor_cobrar
            // 
            label_valor_cobrar.Anchor = AnchorStyles.None;
            label_valor_cobrar.AutoSize = true;
            tableLayoutPanel_datos_placa.SetColumnSpan(label_valor_cobrar, 2);
            label_valor_cobrar.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_valor_cobrar.ForeColor = Color.Gold;
            label_valor_cobrar.Location = new Point(149, 209);
            label_valor_cobrar.Name = "label_valor_cobrar";
            label_valor_cobrar.Size = new Size(205, 37);
            label_valor_cobrar.TabIndex = 58;
            label_valor_cobrar.Text = "Valor a cobrar:";
            // 
            // label_valor_a_cobrar
            // 
            label_valor_a_cobrar.Anchor = AnchorStyles.None;
            label_valor_a_cobrar.AutoSize = true;
            tableLayoutPanel_datos_placa.SetColumnSpan(label_valor_a_cobrar, 2);
            label_valor_a_cobrar.Font = new Font("Segoe UI", 18F);
            label_valor_a_cobrar.ForeColor = Color.LightSeaGreen;
            label_valor_a_cobrar.Location = new Point(234, 299);
            label_valor_a_cobrar.Name = "label_valor_a_cobrar";
            label_valor_a_cobrar.Size = new Size(34, 41);
            label_valor_a_cobrar.TabIndex = 89;
            label_valor_a_cobrar.Text = "0";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.None;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(flowLayoutPanel4, 0, 1);
            tableLayoutPanel3.Controls.Add(flowLayoutPanel2, 0, 2);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel_usuario_encontrado, 0, 3);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 0, 4);
            tableLayoutPanel3.Controls.Add(label_tipo_de_pago, 0, 0);
            tableLayoutPanel3.Location = new Point(669, 9);
            tableLayoutPanel3.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 5;
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.Size = new Size(509, 561);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Anchor = AnchorStyles.None;
            flowLayoutPanel4.Controls.Add(button_efectivo);
            flowLayoutPanel4.Controls.Add(button_tarjeta);
            flowLayoutPanel4.Controls.Add(button_transferencia);
            flowLayoutPanel4.Location = new Point(58, 50);
            flowLayoutPanel4.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(392, 65);
            flowLayoutPanel4.TabIndex = 97;
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
            button_efectivo.Location = new Point(3, 3);
            button_efectivo.Name = "button_efectivo";
            button_efectivo.Size = new Size(119, 63);
            button_efectivo.TabIndex = 74;
            button_efectivo.Text = "Efectivo";
            button_efectivo.UseVisualStyleBackColor = false;
            button_efectivo.Click += button_efectivo_Click;
            // 
            // button_tarjeta
            // 
            button_tarjeta.BackColor = Color.FromArgb(52, 152, 219);
            button_tarjeta.Cursor = Cursors.Hand;
            button_tarjeta.FlatAppearance.BorderSize = 0;
            button_tarjeta.FlatStyle = FlatStyle.Flat;
            button_tarjeta.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_tarjeta.ForeColor = Color.White;
            button_tarjeta.Location = new Point(128, 3);
            button_tarjeta.Name = "button_tarjeta";
            button_tarjeta.Size = new Size(119, 63);
            button_tarjeta.TabIndex = 75;
            button_tarjeta.Text = "Tarjeta";
            button_tarjeta.UseVisualStyleBackColor = false;
            button_tarjeta.Click += button_tarjeta_Click;
            // 
            // button_transferencia
            // 
            button_transferencia.BackColor = Color.FromArgb(52, 152, 219);
            button_transferencia.Cursor = Cursors.Hand;
            button_transferencia.FlatAppearance.BorderSize = 0;
            button_transferencia.FlatStyle = FlatStyle.Flat;
            button_transferencia.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_transferencia.ForeColor = Color.White;
            button_transferencia.Location = new Point(253, 3);
            button_transferencia.Name = "button_transferencia";
            button_transferencia.Size = new Size(130, 63);
            button_transferencia.TabIndex = 73;
            button_transferencia.Text = "Transferencia";
            button_transferencia.UseVisualStyleBackColor = false;
            button_transferencia.Click += button_transferencia_Click;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Anchor = AnchorStyles.None;
            flowLayoutPanel2.Controls.Add(button_consumidor_final);
            flowLayoutPanel2.Controls.Add(button_con_datos);
            flowLayoutPanel2.Location = new Point(99, 123);
            flowLayoutPanel2.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(310, 47);
            flowLayoutPanel2.TabIndex = 95;
            // 
            // button_consumidor_final
            // 
            button_consumidor_final.Anchor = AnchorStyles.None;
            button_consumidor_final.BackColor = Color.FromArgb(52, 152, 219);
            button_consumidor_final.Cursor = Cursors.Hand;
            button_consumidor_final.FlatAppearance.BorderSize = 0;
            button_consumidor_final.FlatStyle = FlatStyle.Flat;
            button_consumidor_final.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_consumidor_final.ForeColor = Color.White;
            button_consumidor_final.Location = new Point(3, 3);
            button_consumidor_final.Name = "button_consumidor_final";
            button_consumidor_final.Size = new Size(146, 40);
            button_consumidor_final.TabIndex = 55;
            button_consumidor_final.Text = "Consumidor Final";
            button_consumidor_final.UseVisualStyleBackColor = false;
            button_consumidor_final.Click += button_consumidor_final_Click;
            // 
            // button_con_datos
            // 
            button_con_datos.Anchor = AnchorStyles.None;
            button_con_datos.BackColor = Color.FromArgb(52, 152, 219);
            button_con_datos.Cursor = Cursors.Hand;
            button_con_datos.FlatAppearance.BorderSize = 0;
            button_con_datos.FlatStyle = FlatStyle.Flat;
            button_con_datos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_con_datos.ForeColor = Color.White;
            button_con_datos.Location = new Point(155, 3);
            button_con_datos.Name = "button_con_datos";
            button_con_datos.Size = new Size(146, 40);
            button_con_datos.TabIndex = 55;
            button_con_datos.Text = "Con Datos";
            button_con_datos.UseVisualStyleBackColor = false;
            button_con_datos.Click += button_con_datos_Click;
            // 
            // tableLayoutPanel_usuario_encontrado
            // 
            tableLayoutPanel_usuario_encontrado.ColumnCount = 1;
            tableLayoutPanel_usuario_encontrado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_usuario_encontrado.Controls.Add(label_telefono, 0, 4);
            tableLayoutPanel_usuario_encontrado.Controls.Add(label_correo, 0, 3);
            tableLayoutPanel_usuario_encontrado.Controls.Add(flowLayoutPanel3, 0, 0);
            tableLayoutPanel_usuario_encontrado.Controls.Add(label_cedula, 0, 2);
            tableLayoutPanel_usuario_encontrado.Controls.Add(label_nombre, 0, 1);
            tableLayoutPanel_usuario_encontrado.Location = new Point(3, 177);
            tableLayoutPanel_usuario_encontrado.Name = "tableLayoutPanel_usuario_encontrado";
            tableLayoutPanel_usuario_encontrado.RowCount = 5;
            tableLayoutPanel_usuario_encontrado.RowStyles.Add(new RowStyle(SizeType.Percent, 37.5F));
            tableLayoutPanel_usuario_encontrado.RowStyles.Add(new RowStyle(SizeType.Percent, 19.53125F));
            tableLayoutPanel_usuario_encontrado.RowStyles.Add(new RowStyle(SizeType.Percent, 24F));
            tableLayoutPanel_usuario_encontrado.RowStyles.Add(new RowStyle(SizeType.Percent, 19.2F));
            tableLayoutPanel_usuario_encontrado.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
            tableLayoutPanel_usuario_encontrado.Size = new Size(502, 215);
            tableLayoutPanel_usuario_encontrado.TabIndex = 83;
            tableLayoutPanel_usuario_encontrado.Visible = false;
            // 
            // label_telefono
            // 
            label_telefono.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_telefono.AutoSize = true;
            label_telefono.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_telefono.Location = new Point(3, 179);
            label_telefono.Name = "label_telefono";
            label_telefono.Size = new Size(496, 23);
            label_telefono.TabIndex = 79;
            label_telefono.Text = "telefono";
            // 
            // label_correo
            // 
            label_correo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_correo.AutoSize = true;
            label_correo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_correo.Location = new Point(3, 138);
            label_correo.Name = "label_correo";
            label_correo.Size = new Size(496, 23);
            label_correo.TabIndex = 78;
            label_correo.Text = "correo";
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(label_titulo_usuario);
            flowLayoutPanel3.Controls.Add(textBox_usuario_encontrar);
            flowLayoutPanel3.Controls.Add(button_buscar_usuario);
            flowLayoutPanel3.Controls.Add(button_agregar_user);
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.Location = new Point(3, 4);
            flowLayoutPanel3.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(496, 54);
            flowLayoutPanel3.TabIndex = 96;
            // 
            // label_titulo_usuario
            // 
            label_titulo_usuario.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_titulo_usuario.AutoSize = true;
            label_titulo_usuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_titulo_usuario.Location = new Point(3, 11);
            label_titulo_usuario.Name = "label_titulo_usuario";
            label_titulo_usuario.Size = new Size(65, 23);
            label_titulo_usuario.TabIndex = 60;
            label_titulo_usuario.Text = "Cédula";
            label_titulo_usuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox_usuario_encontrar
            // 
            textBox_usuario_encontrar.Anchor = AnchorStyles.None;
            textBox_usuario_encontrar.Location = new Point(74, 9);
            textBox_usuario_encontrar.Name = "textBox_usuario_encontrar";
            textBox_usuario_encontrar.Size = new Size(237, 27);
            textBox_usuario_encontrar.TabIndex = 61;
            textBox_usuario_encontrar.Click += textBox_usuario_encontrar_Click;
            // 
            // button_buscar_usuario
            // 
            button_buscar_usuario.BackColor = Color.FromArgb(52, 152, 219);
            button_buscar_usuario.Cursor = Cursors.Hand;
            button_buscar_usuario.FlatAppearance.BorderSize = 0;
            button_buscar_usuario.FlatStyle = FlatStyle.Flat;
            button_buscar_usuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_buscar_usuario.ForeColor = Color.White;
            button_buscar_usuario.Location = new Point(317, 3);
            button_buscar_usuario.Name = "button_buscar_usuario";
            button_buscar_usuario.Size = new Size(83, 40);
            button_buscar_usuario.TabIndex = 74;
            button_buscar_usuario.Text = "Buscar";
            button_buscar_usuario.UseVisualStyleBackColor = false;
            button_buscar_usuario.Click += button_buscar_usuario_Click;
            // 
            // button_agregar_user
            // 
            button_agregar_user.BackColor = Color.FromArgb(52, 152, 219);
            button_agregar_user.Cursor = Cursors.Hand;
            button_agregar_user.FlatAppearance.BorderSize = 0;
            button_agregar_user.FlatStyle = FlatStyle.Flat;
            button_agregar_user.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_agregar_user.ForeColor = Color.White;
            button_agregar_user.Location = new Point(406, 3);
            button_agregar_user.Name = "button_agregar_user";
            button_agregar_user.Size = new Size(80, 40);
            button_agregar_user.TabIndex = 73;
            button_agregar_user.Text = "Agregar";
            button_agregar_user.UseVisualStyleBackColor = false;
            button_agregar_user.Visible = false;
            button_agregar_user.Click += button_agregar_user_Click;
            // 
            // label_cedula
            // 
            label_cedula.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_cedula.AutoSize = true;
            label_cedula.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_cedula.Location = new Point(3, 102);
            label_cedula.Name = "label_cedula";
            label_cedula.Size = new Size(496, 23);
            label_cedula.TabIndex = 77;
            label_cedula.Text = "cedula";
            // 
            // label_nombre
            // 
            label_nombre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_nombre.AutoSize = true;
            label_nombre.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_nombre.Location = new Point(3, 66);
            label_nombre.Name = "label_nombre";
            label_nombre.Size = new Size(496, 23);
            label_nombre.TabIndex = 76;
            label_nombre.Text = "Nombre";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.Anchor = AnchorStyles.None;
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(label_valor_cambio, 1, 0);
            tableLayoutPanel4.Controls.Add(label1, 0, 0);
            tableLayoutPanel4.Controls.Add(label_valor_de_cambio, 1, 1);
            tableLayoutPanel4.Controls.Add(textBox_val_entregado, 0, 1);
            tableLayoutPanel4.Location = new Point(13, 411);
            tableLayoutPanel4.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel4.Size = new Size(482, 133);
            tableLayoutPanel4.TabIndex = 98;
            // 
            // label_valor_cambio
            // 
            label_valor_cambio.Anchor = AnchorStyles.None;
            label_valor_cambio.AutoSize = true;
            label_valor_cambio.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label_valor_cambio.ForeColor = Color.Gold;
            label_valor_cambio.Location = new Point(265, 8);
            label_valor_cambio.Name = "label_valor_cambio";
            label_valor_cambio.Size = new Size(193, 37);
            label_valor_cambio.TabIndex = 90;
            label_valor_cambio.Text = "Valor cambio:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = Color.Gold;
            label1.Location = new Point(34, 0);
            label1.Name = "label1";
            label1.Size = new Size(172, 53);
            label1.TabIndex = 89;
            label1.Text = "Valor entregado:";
            // 
            // label_valor_de_cambio
            // 
            label_valor_de_cambio.Anchor = AnchorStyles.None;
            label_valor_de_cambio.AutoSize = true;
            label_valor_de_cambio.Font = new Font("Segoe UI", 18F);
            label_valor_de_cambio.ForeColor = Color.LightSeaGreen;
            label_valor_de_cambio.Location = new Point(344, 72);
            label_valor_de_cambio.Name = "label_valor_de_cambio";
            label_valor_de_cambio.Size = new Size(34, 41);
            label_valor_de_cambio.TabIndex = 92;
            label_valor_de_cambio.Text = "0";
            // 
            // textBox_val_entregado
            // 
            textBox_val_entregado.Anchor = AnchorStyles.None;
            textBox_val_entregado.Font = new Font("Segoe UI", 18F);
            textBox_val_entregado.Location = new Point(22, 69);
            textBox_val_entregado.Name = "textBox_val_entregado";
            textBox_val_entregado.Size = new Size(197, 47);
            textBox_val_entregado.TabIndex = 88;
            textBox_val_entregado.Leave += textBox_val_entregado_Leave;
            // 
            // label_tipo_de_pago
            // 
            label_tipo_de_pago.Anchor = AnchorStyles.None;
            label_tipo_de_pago.AutoSize = true;
            label_tipo_de_pago.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label_tipo_de_pago.Location = new Point(135, 0);
            label_tipo_de_pago.Name = "label_tipo_de_pago";
            label_tipo_de_pago.Size = new Size(239, 46);
            label_tipo_de_pago.TabIndex = 66;
            label_tipo_de_pago.Text = "Tipo de pago:";
            label_tipo_de_pago.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.ColumnCount = 1;
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.Controls.Add(tableLayoutPanel5, 0, 0);
            tableLayoutPanel9.Dock = DockStyle.Top;
            tableLayoutPanel9.Location = new Point(0, 77);
            tableLayoutPanel9.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 1;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.Size = new Size(1232, 192);
            tableLayoutPanel9.TabIndex = 114;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel5.Controls.Add(button_buscar_placa, 0, 1);
            tableLayoutPanel5.Controls.Add(tableLayoutPanel6, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 3);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 58.064518F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 41.935482F));
            tableLayoutPanel5.Size = new Size(1226, 186);
            tableLayoutPanel5.TabIndex = 0;
            // 
            // button_buscar_placa
            // 
            button_buscar_placa.Anchor = AnchorStyles.None;
            button_buscar_placa.BackColor = Color.FromArgb(52, 152, 219);
            button_buscar_placa.Cursor = Cursors.Hand;
            button_buscar_placa.FlatAppearance.BorderSize = 0;
            button_buscar_placa.FlatStyle = FlatStyle.Flat;
            button_buscar_placa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button_buscar_placa.ForeColor = Color.White;
            button_buscar_placa.Location = new Point(493, 111);
            button_buscar_placa.Name = "button_buscar_placa";
            button_buscar_placa.Size = new Size(239, 72);
            button_buscar_placa.TabIndex = 122;
            button_buscar_placa.Text = "Buscar";
            button_buscar_placa.UseVisualStyleBackColor = false;
            button_buscar_placa.Click += button_buscar_placa_Click;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 5;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.950819F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.114754F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.3442631F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.7868843F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6.803279F));
            tableLayoutPanel6.Controls.Add(textBox_buscar_placa, 3, 0);
            tableLayoutPanel6.Controls.Add(label_placa, 2, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(3, 3);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Size = new Size(1220, 102);
            tableLayoutPanel6.TabIndex = 123;
            // 
            // textBox_buscar_placa
            // 
            textBox_buscar_placa.Anchor = AnchorStyles.Left;
            textBox_buscar_placa.Font = new Font("Segoe UI", 35F);
            textBox_buscar_placa.Location = new Point(679, 8);
            textBox_buscar_placa.Name = "textBox_buscar_placa";
            textBox_buscar_placa.Size = new Size(378, 85);
            textBox_buscar_placa.TabIndex = 67;
            textBox_buscar_placa.Click += textBox_buscar_placa_Click;
            // 
            // label_placa
            // 
            label_placa.Anchor = AnchorStyles.Left;
            label_placa.AutoSize = true;
            label_placa.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label_placa.Location = new Point(321, 22);
            label_placa.Name = "label_placa";
            label_placa.Size = new Size(289, 57);
            label_placa.TabIndex = 70;
            label_placa.Text = "Digitar placa:";
            label_placa.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TransaccionesCajaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1232, 1055);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tableLayoutPanel9);
            Controls.Add(tableLayoutPanel_footer);
            Controls.Add(tableLayoutPanel_logueado);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = false;
            Name = "TransaccionesCajaForm";
            Text = "PruebaForm";
            WindowState = FormWindowState.Maximized;
            tableLayoutPanel_logueado.ResumeLayout(false);
            tableLayoutPanel_logueado.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel_footer.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel_datos_placa.ResumeLayout(false);
            tableLayoutPanel_datos_placa.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel_usuario_encontrado.ResumeLayout(false);
            tableLayoutPanel_usuario_encontrado.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel9.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel_logueado;
        private FontAwesome.Sharp.IconButton iconButton_regresar;
        private Label label_titulo_transacciones;
        private Panel panel1;
        private PictureBox pictureBox1;
        private TableLayoutPanel tableLayoutPanel_footer;
        private Button button_realizar_transaccion;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label_tipo_de_pago;
        private FlowLayoutPanel flowLayoutPanel4;
        private Button button_efectivo;
        private Button button_tarjeta;
        private Button button_transferencia;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button button_consumidor_final;
        private Button button_con_datos;
        private TableLayoutPanel tableLayoutPanel_usuario_encontrado;
        private Label label_telefono;
        private Label label_correo;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label label_titulo_usuario;
        private TextBox textBox_usuario_encontrar;
        private Button button_buscar_usuario;
        private Button button_agregar_user;
        private Label label_cedula;
        private Label label_nombre;
        private TableLayoutPanel tableLayoutPanel4;
        private Label label_valor_cambio;
        private Label label1;
        private Label label_valor_de_cambio;
        private TextBox textBox_val_entregado;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label_titulo_datos_placas;
        private TableLayoutPanel tableLayoutPanel_datos_placa;
        private Label label_hora_ingreso;
        private Label label_valor_hora_ingreso;
        private Label label_hora_estacionamiento;
        private Label label_valor_tiempo;
        private Label label_valor_cobrar;
        private Label label_valor_a_cobrar;
        private TableLayoutPanel tableLayoutPanel9;
        private TableLayoutPanel tableLayoutPanel5;
        private Button button_buscar_placa;
        private TableLayoutPanel tableLayoutPanel6;
        private TextBox textBox_buscar_placa;
        private Label label_placa;
    }
}