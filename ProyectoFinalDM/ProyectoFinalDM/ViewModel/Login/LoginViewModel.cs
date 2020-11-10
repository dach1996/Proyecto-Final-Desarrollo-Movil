using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services;
using ProyectoFinalDM.Services.IService;
using ProyectoFinalDM.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoFinalDM.ViewModel.Login
{
    class LoginViewModel
    {
        private IUsuariosService usuarioService = new UsuarioServiceImplDatos();
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
            usuarioLogiado = usuarioService.buscarUsuario(Username, Password);
            if (usuarioLogiado == null)
            {
               
            }
            else
            {
                await App.navegacion.PushAsync(new TicketView());
            }
        }
    }
}
