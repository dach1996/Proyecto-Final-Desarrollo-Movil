using ProyectoFinalDM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDM.Services.IService
{
    public interface IDetallesService
    {
        void guardarDetalle(DetalleModel detalle);
        void editarDetalle(DetalleModel detalle);
        void eliminarDetalle(int codDetalle);
        Task consultarJsonDetalles();
        Task<ObservableCollection<DetalleModel>> buscarDetallesPorIdTicket(int codTicket);

    }
}
