using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAndina.Utils
{
    public class FuncionesJson
    {
        public int CargarCajaDesdeConfig()
        {
            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "appsettings.json");
            var json = File.ReadAllText(rutaArchivo);

            var config = JsonConvert.DeserializeObject<AppConfig>(json)
                         ?? throw new Exception("No se pudo cargar la configuración del JSON");

            return config.SistemConfig.Caja;
        }

        public string GetMacAddress()
        {
            return NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(nic => nic.OperationalStatus == OperationalStatus.Up
                              && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .Select(nic => nic.GetPhysicalAddress().ToString())
                .FirstOrDefault() ?? "No disponible";
        }
    }
}
