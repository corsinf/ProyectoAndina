using Newtonsoft.Json;
using ProyectoAndina.Utils;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAndina.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public ApiService(AppConfig? config = null)
        {
            _httpClient = new HttpClient();

            // Si no se pasa config, lo cargamos desde appsettings.json
            if (config == null)
            {
                config = CargarConfiguracion();
            }

            _baseUrl = $"{config.Url}:{config.Puerto}";
        }


        public static AppConfig CargarConfiguracion()
        {
            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "appsettings.json");
            var json = File.ReadAllText(rutaArchivo);
            return JsonConvert.DeserializeObject<AppConfig>(json)
                   ?? throw new Exception("No se pudo cargar la configuración del JSON");
        }

        // Ejemplo de método GET
        public async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/{endpoint}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json)!;
        }
        private void SetAuthorizationHeader(string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        #region PERSONAS

        // GET todos
        public async Task<string> GetPersonasAsync(string token = null)
        {
            try
            {
                SetAuthorizationHeader(token);
                string url = $"{_baseUrl}/api/personas";
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
            }
            catch (Exception ex)
            {
                return $"Excepción: {ex.Message}";
            }
        }

        // GET por ID
        public async Task<string> GetPersonaPorIdAsync(int id, string token = null)
        {
            try
            {
                SetAuthorizationHeader(token);
                string url = $"{_baseUrl}/api/personas/{id}";
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
            }
            catch (Exception ex)
            {
                return $"Excepción: {ex.Message}";
            }
        }

        // GET por cédula
        public async Task<string> GetPersonaPorCedulaAsync(string cedula, string token = null)
        {
            try
            {
                SetAuthorizationHeader(token);
                string url = $"{_baseUrl}/api/personas/cedula/{cedula}";
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
            }
            catch (Exception ex)
            {
                return $"Excepción: {ex.Message}";
            }
        }

        // POST crear persona
        public async Task<string> CrearPersonaAsync(object personaData, string token)
        {
            try
            {
                SetAuthorizationHeader(token);
                string url = $"{_baseUrl}/api/personas";
                string jsonContent = JsonConvert.SerializeObject(personaData);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
            }
            catch (Exception ex)
            {
                return $"Excepción: {ex.Message}";
            }
        }

        // PUT actualizar persona
        public async Task<string> ActualizarPersonaAsync(int id, object personaData, string token = null)
        {
            try
            {
                SetAuthorizationHeader(token);
                string url = $"{_baseUrl}/api/personas/{id}";
                string jsonContent = JsonConvert.SerializeObject(personaData);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
            }
            catch (Exception ex)
            {
                return $"Excepción: {ex.Message}";
            }
        }

        // DELETE eliminar persona
        public async Task<string> EliminarPersonaAsync(int id, string token = null)
        {
            try
            {
                SetAuthorizationHeader(token);
                string url = $"{_baseUrl}/api/personas/{id}";
                var response = await _httpClient.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
            }
            catch (Exception ex)
            {
                return $"Excepción: {ex.Message}";
            }
        }

        #endregion

        #region ARQUEO CAJA

        // GET todos los arqueos
        public async Task<string> GetArqueoCajaAsync(string token = null)
        {
            try
            {
                SetAuthorizationHeader(token);
                string url = $"{_baseUrl}/api/arqueo_caja";
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
            }
            catch (Exception ex)
            {
                return $"Excepción: {ex.Message}";
            }
        }

        // GET arqueo por ID
        public async Task<string> GetArqueoCajaPorIdAsync(int id, string token = null)
        {
            try
            {
                SetAuthorizationHeader(token);
                string url = $"{_baseUrl}/api/arqueo_caja/{id}";
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
            }
            catch (Exception ex)
            {
                return $"Excepción: {ex.Message}";
            }
        }

        // POST crear arqueo
        public async Task<string> CrearArqueoCajaAsync(object arqueoData, string token = null)
        {
            try
            {
                SetAuthorizationHeader(token);
                string url = $"{_baseUrl}/api/arqueo_caja";
                string jsonContent = JsonConvert.SerializeObject(arqueoData);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
            }
            catch (Exception ex)
            {
                return $"Excepción: {ex.Message}";
            }
        }

        // PUT actualizar arqueo
        public async Task<string> ActualizarArqueoCajaAsync(int id, object arqueoData, string token = null)
        {
            try
            {
                SetAuthorizationHeader(token);
                string url = $"{_baseUrl}/api/arqueo_caja/{id}";
                string jsonContent = JsonConvert.SerializeObject(arqueoData);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
            }
            catch (Exception ex)
            {
                return $"Excepción: {ex.Message}";
            }
        }

        // DELETE eliminar arqueo
        public async Task<string> EliminarArqueoCajaAsync(int id, string token = null)
        {
            try
            {
                SetAuthorizationHeader(token);
                string url = $"{_baseUrl}/api/arqueo_caja/{id}";
                var response = await _httpClient.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
            }
            catch (Exception ex)
            {
                return $"Excepción: {ex.Message}";
            }
        }

        #endregion

        #region TRANSACCIONES

        // GET todas las transacciones
        public async Task<string> GetTransaccionCajaAsync(string token = null)
        {
            try
            {
                SetAuthorizationHeader(token);
                string url = $"{_baseUrl}/api/transaccion_caja";
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
            }
            catch (Exception ex)
            {
                return $"Excepción: {ex.Message}";
            }
        }

        // GET transacción por ID
        public async Task<string> GetTransaccionCajaPorIdAsync(int id, string token = null)
        {
            try
            {
                SetAuthorizationHeader(token);
                string url = $"{_baseUrl}/api/transaccion_caja/{id}";
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
            }
            catch (Exception ex)
            {
                return $"Excepción: {ex.Message}";
            }
        }

        // POST crear transacción
        public async Task<string> CrearTransaccionCajaAsync(object transaccionData, string token = null)
        {
            try
            {
                SetAuthorizationHeader(token);
                string url = $"{_baseUrl}/api/transaccion_caja";
                string jsonContent = JsonConvert.SerializeObject(transaccionData);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
            }
            catch (Exception ex)
            {
                return $"Excepción: {ex.Message}";
            }
        }

        #endregion

        #region SECUENCIALES

        // GET todos los secuenciales
        public async Task<string> GetSecuencialesAsync(string token)
        {
            try
            {
                SetAuthorizationHeader(token);
                string url = $"{_baseUrl}/api/secuenciales";
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
            }
            catch (Exception ex)
            {
                return $"Excepción: {ex.Message}";
            }
        }

        // GET secuencial por detalle
        public async Task<string> GetSecuencialDetalleAsync(string detalle, string token)
        {
            try
            {
                SetAuthorizationHeader(token);
                string url = $"{_baseUrl}/api/secuenciales/detalle/{detalle}";
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
            }
            catch (Exception ex)
            {
                return $"Excepción: {ex.Message}";
            }
        }

        // GET secuencial por ID
        public async Task<string> GetSecuencialPorIdAsync(int id, string token)
        {
            try
            {
                SetAuthorizationHeader(token);
                string url = $"{_baseUrl}/api/secuenciales/{id}";
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
            }
            catch (Exception ex)
            {
                return $"Excepción: {ex.Message}";
            }
        }

        // POST crear secuencial
        public async Task<string> CrearSecuencialAsync(object secuencialData, string token = null)
        {
            try
            {
                SetAuthorizationHeader(token);
                string url = $"{_baseUrl}/api/secuenciales";
                string jsonContent = JsonConvert.SerializeObject(secuencialData);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
            }
            catch (Exception ex)
            {
                return $"Excepción: {ex.Message}";
            }
        }

        // PUT actualizar secuencial
        public async Task<string> ActualizarSecuencialAsync(int id, object secuencialData, string token = null)
        {
            try
            {
                SetAuthorizationHeader(token);
                string url = $"{_baseUrl}/api/secuenciales/{id}";
                string jsonContent = JsonConvert.SerializeObject(secuencialData);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
            }
            catch (Exception ex)
            {
                return $"Excepción: {ex.Message}";
            }
        }

        // DELETE eliminar secuencial
        public async Task<string> EliminarSecuencialAsync(int id, string token = null)
        {
            try
            {
                SetAuthorizationHeader(token);
                string url = $"{_baseUrl}/api/secuenciales/{id}";
                var response = await _httpClient.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
            }
            catch (Exception ex)
            {
                return $"Excepción: {ex.Message}";
            }
        }

        #endregion

        #region AUTENTICACION

        // Login - obtener token de autenticación
        public async Task<string> LoginAsync(string usuario, string clave)
        {
            try
            {
                // Limpiar headers de autorización para el login
                _httpClient.DefaultRequestHeaders.Authorization = null;

                string url = $"{_baseUrl}/api/Auth/login";
                var loginData = new
                {
                    usuario = usuario,
                    clave = clave
                };

                string jsonContent = JsonConvert.SerializeObject(loginData);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
            }
            catch (Exception ex)
            {
                return $"Excepción: {ex.Message}";
            }
        }

        #endregion

        #region ARTEMIS

        // Verificar placa
        public async Task<string> VerificarPlacaAsync(string placa, string token)
        {
            try
            {
                SetAuthorizationHeader(token);
                string url = $"{_baseUrl}/api/Artemis/verificar-placa?placa={placa}";
                var response = await _httpClient.PostAsync(url, null);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
            }
            catch (Exception ex)
            {
                return $"Excepción: {ex.Message}";
            }
        }

        // Pagar placa
        public async Task<string> PagarPlacaAsync(string placa, decimal pago, string token)
        {
            try
            {
                SetAuthorizationHeader(token);
                string url = $"{_baseUrl}/api/Artemis/pagar-placa?placa={placa}&pago={pago}";
                var response = await _httpClient.PostAsync(url, null);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
            }
            catch (Exception ex)
            {
                return $"Excepción: {ex.Message}";
            }
        }

        // Obtener versión de Artemis
        public async Task<string> GetVersionArtemisAsync(string token)
        {
            try
            {
                SetAuthorizationHeader(token);
                string url = $"{_baseUrl}/api/Artemis/version-artemis";
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
            }
            catch (Exception ex)
            {
                return $"Excepción: {ex.Message}";
            }
        }

        #endregion

        #region DISPOSE

        public void Dispose()
        {
            _httpClient?.Dispose();
        }

        #endregion
    }
}