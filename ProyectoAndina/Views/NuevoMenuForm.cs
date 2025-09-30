using ProyectoAndina.Controllers;
using ProyectoAndina.Models;
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
using static ProyectoAndina.Utils.StylesAlertas;

namespace ProyectoAndina.Views
{
    public partial class NuevoMenuForm : Form
    {
        private readonly ArqueoCajaController _ArqueoCajaController;
        private readonly ArqueoBilletesController _ArqueoBilletesController;
        private readonly RolController _RolController;
        private readonly PersonaRolController _PersonaRolController;
        private readonly FuncionesJson _FuncionesJson;
        string _rol;
        public NuevoMenuForm()
        {
            InitializeComponent();

            _ArqueoCajaController = new ArqueoCajaController();
            _ArqueoBilletesController = new ArqueoBilletesController();
            _RolController = new RolController();
            _PersonaRolController = new PersonaRolController();
            _FuncionesJson = new FuncionesJson();
            CargarUsuarioLogueado();
            


            this.Paint += NuevoMenuForm_Paint;
        }

        private void NuevoMenuForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }

       

        public void CargarUsuarioLogueado()
        {
            //label_persona_logueada.Text = "Bienvenido : " + SessionUser.Correo;
            //label_rol.Text = "Rol : " + SessionUser.Rol;

            if (SessionUser.Rol == "cajero")
            {
                tableLayoutPanel_admin.Visible = false;

                tableLayoutPanel_admin.ColumnStyles[2].Width = 0;
            }

        }
        private void AbrirFormEnPanel(object formhija)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();

        }

        public void CerrarFormHijo()
        {
            if (panelContenedor.Controls.Count > 0)
            {
                Form fh = panelContenedor.Controls[0] as Form;
                if (fh != null)
                    fh.Close();

                panelContenedor.Controls.Clear();
            }
        }

        private void iconPictureBox_arqueo_caja_Click(object sender, EventArgs e)
        {

            var buscarArqueo = _ArqueoCajaController.ObtenerPorArqueoCajaPendiente(SessionUser.id_persona_rol);
            int cajaConfig = _FuncionesJson.CargarCajaDesdeConfig();
            var arqueoAbierto = _ArqueoCajaController.ArqueoCajaAbierta(cajaConfig);

            if (arqueoAbierto != null)
            {
                if (arqueoAbierto.id_persona_rol != SessionUser.id_persona_rol)
                {
                    // La caja está abierta por otra persona
                    StylesAlertas.MostrarAlerta(this, "La caja ya está abierta por otra persona", "¡Error!", TipoAlerta.Error);
                    return;
                }
                // Si es la misma persona, puede continuar
            }

            if (buscarArqueo != null)
            {
                SessionArqueoCaja.id_arqueo_caja = buscarArqueo.arqueo_id;
                TecladoHelper.CerrarTeclado();
                AbrirFormEnPanel(new ArqueoCajaForm(buscarArqueo.arqueo_id));
                CambioEstiloNavegador("arqueo");

            }
            else
            {
                TecladoHelper.CerrarTeclado();
                AbrirFormEnPanel(new ArqueoCajaForm(0));
                CambioEstiloNavegador("arqueo");
            }

        }

        private void iconPictureBox_transacciones_Click(object sender, EventArgs e)
        {

            var buscarArqueo = _ArqueoCajaController.ObtenerPorArqueoCajaPendiente(SessionUser.id_persona_rol);


            if (buscarArqueo != null)
            {
                var buscarArqueoBilletes = _ArqueoBilletesController.obtener_arqueo_billetes(buscarArqueo.arqueo_id);

                if (buscarArqueoBilletes != null)
                {

                    SessionArqueoCaja.id_arqueo_caja = buscarArqueo.arqueo_id;
                    TecladoHelper.CerrarTeclado();
                    AbrirFormEnPanel(new TransaccionesCajaForm());
                    CambioEstiloNavegador("transaccion");

                }
                else
                {
                    StylesAlertas.MostrarAlerta(this, "Complete el arqueo de caja para continuar", "¡Error!", TipoAlerta.Error);
                }
            }
            else
            {
                StylesAlertas.MostrarAlerta(this, "No existe ningun arqueo de caja pendiente", "¡Error!", TipoAlerta.Error);
            }

        }

        private void CambioEstiloNavegador(String modulo)
        {

            if (modulo == "admin")
            {
                // Activo: Administración
                panel3.BackColor = Color.FromArgb(70, 130, 140);
                iconPictureBox_administracion.ForeColor = Color.Black;
                label_administracion.ForeColor = Color.Black;
                tableLayoutPanel_admin.BackColor = Color.White;

                // Reset: Arqueo Caja
                panel1.BackColor = Color.FromArgb(52, 73, 85); // Color por defecto
                iconPictureBox_arqueo_caja.ForeColor = Color.White; // Color por defecto
                label_titulo_arqueo.ForeColor = Color.White;
                tableLayoutPanel_arqueo.BackColor = Color.FromArgb(0, 71, 80);

                // Reset: Transacciones
                panel2.BackColor = Color.FromArgb(52, 73, 85);
                iconPictureBox_transacciones.ForeColor = Color.White;
                label_titulo_transacciones.ForeColor = Color.White;
                tableLayoutPanel_transaccion.BackColor = Color.FromArgb(0, 71, 80);

            }
            else if (modulo == "arqueo")
            {
                // Reset: Administración
                panel3.BackColor = Color.FromArgb(52, 73, 85);
                iconPictureBox_administracion.ForeColor = Color.White;
                label_administracion.ForeColor = Color.White;
                tableLayoutPanel_admin.BackColor = Color.FromArgb(0, 71, 80);

                // Activo: Arqueo Caja
                panel1.BackColor = Color.FromArgb(70, 130, 140);
                iconPictureBox_arqueo_caja.ForeColor = Color.Black;
                label_titulo_arqueo.ForeColor = Color.Black;
                tableLayoutPanel_arqueo.BackColor = Color.White;

                // Reset: Transacciones
                panel2.BackColor = Color.FromArgb(52, 73, 85);
                iconPictureBox_transacciones.ForeColor = Color.White;
                label_titulo_transacciones.ForeColor = Color.White;
                tableLayoutPanel_transaccion.BackColor = Color.FromArgb(0, 71, 80);

            }
            else if (modulo == "transaccion")
            {
                // Reset: Administración
                panel3.BackColor = Color.FromArgb(52, 73, 85);
                iconPictureBox_administracion.ForeColor = Color.White;
                label_administracion.ForeColor = Color.White;
                tableLayoutPanel_admin.BackColor = Color.FromArgb(0, 71, 80);

                // Reset: Arqueo Caja
                panel1.BackColor = Color.FromArgb(52, 73, 85);
                iconPictureBox_arqueo_caja.ForeColor = Color.White;
                label_titulo_arqueo.ForeColor = Color.White;
                tableLayoutPanel_arqueo.BackColor = Color.FromArgb(0, 71, 80);

                // Activo: Transacciones
                panel2.BackColor = Color.FromArgb(70, 130, 140);
                iconPictureBox_transacciones.ForeColor = Color.Black;
                label_titulo_transacciones.ForeColor = Color.Black;
                tableLayoutPanel_transaccion.BackColor = Color.White;
            }

        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconPictureBox_administracion_Click(object sender, EventArgs e)
        {
            if (SessionUser.Rol == "admin")
            {
                TecladoHelper.CerrarTeclado();
                AbrirFormEnPanel(new AdministracionFrom());
                CambioEstiloNavegador("admin");

            }
            if (SessionUser.Rol == "cajero")
            {
                StylesAlertas.MostrarAlerta(this, "No puede acceder a este módulo", "¡Error!", TipoAlerta.Error);
            }
        }

        private void iconPictureBox_cerrar_session_Click(object sender, EventArgs e)
        {
            TecladoHelper.CerrarTeclado();
            var NuevoLoginForm = new NuevoLoginForm();
            this.Hide();                 // Opcional: ocultas la ventana actual
            NuevoLoginForm.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
            this.Close();
        }

        private void iconPictureBox_abrirBarrera_Click(object sender, EventArgs e)
        {
            using (var frm = new AbrirBarreraForm())
            {
                // Redundante si ya lo seteaste en el ctor; no hace daño:
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.TopMost = true;

                var resultado = frm.ShowDialog(this);  // ¡IMPORTANTE: owner!

                if (resultado == DialogResult.OK)
                {
                    StylesAlertas.MostrarAlerta(this, "Barrera Abierta con exito", tipo: TipoAlerta.Success);
                }
            }
        }
    }
}
