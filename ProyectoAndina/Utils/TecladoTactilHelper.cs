using System;
using System.Drawing;
using System.Windows.Forms;
using Krypton.Toolkit; // ⚡ importante

public static class KryptonTecladoNumericoHelper
{
    private static Panel teclado;
    private static Form formPadre;

    public static void ConfigurarFormularioConTeclado(Form form)
    {
        formPadre = form;

        teclado = new Panel
        {
            Dock = DockStyle.Bottom,
            Height = 260,
            BackColor = Color.FromArgb(240, 240, 240),
            Visible = false
        };

        string[] teclas = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "←", "OK" };
        int col = 3, ancho = 80, alto = 70, margen = 10;

        for (int i = 0; i < teclas.Length; i++)
        {
            var boton = new KryptonButton
            {
                Text = teclas[i],
                Width = ancho,
                Height = alto,
                Location = new Point(
                    margen + (i % col) * (ancho + margen),
                    margen + (i / col) * (alto + margen)
                ),
                OverrideDefault = { Back = { Color1 = Color.Teal, Color2 = Color.DarkCyan } },
                StateCommon =
                {
                    Content = { ShortText = { Color1 = Color.White, Font = new Font("Segoe UI", 16, FontStyle.Bold) } },
                    Back = { Color1 = Color.Teal, Color2 = Color.DarkCyan }
                }
            };

            boton.Click += Boton_Click;
            teclado.Controls.Add(boton);
        }

        form.Controls.Add(teclado);
    }

    private static void Boton_Click(object sender, EventArgs e)
    {
        if (formPadre?.ActiveControl is TextBox txt && sender is KryptonButton b)
        {
            if (b.Text == "←" && txt.Text.Length > 0)
                txt.Text = txt.Text.Substring(0, txt.Text.Length - 1);
            else if (b.Text == "OK")
                teclado.Visible = false;
            else if (char.IsDigit(b.Text[0]))
                txt.AppendText(b.Text);
        }
    }

    public static void MostrarTeclado() => teclado.Visible = true;
    public static void OcultarTeclado() => teclado.Visible = false;
}