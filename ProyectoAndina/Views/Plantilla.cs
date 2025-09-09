using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAndina.Views
{
    public partial class Plantilla : Form
    {
        public Plantilla()
        {


        }

        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel_usuario_encontrado = new TableLayoutPanel();
            label_correo = new Label();
            label_cedula = new Label();
            label_telefono = new Label();
            label_nombre = new Label();
            iconPictureBox_buscar_placa = new FontAwesome.Sharp.IconPictureBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel_usuario_encontrado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox_buscar_placa).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 3, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 2, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel_usuario_encontrado, 3, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(1155, 552);
            tableLayoutPanel1.TabIndex = 110;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Dock = DockStyle.Top;
            tableLayoutPanel3.Location = new Point(406, 187);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(340, 145);
            tableLayoutPanel3.TabIndex = 90;
            // 
            // tableLayoutPanel_usuario_encontrado
            // 
            tableLayoutPanel_usuario_encontrado.ColumnCount = 1;
            tableLayoutPanel_usuario_encontrado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_usuario_encontrado.Controls.Add(label_nombre, 0, 0);
            tableLayoutPanel_usuario_encontrado.Controls.Add(label_telefono, 0, 3);
            tableLayoutPanel_usuario_encontrado.Controls.Add(label_cedula, 0, 1);
            tableLayoutPanel_usuario_encontrado.Controls.Add(label_correo, 0, 2);
            tableLayoutPanel_usuario_encontrado.Location = new Point(752, 187);
            tableLayoutPanel_usuario_encontrado.Name = "tableLayoutPanel_usuario_encontrado";
            tableLayoutPanel_usuario_encontrado.RowCount = 4;
            tableLayoutPanel_usuario_encontrado.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_usuario_encontrado.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_usuario_encontrado.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_usuario_encontrado.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_usuario_encontrado.Size = new Size(340, 178);
            tableLayoutPanel_usuario_encontrado.TabIndex = 80;
            tableLayoutPanel_usuario_encontrado.Visible = false;
            // 
            // label_correo
            // 
            label_correo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_correo.AutoSize = true;
            label_correo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_correo.Location = new Point(3, 98);
            label_correo.Name = "label_correo";
            label_correo.Size = new Size(334, 23);
            label_correo.TabIndex = 78;
            label_correo.Text = "correo";
            // 
            // label_cedula
            // 
            label_cedula.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_cedula.AutoSize = true;
            label_cedula.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_cedula.Location = new Point(3, 54);
            label_cedula.Name = "label_cedula";
            label_cedula.Size = new Size(334, 23);
            label_cedula.TabIndex = 77;
            label_cedula.Text = "cedula";
            // 
            // label_telefono
            // 
            label_telefono.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_telefono.AutoSize = true;
            label_telefono.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_telefono.Location = new Point(3, 143);
            label_telefono.Name = "label_telefono";
            label_telefono.Size = new Size(334, 23);
            label_telefono.TabIndex = 79;
            label_telefono.Text = "telefono";
            // 
            // label_nombre
            // 
            label_nombre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label_nombre.AutoSize = true;
            label_nombre.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_nombre.Location = new Point(3, 10);
            label_nombre.Name = "label_nombre";
            label_nombre.Size = new Size(334, 23);
            label_nombre.TabIndex = 76;
            label_nombre.Text = "Nombre";
            // 
            // iconPictureBox_buscar_placa
            // 
            iconPictureBox_buscar_placa.Anchor = AnchorStyles.None;
            iconPictureBox_buscar_placa.BackColor = Color.Transparent;
            iconPictureBox_buscar_placa.ForeColor = SystemColors.ControlText;
            iconPictureBox_buscar_placa.IconChar = FontAwesome.Sharp.IconChar.Search;
            iconPictureBox_buscar_placa.IconColor = SystemColors.ControlText;
            iconPictureBox_buscar_placa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox_buscar_placa.IconSize = 25;
            iconPictureBox_buscar_placa.Location = new Point(156, 21);
            iconPictureBox_buscar_placa.Name = "iconPictureBox_buscar_placa";
            iconPictureBox_buscar_placa.Size = new Size(27, 25);
            iconPictureBox_buscar_placa.TabIndex = 54;
            iconPictureBox_buscar_placa.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(iconPictureBox_buscar_placa, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(752, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(340, 178);
            tableLayoutPanel2.TabIndex = 89;
            // 
            // Plantilla
            // 
            ClientSize = new Size(1155, 552);
            Controls.Add(tableLayoutPanel1);
            Name = "Plantilla";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel_usuario_encontrado.ResumeLayout(false);
            tableLayoutPanel_usuario_encontrado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox_buscar_placa).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);

        }
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel_usuario_encontrado;
        private Label label_nombre;
        private Label label_telefono;
        private Label label_cedula;
        private Label label_correo;
        private TableLayoutPanel tableLayoutPanel2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox_buscar_placa;
    }
}
