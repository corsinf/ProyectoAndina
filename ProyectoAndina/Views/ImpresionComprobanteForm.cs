using ProyectoAndina.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoAndina.Views
{
    public partial class ImpresionComprobanteForm : Form
    {
        ReciboModel reciboActual;
        public ImpresionComprobanteForm(ReciboModel reciboActual)
        {
            InitializeComponent();
            this.reciboActual = reciboActual;
        }

        private void button_imprimir_Click(object sender, EventArgs e)
        {
            var impresor = new DatosImpresion();
            impresor.ImprimirRecibo(reciboActual, ConfiguracionImpresora.ImpresoraSeleccionada);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void comboBoxImpresoras_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfiguracionImpresora.ImpresoraSeleccionada = comboBoxImpresoras.SelectedItem.ToString();
        }



        private void ImpresionComprobanteForm_Load(object sender, EventArgs e)
        {
            foreach (string impresora in PrinterSettings.InstalledPrinters)
            {
                comboBoxImpresoras.Items.Add(impresora);
            }

            // Selecciona la predeterminada
            comboBoxImpresoras.SelectedItem = new PrinterSettings().PrinterName;
        }
    }
}
