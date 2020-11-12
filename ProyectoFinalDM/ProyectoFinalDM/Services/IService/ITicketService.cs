using ProyectoFinalDM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDM.Services.IService
{
    public interface ITicketService
    {
        void guardarTicket(TicketModel ticketModel);
        void modificarTicket(TicketModel ticketModel);
        void eliminarTicket(int codTicket);
       Task<ObservableCollection<TicketModel>> consultarTickets();
        TicketModel buscarTicketPorId(int codTicket);
    }
}
