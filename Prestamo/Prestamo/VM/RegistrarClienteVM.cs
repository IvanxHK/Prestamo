using System;
using Prestamo.Models;
using Prestamo.Helpers;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Prestamo.Models.Server;

namespace Prestamo.VM
{
    public class RegistrarClienteVM : BaseVM
    {
        private Persona cliente;
        private Persona aval; // Nueva instancia para el aval

        private string generoSeleccionado;
        public string GeneroSeleccionado
        {
            get { return generoSeleccionado; }
            set { SetProperty(ref generoSeleccionado, value); }
        }


        // Método para convertir el género seleccionado en un valor numérico.
        private int ConvertirGenero(string genero)
        {
            switch (genero)
            {
                case "Hombre":
                    return 1; // Puedes asignar valores numéricos según tu lógica.
                case "Mujer":
                    return 2;
                default:
                    return 1; // Valor por defecto o manejo de errores si es necesario.
            }
        }

        public RegistrarClienteVM()
        {
            cliente = new Persona();
            aval = new Persona(); // Inicializa el aval
            GeneroSeleccionado = "Hombre"; // Establece el valor predeterminado
            RegistrarClienteCommand = new Command(async () => await RegistrarClienteAsync());
            RegistrarAvalCommand = new Command(async () => await RegistrarAvalAsync());

        }

        public Command RegistrarClienteCommand { get; set; }
        public Command RegistrarAvalCommand { get; set; }

        public Persona Cliente
        {
            get { return cliente; }
            set { SetProperty(ref cliente, value); }
        }
        public Persona Aval
        {
            get { return aval; }
            set { SetProperty(ref aval, value); }
        }
        public async Task RegistrarClienteAsync()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("Sin conexión", "No tienes conexión a internet. Inténtalo más tarde", "Ok");
                return;
            }

            try
            {
                // Aquí obtienes los valores ingresados por el usuario desde el modelo Cliente
                int genero = ConvertirGenero(GeneroSeleccionado);
                string nombre = Cliente.Nombre;
                string apellidoPaterno = Cliente.ApellidoPaterno;
                string apellidoMaterno = Cliente.ApellidoMaterno;
                string direccion = Cliente.Direccion;
                string latitud = Cliente.Latitud;
                string longitud = Cliente.Longitud;
                string telefono = Cliente.Telefono;
                string correo = Cliente.Correo;

                // Llama al servicio para registrar al cliente
                SetClienteResponse clienteResponse = await ApiServices.SetCliente(
    "1", // clave (string)
    1, // tipo_clave (int)
    genero, // genero (int)
    nombre, // nombres (string)
    apellidoPaterno, // paterno (string)
    apellidoMaterno, // materno (string)
    direccion, // direccion (string)
    Convert.ToDouble(latitud), // latitud (double)
    Convert.ToDouble(longitud), // longitud (double)
    telefono, // telefono (string)
    correo, // correo (string)
    1 // fk_credito (long)
);


                if (clienteResponse != null && clienteResponse.Codigo == 200)
                {
                    // El cliente se registró correctamente, puedes realizar cualquier acción adicional aquí
                    await App.Current.MainPage.DisplayAlert("Éxito", "El cliente se registró correctamente", "Ok");
                }
                else
                {
                    // Hubo un problema al registrar el cliente, muestra un mensaje de error
                    await App.Current.MainPage.DisplayAlert("Error", $"Hubo un problema al registrar el cliente. Por favor, inténtalo nuevamente más tarde. Código de error: {clienteResponse?.Codigo}", "Ok");
                }
            }
            catch (Exception ex)
            {
                // Maneja las excepciones aquí, muestra un mensaje de error
                await App.Current.MainPage.DisplayAlert("Error", $"Hubo un problema al registrar el cliente. Por favor, inténtalo nuevamente más tarde.\nError: {ex.Message}", "Ok");
            }
        }

        public async Task RegistrarAvalAsync()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("Sin conexión", "No tienes conexión a internet. Inténtalo más tarde", "Ok");
                return;
            }

            try
            {
                int generoAval = ConvertirGenero(GeneroSeleccionado);
                string nombreAval = Aval.Nombre;
                string apellidoPaternoAval = Aval.ApellidoPaterno;
                string apellidoMaternoAval = Aval.ApellidoMaterno;
                string direccionAval = Aval.Direccion;
                string latitudAval = Aval.Latitud;
                string longitudAval = Aval.Longitud;
                string telefonoAval = Aval.Telefono;
                string correoAval = Aval.Correo;

                // Llama al servicio para registrar al aval
                SetAvalResponse avalResponse = await ApiServices.SetAval(
                    
                    "clave_del_aval", // Reemplaza con el valor adecuado
                    1, // Reemplaza con el valor adecuado
                    generoAval,
                    nombreAval,
                    apellidoPaternoAval,
                    apellidoMaternoAval,
                    direccionAval,
                    Convert.ToDouble(latitudAval),
                    Convert.ToDouble(longitudAval),
                    telefonoAval,
                    correoAval,
                    1 // Reemplaza con el valor adecuado
                );

                if (avalResponse != null && avalResponse.Codigo == 200)
                {
                    // El aval se registró correctamente, puedes realizar cualquier acción adicional aquí
                    await App.Current.MainPage.DisplayAlert("Éxito", "El aval se registró correctamente", "Ok");
                }
                else
                {
                    // Hubo un problema al registrar el aval, muestra un mensaje de error
                    await App.Current.MainPage.DisplayAlert("Error", $"Hubo un problema al registrar el aval. Por favor, inténtalo nuevamente más tarde. Código de error: {avalResponse?.Codigo}", "Ok");
                }
            }
            catch (Exception ex)
            {
                // Maneja las excepciones aquí, muestra un mensaje de error
                await App.Current.MainPage.DisplayAlert("Error", $"Hubo un problema al registrar el aval. Por favor, inténtalo nuevamente más tarde.\nError: {ex.Message}", "Ok");
            }
        }

    }
}
