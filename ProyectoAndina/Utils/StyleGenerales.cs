using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProyectoAndina.Utils
{
    public static class StyleGenerales
    {
        
        public static void PintarFondoDiagonal(Form form, PaintEventArgs e)
        {
            if (form == null || e == null) return;

            if (form == null || e == null) return;

            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                e.Graphics.FillRectangle(brush, form.ClientRectangle);
                
            }
        }
        

    }
}

