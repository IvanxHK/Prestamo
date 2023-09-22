using Prestamo.Pages;
using Prestamo.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prestamo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            GoogleMapsApiService.Initialize(Constants.GoogleMapsApiKey);


            MainPage = new ExamplePage();
            //bool isLoggedIn2 = Current.Properties.ContainsKey("IsLoggedIn2") ? Convert.ToBoolean(Current.Properties["IsLoggedIn2"]) : false;
            //if (isLoggedIn2)
            //{
            //    MainPage = new NavigationPage(new CotizarCreditoPage());
            //}
            //else
            //{
            //    MainPage = new LoginPage();
            //}
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
