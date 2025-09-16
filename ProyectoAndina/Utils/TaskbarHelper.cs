using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAndina.Utils
{
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
            // Taskbar principal
            var taskbar = FindWindow("Shell_TrayWnd", null);
            if (taskbar != IntPtr.Zero) ShowWindow(taskbar, SW_HIDE);

            // Botón Inicio / menús secundarios (multi-monitor)
            var start = FindWindow("Button", null); // puede no existir en todas las versiones
            if (start != IntPtr.Zero) ShowWindow(start, SW_HIDE);

            // Barras secundarias (multi-monitor)
            var secTaskbar = FindWindow("Shell_SecondaryTrayWnd", null);
            if (secTaskbar != IntPtr.Zero) ShowWindow(secTaskbar, SW_HIDE);
        }

        public static void ShowTaskbar()
        {
            var taskbar = FindWindow("Shell_TrayWnd", null);
            if (taskbar != IntPtr.Zero) ShowWindow(taskbar, SW_SHOW);

            var start = FindWindow("Button", null);
            if (start != IntPtr.Zero) ShowWindow(start, SW_SHOW);

            var secTaskbar = FindWindow("Shell_SecondaryTrayWnd", null);
            if (secTaskbar != IntPtr.Zero) ShowWindow(secTaskbar, SW_SHOW);
        }
    }
}
