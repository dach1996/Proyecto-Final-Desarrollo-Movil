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
    public class TicketViewModel : TicketModel
    {
        //Servicios
        public ITicketService servicioTicket = new TicketServiceImplDatos();
        public IClienteService clienteService = new ClienteServiceImplDatos();


        //Modelos
        public ObservableCollection<TicketModel> tickets { get; set; }
        public TicketModel ticket  { get;set; }
        public ObservableCollection<ClienteModel> clientes { get; set; }
        public ObservableCollection<string> locales { get; set; }

        public TicketViewModel(TicketModel ticket=null)
        {
        
            if (ticket == null)
            {
                this.ticket = new TicketModel();
            }
            else
            {
                this.ticket = ticket;
            }
            clientes = clienteService.listarClientes();
            tickets = servicioTicket.consultarTickets();
            guardarTicketCommand = new Command(async () => await this.guardarTicket(), () => !this.isBusy);
            eliminarTicketCommand = new Command(async () => await this.eliminarTicket(), () => !this.isBusy);
            limpiarCommand = new Command(limpiar, ()=> !this.isBusy);
           }



       public Command guardarTicketCommand { get; set; }
        public Command editarTicketCommand { get; set; }
        public Command eliminarTicketCommand { get; set; }
        public Command limpiarCommand { get; set; }



        private async Task guardarTicket()
        {
            isBusy = true;
            if (string.IsNullOrWhiteSpace(ticket.CodTicket))
            {
                Guid CodTicket = Guid.NewGuid();
                ticket.CodTicket = CodTicket.ToString();
                servicioTicket.guardarTicket(ticket);
            }
            else
            {
                servicioTicket.modificarTicket(ticket);
            }
            
            await App.navegacion.PopAsync();
            isBusy = false;
        }


        private async Task eliminarTicket()
        {
            isBusy = true;
            servicioTicket.eliminarTicket(ticket.CodTicket);
            Page page = new Page();

            bool pregunta = await App.navegacion.DisplayAlert("Advertencia", "Desea eliminar este registro", "Sí", "No");
            if(pregunta)
            await App.navegacion.PopAsync();
            isBusy = false;
        }

        private  void limpiar()
        {
            CodTicket = "";
            LocalTicket = "";
            Estado = "";
            CodCliente = "";
            PrioridadTicket = "";
        }

    }
}
