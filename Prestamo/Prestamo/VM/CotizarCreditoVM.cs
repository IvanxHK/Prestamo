using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

        public Command CalcularCotizacionCommand { get; set; }

        public CotizarCreditoVM()
        {
            CalcularCotizacionCommand = new Command(CalcularCotizacion);
        }

        private void CalcularCotizacion()
        {
            //// Calcular el monto total con el interés anual
            //double interesMensual = InteresAnual / 12 / 100;
            //double montoTotalConInteres = MontoCredito * (1 + interesMensual);

            //// Calcular el monto semanal
            //MontoTotal = montoTotalConInteres;
            //MontoSemanal = montoTotalConInteres / NumeroSemanas;

            double montoTotalConInteres = MontoCredito * (1 + (InteresAnual / 100));

            // Calcular el monto semanal
            MontoTotal = montoTotalConInteres;
            MontoSemanal = montoTotalConInteres / NumeroSemanas;
        }

        //private void CalcularCotizacion()
        //{
        //    // Calcular el monto total con el interés anual
        //    double interesMensual = MontoCredito * 10;
        //    double montoTotalConInteres = MontoCredito + interesMensual;

        //    // Calcular el monto semanal
        //    MontoTotal = montoTotalConInteres;
        //    MontoSemanal = montoTotalConInteres / NumeroSemanas;
        //}
    }
}
