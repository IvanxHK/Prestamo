using Prestamo.Models.Maps;
using Prestamo.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace Prestamo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExamplePage : ContentPage
    {
        private ExampleVM VM { get; set; }
        public ExamplePage()
        {
            InitializeComponent();
            VM = new ExampleVM();
            BindingContext = VM;
        }

        protected async void auto_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            if (e.Reason == dotMorten.Xamarin.Forms.AutoSuggestionBoxTextChangeReason.UserInput)
            {
                await VM.GetPlaces(auto.Text);
            }
        }

        protected async void auto_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            GooglePlaceAutoCompletePrediction selected = (GooglePlaceAutoCompletePrediction)e.SelectedItem;
            VM.SelectedPlacePrediction = selected;
            await VM.GetSelectedPlaceDetails();
            map.Pins.Clear();
            map.Pins.Add(new Pin()
            {
                Label = VM.SelectedPlace.Name,
                Address = VM.SelectedPlacePrediction.ToString(),
                Type = PinType.Place,
                Position = new Position(VM.SelectedPlace.Latitude, VM.SelectedPlace.Longitude),
            });
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Xamarin.Forms.GoogleMaps.Position(VM.SelectedPlace.Latitude, VM.SelectedPlace.Longitude), Xamarin.Forms.GoogleMaps.Distance.FromMiles(0.25f)));
            VM.Places?.Clear();
            autoBackground.IsVisible = true;
            auto.IsEnabled = false;
            // asigna tus valores a tu VM según sea necesario
            var direccion = VM.SelectedPlacePrediction?.ToString() ?? "";
            var latitud = VM.SelectedPlace?.Latitude.ToString() ?? "";
            var longitud = VM.SelectedPlace?.Longitude.ToString() ?? "";
        }
        private void resetAutocomplete()
        {
            auto.IsEnabled = true;
            autoBackground.IsVisible = false;
            auto.Text = "";
            map.Pins.Clear();
            VM.Places?.Clear();
            VM.SelectedPlace = null;
            VM.SelectedPlacePrediction = null;
        }

        private void clearAutoComplete(object sender, EventArgs e)
        {
            resetAutocomplete();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await AppSettings.EscogerVideoPopup();
        }
    }
}