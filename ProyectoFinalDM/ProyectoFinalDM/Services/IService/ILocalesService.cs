using ProyectoFinalDM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDM.Services.IService
{
    public interface ILocalesService
    {
        ObservableCollection<LocalModel> listarLocales();
        LocalModel buscarLocal(int codLocal);
        Task consultarJsonLocal();
    }
}
