using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace Prestamo.Pages
{
    public class MenuPage : ContentPage
    {
        protected SideMenuView MenuView { get; set; }
        public MenuPage()
        {
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CloseMenu();
        }

        public void CloseMenu()
        {
            if (MenuView == null) return;
            MenuView.State = Xamarin.CommunityToolkit.UI.Views.SideMenuState.MainViewShown;
        }
        public void OpenMenu()
        {
            if (MenuView == null) return;
            MenuView.State = Xamarin.CommunityToolkit.UI.Views.SideMenuState.LeftMenuShown;
        }
    }
}
