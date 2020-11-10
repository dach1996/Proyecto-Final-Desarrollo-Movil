using ProyectoFinalDM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalDM.Services.IService
{
    public interface IUsuariosService
    {
        UsuarioModel buscarUsuario(string username, string password);

    }
}
