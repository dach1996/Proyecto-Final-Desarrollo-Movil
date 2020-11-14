using ProyectoFinalDM.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ProyectoFinalDM.Services.IService
{
    public interface IClienteService
    {
        ObservableCollection<ClienteModel> listarClientes();
        ClienteModel buscarCliente(int  codCliente);
        Task consultarJsonCliente();
    }
}
