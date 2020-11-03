using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services;
using ProyectoFinalDM.Services.IService;
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


        public ObservableCollection<TicketModel> tickets { get; set; }
        public ITicketService servicioTicket = new TicketServiceImplDatos();
        public TicketModel ticket = new TicketModel();


        public TicketViewModel()
        {
            tickets = servicioTicket.consultarTickets();
            guardarTicketCommand = new Command(async () => await this.guardarTicket(), () => !this.isBusy);
            editarTicketCommand = new Command(async () => await this.editarTicket(), () => !this.isBusy);
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
            Guid CodTicket = Guid.NewGuid();
            ticket = new TicketModel()
            {
                CodTicket = CodTicket.ToString(),
                LocalTicket = LocalTicket,
                Estado = "Nuevo",
                CodCliente = CodCliente,
                PrioridadTicket = PrioridadTicket,
            };
            servicioTicket.guardarTicket(ticket);
            await Task.Delay(200);
            isBusy = false;
        }

        private async Task editarTicket()
        {
            isBusy = true;
            ticket = new TicketModel()
            {
                CodTicket = CodCliente,
                LocalTicket = LocalTicket,
                Estado = "Nuevo",
                CodCliente = CodCliente,
                PrioridadTicket = PrioridadTicket,
            };
            servicioTicket.modificarTicket(ticket);
            await Task.Delay(200);
            isBusy = false;
        }

        private async Task eliminarTicket()
        {
            isBusy = true;
            servicioTicket.eliminarTicket(CodTicket);
            await Task.Delay(200);
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
