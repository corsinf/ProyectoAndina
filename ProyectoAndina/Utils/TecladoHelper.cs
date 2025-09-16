using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

public static class TecladoHelper
{
    private const int WM_SYSCOMMAND = 0x0112;
    private const int SC_CLOSE = 0xF060;
    private const int SW_HIDE = 0;
    private const int SW_SHOW = 5;

    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool PostMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    public static void MostrarTeclado()
    {
        try
        {
            if (IntentarTabTip()) return;
            IntentarOSK();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al mostrar teclado: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private static bool IntentarTabTip()
    {
        string[] rutasTabTip =
        {
            @"C:\Program Files\Common Files\Microsoft Shared\ink\TabTip.exe",
            @"C:\Program Files (x86)\Common Files\Microsoft Shared\ink\TabTip.exe",
            @"C:\Windows\System32\TabTip.exe"
        };

        foreach (var ruta in rutasTabTip)
        {
            if (!File.Exists(ruta)) continue;

            // Reiniciar para forzar aparición
            CerrarTeclado(); // por si hay instancias flotantes
            Thread.Sleep(150);

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = ruta,
                    UseShellExecute = true
                });
                return true;
            }
            catch { /* probar siguiente */ }
        }
        return false;
    }

    private static void IntentarOSK()
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "osk.exe",
            UseShellExecute = true
        });
    }

    /// <summary>
    /// Cierra el teclado virtual si está abierto (TabTip/TextInputHost/OSK).
    /// </summary>
    public static void CerrarTeclado()
    {
        try
        {
            // 1) Intento grácil: cerrar la ventana del Touch Keyboard
            //   - Win10/11: clase "IPTip_Main_Window"
            //   - OSK: clase "OSKMainClass"
            IntPtr hTabTip = FindWindow("IPTip_Main_Window", null);
            if (hTabTip != IntPtr.Zero)
            {
                // Primero intenta ocultar
                ShowWindow(hTabTip, SW_HIDE);
                // Luego envía un "close"
                PostMessage(hTabTip, WM_SYSCOMMAND, (IntPtr)SC_CLOSE, IntPtr.Zero);
                Thread.Sleep(150);
            }

            IntPtr hOSK = FindWindow("OSKMainClass", null);
            if (hOSK != IntPtr.Zero)
            {
                ShowWindow(hOSK, SW_HIDE);
                PostMessage(hOSK, WM_SYSCOMMAND, (IntPtr)SC_CLOSE, IntPtr.Zero);
                Thread.Sleep(150);
            }

            // 2) Si sigue vivo, matar procesos relacionados
            CerrarProcesos("TabTip");          // teclado táctil
            CerrarProcesos("TextInputHost");   // host UI Win11
            CerrarProcesos("osk");             // on-screen keyboard
        }
        catch
        {
            // Ignorar errores
        }
    }

    public static bool HayTecladoVirtual()
    {
        try
        {
            return Process.GetProcessesByName("TabTip").Any()
                || Process.GetProcessesByName("TextInputHost").Any()
                || Process.GetProcessesByName("osk").Any()
                || FindWindow("IPTip_Main_Window", null) != IntPtr.Zero
                || FindWindow("OSKMainClass", null) != IntPtr.Zero;
        }
        catch
        {
            return false;
        }
    }

    private static void CerrarProcesos(string processName)
    {
        foreach (var p in Process.GetProcessesByName(processName))
        {
            try
            {
                if (!p.HasExited)
                {
                    p.CloseMainWindow();
                    if (!p.WaitForExit(300))
                    {
                        p.Kill();
                        p.WaitForExit(300);
                    }
                }
            }
            catch { /* sin permisos o zombie */ }
            finally
            {
                try { p.Dispose(); } catch { }
            }
        }
    }
}
