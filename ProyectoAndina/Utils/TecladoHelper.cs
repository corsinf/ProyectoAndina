using System;
using System.Diagnostics;
<<<<<<< HEAD
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

public static class TecladoHelper
{


=======
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

public static class TecladoHelper
{
>>>>>>> 1fbbfaa8fccc06aecd2a96cd1ee224c331cfbff2
    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    private const int SW_SHOW = 5;

<<<<<<< HEAD
    public static void MostrarTeclado()
    {
        // Guardar ventana activa
=======
    // --- Constantes para detectar pantalla táctil ---
    private const int SM_DIGITIZER = 94;
    private const int NID_INTEGRATED_TOUCH = 0x01;
    private const int NID_EXTERNAL_TOUCH = 0x02;

    [DllImport("user32.dll")]
    private static extern int GetSystemMetrics(int nIndex);

    private static bool EsPantallaTactil()
    {
        int digitizerStatus = GetSystemMetrics(SM_DIGITIZER);
        bool tieneTouchIntegrado = (digitizerStatus & NID_INTEGRATED_TOUCH) == NID_INTEGRATED_TOUCH;
        bool tieneTouchExterno = (digitizerStatus & NID_EXTERNAL_TOUCH) == NID_EXTERNAL_TOUCH;
        return tieneTouchIntegrado || tieneTouchExterno;
    }

    public static void MostrarTeclado()
    {
        // Solo mostrar teclado si hay pantalla táctil
        if (!EsPantallaTactil())
            return;

>>>>>>> 1fbbfaa8fccc06aecd2a96cd1ee224c331cfbff2
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
<<<<<<< HEAD
            @"C:\Program Files\Common Files\Microsoft Shared\ink\TabTip.exe",
            @"C:\Program Files (x86)\Common Files\Microsoft Shared\ink\TabTip.exe",
            @"C:\Windows\System32\TabTip.exe"
        };
=======
                @"C:\Program Files\Common Files\Microsoft Shared\ink\TabTip.exe",
                @"C:\Program Files (x86)\Common Files\Microsoft Shared\ink\TabTip.exe",
                @"C:\Windows\System32\TabTip.exe"
            };
>>>>>>> 1fbbfaa8fccc06aecd2a96cd1ee224c331cfbff2

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
<<<<<<< HEAD
            // Cerrar TabTip
=======
>>>>>>> 1fbbfaa8fccc06aecd2a96cd1ee224c331cfbff2
            var procesosTabTip = Process.GetProcessesByName("TabTip");
            foreach (var p in procesosTabTip)
            {
                try { p.Kill(); } catch { }
            }
        }
<<<<<<< HEAD
        catch
        {
            // Ignorar errores
        }
=======
        catch { }
>>>>>>> 1fbbfaa8fccc06aecd2a96cd1ee224c331cfbff2
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
<<<<<<< HEAD


=======
>>>>>>> 1fbbfaa8fccc06aecd2a96cd1ee224c331cfbff2
}
