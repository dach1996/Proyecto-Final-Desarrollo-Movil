using ProyectoFinalDM.INotifyProperty;
using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services;
using ProyectoFinalDM.Services.IService;
using ProyectoFinalDM.View;
using ProyectoFinalDM.View.Detalle;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoFinalDM.ViewModel
{
    public class TicketViewModel:Notificaciones
    {
        //Servicios
        private ITicketService ticketService = new TicketServiceImplDatos();
        private IClienteService clienteService = new ClienteServiceImplDatos();
        private ICategoriasService categoriaService = new CategoriaServiceImplDatos();
        private IPrioridadService prioridadService = new PrioridadServiceImplDatos();



   
        public TicketModel ticket { get; set; }
        public ObservableCollection<TicketModel> tickets { get; set; }
        public ObservableCollection<ClienteModel> clientes { get; set; }
        public ObservableCollection<CategoriaModel> categorias { get; set; }
        public ObservableCollection<LocalModel> locales { get; set; }
        public ObservableCollection<PrioridadModel> prioridades { get; set; }

        public Command verDetalleCommand { get; set; }
        public Command guardarTicketCommand { get; set; }
        public Command eliminarTicketCommand { get; set; }
        public TicketViewModel(TicketModel ticket = null)
        {
            prioridades = prioridadService.listarPrioridades();
            clientes = clienteService.listarClientes();
            categorias = categoriaService.listarCategorias();
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
            verDetalleCommand = new Command(async () => await this.verDetalles());
        }

       
        private async Task guardarTicket()
        {

            if (ticket.CodTicket==0)
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
