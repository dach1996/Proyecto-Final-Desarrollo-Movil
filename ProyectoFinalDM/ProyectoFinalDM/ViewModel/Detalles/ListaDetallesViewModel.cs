using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services;
using ProyectoFinalDM.Services.IService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProyectoFinalDM.ViewModel.Detalles
{
    public class ListaDetallesViewModel
    {
        private IDetallesService detallesService = new DetalleServiceImplDatos();
        public ObservableCollection<DetalleModel> detalles { get; set; }

        public ListaDetallesViewModel(TicketModel ticket)
        {
            this.detalles = detallesService.listarDetalles();
        }

    }
}
