using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace Prestamo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrincipalPage : MenuPage
    {
        //private ListadoIncidenciasVM VM { get; set; }

        public PrincipalPage()
        {
            InitializeComponent();
            //VM = new ListadoIncidenciasVM();
            //BindingContext = VM;
            //tipoPicker.SelectedIndex = 0;
            MenuView = menuView;

            List<DatoEstatico> datosEstaticos = new List<DatoEstatico>
            {
                new DatoEstatico { Pago = "Pago 1", Periodo = "Periodo 1", Fecha = DateTime.Now, Estatus = "Pagado" },
                new DatoEstatico { Pago = "Pago 2", Periodo = "Periodo 2", Fecha = DateTime.Now.AddMonths(1), Estatus = "Pendiente" },
                new DatoEstatico { Pago = "Pago 3", Periodo = "Periodo 3", Fecha = DateTime.Now.AddMonths(2), Estatus = "Retraso" }
            };

            // Asignar la lista como origen de datos para la CollectionView
            collectionView.ItemsSource = datosEstaticos;
        }
        private void menuBtn_Clicked(object sender, EventArgs e)
        {
            OpenMenu();
        }
        //private async void nuevoTap_Tapped(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new IncidenciasPage());
        //}

        //private async void Picker_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    UserDialogs.Instance.ShowLoading("Cargando...");
        //    await VM.GetIncidencias();
        //    UserDialogs.Instance.HideLoading();
        //}
    }

    internal class DatoEstatico
    {
        public string Pago { get; internal set; }
        public string Periodo { get; internal set; }
        public DateTime Fecha { get; internal set; }
        public string Estatus { get; set; } // Agrega una propiedad para el estado

    }
}