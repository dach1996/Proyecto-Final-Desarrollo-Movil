using ProyectoFinalDM.INotifyProperty;
using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services;
using ProyectoFinalDM.Services.IService;
using ProyectoFinalDM.Services.WSImplements;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoFinalDM.ViewModel.Detalles
{
    public class ListaDetallesViewModel : Notificaciones
    {
        private IDetallesService detallesService = new DetalleServiceImplWS();
        private DetalleModel detalleModel;

        public DetalleModel detalle
        {
            get { return detalleModel; }
            set { detalleModel = value; this.OnPropertyChanged(); }
        }

        public ObservableCollection<DetalleModel> detalles { get; set; }

        public TicketModel ticket { get; set; }
        public Command guardarDetalleCommnad { get; set; }
        public ListaDetallesViewModel(TicketModel ticket)

        {
            detalles = new ObservableCollection<DetalleModel>();
            detalle = new DetalleModel();
            this.ticket = ticket;
            cargarDatosTicket();
            this.guardarDetalleCommnad = new Command(() => guardarDetalle());
        }
        private async void cargarDatosTicket()
        {
            IsBusy = true;
            await Task.Run(async () =>
            {
                var consulta = await detallesService.buscarDetallesPorIdTicket(ticket.CodTicket);
                this.detalles.Clear();
                foreach (var item in consulta)
                {
                    detalles.Add(item);
                }
                IsBusy = false;
            });

        }


        private void guardarDetalle()
        {
            this.detalle.Usuario = StaticData.usuaroLogeado;
            this.detalle.Ticket = this.ticket;
            detallesService.guardarDetalle(this.detalle);
            cargarDatosTicket();
            this.detalle.TextoDetalle = "";
        }


    }
}
