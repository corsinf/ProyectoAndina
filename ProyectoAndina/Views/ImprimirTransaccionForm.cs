using ProyectoAndina.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoAndina.Views
{
    public partial class ImprimirTransaccionForm : Form
    {
        private System.Windows.Forms.Timer progressTimer;
        private int currentProgress = 0;
        private readonly ReciboModel reciboActual;
        private bool yaImprimio = false;
        public ImprimirTransaccionForm(ReciboModel reciboActual)
        {
            this.reciboActual = reciboActual;
            InitializeComponent();
            InicializarProgressBar();
        }

        private void InicializarProgressBar()
        {
            // Configurar el ProgressBar
            progressBar_cargar.Minimum = 0;
            progressBar_cargar.Maximum = 100;
            progressBar_cargar.Value = 0;

            // Configurar el Timer (10ms x 100 pasos = 1000ms = 1s)
            progressTimer = new System.Windows.Forms.Timer();
            progressTimer.Interval = 10;
            progressTimer.Tick += ProgressTimer_Tick;

            // Inicializar el label
            label_progreso.Text = "0%";

            // Iniciar la simulación automáticamente
            IniciarCarga();
        }



        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            currentProgress++;

            // Actualizar el ProgressBar
            progressBar_cargar.Value = currentProgress;

            // Actualizar el Label
            label_progreso.Text = $"{currentProgress}%";

            // Si llegamos al 100%, detener el timer
            if (currentProgress >= 100)
            {
                progressTimer.Stop();
                OnCargaCompleta();
            }
        }

        private void IniciarCarga()
        {
            // Reiniciar valores
            currentProgress = 0;
            progressBar_cargar.Value = 0;
            label_progreso.Text = "0%";

            // Iniciar el timer
            progressTimer.Start();
        }
        
        private async void OnCargaCompleta()
        {
            if (yaImprimio)
                return; // si ya imprimió, no hace nada

            yaImprimio = true; // marca que ya imprimió

            try
            {
                await Task.Run(() =>
                {
                    var impresor = new DatosImpresion();
                    impresor.ImprimirRecibo(reciboActual, ConfiguracionImpresora.ImpresoraSeleccionada);
                    AbrirCajon(ConfiguracionImpresora.ImpresoraSeleccionada);
                });

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Ocurrió un error al imprimir el comprobante.",
                    "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Si quieres permitir reintento en caso de error, descomenta:
                yaImprimio = false;
            }
        }


        // Método público para reiniciar la carga si lo necesitas
        public void ReiniciarCarga()
        {
            if (progressTimer.Enabled)
            {
                progressTimer.Stop();
            }
            IniciarCarga();
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
