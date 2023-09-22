using Prestamo.Models;
using Prestamo.Models.Server;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Prestamo.VM
{
    public class CotizarCreditoVM : BaseVM
    {
        private double montoCredito;
        private double interesAnual;
        private int numeroSemanas;
        private double montoTotal;
        private double montoSemanal;
        private double multa;
        private int selectedTab;
        private ObservableCollection<PagoItem> pagos;
        public ObservableCollection<PagoItem> Pagos
        {
            get { return pagos; }
            set
            {
                if (pagos != value)
                {
                    pagos = value;
                    OnPropertyChanged();
                }
            }
        }

        public int SelectedTab
        {
            get { return selectedTab; }
            set
            {
                if (selectedTab != value)
                {
                    selectedTab = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime selectedStartDate;
        public DateTime SelectedStartDate
        {
            get { return selectedStartDate; }
            set
            {
                if (selectedStartDate != value)
                {
                    selectedStartDate = value;
                    OnPropertyChanged();
                }
            }
        }

        public double MontoCredito
        {
            get { return montoCredito; }
            set
            {
                if (montoCredito != value)
                {
                    montoCredito = value;
                    OnPropertyChanged();
                }
            }
        }

        public double InteresAnual
        {
            get { return interesAnual; }
            set
            {
                if (interesAnual != value)
                {
                    interesAnual = value;
                    OnPropertyChanged();
                }
            }
        }

        public int NumeroSemanas
        {
            get { return numeroSemanas; }
            set
            {
                if (numeroSemanas != value)
                {
                    numeroSemanas = value;
                    OnPropertyChanged();
                }
            }
        }

        public double MontoTotal
        {
            get { return montoTotal; }
            set
            {
                if (montoTotal != value)
                {
                    montoTotal = value;
                    OnPropertyChanged();
                }
            }
        }

        public double MontoSemanal
        {
            get { return montoSemanal; }
            set
            {
                if (montoSemanal != value)
                {
                    montoSemanal = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Multa
        {
            get { return multa; }
            set
            {
                if (multa != value)
                {
                    multa = value;
                    OnPropertyChanged();
                }
            }
        }

        public Command CalcularCotizacionCommand { get; set; }

        public CotizarCreditoVM()
        {
            CalcularCotizacionCommand = new Command(CalcularCotizacion);
            SelectedStartDate = DateTime.Now;
            SelectedTab = 0; 

        }

        private async void CalcularCotizacion()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await DisplayAlert("Sin conexión", "No tienes conexión a internet. Inténtalo más tarde", "Ok");
                return;
            }

            // Calcula el monto total con interés
            double interesMensual = MontoCredito / 10;
            double montoTotalConInteres = MontoCredito + interesMensual;

            // Calcula el monto semanal
            MontoTotal = montoTotalConInteres;
            MontoSemanal = montoTotalConInteres / NumeroSemanas;

            // Asigna el valor estático de la multa
            double multa = 300; // Aquí asignamos el valor estático de 300
            Multa = multa;

            try
            {
                // Llama al servicio para obtener la respuesta
                SetCreditoResponse creditoResponse = await ApiServices.SetCredito(
                    (int)MontoCredito,
                    (int)InteresAnual,
                    (int)MontoSemanal,
                    (int)multa, // Utiliza la variable Multa que acabamos de asignar
                    SelectedStartDate.ToString("yyyy-MM-dd"), // Convierte la fecha al formato correcto
                    (int)NumeroSemanas
                );

                if (creditoResponse.Codigo == 200)
                {
                    var pagos = creditoResponse.ObjList.Pagos;
                    foreach (var pago in pagos)
                    {
                        Console.WriteLine($"Orden: {pago.Orden}");
                        Console.WriteLine($"Orden Texto: {pago.OrdenTexto}");
                        Console.WriteLine($"Fecha: {pago.Fecha}");
                        Console.WriteLine($"Monto: {pago.Monto}");
                        Console.WriteLine($"estatus: {pago.Estatus}");

                    }
                    SelectedTab = 1;
                    Pagos = new ObservableCollection<PagoItem>(
                    creditoResponse.ObjList.Pagos.Select(p => new PagoItem
                    {
                        OrdenTexto = p.OrdenTexto,
                        Fecha = p.Fecha,
                        Monto = p.Monto,
                        Estatus = (int)p.Estatus
                    }).ToList()
                   );

                }
                else
                {
                    await DisplayAlert("Error", "Ocurrió un error al cotizar. Inténtalo más tarde", "Ok");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await DisplayAlert("Error", ex.Message, "Ok");
                return;
            }
        }
    }
}
