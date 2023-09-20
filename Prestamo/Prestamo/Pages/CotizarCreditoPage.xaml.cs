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
	public partial class CotizarCreditoPage : ContentPage
	{
		public CotizarCreditoPage ()
		{
			InitializeComponent ();
            BindingContext = new CotizarCreditoVM(); // Establece el ViewModel como contexto de datos

        }
    }
}