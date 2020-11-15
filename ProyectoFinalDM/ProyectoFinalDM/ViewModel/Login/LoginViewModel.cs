using ProyectoFinalDM.INotifyProperty;
using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services;
using ProyectoFinalDM.Services.IService;
using ProyectoFinalDM.Services.WSImplements;
using ProyectoFinalDM.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoFinalDM.ViewModel.Login
{
    class LoginViewModel : Notificaciones
    {
        private IUsuariosService usuarioService = new UsuarioServiceImplWS();
        private IClienteService clienteService = new ClientesServiceImplWS();
        private ILocalesService localService = new LocalesServiceImplWS();
        private ICategoriasService categoriaService = new CategoriaServiceImplWS();
        private IEstadosService estadosService = new EstadoServiceImplDatos();
        private IPrioridadService prioridadService = new PrioridadServiceImplDatos();
        public static UsuarioModel usuarioLogiado;
        public string Username { get; set; }
        public string Password { get; set; }
        private string estadoAuth_;

        public string estadoAuth
        {
            get { return estadoAuth_; }
            set { estadoAuth_ = value; this.OnPropertyChanged(); }
        }

        public ICommand verificarIngresoCommand { get; set; }
        public LoginViewModel()
        {
            
            verificarIngresoCommand = new Command(() => verificarIngreso());
        }

        private async void verificarIngreso()
        {
            IsBusy = true;
            estadoAuth = "Autentificando";
            await usuarioService.consultarJsonUsuarios();
            usuarioLogiado = usuarioService.buscarUsuario(Username, Password);

            if (usuarioLogiado != null)
            {
                estadoAuth = "Cargando Información";
                await Task.WhenAll(
                    estadosService.consultarEstados(),
                    prioridadService.consultarPrioridades(),
                    clienteService.consultarJsonCliente(),
                    localService.consultarJsonLocal(),
                    categoriaService.consultarJsonCategoria()
                    );

                Console.WriteLine("Terminé de cargar todos");
                StaticData.usuaroLogeado = usuarioLogiado;
                IsBusy = false;
                estadoAuth = "";
                await App.navegacion.PushAsync(new TicketView());

            }
            else
            {
                estadoAuth = "";
                IsBusy = false;
                await App.navegacion.DisplayAlert("Acceso Denegado", "Error Usuario o Contraseña Incorrecto", "OK");

            }
        }
    }
}
