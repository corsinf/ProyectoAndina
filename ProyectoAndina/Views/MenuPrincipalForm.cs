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
        private readonly FuncionesJson _FuncionesJson;
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
            _FuncionesJson = new FuncionesJson();
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
            label_rol.Text = "Rol : " + SessionUser.Rol;

            if (SessionUser.Rol == "cajero") {
                tableLayoutPanel_admin.Visible = false;
                tableLayoutPanel_contenido.ColumnStyles[0].Width = 10;
                tableLayoutPanel_contenido.ColumnStyles[1].Width = 0;
                tableLayoutPanel_contenido.ColumnStyles[2].Width = 40;
                tableLayoutPanel_contenido.ColumnStyles[3].Width = 40;
                tableLayoutPanel_contenido.ColumnStyles[4].Width = 10;
            }
        }

        private void button_cerrar_session_Click(object sender, EventArgs e)
        {
            TecladoHelper.CerrarTeclado();
            var NuevoLoginForm = new NuevoLoginForm();
            this.Hide();                 // Opcional: ocultas la ventana actual
            NuevoLoginForm.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
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
                    TecladoHelper.CerrarTeclado();
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
                StylesAlertas.MostrarAlerta(this, "Tiene una arqueo de caja abierto", "Aviso", TipoAlerta.Info);
                TecladoHelper.CerrarTeclado();
                var nuevoForm = new ArqueoCajaForm(buscarArqueo.arqueo_id);
                nuevoForm.StartPosition = FormStartPosition.Manual;
                nuevoForm.Location = this.Location;
                nuevoForm.Size = this.Size;

                this.Visible = false;  // MÁS RÁPIDO que Hide()
                nuevoForm.ShowDialog();
                this.Close();
            }
            else
            {
                TecladoHelper.CerrarTeclado();
                var nuevoForm = new ArqueoCajaForm(0);
                nuevoForm.StartPosition = FormStartPosition.Manual;
                nuevoForm.Location = this.Location;
                nuevoForm.Size = this.Size;

                this.Visible = false;  // MÁS RÁPIDO que Hide()
                nuevoForm.ShowDialog();
                this.Close();
            }
        }

        private void tableLayoutPanel_admin_Click(object sender, EventArgs e)
        {
           if(SessionUser.Rol == "admin")
            {
                TecladoHelper.CerrarTeclado();
                var AdministracionFrom = new AdministracionFrom();
                AdministracionFrom.Show(); 

            }
            if (SessionUser.Rol == "cajero")
            {
                StylesAlertas.MostrarAlerta(this, "No puede acceder a este módulo", "¡Error!", TipoAlerta.Error);
            }

        }

        private void label_persona_logueada_Click(object sender, EventArgs e)
        {

        }
    }
}
