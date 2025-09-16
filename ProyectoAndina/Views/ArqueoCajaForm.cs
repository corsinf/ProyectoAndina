using FontAwesome.Sharp;
using System.Diagnostics;
using System.Linq;
using ProyectoAndina.Controllers;
using ProyectoAndina.Helper;
using ProyectoAndina.Models;
using ProyectoAndina.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProyectoAndina.Utils.StylesAlertas;

namespace ProyectoAndina.Views
{
    public partial class ArqueoCajaForm : KioskForm
    {
        private readonly ArqueoCajaController _AperturaCajaController;
        private readonly ArqueoBilletesController _ArqueoBilletesController;
        private readonly CajaController _CajaController;
        private readonly TransaccionCajaController _TransaccionesCaja;
        private readonly FuncionesGenerales _FuncionesGenerales;
        private ValidacionHelper validador;
        public int arqueo_caja_id;
        public string tipo_arqueo;
        public ArqueoCajaForm(int id_arqueo_caja)
        {
            InitializeComponent();

            StyleButton.CrearBotonElegante(button_valor_apertura, IconChar.CashRegister);
            StyleButton.CrearBotonElegante(button_valor_cierre, IconChar.CashRegister);

            StyleButton.CrearBotonElegante(button_apertura_de_caja, IconChar.PlusCircle);

            StyleButton.CrearBotonElegante(button_maniana, IconChar.Sun);
            StyleButton.CrearBotonElegante(button_tarde, IconChar.MountainSun);
            StyleButton.CrearBotonElegante(button_noche, IconChar.Moon);


            StyleContenedores.EstilizarTableLayout(tableLayoutPanel_faltante, Color.Red);
            StyleContenedores.EstilizarTableLayout(tableLayoutPanel_sobrante, Color.Orange);
            StyleContenedores.EstilizarTableLayout(tableLayoutPanel_transacciones, Color.FromArgb(0, 148, 144));
            StyleContenedores.EstilizarTableLayout(tableLayoutPanel_configuracion_complementaria, Color.FromArgb(0, 148, 144));


            _AperturaCajaController = new ArqueoCajaController();
            _CajaController = new CajaController();
            _TransaccionesCaja = new TransaccionCajaController();
            _FuncionesGenerales = new FuncionesGenerales();
            _ArqueoBilletesController = new ArqueoBilletesController();
            validador = new ValidacionHelper(this);
            ConfigurarValidacion();
            CargarListaCajas();
            



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
                else {
                    tipo_arqueo = "apertura";
                    cargar_datos_caja_abierta(id_arqueo_caja);
                    StylesAlertas.MostrarAlerta(this, "Complete el arqueo de caja para continuar", "¡Error!", TipoAlerta.Error);
                }

            }
            else
            {
                enabled_apertura_caja();
                tipo_arqueo = "apertura";
            }
        }

        private void ConfigurarValidacion()
        {
            validador = new ValidacionHelper(this);
            validador.AgregarControlRequerido(textBox_valor_apertura, "El nombre es requerido");
            validador.AgregarControlRequerido(textBox_descripcion, "El nombre es requerido");
            validador.AgregarControlRequerido(comboBox_cajas, "Debe seleccionar una categoría");
        }

        private void ArqueoCajaForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }

        public void enabled_apertura_caja()
        {

            textBox_total_en_caja.Enabled = false;
            button_valor_cierre.Enabled = false;

            panel_apertura.Dock = DockStyle.Fill;
            panel_cierre.Visible = false;
            panel_valor_apertura.Dock = DockStyle.Fill;
            panel_valor_cierre.Visible = false;

            button_apertura_de_caja.Text = "Crear";

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
        private void CargarListaCajas(int cajaIdSeleccionada = 0)
        {
            var cajas = _CajaController.obtener_cajas_cerradas();

            // Si cajaIdSeleccionada = 0 → mostrar todas
            if (cajaIdSeleccionada == 0)
            {
                comboBox_cajas.DataSource = cajas
                    .Select(c => new KeyValuePair<int, string>(c.caja_id, c.nombre))
                    .ToList();

                comboBox_cajas.DisplayMember = "Value";
                comboBox_cajas.ValueMember = "Key";
                comboBox_cajas.SelectedIndex = -1;
                comboBox_cajas.Enabled = true;
            }
            else
            {
                // Buscar la caja
                var cajaEncontrada = _CajaController.ObtenerPorId(cajaIdSeleccionada);

                if (cajaEncontrada != null)
                {
                    // Solo un item con esa caja
                    comboBox_cajas.DataSource = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(cajaEncontrada.caja_id, cajaEncontrada.nombre)
            };

                    comboBox_cajas.DisplayMember = "Value";
                    comboBox_cajas.ValueMember = "Key";
                    comboBox_cajas.SelectedIndex = 0;
                    comboBox_cajas.Enabled = false; // bloqueado en esa caja
                }
                else
                {
                    // Si no existe, dejarlo vacío
                    comboBox_cajas.DataSource = null;
                }
            }
        }


        public void cargar_datos_caja_abierta(int id_arqueo_caja)
        {

            var cajaAbierta = _AperturaCajaController.ObtenerPorId(id_arqueo_caja);

            if (tipo_arqueo == "cierre") {
                panel_cierre.Dock = DockStyle.Fill;
                panel_apertura.Visible = false;
                panel_valor_cierre.Dock = DockStyle.Fill;
                panel_valor_cierre.Visible = true;
                tableLayoutPanel_transacciones.Visible = true;
                button_apertura_de_caja.Text = "Cerrar";
            }

            if (tipo_arqueo == "apertura") {
                button_apertura_de_caja.Text = "Crear";
                button_apertura_de_caja.Enabled = false;
                panel_apertura.Dock = DockStyle.Fill;
                panel_cierre.Visible = false;
                panel_valor_apertura.Dock = DockStyle.Fill;
                panel_valor_cierre.Visible = false;

            }


            CargarListaCajas(cajaAbierta.caja_id);


            if (cajaAbierta != null)
            {

                textBox_valor_apertura.Enabled = false;
                button_valor_apertura.Enabled = true;
                button_maniana.Enabled = false;
                button_tarde.Enabled = false;
                button_noche.Enabled = false;
                textBox_descripcion.Text = cajaAbierta.observaciones;
                comboBox_cajas.SelectedValue = cajaAbierta.caja_id;
                textBox_valor_apertura.Text = cajaAbierta.valor_apertura.ToString();
                textBox_total_transacciones.Text = cajaAbierta.total_transacciones.ToString();
                textBox_faltante.Text = cajaAbierta.faltante.ToString() ?? "0";
                textBox_sobrante.Text = cajaAbierta.sobrante.ToString() ?? "0";

                decimal total_en_caja = decimal.Parse(cajaAbierta.total_en_caja.ToString());
                if (total_en_caja > 0)
                {
                    textBox_total_en_caja.Text = cajaAbierta.total_en_caja.ToString();
                    textBox_total_en_caja.Enabled = false;
                }
                else
                {
                    textBox_total_en_caja.Enabled = true;
                }
            }
            else
            {
                _FuncionesGenerales.LimpiarCampos(this);
            }

        }




        private void iconButton_regresar_Click(object sender, EventArgs e)
        {
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
                    panel_cierre.Dock = DockStyle.Fill;
                    panel_apertura.Visible = false;
                    panel_valor_cierre.Dock = DockStyle.Fill;
                    panel_valor_cierre.Visible = true;
                    tableLayoutPanel_transacciones.Visible = true;
                    button_apertura_de_caja.Text = "Cerrar";
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


           
            if (tipo_arqueo == "apertura") {

                if (!validador.ValidarTodosLosControles())
                {
                    validador.MostrarMensajeValidacion();
                    return;
                }
                if (buscarTurnoDisponible() == "asignado") { 
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
                decimal total_en_caja = _FuncionesGenerales.ParseDecimalFromTextBoxNormalizado(textBox_total_en_caja.Text);


                var arqueo = new arqueo_cajaM
                {
                    caja_id = Convert.ToInt32(comboBox_cajas.SelectedValue), // el ID real de la caja
                    id_persona_rol = SessionUser.id_persona_rol,            // del login o sesión
                    turno = buscarTurnoDisponible(),
                    fecha_apertura = DateTime.Now,                           // apertura actual
                    hora_cierre = DateTime.Now,
                    valor_apertura = valor_apertura_normalizado,
                    total_en_caja = total_en_caja,
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

                    //estado controles
                    textBox_total_en_caja.Enabled = true;
                    textBox_valor_apertura.Enabled = false;
                    button_valor_apertura.Enabled = true;


                    SessionArqueoCaja.id_arqueo_caja = arqueo_caja_id;
                    SessionArqueoCaja.montoValidar = valor_apertura_normalizado;
                    SessionArqueoCaja.estadoArqueo = "A";

                    using (var frm = new BilletesMonedasForm())
                    {
                        frm.StartPosition = FormStartPosition.CenterParent;

                        var result = frm.ShowDialog(this); // 1) Abrir modal y esperar resultado

                        if (result == DialogResult.OK)     // 2) Evaluar resultado después de ShowDialog
                        {
                            panel_cierre.Dock = DockStyle.Fill;
                            panel_apertura.Visible = false;
                            panel_valor_cierre.Dock = DockStyle.Fill;
                            panel_valor_cierre.Visible = true;
                            tableLayoutPanel_transacciones.Visible = true;
                            button_apertura_de_caja.Text = "Cerrar";
                        }
                    }

                }

            }
            else {
                if (!validarCamposCierre())
                {
                    StylesAlertas.MostrarAlerta(this, "Completar todos los campos para la apertura", "¡Error!", TipoAlerta.Error);
                    return;
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
                            var MenuPrincipalForm = new MenuPrincipalForm();
                            this.Hide();
                            MenuPrincipalForm.ShowDialog();
                            this.Close();
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
            // Permite dígitos, retroceso y punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Solo un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
            {
                e.Handled = true;
            }
        }


        private void textBox_valor_apertura_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();
        }


        private void textBox_total_en_caja_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();
        }

        private void textBox_descripcion_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();
        }

        private void textBox_total_en_caja_Leave(object sender, EventArgs e)
        {
            decimal total_en_caja = _FuncionesGenerales.ParseDecimalFromTextBoxNormalizado(textBox_total_en_caja.Text);

            if (total_en_caja > 0) { 
                button_valor_cierre.Enabled = true;
            }
        }
    }
}
