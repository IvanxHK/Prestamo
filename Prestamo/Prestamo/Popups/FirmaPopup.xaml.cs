using SignaturePad.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prestamo.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirmaPopup : Popup
    {
        private string title;
        private string promtText;
        private string captionText;

        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        public string PromtText
        {
            get => promtText;
            set
            {
                promtText = value;
                OnPropertyChanged();
            }
        }

        public string CaptionText
        {
            get => captionText;
            set
            {
                captionText = value;
                OnPropertyChanged();
            }
        }

        public FirmaPopup(string title, string promtText, string captionText)
        {
            Title = title;
            PromtText = promtText;
            CaptionText = captionText;
            InitializeComponent();
        }
        private async void FirmarBtn_Clicked(object sender, EventArgs e)
        {
            Stream bitmap = await signatureView.GetImageStreamAsync(SignatureImageFormat.Png);
            Dismiss(bitmap);
        }
    }
}