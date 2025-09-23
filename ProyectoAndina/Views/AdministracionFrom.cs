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
    public partial class AdministracionFrom : KioskForm
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
            var MenuPrincipalForm = new MenuPrincipalForm();
            this.Hide();
            MenuPrincipalForm.ShowDialog();
            this.Close();
        }

        private void tableLayoutPanel_personas_Click(object sender, EventArgs e)
        {
            TecladoHelper.CerrarTeclado();
            var PersonaForm = new PersonaForm();
            this.Hide();
            PersonaForm.ShowDialog();
            this.Close();
        }

        private void tableLayoutPanel_rol_Click(object sender, EventArgs e)
        {
            TecladoHelper.CerrarTeclado();
            var RolForm = new RolForm();
            this.Hide();
            RolForm.ShowDialog();
            this.Close();
        }

        private void tableLayoutPanel_asignar_rol_Click(object sender, EventArgs e)
        {
            TecladoHelper.CerrarTeclado();
            var PersonaRolForm = new PersonaRolForm();
            this.Hide();
            PersonaRolForm.ShowDialog();
            this.Close();
        }

        private void tableLayoutPanel_cajas_Click(object sender, EventArgs e)
        {

            TecladoHelper.CerrarTeclado();
            var CajaForm = new CajaForm();
            this.Hide();
            CajaForm.ShowDialog();
            this.Close();
        }

        private void tableLayoutPanel_arqueo_cajas_Click(object sender, EventArgs e)
        {
            TecladoHelper.CerrarTeclado();
            var ArqueosCajasForm = new ArqueosCajasForm();
            this.Hide();
            ArqueosCajasForm.ShowDialog();
            this.Close();
        }

        private void tableLayoutPanel_transacciones_Click(object sender, EventArgs e)
        {
            TecladoHelper.CerrarTeclado();
            var TransaccionesForm = new TransaccionesForm();
            this.Hide();
            TransaccionesForm.ShowDialog();
            this.Close();
        }
    }
}
