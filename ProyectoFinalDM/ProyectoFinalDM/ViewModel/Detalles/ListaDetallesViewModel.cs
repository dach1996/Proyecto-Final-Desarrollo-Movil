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

        public ListaDetallesViewModel(TicketModel ticket)
        {
            detalle = new DetalleModel();
            this.detalles = detallesService.listarDetalles();
            this.guardarDetalleCommnad = new Command(async () => await guardarDetalle());
        }

        public Command guardarDetalleCommnad { get; set; }

        private async Task guardarDetalle()
        {
            detallesService.nuevoDetalles(detalle);
        }


    }
}
