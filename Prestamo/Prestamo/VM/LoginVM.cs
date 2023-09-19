using Acr.UserDialogs;
using Prestamo.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Prestamo.VM
{
    public class LoginVM : BaseVM
    {
        private string usuario;
        private string password;

        public Command LoginCommand { get; set; }

        public string Usuario
        {
            get => usuario;
            set
            {
                usuario = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public LoginVM()
        {
            LoginCommand = new Command(async () =>
            {
                UserDialogs.Instance.ShowLoading("Cargando...");
                await Login();
                UserDialogs.Instance.HideLoading();
            });
        }

        public async Task Login()
        {
            Application.Current.MainPage = new NavigationPage(new PrincipalPage());

            //if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            //{
            //    await DisplayAlert("Error de conexión", "No tienes conexión a internet. Intentalo más tarde", "OK");
            //    return;
            //}
            //try
            //{
            //    var response = await ApiServices.Login(Usuario, Password);
            //    if ((response?.Codigo ?? 0) != 200)
            //    {
            //        await DisplayAlert("Error", response?.Descripcion, "OK");
            //        return;
            //    }
            //    if (response.ObjList.Existe == 1)
            //    {
            //        Usuario usuario = new Usuario
            //        {
            //            Correo = Usuario,
            //            Pwd = Password,
            //            Nivel = response.ObjList.Nivel,
            //            PkTienda = response.ObjList.IdTienda
            //        };
            //        AppSettings.GuardarUsuario(usuario);
            //        Application.Current.Properties["IsLoggedIn2"] = Boolean.TrueString;

            //        Application.Current.MainPage = new NavigationPage(new PrincipalPage());
            //    }
            //    else
            //    {
            //        await DisplayAlert("Error", "El usuario o contraseña son incorrectos. Intentalo de nuevo", "OK");
            //    }

            //}
            //catch (Exception e)
            //{
            //    Debug.WriteLine(e.Message);
            //    await DisplayAlert("Error", "Ocurrió un error al iniciar sesión. Intentalo más tarde", "OK");
            //}
        }
    }
}
