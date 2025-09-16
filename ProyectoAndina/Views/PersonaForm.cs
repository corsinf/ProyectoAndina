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
    public partial class PersonaForm : KioskForm
    {
        private readonly PersonaController _PersonaController;
        private readonly ControladorPaginacion _paginacion;
        private System.Windows.Forms.Timer searchTimer;

        public int perId;

        public PersonaForm()
        {
            _PersonaController = new PersonaController();
            _paginacion = new ControladorPaginacion();


            InitializeComponent(); // Primero inicializar el diseñador

            // Configurar estilos después de InitializeComponent
            ConfigurarEstilosIniciales();
            ConfigurarControlesExistentes();
            ConfigurarEventos();

            // Cargar datos iniciales
            CargarDatos();
        }

        private void ConfigurarEstilosIniciales()
        {
            // Aplicar estilos a los controles existentes
            StyleButton.CrearBotonElegante(button_agregar_persona, FontAwesome.Sharp.IconChar.Plus);
        }

        private void ConfigurarControlesExistentes()
        {
            // Configurar el DataGridView que ya existe en el diseñador
            PaginacionUI.ConfigurarDataGridViewParaPaginacion(dgvDatos);
            ConfigurarColumnasPersona();

            // Configurar el ComboBox existente
            cmbRegistrosPorPagina.Items.Clear();
            cmbRegistrosPorPagina.Items.AddRange(new object[] { "10", "20", "50", "100" });
            cmbRegistrosPorPagina.SelectedIndex = 1; // 20 por defecto
            cmbRegistrosPorPagina.DropDownStyle = ComboBoxStyle.DropDownList;

            // Configurar el TextBox existente
            txtBuscar.PlaceholderText = "Buscar por nombre, cédula o correo...";
            txtBuscar.Clear();

            // Configurar botones de paginación existentes
            FuncionesPaginado.ConfigurarBotonesPaginacion(label_info, btnPrimera, btnAnterior, btnSiguiente, btnUltima);
        }



        private void ConfigurarColumnasPersona()
        {
            dgvDatos.Columns.Clear();

            // Agregar columnas específicas para PersonaM
            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "per_id",
                HeaderText = "ID",
                Visible = false
            });

            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "primer_nombre",
                HeaderText = "Nombre",
                FillWeight = 25
            });

            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "primer_apellido",
                HeaderText = "Apellido",
                FillWeight = 25
            });

            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "cedula",
                HeaderText = "Cédula",
                FillWeight = 20
            });

            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "correo",
                HeaderText = "Correo",
                FillWeight = 25
            });

            // Columna de acciones
            var colAcciones = new DataGridViewButtonColumn();
            colAcciones.Name = "acciones";
            colAcciones.HeaderText = "Acciones";
            colAcciones.Text = "•••";
            colAcciones.UseColumnTextForButtonValue = true;
            colAcciones.FillWeight = 15;
            dgvDatos.Columns.Add(colAcciones);
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

        private void CargarDatos()
        {
            try
            {
                // Mostrar indicador de carga
                this.Cursor = Cursors.WaitCursor;
                dgvDatos.Enabled = false;
                label_info.Text = "Cargando datos...";

                // Obtener datos paginados del controlador
                var resultado = _PersonaController.ObtenerPersonasPaginadas(
                    _paginacion.PaginaActual,
                    _paginacion.RegistrosPorPagina,
                    _paginacion.FiltroActual);

                // Actualizar información de paginación
                _paginacion.ActualizarTotales(resultado.TotalRegistros);

                // Limpiar y cargar datos en el DataGridView
                dgvDatos.Rows.Clear();

                foreach (var persona in resultado.Datos)
                {
                    dgvDatos.Rows.Add(
                        persona.per_id,
                        persona.primer_nombre ?? "N/A",
                        persona.primer_apellido ?? "N/A",
                        persona.cedula ?? "N/A",
                        persona.correo ?? "N/A",
                        "•••"
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

        // Evento para manejar clics en el DataGridView
        private void DgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvDatos.Columns["acciones"].Index)
            {
                int idPersona = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["per_id"].Value);

                // Mostrar menú contextual
                var contextMenu = new ContextMenuStrip();
                contextMenu.Items.Add("Editar", null, (s, args) => AbrirFormularioEdicion(idPersona));
                contextMenu.Items.Add("Eliminar", null, (s, args) => ConfirmarEliminar(idPersona));

                var mousePos = dgvDatos.PointToClient(Cursor.Position);
                contextMenu.Show(dgvDatos, mousePos);
            }
        }

        // MÉTODOS EXISTENTES - ACTUALIZADOS
        private void AbrirFormularioEdicion(int idPersona)
        {
            var PersonaCrudForm = new PersonaCrudForm(idPersona, this);
            PersonaCrudForm.StartPosition = FormStartPosition.CenterParent;

            DialogResult resultado = PersonaCrudForm.ShowDialog(this);

            if (PersonaCrudForm.DialogResult == DialogResult.OK)
            {
                // Recargar datos después de editar
                CargarDatos();
            }
        }

        private void ConfirmarEliminar(int idPersona)
        {
            try
            {
                var resultado = StylesAlertas.MostrarConfirmacion(
                    this,
                    $"¿Estás seguro de que quieres eliminar la persona con ID {idPersona}?",
                    "Confirmar Eliminación",
                    TipoAlerta.Info);

                if (resultado == DialogResult.Yes)
                {
                    _PersonaController.Eliminar(idPersona);
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

        private void PersonaForm_Paint(object sender, PaintEventArgs e)
        {
            StyleGenerales.PintarFondoDiagonal(this, e);
        }

        private void button_agregar_persona_Click(object sender, EventArgs e)
        {
            var PersonaCrudForm = new PersonaCrudForm(0, this);
            PersonaCrudForm.StartPosition = FormStartPosition.CenterParent;

            DialogResult resultado = PersonaCrudForm.ShowDialog(this);

            if (PersonaCrudForm.DialogResult == DialogResult.OK)
            {
                // Recargar datos después de agregar
                CargarDatos();
            }
        }

        private void iconButton_regresar_Click(object sender, EventArgs e)
        {
            var AdministracionFrom = new AdministracionFrom();
            this.Hide();
            AdministracionFrom.ShowDialog();
            this.Close();
        }

        private void txtBuscar_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();
        }
    }
}
