using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoAndina.Utils
{
    public static class PaginacionUI
    {
        public static void ConfigurarDataGridViewParaPaginacion(DataGridView dgv)
        {
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;

            // Estilo de encabezados
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 40;

            // Estilo de filas
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 88, 255);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.RowTemplate.Height = 35;
        }

        public static Panel CrearPanelPaginacion(int x, int y, int width)
        {
            var panel = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(width, 50),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };

            return panel;
        }

        public static (Button primera, Button anterior, Button siguiente, Button ultima, Label info)
            CrearControlesPaginacion()
        {
            var btnPrimera = new Button { Text = "Primera", Size = new Size(70, 30), Location = new Point(0, 10) };
            var btnAnterior = new Button { Text = "Anterior", Size = new Size(70, 30), Location = new Point(80, 10) };
            var btnSiguiente = new Button { Text = "Siguiente", Size = new Size(70, 30), Location = new Point(160, 10) };
            var btnUltima = new Button { Text = "Última", Size = new Size(70, 30), Location = new Point(240, 10) };

            var lblInfo = new Label
            {
                Location = new Point(330, 15),
                Size = new Size(400, 20),
                TextAlign = ContentAlignment.MiddleLeft
            };

            return (btnPrimera, btnAnterior, btnSiguiente, btnUltima, lblInfo);
        }

        public static (TextBox buscar, ComboBox registrosPorPagina) CrearControlesBusqueda(int x, int y)
        {
            var txtBuscar = new TextBox
            {
                Location = new Point(x, y),
                Size = new Size(300, 25),
                PlaceholderText = "Buscar..."
            };

            var cmbRegistros = new ComboBox
            {
                Location = new Point(x + 320, y),
                Size = new Size(80, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbRegistros.Items.AddRange(new object[] { "10", "20", "50", "100" });
            cmbRegistros.SelectedIndex = 1; // 20 por defecto

            return (txtBuscar, cmbRegistros);
        }
    }
}