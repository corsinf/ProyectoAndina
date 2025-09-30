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
    public partial class AbrirBarreraForm : Form
    {
        private System.Windows.Forms.Timer progressTimer;
        private int currentProgress = 0;
        public AbrirBarreraForm()
        {
            InitializeComponent();
            InicializarProgressBar();
        }

        private void InicializarProgressBar()
        {
            // Configurar el ProgressBar
            progressBar_cargar.Minimum = 0;
            progressBar_cargar.Maximum = 100;
            progressBar_cargar.Value = 0;

            // Configurar el Timer
            progressTimer = new System.Windows.Forms.Timer();
            progressTimer.Interval = 30; // 30ms por cada incremento (3000ms / 100 incrementos = 30ms)
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

        private void OnCargaCompleta()
        {
            // Aquí puedes agregar lo que quieres que suceda cuando termine la carga
            // Por ejemplo:
            // MessageBox.Show("Verificación completada!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // this.Close(); // Si quieres cerrar el formulario

            // O cualquier otra lógica que necesites
            label_progreso.Text = "¡Verificación completada!";
            this.DialogResult = DialogResult.OK; // cierra ShowDialog con OK
            this.Close();
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

        
       
    }
}
