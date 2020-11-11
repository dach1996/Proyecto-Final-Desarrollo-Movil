using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services.IService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ProyectoFinalDM.Services
{
    public class UsuarioServiceImplDatos : IUsuariosService
    {
        public static ObservableCollection<UsuarioModel> usuarios { get; set; }
        public static UsuarioModel usuario { get; set; }
        public UsuarioServiceImplDatos()
        {
            usuarios = new ObservableCollection<UsuarioModel>();
            usuarios.Add(new UsuarioModel {CodUsuario=1, NombreUsuario="Danny",PasswordUsuario="12345"});
            usuarios.Add(new UsuarioModel {CodUsuario=2, NombreUsuario="Alex",PasswordUsuario="Moya"});
            usuarios.Add(new UsuarioModel {CodUsuario=3, NombreUsuario="Adrian",PasswordUsuario="Guadalpue"});
        }
        public UsuarioModel buscarUsuario(string username, string password)
        {
            return usuarios.FirstOrDefault(u=> (u.UsernameUsuario==username || u.NombreUsuario== username)&& u.PasswordUsuario==password);
        }

        public ObservableCollection<UsuarioModel> listarUsuarios()
        {
            return usuarios;
        }
    }
}
