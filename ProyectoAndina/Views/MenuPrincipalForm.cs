using ProyectoAndina.Controllers;
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
    public partial class MenuPrincipalForm : KioskForm
    {
        private readonly ArqueoCajaController _ArqueoCajaController;
        private readonly ArqueoBilletesController _ArqueoBilletesController;
        private readonly RolController _RolController;
        private readonly PersonaRolController _PersonaRolController;
        public bool estado_admin;
        public bool estado_arqueo;
        public bool estado_transacciones;
        public MenuPrincipalForm()
        {
            InitializeComponent();

            StyleContenedores.EstilizarTableLayout(tableLayoutPanel_transacciones, Color.FromArgb(0, 148, 144));
            StyleContenedores.EstilizarTableLayout(tableLayoutPanel_admin, Color.FromArgb(0, 148, 144));
            StyleContenedores.EstilizarTableLayout(tableLayoutPanel_arqueo, Color.FromArgb(0, 148, 144));

            _ArqueoCajaController = new ArqueoCajaController();
            _ArqueoBilletesController = new ArqueoBilletesController();
            _RolController = new RolController();
            _PersonaRolController = new PersonaRolController();
            CargarUsuarioLogueado();

            this.Paint += LoginForm_Paint;

        }

        private void LoginForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }

        public void CargarUsuarioLogueado()
        {
            label_persona_logueada.Text = "Bienvenido : " + SessionUser.Correo;

            var rolPersonaList = _PersonaRolController.ObtenerPersonaRolId(SessionUser.id_persona_rol);
            if (rolPersonaList != null)
            {
                var rolPersona = rolPersonaList; // Tomamos el primero
                var rol = _RolController.ObtenerRolPorId(rolPersona.RolId);

                if (rol != null)
                {
                    label_rol.Text = "Rol : " + rol.Nombre.ToString();

                    if (rol.Nombre == "admin" || rol.RolId == 1)
                    {
                        estado_admin = true;
                        estado_arqueo = true;
                        estado_transacciones = true;
                    }

                    if (rol.Nombre == "cajero" || rol.RolId == 2)
                    {
                        estado_admin = false;
                        estado_arqueo = true;
                        estado_transacciones = true;
                    }

                }

            }
            else
            {
                label_rol.Text = "Rol : Sin rol";
                estado_admin = false;
                estado_arqueo = false;
                estado_transacciones = false;

            }

        }

        private void button_cerrar_session_Click(object sender, EventArgs e)
        {
            var LoginForm = new LoginForm();
            this.Hide();                 // Opcional: ocultas la ventana actual
            LoginForm.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
            this.Close();
        }

       

        private void tableLayoutPanel_transacciones_Click(object sender, EventArgs e)
        {
            var buscarArqueo = _ArqueoCajaController.ObtenerPorArqueoCajaPendiente(SessionUser.id_persona_rol);

            if (buscarArqueo != null)
            {
                var buscarArqueoBilletes = _ArqueoBilletesController.obtener_arqueo_billetes(buscarArqueo.arqueo_id);

                if (buscarArqueoBilletes != null)
                {

                    SessionArqueoCaja.id_arqueo_caja = buscarArqueo.arqueo_id;
                    var TransaccionesCajaForm = new TransaccionesCajaForm();
                    this.Hide();                 // Opcional: ocultas la ventana actual
                    TransaccionesCajaForm.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
                    this.Close();
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

        private void tableLayoutPanel_arqueo_Click(object sender, EventArgs e)
        {
            var buscarArqueo = _ArqueoCajaController.ObtenerPorArqueoCajaPendiente(SessionUser.id_persona_rol);

            if (buscarArqueo != null)
            {
                SessionArqueoCaja.id_arqueo_caja = buscarArqueo.arqueo_id;
                StylesAlertas.MostrarAlerta(this, "Tiene una arqueo de caja abierto", "Aviso", TipoAlerta.Info);
                var ArqueoCajaForm = new ArqueoCajaForm(buscarArqueo.arqueo_id);
                this.Hide();
                ArqueoCajaForm.ShowDialog();
                this.Close();
            }
            else
            {
                var ArqueoCajaForm = new ArqueoCajaForm(0);
                this.Hide();
                ArqueoCajaForm.ShowDialog();
                this.Close();
            }
        }

        private void tableLayoutPanel_admin_Click(object sender, EventArgs e)
        {
            var AdministracionFrom = new AdministracionFrom();
            this.Hide();                 // Opcional: ocultas la ventana actual
            AdministracionFrom.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
            this.Close();
        }
    }
}
