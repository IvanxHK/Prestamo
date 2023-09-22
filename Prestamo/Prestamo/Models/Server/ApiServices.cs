using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Prestamo.Models.Server
{
    public class ApiServices
    {
        public static async Task<LoginResponse> Login(string correo, string password)
        {
            using (var httpClient = new HttpClient())
            {
                string url = $"{AppSettings.ApiUrl}login.php?" +
                    $"usuario={correo}" +
                    $"&pass={password}";

                Debug.WriteLine(url);

                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(content); // Print the JSON response

                return JsonConvert.DeserializeObject<LoginResponse>(content);
            }
        }

        public static async Task<SetCreditoResponse> SetCredito(int monto, int interes, int pago_semanal, int multa, string fecha_inicial, int semanas)
        {
            using (var httpClient = new HttpClient())
            {
                var usuario = AppSettings.ObtenerUsuario();
                string url = $"{AppSettings.ApiUrl}setCredito.php";

                var formData = new MultipartFormDataContent();
                formData.Add(new StringContent(usuario.Correo), "usuario");
                formData.Add(new StringContent(usuario.Pwd), "pass");
                formData.Add(new StringContent(monto.ToString()), "monto");
                formData.Add(new StringContent(interes.ToString()), "interes");
                formData.Add(new StringContent(pago_semanal.ToString()), "pago_semanal");
                formData.Add(new StringContent(multa.ToString()), "multa");
                formData.Add(new StringContent(fecha_inicial), "fecha_inicial");
                formData.Add(new StringContent(semanas.ToString()), "semanas");

                HttpResponseMessage response = await httpClient.PostAsync(url, formData);

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    SetCreditoResponse creditoResponse = JsonConvert.DeserializeObject<SetCreditoResponse>(jsonContent);
                    return creditoResponse;
                }
                else
                {
                    throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}");
                }
            }
        }

        public static async Task<SetClienteResponse> SetCliente(string clave, int tipo_clave, int genero, string nombres, string paterno, string materno, string direccion, double latitud, double longitud, string telefono, string correo, long fk_credito)
        {
            using (var httpClient = new HttpClient())
            {
                var usuario = AppSettings.ObtenerUsuario();
                string url = $"{AppSettings.ApiUrl}setCliente.php";

                var formData = new MultipartFormDataContent();
                formData.Add(new StringContent(usuario.Correo), "usuario");
                formData.Add(new StringContent(usuario.Pwd), "pass");
                formData.Add(new StringContent(clave), "clave");
                formData.Add(new StringContent(tipo_clave.ToString()), "tipo_clave");
                formData.Add(new StringContent(genero.ToString()), "genero");
                formData.Add(new StringContent(nombres), "nombres");
                formData.Add(new StringContent(paterno), "paterno");
                formData.Add(new StringContent(materno), "materno");
                formData.Add(new StringContent(direccion), "direccion");
                formData.Add(new StringContent(latitud.ToString()), "latitud");
                formData.Add(new StringContent(longitud.ToString()), "longitud");
                formData.Add(new StringContent(telefono), "telefono");
                formData.Add(new StringContent(correo), "correo");
                formData.Add(new StringContent(fk_credito.ToString()), "fk_credito");

                HttpResponseMessage response = await httpClient.PostAsync(url, formData);

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    SetClienteResponse clienteResponse = JsonConvert.DeserializeObject<SetClienteResponse>(jsonContent);
                    return clienteResponse;
                }
                else
                {
                    throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}");
                }
            }
        }

        public static async Task<SetAvalResponse> SetAval(string clave, int tipo_clave, int genero, string nombres, string paterno, string materno, string direccion, double latitud, double longitud, string telefono, string correo, long fk_cliente)
        {
            using (var httpClient = new HttpClient())
            {
                var usuario = AppSettings.ObtenerUsuario();
                string url = $"{AppSettings.ApiUrl}setAval.php";

                var formData = new MultipartFormDataContent();
                formData.Add(new StringContent(usuario.Correo), "usuario");
                formData.Add(new StringContent(usuario.Pwd), "pass");
                formData.Add(new StringContent(clave), "clave");
                formData.Add(new StringContent(tipo_clave.ToString()), "tipo_clave");
                formData.Add(new StringContent(genero.ToString()), "genero");
                formData.Add(new StringContent(nombres), "nombres");
                formData.Add(new StringContent(paterno), "paterno");
                formData.Add(new StringContent(materno), "materno");
                formData.Add(new StringContent(direccion), "direccion");
                formData.Add(new StringContent(latitud.ToString()), "latitud");
                formData.Add(new StringContent(longitud.ToString()), "longitud");
                formData.Add(new StringContent(telefono), "telefono");
                formData.Add(new StringContent(correo), "correo");
                formData.Add(new StringContent(fk_cliente.ToString()), "fk_cliente");

                HttpResponseMessage response = await httpClient.PostAsync(url, formData);

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    SetAvalResponse avalResponse = JsonConvert.DeserializeObject<SetAvalResponse>(jsonContent);
                    return avalResponse;
                }
                else
                {
                    throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}");
                }
            }
        }



    }
}
