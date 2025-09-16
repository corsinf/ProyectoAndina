using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoAndina.Utils
{
    public static class FuncionesPaginado
    {
        /// <summary>
        /// Configura un DataGridView para paginación (estilos generales).
        /// </summary>
        public static void ConfigurarDataGridView(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;

            // Estilo
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;
        }

        /// <summary>
        /// Configura un ComboBox para seleccionar cantidad de registros por página.
        /// </summary>
        public static void ConfigurarComboRegistros(ComboBox combo, int porDefecto = 20)
        {
            if (combo == null) return;

            combo.Items.Clear();
            combo.Items.AddRange(new object[] { "10", "20", "50", "100" });
            combo.DropDownStyle = ComboBoxStyle.DropDownList;

            int index = combo.Items.IndexOf(porDefecto.ToString());
            combo.SelectedIndex = index >= 0 ? index : 1; // si no encuentra, usa 20
        }

        /// <summary>
        /// Configura un TextBox de búsqueda con placeholder.
        /// </summary>
        public static void ConfigurarTextBoxBusqueda(TextBox txt, string placeholder = "Buscar...")
        {
            if (txt == null) return;

            txt.PlaceholderText = placeholder;
            txt.Clear();
        }

        /// <summary>
        /// Configura botones de paginación y aplica estilos.
        /// </summary>
        public static void ConfigurarBotonesPaginacion(Label lblInfo, params Button[] botones)
        {
            foreach (var btn in botones)
            {
                if (btn == null) continue;

                btn.BackColor = Color.FromArgb(100, 88, 255);
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;
            }

            if (lblInfo != null)
            {
                lblInfo.Text = "Cargando...";
                lblInfo.ForeColor = Color.FromArgb(64, 64, 64);
            }
        }
    }
}
