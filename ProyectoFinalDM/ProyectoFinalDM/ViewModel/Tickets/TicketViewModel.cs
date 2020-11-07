using ProyectoFinalDM.INotifyProperty;
using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services;
using ProyectoFinalDM.Services.IService;
using ProyectoFinalDM.View;
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



        //Modelos
        private bool prueba;

        public bool Prueba
        {
            get { return prueba; }
            set { prueba = value; this.OnPropertyChanged(); }
        }

   

        public TicketModel ticket { get; set; }
        public ObservableCollection<TicketModel> tickets { get; set; }
        public ObservableCollection<ClienteModel> clientes { get; set; }
        public ObservableCollection<CategoriaModel> categorias { get; set; }
        public ObservableCollection<LocalModel> locales { get; set; }
        public ObservableCollection<PrioridadModel> prioridades { get; set; }

        public TicketViewModel(TicketModel ticket = null)
        {
            Prueba = false;
            prioridades = prioridadService.listarPrioridades();
            clientes = clienteService.listarClientes();
            categorias = categoriaService.listarCategorias();
            tickets = ticketService.consultarTickets();
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



        public Command guardarTicketCommand { get; set; }
        public Command editarTicketCommand { get; set; }
        public Command eliminarTicketCommand { get; set; }
        public Command limpiarCommand { get; set; }



        private async Task guardarTicket()
        {

            if (string.IsNullOrWhiteSpace(ticket.CodTicket))
            {
                Guid CodTicket = Guid.NewGuid();
                ticket.CodTicket = CodTicket.ToString();
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

    }
}
