using Newtonsoft.Json;
using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services.IService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDM.Services.WSImplements
{
    public class UsuarioServiceImplWS : WSConnection<UsuarioModel>, IUsuariosService
    {

        public UsuarioServiceImplWS()
        {
            base.httpClient = new HttpClient();
            base.Url = base.Url + "usuario.php";
        }
        public Task consultarJsonUsuarios()
        {
            return Task.Run(async()=>{
                var consultaSerializada = await httpClient.GetStringAsync(Url);
                var consultaDeserializada = JsonConvert.DeserializeObject<List<UsuarioModel>>(consultaSerializada);
                StaticData.usuarios = new ObservableCollection<UsuarioModel>(consultaDeserializada);
            });
        }
        public  UsuarioModel buscarUsuario(string username, string password)
        {
            return StaticData.usuarios.FirstOrDefault(u => u.UsernameUsuario == username && u.PasswordUsuario == password);
           
        }

        public ObservableCollection<UsuarioModel> listarUsuarios()
        {
            return StaticData.usuarios;
        }

        public UsuarioModel buscarUsuarioId(int codUsuario)
        {
            return StaticData.usuarios.FirstOrDefault(u => u.CodUsuario==codUsuario);

        }
    }
}
