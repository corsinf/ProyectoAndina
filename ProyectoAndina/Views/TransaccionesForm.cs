using Newtonsoft.Json;
using ProyectoAndina.Controllers;
using ProyectoAndina.Funciones_Generales;
using ProyectoAndina.Services;
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
    public partial class TransaccionesForm : Form
    {
        private readonly TransaccionCajaController _transaccionCajaController;
        private readonly PersonaController _PersonaController;
        private readonly ApiService _apiService;

        private readonly ControladorPaginacion _paginacion;
        private System.Windows.Forms.Timer searchTimer;
        public TransaccionesForm()
        {

            _transaccionCajaController = new TransaccionCajaController();
            _PersonaController = new PersonaController();
            _apiService = new ApiService();
            InitializeComponent();
            _paginacion = new ControladorPaginacion();
            ConfigurarControlesExistentes();
            ConfigurarEventos();

            // Cargar datos iniciales
            CargarDatos();
            this.Paint += TransaccionesForm_Paint;
        }
        private async void CargarDatos()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dgvDatos.Enabled = false;
                label_info.Text = "Cargando datos...";

                var persona = _PersonaController.ObtenerPorId(SessionUser.PerId);
                if (persona != null)
                {
                    string loginResponse = await _apiService.LoginAsync(persona.correo, persona.password);

                    if (!string.IsNullOrEmpty(loginResponse) &&
                        !loginResponse.StartsWith("Error") &&
                        !loginResponse.StartsWith("Excepción"))
                    {
                        var obj = JsonConvert.DeserializeObject<dynamic>(loginResponse);
                        string token = obj?.token;

                        if (!string.IsNullOrEmpty(token))
                        {
                            var resultado = await _transaccionCajaController.ObtenerTransaccionesPaginadasApiAsync(
                                _paginacion.PaginaActual,
                                _paginacion.RegistrosPorPagina,
                                _paginacion.FiltroActual,
                                token
                            );

                            _paginacion.ActualizarTotales(resultado.TotalRegistros);

                            dgvDatos.Rows.Clear();
                            foreach (var t in resultado.Datos)
                            {
                                dgvDatos.Rows.Add(
                                    t.trans_id,
                                    t.fecha_transaccion.ToString("dd/MM/yyyy HH:mm"),
                                    t.per_id_cliente,
                                    t.valor_a_cobrar.ToString("C2"),
                                    t.valor_entregado.ToString("C2"),
                                    t.valor_cambio.ToString("C2"),
                                    t.tipo_pago_id,
                                    t.descripcion,
                                    t.placa
                                );
                            }

                            ActualizarControlesPaginacion();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                StylesAlertas.MostrarAlerta(this,
                    $"Error al cargar transacciones: {ex.Message}",
                    "Error",
                    TipoAlerta.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                dgvDatos.Enabled = true;
            }
        }

        private void ActualizarControlesPaginacion()
        {
            // Actualizar el label de información
            label_info.Text = _paginacion.ObtenerInfoPaginacion();

            // Habilitar/deshabilitar botones
            btnPrimera.Enabled = _paginacion.PuedeIrAnterior;
            btnAnterior.Enabled = _paginacion.PuedeIrAnterior;
            btnSiguiente.Enabled = _paginacion.PuedeIrSiguiente;
            btnUltima.Enabled = _paginacion.PuedeIrSiguiente;

            // Cambiar el color de los botones según su estado
            foreach (Button btn in new[] { btnPrimera, btnAnterior, btnSiguiente, btnUltima })
            {
                if (btn.Enabled)
                {
                    btn.BackColor = Color.FromArgb(100, 88, 255);
                    btn.ForeColor = Color.White;
                }
                else
                {
                    btn.BackColor = Color.FromArgb(200, 200, 200);
                    btn.ForeColor = Color.Gray;
                }
            }
        }

        private void ConfigurarControlesExistentes()
        {
            // Configurar el DataGridView que ya existe en el diseñador
            PaginacionUI.ConfigurarDataGridViewParaPaginacion(dgvDatos);
            ConfigurarColumnasTransaccion();

            // Configurar el ComboBox existente
            cmbRegistrosPorPagina.Items.Clear();
            cmbRegistrosPorPagina.Items.AddRange(new object[] { "10", "20", "50", "100" });
            cmbRegistrosPorPagina.SelectedIndex = 1; // 20 por defecto
            cmbRegistrosPorPagina.DropDownStyle = ComboBoxStyle.DropDownList;

            // Configurar el TextBox existente
            txtBuscar.PlaceholderText = "Buscar por nombre, cédula o correo...";
            txtBuscar.Clear();

            // Configurar botones de paginación existentes
            ConfigurarBotonesPaginacion();
        }

        private void ConfigurarBotonesPaginacion()
        {
            // Cambiar el texto de los botones
            btnPrimera.Text = "Primera";
            btnAnterior.Text = "Anterior";
            btnSiguiente.Text = "Siguiente";
            btnUltima.Text = "Última";

            // Aplicar estilos a los botones
            foreach (Button btn in new[] { btnPrimera, btnAnterior, btnSiguiente, btnUltima })
            {
                btn.BackColor = Color.FromArgb(100, 88, 255);
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;
            }

            // Configurar el label de información
            label_info.Text = "Cargando...";
            label_info.Font = new Font("Segoe UI", 9);
            label_info.ForeColor = Color.FromArgb(64, 64, 64);
        }
        private void ConfigurarColumnasTransaccion()
        {
            dgvDatos.Columns.Clear();

            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "trans_id",
                HeaderText = "ID",
                Visible = false
            });

            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "fecha_transaccion",
                HeaderText = "Fecha",
                FillWeight = 20,
                DefaultCellStyle = { Format = "dd/MM/yyyy HH:mm" }
            });

            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "per_id_cliente",
                HeaderText = "Cliente",
                FillWeight = 20
            });

            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "valor_a_cobrar",
                HeaderText = "Valor",
                FillWeight = 15,
                DefaultCellStyle = { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "tipo_pago_id",
                HeaderText = "Tipo Pago",
                FillWeight = 15
            });

            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "acciones",
                HeaderText = "",
                FillWeight = 5
            });
        }
        private void CmbRegistrosPorPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRegistrosPorPagina.SelectedItem != null)
            {
                _paginacion.RegistrosPorPagina = int.Parse(cmbRegistrosPorPagina.SelectedItem.ToString());
                _paginacion.IrAPrimera();
                CargarDatos();
            }
        }
        private void ConfigurarEventos()
        {
            // Timer para búsqueda con retraso
            searchTimer = new System.Windows.Forms.Timer { Interval = 500 };
            searchTimer.Tick += SearchTimer_Tick;

            // Eventos de controles existentes
            txtBuscar.TextChanged += TxtBuscar_TextChanged;
            cmbRegistrosPorPagina.SelectedIndexChanged += CmbRegistrosPorPagina_SelectedIndexChanged;

            // Eventos de paginación (usar los controles del diseñador)
            btnPrimera.Click += BtnPrimera_Click;
            btnAnterior.Click += BtnAnterior_Click;
            btnSiguiente.Click += BtnSiguiente_Click;
            btnUltima.Click += BtnUltima_Click;


        }


        private void button_regresar_Click(object sender, EventArgs e)
        {
            var AdministracionFrom = new AdministracionFrom();
            this.Hide();                 // Opcional: ocultas la ventana actual
            AdministracionFrom.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
            this.Close();
        }

        private void TransaccionesForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }

        private void BtnPrimera_Click(object sender, EventArgs e)
        {
            _paginacion.IrAPrimera();
            CargarDatos();
        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            _paginacion.IrAAnterior();
            CargarDatos();
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            _paginacion.IrASiguiente();
            CargarDatos();
        }

        private void BtnUltima_Click(object sender, EventArgs e)
        {
            _paginacion.IrAUltima();
            CargarDatos();
        }

        // Eventos de búsqueda
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            _paginacion.FiltroActual = txtBuscar.Text.Trim();
            _paginacion.IrAPrimera();
            CargarDatos();
        }

        private void txtBuscar_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();
        }
    }
}
