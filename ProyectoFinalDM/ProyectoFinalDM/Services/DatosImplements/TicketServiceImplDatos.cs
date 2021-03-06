﻿using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services.IService;
using ProyectoFinalDM.Services.WSImplements;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

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
                ClienteServiceImplDatos clientesService = new ClienteServiceImplDatos();
                CategoriaServiceImplDatos categoriaService = new CategoriaServiceImplDatos();
                IUsuariosService usuarioService = new UsuarioServiceImplWS();
                IPrioridadService prioridadesService = new PrioridadServiceImplDatos();
                LocalServiceImplDatos localService = new LocalServiceImplDatos();
                ObservableCollection<ClienteModel> clientes = new ObservableCollection<ClienteModel>();
                ObservableCollection<CategoriaModel> categorias = new ObservableCollection<CategoriaModel>();
                ObservableCollection<PrioridadModel> prioridades = new ObservableCollection<PrioridadModel>();
                ObservableCollection<UsuarioModel> usuarios = new ObservableCollection<UsuarioModel>();
                ObservableCollection<LocalModel> locales = new ObservableCollection<LocalModel>();
                clientes = clientesService.listarClientes();
                categorias = categoriaService.listarCategorias();

                usuarios = usuarioService.listarUsuarios();
                locales = localService.listarLocales();
                for (int a = 0; a < 10; a++)
                {
                    tickets.Add(new TicketModel()
                    {
                        CodTicket =  (a+1),
                        Estado = "Ingresado",
                        FechaFinTicket = new DateTime(),
                        FechaTicket = new DateTime(),
                        Local = locales[new Random().Next(1, 5)],
                        TituloTicket = "Coordinar para cambiar Sensor",
                     
                        Usuario = usuarios[new Random().Next(1,3)],
                        Cliente = clientes[new Random().Next(1, 3)],
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

        Task<ObservableCollection<TicketModel>> ITicketService.consultarTickets()
        {
            throw new NotImplementedException();
        }

        Task<TicketModel> ITicketService.buscarTicketPorId(int codTicket)
        {
            throw new NotImplementedException();
        }
    }
}
