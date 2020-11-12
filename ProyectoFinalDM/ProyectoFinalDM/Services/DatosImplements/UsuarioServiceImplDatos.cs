using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services.IService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDM.Services
{
    public class UsuarioServiceImplDatos : IUsuariosService
    {
        public static ObservableCollection<UsuarioModel> usuarios { get; set; }
        public static UsuarioModel usuario { get; set; }
        public UsuarioServiceImplDatos()
        {
            usuarios = new ObservableCollection<UsuarioModel>();
            usuarios.Add(new UsuarioModel {CodUsuario=1, ApellidoUsuario="Cárdenas ",NombreUsuario="Danny",PasswordUsuario="12345"});
            usuarios.Add(new UsuarioModel {CodUsuario=2, ApellidoUsuario="Moya", NombreUsuario="Alex",PasswordUsuario="12345"});
            usuarios.Add(new UsuarioModel {CodUsuario=3,ApellidoUsuario="Guadalupe", NombreUsuario="Adrian",PasswordUsuario="12345"});
        }
        public async Task <UsuarioModel> buscarUsuario(string username, string password)
        {
            await Task.Run(() =>
            {
                return   usuarios.FirstOrDefault(u => (u.UsernameUsuario == username || u.NombreUsuario == username) && u.PasswordUsuario == password);
            });
            return null;
           
        }

        public ObservableCollection<UsuarioModel> listarUsuarios()
        {
            return usuarios;
        }
    }
}
