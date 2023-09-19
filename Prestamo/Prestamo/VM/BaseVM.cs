using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace Prestamo.VM
{
    public class BaseVM : ObservableObject
    {
        private bool isRefreshing;
        private int selectedTab;

        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public int SelectedTab
        {
            get => selectedTab;
            set
            {
                selectedTab = value;
                OnPropertyChanged();
            }
        }

        public Command<string> GoToTabCommand { get; set; }

        public Command RefreshCommand { get; set; }

        public BaseVM()
        {
            GoToTabCommand = new Command<string>((index) =>
            {
                Int32.TryParse(index, out int tab);
                SelectedTab = tab;
            });
        }

        protected async Task PushPageAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        protected async Task PushPageModalAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(page);
        }

        protected async Task PopPageAsync()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        protected async Task PopToRootAsync()
        {
            await Application.Current.MainPage.Navigation.PopToRootAsync();
        }

        protected async Task DisplayAlert(string title, string desciption, string close)
        {
            await Application.Current.MainPage.DisplayAlert(title, desciption, close);
        }

        protected async Task<bool> DisplayQuestion(string title, string question)
        {
            var answer = await Application.Current.MainPage.DisplayAlert(title, question, "Si", "No");
            return answer;
        }

        protected void ReplacePage(Page page)
        {
            Application.Current.MainPage = page;
        }

    }
}
