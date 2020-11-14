using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services.IService;
using ProyectoFinalDM.Services.WSImplements;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace ProyectoFinalDM.Services
{
    public class DetalleServiceImplDatos : IDetallesService
    {
        public static ObservableCollection<DetalleModel> detalles { get; set; }
        IUsuariosService usuarioService = new UsuarioServiceImplWS();
        ITicketService ticketService = new TicketServiceImplDatos();
        ObservableCollection<UsuarioModel> usuarios = new ObservableCollection<UsuarioModel>();
        ObservableCollection<TicketModel> tickets = new ObservableCollection<TicketModel>();
               

        public DetalleServiceImplDatos()
        {
            if (detalles == null) { 
                tickets = TicketServiceImplDatos.tickets;
            usuarios = usuarioService.listarUsuarios();
            detalles = new ObservableCollection<DetalleModel>();
          
            for (int i = 0; i < 60; i++)
            {
                 detalles.Add(new DetalleModel { CodDetalle = i, 
                    Usuario =  usuarios[new Random().Next(1,3)], 
                    FechaDetalle = DateTime.Now, 
                    Ticket = tickets [new Random().Next(1, 9)],
                    TextoDetalle = "Esto es el detalle del Ticket 1" });
            }
            }
        }
        public void editarDetalle(DetalleModel detalle)
        {
            for (int i = 0; i < detalles.Count; i++)
            {
                if (detalles[i].CodDetalle == detalle.CodDetalle)
                {
                    detalles[i] = detalle;
                }
            }

        }

        public void eliminarDetalle(int codDetalle)
        {
            detalles.ForEach(d =>
            {
                if (d.CodDetalle == codDetalle)
                {
                    detalles.Remove(d);
                }
            }
            );
        }

        public ObservableCollection<DetalleModel> listarDetalles()
        {
            return detalles;
        }

        public void nuevoDetalles(DetalleModel detalle)
        {
            detalle.CodDetalle=detalles.Count+1;
            detalles.Add(detalle);
        }

        public ObservableCollection<DetalleModel> buscarDetallesPorIdTicket(int codTicket)
        {
            var lista =detalles.Where(d => d.Ticket.CodTicket == codTicket).ToList();
            return new ObservableCollection<DetalleModel>(lista);
        }
    }
}
