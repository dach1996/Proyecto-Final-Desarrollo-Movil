using Plugin.Fingerprint.Abstractions;
using ProyectoFinalDM.INotifyProperty;
using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services;
using ProyectoFinalDM.Services.IService;
using ProyectoFinalDM.Services.Security;
using ProyectoFinalDM.Services.SignalR;
using ProyectoFinalDM.Services.WSImplements;
using ProyectoFinalDM.SQLite;
using ProyectoFinalDM.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
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
        private ConnectionSQLite conexion;
        public string Username { get; set; }
        public string Password { get; set; }
        private string estadoAuth_;

        public string estadoAuth
        {
            get { return estadoAuth_; }
            set { estadoAuth_ = value; this.OnPropertyChanged(); }
        }

        public ICommand verificarIngresoCommand { get; set; }
        public ICommand verificarHuellaDigitital { get; set; }
        public LoginViewModel()
        {
            
            conexion = new ConnectionSQLite();
            verificarIngresoCommand = new Command(() => verificarIngreso());
            verificarHuellaDigitital = new Command(() => OnAuthenticate());
        }

        private async void OnAuthenticate()
        {
            await AuthenticateAsync("Coloca tu huella digital para acceder");
        }

        private async Task AuthenticateAsync(string reason, string cancel = null, string fallback = null, string tooFast = null)
        {

            var dialogConfig = new AuthenticationRequestConfiguration("Acceso", reason)
            { // all optional 
                CancelTitle = cancel,
                FallbackTitle = fallback,
            };

            // optional
            dialogConfig.HelpTexts.MovedTooFast = tooFast;

            var result = await Plugin.Fingerprint.CrossFingerprint.Current.AuthenticateAsync(dialogConfig);

            await SetResultAsync(result);
        }

        private async Task SetResultAsync(FingerprintAuthenticationResult result)
        {
            if (result.Authenticated)
            {
                StaticData.cleanData();
                IsBusy = true;
                estadoAuth = "Autentificando";
                await usuarioService.consultarJsonUsuarios();
                var lista = conexion.buscarUsuario();
                if (lista.Count > 0)
                {
                    var user = Encrypt.DesEncriptar(lista[0].username);
                    var pass =Encrypt.DesEncriptar(lista[0].password);
                    usuarioLogiado = usuarioService.buscarUsuario(user,pass);
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
                        await App.navegacion.PushAsync(new MainPage());
                    }
                    else
                    {
                        estadoAuth = "";
                        IsBusy = false;
                        await App.navegacion.DisplayAlert("Acceso Denegado", "Error Usuario o Contraseña Incorrecto", "OK");
                    }
                }
                else
                {
                    IsBusy = false;
                    estadoAuth = "";
                    await App.navegacion.DisplayAlert("Acceso Denegado", "Usted no tiene habilitado el acceso con Huella", "OK");
                }
                
            } 
        }

        private async void verificarIngreso()
        {
      

            StaticData.cleanData();
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
                await App.navegacion.PushAsync(new MainPage());

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
