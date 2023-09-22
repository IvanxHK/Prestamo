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


    }
}
