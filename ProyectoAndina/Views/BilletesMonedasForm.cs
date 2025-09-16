using ProyectoAndina.Controllers;
using ProyectoAndina.Helper;
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
    public partial class BilletesMonedasForm : KioskForm

    {
        private readonly ArqueoBilletesController _ArqueoBilletesController;
        private readonly ArqueoCajaController _ArqueoCajaController;
        private readonly FuncionesGenerales _FuncionesGenerales;
        public int id_arqueo_caja;
        public int total_contado;
        public BilletesMonedasForm()
        {
            _ArqueoBilletesController = new ArqueoBilletesController();
            _ArqueoCajaController = new ArqueoCajaController();
            _FuncionesGenerales = new FuncionesGenerales();
            InitializeComponent();

            StyleSystem.PanelBoton(panel_cien_dolar);
            StyleSystem.PanelBoton(panel_cincuenta_dolar);
            StyleSystem.PanelBoton(panel_viente_dolar);
            StyleSystem.PanelBoton(panel_diez_dolar);
            StyleSystem.PanelBoton(panel_cinco_dolar);
            StyleSystem.PanelBoton(panel_dos_dolar);
            StyleSystem.PanelBoton(panel_uno_dolar);
            StyleSystem.PanelBoton(panel_uno_moneda);
            StyleSystem.PanelBoton(panel_cincuenta_ctvs);
            StyleSystem.PanelBoton(panel_veinticinco_ctvs);
            StyleSystem.PanelBoton(panel_diez_ctvs);
            StyleSystem.PanelBoton(panel_cinco_ctvs);
            StyleSystem.PanelBoton(panel_uno_ctvs);

            StyleSystem.BotonRedondeado(button_agregar_arqueo_billetes, Color.FromArgb(52, 152, 219));




            this.Paint += BilletesMonedasForm_Paint;
            this.Load += BilletesMonedasForm_Load;

            realizar_total_monto();

            int arqueo_caja_id = SessionArqueoCaja.id_arqueo_caja;

            if (arqueo_caja_id > 0)
            {
                if (SessionArqueoCaja.estadoArqueo == "A")
                {
                    mostrar_arqueo_billetes(arqueo_caja_id, SessionArqueoCaja.estadoArqueo);
                    id_arqueo_caja = arqueo_caja_id;
                    verificar_monto_arqueo_caja();
                }
                if (SessionArqueoCaja.estadoArqueo == "C")
                {
                    mostrar_arqueo_billetes(arqueo_caja_id, SessionArqueoCaja.estadoArqueo);
                    verificar_monto_arqueo_caja();
                }
            }
        }
        private void BilletesMonedasForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }

        private void iconButton_regresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_valor_cien_Click(object sender, EventArgs e)
        {
            int valor_cien = ToInt(textBox_100_dollar.Text);

            int aumentar = valor_cien + 1;

            textBox_100_dollar.Text = aumentar.ToString();
        }

        private void button_valor_cincuenta_Click(object sender, EventArgs e)
        {
            int valor_cincuenta = ToInt(textBox_50_dollar.Text);

            int aumentar = valor_cincuenta + 1;

            textBox_50_dollar.Text = aumentar.ToString();
        }

        private void button_valor_veinte_Click(object sender, EventArgs e)
        {
            int veinte = ToInt(textBox_20_dollar.Text);

            int aumentar = veinte + 1;

            textBox_20_dollar.Text = aumentar.ToString();
        }

        private void button_valor_diez_Click(object sender, EventArgs e)
        {
            int diez = ToInt(textBox_10_dollar.Text);

            int aumentar = diez + 1;

            textBox_10_dollar.Text = aumentar.ToString();
        }

        private void button_valor_cinco_Click(object sender, EventArgs e)
        {
            int cinco = ToInt(textBox_5_dollar.Text);

            int aumentar = cinco + 1;

            textBox_5_dollar.Text = aumentar.ToString();
        }

        private void button_valor_dos_Click(object sender, EventArgs e)
        {
            int dos = ToInt(textBox_2_dollar.Text);

            int aumentar = dos + 1;

            textBox_2_dollar.Text = aumentar.ToString();
        }

        private void button_valor_uno_Click(object sender, EventArgs e)
        {
            int uno = ToInt(textBox_1_dollar.Text);

            int aumentar = uno + 1;

            textBox_1_dollar.Text = aumentar.ToString();
        }

        private void button_valor_uno_dolar_moneda_Click(object sender, EventArgs e)
        {
            int uno = ToInt(textBox_1_dollar_moneda.Text);

            int aumentar = uno + 1;

            textBox_1_dollar_moneda.Text = aumentar.ToString();
        }

        private void button_valor_cincuenta_ctvs_Click(object sender, EventArgs e)
        {
            int ciencuenta = ToInt(textBox_50_ctvs.Text);

            int aumentar = ciencuenta + 1;

            textBox_50_ctvs.Text = aumentar.ToString();
        }

        private void button_valor_veinticinco_ctvs_Click(object sender, EventArgs e)
        {
            int veinticinco = ToInt(textBox_25_ctvs.Text);

            int aumentar = veinticinco + 1;

            textBox_25_ctvs.Text = aumentar.ToString();
        }

        private void button_valor_diez_ctvs_Click(object sender, EventArgs e)
        {
            int diez = ToInt(textBox_10_ctvs.Text);

            int aumentar = diez + 1;

            textBox_10_ctvs.Text = aumentar.ToString();
        }

        private void button_valor_cinco_ctvs_Click(object sender, EventArgs e)
        {
            int cinco = ToInt(textBox_5_ctvs.Text);

            int aumentar = cinco + 1;

            textBox_5_ctvs.Text = aumentar.ToString();
        }

        private void button_valor_uno_ctvs_Click(object sender, EventArgs e)
        {
            int uno = ToInt(textBox_1_ctvs.Text);

            int aumentar = uno + 1;

            textBox_1_ctvs.Text = aumentar.ToString();
        }

        private void button_agregar_arqueo_billetes_Click(object sender, EventArgs e)
        {
            var arqueo = new arqueo_billetesM
            {
                arqueo_id = SessionArqueoCaja.id_arqueo_caja,
                estado = SessionArqueoCaja.estadoArqueo,
                billetes_100 = ToInt(textBox_100_dollar.Text),
                billetes_50 = ToInt(textBox_50_dollar.Text),
                billetes_20 = ToInt(textBox_20_dollar.Text),
                billetes_10 = ToInt(textBox_10_dollar.Text),
                billetes_5 = ToInt(textBox_5_dollar.Text),
                billetes_1 = ToInt(textBox_1_dollar.Text),
                monedas_1 = ToInt(textBox_1_dollar_moneda.Text),
                centavos_50 = ToInt(textBox_50_ctvs.Text),
                centavos_25 = ToInt(textBox_25_ctvs.Text),
                centavos_10 = ToInt(textBox_10_ctvs.Text),
                centavos_5 = ToInt(textBox_5_ctvs.Text),
                centavos_1 = ToInt(textBox_1_ctvs.Text)
            };

            // Limpiar el símbolo de $ y espacios


            // Convertir usando CultureInfo que tenga coma como decimal
            // Obtener valores normalizados
            decimal valorArqueo = _FuncionesGenerales.ParseDecimalFromTextBoxNormalizado(label_total_monto_arqueo_valor.Text);
            decimal valorTotal = _FuncionesGenerales.ParseDecimalFromTextBoxNormalizado(label_total_monto_valor.Text);

            // Comparar con tolerancia
            if (Math.Abs(valorArqueo - valorTotal) < 0.01m) // m para literal decimal
            {
                // Insertar arqueo
                _ArqueoBilletesController.Insertar(arqueo);

                // Mensaje según estado del arqueo
                if (SessionArqueoCaja.estadoArqueo == "A")
                {
                    StylesAlertas.MostrarAlerta(this, "Los valores son iguales ✅\nSe creó correctamente la apertura", tipo: TipoAlerta.Success);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else if (SessionArqueoCaja.estadoArqueo == "C")
                {
                    _ArqueoCajaController.ActualizarTotalEnCaja(SessionArqueoCaja.id_arqueo_caja, SessionArqueoCaja.montoValidar);
                    StylesAlertas.MostrarAlerta(this, "Los valores son iguales ✅\nSe creó correctamente la apertura", tipo: TipoAlerta.Success);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

               
               
            }
            else
            {
                StylesAlertas.MostrarAlerta(this, "Los valores NO coinciden ❌", "¡Error!", TipoAlerta.Error);
            }

        }

        private void mostrar_arqueo_billetes(int arqueo_caja_id, string estado)
        {

            var arqueo_caja = _ArqueoCajaController.ObtenerPorId(arqueo_caja_id);

            if (arqueo_caja != null)
            {
                var buscarArqueoBilletes = _ArqueoBilletesController.ObtenerPorIdEstado(arqueo_caja.arqueo_id, estado);

                if (buscarArqueoBilletes != null)
                {

                    button_agregar_arqueo_billetes.Enabled = false;
                    // label_notificacion_cambio.Text = "Si necesita realizar un cambio, por favor contacte al administrador.";
                    textBox_100_dollar.Text = buscarArqueoBilletes.billetes_100.ToString();
                    textBox_50_dollar.Text = buscarArqueoBilletes.billetes_50.ToString();
                    textBox_20_dollar.Text = buscarArqueoBilletes.billetes_20.ToString();
                    textBox_10_dollar.Text = buscarArqueoBilletes.billetes_10.ToString();
                    textBox_5_dollar.Text = buscarArqueoBilletes.billetes_5.ToString();
                    textBox_1_dollar.Text = buscarArqueoBilletes.billetes_1.ToString();
                    textBox_1_dollar_moneda.Text = buscarArqueoBilletes.monedas_1.ToString();
                    textBox_50_ctvs.Text = buscarArqueoBilletes.centavos_50.ToString();
                    textBox_25_ctvs.Text = buscarArqueoBilletes.centavos_25.ToString();
                    textBox_10_ctvs.Text = buscarArqueoBilletes.centavos_10.ToString();
                    textBox_5_ctvs.Text = buscarArqueoBilletes.centavos_5.ToString();
                    textBox_1_ctvs.Text = buscarArqueoBilletes.centavos_1.ToString();
                    label_total_monto_valor.Text = buscarArqueoBilletes.total_contado.ToString();

                    //label_mensaje.Text = "Si desea realizar algun cambio contactese con el admin";
                    colocar_enabled();
                }
                else
                {

                    _FuncionesGenerales.LimpiarCampos(this);
                    //label_mensaje.Text = "";
                }

            }
            else
            {



            }
        }

        public void colocar_enabled()
        {
            textBox_100_dollar.Enabled = false;
            textBox_50_dollar.Enabled = false;
            textBox_20_dollar.Enabled = false;
            textBox_10_dollar.Enabled = false;
            textBox_5_dollar.Enabled = false;
            textBox_2_dollar.Enabled = false;
            textBox_1_dollar.Enabled = false;
            textBox_1_dollar_moneda.Enabled = false;
            textBox_50_ctvs.Enabled = false;
            textBox_25_ctvs.Enabled = false;
            textBox_10_ctvs.Enabled = false;
            textBox_5_ctvs.Enabled = false;
            textBox_1_ctvs.Enabled = false;

            button_valor_cien.Enabled = false;
            button_valor_cincuenta.Enabled = false;
            button_valor_veinte.Enabled = false;
            button_valor_diez.Enabled = false;
            button_valor_cinco.Enabled = false;
            button_valor_uno.Enabled = false;
            button_valor_dos.Enabled = false;
            button_valor_uno_dolar_moneda.Enabled = false;
            button_valor_uno_ctvs.Enabled = false;
            button_valor_cincuenta_ctvs.Enabled = false;
            button_valor_veinticinco_ctvs.Enabled = false;
            button_valor_diez_ctvs.Enabled = false;
            button_valor_cinco_ctvs.Enabled = false;

            button_agregar_arqueo_billetes.Enabled = false;

        }


        private void verificar_monto_arqueo_caja()
        {

            label_total_monto_arqueo_valor.Text = SessionArqueoCaja.montoValidar.ToString();

        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y teclas de control (ej: backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BilletesMonedasForm_Load(object sender, EventArgs e)
        {
            foreach (var tb in new[] { textBox_100_dollar, textBox_50_dollar, textBox_20_dollar,
                               textBox_10_dollar, textBox_5_dollar, textBox_2_dollar, textBox_1_dollar,
                               textBox_1_dollar_moneda, textBox_50_ctvs, textBox_25_ctvs,
                               textBox_10_ctvs, textBox_5_ctvs, textBox_1_ctvs })
            {
                tb.KeyPress += SoloNumeros_KeyPress;
                tb.TextChanged += (s, ev) => realizar_total_monto();
            }
        }

        private int ToInt(string text)
        {
            return int.TryParse(text, out int value) ? value : 0;
        }

        private void realizar_total_monto()
        {
            decimal total = 0;

            // Billetes
            total += ToInt(textBox_100_dollar.Text) * 100m;
            total += ToInt(textBox_50_dollar.Text) * 50m;
            total += ToInt(textBox_20_dollar.Text) * 20m;
            total += ToInt(textBox_10_dollar.Text) * 10m;
            total += ToInt(textBox_5_dollar.Text) * 5m;
            total += ToInt(textBox_2_dollar.Text) * 2m;
            total += ToInt(textBox_1_dollar.Text) * 1m;

            // Monedas
            total += ToInt(textBox_1_dollar_moneda.Text) * 1m;
            total += ToInt(textBox_50_ctvs.Text) * 0.50m;
            total += ToInt(textBox_25_ctvs.Text) * 0.25m;
            total += ToInt(textBox_10_ctvs.Text) * 0.10m;
            total += ToInt(textBox_5_ctvs.Text) * 0.05m;
            total += ToInt(textBox_1_ctvs.Text) * 0.01m;

            // Mostrar el total (ejemplo en un Label)
            label_total_monto_valor.Text = $"{total:C2}"; // ejemplo → $123.45
        }
    }


}
