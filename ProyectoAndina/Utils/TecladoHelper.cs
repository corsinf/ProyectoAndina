using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

public static class TecladoHelper
{


    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    private const int SW_SHOW = 5;

    public static void MostrarTeclado()
    {
        // Guardar ventana activa
        IntPtr ventanaActiva = GetForegroundWindow();

        try
        {
            IntentarTabTip(ventanaActiva);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al mostrar teclado: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private static bool IntentarTabTip(IntPtr ventanaActiva)
    {
        try
        {
            string[] rutasTabTip = {
            @"C:\Program Files\Common Files\Microsoft Shared\ink\TabTip.exe",
            @"C:\Program Files (x86)\Common Files\Microsoft Shared\ink\TabTip.exe",
            @"C:\Windows\System32\TabTip.exe"
        };

            foreach (string ruta in rutasTabTip)
            {
                if (File.Exists(ruta))
                {
                    // Cerrar procesos TabTip existentes
                    var procesos = Process.GetProcessesByName("TabTip");
                    foreach (var p in procesos)
                    {
                        try { p.Kill(); } catch { }
                    }

                    Thread.Sleep(200);

                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = ruta,
                        UseShellExecute = true
                    };
                    Process.Start(startInfo);

                    return true;
                }
            }
        }
        catch
        {
            return false;
        }
        return false;
    }

    public static void CerrarTeclado()
    {
        try
        {
            // Cerrar TabTip
            var procesosTabTip = Process.GetProcessesByName("TabTip");
            foreach (var p in procesosTabTip)
            {
                try { p.Kill(); } catch { }
            }
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
            var tabTip = Process.GetProcessesByName("TabTip");
            return tabTip.Length > 0;
        }
        catch
        {
            return false;
        }
    }


}
