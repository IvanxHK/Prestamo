using Prestamo.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prestamo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private string correo { get; set; }
        private string usuario { get; set; }
        //public List<Entry> myEntryList { get; set; }

        private LoginVM VM { get; set; }
        public LoginPage()
        {
            InitializeComponent();
            VM = new LoginVM();
            BindingContext = VM;
        }
    }
}