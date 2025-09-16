using ProyectoAndina.Controllers;
using ProyectoAndina.Models;
using ProyectoAndina.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProyectoAndina.Utils.StylesAlertas;

namespace ProyectoAndina.Views
{
    public partial class CajaCrudForm : Form
    {
        private readonly CajaController _CajaController;
        private ValidacionHelper validador;
        public int caja_id;
        private Form _formularioPadre;
        public CajaCrudForm(int id, Form formularioPadre = null)
        {
            // Config típica de diálogo modal
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.TopMost = true;
            this.KeyPreview = false;

            InitializeComponent();
            _CajaController = new CajaController();
            validador = new ValidacionHelper(this);
            ConfigurarValidacion();
            this.Paint += CajaCrudForm_Paint;
            _formularioPadre = formularioPadre;


            if (id == 0)
            {
                LimpiarCampos();
            }
            else
            {
                cargarDatosCaja(id);
                caja_id = id;
            }
        }

        private void ConfigurarValidacion()
        {
            validador = new ValidacionHelper(this);
            validador.AgregarControlRequerido(textBox_nombre, "El campo nombre es requerido");
            validador.AgregarControlRequerido(textBox_codigo, "El campo codigo es requerido");
            validador.AgregarControlRequerido(textBox_ubicacion, "El campo ubicación es requerido");
        }
        private void CajaCrudForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }
        public void cargarDatosCaja(int id)
        {
            var caja = _CajaController.ObtenerPorId(id);

            if (caja != null)
            {
                StyleButton.CrearBotonElegante(button_accion, FontAwesome.Sharp.IconChar.Rotate);
                button_accion.Text = "Actualizar";
                textBox_nombre.Text = caja.nombre;
                textBox_codigo.Text = caja.codigo;
                textBox_ubicacion.Text = caja.ubicacion;
            }
            
        }

        public void LimpiarCampos()
        {
            StyleButton.CrearBotonElegante(button_accion, FontAwesome.Sharp.IconChar.Plus);
            button_accion.Text = "Crear";
            textBox_nombre.Text = "";
            textBox_codigo.Text = "";
            textBox_ubicacion.Text = "";
        }

        private void button_accion_Click(object sender, EventArgs e)
        {

            //revisar sobre persona y rol
            if (!validador.ValidarTodosLosControles())
            {
                validador.MostrarMensajeValidacion();
                return;
            }

            var codigo = textBox_codigo.Text.Trim();
            var nombre = textBox_nombre.Text.Trim();
            var ubicacion = textBox_ubicacion.Text.Trim();
            var ip_equipo = ObtenerIpLocal();


            var cajaEncontrada = _CajaController.ObtenerPorcodigo(codigo);
            if (cajaEncontrada != null) {
                StylesAlertas.MostrarAlerta(this, "Ya existe el codigo", "¡Error!", TipoAlerta.Error);
                return;
            }


            var Caja = new CajaM
            {
                codigo = codigo,
                nombre = nombre,
                ubicacion = ubicacion,
                ip_equipo = ip_equipo,
                estado = true,
                fecha_creacion = DateTime.Now
            };


            var accion = button_accion.Text;
            if (accion == "Crear")
            {
                _CajaController.Insertar(Caja);
                StylesAlertas.MostrarAlerta(this, "Registro creado correctamente", tipo: TipoAlerta.Success);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {

                Caja.caja_id = caja_id;
                _CajaController.Actualizar(Caja);
                StylesAlertas.MostrarAlerta(this, "Registro actualizado correctamente", tipo: TipoAlerta.Success);
                this.DialogResult = DialogResult.OK; // opcional, útil si quieres saber desde el form padre que se creó
                this.Close();
            }
        }
        private string ObtenerIpLocal()
        {
            string nombreHost = Dns.GetHostName();
            foreach (var ip in Dns.GetHostAddresses(nombreHost))
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "IP no encontrada";
        }

        private void textBox_codigo_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();
        }

        private void textBox_nombre_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();
        }

        private void textBox_ubicacion_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();
        }
    }
}
