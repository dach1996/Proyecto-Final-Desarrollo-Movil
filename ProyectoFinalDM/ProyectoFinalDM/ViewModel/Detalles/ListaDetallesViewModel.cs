using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services;
using ProyectoFinalDM.Services.IService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoFinalDM.ViewModel.Detalles
{
    public class ListaDetallesViewModel
    {
        private IDetallesService detallesService = new DetalleServiceImplDatos();
        public DetalleModel detalle { get; set; }
        public ObservableCollection<DetalleModel> detalles { get; set; }
        private TicketModel ticket;

        public ListaDetallesViewModel(TicketModel ticket)

        {
            detalle = new DetalleModel();
            this.ticket = ticket;
            this.detalles = detallesService.buscarDetallesPorIdTicket(ticket.CodTicket);
            this.guardarDetalleCommnad = new Command(()=>guardarDetalle());
        }

        public Command guardarDetalleCommnad { get; set; }

        private void guardarDetalle()
        {
           
            detalle.Usuario = UsuarioServiceImplDatos.usuario;
            detalle.FechaDetalle = new DateTime();
            detalle.Ticket = ticket;
            detallesService.nuevoDetalles(detalle);
            detalles.Add(detalle);
        }


    }
}
