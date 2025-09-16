using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAndina.Helper
{
    internal class FuncionesGenerales
    {

        public void SoloNumerosDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;

            // Permitir teclas de control (backspace, delete, etc.)
            if (char.IsControl(e.KeyChar))
                return;

            // Permitir dígitos
            if (char.IsDigit(e.KeyChar))
            {
                // Si ya hay punto, limitar a 2 decimales
                int index = tb.Text.IndexOf('.');
                if (index >= 0 && tb.SelectionStart > index)
                {
                    string decimalPart = tb.Text.Substring(index + 1);
                    // Si ya hay 2 decimales y no se está seleccionando, bloquear
                    if (decimalPart.Length >= 2 && tb.SelectionLength == 0)
                    {
                        e.Handled = true;
                        return;
                    }
                }
                return;
            }

            // Permitir un solo punto decimal
            if (e.KeyChar == '.' && !tb.Text.Contains("."))
                return;

            // Bloquear cualquier otro caracter
            e.Handled = true;
        }

        public void LimpiarCampos(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = string.Empty;
                }
                else if (control.HasChildren)
                {
                    // Llamada recursiva para limpiar los controles hijos (por ejemplo, dentro de un Panel o GroupBox)
                    LimpiarCampos(control);
                }
            }
        }

        public decimal ParseDecimalFromTextBox(string texto)
        {
            // Quitar espacios y símbolos de moneda
            texto = texto.Trim().Replace("$", "").Replace(" ", "");

            // Reemplazar coma por punto para CultureInfo.InvariantCulture
            texto = texto.Replace(",", ".");

            // Intentar parsear
            if (decimal.TryParse(texto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
            {
                return valor;
            }

            // Si falla, retorna 0
            return 0m;
        }

        public  decimal ParseDecimalFromTextBoxNormalizado(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0m;

            // 1. Limpiar espacios y caracteres no permitidos (solo dígitos, . o ,)
            string limpio = Regex.Replace(input.Trim(), @"[^0-9\.,]", "");

            if (string.IsNullOrWhiteSpace(limpio))
                throw new FormatException("El valor ingresado no contiene números válidos.");

            // 2. Normalizar: cambiar coma por punto
            limpio = limpio.Replace(",", ".");

            // 3. Validar formato decimal correcto (máx 1 punto decimal)
            if (Regex.Matches(limpio, @"\.").Count > 1)
                throw new FormatException("Formato decimal inválido. Solo un separador decimal permitido.");

            // 4. Intentar parsear con cultura invariante
            if (decimal.TryParse(limpio, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal valor))
            {
                return valor;
            }

            throw new FormatException("No se pudo convertir el valor a número válido.");
        }

    }
}
