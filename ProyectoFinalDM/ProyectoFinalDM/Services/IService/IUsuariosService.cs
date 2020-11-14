using ProyectoFinalDM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDM.Services.IService
{
    public interface IUsuariosService
    {
        UsuarioModel buscarUsuario(string username, string password);
        UsuarioModel buscarUsuarioId(int codUsuario);
        ObservableCollection<UsuarioModel> listarUsuarios();
        Task consultarJsonUsuarios();
    }
}
