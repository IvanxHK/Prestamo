using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.UI.Views;
using Acr.UserDialogs;
using Xamarin.Essentials;
using System.IO;

namespace Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerPdfPopup : Popup
    {
        private string rutaPdf;

        public string RutaPdf
        {
            get => rutaPdf;
            set
            {
                rutaPdf = value;
                OnPropertyChanged();
            }
        }
        public VerPdfPopup(string rutaPdf)
        {
            InitializeComponent();
            RutaPdf = rutaPdf;
        }

    }
}