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
    public partial class AdministracionFrom : Form
    {
        public AdministracionFrom()
        {


            InitializeComponent();
            StyleContenedores.EstilizarTableLayout(tableLayoutPanel_arqueo_cajas, Color.FromArgb(0, 148, 144));
            StyleContenedores.EstilizarTableLayout(tableLayoutPanel_personas, Color.FromArgb(0, 148, 144));
            StyleContenedores.EstilizarTableLayout(tableLayoutPanel_rol, Color.FromArgb(0, 148, 144));
            StyleContenedores.EstilizarTableLayout(tableLayoutPanel_asignar_rol, Color.FromArgb(0, 148, 144));
            StyleContenedores.EstilizarTableLayout(tableLayoutPanel_cajas, Color.FromArgb(0, 148, 144));
            StyleContenedores.EstilizarTableLayout(tableLayoutPanel_transacciones, Color.FromArgb(0, 148, 144));

            this.Paint += AdministracionFrom_Paint;
        }
        private void AdministracionFrom_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }

        private void iconButton_regresar_Click(object sender, EventArgs e)
        {
            TecladoHelper.CerrarTeclado();
            
        }

        private void AbrirFormEnPanel(object formhija)
        {
            if (this.panel_contenedor.Controls.Count > 0)
                this.panel_contenedor.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panel_contenedor.Controls.Add(fh);
            this.panel_contenedor.Tag = fh;
            fh.Show();

        }

        private void tableLayoutPanel_personas_Click(object sender, EventArgs e)
        {
            TecladoHelper.CerrarTeclado();
            AbrirFormEnPanel(new PersonaForm());
        }

        private void tableLayoutPanel_rol_Click(object sender, EventArgs e)
        {
            TecladoHelper.CerrarTeclado();
            AbrirFormEnPanel(new RolForm());
           
        }

        private void tableLayoutPanel_asignar_rol_Click(object sender, EventArgs e)
        {
            TecladoHelper.CerrarTeclado();
            AbrirFormEnPanel(new PersonaRolForm());
        }

        private void tableLayoutPanel_cajas_Click(object sender, EventArgs e)
        {

            TecladoHelper.CerrarTeclado();
            AbrirFormEnPanel(new RolForm());
        }

        private void tableLayoutPanel_arqueo_cajas_Click(object sender, EventArgs e)
        {
            TecladoHelper.CerrarTeclado();
            AbrirFormEnPanel(new ArqueosCajasForm());
        }

        private void tableLayoutPanel_transacciones_Click(object sender, EventArgs e)
        {
            TecladoHelper.CerrarTeclado();
            AbrirFormEnPanel(new TransaccionesForm());
        }
    }
}
