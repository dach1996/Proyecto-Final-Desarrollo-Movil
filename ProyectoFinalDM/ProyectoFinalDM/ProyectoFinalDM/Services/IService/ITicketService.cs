using ProyectoFinalDM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProyectoFinalDM.Services.IService
{
    public interface ITicketService
    {
        void guardarTicket(TicketModel ticketModel);
        void modificarTicket(TicketModel ticketModel);
        void eliminarTicket(string codTicket);
        ObservableCollection<TicketModel> consultarTickets();
    }
}
