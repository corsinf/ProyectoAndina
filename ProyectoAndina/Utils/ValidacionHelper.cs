using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using ProyectoAndina.Utils; // Asegúrate de que este sea el namespace correcto

public class ValidacionHelper
{
    private ErrorProvider errorProvider;
    private Form formulario;
    private Dictionary<Control, string> controlesRequeridos;

    public ValidacionHelper(Form form)
    {
        formulario = form;
        errorProvider = new ErrorProvider();
        errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        errorProvider.Icon = SystemIcons.Warning;
        controlesRequeridos = new Dictionary<Control, string>();
    }

    // Método para agregar controles que requieren validación
    public void AgregarControlRequerido(Control control, string mensajeError)
    {
        if (!controlesRequeridos.ContainsKey(control))
        {
            controlesRequeridos.Add(control, mensajeError);

            // Agregar eventos para validación en tiempo real
            if (control is TextBox txt)
            {
                txt.Leave += ValidarControl;
                txt.TextChanged += LimpiarErrorSiTieneTexto;
            }
            else if (control is ComboBox cmb)
            {
                cmb.Leave += ValidarControl;
                cmb.SelectedIndexChanged += LimpiarErrorSiTieneSeleccion;
            }
        }
    }

    // Validar un control específico
    private void ValidarControl(object sender, EventArgs e)
    {
        Control control = sender as Control;
        if (controlesRequeridos.ContainsKey(control))
        {
            if (EstaVacio(control))
            {
                MostrarError(control, controlesRequeridos[control]);
            }
            else
            {
                LimpiarError(control);
            }
        }
    }

    // Limpiar error cuando el usuario empieza a escribir
    private void LimpiarErrorSiTieneTexto(object sender, EventArgs e)
    {
        TextBox txt = sender as TextBox;
        if (!string.IsNullOrWhiteSpace(txt.Text))
        {
            LimpiarError(txt);
        }
    }

    private void LimpiarErrorSiTieneSeleccion(object sender, EventArgs e)
    {
        ComboBox cmb = sender as ComboBox;
        if (cmb.SelectedIndex >= 0)
        {
            LimpiarError(cmb);
        }
    }

    // Validar todos los controles requeridos
    public bool ValidarTodosLosControles()
    {
        bool todosValidos = true;

        foreach (var kvp in controlesRequeridos)
        {
            Control control = kvp.Key;
            string mensaje = kvp.Value;

            if (EstaVacio(control))
            {
                MostrarError(control, mensaje);
                todosValidos = false;
            }
            else
            {
                LimpiarError(control);
            }
        }

        return todosValidos;
    }

    // Mostrar mensaje de validación usando StylesAlertas
    public void MostrarMensajeValidacion()
    {
        var controlesConError = controlesRequeridos.Keys.Where(c => EstaVacio(c)).ToList();

        if (controlesConError.Any())
        {
            string mensaje = "Complete los siguientes campos:\n\n";
            foreach (var control in controlesConError)
            {
                string nombreControl = ObtenerNombreAmigable(control);
                mensaje += $"• {nombreControl}\n";
            }

            // Usar tu StylesAlertas personalizado
            StylesAlertas.MostrarAlerta(
                formulario,
                mensaje,
                "Campos Requeridos",
                StylesAlertas.TipoAlerta.Error,
                4000
            );

            // Enfocar el primer control con error
            controlesConError.First().Focus();
        }
    }

    // Métodos adicionales para usar tus alertas en todo el proyecto
    public void MostrarMensajeExito(string mensaje, string titulo = "¡Éxito!")
    {
        StylesAlertas.MostrarExito(formulario, mensaje, titulo);
    }

    public void MostrarMensajeInfo(string mensaje, string titulo = "Información")
    {
        StylesAlertas.MostrarAlerta(formulario, mensaje, titulo, StylesAlertas.TipoAlerta.Info, 3000);
    }

    public void MostrarMensajeError(string mensaje, string titulo = "Error")
    {
        StylesAlertas.MostrarAlerta(formulario, mensaje, titulo, StylesAlertas.TipoAlerta.Error, 4000);
    }

    public DialogResult MostrarConfirmacion(string mensaje, string titulo = "Confirmar")
    {
        return StylesAlertas.MostrarConfirmacion(formulario, mensaje, titulo, StylesAlertas.TipoAlerta.Info);
    }

    public DialogResult MostrarConfirmacionAdvertencia(string mensaje, string titulo = "Advertencia")
    {
        return StylesAlertas.MostrarConfirmacion(formulario, mensaje, titulo, StylesAlertas.TipoAlerta.Error);
    }

    private bool EstaVacio(Control control)
    {
        if (control is TextBox txt)
            return string.IsNullOrWhiteSpace(txt.Text);

        if (control is ComboBox cmb)
            return cmb.SelectedIndex < 0;

        return false;
    }

    private void MostrarError(Control control, string mensaje)
    {
        errorProvider.SetError(control, mensaje);
        control.BackColor = Color.FromArgb(255, 245, 245); // Fondo rojizo suave
    }

    private void LimpiarError(Control control)
    {
        errorProvider.SetError(control, "");
        control.BackColor = SystemColors.Window; // Color original
    }

    private string ObtenerNombreAmigable(Control control)
    {
        // 1️⃣ Si el control tiene Tag, usarlo
        if (control.Tag != null && !string.IsNullOrWhiteSpace(control.Tag.ToString()))
            return control.Tag.ToString();

        // 2️⃣ Buscar un Label en el mismo contenedor (Parent) 
        //     cuyo TabIndex sea inmediatamente anterior al del control
        if (control.Parent != null)
        {
            foreach (Control c in control.Parent.Controls)
            {
                if (c is Label lbl)
                {
                    // Si el Label está "antes" que el TextBox en el orden de tabulación
                    if (lbl.TabIndex == control.TabIndex - 1)
                    {
                        // Quita los ":" al final si los tiene
                        return lbl.Text.Replace(":", "").Trim();
                    }
                }
            }
        }

        // 3️⃣ Como fallback, limpiar el Name del control
        string nombre = control.Name;
        nombre = nombre
            .Replace("textBox_", "")
            .Replace("comboBox_", "")
            .Replace("checkBox_", "")
            .Replace("radioButton_", "")
            .Replace("dateTimePicker_", "")
            .Replace("_", " ");
        return char.ToUpper(nombre[0]) + nombre.Substring(1);
    }

    public void LimpiarTodosLosErrores()
    {
        foreach (var control in controlesRequeridos.Keys)
        {
            LimpiarError(control);
        }
    }

    // Liberar recursos
    public void Dispose()
    {
        errorProvider?.Dispose();
    }
}

// ======================== CLASE ESTÁTICA PARA USO GLOBAL ========================
public static class ValidacionGlobal
{
    // Validación rápida para cualquier form sin instanciar ValidacionHelper
    public static bool ValidarCamposRequeridos(Form owner, params (Control control, string nombre)[] campos)
    {
        var camposVacios = new List<string>();

        foreach (var (control, nombre) in campos)
        {
            bool estaVacio = false;

            if (control is TextBox txt && string.IsNullOrWhiteSpace(txt.Text))
                estaVacio = true;
            else if (control is ComboBox cmb && cmb.SelectedIndex < 0)
                estaVacio = true;

            if (estaVacio)
            {
                camposVacios.Add(nombre);
                control.BackColor = Color.FromArgb(255, 245, 245);
            }
            else
            {
                control.BackColor = SystemColors.Window;
            }
        }

        if (camposVacios.Any())
        {
            string mensaje = "Complete los siguientes campos:\n\n";
            camposVacios.ForEach(campo => mensaje += $"• {campo}\n");

            StylesAlertas.MostrarAlerta(owner, mensaje, "Campos Requeridos",
                StylesAlertas.TipoAlerta.Error, 4000);

            // Enfocar el primer campo vacío
            campos.First(c => camposVacios.Contains(c.nombre)).control.Focus();
            return false;
        }

        return true;
    }

    // Métodos estáticos para usar en cualquier parte del proyecto
    public static void MostrarExito(Form owner, string mensaje, string titulo = "¡Éxito!")
    {
        StylesAlertas.MostrarExito(owner, mensaje, titulo);
    }

    public static void MostrarInfo(Form owner, string mensaje, string titulo = "Información")
    {
        StylesAlertas.MostrarAlerta(owner, mensaje, titulo, StylesAlertas.TipoAlerta.Info, 3000);
    }

    public static void MostrarError(Form owner, string mensaje, string titulo = "Error")
    {
        StylesAlertas.MostrarAlerta(owner, mensaje, titulo, StylesAlertas.TipoAlerta.Error, 4000);
    }

    public static DialogResult MostrarConfirmacion(Form owner, string mensaje, string titulo = "Confirmar")
    {
        return StylesAlertas.MostrarConfirmacion(owner, mensaje, titulo, StylesAlertas.TipoAlerta.Info);
    }
}