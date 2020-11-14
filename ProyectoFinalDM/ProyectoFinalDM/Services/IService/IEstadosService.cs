using ProyectoFinalDM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDM.Services.IService
{
    public interface IEstadosService
    {
        ObservableCollection<String> listarEstados();
        String buscarEstado(string estado);
        Task consultarEstados();
    }
}
