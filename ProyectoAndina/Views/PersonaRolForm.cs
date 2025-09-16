using ProyectoAndina.Controllers;
using ProyectoAndina.Funciones_Generales;
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
    public partial class PersonaRolForm : KioskForm
    {
        private readonly RolController _rolController;
        private readonly PersonaController _personaController;
        private readonly PersonaRolController _personaRolController;
        private readonly ControladorPaginacion _paginacion;
        private System.Windows.Forms.Timer searchTimer;
        private int id_per_rolRol;
        private List<persona_rolM> _todasLasPersonasRol;

        public PersonaRolForm()
        {
            InitializeComponent();
            _rolController = new RolController();
            _personaController = new PersonaController();
            _personaRolController = new PersonaRolController();
            _paginacion = new ControladorPaginacion();
            StyleButton.CrearBotonElegante(button_agregar_rol_persona, FontAwesome.Sharp.IconChar.Plus);
            this.Paint += PersonaRolForm_Paint;

            // Configurar estilos después de InitializeComponent
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
                var resultado = _personaRolController.ObtenerPersonaRolesPaginados(
                    _paginacion.PaginaActual,
                    _paginacion.RegistrosPorPagina,
                    _paginacion.FiltroActual);

                // Actualizar información de paginación
                _paginacion.ActualizarTotales(resultado.TotalRegistros);

                // Limpiar y cargar datos en el DataGridView
                dgvDatos.Rows.Clear();

                foreach (var item in resultado.Datos)
                {
                    dgvDatos.Rows.Add(
                        item.IdPersonaRol,
                        item.Cedula ?? "N/A",
                        item.NombrePersona ?? "N/A",
                        item.NombreRol ?? "N/A",
                        item.DescripcionRol ?? "N/A",
                        item.Estado ? "Activo" : "Inactivo",
                        item.FechaAsignacion?.ToString("dd/MM/yyyy") ?? "N/A",
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

        private void ConfigurarColumnasPersonaRol()
        {
            dgvDatos.Columns.Clear();

            // ID interno (oculto)
            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id_persona_rol",
                HeaderText = "ID",
                Visible = false
            });

            // Cédula de la persona
            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "cedula",
                HeaderText = "Cédula",
                FillWeight = 20
            });

            // Nombre completo de la persona
            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "nombre_persona",
                HeaderText = "Persona",
                FillWeight = 30
            });

            // Nombre del rol
            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "nombre_rol",
                HeaderText = "Rol",
                FillWeight = 25
            });

            // Descripción del rol
            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "descripcion_rol",
                HeaderText = "Descripción",
                FillWeight = 35
            });

            // Estado
            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "estado",
                HeaderText = "Estado",
                FillWeight = 15
            });

            // Fecha asignación
            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "fecha_asignacion",
                HeaderText = "Fecha Asignación",
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




        private void ConfigurarControlesExistentes()
        {
            // Configurar el DataGridView que ya existe en el diseñador
            PaginacionUI.ConfigurarDataGridViewParaPaginacion(dgvDatos);
            ConfigurarColumnasPersonaRol();

            // Configurar el ComboBox existente
            cmbRegistrosPorPagina.Items.Clear();
            cmbRegistrosPorPagina.Items.AddRange(new object[] { "10", "20", "50", "100" });
            cmbRegistrosPorPagina.SelectedIndex = 1; // 20 por defecto
            cmbRegistrosPorPagina.DropDownStyle = ComboBoxStyle.DropDownList;

            // Configurar el TextBox existente
            txtBuscar.PlaceholderText = "Buscar por nombre, cédula, rol y descripción";
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
                int id_per_rol = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["id_persona_rol"].Value);

                // Mostrar menú contextual
                var contextMenu = new ContextMenuStrip();
                contextMenu.Items.Add("Editar", null, (s, args) => AbrirFormularioEdicion(id_per_rol));
                contextMenu.Items.Add("Eliminar", null, (s, args) => ConfirmarEliminar(id_per_rol));

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

        private void AbrirFormularioEdicion(int perRolId)
        {

            var PersonaRolCrudForm = new PersonaRolCrudForm(perRolId, this);
            PersonaRolCrudForm.StartPosition = FormStartPosition.CenterParent;

            DialogResult resultado = PersonaRolCrudForm.ShowDialog(this);

            if (PersonaRolCrudForm.DialogResult == DialogResult.OK)
            {
                CargarDatos();

            }


        }

        // Método para confirmar eliminación
        private void ConfirmarEliminar(int idPerRol)
        {
            try
            {
                var resultado = MessageBox.Show(
                    $"¿Estás seguro de que quieres eliminar el rol de la persona con ID {idPerRol}?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    _personaRolController.EliminarPersonaRol(idPerRol);
                    StylesAlertas.MostrarAlerta(this, "Registro eliminado correctamente", tipo: TipoAlerta.Success);
                    CargarDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar rol: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PersonaRolForm_Paint(object sender, PaintEventArgs e)
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

        private void button_agregar_rol_persona_Click(object sender, EventArgs e)
        {


            var PersonaRolCrudForm = new PersonaRolCrudForm(0, this);
            PersonaRolCrudForm.StartPosition = FormStartPosition.CenterParent;

            DialogResult resultado = PersonaRolCrudForm.ShowDialog(this);

            if (PersonaRolCrudForm.DialogResult == DialogResult.OK)
            {

            }
        }

        private void txtBuscar_Click(object sender, EventArgs e)
        {
            TecladoHelper.MostrarTeclado();
        }
    }
}
