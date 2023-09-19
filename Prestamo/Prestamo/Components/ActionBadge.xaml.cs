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
    public partial class ActionBadge : ContentView
    {

        public static readonly BindableProperty TextProperty = BindableProperty.Create(
                              nameof(Text),        // the name of the bindable property
                              typeof(string),     // the bindable property type
                              typeof(ActionBadge),   // the parent object type
                              string.Empty);      // the default valu
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public ActionBadge()
        {
            InitializeComponent();
        }
    }
}