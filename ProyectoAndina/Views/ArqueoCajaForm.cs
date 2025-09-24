using FontAwesome.Sharp;
using ProyectoAndina.Controllers;
using ProyectoAndina.Helper;
using ProyectoAndina.Models;
using ProyectoAndina.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Org.BouncyCastle.Math.EC.ECCurve;
using static ProyectoAndina.Utils.StylesAlertas;

namespace ProyectoAndina.Views
{
    public partial class ArqueoCajaForm : Form
    {
        private readonly ArqueoCajaController _AperturaCajaController;
        private readonly ArqueoBilletesController _ArqueoBilletesController;
        private readonly CajaController _CajaController;
        private readonly TransaccionCajaController _TransaccionesCaja;
        private readonly FuncionesGenerales _FuncionesGenerales;
        private readonly FuncionesJson _FuncionesJson;
        private ValidacionHelper validador;
        public int arqueo_caja_id;
        public string tipo_arqueo;


        public ArqueoCajaForm(int id_arqueo_caja)
        {

            InitializeComponent();


            StyleButton.CrearBotonElegante(button_valor_apertura, IconChar.CashRegister);
            StyleButton.CrearBotonElegante(button_valor_cierre, IconChar.CashRegister);

            StyleButton.CrearBotonElegante(button_maniana, IconChar.Sun);
            StyleButton.CrearBotonElegante(button_tarde, IconChar.MountainSun);
            StyleButton.CrearBotonElegante(button_noche, IconChar.Moon);

            StyleButton.CrearBotonElegante(button_cerrar_arqueo, IconChar.Lock);
            StyleButton.CrearBotonElegante(button_apertura_de_caja, IconChar.LockOpen);

            _AperturaCajaController = new ArqueoCajaController();
            _CajaController = new CajaController();
            _TransaccionesCaja = new TransaccionCajaController();
            _FuncionesGenerales = new FuncionesGenerales();
            _ArqueoBilletesController = new ArqueoBilletesController();
            _FuncionesJson = new FuncionesJson();
            validador = new ValidacionHelper(this);
            ConfigurarValidacion();

            this.Paint += ArqueoCajaForm_Paint;
            this.DoubleBuffered = true;


            if (id_arqueo_caja > 0)
            {
                arqueo_caja_id = id_arqueo_caja;

                var buscarArqueoBilletes = _ArqueoBilletesController.obtener_arqueo_billetes_apertura(arqueo_caja_id);

                if (buscarArqueoBilletes != null)
                {
                    tipo_arqueo = "cierre";
                    cargar_datos_caja_abierta(id_arqueo_caja);

                }
                else
                {
                    tipo_arqueo = "apertura";
                    cargar_datos_caja_abierta(id_arqueo_caja);
                    StylesAlertas.MostrarAlerta(this, "Complete el arqueo de caja para continuar", "¡Error!", TipoAlerta.Error);
                }

            }
           

           
        }



        private void ConfigurarValidacion()
        {
            validador = new ValidacionHelper(this);
            validador.AgregarControlRequerido(textBox_valor_apertura, "El valor de apertura es requerido");
            validador.AgregarControlRequerido(textBox_descripcion, "El campo descripción es requerido");
        }

        private void ArqueoCajaForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }

        

        public void actulizarCamposCierreCaja()
        {

            var datos_transacciones = _TransaccionesCaja.ObtenerResumenPorArqueo(SessionArqueoCaja.id_arqueo_caja);
            var datos_arqueo = _AperturaCajaController.ObtenerPorId(SessionArqueoCaja.id_arqueo_caja);


            textBox_total_transacciones.Text = datos_transacciones.totalTransacciones.ToString();
            textBox_total_transacciones_valor.Text = datos_transacciones.totalACobrar.ToString("0.##", CultureInfo.InvariantCulture);


            decimal total_en_caja = _FuncionesGenerales.ParseDecimalFromTextBox(textBox_total_en_caja.Text);
            decimal total_valor_apertura = datos_arqueo.valor_apertura;
            decimal valor_total_transacciones = _FuncionesGenerales.ParseDecimalFromTextBox(textBox_total_transacciones_valor.Text);

            // Inicializar sobrante/faltante

            decimal total_dia = total_valor_apertura + valor_total_transacciones;
            decimal sobrante = 0;
            decimal faltante = 0;

            // Calcular sobrante/faltante con respecto al total del día
            if (total_en_caja > total_dia)
            {
                sobrante = total_en_caja - total_dia;
                textBox_sobrante.Text = sobrante.ToString("0.##", CultureInfo.InvariantCulture);
                textBox_faltante.Text = "0.00";
            }
            else if (total_en_caja < total_dia)
            {
                faltante = total_dia - total_en_caja;
                textBox_faltante.Text = faltante.ToString("0.##", CultureInfo.InvariantCulture);
                textBox_sobrante.Text = "0.00";
            }
            else
            {
                textBox_sobrante.Text = "0.00";
                textBox_faltante.Text = "0.00";
            }

        }

        public void cargar_datos_caja_abierta(int id_arqueo_caja)
        {
            if (tipo_arqueo == "apertura")
            {
                textBox_total_en_caja.Enabled = false;
                button_cerrar_arqueo.Enabled = false;
                button_apertura_de_caja.Enabled = false;
            }
            else {
                textBox_total_en_caja.Enabled = true;
                button_apertura_de_caja.Enabled = false;
                button_cerrar_arqueo.Enabled = true;
                button_valor_cierre.Enabled = true;
            }
            var cajaAbierta = _AperturaCajaController.ObtenerPorId(id_arqueo_caja);
            var cajaEncontrada = _CajaController.ObtenerPorId(cajaAbierta.caja_id);
           

            if (cajaAbierta != null)
            {
                label_titulo_arqueo.Text = "Cierre de caja - " + cajaEncontrada.nombre;
                textBox_valor_apertura.Enabled = false;
                button_valor_apertura.Enabled = true;
                button_maniana.Enabled = false;
                button_tarde.Enabled = false;
                button_noche.Enabled = false;
                textBox_descripcion.Text = cajaAbierta.observaciones;
                textBox_valor_apertura.Text = cajaAbierta.valor_apertura.ToString();
                textBox_total_transacciones.Text = cajaAbierta.total_transacciones.ToString();
                textBox_faltante.Text = cajaAbierta.faltante.ToString() ?? "0";
                textBox_sobrante.Text = cajaAbierta.sobrante.ToString() ?? "0";

                decimal total_en_caja = decimal.Parse(cajaAbierta.total_en_caja.ToString());
                decimal valor_apertura = decimal.Parse(cajaAbierta.valor_apertura.ToString());
                if (total_en_caja > 0)
                {
                    textBox_total_en_caja.Text = cajaAbierta.total_en_caja.ToString();
                    
                }
                if (valor_apertura > 0) {
                    button_cerrar_arqueo.Enabled = false;
                }
                
            }
            else
            {
                _FuncionesGenerales.LimpiarCampos(this);
            }

        }




        private void iconButton_regresar_Click(object sender, EventArgs e)
        {
            TecladoHelper.CerrarTeclado();
            var MenuPrincipalForm = new MenuPrincipalForm();
            this.Hide();                 // Opcional: ocultas la ventana actual
            MenuPrincipalForm.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
            this.Close();
        }

        private void button_valor_apertura_Click(object sender, EventArgs e)
        {
            SessionArqueoCaja.estadoArqueo = "A";

            SessionArqueoCaja.montoValidar =
                _FuncionesGenerales.ParseDecimalFromTextBoxNormalizado(textBox_valor_apertura.Text);

            using (var denominacionesdinero = new BilletesMonedasForm())
            {
                denominacionesdinero.StartPosition = FormStartPosition.CenterParent;

                // 1) Abres el modal y capturas el resultado
                var result = denominacionesdinero.ShowDialog(this);

                // 2) Recién aquí revisas si devolvió OK
                if (result == DialogResult.OK)
                {

                    button_apertura_de_caja.Enabled = true;
                }
            }
        }


        private void button_valor_cierre_Click(object sender, EventArgs e)
        {
            SessionArqueoCaja.estadoArqueo = "C";
            SessionArqueoCaja.montoValidar =
                _FuncionesGenerales.ParseDecimalFromTextBoxNormalizado(textBox_total_en_caja.Text);

            using (var denominacionesdinero = new BilletesMonedasForm())
            {
                denominacionesdinero.StartPosition = FormStartPosition.CenterParent;
                denominacionesdinero.TopMost = true;

                var result = denominacionesdinero.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    textBox_total_en_caja.Enabled = false;
                    button_cerrar_arqueo.Enabled = true;
                    actulizarCamposCierreCaja();
                }
            }
        }


        private void button_maniana_Click(object sender, EventArgs e)
        {
            button_maniana.Enabled = false;
            button_tarde.Enabled = true;
            button_noche.Enabled = true;
        }

        private void button_tarde_Click(object sender, EventArgs e)
        {
            button_maniana.Enabled = true;
            button_tarde.Enabled = false;
            button_noche.Enabled = true;
        }

        private void button_noche_Click(object sender, EventArgs e)
        {
            button_maniana.Enabled = true;
            button_tarde.Enabled = true;
            button_noche.Enabled = false;
        }

        private void button_parar_apertura_caja_Click(object sender, EventArgs e)
        {

        }

        private void button_apertura_de_caja_Click(object sender, EventArgs e)
        {


            if (!validador.ValidarTodosLosControles())
            {
                validador.MostrarMensajeValidacion();
                return;
            }
            else {
                if (textBox_valor_apertura.Text == "Ingrese el valor..." || textBox_descripcion.Text == "Observaciones sobre la apertura de caja...") {

                    StylesAlertas.MostrarAlerta(this, "Completar los campos", "¡Error!", TipoAlerta.Error);
                    return;
                }
            
            }
            if (buscarTurnoDisponible() == "asignado")
            {
                StylesAlertas.MostrarAlerta(this, "Seleccionar un turno", "¡Error!", TipoAlerta.Error);
                return;
            }

            var cajas = _CajaController.obtener_cajas_cerradas();
            if (cajas == null)
            {
                StylesAlertas.MostrarAlerta(this, "No existen cajas disponibles para la apertura", "¡Error!", TipoAlerta.Error);
                return;
            }
            decimal valor_apertura_normalizado = _FuncionesGenerales.ParseDecimalFromTextBoxNormalizado(textBox_valor_apertura.Text);

            int cajaConfig = _FuncionesJson.CargarCajaDesdeConfig();


            var caja = _CajaController.ObtenerPorId(cajaConfig);

            if (caja == null)
            {
                StylesAlertas.MostrarAlerta(this, "No existe esa caja", "¡Error!", TipoAlerta.Error);
                return;
            }


            var arqueo = new arqueo_cajaM
            {
                caja_id = cajaConfig, // el ID real de la caja
                id_persona_rol = SessionUser.id_persona_rol,            // del login o sesión
                turno = buscarTurnoDisponible(),
                fecha_apertura = DateTime.Now,                           // apertura actual
                hora_cierre = DateTime.Now,
                valor_apertura = valor_apertura_normalizado,
                total_en_caja = 0,
                faltante = 0,
                sobrante = 0,
                observaciones = textBox_descripcion.Text.Trim(),
                estado = "A",
                pinpad_lote = "",        // si luego implementas
                pinpad_referencia = ""   // idem
            };

            if (arqueo != null)
            {
                arqueo_caja_id = _AperturaCajaController.Insertar_ReturnId(arqueo);
                StylesAlertas.MostrarAlerta(this, "Arqueo de Caja Creado Correctamente", tipo: TipoAlerta.Success);
                button_apertura_de_caja.Enabled = false;

                //estado controles
                textBox_total_en_caja.Enabled = true;
                textBox_valor_apertura.Enabled = false;
                button_valor_apertura.Enabled = true;


                SessionArqueoCaja.id_arqueo_caja = arqueo_caja_id;
                SessionArqueoCaja.montoValidar = valor_apertura_normalizado;
                SessionArqueoCaja.estadoArqueo = "A";

                using (var denominacionesdinero = new BilletesMonedasForm())
                {
                    denominacionesdinero.StartPosition = FormStartPosition.CenterParent;

                    // 1) Abres el modal y capturas el resultado
                    var result = denominacionesdinero.ShowDialog(this);

                    if (result == DialogResult.OK)     // 2) Evaluar resultado después de ShowDialog
                    {
                        TecladoHelper.CerrarTeclado();
                        button_apertura_de_caja.Enabled = false;
                        textBox_valor_apertura.Enabled = false;

                    }
                }
            }



            
               


            



        }




        private bool validarCamposCierre()
        {
            bool estado = true;

            if (textBox_total_en_caja.Text.Trim() == "")
            {

                return estado = false;
            }

            return estado;
        }

        private string buscarTurnoDisponible()
        {

            string valor = "";

            if (button_maniana.Enabled == false)
            {
                return valor = "mañana";
            }
            else if (button_tarde.Enabled == false)
            {
                return valor = "tarde";
            }
            else if (button_noche.Enabled == false)
            {
                return valor = "noche";
            }
            return "asignado";
        }
        private void textBox_saldo_inicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Permitir control (borrar, enter, etc.)
            if (char.IsControl(e.KeyChar))
                return;

            // Permitir solo dígitos y un punto
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            // Solo un punto decimal
            if (e.KeyChar == '.' && txt.Text.Contains('.'))
            {
                e.Handled = true;
                return;
            }

            // Validar máximo 2 decimales
            if (char.IsDigit(e.KeyChar) && txt.Text.Contains("."))
            {
                int indexPunto = txt.Text.IndexOf('.');
                string decimales = txt.Text.Substring(indexPunto + 1);

                if (decimales.Length >= 2 && txt.SelectionStart > indexPunto)
                {
                    e.Handled = true;
                    return;
                }
            }

            // ---- Validar que no supere 10,000.00 ----
            string nuevoTexto;

            // Insertar el nuevo carácter en la posición actual del cursor
            if (txt.SelectionLength > 0)
                nuevoTexto = txt.Text.Remove(txt.SelectionStart, txt.SelectionLength)
                                      .Insert(txt.SelectionStart, e.KeyChar.ToString());
            else
                nuevoTexto = txt.Text.Insert(txt.SelectionStart, e.KeyChar.ToString());

            if (decimal.TryParse(nuevoTexto, out decimal valor))
            {
                if (valor > 10000)
                {
                    e.Handled = true; // Bloquear si supera 10,000.00
                    return;
                }
            }
        }


        private void textBox_valor_apertura_Click(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt.Text == "Ingrese el valor..." && txt.ForeColor == Color.FromArgb(180, 180, 180))
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
            TecladoHelper.MostrarTeclado();
        }


        private void textBox_total_en_caja_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();
            TextBox txt = sender as TextBox;
            if (txt.Text == "Ingrese el total..." && txt.ForeColor == Color.FromArgb(180, 180, 180))
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void textBox_descripcion_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();
            TextBox txt = sender as TextBox;

            if (txt != null && txt.Text == "Observaciones sobre la apertura de caja...")
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }


        }





        private void textBox_total_en_caja_Leave(object sender, EventArgs e)
        {
            decimal total_en_caja = _FuncionesGenerales.ParseDecimalFromTextBoxNormalizado(textBox_total_en_caja.Text);

            if (total_en_caja > 0)
            {
                button_valor_cierre.Enabled = true;
            }
            else { 
            
                button_cerrar_arqueo.Enabled = false;
            }
        }

        private void button_cerrar_arqueo_Click(object sender, EventArgs e)
        {
            if (!validarCamposCierre())
            {
                StylesAlertas.MostrarAlerta(this, "Completar todos los campos para la apertura", "¡Error!", TipoAlerta.Error);
                return;
            }
            else {

                if (textBox_total_en_caja.Text == "Ingrese el total...") {
                    StylesAlertas.MostrarAlerta(this, "Ingrese el total en caja", "¡Error!", TipoAlerta.Error);
                    return;
                }
            }

                actulizarCamposCierreCaja();
            decimal total_en_caja = _FuncionesGenerales.ParseDecimalFromTextBoxNormalizado(textBox_total_en_caja.Text);
            decimal faltante = _FuncionesGenerales.ParseDecimalFromTextBoxNormalizado(textBox_faltante.Text);
            decimal sobrante = _FuncionesGenerales.ParseDecimalFromTextBoxNormalizado(textBox_sobrante.Text);

            var tiposPagos = _TransaccionesCaja.ObtenerSumaPorTipoPago(SessionArqueoCaja.id_arqueo_caja);
            decimal efectivo = 0;
            decimal transferencia = 0;
            decimal tarjeta = 0;

            // Opción 1: Usando foreach con KeyValuePair
            foreach (var tipo in tiposPagos)
            {
                switch (tipo.Key) // Key es el tipo_pago_id
                {
                    case 1: // EFECTIVO
                        efectivo = tipo.Value; // Value es el total
                        break;
                    case 2: // TRANSFERENCIA
                        transferencia = tipo.Value;
                        break;
                    case 3: // TARJETA
                        tarjeta = tipo.Value;
                        break;
                }
            }

            var arqueo = new arqueo_cajaM
            {
                arqueo_id = SessionArqueoCaja.id_arqueo_caja,
                id_persona_rol = SessionUser.id_persona_rol,
                hora_cierre = DateTime.Now,
                total_transacciones = decimal.TryParse(textBox_total_transacciones.Text, out var trans) ? trans : 0,
                total_en_caja = total_en_caja,
                faltante = faltante,
                sobrante = sobrante,
                observaciones = textBox_descripcion.Text.Trim(),
                estado = "C",
                total_efectivo = efectivo,
                total_transferencia = transferencia,
                total_tarjeta = tarjeta,
            };

            var ArqueoCajaAbierto = _AperturaCajaController.ObtenerPorId(arqueo_caja_id);

            if (arqueo_caja_id > 0)
            {
                var resultado = StylesAlertas.MostrarConfirmacion(
    this,
    "¿Desea cerrar este arqueo de caja?",
    "Confirmar",
    StylesAlertas.TipoAlerta.Info);

                // Cambiar de DialogResult.OK a DialogResult.Yes
                if (resultado == DialogResult.Yes)
                {
                    int idArqueoCaja = arqueo_caja_id;
                    if (idArqueoCaja > 0)
                    {
                        _AperturaCajaController.Actualizar(arqueo);
                        StylesAlertas.MostrarAlerta(this, "Arqueo de caja cerrado correctamente.", tipo: StylesAlertas.TipoAlerta.Success);
                        button_cerrar_arqueo.Enabled = false;
                        textBox_total_en_caja.Enabled = false;

                    }
                    else
                    {
                        StylesAlertas.MostrarAlerta(this, "ID del arqueo de caja no válido.", "¡Error!", StylesAlertas.TipoAlerta.Error);
                    }
                }
            }
            else
            {
                StylesAlertas.MostrarAlerta(this, "Seleccione una caja que desea eliminar.", "¡Error!", TipoAlerta.Error);
            }
        }
    }
}
