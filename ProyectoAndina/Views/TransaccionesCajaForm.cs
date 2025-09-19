using FontAwesome.Sharp;
using Newtonsoft.Json;
using ProyectoAndina.Controllers;
using ProyectoAndina.Helper;
using ProyectoAndina.Models;
using ProyectoAndina.Services;
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

    public partial class TransaccionesCajaForm : Form
    {
        private readonly PersonaController _PersonaController;
        private readonly CajaController _CajaController;
        private readonly ArqueoCajaController _ArqueoCajaController;
        private readonly TransaccionCajaController _TransaccionCajaController;
        private readonly ApiService _apiService;
        private readonly FuncionesGenerales _funcionesGenerales = new FuncionesGenerales();
        public int tipo_factura = 0;
        private ReciboModel recibo;
        private int id_usuario;

        public TransaccionesCajaForm()
        {
            InitializeComponent();


            StyleButton.CrearBotonElegante(button_realizar_transaccion, FontAwesome.Sharp.IconChar.CashRegister);
            // Métodos de pago
            StyleButton.CrearBotonElegante(button_efectivo, FontAwesome.Sharp.IconChar.MoneyBillWave);
            StyleButton.CrearBotonElegante(button_tarjeta, FontAwesome.Sharp.IconChar.CreditCard);
            StyleButton.CrearBotonElegante(button_transferencia, FontAwesome.Sharp.IconChar.University); // o IconChar.MoneyCheckDollar

            // Tipo de cliente
            StyleButton.CrearBotonElegante(button_consumidor_final, FontAwesome.Sharp.IconChar.User);
            StyleButton.CrearBotonElegante(button_con_datos, FontAwesome.Sharp.IconChar.UserTie);

            StyleButton.CrearBotonElegante(button_agregar_user, FontAwesome.Sharp.IconChar.PlusCircle);
            StyleButton.CrearBotonElegante(button_actualizar_usuario, FontAwesome.Sharp.IconChar.Rotate);


            StyleButton.AplicarEstiloBotonBusqueda(iconPictureBox_search, textBox_buscar_placa);
            StyleButton.AplicarEstiloBotonBusqueda(iconPictureBox_buscar_usuario, textBox_usuario_encontrar);

            StyleContenedores.EstilizarTableLayout(tableLayoutPanel_datos_placa, Color.FromArgb(0, 148, 144));



            _PersonaController = new PersonaController();
            _CajaController = new CajaController();
            _ArqueoCajaController = new();
            _apiService = new ApiService();
            _TransaccionCajaController = new TransaccionCajaController();
            this.Paint += TransaccionesCajaForm_Paint;
        }


        private async void button_realizar_transaccion_Click(object sender, EventArgs e)
        {
            if (sacarTipoPago() == 0)
            {
                StylesAlertas.MostrarAlerta(this, "Seleccionar tipo de pago", "¡Error!", TipoAlerta.Error);
                return;

            }

            string valorEntregadoEncerado = textBox_val_entregado.Text.Trim();
            string valorCambioEncerado = label_valor_a_cobrar.Text.Trim();

            if (valorEntregadoEncerado == "" || valorCambioEncerado == "")
            {
                StylesAlertas.MostrarAlerta(this, "Agregar un valor entregado por el usuario", "¡Error!", TipoAlerta.Error);
                return;
            }
            string texto = label_valor_de_cambio.Text.Replace("💰", "").Trim();
            decimal valorEntregado = _funcionesGenerales.ParseDecimalFromTextBoxNormalizado(textBox_val_entregado.Text);
            decimal valorCambio = _funcionesGenerales.ParseDecimalFromTextBoxNormalizado(texto);

            if (tipo_factura == 1)
            {
                if (valorEntregado > 49)
                {
                    StylesAlertas.MostrarAlerta(this, "El consumidor final no puede realizar pagos mayor a 50 dolares", "¡Error!", TipoAlerta.Error);
                }
            }
            else if (tipo_factura == 2)
            {
                if (id_usuario == 0 || label_nombre.Text.Trim() == "")
                {
                    StylesAlertas.MostrarAlerta(this, "Seleccionar un usuario", "¡Error!", TipoAlerta.Error);
                    return;
                }

            }
            else if (tipo_factura == 0)
            {
                StylesAlertas.MostrarAlerta(this, "Seleccione un tipo de factura", "¡Error!", TipoAlerta.Error);
                return;
            }


            // Validar que los valores sean mayores o iguales a cero (opcional)
            if (valorEntregado >= 0 && valorCambio >= 0)
            {
                string descripcion = "Generado desde la aplicacion de escritorio";
                int id_arqueo_caja = SessionArqueoCaja.id_arqueo_caja;

                string valor_cobrar = label_valor_a_cobrar.Text.Replace("💰", "").Trim();
                decimal valor_a_cobrar = _funcionesGenerales.ParseDecimalFromTextBoxNormalizado(valor_cobrar);


                string tiempo_estacionamiento = label_valor_hora_ingreso.Text.Replace("⏰", "").Trim();
                string fecha_ingreso = label_valor_tiempo.Text.Replace("⌛", "").Trim();


                string placa = textBox_buscar_placa.Text.Trim();

                var transaccionCaja = new TransaccionCajaM
                {
                    arqueo_id = id_arqueo_caja,
                    per_id_cliente = id_usuario,
                    fecha_transaccion = DateTime.Now,
                    valor_a_cobrar = valor_a_cobrar,
                    valor_entregado = valorEntregado,
                    tipo_pago_id = sacarTipoPago(),
                    descripcion = descripcion,
                    placa = placa
                };

                var persona = _PersonaController.ObtenerPorId(SessionUser.PerId);
                var arqueoCaja = _ArqueoCajaController.ObtenerPorId(id_arqueo_caja);
                var cajaTransaccion = _CajaController.ObtenerPorId(arqueoCaja.caja_id);


                if (persona != null)
                {
                    // Esperar el resultado del login
                    string loginResponse = await _apiService.LoginAsync(persona.correo, persona.password);

                    if (!string.IsNullOrEmpty(loginResponse) && !loginResponse.StartsWith("Error") && !loginResponse.StartsWith("Excepción"))
                    {
                        // Aquí normalmente viene un JSON con el token
                        // Ejemplo: { "token": "eyJhbGciOi..." }
                        var obj = JsonConvert.DeserializeObject<dynamic>(loginResponse);
                        string token = obj?.token;


                        if (!string.IsNullOrEmpty(token))
                        {
                            string PagoResponse = await _apiService.PagarPlacaAsync(placa, valorEntregado, token);

                            var objPago = JsonConvert.DeserializeObject<dynamic>(PagoResponse);

                            if (objPago.code != null)
                            {
                                string codigo = objPago.code;
                                string mensaje = objPago.msg;

                                // Si el código no es "0" (éxito), hay un error
                                if (codigo != "0")
                                {
                                    StylesAlertas.MostrarAlerta(this, "No existe ningun vehiculo con esos datos", "¡Error!", TipoAlerta.Error);

                                    _funcionesGenerales.LimpiarCampos(this);

                                    return; // Salir del método
                                }
                            }
                            //inserta en la bdd
                            //_TransaccionCajaController.Insertar(transaccionCaja);
                            //insertar en el olimpo

                            string Transaccion = await _apiService.CrearTransaccionCajaAsync(transaccionCaja, token);



                            if (Transaccion.StartsWith("Error") || Transaccion.StartsWith("Excepción"))
                            {
                                //MessageBox.Show("❌ No se pudo registrar la transacción: " + Transaccion,
                                //               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                StylesAlertas.MostrarAlerta(this, "No se pudo completar la transacción", "¡Error!", TipoAlerta.Error);
                            }
                            else
                            {
                                // Si tu API devuelve la transacción creada en JSON
                                var objTransaccion = JsonConvert.DeserializeObject<TransaccionCajaM>(Transaccion);
                                // MessageBox.Show("✅ Transacción registrada con ID: " + objTransaccion.arqueo_id,
                                //                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                StylesAlertas.MostrarAlerta(this, "Transacción realizada correctamente", tipo: TipoAlerta.Success);

                                decimal porcentaje = 0.15m; // 15%
                                decimal montoDescuento = transaccionCaja.valor_a_cobrar * porcentaje; // 15% del valor a cobrar
                                decimal subTotal = transaccionCaja.valor_a_cobrar - montoDescuento;
                                decimal total = valor_a_cobrar; // si no hay impuestos adicionales

                                if (tipo_factura == 1)
                                {

                                    recibo = new ReciboModel
                                    {
                                        Fecha = DateTime.Now,
                                        Hora = DateTime.Now,
                                        IVA15 = montoDescuento,
                                        Subtotal = subTotal,
                                        Total = total,
                                        SistemaPago = "consumidor",
                                        FechaSalida = DateTime.Now,
                                        FechaEntrada = DateTime.Parse(tiempo_estacionamiento),
                                        TiempoConsumido = fecha_ingreso,
                                        Caja = cajaTransaccion.nombre,
                                        Cajero = persona.nombre_completo,
                                    };
                                }
                                else if (tipo_factura == 2)
                                {
                                    recibo.IVA15 = montoDescuento;
                                    recibo.Subtotal = subTotal;
                                    recibo.Total = total;
                                    recibo.SistemaPago = "ruc";
                                    recibo.FechaSalida = DateTime.Now;
                                    recibo.FechaEntrada = DateTime.Parse(tiempo_estacionamiento);
                                    recibo.TiempoConsumido = fecha_ingreso;
                                    recibo.Caja = cajaTransaccion.nombre;
                                    recibo.Cajero = persona.nombre_completo;
                                }



                                // 'this' aquí es tu form padre (por ejemplo, tu KioskForm)
                                using (var frm = new ImpresionComprobanteForm(recibo))
                                {
                                    // Redundante si ya lo seteaste en el ctor; no hace daño:
                                    frm.StartPosition = FormStartPosition.CenterParent;
                                    frm.TopMost = true;

                                    var resultado = frm.ShowDialog(this);  // ¡IMPORTANTE: owner!

                                    if (resultado == DialogResult.OK)
                                    {
                                        StylesAlertas.MostrarAlerta(this, "Impresión finalizada con éxito.", tipo: TipoAlerta.Success);
                                    }
                                }


                            }

                            _funcionesGenerales.LimpiarCampos(this);

                            label_valor_hora_ingreso.Text = "";
                            label_valor_tiempo.Text = "";
                            label_valor_a_cobrar.Text = "";
                            label_valor_de_cambio.Text = "";

                            label_nombre.Text = "";
                            label_correo.Text = "";
                            label_cedula.Text = "";
                            label_telefono.Text = "";

                        }
                        else
                        {
                            StylesAlertas.MostrarAlerta(this, "No se pudo obtener el token del login.", "Aviso", TipoAlerta.Info);
                        }

                    }
                }

            }
            else
            {
                StylesAlertas.MostrarAlerta(this, "Por favor ingrese un número válido.", "Aviso", TipoAlerta.Info);
            }
        }

        private void button_cancelar_transaccion_Click(object sender, EventArgs e)
        {
            _funcionesGenerales.LimpiarCampos(this);
        }

        private void button_agregar_user_Click(object sender, EventArgs e)
        {
            String cedula = textBox_usuario_encontrar.Text;
            var CrearUsuario = new CrearUsuario(this, cedula, 1);
            CrearUsuario.StartPosition = FormStartPosition.CenterParent;
            var result = CrearUsuario.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                var personaUltima = _PersonaController.ObtenerUltima();
                if (personaUltima != null)
                {
                    label_nombre.Text = personaUltima.primer_nombre + " " + personaUltima.primer_apellido;
                    label_nombre.Text = "👤 Nombre: " + personaUltima.primer_nombre + " " + personaUltima.primer_apellido;
                    label_correo.Text = "📧 Correo: " + personaUltima.correo;
                    label_cedula.Text = "🆔 Cédula: " + personaUltima.cedula;
                    label_telefono.Text = "📞 Teléfono: " + personaUltima.telefono_1;
                    id_usuario = personaUltima.per_id;
                    textBox_usuario_encontrar.Text = personaUltima.cedula;

                    recibo = new ReciboModel
                    {
                        Fecha = DateTime.Now,
                        Hora = DateTime.Now,
                        Cliente = personaUltima.nombre_completo,
                        CI_RUC = personaUltima.cedula,
                        TelefonoCliente = personaUltima.telefono_1,
                        Email = personaUltima.correo,
                        DireccionCliente = personaUltima.direccion,
                    };

                    button_con_datos.Enabled = false;
                    button_consumidor_final.Enabled = true;
                    tipo_factura = 2;
                }

                else
                {
                    StylesAlertas.MostrarAlerta(this, "No se pudo sacar los datos", "¡Error!", TipoAlerta.Error);
                }

            }
        }

        private async void button_buscar_placa_Click(object sender, EventArgs e)
        {
            try
            {
                string placa = textBox_buscar_placa.Text.Trim();

                if (placa == "")
                {
                    StylesAlertas.MostrarAlerta(this, "No hay ningun campo en la placa", "¡Error!", TipoAlerta.Error);
                    return;
                }
                var persona = _PersonaController.ObtenerPorId(SessionUser.PerId);

                if (persona != null)
                {
                    // Esperar el resultado del login
                    string loginResponse = await _apiService.LoginAsync(persona.correo, persona.password);

                    if (!string.IsNullOrEmpty(loginResponse) && !loginResponse.StartsWith("Error") && !loginResponse.StartsWith("Excepción"))
                    {
                        // Aquí normalmente viene un JSON con el token
                        // Ejemplo: { "token": "eyJhbGciOi..." }
                        var obj = JsonConvert.DeserializeObject<dynamic>(loginResponse);
                        string token = obj?.token;


                        if (!string.IsNullOrEmpty(token))
                        {
                            // ✅ Ya tienes el token. Ahora puedes usarlo para otra operación
                            string respuesta = await _apiService.VerificarPlacaAsync(placa, token);

                            var objRespuesta = JsonConvert.DeserializeObject<dynamic>(respuesta);


                            if (objRespuesta.code != null)
                            {
                                string codigo = objRespuesta.code;
                                string mensaje = objRespuesta.msg;

                                // Si el código no es "0" (éxito), hay un error
                                if (codigo == "0")
                                {
                                    StylesAlertas.MostrarAlerta(this, "No hay respuesta del servidor", "¡Error!", TipoAlerta.Error);


                                    _funcionesGenerales.LimpiarCampos(this);

                                    return; // Salir del método
                                }
                                if (codigo == "128")
                                {
                                    StylesAlertas.MostrarAlerta(this, "No existe el vehiculo", "¡Error!", TipoAlerta.Error);


                                    _funcionesGenerales.LimpiarCampos(this);

                                    return; // Salir del método
                                }
                            }

                            if (objRespuesta?.traducido != null)
                            {
                                // Acceder correctamente a las propiedades (sin .Artemis)
                                string placaActual = objRespuesta.traducido.Placa;
                                string HoraIngreso = objRespuesta.traducido.HoraIngreso;
                                string TiempoEstacionamiento = objRespuesta.traducido.TiempoEstacionado;
                                string TipoRegla = objRespuesta.traducido.TipoRegla;
                                string NombreRegla = objRespuesta.traducido.NombreRegla;
                                string MontoPagar = objRespuesta.traducido.MontoAPagar;

                                if (MontoPagar == "0.00")
                                {
                                    label_valor_hora_ingreso.Text = "⏰" + HoraIngreso;
                                    label_valor_tiempo.Text = "⌛" + TiempoEstacionamiento;
                                    label_valor_a_cobrar.Text = "💰 " + MontoPagar;
                                    button_realizar_transaccion.Enabled = false;
                                    textBox_val_entregado.Enabled = false;

                                }
                                else
                                {
                                    label_valor_hora_ingreso.Text = "⏰" + HoraIngreso;
                                    label_valor_tiempo.Text = "⌛" + TiempoEstacionamiento;
                                    label_valor_a_cobrar.Text = "💰 " + MontoPagar;
                                    button_realizar_transaccion.Enabled = true;
                                    textBox_val_entregado.Enabled = true;


                                }

                                // Asignar a los TextBox


                            }
                            else
                            {
                                StylesAlertas.MostrarAlerta(this, "La respuesta no contiene la estructura esperada", "¡Error!", TipoAlerta.Error);
                            }



                            //string montoPagar = objRespuesta.Artemis.traducido.Placa;

                        }
                        else
                        {
                            StylesAlertas.MostrarAlerta(this, "No se pudo obtener el token del login.", "¡Error!", TipoAlerta.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error en login: " + loginResponse);
                    }
                }
                else
                {
                    StylesAlertas.MostrarAlerta(this, "No hay un usuario logueado.", "¡Error!", TipoAlerta.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en apertura de caja: " + ex.Message);
            }
        }

        private async void button_buscar_usuario_Click(object sender, EventArgs e)
        {
            string cedula = textBox_usuario_encontrar.Text.Trim();



            if (cedula == "")
            {
                StylesAlertas.MostrarAlerta(this, "Ingrese el CI/RUC del usuario", "¡Error!", TipoAlerta.Error);
                label_nombre.Text = "👤 Nombre: ";
                label_correo.Text = "📧 Correo: ";
                label_cedula.Text = "🆔 Cédula: ";
                label_telefono.Text = "📞 Teléfono: ";
                id_usuario = 1;
                return;
            }
            else
            {


                var persona = _PersonaController.ObtenerPorId(SessionUser.PerId);

                if (persona != null)
                {
                    // Esperar el resultado del login
                    string loginResponse = await _apiService.LoginAsync(persona.correo, persona.password);

                    if (!string.IsNullOrEmpty(loginResponse) && !loginResponse.StartsWith("Error") && !loginResponse.StartsWith("Excepción"))
                    {
                        // Aquí normalmente viene un JSON con el token
                        // Ejemplo: { "token": "eyJhbGciOi..." }
                        var obj = JsonConvert.DeserializeObject<dynamic>(loginResponse);
                        string token = obj?.token;


                        if (!string.IsNullOrEmpty(token))
                        {
                            // ✅ Ya tienes el token. Ahora puedes usarlo para otra operación
                            string respuesta = await _apiService.GetPersonaPorCedulaAsync(cedula, token);

                            // Validar si la API devolvió vacío o lista vacía
                            if (string.IsNullOrWhiteSpace(respuesta) || respuesta == "[]" || respuesta == "null")
                            {
                                StylesAlertas.MostrarAlerta(
                                    this,
                                    "No se encontró el usuario",
                                    "¡Error!",
                                    TipoAlerta.Error,
                                    4000
                                );
                                button_agregar_user.Visible = true;
                                button_agregar_user.Enabled = true;

                                return;
                            }

                            if (respuesta.Contains("\"status\":404") || respuesta.Contains("\"title\":\"Not Found\""))
                            {
                                StylesAlertas.MostrarAlerta(this, "No se encontro el usuario", "¡Error!", TipoAlerta.Error);
                                return;
                            }
                            var objRespuesta = JsonConvert.DeserializeObject<dynamic>(respuesta);

                            if (objRespuesta != null)
                            {
                                button_agregar_user.Visible = false;
                                label_nombre.Text = "👤 Nombre: " + objRespuesta.nombre_completo;
                                label_correo.Text = "📧 Correo: " + objRespuesta.correo;
                                label_cedula.Text = "🆔 Cédula: " + objRespuesta.cedula;
                                label_telefono.Text = "📞 Teléfono: " + objRespuesta.telefono_1;
                                id_usuario = objRespuesta.per_id;

                                recibo = new ReciboModel
                                {
                                    Fecha = DateTime.Now,
                                    Hora = DateTime.Now,
                                    Cliente = objRespuesta.nombre_completo,
                                    CI_RUC = objRespuesta.cedula,
                                    TelefonoCliente = objRespuesta.telefono_1,
                                    Email = objRespuesta.correo,
                                    DireccionCliente = objRespuesta.direccion,
                                };

                                button_con_datos.Enabled = false;
                                button_consumidor_final.Enabled = true;
                                tipo_factura = 2;
                            }

                        }
                    }

                }

            }
        }
        private void TransaccionesCajaForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }



        private void textBox_val_entregado_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox_val_entregado.Text))
            {
                label_valor_de_cambio.Text = "0.00";
                return;
            }

            // Configurar cultura para usar punto como separador decimal
            CultureInfo cultura = CultureInfo.InvariantCulture;

            // Procesar valor entregado
            string textoEntregado = textBox_val_entregado.Text.Trim();
            decimal valorEntregado;

            // Intentar parsear el valor entregado
            if (!decimal.TryParse(textoEntregado, NumberStyles.Number, cultura, out valorEntregado))
            {
                MessageBox.Show("Por favor ingrese un número válido en valor entregado.",
                               "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                label_valor_de_cambio.Text = "0.00";
                button_realizar_transaccion.Enabled = false;

                return;
            }

            // Procesar valor a cobrar
            string texto = label_valor_a_cobrar.Text.Replace("💰", "").Trim();
            string textoCobrar = texto;

            // Quitar símbolos de moneda y espacios
            textoCobrar = textoCobrar.Replace("$", "")
                                    .Replace("USD", "")
                                    .Replace("€", "")
                                    .Replace("£", "")
                                    .Trim();

            decimal valorCobrar;

            // Intentar parsear el valor a cobrar
            if (!decimal.TryParse(textoCobrar, NumberStyles.Number, cultura, out valorCobrar))
            {

                StylesAlertas.MostrarAlerta(this, "El valor a cobrar no es válido.", "Aviso", TipoAlerta.Info);
                label_valor_de_cambio.Text = "0.00";
                button_realizar_transaccion.Enabled = false;

                return;
            }

            // Calcular el cambio
            decimal valorCambio = valorEntregado - valorCobrar;

            // Validar que el valor entregado sea suficiente
            if (valorCambio < 0)
            {

                StylesAlertas.MostrarAlerta(this, $"El valor entregado (${valorEntregado:0.00}) no puede ser menor al valor a cobrar (${valorCobrar:0.00}).", "Aviso", TipoAlerta.Info);
                label_valor_de_cambio.Text = "0.00";
                button_realizar_transaccion.Enabled = false;
                return;
            }
            // Mostrar el resultado con formato de moneda
            label_valor_de_cambio.Text = "💰" + valorCambio.ToString("0.00", cultura);
            button_realizar_transaccion.Enabled = true;
        }

        private int sacarTipoPago()
        {

            int valor = 0;

            if (button_tarjeta.Enabled == false)
            {
                return valor = 3;
            }
            else if (button_transferencia.Enabled == false)
            {
                return valor = 2;
            }
            else if (button_efectivo.Enabled == false)
            {
                return valor = 1;
            }

            return valor;
        }

        private void button_efectivo_Click(object sender, EventArgs e)
        {
            button_efectivo.Enabled = false;
            button_tarjeta.Enabled = true;
            button_transferencia.Enabled = true;
        }

        private void button_transferencia_Click(object sender, EventArgs e)
        {
            button_efectivo.Enabled = true;
            button_tarjeta.Enabled = true;
            button_transferencia.Enabled = false;
        }

        private void button_tarjeta_Click(object sender, EventArgs e)
        {
            button_efectivo.Enabled = true;
            button_tarjeta.Enabled = false;
            button_transferencia.Enabled = true;

        }

        private void button_consumidor_final_Click(object sender, EventArgs e)
        {
            button_consumidor_final.Enabled = false;
            button_con_datos.Enabled = true;
            tableLayoutPanel_usuario_encontrado.Visible = false;
            tableLayoutPanel_datos_usuario.Visible = false;
            button_agregar_user.Visible = false;
            id_usuario = 1;
            tipo_factura = 1;
        }

        private void button_con_datos_Click(object sender, EventArgs e)
        {
            button_consumidor_final.Enabled = true;
            button_con_datos.Enabled = false;
            tableLayoutPanel_usuario_encontrado.Visible = true;
            tableLayoutPanel_datos_usuario.Visible = true;
            tableLayoutPanel_usuario_encontrado.Dock = DockStyle.Fill;
            tipo_factura = 2;
        }

        private void iconButton_regresar_Click(object sender, EventArgs e)
        {
            TecladoHelper.CerrarTeclado();

            var MenuPrincipalForm = new MenuPrincipalForm();
            this.Hide();                 // Opcional: ocultas la ventana actual
            MenuPrincipalForm.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
            this.Close();
        }

        private void textBox_buscar_placa_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();
        }

        private void textBox_usuario_encontrar_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox_val_entregado_KeyPress(object sender, KeyPressEventArgs e)
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

                // Si ya tiene 2 decimales, bloquear más
                if (decimales.Length >= 2 && txt.SelectionStart > indexPunto)
                {
                    e.Handled = true;
                }
            }
        }

        private void label_titulo_usuario_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_actualizar_usuario_Click(object sender, EventArgs e)
        {
            String cedula = textBox_usuario_encontrar.Text;
            var CrearUsuario = new CrearUsuario(this, cedula, 2);
            CrearUsuario.StartPosition = FormStartPosition.CenterParent;
            var result = CrearUsuario.ShowDialog(this);

            if (result == DialogResult.OK)
            {

            }


        }
    }
}
