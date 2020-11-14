using ProyectoFinalDM.INotifyProperty;
using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services;
using ProyectoFinalDM.Services.IService;
using ProyectoFinalDM.Services.WSImplements;
using ProyectoFinalDM.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoFinalDM.ViewModel.Login
{
    class LoginViewModel : Notificaciones
    {
        private IUsuariosService usuarioService = new UsuarioServiceImplWS();
        private IClienteService clienteService = new ClientesServiceImplWS();
        public static UsuarioModel usuarioLogiado;
        public string Username { get; set; }
        public string Password { get; set; }

        public ICommand verificarIngresoCommand { get; set; }
        public LoginViewModel()
        {
            verificarIngresoCommand = new Command(() => verificarIngreso());
        }

        private async void verificarIngreso()
        {
            IsBusy = true;
            usuarioService.consultarJsonUsuarios().Wait();
            usuarioLogiado =  usuarioService.buscarUsuario(Username, Password);
            if (usuarioLogiado != null)
            {
                clienteService.consultarJson();
                UsuarioServiceImplDatos.usuario = usuarioLogiado;
                IsBusy = false;
                await App.navegacion.PushAsync(new TicketView());
                
            }
            else
            {
                IsBusy = false;
                await App.navegacion.DisplayAlert("Acceso Denegado", "Error Usuario o Contraseña Incorrecto", "OK");
                
            }
        }
    }
}
