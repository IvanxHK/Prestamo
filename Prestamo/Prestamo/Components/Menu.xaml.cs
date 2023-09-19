//using Prestamo.Models;
using Prestamo.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prestamo.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : Grid
    {
        private Command inicioCommand;

        private Command cerrarCommand;
        //private Usuario usuario;

        public Command InicioCommand
        {
            get => inicioCommand;
            set
            {
                inicioCommand = value;
                OnPropertyChanged();
            }
        }
        public Command CerrarCommand
        {
            get => cerrarCommand;
            set
            {
                cerrarCommand = value;
                OnPropertyChanged();
            }
        }

        //public Usuario Usuario
        //{
        //    get => usuario;
        //    set
        //    {
        //        usuario = value;
        //        OnPropertyChanged();
        //    }
        //}


        public Menu()
        {

            //Usuario = AppSettings.ObtenerUsuario();
            CerrarCommand = new Command(() =>
            {
                Application.Current.Properties["IsLoggedIn2"] = Boolean.FalseString;
                Preferences.Clear();
                Application.Current.MainPage = new LoginPage();
            });

            InicioCommand = new Command(() =>
            {
                // Crea una instancia de la PrincipalPage
                var principalPage = new PrincipalPage();

                // Reemplaza la página actual por la PrincipalPage
                ReplacePage(principalPage);
            });
            InitializeComponent();
        }
        private void ReplacePage(Page page)
        {
            NavigationPage navPage = (NavigationPage)Application.Current.MainPage;
            if (navPage.CurrentPage.GetType() != page.GetType())
            {
                Application.Current.MainPage = new NavigationPage(page);
            }
            else
            {
                CloseMenu();
            }
        }

        private void CloseMenu()
        {
            NavigationPage navPage = (NavigationPage)Application.Current.MainPage;
            MenuPage mainPage = (MenuPage)navPage.CurrentPage;
            mainPage?.CloseMenu();
        }
    }
}