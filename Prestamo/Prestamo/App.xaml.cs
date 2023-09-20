﻿using Prestamo.Pages;
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

            MainPage = new CotizarCreditoPage();
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
