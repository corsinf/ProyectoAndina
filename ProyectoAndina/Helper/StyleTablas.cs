using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoAndina.Funciones_Generales
{
    internal class StyleTablas
    {

        public Action<int> OnIdSeleccionado;

        public Action<int> OnEditarClicked;
        public Action<int> OnEliminarClicked;

        public void AgregarCelda(TableLayoutPanel panel, string texto, int columna, int fila, bool isHeader = false)
        {
            var label = new Label
            {
                Text = texto ?? string.Empty,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill,
                Padding = new Padding(8, 5, 8, 5),
                Margin = new Padding(0),
                FlatStyle = FlatStyle.Flat,
                MinimumSize = new Size(0, 35),
                MaximumSize = new Size(0, 35),
                Height = 35
            };

            if (!isHeader)
            {
                label.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                label.BackColor = (fila % 2 == 0) ? Color.White : Color.FromArgb(248, 249, 250);
                label.ForeColor = Color.FromArgb(33, 37, 41);
                label.Height = 35;

                label.MouseEnter += (s, e) =>
                {
                    if (columna != 4) // No aplicar hover en columna de acciones
                        label.BackColor = Color.FromArgb(220, 230, 240);
                };
                label.MouseLeave += (s, e) =>
                {
                    if (columna != 4) // No aplicar hover en columna de acciones
                        label.BackColor = (fila % 2 == 0) ? Color.White : Color.FromArgb(248, 249, 250);
                };

                label.Tag = new Point(columna, fila);

                if (columna == 1) // Solo columna 1 (Nombre) tiene click
                    label.Click += (sender, e) => Label_Click(sender, e, panel);

                if (columna == 0) // Columna ID oculta
                {
                    label.Text = texto ?? string.Empty;
                    label.Width = 0;
                    label.MaximumSize = new Size(0, 1);
                    label.MinimumSize = new Size(0, 1);
                    label.Size = new Size(0, 1);
                    label.Margin = new Padding(0);
                }
            }
            else
            {
                label.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                label.BackColor = Color.FromArgb(230, 230, 230);
                label.ForeColor = Color.FromArgb(33, 37, 41);
                label.Height = 35;
                label.TextAlign = ContentAlignment.MiddleCenter;
            }

            var toolTip = new ToolTip();
            toolTip.SetToolTip(label, texto);
            panel.Controls.Add(label, columna, fila);
        }

        // Nuevo método para agregar panel de acciones con botones
        public void AgregarPanelAcciones(TableLayoutPanel tablePanel, int id, int columna, int fila)
        {
            var panelAcciones = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(2),
                BackColor = (fila % 2 == 0) ? Color.White : Color.FromArgb(248, 249, 250)
            };

            // Botón Editar
            var btnEditar = new Button
            {
                Size = new Size(30, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(40, 167, 69), // Verde
                ForeColor = Color.White,
                Text = "✏", // Puedes usar un ícono de fuente o imagen
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Tag = id,
                Location = new Point(5, 3)
            };

            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatAppearance.MouseOverBackColor = Color.FromArgb(34, 139, 59);

            btnEditar.Click += (sender, e) =>
            {
                if (sender is Button btn && btn.Tag is int rolId)
                {
                    OnEditarClicked?.Invoke(rolId);
                }
            };

            // Botón Eliminar
            var btnEliminar = new Button
            {
                Size = new Size(30, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(220, 53, 69), // Rojo
                ForeColor = Color.White,
                Text = "🗑", // Puedes usar un ícono de fuente o imagen
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Tag = id,
                Location = new Point(40, 3)
            };

            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatAppearance.MouseOverBackColor = Color.FromArgb(200, 35, 51);

            btnEliminar.Click += (sender, e) =>
            {
                if (sender is Button btn && btn.Tag is int rolId)
                {
                    OnEliminarClicked?.Invoke(rolId);
                }
            };

            // Agregar botones al panel
            panelAcciones.Controls.Add(btnEditar);
            panelAcciones.Controls.Add(btnEliminar);

            // Agregar panel al TableLayoutPanel
            tablePanel.Controls.Add(panelAcciones, columna, fila);
        }

        private void Label_Click(object sender, EventArgs e, TableLayoutPanel panel)
        {
            if (sender is Label clickedLabel && clickedLabel.Tag is Point cellPos)
            {
                int fila = cellPos.Y;
                Control idControl = panel.GetControlFromPosition(0, fila);
                if (idControl is Label idLabel)
                {
                    string idTexto = idLabel.Text;
                    if (int.TryParse(idTexto, out int idPersonaRol))
                    {
                        OnIdSeleccionado?.Invoke(idPersonaRol); // 👈 se ejecuta si está asignado
                    }
                }
            }
        }

    }
}
