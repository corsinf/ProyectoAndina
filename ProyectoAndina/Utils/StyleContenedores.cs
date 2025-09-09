using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProyectoAndina.Utils.StylesAlertas;

namespace ProyectoAndina.Utils
{
    public static class StyleContenedores
    {

        public static void CentrarPanel(Form form, Panel panel)
        {
            if (panel != null)
            {
                // Mantener la posición Y original (Top fijo)
                int topOriginal = panel.Location.Y;

                // Solo centrar horizontalmente y ajustar tamaño
                int margenHorizontal = 20; // Margen desde los bordes izquierdo y derecho
                int margenInferior = 20;   // Margen desde el borde inferior

                // Centrar horizontalmente con margen
                int nuevoX = margenHorizontal;
                int nuevoAncho = form.ClientSize.Width - (margenHorizontal * 2);

                // Expandir hacia abajo hasta el borde inferior con margen
                int nuevoAlto = form.ClientSize.Height - topOriginal - margenInferior;

                panel.Location = new Point(nuevoX, topOriginal);
                panel.Size = new Size(nuevoAncho, nuevoAlto);
            }
        }

        public static void ConfigurarResponsividad(Form form, Panel panel)
        {
            // Configurar al cargar
            form.Load += (s, e) => CentrarPanel(form, panel);
            // Reconfigurar cuando cambie el tamaño del form
            form.Resize += (s, e) => CentrarPanel(form, panel);

        }

        public static void ConfigurarResponsividadContenedor(Form form, Panel panelContenedor)
        {
            // Configurar al cargar
            form.Load += (s, e) => {
                AjustarTamañoContenedor(form, panelContenedor);
                DistribuirPanelesManteniendoTamaño(panelContenedor);
            };

            // Reconfigurar cuando cambie el tamaño del form
            form.Resize += (s, e) => {
                AjustarTamañoContenedor(form, panelContenedor);
                DistribuirPanelesManteniendoTamaño(panelContenedor);
            };
        }

        public static void AjustarTamañoContenedor(Form form, Panel panelContenedor)
        {
            if (panelContenedor?.Parent == null) return;

            Panel panelPadre = panelContenedor.Parent as Panel;
            if (panelPadre == null) return;

            // El panel_contenedor se ajusta al ancho de su padre (panelModulos)
            int margen = 20;
            panelContenedor.Location = new Point(margen, panelContenedor.Location.Y);
            panelContenedor.Width = panelPadre.Width - (margen * 2); // AQUÍ también está correcto: resta margen izquierdo Y derecho
        }



        // TU MÉTODO ORIGINAL (sin cambios)
        public static void DistribuirPanelesManteniendoTamaño(Panel panelContenedor, int margenEntrePaneles = 10, int margenExterno = 10)
        {
            if (panelContenedor == null || panelContenedor.Controls.Count == 0) return;
            var paneles = panelContenedor.Controls.OfType<Panel>().ToList();
            if (paneles.Count == 0) return;

            // Calcular el ancho total ocupado por todos los paneles
            int anchoTotalPaneles = paneles.Sum(p => p.Width);
            int anchoTotalMargenes = margenEntrePaneles * (paneles.Count - 1);
            int anchoTotal = anchoTotalPaneles + anchoTotalMargenes;

            // Calcular posición inicial para centrar todo el conjunto
            int inicioX = (panelContenedor.Width - anchoTotal) / 2;

            // Si no cabe, ajustar al margen externo
            if (inicioX < margenExterno)
                inicioX = margenExterno;

            // Distribuir los paneles
            int posicionActual = inicioX;
            foreach (Panel panel in paneles)
            {
                // Mantener tamaño original, solo cambiar posición
                panel.Location = new Point(posicionActual, panel.Location.Y);

                CentrarContenidoEnPanel(panel);

                posicionActual += panel.Width + margenEntrePaneles;
            }
        }

        public static void CentrarContenidoEnPanel(Panel panel)
        {
            if (panel == null || panel.Controls.Count == 0) return;

            foreach (Control c in panel.Controls)
            {
                // Mantiene la posición vertical original (Top) y centra horizontalmente
                c.Left = (panel.Width - c.Width) / 2;
            }
        }

        // VERSIÓN ALTERNATIVA MÁS SIMPLE
        public static void ConfigurarTodoAutomatico(Form form, Panel panelPrincipal, Panel panelContenedor)
        {
            // Panel principal
            ConfigurarResponsividad(form, panelPrincipal);

            // Panel contenedor se ajusta automáticamente
            panelContenedor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Distribución automática
            form.Load += (s, e) => DistribuirPanelesManteniendoTamaño(panelContenedor);
            form.Resize += (s, e) => DistribuirPanelesManteniendoTamaño(panelContenedor);
        }

        public static void DistribuirPanelesOcupandoTodoElEspacio(Panel panelContenedor, int margenEntrePaneles = 10, int margenExterno = 10)
        {
            if (panelContenedor == null || panelContenedor.Controls.Count == 0) return;
            var paneles = panelContenedor.Controls.OfType<Panel>().ToList();
            if (paneles.Count == 0) return;

            int cantidadPaneles = paneles.Count;

            // Calcular el espacio disponible
            int espacioDisponible = panelContenedor.Width - (margenExterno * 2) - (margenEntrePaneles * (cantidadPaneles - 1));
            int anchoPorPanel = espacioDisponible / cantidadPaneles;

            // Altura disponible (mantener margen superior e inferior)
            int altoDisponible = panelContenedor.Height - (margenExterno * 2);

            // Distribuir los paneles
            for (int i = 0; i < paneles.Count; i++)
            {
                Panel panel = paneles[i];

                // Calcular posición X
                int posicionX = margenExterno + (i * (anchoPorPanel + margenEntrePaneles));

                // Asignar nueva posición y tamaño
                panel.Location = new Point(posicionX, margenExterno);
                panel.Size = new Size(anchoPorPanel, altoDisponible);
            }
        }
        

        // VERSIÓN MEJORADA CON DISTRIBUCIÓN INTELIGENTE
        public static void DistribuirPanelesInteligente(Panel panelContenedor, int margenEntrePaneles = 10, int margenExterno = 10)
        {
            if (panelContenedor == null || panelContenedor.Controls.Count == 0) return;
            var paneles = panelContenedor.Controls.OfType<Panel>().ToList();
            if (paneles.Count == 0) return;

            int cantidadPaneles = paneles.Count;
            int anchoContenedor = panelContenedor.Width;
            int altoContenedor = panelContenedor.Height;

            // Calcular distribución según la cantidad de paneles
            switch (cantidadPaneles)
            {
                case 1:
                    // Un panel ocupa todo el espacio
                    paneles[0].Location = new Point(margenExterno, margenExterno);
                    paneles[0].Size = new Size(anchoContenedor - (margenExterno * 2),
                                             altoContenedor - (margenExterno * 2));
                    break;

                case 2:
                    // Dos paneles: izquierda y derecha
                    int anchoDos = (anchoContenedor - (margenExterno * 2) - margenEntrePaneles) / 2;

                    paneles[0].Location = new Point(margenExterno, margenExterno);
                    paneles[0].Size = new Size(anchoDos, altoContenedor - (margenExterno * 2));

                    paneles[1].Location = new Point(margenExterno + anchoDos + margenEntrePaneles, margenExterno);
                    paneles[1].Size = new Size(anchoDos, altoContenedor - (margenExterno * 2));
                    break;

                case 3:
                    // Tres paneles: izquierda, centro, derecha
                    int anchoTres = (anchoContenedor - (margenExterno * 2) - (margenEntrePaneles * 2)) / 3;

                    paneles[0].Location = new Point(margenExterno, margenExterno);
                    paneles[0].Size = new Size(anchoTres, altoContenedor - (margenExterno * 2));

                    paneles[1].Location = new Point(margenExterno + anchoTres + margenEntrePaneles, margenExterno);
                    paneles[1].Size = new Size(anchoTres, altoContenedor - (margenExterno * 2));

                    paneles[2].Location = new Point(margenExterno + (anchoTres * 2) + (margenEntrePaneles * 2), margenExterno);
                    paneles[2].Size = new Size(anchoTres, altoContenedor - (margenExterno * 2));
                    break;

                default:
                    // Más de 3 paneles: distribución uniforme
                    DistribuirPanelesOcupandoTodoElEspacio(panelContenedor, margenEntrePaneles, margenExterno);
                    break;
            }
        }

       


        // MÉTODO PARA USAR LA DISTRIBUCIÓN INTELIGENTE
        public static void ConfigurarResponsividadInteligente(Form form, Panel panelContenedor)
        {
            // Configurar al cargar
            form.Load += (s, e) => {
                AjustarTamañoContenedor(form, panelContenedor);
                DistribuirPanelesInteligente(panelContenedor);
            };

            // Reconfigurar cuando cambie el tamaño del form
            form.Resize += (s, e) => {
                AjustarTamañoContenedor(form, panelContenedor);
                DistribuirPanelesInteligente(panelContenedor);
            };
        }

        public static void ConfigurarResponsividadVertical(
     Form form,
     Panel panelContenedor,
     int totalColumnas = 12,
     int[] columnasPorPanel = null,
     int[] ordenPaneles = null) // <-- nuevo parámetro para orden
        {
            if (panelContenedor == null || form == null) return;

            // Se aplica al cargar el form
            form.Load += (s, e) =>
            {
                DistribuirPanelesVerticalConColumnas(panelContenedor, totalColumnas, columnasPorPanel, ordenPaneles);
            };

            // Se aplica cada vez que cambie el tamaño
            form.Resize += (s, e) =>
            {
                DistribuirPanelesVerticalConColumnas(panelContenedor, totalColumnas, columnasPorPanel, ordenPaneles);
            };

            // ⚡ Ajuste inmediato si ya está creado y visible
            if (form.IsHandleCreated && panelContenedor.IsHandleCreated)
            {
                DistribuirPanelesVerticalConColumnas(panelContenedor, totalColumnas, columnasPorPanel, ordenPaneles);
            }
        }



        // Distribución vertical responsiva
        public static void DistribuirPanelesVerticalConColumnas(
     Panel panelContenedor,
     int totalColumnas = 12,
     int[] columnasPorPanel = null,
     int[] ordenPaneles = null,
     int margenEntrePaneles = 10,
     int margenExterno = 10)
        {
            if (panelContenedor == null || panelContenedor.Controls.Count == 0) return;

            // ✅ Solo paneles visibles
            var paneles = panelContenedor.Controls
                                         .OfType<Panel>()
                                         .Where(p => p.Visible)
                                         .ToList();
            if (paneles.Count == 0) return;

            int cantidadPaneles = paneles.Count;

            // ✅ Ajustar columnasPorPanel solo a visibles
            if (columnasPorPanel == null || columnasPorPanel.Length != cantidadPaneles)
            {
                columnasPorPanel = new int[cantidadPaneles];
                for (int i = 0; i < cantidadPaneles; i++)
                    columnasPorPanel[i] = totalColumnas / cantidadPaneles;
            }

            // ✅ Ajustar orden solo a visibles
            if (ordenPaneles == null || ordenPaneles.Length != cantidadPaneles)
            {
                ordenPaneles = new int[cantidadPaneles];
                for (int i = 0; i < cantidadPaneles; i++)
                    ordenPaneles[i] = i;
            }

            int sumColumnas = columnasPorPanel.Sum();
            int espacioDisponible = panelContenedor.Height - (margenExterno * 2) - (margenEntrePaneles * (cantidadPaneles - 1));
            int posicionY = margenExterno;

            for (int i = 0; i < cantidadPaneles; i++)
            {
                int index = ordenPaneles[i];
                if (index < 0 || index >= cantidadPaneles) continue;

                Panel panel = paneles[index];

                // Mantener X y Width originales
                int posicionX = panel.Location.X;
                int ancho = panel.Width;

                int alto = (columnasPorPanel[index] * espacioDisponible) / sumColumnas;

                panel.Location = new Point(posicionX, posicionY);
                panel.Size = new Size(ancho, alto);

                posicionY += alto + margenEntrePaneles;
            }
        }




        public static void ConfigurarResponsividadHorizontal(
            Form form,
            Panel panelContenedor,
            int totalColumnas = 12,
            int[] columnasPorPanel = null,
            int[] ordenPaneles = null,
            bool centrarVertical = false)
        {
            if (panelContenedor == null) return;

            // Método para ejecutar el ajuste
            Action ajustar = () => {
                AjustarTamañoContenedor(form, panelContenedor);
                DistribuirPanelesHorizontalConColumnas(panelContenedor, totalColumnas, columnasPorPanel, ordenPaneles, centrarVertical);
            };

            // Usar Shown en lugar de Load para asegurar que el formulario esté completamente renderizado
            form.Shown += (s, e) => {
                // Usar Timer para dar tiempo al layout
                var timer = new System.Windows.Forms.Timer();
                timer.Interval = 50; // 50ms debería ser suficiente
                timer.Tick += (sender, args) => {
                    timer.Stop();
                    timer.Dispose();
                    ajustar();
                };
                timer.Start();
            };

            form.Resize += (s, e) => {
                ajustar();
            };

            // También manejar el evento Layout del panel contenedor
            panelContenedor.Layout += (s, e) => {
                if (form.WindowState != FormWindowState.Minimized)
                {
                    ajustar();
                }
            };
        }

        public static void DistribuirPanelesHorizontalConColumnas(
            Panel panelContenedor,
            int totalColumnas = 12,
            int[] columnasPorPanel = null,
            int[] ordenPaneles = null,
            bool centrarVertical = false,
            int margenEntrePaneles = 10,
            int margenExterno = 10)
        {
            if (panelContenedor == null || panelContenedor.Controls.Count == 0) return;

            // Verificar que el panel tenga dimensiones válidas
            if (panelContenedor.Width <= 0 || panelContenedor.Height <= 0) return;

            var paneles = panelContenedor.Controls.OfType<Panel>().ToList();
            int cantidadPaneles = paneles.Count;

            if (cantidadPaneles == 0) return;

            if (columnasPorPanel == null || columnasPorPanel.Length != cantidadPaneles)
            {
                columnasPorPanel = new int[cantidadPaneles];
                for (int i = 0; i < cantidadPaneles; i++)
                    columnasPorPanel[i] = totalColumnas / cantidadPaneles;
            }

            if (ordenPaneles == null || ordenPaneles.Length != cantidadPaneles)
            {
                ordenPaneles = new int[cantidadPaneles];
                for (int i = 0; i < cantidadPaneles; i++)
                    ordenPaneles[i] = i;
            }

            int sumColumnas = columnasPorPanel.Sum();

            // CORRECCIÓN: Restar márgenes externos de ambos lados (izquierdo Y derecho)
            int espacioDisponible = panelContenedor.Width - (2 * margenExterno) - (margenEntrePaneles * (cantidadPaneles - 1));

            int posicionX = margenExterno; // empezamos desde el margen externo izquierdo
            int altoDisponible = panelContenedor.Height - (margenExterno * 2);

            // Para mejor distribución, calculamos los anchos primero
            int[] anchosCalculados = new int[cantidadPaneles];
            int anchoTotalUsado = 0;

            // Calcular anchos individuales
            for (int i = 0; i < cantidadPaneles - 1; i++)
            {
                int index = ordenPaneles[i];
                anchosCalculados[i] = (columnasPorPanel[index] * espacioDisponible) / sumColumnas;
                anchoTotalUsado += anchosCalculados[i];
            }

            // El último panel toma el espacio restante para evitar problemas de redondeo
            if (cantidadPaneles > 0)
            {
                anchosCalculados[cantidadPaneles - 1] = espacioDisponible - anchoTotalUsado;
            }

            for (int i = 0; i < cantidadPaneles; i++)
            {
                int index = ordenPaneles[i];
                if (index < 0 || index >= cantidadPaneles) continue;

                Panel panel = paneles[index];
                int ancho = anchosCalculados[i];
                int posicionY = margenExterno;
                int alto = altoDisponible;

                panel.Location = new Point(posicionX, posicionY);
                panel.Size = new Size(ancho, alto);

                // Centrar contenido vertical dentro de cada panel
                if (centrarVertical && panel.Controls.Count > 0)
                {
                    foreach (Control ctrl in panel.Controls)
                    {
                        ctrl.Location = new Point(
                            ctrl.Location.X, // X original
                            (panel.Height - ctrl.Height) / 2 // centrado vertical
                        );
                    }
                }

                // Avanzar la posición X para el siguiente panel (solo si no es el último)
                if (i < cantidadPaneles - 1)
                {
                    posicionX += ancho + margenEntrePaneles;
                }
            }
        }

        public static void EstilizarCardAcceso(
     Panel panelContainer,
     Panel panelTitulo,
     Panel panelImagen,
     Panel panelDescripcion,
     string titulo,
     Image imagen,
     string descripcion,
     bool acceso = true,
     Action onAcceso = null,
          Form form = null)
        {
            if (panelContainer == null) return;

            // --- Estilo principal de la Card ---
            panelContainer.BorderStyle = BorderStyle.None;
            panelContainer.BackColor = Color.White;
            panelContainer.Padding = new Padding(15);
            panelContainer.Margin = new Padding(10);

            panelContainer.Cursor = Cursors.Hand;

            // Borde redondeado
            panelContainer.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Rectangle rect = new Rectangle(0, 0, panelContainer.Width - 1, panelContainer.Height - 1);
                using (var brush = new SolidBrush(panelContainer.BackColor))
                using (var pen = new Pen(Color.LightGray, 2))
                {
                    e.Graphics.FillRoundedRectangle(brush, rect, 20);
                    e.Graphics.DrawRoundedRectangle(pen, rect, 20);
                }
            };

            // --- Título ---
            if (panelTitulo != null)
            {
                panelTitulo.Dock = DockStyle.Top;
                panelTitulo.Height = 40;
                panelTitulo.BackColor = Color.Transparent;
                panelTitulo.Padding = new Padding(5);

                var lblTitulo = new Label
                {
                    Text = titulo,
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.Black,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                panelTitulo.Controls.Clear();
                panelTitulo.Controls.Add(lblTitulo);
            }

            // --- Imagen ---
            if (panelImagen != null && imagen != null)
            {
                panelImagen.Dock = DockStyle.Top;
                panelImagen.Height = 120;
                panelImagen.BackColor = Color.Transparent;

                var picture = new PictureBox
                {
                    Image = imagen,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(0, 10, 0, 10)
                };

                panelImagen.Controls.Clear();
                panelImagen.Controls.Add(picture);
            }

            // --- Descripción ---
            if (panelDescripcion != null)
            {
                panelDescripcion.Dock = DockStyle.Fill;
                panelDescripcion.BackColor = Color.Transparent;
                panelDescripcion.Padding = new Padding(10);

                var lblDescripcion = new Label
                {
                    Text = descripcion,
                    Dock = DockStyle.Top,
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    ForeColor = acceso ? Color.Green : Color.Red,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                panelDescripcion.Controls.Clear();
                panelDescripcion.Controls.Add(lblDescripcion);
            }

            // --- Evento Click para toda la card ---
            void CardClick(object sender, EventArgs e)
            {
                if (acceso)
                {
                    onAcceso?.Invoke();
                }
                else
                {
                    StylesAlertas.MostrarAlerta(form, "❌ No tiene acceso a esta sección", "¡Error!", TipoAlerta.Error);
                }
            }

            // Registrar click en panel principal y todos los subpaneles y controles internos
            RegisterClickRecursive(panelContainer, CardClick);

            // --- Hover visual ---
            panelContainer.MouseEnter += (s, e) => panelContainer.BackColor = Color.FromArgb(240, 240, 240);
            panelContainer.MouseLeave += (s, e) => panelContainer.BackColor = Color.White;
        }

        public static void EstilizarCard(
    Panel panelContainer,
    Panel panelTitulo,
    Panel panelImagen,
    string titulo,
    Image imagen,
    Action onClick = null)
        {
            if (panelContainer == null) return;

            // --- Estilo principal de la Card ---
            panelContainer.BorderStyle = BorderStyle.None;
            panelContainer.BackColor = Color.White;
            panelContainer.Padding = new Padding(15);
            panelContainer.Margin = new Padding(10);
            panelContainer.Cursor = Cursors.Hand;

            // Borde redondeado
            panelContainer.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Rectangle rect = new Rectangle(0, 0, panelContainer.Width - 1, panelContainer.Height - 1);
                using (var brush = new SolidBrush(panelContainer.BackColor))
                using (var pen = new Pen(Color.LightGray, 2))
                {
                    e.Graphics.FillRoundedRectangle(brush, rect, 20);
                    e.Graphics.DrawRoundedRectangle(pen, rect, 20);
                }
            };

            // --- Imagen primero ---
            if (panelImagen != null && imagen != null)
            {
                panelImagen.Dock = DockStyle.Top;
                panelImagen.Height = 170; // aumentamos un poco la altura total
                panelImagen.BackColor = Color.Transparent;

                var picture = new PictureBox
                {
                    Image = imagen,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(100, 100),
                    Dock = DockStyle.None,
                    Anchor = AnchorStyles.None,
                    Margin = new Padding(0, 25, 0, 0) // 👈 margen superior de 15px
                };

                // Centrado dentro del panel
                picture.Location = new Point(
                    (panelImagen.Width - picture.Width) / 2,
                    (panelImagen.Height - picture.Height) / 2
                );

                panelImagen.Resize += (s, e) =>
                {
                    picture.Location = new Point(
                        (panelImagen.Width - picture.Width) / 2,
                        (panelImagen.Height - picture.Height) / 2
                    );
                };

                panelImagen.Controls.Clear();
                panelImagen.Controls.Add(picture);
            }

            // --- Título después ---
            if (panelTitulo != null)
            {
                panelTitulo.Dock = DockStyle.Top;
                panelTitulo.Height = 40;
                panelTitulo.BackColor = Color.Transparent;
                panelTitulo.Padding = new Padding(5);

                var lblTitulo = new Label
                {
                    Text = titulo,
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.Black,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                panelTitulo.Controls.Clear();
                panelTitulo.Controls.Add(lblTitulo);
            }

            // --- Evento Click ---
            void CardClick(object sender, EventArgs e) => onClick?.Invoke();
            RegisterClickRecursive(panelContainer, CardClick);

            // --- Hover visual ---
            panelContainer.MouseEnter += (s, e) => panelContainer.BackColor = Color.FromArgb(240, 240, 240);
            panelContainer.MouseLeave += (s, e) => panelContainer.BackColor = Color.White;
        }


        // Helper para propagar el click a todos los controles hijos
        private static void RegisterClickRecursive(Control control, EventHandler handler)
        {
            control.Click += handler;
            foreach (Control child in control.Controls)
            {
                RegisterClickRecursive(child, handler);
            }
        }


        /// <summary>
        /// Aplica hover al panel completo
        /// </summary>
        private static void AddHoverEffect(Control control, Color backNormal, Color backHover)
        {
            control.MouseEnter += (s, e) =>
            {
                var parentPanel = GetRootPanel(control);
                parentPanel.BackColor = backHover;
                parentPanel.Invalidate();
            };

            control.MouseLeave += (s, e) =>
            {
                var parentPanel = GetRootPanel(control);

                if (!parentPanel.ClientRectangle.Contains(parentPanel.PointToClient(Cursor.Position)))
                {
                    parentPanel.BackColor = backNormal;
                    parentPanel.Invalidate();
                }
            };

            foreach (Control child in control.Controls)
                AddHoverEffect(child, backNormal, backHover);
        }

        /// <summary>
        /// Hace que la card sea "clickeable"
        /// </summary>
        private static void AddClickEffect(Panel panel, bool acceso, Action onAcceso)
        {
            panel.Cursor = Cursors.Hand;

            void ClickHandler(object s, EventArgs e)
            {
                if (acceso)
                {
                    // ✅ Si tiene acceso → ejecutar acción
                    onAcceso?.Invoke();
                }
                else
                {
                    // ❌ Mostrar mensaje bonito de acceso denegado
                    MessageBox.Show(
                        "⛔ No tiene acceso a esta sección.",
                        "Acceso Denegado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }

            panel.Click += ClickHandler;

            // Para que los hijos no "bloqueen" el click
            foreach (Control child in panel.Controls)
                child.Click += ClickHandler;
        }

        private static Panel GetRootPanel(Control control)
        {
            while (control.Parent != null && !(control is Panel))
                control = control.Parent;

            return control as Panel;
        }

        // Métodos gráficos auxiliares
        public static void FillRoundedRectangle(this Graphics g, Brush brush, Rectangle bounds, int cornerRadius)
        {
            using (var path = RoundedRect(bounds, cornerRadius))
            {
                g.FillPath(brush, path);
            }
        }

        public static void DrawRoundedRectangle(this Graphics g, Pen pen, Rectangle bounds, int cornerRadius)
        {
            using (var path = RoundedRect(bounds, cornerRadius))
            {
                g.DrawPath(pen, path);
            }
        }

        private static System.Drawing.Drawing2D.GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }


        public static void AjustarPanelEnContenedor(Panel contenedor, Panel panel, int margenHorizontal = 20, int margenInferior = 20, int margenSuperior = 20)
        {
            if (contenedor != null && panel != null)
            {
                // Márgenes izquierda y derecha
                int nuevoX = margenHorizontal;
                int nuevoAncho = contenedor.ClientSize.Width - (margenHorizontal * 2);

                // Mantener espacio arriba y abajo
                int nuevoY = margenSuperior;
                int nuevoAlto = contenedor.ClientSize.Height - margenSuperior - margenInferior;

                // Ajustar panel dentro del contenedor
                panel.Location = new Point(nuevoX, nuevoY);
                panel.Size = new Size(nuevoAncho, nuevoAlto);
            }
        }

        public static void ConfigurarResponsividadEnContenedor(Panel contenedor, Panel panel, int margenHorizontal = 20, int margenInferior = 20, int margenSuperior = 20)
        {
            contenedor.HandleCreated += (s, e) =>
            {
                AjustarPanelEnContenedor(contenedor, panel, margenHorizontal, margenInferior, margenSuperior);
            };

            // Ajuste en cada redimensionamiento
            contenedor.Resize += (s, e) =>
            {
                AjustarPanelEnContenedor(contenedor, panel, margenHorizontal, margenInferior, margenSuperior);
            }; if (contenedor.IsHandleCreated)
            {
                AjustarPanelEnContenedor(contenedor, panel, margenHorizontal, margenInferior, margenSuperior);
            }
        }


        public static void AjustarPanelEnContenedorWidth(Panel contenedor, Panel panel, int margenHorizontal = 20)
        {
            if (contenedor != null && panel != null)
            {
                // Mantener altura y posición Y originales
                int alturaOriginal = panel.Height;
                int posicionYOriginal = panel.Location.Y;

                // Ajustar solo ancho con márgenes horizontales
                int nuevoX = margenHorizontal;
                int nuevoAncho = contenedor.ClientSize.Width - (margenHorizontal * 2);

                panel.Location = new Point(nuevoX, posicionYOriginal);
                panel.Size = new Size(nuevoAncho, alturaOriginal);
            }
        }

        public static void ConfigurarResponsividadEnContenedorWidth(Panel contenedor, Panel panel, int margenHorizontal = 20)
        {
            contenedor.HandleCreated += (s, e) =>
                AjustarPanelEnContenedorWidth(contenedor, panel, margenHorizontal);

            contenedor.Resize += (s, e) =>
                AjustarPanelEnContenedorWidth(contenedor, panel, margenHorizontal);
        }
        public static void ConfigurarResponsividadHorizontalPanel(
    Panel panelContenedor,
    int totalColumnas = 12,
    int[] columnasPorPanel = null,
    int[] ordenPaneles = null,
    int margenEntrePaneles = 10,
    int margenExterno = 10,
    bool centrarVertical = false)
        {
            if (panelContenedor == null) return;

            void ajustar()
            {
                if (panelContenedor.IsHandleCreated && panelContenedor.Parent != null)
                {
                    DistribuirPanelesHorizontalConColumnasNuevo(
                        panelContenedor,
                        totalColumnas,
                        columnasPorPanel,
                        ordenPaneles,
                        margenEntrePaneles,
                        margenExterno,
                        centrarVertical
                    );
                }
            }

            // Se ejecuta al crear el control (ya cargado en pantalla)
            panelContenedor.HandleCreated += (s, e) => ajustar();

            // Se ejecuta si cambia de tamaño
            panelContenedor.Resize += (s, e) => ajustar();

            // Se ejecuta al hacer Layout (ej: cuando agregas o quitas paneles hijos)
            panelContenedor.Layout += (s, e) => ajustar();

            // Forzar una vez manual por si ya está cargado
            if (panelContenedor.IsHandleCreated)
                ajustar();
        }


        public static void DistribuirPanelesHorizontalConColumnasNuevo(
    Panel panelContenedor,
    int totalColumnas = 12,
    int[] columnasPorPanel = null,
    int[] ordenPaneles = null,
    int margenEntrePaneles = 10,
    int margenExterno = 10,
    bool centrarVertical = false)
        {
            if (panelContenedor == null || panelContenedor.Controls.Count == 0) return;

            // ✅ Solo paneles visibles
            var paneles = panelContenedor.Controls
                                         .OfType<Panel>()
                                         .Where(p => p.Visible)
                                         .ToList();
            if (paneles.Count == 0) return;

            int cantidadPaneles = paneles.Count;

            // ✅ Ajustar columnasPorPanel solo a visibles
            if (columnasPorPanel == null || columnasPorPanel.Length != cantidadPaneles)
            {
                columnasPorPanel = new int[cantidadPaneles];
                for (int i = 0; i < cantidadPaneles; i++)
                    columnasPorPanel[i] = totalColumnas / cantidadPaneles;
            }

            // ✅ Ajustar orden solo a visibles
            if (ordenPaneles == null || ordenPaneles.Length != cantidadPaneles)
            {
                ordenPaneles = new int[cantidadPaneles];
                for (int i = 0; i < cantidadPaneles; i++)
                    ordenPaneles[i] = i;
            }

            int sumColumnas = columnasPorPanel.Sum();

            // Espacio útil dentro del contenedor
            int anchoDisponible = panelContenedor.Width - (margenExterno * 2) - (margenEntrePaneles * (cantidadPaneles - 1));
            int altoDisponible = panelContenedor.Height - (margenExterno * 2);

            int posicionX = margenExterno;

            for (int i = 0; i < cantidadPaneles; i++)
            {
                int index = ordenPaneles[i];
                if (index < 0 || index >= cantidadPaneles) continue;

                Panel panel = paneles[index];

                // 🔹 Calcular ancho proporcional
                int ancho = (columnasPorPanel[index] * anchoDisponible) / sumColumnas;

                // 🔹 Alto: puede ser todo el alto disponible o dividido proporcional
                int alto = altoDisponible;

                // Si quieres repartir verticalmente también, puedes hacer algo como:
                // alto = altoDisponible / cantidadPaneles;

                // Posición en Y
                int posicionY = margenExterno;
                if (centrarVertical)
                {
                    posicionY = (panelContenedor.Height - alto) / 2;
                }

                panel.Location = new Point(posicionX, posicionY);
                panel.Size = new Size(ancho, alto);

                posicionX += ancho + margenEntrePaneles;
            }
        }
        // ✅ Configurar distribución vertical responsiva en un Panel padre

        public static void ConfigurarResponsividadVerticalPanel(
    Panel panelContenedor,
    int totalColumnas = 12,
    int[] columnasPorPanel = null,
    int[] ordenPaneles = null,
    int margenEntrePaneles = 10,
    int margenExterno = 10,
    bool centrarHorizontal = false)
        {
            if (panelContenedor == null) return;

            void ajustar()
            {
                if (panelContenedor.IsHandleCreated && panelContenedor.Parent != null)
                {
                    DistribuirPanelesVerticalConColumnasNuevo(
                        panelContenedor,
                        totalColumnas,
                        columnasPorPanel,
                        ordenPaneles,
                        margenEntrePaneles,
                        margenExterno,
                        centrarHorizontal
                    );
                }
            }

            // Se ejecuta al crear el control
            panelContenedor.HandleCreated += (s, e) => ajustar();

            // Se ejecuta al cambiar de tamaño
            panelContenedor.Resize += (s, e) => ajustar();

            // Se ejecuta al hacer Layout (cuando agregas o quitas paneles hijos)
            panelContenedor.Layout += (s, e) => ajustar();

            // Forzar una vez manual por si ya está cargado
            if (panelContenedor.IsHandleCreated)
                ajustar();
        }


        public static void DistribuirPanelesVerticalConColumnasNuevo(
            Panel panelContenedor,
            int totalColumnas = 12,
            int[] columnasPorPanel = null,
            int[] ordenPaneles = null,
            int margenEntrePaneles = 10,
            int margenExterno = 10,
            bool centrarHorizontal = false)
        {
            if (panelContenedor == null || panelContenedor.Controls.Count == 0) return;

            // ✅ Solo paneles visibles
            var paneles = panelContenedor.Controls
                                         .OfType<Panel>()
                                         .Where(p => p.Visible)
                                         .ToList();
            if (paneles.Count == 0) return;

            int cantidadPaneles = paneles.Count;

            // ✅ Ajustar columnasPorPanel solo a visibles
            if (columnasPorPanel == null || columnasPorPanel.Length != cantidadPaneles)
            {
                columnasPorPanel = new int[cantidadPaneles];
                for (int i = 0; i < cantidadPaneles; i++)
                    columnasPorPanel[i] = totalColumnas / cantidadPaneles;
            }

            // ✅ Ajustar orden solo a visibles
            if (ordenPaneles == null || ordenPaneles.Length != cantidadPaneles)
            {
                ordenPaneles = new int[cantidadPaneles];
                for (int i = 0; i < cantidadPaneles; i++)
                    ordenPaneles[i] = i;
            }

            int sumColumnas = columnasPorPanel.Sum();

            // Espacio útil dentro del contenedor
            int altoDisponible = panelContenedor.Height - (margenExterno * 2) - (margenEntrePaneles * (cantidadPaneles - 1));
            int anchoDisponible = panelContenedor.Width - (margenExterno * 2);

            int posicionY = margenExterno;

            for (int i = 0; i < cantidadPaneles; i++)
            {
                int index = ordenPaneles[i];
                if (index < 0 || index >= cantidadPaneles) continue;

                Panel panel = paneles[index];

                // 🔹 Calcular alto proporcional
                int alto = (columnasPorPanel[index] * altoDisponible) / sumColumnas;

                // 🔹 Ancho: todo el ancho disponible
                int ancho = anchoDisponible;

                // Posición en X
                int posicionX = margenExterno;
                if (centrarHorizontal)
                {
                    posicionX = (panelContenedor.Width - ancho) / 2;
                }

                panel.Location = new Point(posicionX, posicionY);
                panel.Size = new Size(ancho, alto);

                posicionY += alto + margenEntrePaneles;
            }
        }
        public static void EstilizarPanel(Panel panel, Color bordeColor, int borderRadius = 10, int sombraOffset = 5)
        {
            if (panel == null) return;

            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.None;

            // Paint para borde y sombra
            panel.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);

                // Sombra
                Rectangle sombraRect = new Rectangle(sombraOffset, sombraOffset, panel.Width - 1, panel.Height - 1);
                using (var sombraBrush = new SolidBrush(Color.FromArgb(50, Color.Transparent)))
                using (var sombraPath = RoundedRect(sombraRect, borderRadius))
                {
                    e.Graphics.FillPath(sombraBrush, sombraPath);
                }

                // Borde
                using (var pen = new Pen(bordeColor, 2))
                using (var path = RoundedRect(rect, borderRadius))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            };

            panel.Invalidate(); // forzar redibujado
        }



        public static void EstilizarTableLayout(
    TableLayoutPanel tableLayout,
    Color borderColor,
    int borderRadius = 12,
    int borderWidth = 2,
    int shadowOffset = 4,
    Color? backgroundColor = null // por defecto blanco
)
        {
            if (tableLayout == null) return;

            tableLayout.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            var bgColor = backgroundColor ?? Color.White;

            tableLayout.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                var rect = new Rectangle(0, 0, tableLayout.Width - 1, tableLayout.Height - 1);

                // ☁️ SOMBRA
                if (shadowOffset > 0)
                {
                    var shadowRect = new Rectangle(shadowOffset, shadowOffset,
                        tableLayout.Width - shadowOffset, tableLayout.Height - shadowOffset);

                    using (var shadowBrush = new SolidBrush(Color.FromArgb(25, 0, 0, 0)))
                    using (var shadowPath = CreateRoundedRect(shadowRect, borderRadius))
                    {
                        e.Graphics.FillPath(shadowBrush, shadowPath);
                    }
                }

                // 🎨 FONDO BLANCO (interior limpio)
                using (var bgBrush = new SolidBrush(bgColor))
                using (var bgPath = CreateRoundedRect(rect, borderRadius))
                {
                    e.Graphics.FillPath(bgBrush, bgPath);
                }

                // 🔲 BORDE
                using (var borderPen = new Pen(borderColor, borderWidth))
                using (var borderPath = CreateRoundedRect(rect, borderRadius))
                {
                    e.Graphics.DrawPath(borderPen, borderPath);
                }
            };

            tableLayout.Invalidate();
        }


        // 🎯 VERSIÓN SIMPLE SIN SOMBRA (más limpia)
        public static void EstilizarTableLayoutSimple(
            TableLayoutPanel tableLayout,
            Color borderColor,
            int borderRadius = 8,
            int borderWidth = 1)
        {
            EstilizarTableLayout(tableLayout, borderColor, borderRadius, borderWidth, 0);
        }

        // 🔧 MÉTODO AUXILIAR PARA RECTÁNGULOS REDONDEADOS
        private static GraphicsPath CreateRoundedRect(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            int diameter = radius * 2;

            if (rect.Width <= diameter || rect.Height <= diameter || radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            // Crear rectángulo con esquinas redondeadas
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90); // Superior izquierda
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90); // Superior derecha
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90); // Inferior derecha
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90); // Inferior izquierda

            path.CloseAllFigures();
            return path;
        }


    }
}
