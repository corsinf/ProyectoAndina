using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32; // Para SystemEvents

namespace ProyectoAndina.Utils
{
    public class KioskForm : Form
    {
        // Win32 APIs adicionales para control total de ventana
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(int nIndex);

        [DllImport("user32.dll")]
        private static extern IntPtr MonitorFromWindow(IntPtr hwnd, uint dwFlags);

        [DllImport("user32.dll")]
        private static extern bool GetMonitorInfo(IntPtr hMonitor, ref MONITORINFO lpmi);

        [StructLayout(LayoutKind.Sequential)]
        private struct MONITORINFO
        {
            public int cbSize;
            public Rectangle rcMonitor;
            public Rectangle rcWork;
            public uint dwFlags;
        }

        // Constantes Win32
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int WM_NCLBUTTONDBLCLK = 0xA3;
        private const int WM_SYSCOMMAND = 0x0112;
        private const int WM_NCHITTEST = 0x0084;
        private const int SC_MOVE = 0xF010;
        private const int SC_KEYMENU = 0xF100;
        private const int HTCAPTION = 0x02;

        private static readonly IntPtr HWND_TOP = IntPtr.Zero;
        private const uint SWP_SHOWWINDOW = 0x0040;
        private const uint SWP_NOACTIVATE = 0x0010;
        private const int SM_CXSCREEN = 0;
        private const int SM_CYSCREEN = 1;
        private const int SM_XVIRTUALSCREEN = 76;
        private const int SM_YVIRTUALSCREEN = 77;
        private const int SM_CXVIRTUALSCREEN = 78;
        private const int SM_CYVIRTUALSCREEN = 79;
        private const uint MONITOR_DEFAULTTOPRIMARY = 1;

        private Rectangle _lockBounds;
        private bool _restaurandoPos = false;
        private bool _permitirCerrar = false;

        // Tap secreto
        private int _tapCount = 0;
        private DateTime _lastTap = DateTime.MinValue;
        private int _tapGoal = 7;
        private TimeSpan _tapWindow = TimeSpan.FromSeconds(5);

        public KioskForm(bool hideTaskbar = true)
        {
            // Configuración básica del form
            FormBorderStyle = FormBorderStyle.None;
            ControlBox = false;
            ShowIcon = false;
            ShowInTaskbar = false;
            TopMost = true;
            KeyPreview = true;
            WindowState = FormWindowState.Normal;
            StartPosition = FormStartPosition.Manual;

            // Eliminar cualquier margen o padding
            Margin = new Padding(0);
            Padding = new Padding(0);

            // Configuración adicional para evitar bordes invisibles
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            if (hideTaskbar)
                TaskbarHelper.HideTaskbar();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // Remover todos los estilos de ventana que puedan causar bordes
                cp.Style &= ~0x00C00000; // WS_BORDER
                cp.ExStyle &= ~0x00000200; // WS_EX_CLIENTEDGE
                cp.ExStyle &= ~0x00000001; // WS_EX_DLGMODALFRAME
                return cp;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // FORZAR configuración de pantalla completa usando APIs de Windows
            SetFullScreenBoundsNative();

            // Eventos para mantener la posición y tamaño bloqueados
            LocationChanged += OnLocationOrSizeChanged;
            SizeChanged += OnLocationOrSizeChanged;

            // Evento adicional para manejar cambios en la resolución
            SystemEvents.DisplaySettingsChanged += (s, args) => SetFullScreenBoundsNative();
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(value);
            if (value && !_restaurandoPos)
            {
                // Forzar pantalla completa cada vez que se hace visible
                BeginInvoke(new Action(() => SetFullScreenBoundsNative()));
            }
        }

        private void SetFullScreenBoundsNative()
        {
            Rectangle totalBounds;

            if (Screen.AllScreens.Length > 1)
            {
                // Para múltiples pantallas, usar métricas del sistema
                totalBounds = new Rectangle(
                    GetSystemMetrics(SM_XVIRTUALSCREEN),
                    GetSystemMetrics(SM_YVIRTUALSCREEN),
                    GetSystemMetrics(SM_CXVIRTUALSCREEN),
                    GetSystemMetrics(SM_CYVIRTUALSCREEN)
                );
            }
            else
            {
                // Para una pantalla, usar métricas completas del sistema
                totalBounds = new Rectangle(
                    0, 0,
                    GetSystemMetrics(SM_CXSCREEN),
                    GetSystemMetrics(SM_CYSCREEN)
                );
            }

            _lockBounds = totalBounds;

            // Usar SetWindowPos para posicionamiento más preciso
            if (Handle != IntPtr.Zero)
            {
                SetWindowPos(Handle, HWND_TOP,
                    _lockBounds.X, _lockBounds.Y,
                    _lockBounds.Width, _lockBounds.Height,
                    SWP_SHOWWINDOW);
            }

            // Respaldo con métodos tradicionales
            Location = new Point(_lockBounds.X, _lockBounds.Y);
            Size = _lockBounds.Size;

            MinimumSize = _lockBounds.Size;
            MaximumSize = _lockBounds.Size;
        }

        private Rectangle GetVirtualScreenBounds()
        {
            return new Rectangle(
                GetSystemMetrics(SM_XVIRTUALSCREEN),
                GetSystemMetrics(SM_YVIRTUALSCREEN),
                GetSystemMetrics(SM_CXVIRTUALSCREEN),
                GetSystemMetrics(SM_CYVIRTUALSCREEN)
            );
        }

        private void OnLocationOrSizeChanged(object sender, EventArgs e)
        {
            if (_restaurandoPos) return;

            // Verificar si la posición o tamaño cambió
            if (Bounds != _lockBounds)
            {
                _restaurandoPos = true;
                try
                {
                    if (Handle != IntPtr.Zero)
                    {
                        SetWindowPos(Handle, HWND_TOP,
                            _lockBounds.X, _lockBounds.Y,
                            _lockBounds.Width, _lockBounds.Height,
                            SWP_SHOWWINDOW);
                    }
                    SetBounds(_lockBounds.X, _lockBounds.Y, _lockBounds.Width, _lockBounds.Height);
                }
                finally
                {
                    _restaurandoPos = false;
                }
            }
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            // Durante la restauración de posición, usar los valores exactos
            if (_restaurandoPos)
            {
                base.SetBoundsCore(x, y, width, height, specified);
                return;
            }

            // Si ya tenemos _lockBounds definido, SIEMPRE forzar esos valores
            if (_lockBounds != Rectangle.Empty)
            {
                base.SetBoundsCore(_lockBounds.X, _lockBounds.Y, _lockBounds.Width, _lockBounds.Height,
                    BoundsSpecified.All);
            }
            else
            {
                base.SetBoundsCore(x, y, width, height, specified);
            }
        }

        // Override adicional para evitar que Windows modifique el ClientSize
        protected override void SetClientSizeCore(int x, int y)
        {
            if (_lockBounds != Rectangle.Empty)
            {
                // Mantener el tamaño total del form, no solo el área cliente
                base.SetBoundsCore(_lockBounds.X, _lockBounds.Y, _lockBounds.Width, _lockBounds.Height,
                    BoundsSpecified.All);
            }
            else
            {
                base.SetClientSizeCore(x, y);
            }
        }

        protected override void WndProc(ref Message m)
        {
            if ((m.Msg == WM_NCLBUTTONDOWN || m.Msg == WM_NCLBUTTONDBLCLK) && (int)m.WParam == HTCAPTION)
                return;

            if (m.Msg == WM_SYSCOMMAND)
            {
                int cmd = m.WParam.ToInt32() & 0xFFF0;
                if (cmd == SC_MOVE || cmd == SC_KEYMENU)
                    return;
            }

            if (m.Msg == WM_NCHITTEST)
            {
                base.WndProc(ref m);
                if (m.Result == (IntPtr)HTCAPTION)
                    m.Result = (IntPtr)1; // HTCLIENT
                return;
            }

            base.WndProc(ref m);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Alt+F4 -> cierre controlado
            if (keyData == (Keys.Alt | Keys.F4))
            {
                RequestExit();
                return true;
            }

            // Bloquear solo Alt+Space (menú del sistema)
            if (keyData == (Keys.Alt | Keys.Space))
                return true;

            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Permitir cierre si ya pedimos salir o si el sistema se apaga
            if (_permitirCerrar || e.CloseReason == CloseReason.WindowsShutDown)
            {
                try { TaskbarHelper.ShowTaskbar(); } catch { }
                base.OnFormClosing(e);
                return;
            }

            // Si llega aquí y fue un cierre de usuario (incluye Alt+F4 no interceptado),
            // dispara nuestro cierre controlado.
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                RequestExit();
                return;
            }

            // Para cualquier otro caso, cancela
            e.Cancel = true;
        }

        // === API pública ===

        /// <summary>
        /// Configura un tap secreto en un control para cerrar la app.
        /// </summary>
        public void SetSecretExit(Control triggerControl, int taps = 7, TimeSpan? window = null)
        {
            _tapGoal = Math.Max(1, taps);
            _tapWindow = window ?? TimeSpan.FromSeconds(5);

            triggerControl.Click -= OnSecretClick;
            triggerControl.Click += OnSecretClick;
        }

        private void OnSecretClick(object? sender, EventArgs e)
        {
            var now = DateTime.Now;
            if (now - _lastTap > _tapWindow)
                _tapCount = 0;

            _tapCount++;
            _lastTap = now;

            if (_tapCount >= _tapGoal)
                RequestExit();
        }

        /// <summary>
        /// Solicita salir realmente de la app (restaura barra de tareas).
        /// </summary>
        public void RequestExit()
        {
            try { TaskbarHelper.ShowTaskbar(); } catch { }
            _permitirCerrar = true;

            try
            {
                foreach (Form f in Application.OpenForms.Cast<Form>().ToList())
                {
                    if (!f.IsDisposed) f.Close();
                }
            }
            catch { /* no-op */ }

            try { Application.ExitThread(); } catch { /* no-op */ }
            try { Application.Exit(); } catch { /* no-op */ }
            try { Environment.Exit(0); } catch { /* no-op */ }
        }

        /// <summary>
        /// Muestra un hijo como MODAL, centrado sobre este KioskForm y siempre encima.
        /// El form padre se mantiene abierto debajo.
        /// </summary>
        public DialogResult ShowModal(Form child)
        {
            if (child == null || child.IsDisposed) return DialogResult.None;

            // Config visual típica de un diálogo
            child.StartPosition = FormStartPosition.CenterParent;
            child.ShowIcon = false;
            child.ShowInTaskbar = false;
            child.MinimizeBox = false;
            child.MaximizeBox = false;
            if (child.FormBorderStyle == FormBorderStyle.None)
                child.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Asegurar que el hijo también sea TopMost
            child.TopMost = true;

            try
            {
                // Mostrar como modal con este form como propietario
                // Esto mantiene el form padre abierto debajo
                return child.ShowDialog(this);
            }
            finally
            {
                // Después de cerrar el diálogo, asegurar que este form mantenga el foco
                this.Focus();
                this.BringToFront();
                // Re-forzar pantalla completa por si algo cambió
                SetFullScreenBoundsNative();
            }
        }

        /// <summary>
        /// Muestra un form hijo de manera no modal, permitiendo interacción con ambos forms.
        /// Útil para formularios que necesitan mantenerse abiertos simultáneamente.
        /// </summary>
        public void ShowNonModal(Form child)
        {
            if (child == null || child.IsDisposed) return;

            // Configurar como ventana hija
            child.ShowIcon = false;
            child.ShowInTaskbar = false;
            child.TopMost = true;

            // Si no tiene posición específica, centrar sobre el padre
            if (child.StartPosition == FormStartPosition.WindowsDefaultLocation)
            {
                child.StartPosition = FormStartPosition.CenterParent;
            }

            // Mostrar sin bloquear el form padre
            child.Show(this);
            child.BringToFront();
        }

        /// <summary>
        /// Fuerza que este KioskForm vuelva al frente y ocupe toda la pantalla.
        /// Útil después de mostrar otros forms.
        /// </summary>
        public void BringKioskToFront()
        {
            this.TopMost = false;  // Temporal para poder usar BringToFront
            this.BringToFront();
            this.Focus();
            this.TopMost = true;   // Restaurar TopMost

            // Re-establecer pantalla completa
            SetFullScreenBoundsNative();
        }

        /// <summary>
        /// Método público para forzar pantalla completa (útil si hay problemas de visualización)
        /// </summary>
        public void ForceFullScreen()
        {
            SetFullScreenBoundsNative();
        }

        /// <summary>
        /// MessageBox "propiedad" del KioskForm para que siempre salga arriba y centrado.
        /// </summary>
        public DialogResult ShowInfo(string text, string caption = "Información")
        {
            var result = MessageBox.Show(this, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            SetFullScreenBoundsNative(); // Re-forzar después del MessageBox
            return result;
        }

        public DialogResult ShowWarn(string text, string caption = "Atención")
        {
            var result = MessageBox.Show(this, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            SetFullScreenBoundsNative();
            return result;
        }

        public DialogResult ShowError(string text, string caption = "Error")
        {
            var result = MessageBox.Show(this, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            SetFullScreenBoundsNative();
            return result;
        }

        public DialogResult ShowConfirm(string text, string caption = "Confirmar")
        {
            var result = MessageBox.Show(this, text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            SetFullScreenBoundsNative();
            return result;
        }
    }

    public static class TaskbarHelper
    {
        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;
        private const int SW_MINIMIZE = 6;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        private static extern bool EnableWindow(IntPtr hWnd, bool bEnable);

        private static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_NOACTIVATE = 0x0010;
        private const uint SWP_HIDEWINDOW = 0x0080;

        public static void HideTaskbar()
        {
            // Ocultar barra de tareas principal de manera más agresiva
            var taskbar = FindWindow("Shell_TrayWnd", null);
            if (taskbar != IntPtr.Zero)
            {
                ShowWindow(taskbar, SW_HIDE);
                // Mover al fondo y deshabilitar
                SetWindowPos(taskbar, HWND_BOTTOM, -32000, -32000, 1, 1,
                    SWP_HIDEWINDOW | SWP_NOACTIVATE);
                EnableWindow(taskbar, false);
            }

            // Ocultar barras secundarias (multi-monitor)
            IntPtr secTaskbar = IntPtr.Zero;
            int index = 0;
            do
            {
                secTaskbar = FindWindow("Shell_SecondaryTrayWnd", null);
                if (secTaskbar != IntPtr.Zero)
                {
                    ShowWindow(secTaskbar, SW_HIDE);
                    SetWindowPos(secTaskbar, HWND_BOTTOM, -32000, -32000, 1, 1,
                        SWP_HIDEWINDOW | SWP_NOACTIVATE);
                    EnableWindow(secTaskbar, false);
                }
                index++;
            } while (secTaskbar != IntPtr.Zero && index < 10); // Máximo 10 monitores

            // Ocultar botón de inicio
            var start = FindWindow("Button", "Start");
            if (start != IntPtr.Zero)
            {
                ShowWindow(start, SW_HIDE);
                EnableWindow(start, false);
            }

            // Ocultar otros elementos de la barra
            var trayNotify = FindWindow("TrayNotifyWnd", null);
            if (trayNotify != IntPtr.Zero)
            {
                ShowWindow(trayNotify, SW_HIDE);
            }

            var clockWnd = FindWindow("TrayClockWClass", null);
            if (clockWnd != IntPtr.Zero)
            {
                ShowWindow(clockWnd, SW_HIDE);
            }

            // Ocultar área de notificación
            var notifyArea = FindWindow("NotifyIconOverflowWindow", null);
            if (notifyArea != IntPtr.Zero)
            {
                ShowWindow(notifyArea, SW_HIDE);
            }
        }

        public static void ShowTaskbar()
        {
            var taskbar = FindWindow("Shell_TrayWnd", null);
            if (taskbar != IntPtr.Zero)
            {
                EnableWindow(taskbar, true);
                ShowWindow(taskbar, SW_SHOW);
            }

            var secTaskbar = FindWindow("Shell_SecondaryTrayWnd", null);
            if (secTaskbar != IntPtr.Zero)
            {
                EnableWindow(secTaskbar, true);
                ShowWindow(secTaskbar, SW_SHOW);
            }

            var start = FindWindow("Button", "Start");
            if (start != IntPtr.Zero)
            {
                EnableWindow(start, true);
                ShowWindow(start, SW_SHOW);
            }

            var trayNotify = FindWindow("TrayNotifyWnd", null);
            if (trayNotify != IntPtr.Zero) ShowWindow(trayNotify, SW_SHOW);

            var clockWnd = FindWindow("TrayClockWClass", null);
            if (clockWnd != IntPtr.Zero) ShowWindow(clockWnd, SW_SHOW);

            var notifyArea = FindWindow("NotifyIconOverflowWindow", null);
            if (notifyArea != IntPtr.Zero) ShowWindow(notifyArea, SW_SHOW);
        }
    }
}
