using MediaManager.Forms;
using MediaManager;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Core;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace Prestamo.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoPopup : Popup<MediaFile>
    {
        private Uri videoSource;

        public Uri VideoSource
        {
            get => videoSource;
            set
            {
                videoSource = value;
                OnPropertyChanged();
            }
        }
        private MediaFile ImageFile { get; set; }
        public VideoPopup(MediaFile mediaFile)
        {
            InitializeComponent();
            ImageFile = mediaFile;
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
                new Uri($"{file.Path}");
            }
        }

        protected override MediaFile GetLightDismissResult()
        {
            return null;
        }

        private async void This_Opened(object sender, PopupOpenedEventArgs e)
        {
            Debug.WriteLine("OPENED");
            var videoView = new VideoView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                IsFullWindow = true,
                InputTransparent = true,
                AutoPlay = true,
                ShowControls = false,
            };
            videoContainer.Content = videoView;
            var generatedMediaItem =
                        await CrossMediaManager.Current.Extractor.CreateMediaItem(ImageFile.Path);
            await CrossMediaManager.Current.MediaPlayer.Play(generatedMediaItem);
        }
    }
}