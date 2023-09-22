using Prestamo.Models.Maps;
using Prestamo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Prestamo.VM
{
    public class ExampleVM : BaseVM
    {
        // Observable collection de lugares. Se usa para el autocompletado por Google Maps
        private ObservableCollection<GooglePlaceAutoCompletePrediction> places;
        public ObservableCollection<GooglePlaceAutoCompletePrediction> Places
        {
            get => places;
            set
            {
                places = value;
                OnPropertyChanged();
            }
        }
        public GooglePlaceAutoCompletePrediction SelectedPlacePrediction { get; set; }
        public GooglePlace SelectedPlace { get; set; }
        private GoogleMapsApiService googleMapsApi { get; set; }

        public ExampleVM()
        {
            googleMapsApi = new GoogleMapsApiService();
        }

        public async Task GetPlaces(string text)
        {
            var response = await googleMapsApi.GetPlaces(text);
            Places = new ObservableCollection<GooglePlaceAutoCompletePrediction>(response?.AutoCompletePlaces);
        }

        public async Task GetSelectedPlaceDetails()
        {
            SelectedPlace = await googleMapsApi.GetPlaceDetails(SelectedPlacePrediction.PlaceId);
        }

    }
}
