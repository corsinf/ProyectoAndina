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
    public partial class CajaForm : KioskForm
    {

        private readonly CajaController _CajaController;
        private readonly ControladorPaginacion _paginacion;
        private System.Windows.Forms.Timer searchTimer;
        public int caja_id;
        public CajaForm()
        {
            _CajaController = new CajaController();
            _paginacion = new ControladorPaginacion();

            InitializeComponent();
            StyleButton.CrearBotonElegante(button_agregar_caja, FontAwesome.Sharp.IconChar.Plus);

            this.Paint += CajaFormForm_Paint;


            ConfigurarControlesExistentes();
            ConfigurarEventos();

            // Cargar datos iniciales
            CargarDatos();


        }


        private void ConfigurarControlesExistentes()
        {
            // Configurar el DataGridView que ya existe en el diseñador
            PaginacionUI.ConfigurarDataGridViewParaPaginacion(dgvDatos);
            ConfigurarColumnasCaja();

            // Configurar el ComboBox existente
            cmbRegistrosPorPagina.Items.Clear();
            cmbRegistrosPorPagina.Items.AddRange(new object[] { "10", "20", "50", "100" });
            cmbRegistrosPorPagina.SelectedIndex = 1; // 20 por defecto
            cmbRegistrosPorPagina.DropDownStyle = ComboBoxStyle.DropDownList;

            // Configurar el TextBox existente
            txtBuscar.PlaceholderText = "Buscar por nombre, descripcion y lugar";
            txtBuscar.Clear();

            // Configurar botones de paginación existentes
            FuncionesPaginado.ConfigurarBotonesPaginacion(label_info, btnPrimera, btnAnterior, btnSiguiente, btnUltima);
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

            // Evento para el DataGridView
            dgvDatos.CellContentClick += DgvDatos_CellContentClick;
        }
        private void DgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvDatos.Columns["acciones"].Index)
            {
                int id_caja = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["caja_id"].Value);

                // Mostrar menú contextual
                var contextMenu = new ContextMenuStrip();
                contextMenu.Items.Add("Editar", null, (s, args) => AbrirFormularioEdicion(id_caja));
                var mousePos = dgvDatos.PointToClient(Cursor.Position);
                contextMenu.Show(dgvDatos, mousePos);
            }
        }

        // Eventos de paginación
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

        private void CmbRegistrosPorPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRegistrosPorPagina.SelectedItem != null)
            {
                _paginacion.RegistrosPorPagina = int.Parse(cmbRegistrosPorPagina.SelectedItem.ToString());
                _paginacion.IrAPrimera();
                CargarDatos();
            }
        }
        private void ConfirmarEliminar(int id_caja)
        {
            try
            {
                var resultado = StylesAlertas.MostrarConfirmacion(
                    this,
                    $"¿Estás seguro de que quieres eliminar la caja con ID {id_caja}?",
                    "Confirmar Eliminación",
                    TipoAlerta.Info);

                if (resultado == DialogResult.Yes)
                {
                    _CajaController.Eliminar(id_caja);
                    StylesAlertas.MostrarAlerta(this, "Registro eliminado correctamente", tipo: TipoAlerta.Success);

                    // Recargar datos después de eliminar
                    CargarDatos();
                }
            }
            catch (Exception ex)
            {
                StylesAlertas.MostrarAlerta(this, $"Error al eliminar persona: {ex.Message}", "Error", TipoAlerta.Error);
            }
        }

        private void AbrirFormularioEdicion(int idCaja)
        {

            var CajaCrudForm = new CajaCrudForm(idCaja, this);
            CajaCrudForm.StartPosition = FormStartPosition.CenterParent;

            DialogResult resultado = CajaCrudForm.ShowDialog(this);

            if (CajaCrudForm.DialogResult == DialogResult.OK)
            {
                CargarDatos();
            }


        }



        private void CajaFormForm_Paint(object sender, PaintEventArgs e)
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

        private void button_agregar_caja_Click(object sender, EventArgs e)
        {
            var CajaCrudForm = new CajaCrudForm(0, this);
            CajaCrudForm.StartPosition = FormStartPosition.CenterParent;

            DialogResult resultado = CajaCrudForm.ShowDialog(this);

            if (CajaCrudForm.DialogResult == DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void ConfigurarColumnasCaja()
        {
            dgvDatos.Columns.Clear();

            // ID (oculto)
            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "caja_id",
                HeaderText = "ID",
                Visible = false
            });

            // Nombre de la caja
            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "nombre",
                HeaderText = "Codigo",
                FillWeight = 30
            });

            // Descripción
            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "descripcion",
                HeaderText = "Nombre",
                FillWeight = 35
            });

            // Estado
            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Lugar",
                HeaderText = "Lugar",
                FillWeight = 15
            });

            // Fecha creación
            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "fecha_creacion",
                HeaderText = "Fecha Creación",
                FillWeight = 25
            });

            // Fecha modificación
            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "fecha_modificacion",
                HeaderText = "Última Modificación",
                FillWeight = 25
            });

            // Columna de acciones
            var colAcciones = new DataGridViewButtonColumn
            {
                Name = "acciones",
                HeaderText = "Acciones",
                Text = "•••",
                UseColumnTextForButtonValue = true,
                FillWeight = 15
            };
            dgvDatos.Columns.Add(colAcciones);
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
                var resultado = _CajaController.ObtenerCajasPaginadas(
                    _paginacion.PaginaActual,
                    _paginacion.RegistrosPorPagina,
                    _paginacion.FiltroActual);

                // Actualizar información de paginación
                _paginacion.ActualizarTotales(resultado.TotalRegistros);

                // Limpiar y cargar datos en el DataGridView
                dgvDatos.Rows.Clear();

                foreach (var caja in resultado.Datos)
                {
                    dgvDatos.Rows.Add(
                        caja.caja_id,
                        caja.codigo ?? "N/A",
                        caja.nombre ?? "N/A",
                        caja.ubicacion ?? "N/A",
                        caja.ip_equipo ?? "N/A",
                        caja.estado ? "Activa" : "Inactiva",
                        // Si fecha_creacion puede ser null, ajusta con ?.ToString(...)
                        caja.fecha_creacion != DateTime.MinValue ? caja.fecha_creacion.ToString("dd/MM/yyyy") : "N/A",
                        "•••"
                    );
                }

                // Actualizar controles de paginación y etiqueta
                ActualizarControlesPaginacion();
                label_info.Text = $"Total registros: {resultado.TotalRegistros}";
            }
            catch (Exception ex)
            {
                StylesAlertas.MostrarAlerta(this,
                    $"Error al cargar datos de Cajas: {ex.Message}",
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

        private void txtBuscar_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();
        }
    }
}
