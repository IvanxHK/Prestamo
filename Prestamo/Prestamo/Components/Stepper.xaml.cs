using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prestamo.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Stepper : ContentView
    {
        public static readonly BindableProperty QuantityProperty =
            BindableProperty.Create(nameof(Quantity), typeof(double), typeof(Stepper), 1.0, BindingMode.TwoWay);

        public static readonly BindableProperty StepProperty =
            BindableProperty.Create(nameof(Step), typeof(double), typeof(Stepper), 1.0);

        public static readonly BindableProperty MaxProperty =
            BindableProperty.Create(nameof(Max), typeof(double), typeof(Stepper), double.MaxValue);

        public static readonly BindableProperty MinProperty =
            BindableProperty.Create(nameof(Min), typeof(double), typeof(Stepper), 1.0);

        public double Quantity
        {
            get => (double)GetValue(QuantityProperty);
            set => SetValue(QuantityProperty, value);
        }

        public double Step
        {
            get => (double)GetValue(StepProperty);
            set => SetValue(StepProperty, value);
        }

        public double Max
        {
            get => (double)GetValue(MaxProperty);
            set => SetValue(MaxProperty, value);
        }

        public double Min
        {
            get => (double)GetValue(MinProperty);
            set => SetValue(MinProperty, value);
        }

        public static readonly BindableProperty QuantityChangedCommandProperty =
            BindableProperty.Create(nameof(QuantityChangedCommand), typeof(ICommand), typeof(Stepper));

        public ICommand QuantityChangedCommand
        {
            get => (ICommand)GetValue(QuantityChangedCommandProperty);
            set => SetValue(QuantityChangedCommandProperty, value);
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == QuantityProperty.PropertyName)
            {
                QuantityChangedCommand?.Execute(Quantity);
            }
        }

        public Stepper()
        {
            InitializeComponent();
        }

        private void IncreaseTap_Tapped(object sender, EventArgs e)
        {
            if (Quantity + Step <= Max)
            {
                Quantity += Step;
            }
        }

        private void DecreaseTap_Tapped(object sender, EventArgs e)
        {
            if (Quantity - Step >= Min)
            {
                Quantity -= Step;
            }
        }
    }
}