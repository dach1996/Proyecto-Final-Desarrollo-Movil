using ProyectoFinalDM.Models.SQLite;
using ProyectoFinalDM.Services.WSImplements;
using ProyectoFinalDM.SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoFinalDM.ViewModel.Huella
{
    public class HuellaViewModel
    {
        private ConnectionSQLite conexion;
        public ICommand guardarUsuarioCommand { get; set; }
        public ICommand borrarUsuarioCommand { get; set; }
        public HuellaViewModel()
        {
            conexion = new ConnectionSQLite();
            guardarUsuarioCommand = new Command(guardarUsuario);
            borrarUsuarioCommand = new Command(borrarUsuaro);
        }

        private async void borrarUsuaro()
        {
            conexion.eliminarUsuarios();
            await App.Current.MainPage.DisplayAlert("Éxito", "Ingreso con huella desactivado", "Continuar");
        }

        private async void guardarUsuario()
        {
            conexion.createTableUser();
            conexion.eliminarUsuarios();
            await conexion.registrarUsuario(StaticData.usuaroLogeado.UsernameUsuario, StaticData.usuaroLogeado.PasswordUsuario);
            var lista =  conexion.buscarUsuario();
            if (lista.Count > 0)
            {
              await App.Current.MainPage.DisplayAlert("Éxito", "Usted ya puede ingresar mediante su huella", "Continuar");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Sucedió algo, por favor volver a intentar", "Continuar");
            }
                

        }
    }
}
