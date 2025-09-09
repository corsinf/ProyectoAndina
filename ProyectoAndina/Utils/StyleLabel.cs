using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAndina.Utils
{
    public static class StyleLabel
    {
        public static class Colors
        {
            public static readonly Color VerdeUASB = Color.FromArgb(0, 71, 80);        // #004750
            public static readonly Color AmarilloUASB = Color.FromArgb(235, 179, 0);   // #EBB300
            public static readonly Color NegroUASB = Color.FromArgb(33, 39, 33);       // #212721
            public static readonly Color VerdeMedioUASB = Color.FromArgb(0, 110, 99);  // #006e63
            public static readonly Color VerdeClaroUASB = Color.FromArgb(0, 148, 144); // #009490

            // Colores complementarios
            public static readonly Color Blanco = Color.White;
            public static readonly Color GrisClaro = Color.FromArgb(248, 249, 250);
            public static readonly Color GrisMedio = Color.FromArgb(206, 212, 218);
            public static readonly Color GrisOscuro = Color.FromArgb(108, 117, 125);

            // Estados para botones
            public static readonly Color VerdeHover = Color.FromArgb(0, 91, 100);
            public static readonly Color VerdePressed = Color.FromArgb(0, 51, 60);
            public static readonly Color Error = Color.FromArgb(220, 53, 69);
            public static readonly Color Success = Color.FromArgb(40, 167, 69);
        }

        // Fuentes según el manual (aproximadas)
        public static class Fonts
        {
            public static readonly Font TituloGrande = new Font("Segoe UI", 28F, FontStyle.Bold);
            public static readonly Font TituloMedio = new Font("Segoe UI", 20F, FontStyle.Bold);
            public static readonly Font TituloPequeno = new Font("Segoe UI", 16F, FontStyle.Bold);
            public static readonly Font Subtitulo = new Font("Segoe UI", 14F, FontStyle.Regular);
            public static readonly Font Cuerpo = new Font("Segoe UI", 12F, FontStyle.Regular);
            public static readonly Font CuerpoSmall = new Font("Segoe UI", 10F, FontStyle.Regular);
            public static readonly Font Boton = new Font("Segoe UI", 12F, FontStyle.Regular);
        }
        public static void ConfigurarLabel(Label label, TipoLabel tipo = TipoLabel.Cuerpo)
        {
            label.BackColor = Color.Transparent;
            label.ForeColor = Colors.NegroUASB;

            switch (tipo)
            {
                case TipoLabel.TituloGrande:
                    label.Font = Fonts.TituloGrande;
                    label.ForeColor = Colors.VerdeUASB;
                    break;
                case TipoLabel.TituloMedio:
                    label.Font = Fonts.TituloMedio;
                    label.ForeColor = Colors.VerdeUASB;
                    break;
                case TipoLabel.TituloPequeno:
                    label.Font = Fonts.TituloPequeno;
                    label.ForeColor = Colors.VerdeUASB;
                    break;
                case TipoLabel.Subtitulo:
                    label.Font = Fonts.Subtitulo;
                    break;
                case TipoLabel.Cuerpo:
                    label.Font = Fonts.Cuerpo;
                    break;
                case TipoLabel.CuerpoSmall:
                    label.Font = Fonts.CuerpoSmall;
                    label.ForeColor = Colors.GrisOscuro;
                    break;
            }
        }

        public static void ConfigurarLabelConIcono(
    Label label,
    string texto,
    TipoLabel tipo = TipoLabel.Cuerpo,
    bool bold = false,
    FontAwesome.Sharp.IconChar? icono = null)
        {
            // Aplicar estilo base
            ConfigurarLabel(label, tipo);

            // Aplicar bold solo si se pide
            if (bold)
                label.Font = new Font(label.Font, FontStyle.Bold);

            // Si viene un ícono lo agregamos al inicio
            if (icono.HasValue)
            {
                var iconChar = char.ConvertFromUtf32((int)icono.Value);
                label.Text = $"{iconChar}  {texto}";
            }
            else
            {
                label.Text = texto;
            }
        }


    }
}
