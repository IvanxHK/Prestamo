using Acr.UserDialogs;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Popups;
using Prestamo.Models;
using Prestamo.Models.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Prestamo
{
    public static class AppSettings
    {

        public static string ApiUrl = "https://prestamos.integradesarrollo.com/ws/";
        private const string UsuarioKey = "Usuario";

        public static void GuardarUsuario(Usuario usuario)
        {
            var usuarioJson = Newtonsoft.Json.JsonConvert.SerializeObject(usuario);
            Preferences.Set(UsuarioKey, usuarioJson);
        }

        public static Usuario ObtenerUsuario()
        {
            var usuarioJson = Preferences.Get(UsuarioKey, string.Empty);
            if (!string.IsNullOrEmpty(usuarioJson))
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<Usuario>(usuarioJson);
            }
            return null;
        }

        public static string ConvertToMoney(object value)
        {
            if (value == null || value.ToString() == String.Empty) value = 0m;
            NumberFormatInfo nfi = new CultureInfo("es-MX").NumberFormat;
            return Regex.Replace(Decimal.Parse(value.ToString()).ToString("C", nfi), "\\.00$", "");
        }
        private static async Task DisplayAlert(string titulo, string descripcion, string confirmacion)
        {
            await Application.Current.MainPage.DisplayAlert(titulo, descripcion, confirmacion);
        }
        public static async Task<string> DescargarPDf(string pdfUrl, string nombrePdf, bool ovewrite = false)
        {

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await DisplayAlert("Sin conexión", "No tienes conexión a internet. Intentalo más tarde", "Ok");
                return "";
            }
            try
            {
                UserDialogs.Instance.ShowLoading("Descargando pdf...");
                string rutaPdf = await Services.ApiServices.DescargarArchivo(pdfUrl, nombrePdf, ovewrite);
                UserDialogs.Instance.HideLoading();
                return rutaPdf;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                await DisplayAlert("Error", "Ocurrió un error al descargar el archivo. Intentalo más tarde", "Ok");
                return "";
            }
        }

        public static async Task<MediaFile> EscogerImagenPopup()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet("Tomar imagen desde:", null, null, "Galería", "Cámara");
            MediaFile file = null;
            if (action == "Galería") file = await TomarFotoGaleria();
            if (action == "Cámara") file = await TomarFotoCamara();
            if (file != null)
            {
                var PopupFile = await App.Current.MainPage.Navigation.ShowPopupAsync(new ImagePopup(file));
                return PopupFile;
            }
            return file;
        }

        public static async Task<MediaFile> EscogerVideoPopup()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet("Tomar video desde:", null, null, "Galería", "Cámara");
            MediaFile file = null;
            if (action == "Galería") file = await TomarVideoGaleria();
            if (action == "Cámara") file = await TomarVideoCamara();
            if (file != null)
            {
                var PopupFile = await App.Current.MainPage.Navigation.ShowPopupAsync(new ImagePopup(file));
                return PopupFile;
            }
            return file;
        }

        public static async Task<MediaFile> TomarFotoCamara()
        {
            if (!CrossMedia.Current.IsTakePhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Permiso no concedido", "Conceda permiso a las cámara para poder tomar la foto", "Ok");
                return null;
            }
            var file = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
            });

            return file;
        }

        public static async Task<MediaFile> TomarVideoCamara()
        {
            if (!CrossMedia.Current.IsTakeVideoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Permiso no concedido", "Conceda permiso a las cámara para poder tomar el video", "Ok");
                return null;
            }

            var file = await Plugin.Media.CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
            {
            });

            return file;
        }

        public static async Task<MediaFile> TomarVideoGaleria()
        {
            if (!CrossMedia.Current.IsPickVideoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Permiso no concedido", "Conceda permiso a las galeria para escoger el video", "Ok");
                return null;
            }

            var file = await Plugin.Media.CrossMedia.Current.PickVideoAsync();

            return file;
        }

        public static async Task<MediaFile> TomarFotoGaleria()
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Permiso no concedido", "Conceda permiso a las fotos para poder subir la imagen", "Ok");
                return null;
            }
            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
            });

            return file;
        }

        public static async Task<MediaFile> EscogerImagen()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet("Tomar imagen desde:", null, null, "Galería", "Cámara");
            MediaFile file = null;
            if (action == "Galería") file = await TomarFotoGaleria();
            if (action == "Cámara") file = await TomarFotoCamara();
            return file;
        }

        public static async Task<MediaFile> EscogerVideo()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet("Tomar video desde:", null, null, "Galería", "Cámara");
            MediaFile file = null;
            if (action == "Galería") file = await TomarVideoGaleria();
            if (action == "Cámara") file = await TomarVideoCamara();
            return file;
        }

        public static async Task<FileResult> EscogerArcivo()
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "Escoger archivo"
                });

                if (result != null)
                {
                    return result;
                    // Use the filePath as needed
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error " + ex.Message);
                // Handle exception
            }
            return null;
        }

        public static async Task DescargarPDfOpcciones(string pdfUrl, string nombrePdf, bool ovewrite = false)
        {

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await DisplayAlert("Sin conexión", "No tienes conexión a internet. Intentalo más tarde", "Ok");
                return;
            }
            try
            {
                UserDialogs.Instance.ShowLoading("Descargando pdf...");
                string rutaPdf = await Services.ApiServices.DescargarArchivo(pdfUrl, nombrePdf, ovewrite);
                UserDialogs.Instance.HideLoading();
                string action = await Application.Current.MainPage.DisplayActionSheet("PDF descargado con éxito", "Cancel", null, "Imprimir", "Compartir");
                if (action == "Imprimir")
                {
                    await App.Current.MainPage.Navigation.ShowPopupAsync(new VerPdfPopup(rutaPdf));
                }
                else if (action == "Compartir")
                {
                    await Share.RequestAsync(new ShareFileRequest
                    {
                        Title = "PDF",
                        File = new ShareFile(rutaPdf)
                    });
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                await DisplayAlert("Error", "Ocurrió un error al descargar el archivo. Intentalo más tarde", "Ok");
                return;
            }
        }

    }
}
