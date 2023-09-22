using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Prestamo.Services
{
    public static class ApiServices
    {
        public static async Task<string> DescargarArchivo(string url, string nombre, bool overwrite = false)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsByteArrayAsync();
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), nombre);
                if (!File.Exists(path) || overwrite)
                {
                    File.WriteAllBytes(path, content);
                }
                return path;
            }
        }
    }
}
