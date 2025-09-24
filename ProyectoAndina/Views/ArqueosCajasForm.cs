using ProyectoAndina.Controllers;
using ProyectoAndina.Funciones_Generales;
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
    public partial class ArqueosCajasForm : Form
    {
        private readonly ArqueoCajaController _ArqueoCajaController;
        public int id_arqueo_caja;
        private readonly ControladorPaginacion _paginacion;
        private System.Windows.Forms.Timer searchTimer;
        public ArqueosCajasForm()
        {
            InitializeComponent();
            _ArqueoCajaController = new ArqueoCajaController();
            _paginacion = new ControladorPaginacion();
            ConfigurarControlesExistentes();
            ConfigurarEventos();

            // Cargar datos iniciales
            CargarDatos();
        }
        private void CargarDatos()
        {
            try
            {
                // Mostrar indicador de carga
                this.Cursor = Cursors.WaitCursor;
                dgvDatos.Enabled = false;
                label_info.Text = "Cargando datos...";

                // Obtener datos paginados del controlador
                var resultado = _ArqueoCajaController.ObtenerArqueosConRolesPaginados(
                    _paginacion.PaginaActual,
                    _paginacion.RegistrosPorPagina,
                    _paginacion.FiltroActual);

                // Actualizar información de paginación
                _paginacion.ActualizarTotales(resultado.TotalRegistros);

                // Limpiar y cargar datos en el DataGridView
                dgvDatos.Rows.Clear();

                foreach (var arqueo in resultado.Datos)
                {
                    dgvDatos.Rows.Add(
                        arqueo.arqueo_id,
                        arqueo.monto_inicial.ToString("C2"),   // 💰 formateado en moneda
                        arqueo.monto_final.ToString("C2"),
                        arqueo.estado ?? "N/A",
                        $"{arqueo.primer_nombre} {arqueo.primer_apellido}", // Nombre completo
                        arqueo.cedula ?? "N/A",
                        arqueo.nombre_rol ?? "N/A"
                    );
                }

                // Actualizar controles de paginación
                ActualizarControlesPaginacion();
            }
            catch (Exception ex)
            {
                StylesAlertas.MostrarAlerta(this,
                    $"Error al cargar datos: {ex.Message}",
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
        private void ConfigurarColumnasArqueo()
        {
            dgvDatos.Columns.Clear();

            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "arqueo_id",
                HeaderText = "ID",
                Visible = false
            });

            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "monto_inicial",
                HeaderText = "Monto Inicial",
                FillWeight = 15,
                DefaultCellStyle = { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "monto_final",
                HeaderText = "Monto Final",
                FillWeight = 15,
                DefaultCellStyle = { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "estado",
                HeaderText = "Estado",
                FillWeight = 10
            });

            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "nombre_completo",
                HeaderText = "Responsable",
                FillWeight = 20
            });

            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "cedula",
                HeaderText = "Cédula",
                FillWeight = 15
            });

            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "nombre_rol",
                HeaderText = "Rol",
                FillWeight = 15
            });

            // Columna de acciones (menú de opciones)
           
        }


        private void ConfigurarControlesExistentes()
        {
            // Configurar el DataGridView que ya existe en el diseñador
            PaginacionUI.ConfigurarDataGridViewParaPaginacion(dgvDatos);
            ConfigurarColumnasArqueo();

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
        private void DgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvDatos.Columns["acciones"].Index)
            {
                int idPersona = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["per_id"].Value);

                // Mostrar menú contextual
                var contextMenu = new ContextMenuStrip();


                var mousePos = dgvDatos.PointToClient(Cursor.Position);
                contextMenu.Show(dgvDatos, mousePos);
            }
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

        private void ArqueosCajasForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }

        private void button_regresar_Click(object sender, EventArgs e)
        {
            TecladoHelper.CerrarTeclado();
            var AdministracionFrom = new AdministracionFrom();
            this.Hide();                 // Opcional: ocultas la ventana actual
            AdministracionFrom.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
            this.Close();
        }

        private void txtBuscar_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();
        }
    }
}
