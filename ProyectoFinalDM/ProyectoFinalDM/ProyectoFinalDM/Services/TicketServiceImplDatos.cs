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
                ICategoriasService categoriaService = new CategoriaServiceImplDatos();
                ObservableCollection<ClienteModel> clientes = new ObservableCollection<ClienteModel>();
                ObservableCollection<CategoriaModel> categorias = new ObservableCollection<CategoriaModel>();
                clientes = clientesService.listarClientes();
                categorias = categoriaService.listarCategorias();
                for (int a = 0; a < clientes.Count; a++)
                {
                    tickets.Add(new TicketModel()
                    {
                        CodTicket =  Guid.NewGuid().ToString(),
                        Estado = "Ingresado",
                        FechaFinTicket = new DateTime(),
                        FechaTicket = new DateTime(),
                        LocalTicket = "Quicentro",
                        CodUsuario = "Juanito Perez",
                        TituloTicket = "Coordinar para cambiar Sensor",
                        Cliente = clientes[a],
                        Categoria = categorias[new Random().Next(1, 5)]
                    }) ;
               
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
