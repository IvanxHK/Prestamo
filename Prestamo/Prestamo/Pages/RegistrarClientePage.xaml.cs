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
    public partial class RegistrarClientePage : MenuPage
    {
        private RegistrarClienteVM VM { get; set; }

        public RegistrarClientePage()
        {
            InitializeComponent();
            VM = new RegistrarClienteVM();
            BindingContext = VM;
        }
        private void menuBtn_Clicked(object sender, EventArgs e)
        {
            OpenMenu();
        }
    }
}