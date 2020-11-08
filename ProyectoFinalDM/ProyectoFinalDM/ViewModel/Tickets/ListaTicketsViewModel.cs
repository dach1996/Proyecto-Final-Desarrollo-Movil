using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services;
using ProyectoFinalDM.Services.IService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProyectoFinalDM.ViewModel.Tickets
{
   
    class ListaTicketsViewModel
    {
        private ITicketService ticketService = new TicketServiceImplDatos();

        public ObservableCollection<TicketModel> tickets { get; set; }
        public ListaTicketsViewModel()
        {
            tickets = TicketServiceImplDatos.tickets;
        }
    }
}
