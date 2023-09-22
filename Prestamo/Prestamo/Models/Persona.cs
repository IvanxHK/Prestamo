using System;
using System.ComponentModel;
using Prestamo.Helpers;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Prestamo.Models
{
    public class Persona : ObservableObject
    {
        private int genero;
        public int Genero
        {
            get { return genero; }
            set { SetProperty(ref genero, value); }
        }

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { SetProperty(ref nombre, value); }
        }

        private string apellidoPaterno;
        public string ApellidoPaterno
        {
            get { return apellidoPaterno; }
            set { SetProperty(ref apellidoPaterno, value); }
        }

        private string apellidoMaterno;
        public string ApellidoMaterno
        {
            get { return apellidoMaterno; }
            set { SetProperty(ref apellidoMaterno, value); }
        }

        private string direccion;
        public string Direccion
        {
            get { return direccion; }
            set { SetProperty(ref direccion, value); }
        }

        private string latitud;
        public string Latitud
        {
            get { return latitud; }
            set { SetProperty(ref latitud, value); }
        }

        private string longitud;
        public string Longitud
        {
            get { return longitud; }
            set { SetProperty(ref longitud, value); }
        }

        private string telefono;
        public string Telefono
        {
            get { return telefono; }
            set { SetProperty(ref telefono, value); }
        }

        private string correo;
        public string Correo
        {
            get { return correo; }
            set { SetProperty(ref correo, value); }
        }

    }
}
