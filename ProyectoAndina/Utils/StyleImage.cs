using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAndina.Utils
{
    public static class StyleImage
    {


        public static void ConfigurarImagenEnPanel(
     Panel contenedor,
     PictureBox pictureBox,
     Image imagen,
     int margenHorizontal = 5,
     int margenVertical = 5)
        {
            if (contenedor == null || pictureBox == null || imagen == null) return;

            // Asegurar que la PictureBox pertenezca al contenedor
            if (!contenedor.Controls.Contains(pictureBox))
            {
                contenedor.Controls.Add(pictureBox);
            }

            // Configuración inicial
            pictureBox.Image = imagen;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Mantiene proporción
            pictureBox.BackColor = Color.Transparent;

            void Ajustar()
            {
                if (contenedor == null || pictureBox == null) return;

                // Espacio disponible dentro del contenedor con márgenes
                int anchoDisponible = Math.Max(20, contenedor.ClientSize.Width - (margenHorizontal * 2));
                int altoDisponible = Math.Max(20, contenedor.ClientSize.Height - (margenVertical * 2));

                // Escalar proporcionalmente
                double relacionImagen = (double)imagen.Width / imagen.Height;
                double relacionContenedor = (double)anchoDisponible / altoDisponible;

                int nuevoAncho, nuevoAlto;

                if (relacionImagen > relacionContenedor)
                {
                    // Imagen más ancha → ajusta al ancho
                    nuevoAncho = anchoDisponible;
                    nuevoAlto = (int)(nuevoAncho / relacionImagen);
                }
                else
                {
                    // Imagen más alta → ajusta al alto
                    nuevoAlto = altoDisponible;
                    nuevoAncho = (int)(nuevoAlto * relacionImagen);
                }

                pictureBox.Size = new Size(nuevoAncho, nuevoAlto);

                // ✅ Centrar dentro del contenedor
                int nuevoX = (contenedor.ClientSize.Width - nuevoAncho) / 2;
                int nuevoY = (contenedor.ClientSize.Height - nuevoAlto) / 2;
                pictureBox.Location = new Point(nuevoX, nuevoY);
            }

            contenedor.HandleCreated += (s, e) => Ajustar();
            contenedor.Resize += (s, e) => Ajustar();
        }

    }
}
