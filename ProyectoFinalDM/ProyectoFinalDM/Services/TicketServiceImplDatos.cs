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
                IUsuariosService usuarioService = new UsuarioServiceImplDatos();
                IPrioridadService prioridadesService = new PrioridadServiceImplDatos();
                ObservableCollection<ClienteModel> clientes = new ObservableCollection<ClienteModel>();
                ObservableCollection<CategoriaModel> categorias = new ObservableCollection<CategoriaModel>();
                ObservableCollection<PrioridadModel> prioridades = new ObservableCollection<PrioridadModel>();
                ObservableCollection<UsuarioModel> usuarios = new ObservableCollection<UsuarioModel>();
                clientes = clientesService.listarClientes();
                categorias = categoriaService.listarCategorias();
                prioridades = prioridadesService.listarPrioridades();
                usuarios = usuarioService.listarUsuarios();
                for (int a = 0; a < clientes.Count; a++)
                {
                    tickets.Add(new TicketModel()
                    {
                        CodTicket =  (a+1),
                        Estado = "Ingresado",
                        FechaFinTicket = new DateTime(),
                        FechaTicket = new DateTime(),
                        LocalTicket = "Quicentro",
                        TituloTicket = "Coordinar para cambiar Sensor",
                        Prioridad= prioridades[new Random().Next(1,3)],
                        Usuario = usuarios[new Random().Next(1,3)],
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
            ticketModel.CodTicket = tickets.Count;
            
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
        public void eliminarTicket(int codTicket)
        {
            TicketModel ticket = tickets.FirstOrDefault(t => t.CodTicket == codTicket);
            tickets.Remove(ticket);
        }

        public TicketModel buscarTicketPorId(int codTicket)
        {
            return tickets.FirstOrDefault(t => t.CodTicket == codTicket);
        }
    }
}
