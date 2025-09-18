using ProyectoAndina.Utils;
using System;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace ProyectoAndina.Views
{
    public partial class ImpresionComprobanteForm : Form
    {
        private readonly ReciboModel reciboActual;

        public ImpresionComprobanteForm(ReciboModel reciboActual)
        {
            InitializeComponent();
            this.reciboActual = reciboActual;

            // Config típica de diálogo modal
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.TopMost = true;
            this.KeyPreview = false;

        }

        private void ImpresionComprobanteForm_Load(object sender, EventArgs e)
        {
            try
            {
                comboBoxImpresoras.Items.Clear();

                foreach (string impresora in PrinterSettings.InstalledPrinters)
                    comboBoxImpresoras.Items.Add(impresora);

                // Selecciona la predeterminada si existe
                var predeterminada = new PrinterSettings().PrinterName;
                if (!string.IsNullOrWhiteSpace(predeterminada) &&
                    comboBoxImpresoras.Items.Cast<string>().Any(p => p.Equals(predeterminada, StringComparison.OrdinalIgnoreCase)))
                {
                    comboBoxImpresoras.SelectedItem = predeterminada;
                }
                else if (comboBoxImpresoras.Items.Count > 0)
                {
                    comboBoxImpresoras.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                // No cierres el form aquí; solo informa
                Debug.WriteLine($"Error cargando impresoras: {ex}");
                MessageBox.Show(this, "No se pudieron cargar las impresoras instaladas.",
                    "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void comboBoxImpresoras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxImpresoras.SelectedItem is string impresora && !string.IsNullOrWhiteSpace(impresora))
            {
                ConfiguracionImpresora.ImpresoraSeleccionada = impresora;
            }
        }

        private async void button_imprimir_Click(object sender, EventArgs e)
        {
            // Evita doble clic
            button_imprimir.Enabled = false;
            try
            {
                // Por si no hay selección (fallback)
                if (string.IsNullOrWhiteSpace(ConfiguracionImpresora.ImpresoraSeleccionada) &&
                    comboBoxImpresoras.SelectedItem is string impresoraSel)
                {
                    ConfiguracionImpresora.ImpresoraSeleccionada = impresoraSel;
                }

                if (string.IsNullOrWhiteSpace(ConfiguracionImpresora.ImpresoraSeleccionada))
                {
                    MessageBox.Show(this, "Selecciona una impresora.", "Impresión",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Si ImprimirRecibo es bloqueante, puedes envolverlo en Task.Run
                // para no congelar el UI. Si ya es rápido/sincrónico, puedes llamarlo directo.
                await Task.Run(() =>
                {
                    var impresor = new DatosImpresion();
                    impresor.ImprimirRecibo(reciboActual, ConfiguracionImpresora.ImpresoraSeleccionada);
                    AbrirCajon(ConfiguracionImpresora.ImpresoraSeleccionada);
                });

                this.DialogResult = DialogResult.OK; // cierra ShowDialog con OK
                this.Close();
            }
            catch (Exception ex)
            {
                // No cierres el form; muestra el error
                Debug.WriteLine($"Error imprimiendo: {ex}");
                MessageBox.Show(this, "Ocurrió un error al imprimir el comprobante.",
                    "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                button_imprimir.Enabled = true;
            }
        }

        private void AbrirCajon(string nombreImpresora)
        {
            try
            {
                // Comando ESC/POS abrir cajón
                byte[] abrirCajon = new byte[] { 0x1B, 0x70, 0x00, 0x40, 0x50 };

                using (var print = new System.Drawing.Printing.PrintDocument())
                {
                    print.PrinterSettings.PrinterName = nombreImpresora;
                    print.PrintPage += (s, e) =>
                    {
                        e.Graphics.DrawString("", new Font("Arial", 1), Brushes.Black, new PointF(0, 0));
                        e.Graphics.DrawString("", new Font("Arial", 1), Brushes.Black, new PointF(0, 0));
                    };

                    // Enviar comando directo a la impresora
                    RawPrinterHelper.SendBytesToPrinter(nombreImpresora, abrirCajon, abrirCajon.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir cajón: {ex.Message}");
            }
        }

    }
}
