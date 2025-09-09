using ProyectoAndina.Utils;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAndina.Views
{
    public partial class TemplateImpresionRecibo : Form
    {

        ReciboModel reciboActual;
        public TemplateImpresionRecibo(ReciboModel recibo)
        {
            InitializeComponent();
            reciboActual = recibo;
        }

        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBox_logo_tipo = new PictureBox();
            panel_formulario = new Panel();
            button_imprimir = new Button();
            comboBoxImpresoras = new ComboBox();
            lbl_nombre = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_tipo).BeginInit();
            panel_formulario.SuspendLayout();
            SuspendLayout();
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
            tableLayoutPanel1.Size = new Size(447, 75);
            tableLayoutPanel1.TabIndex = 83;
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
            // panel_formulario
            // 
            panel_formulario.BackColor = Color.Transparent;
            panel_formulario.Controls.Add(button_imprimir);
            panel_formulario.Controls.Add(comboBoxImpresoras);
            panel_formulario.Controls.Add(lbl_nombre);
            panel_formulario.Dock = DockStyle.Fill;
            panel_formulario.Location = new Point(0, 75);
            panel_formulario.Name = "panel_formulario";
            panel_formulario.Size = new Size(447, 410);
            panel_formulario.TabIndex = 84;
            // 
            // button_imprimir
            // 
            button_imprimir.Location = new Point(161, 258);
            button_imprimir.Name = "button_imprimir";
            button_imprimir.Size = new Size(94, 29);
            button_imprimir.TabIndex = 31;
            button_imprimir.Text = "Imprimir";
            button_imprimir.UseVisualStyleBackColor = true;
            button_imprimir.Click += button_imprimir_Click;
            // 
            // comboBoxImpresoras
            // 
            comboBoxImpresoras.FormattingEnabled = true;
            comboBoxImpresoras.Location = new Point(145, 60);
            comboBoxImpresoras.Name = "comboBoxImpresoras";
            comboBoxImpresoras.Size = new Size(151, 28);
            comboBoxImpresoras.TabIndex = 30;
            comboBoxImpresoras.SelectedIndexChanged += comboBoxImpresoras_SelectedIndexChanged;
            // 
            // lbl_nombre
            // 
            lbl_nombre.AutoSize = true;
            lbl_nombre.Location = new Point(161, 154);
            lbl_nombre.Name = "lbl_nombre";
            lbl_nombre.Size = new Size(95, 20);
            lbl_nombre.TabIndex = 29;
            lbl_nombre.Text = "Imprimiendo";
            // 
            // TemplateImpresionRecibo
            // 
            ClientSize = new Size(447, 485);
            Controls.Add(panel_formulario);
            Controls.Add(tableLayoutPanel1);
            Name = "TemplateImpresionRecibo";
            Load += TemplateImpresionRecibo_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo_tipo).EndInit();
            panel_formulario.ResumeLayout(false);
            panel_formulario.PerformLayout();
            ResumeLayout(false);

        }
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel_formulario;
        private Label lbl_nombre;
        private ComboBox comboBoxImpresoras;
        private Button button_imprimir;
        private PictureBox pictureBox_logo_tipo;

        private void TemplateImpresionRecibo_Load(object sender, EventArgs e)
        {
            foreach (string impresora in PrinterSettings.InstalledPrinters)
            {
                comboBoxImpresoras.Items.Add(impresora);
            }

            // Selecciona la predeterminada
            comboBoxImpresoras.SelectedItem = new PrinterSettings().PrinterName;
        }

        private void comboBoxImpresoras_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfiguracionImpresora.ImpresoraSeleccionada = comboBoxImpresoras.SelectedItem.ToString();
        }

        private void button_imprimir_Click(object sender, EventArgs e)
        {
           
                MostrarPdf.GenerarPDFConsumidorFinal();


                var impresor = new DatosImpresion();
                impresor.ImprimirRecibo(reciboActual, ConfiguracionImpresora.ImpresoraSeleccionada);
                MostrarPdf.GenerarPDFFactura(reciboActual);
        }
    }
}
