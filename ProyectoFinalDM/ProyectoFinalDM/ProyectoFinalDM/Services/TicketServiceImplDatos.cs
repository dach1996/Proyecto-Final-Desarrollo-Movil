using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services.IService;
using System;
using System.Collections.ObjectModel;
using System.Linq;


namespace ProyectoFinalDM.Services
{
    public class TicketServiceImplDatos :   ITicketService
    {
        public static ObservableCollection<TicketModel> tickets { get; set; }

        public TicketServiceImplDatos()
        {
            if (tickets == null)
            {
                tickets = new ObservableCollection<TicketModel>();
                IClienteService clientesService = new ClienteServiceImplDatos();
                ObservableCollection<ClienteModel> clientes = new ObservableCollection<ClienteModel>();
                clientes = clientesService.listarClientes();
                for (int a = 0; a < clientes.Count; a++)
                {
                    tickets.Add(new TicketModel()
                    {
                        CodTicket = "asdf",
                        CategoriaTicket = "Remplazo",
                        Estado = "Ingresado",
                        FechaFinTicket = new DateTime(),
                        FechaTicket = new DateTime(),
                        LocalTicket = "Quicentro",
                        CodUsuario = "Juanito Perez",
                        PrioridadTicket = "Alta",
                        TituloTicket = "Coordinar para cambiar Sensor",
                        ClienteSelected = clientes[a]
                    });
               
                }
               
            }
        }
        public ObservableCollection<TicketModel> consultarTickets()
        {
            return tickets ;
        }
        public void guardarTicket(TicketModel ticketModel)
        {
            tickets.Add(ticketModel);
        }
        public void modificarTicket(TicketModel ticketModel)
        {
            for (int i = 0; i < tickets.Count; i++)
            {
                if (tickets[i].CodTicket == ticketModel.CodTicket)
                {
                    tickets[i] = ticketModel;
                }
            }
        }
        public void eliminarTicket(string codTicket)
        {
            TicketModel ticket = tickets.FirstOrDefault(t => t.CodTicket == codTicket);
            tickets.Remove(ticket);
        }


    }
}
