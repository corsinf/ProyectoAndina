public class ReciboModel
{
    // Empresa (por defecto)
    public string RazonSocial { get; set; } = "UNIVERSIDAD ANDINA SIMON BOLIVAR";
    public string RUC { get; set; } = "RUC 1791233417001";
    public string Telefono { get; set; } = "+593 86 307 2166";
    public string Direccion { get; set; } = "Toledo,Quito 170143,Ecuador";
    public string Ciudad { get; set; } = "Quito - Ecuador";

    // Factura / Documento
    public string Documento { get; set; }   // Ej: "Factura", "Ticket", etc.
    public string Secuencial { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now.Date;
    public DateTime Hora { get; set; } = DateTime.Now;

    // Caja y cajero
    public string Caja { get; set; }
    public string Cajero { get; set; }

    // Cliente
    public string Cliente { get; set; }
    public string CI_RUC { get; set; }
    public string TelefonoCliente { get; set; }
    public string Email { get; set; }
    public string DireccionCliente { get; set; }

    // Parqueo (entrada/salida)
    public DateTime? FechaEntrada { get; set; }
    public DateTime? FechaSalida { get; set; }
    public string TiempoConsumido { get; set; }

    // Valores
    public decimal Neto { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Descuento { get; set; }
    public decimal IVA15 { get; set; }
    public decimal IVA0 { get; set; }
    public decimal Total { get; set; }
    public decimal BaseConsumoTarifa0 { get; set; }

    // Sistema de pago
    public string SistemaPago { get; set; }
}
