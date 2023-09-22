using Prestamo.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Prestamo.VM
{
    public class PrincipalVM : BaseVM
    {
        public ICommand RegistrarCommand { get; private set; }

        // En el constructor del ViewModel:
        public PrincipalVM()
        {
            RegistrarCommand = new Command(NavegarARegistrarCliente);
        }

        private async void NavegarARegistrarCliente()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RegistrarClientePage());
        }

        //private int selectedTipoIndex;
        //private List<ListadoIncidenciasObjList> incidencias;

        //public int SelectedTipoIndex
        //{
        //    get => selectedTipoIndex;
        //    set
        //    {
        //        selectedTipoIndex = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public List<ListadoIncidenciasObjList> Incidencias
        //{
        //    get => incidencias;
        //    set
        //    {
        //        incidencias = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public List<ListadoIncidenciasObjList> DepositosServer { get; set; }

        //public Command<ListadoIncidenciasObjList> SelectedCommand { get; set; }


        //public Usuario Usuario { get; set; }

        //public List<string> Tipos { get; set; }

        //public ListadoIncidenciasVM() : base()
        //{
        //    Usuario = AppSettings.ObtenerUsuario();

        //    switch (Usuario.Nivel)
        //    {
        //        case "2":
        //            Tipos = new List<string>()
        //            {
        //                "Solicitado",
        //                "En curso",
        //                "Resueltas",
        //                "Rechazadas",
        //            };
        //            SelectedTipoIndex = 1;
        //            break;
        //        case "3":
        //            Tipos = new List<string>()
        //            {
        //                "Pendientes",
        //                "Aprobadas",
        //                "Rechazadas",
        //                "Falta información",
        //                "Todas",
        //            "Aprobadas contabilidad",
        //                "Rechazadas contabilidad",
        //            };
        //            SelectedTipoIndex = 4;
        //            break;
        //        case "4":
        //            Tipos = new List<string>()
        //            {
        //                "Pendientes",
        //                "Aprobadas",
        //                "Rechazadas",
        //                "Falta información",
        //                "Todas",
        //            };
        //            SelectedTipoIndex = 4;
        //            break;
        //        case "10":
        //            Tipos = new List<string>()
        //            {
        //                "Solicitado",
        //                "En curso",
        //                "Resueltas",
        //                "Rechazadas",
        //            };
        //            SelectedTipoIndex = 1;
        //            break;
        //    }

        //    RefreshCommand = new Command(async () =>
        //    {
        //        IsRefreshing = true;
        //        await GetIncidencias();
        //        IsRefreshing = false;
        //    });
        //    //CAMBIAR EL DIRECCIONAMIENTO
        //    SelectedCommand = new Command<ListadoIncidenciasObjList>(async (solicitud) =>
        //    {
        //        await PushPageAsync(new DetalleListadoIncidenciasPage(solicitud));
        //    });
        //}


        //public async Task GetIncidencias()
        //{
        //    if (Connectivity.NetworkAccess != NetworkAccess.Internet)
        //    {
        //        await DisplayAlert("Sin conexión a internet", "No cuentas con una conexión a internet. Intentalo más tarde", "Ok");
        //        return;
        //    }
        //    try
        //    {
        //        var response = await ApiServices.GetIncidencias(SelectedTipoIndex + 1);
        //        if ((response?.Codigo ?? 0) != 200)
        //        {
        //            await DisplayAlert("Error", response?.Descripcion, "Ok");
        //            return;
        //        }
        //        Incidencias = response.ObjList;
        //        //Depositos = new List<SolicitudesDepositosObjList>(DepositosServer);
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e.Message);
        //        await DisplayAlert("Error", "Hubo un error inesperado al obtener las confirmaciones de depósitos. Intentalo más tarde", "Ok");
        //    }
        //}


    }
}
