using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProyectoAndina.Utils
{
    public class KioskForm : Form
    {
        // Win32
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int WM_NCLBUTTONDBLCLK = 0xA3;
        private const int WM_SYSCOMMAND = 0x0112;
        private const int WM_NCHITTEST = 0x0084;
        private const int SC_MOVE = 0xF010;
        private const int SC_KEYMENU = 0xF100;
        private const int HTCAPTION = 0x02;

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
            FormBorderStyle = FormBorderStyle.None;
            ControlBox = false;
            ShowIcon = false;
            ShowInTaskbar = false;
            TopMost = true;
            KeyPreview = true;
            WindowState = FormWindowState.Maximized;
            StartPosition = FormStartPosition.Manual;

            if (hideTaskbar)
                TaskbarHelper.HideTaskbar();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Bounds = Screen.AllScreens.Length > 1
                ? Screen.AllScreens.Select(s => s.Bounds).Aggregate(Rectangle.Union)
                : Screen.PrimaryScreen.Bounds;

            _lockBounds = Bounds;
            MinimumSize = Size;
            MaximumSize = Size;

            LocationChanged += (s, a) =>
            {
                if (_restaurandoPos) return;
                if (Bounds.Location != _lockBounds.Location)
                {
                    _restaurandoPos = true;
                    try { Bounds = _lockBounds; }
                    finally { _restaurandoPos = false; }
                }
            };

            SizeChanged += (s, a) =>
            {
                if (_restaurandoPos) return;
                if (Size != _lockBounds.Size)
                {
                    _restaurandoPos = true;
                    try { Size = _lockBounds.Size; Bounds = _lockBounds; }
                    finally { _restaurandoPos = false; }
                }
            };
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

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == (Keys.Alt | Keys.F4) || keyData == (Keys.Alt | Keys.Space))
        //        return true;
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Alt+F4 -> cierre controlado
            if (keyData == (Keys.Alt | Keys.F4))
            {
                RequestExit();   // <- asegura _permitirCerrar = true y cierra todo
                return true;     // consumimos la tecla
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
                e.Cancel = true;   // cancelamos este intento
                RequestExit();     // hacemos el cierre real
                return;
            }

            // Para cualquier otro caso, cancela
            e.Cancel = true;
        }

        // === API pública ===

        /// Configura un tap secreto en un control para cerrar la app.
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

        /// Solicita salir realmente de la app (restaura barra de tareas).
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

        /// Muestra un hijo como MODAL, centrado sobre este KioskForm y siempre encima.
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

            // Trucos para asegurar que quede arriba
            bool originalTopMost = this.TopMost;
            try
            {
                // Si tu ventana padre es TopMost, fuerza también el hijo
                child.TopMost = true;

                // MUY IMPORTANTE: pasar "this" como owner asegura que el hijo
                // se mantenga sobre el padre y con foco.
                return child.ShowDialog(this);
            }
            finally
            {
                // Restaurar TopMost del padre (por si lo cambiaste en el futuro)
                this.TopMost = originalTopMost;
            }
        }

        /// MessageBox “propiedad” del KioskForm para que siempre salga arriba y centrado.
        public DialogResult ShowInfo(string text, string caption = "Información")
            => MessageBox.Show(this, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

        public DialogResult ShowWarn(string text, string caption = "Atención")
            => MessageBox.Show(this, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);

        public DialogResult ShowError(string text, string caption = "Error")
            => MessageBox.Show(this, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);

        public DialogResult ShowConfirm(string text, string caption = "Confirmar")
            => MessageBox.Show(this, text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }

    public static class TaskbarHelper
    {
        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static void HideTaskbar()
        {
            var taskbar = FindWindow("Shell_TrayWnd", null);
            if (taskbar != IntPtr.Zero) ShowWindow(taskbar, SW_HIDE);

            var secTaskbar = FindWindow("Shell_SecondaryTrayWnd", null);
            if (secTaskbar != IntPtr.Zero) ShowWindow(secTaskbar, SW_HIDE);

            var start = FindWindow("Button", null);
            if (start != IntPtr.Zero) ShowWindow(start, SW_HIDE);
        }

        public static void ShowTaskbar()
        {
            var taskbar = FindWindow("Shell_TrayWnd", null);
            if (taskbar != IntPtr.Zero) ShowWindow(taskbar, SW_SHOW);

            var secTaskbar = FindWindow("Shell_SecondaryTrayWnd", null);
            if (secTaskbar != IntPtr.Zero) ShowWindow(secTaskbar, SW_SHOW);

            var start = FindWindow("Button", null);
            if (start != IntPtr.Zero) ShowWindow(start, SW_SHOW);
        }
    }
}
