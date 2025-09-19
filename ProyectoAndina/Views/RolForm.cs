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
    public partial class RolForm : KioskForm
    {
        private readonly RolController _RolController;
        private readonly ControladorPaginacion _paginacion;
        private System.Windows.Forms.Timer searchTimer;

        private int idRol;
        public RolForm()
        {
            InitializeComponent();

            StyleButton.CrearBotonElegante(button_agregar_rol, FontAwesome.Sharp.IconChar.Plus);
            _RolController = new RolController();
            _paginacion = new ControladorPaginacion();

            this.Paint += RolForm_Paint;
            ConfigurarControlesExistentes();
            ConfigurarEventos();

            // Cargar datos iniciales
            CargarDatos();



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

        private void ConfigurarControlesExistentes()
        {
            // Configurar el DataGridView que ya existe en el diseñador
            PaginacionUI.ConfigurarDataGridViewParaPaginacion(dgvDatos);
            ConfigurarColumnasRol();

            // Configurar el ComboBox existente
            cmbRegistrosPorPagina.Items.Clear();
            cmbRegistrosPorPagina.Items.AddRange(new object[] { "10", "20", "50", "100" });
            cmbRegistrosPorPagina.SelectedIndex = 1; // 20 por defecto
            cmbRegistrosPorPagina.DropDownStyle = ComboBoxStyle.DropDownList;

            // Configurar el TextBox existente
            txtBuscar.PlaceholderText = "Buscar por nombre";
            txtBuscar.Clear();

            // Configurar botones de paginación existentes
            FuncionesPaginado.ConfigurarBotonesPaginacion(label_info, btnPrimera, btnAnterior, btnSiguiente, btnUltima);
        }

        private void AbrirFormularioEdicion(int idRol)
        {

            var RolCrudForm = new RolCrudForm(idRol, this);
            RolCrudForm.StartPosition = FormStartPosition.CenterParent;

            DialogResult resultado = RolCrudForm.ShowDialog(this);

            if (RolCrudForm.DialogResult == DialogResult.OK)
            {
                CargarDatos();
            }


        }


        private void RolForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }


        private void button_regresar_Click(object sender, EventArgs e)
        {
            var AdministracionFrom = new AdministracionFrom();
            this.Hide();                 // Opcional: ocultas la ventana actual
            AdministracionFrom.ShowDialog();  // Bloquea hasta que RegistroForm se cierre
            this.Close();
        }

        private void button_agregar_rol_Click(object sender, EventArgs e)
        {
            var RolCrudForm = new RolCrudForm(0, this);
            RolCrudForm.StartPosition = FormStartPosition.CenterParent;

            DialogResult resultado = RolCrudForm.ShowDialog(this);

            if (RolCrudForm.DialogResult == DialogResult.OK)
            {

                CargarDatos();
            }
        }

        private void ConfigurarColumnasRol()
        {
            dgvDatos.Columns.Clear();

            // ID oculto
            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "rol_id",
                HeaderText = "ID",
                Visible = false
            });

            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "nombre",
                HeaderText = "Nombre",
                FillWeight = 30
            });

            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "descripcion",
                HeaderText = "Descripción",
                FillWeight = 40
            });

            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "estado",
                HeaderText = "Estado",
                FillWeight = 15
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
                label_info.Text = "Cargando roles...";

                // Obtener datos paginados desde el controlador
                var resultado = _RolController.ObtenerRolesPaginados(
                    _paginacion.PaginaActual,
                    _paginacion.RegistrosPorPagina,
                    _paginacion.FiltroActual);

                // Actualizar información de paginación
                _paginacion.ActualizarTotales(resultado.TotalRegistros);

                // Limpiar y cargar filas
                dgvDatos.Rows.Clear();

                foreach (var rol in resultado.Datos)
                {
                    dgvDatos.Rows.Add(
                        rol.RolId,
                        rol.Nombre ?? "N/A",
                        rol.Descripcion ?? "N/A",
                        rol.Estado ? "Activo" : "Inactivo",
                        "•••"
                    );
                }

                // Actualizar controles de paginación
                ActualizarControlesPaginacion();
            }
            catch (Exception ex)
            {
                StylesAlertas.MostrarAlerta(this,
                    $"Error al cargar roles: {ex.Message}",
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

        // Evento para manejar clics en el DataGridView
        private void DgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvDatos.Columns["acciones"].Index)
            {
                int id_rol = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["rol_id"].Value);

                // Mostrar menú contextual
                var contextMenu = new ContextMenuStrip();
                contextMenu.Items.Add("Editar", null, (s, args) => AbrirFormularioEdicion(id_rol));
                contextMenu.Items.Add("Eliminar", null, (s, args) => ConfirmarEliminar(id_rol));

                var mousePos = dgvDatos.PointToClient(Cursor.Position);
                contextMenu.Show(dgvDatos, mousePos);
            }
        }

        private void ConfirmarEliminar(int id_rol)
        {
            try
            {
                var resultado = StylesAlertas.MostrarConfirmacion(
                    this,
                    $"¿Estás seguro de que quieres eliminar el rol?",
                    "Confirmar Eliminación",
                    TipoAlerta.Info);

                if (resultado == DialogResult.Yes)
                {
                    _RolController.EliminarRol(id_rol);
                    StylesAlertas.MostrarAlerta(this, "Registro eliminado correctamente", tipo: TipoAlerta.Success);
                    CargarDatos();
                }
            }
            catch (Exception ex)
            {
                StylesAlertas.MostrarAlerta(this, $"Error al eliminar persona: {ex.Message}", "Error", TipoAlerta.Error);
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

        private void CmbRegistrosPorPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRegistrosPorPagina.SelectedItem != null)
            {
                _paginacion.RegistrosPorPagina = int.Parse(cmbRegistrosPorPagina.SelectedItem.ToString());
                _paginacion.IrAPrimera();
                CargarDatos();
            }
        }

        private void txtBuscar_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();
        }
    }
}
