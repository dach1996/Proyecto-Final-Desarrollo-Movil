using ProyectoFinalDM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProyectoFinalDM.Services.IService
{
    public interface IDetallesService
    {
        ObservableCollection<DetalleModel> listarDetalles();
        void nuevoDetalles(DetalleModel detalle);
        void editarDetalle(DetalleModel detalle);
        void eliminarDetalle(int codDetalle);

    }
}
