using Prestamo;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePopup : Popup<MediaFile>
    {
        private ImageSource imageSource;

        private MediaFile ImageFile { get; set; }
        public ImageSource ImageSource
        {
            get => imageSource;
            set
            {
                imageSource = value;
                OnPropertyChanged();
            }
        }
        public ImagePopup(MediaFile imageFile)
        {
            InitializeComponent();
            ImageFile = imageFile;
            ImageSource = imageFile.Path;
        }

        private void subirBtn_Clicked(object sender, EventArgs e)
        {
            Dismiss(ImageFile);
        }

        private async void escogerOtraBtn_Clicked(object sender, EventArgs e)
        {
            var file = await AppSettings.EscogerImagen();
            if (file != null)
            {
                ImageFile = file;
                ImageSource = file.Path;
            }
        }

        protected override MediaFile GetLightDismissResult()
        {
            return null;
        }
    }
}