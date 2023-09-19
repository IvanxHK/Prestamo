using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prestamo.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PerfilImage : ContentView
    {

        public static readonly BindableProperty SourceProperty = BindableProperty.Create(
                              nameof(Source),        // the name of the bindable property
                              typeof(ImageSource),     // the bindable property type
                              typeof(PerfilImage),   // the parent object type
                              default(ImageSource));      // the default valu
        public ImageSource Source
        {
            get => (ImageSource)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        public static readonly BindableProperty BorderThicknessProperty = BindableProperty.Create(
                              nameof(BorderThicknessProperty),        // the name of the bindable property
                              typeof(double),     // the bindable property type
                              typeof(PerfilImage),   // the parent object type
                              5.0);      // the default valu
        public double BorderThickness
        {
            get => (double)GetValue(BorderThicknessProperty);
            set => SetValue(BorderThicknessProperty, value);
        }

        public PerfilImage()
        {
            InitializeComponent();
        }
    }
}