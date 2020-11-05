using ProyectoFinalDM.Models;
using System.Collections.ObjectModel;

namespace ProyectoFinalDM.Services.IService
{
    public interface IClienteService
    {
        ObservableCollection<ClienteModel> listarClientes();
    }
}
