using ProyectoFinalDM.INotifyProperty;
using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services;
using ProyectoFinalDM.Services.IService;
using ProyectoFinalDM.Services.WSImplements;
using ProyectoFinalDM.View;
using ProyectoFinalDM.View.Detalle;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoFinalDM.ViewModel
{
    public class TicketViewModel : Notificaciones
    {
        //Servicios
        private ITicketService ticketService = new TicketServiceImplWS();
        private IClienteService clienteService = new ClientesServiceImplWS();
        private ICategoriasService categoriaService = new CategoriaServiceImplWS();
        private IPrioridadService prioridadService = new PrioridadServiceImplDatos();
        private ILocalesService localService = new LocalesServiceImplWS();




        public TicketModel ticket { get; set; }
        public ObservableCollection<String> estados { get; set; }
        public ObservableCollection<ClienteModel> clientes { get; set; }
        public ObservableCollection<CategoriaModel> categorias { get; set; }
        public ObservableCollection<LocalModel> locales { get; set; }
        public ObservableCollection<String> prioridades { get; set; }

        public Command verDetalleCommand { get; set; }
        public Command guardarTicketCommand { get; set; }
        public Command eliminarTicketCommand { get; set; }
        public Command prueba { get; set; }
        public TicketViewModel(TicketModel ticket = null)
        {

            prioridades = StaticData.prioridades;
            clientes = StaticData.clientes;
            categorias = StaticData.categorias;
            locales = StaticData.locales;
            estados = StaticData.estados;
 
            if (ticket == null)
            {
                this.ticket = new TicketModel();
                this.ticket.Categoria = new CategoriaModel { CodCategoria = 0, NombreCategoria = "INGRESADO" };
            }
            else
            {
                this.ticket = ticket;
            }
            guardarTicketCommand = new Command(async () => await this.guardarTicket());
            eliminarTicketCommand = new Command(async () => await this.eliminarTicket());
        }

        private async void cargarDatosTicket(int codigoTicket)
        {
            IsBusy = true;
            var consulta = await ticketService.buscarTicketPorId(codigoTicket);
            PropertyInfo[] properties = typeof(TicketModel).GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                properties[i].SetValue(this.ticket, properties[i].GetValue(consulta));
            }
            await this.cargarClienteTicket();
            IsBusy = false;

        }

        private Task cargarClienteTicket()
        {
            return Task.Run(()=>{
                this.ticket.Cliente = clienteService.buscarCliente(1);
            });
        }

        private async Task guardarTicket()
        {

            if (ticket.CodTicket == 0)
            {

                ticket.Usuario = UsuarioServiceImplDatos.usuario;
                ticketService.guardarTicket(ticket);

            }
            else
            {
                ticketService.modificarTicket(ticket);
            }

            await App.navegacion.PopAsync();
        }



        private async Task eliminarTicket()
        {
            ticketService.eliminarTicket(ticket.CodTicket);
            Page page = new Page();

            bool pregunta = await App.navegacion.DisplayAlert("Advertencia", "Desea eliminar este registro", "Sí", "No");
            if (pregunta)
                await App.navegacion.PopAsync();

        }

        private async Task verDetalles()
        {

            await App.navegacion.PushAsync(new ListaDestallesView(this.ticket));

        }

    }
}
