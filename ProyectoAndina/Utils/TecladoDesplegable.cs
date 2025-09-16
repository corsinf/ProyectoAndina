using System;
using System.Drawing;
using System.Windows.Forms;

public enum TipoTeclado
{
    Numerico,
    Alfabetico,
    Mixto,
    CaracteresEspeciales
}

public static class TecladoDesplegable
{
    private static TecladoForm tecladoForm;

    public static void MostrarTeclado(Form form, TextBox target, TipoTeclado tipoInicial = TipoTeclado.Numerico, Button botonEnter = null, bool soloNumerico = false)
    {
        if (tecladoForm != null && !tecladoForm.IsDisposed)
            tecladoForm.Close();

        tecladoForm = new TecladoForm(form, target, tipoInicial, botonEnter, soloNumerico);
        tecladoForm.Show();
    }

    public static void CerrarTeclado()
    {
        if (tecladoForm != null && !tecladoForm.IsDisposed)
        {
            tecladoForm.Close();
            tecladoForm = null; // limpiar referencia
        }
    }

    private class TecladoForm : Form
    {
        private Form _parentForm;
        private TextBox _target;
        private TipoTeclado _tipoActual;
        private FlowLayoutPanel _panelBotonesTeclado;
        private TableLayoutPanel _panelTeclas;
        private Label _visor;
        private bool _mayusculas = false;
        private Button _botonEnterExterno;
        private bool _soloNumerico;

        public TecladoForm(Form parentForm, TextBox target, TipoTeclado tipo, Button botonEnter, bool soloNumerico = false)
        {
            _parentForm = parentForm;
            _target = target;
            _tipoActual = tipo;
            _botonEnterExterno = botonEnter;
            _soloNumerico = soloNumerico;

            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            TopMost = true;
            BackColor = Color.FromArgb(45, 45, 48);

            // Ubicar teclado en la parte inferior y ancho completo
            int alto = parentForm.Height / 3;
            this.Width = parentForm.Width;
            this.Height = alto;
            this.Location = new Point(parentForm.Location.X, parentForm.Location.Y + parentForm.Height - alto);

            CrearPaneles();

            if (!_soloNumerico)
                CrearBotonesTipoTeclado();

            ConstruirTeclado();

            parentForm.Resize += (s, e) => AjustarTamaño();
        }

        private void AjustarTamaño()
        {
            this.Width = _parentForm.Width;
            this.Height = _parentForm.Height / 3;
            this.Location = new Point(_parentForm.Location.X, _parentForm.Location.Y + _parentForm.Height - this.Height);
            ConstruirTeclado();
        }

        private void CrearPaneles()
        {
            // Panel superior: visor y botones de tipo de teclado
            Panel panelSuperior = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.FromArgb(37, 37, 38)
            };

            _panelBotonesTeclado = new FlowLayoutPanel
            {
                Dock = DockStyle.Left,
                Width = 500,
                FlowDirection = FlowDirection.LeftToRight,
                BackColor = Color.FromArgb(37, 37, 38),
                Padding = new Padding(10),
            };

            _visor = new Label
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(37, 37, 38),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10),
                Text = _target.Text
            };

            Button btnCerrar = new Button
            {
                Text = "✕",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                BackColor = Color.FromArgb(232, 17, 35),
                ForeColor = Color.White,
                Width = 50,
                Dock = DockStyle.Right,
                FlatStyle = FlatStyle.Flat
            };
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.Click += (s, e) => Close();

            panelSuperior.Controls.Add(_visor);
            panelSuperior.Controls.Add(_panelBotonesTeclado);
            panelSuperior.Controls.Add(btnCerrar);

            _panelTeclas = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(45, 45, 48)
            };

            Controls.Add(_panelTeclas);
            Controls.Add(panelSuperior);
        }

        private void CrearBotonesTipoTeclado()
        {
            _panelBotonesTeclado.Controls.Clear();
            _panelBotonesTeclado.Controls.Add(CrearBotonTipo("🔢", TipoTeclado.Numerico));
            _panelBotonesTeclado.Controls.Add(CrearBotonTipo("🔤", TipoTeclado.Alfabetico));
            _panelBotonesTeclado.Controls.Add(CrearBotonTipo("🔠", TipoTeclado.Mixto));
            _panelBotonesTeclado.Controls.Add(CrearBotonTipo("@#$", TipoTeclado.CaracteresEspeciales));
        }

        private Button CrearBotonTipo(string texto, TipoTeclado tipo)
        {
            bool esActivo = _tipoActual == tipo;
            var btn = new Button
            {
                Text = texto,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                Width = 110,
                Height = 70,
                BackColor = esActivo ? Color.FromArgb(0, 120, 215) : Color.FromArgb(60, 60, 62),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Tag = tipo,
                Margin = new Padding(5)
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = esActivo ? Color.FromArgb(40, 160, 255) : Color.FromArgb(80, 80, 82);

            btn.Click += (s, e) =>
            {
                _tipoActual = tipo;
                ConstruirTeclado();
                CrearBotonesTipoTeclado();
            };

            return btn;
        }

        private void ConstruirTeclado()
        {
            _panelTeclas.Controls.Clear();

            string[] teclas = _tipoActual switch
            {
                TipoTeclado.Numerico => new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0",".", "←", "ENTER" },
                TipoTeclado.Alfabetico => new[] { "Q","W","E","R","T","Y","U","I","O","P",
                                                 "A","S","D","F","G","H","J","K","L","Ñ",
                                                 "⇧","Z","X","C","V","B","N","M","←","ENTER",
                                                 "SPACE" },
                TipoTeclado.Mixto => new[] { "1","2","3","4","5","6","7","8","9","0",
                                             "Q","W","E","R","T","Y","U","I","O","P",
                                             "A","S","D","F","G","H","J","K","L","Ñ",
                                             "⇧","Z","X","C","V","B","N","M","←","ENTER",
                                             "SPACE" },
                TipoTeclado.CaracteresEspeciales => new[] { "!","@","#","$","%","^","&","*",
                                                            "(",")","-","_","=","+","[","]",
                                                            "{","}","\\","|",";",":","'","\"",
                                                            ",",".","/","?","<",">","~","`",
                                                            "SPACE","←","ENTER" },
                _ => new string[0]
            };

            int columnas = Math.Min(10, teclas.Length);
            int filas = (int)Math.Ceiling(teclas.Length / (double)columnas);

            _panelTeclas.RowCount = filas;
            _panelTeclas.ColumnCount = columnas;
            _panelTeclas.RowStyles.Clear();
            _panelTeclas.ColumnStyles.Clear();
            for (int i = 0; i < filas; i++) _panelTeclas.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / filas));
            for (int j = 0; j < columnas; j++) _panelTeclas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / columnas));

            int index = 0;
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    if (index >= teclas.Length) break;
                    _panelTeclas.Controls.Add(CrearBotonTecla(teclas[index++]), j, i);
                }
            }
        }

        private Button CrearBotonTecla(string texto)
        {
            Color colorFondo = Color.FromArgb(60, 60, 62);
            Color colorTexto = Color.White;

            switch (texto)
            {
                case "ENTER": colorFondo = Color.FromArgb(76, 175, 80); break;
                case "←": colorFondo = Color.FromArgb(255, 152, 0); break;
                case "⇧": colorFondo = _mayusculas ? Color.FromArgb(33, 150, 243) : Color.FromArgb(96, 125, 139); break;
                case "SPACE": colorFondo = Color.FromArgb(96, 125, 139); break;
            }

            var btn = new Button
            {
                Text = texto == "SPACE" ? "Espacio" : texto,
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                Dock = DockStyle.Fill,
                BackColor = colorFondo,
                ForeColor = colorTexto,
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(5)
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(
                Math.Min(255, colorFondo.R + 20),
                Math.Min(255, colorFondo.G + 20),
                Math.Min(255, colorFondo.B + 20)
            );

            btn.Click += (s, e) =>
            {
                switch (texto)
                {
                    case "←":
                        if (_target.Text.Length > 0)
                        {
                            int pos = _target.SelectionStart;
                            if (pos > 0)
                            {
                                _target.Text = _target.Text.Remove(pos - 1, 1);
                                _target.SelectionStart = pos - 1;
                            }
                        }
                        break;
                    case "ENTER":
                        if (_botonEnterExterno != null) _botonEnterExterno.PerformClick();
                        else _target.AppendText(Environment.NewLine);
                        break;
                    case "⇧":
                        _mayusculas = !_mayusculas;
                        ConstruirTeclado();
                        break;
                    case "SPACE":
                        _target.AppendText(" ");
                        break;
                    default:
                        string caracter = texto;
                        if ((_tipoActual == TipoTeclado.Alfabetico || _tipoActual == TipoTeclado.Mixto) && char.IsLetter(caracter[0]))
                            caracter = _mayusculas ? caracter.ToUpper() : caracter.ToLower();
                        _target.AppendText(caracter);
                        break;
                }
                _visor.Text = _target.Text;
                _target.Focus();
            };

            return btn;
        }
    }
}
