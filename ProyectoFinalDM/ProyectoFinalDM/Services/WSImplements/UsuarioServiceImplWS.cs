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
   public class UsuarioServiceImplWS : IUsuariosService
    {
        private string Url;
        private HttpClient httpClient;
        private ObservableCollection<UsuarioModel> usuarios;

        
        public UsuarioServiceImplWS()
        {
            httpClient = new HttpClient();
            Url = "http://192.168.100.29/WebService/Api/usuario.php";
        } 
        private async Task consultarJson()
        { 
                var consultaSerializada = await httpClient.GetStringAsync(Url);
                var consultaDeserializada = JsonConvert.DeserializeObject<List<UsuarioModel>>(consultaSerializada);
                usuarios = new ObservableCollection<UsuarioModel>(consultaDeserializada);
        }
        public async Task<UsuarioModel> buscarUsuario(string username, string password)
        {
            await this.consultarJson();
            return usuarios.FirstOrDefault(u => u.UsernameUsuario == username && u.PasswordUsuario == password);
        }

        public ObservableCollection<UsuarioModel> listarUsuarios()
        {
            this.consultarJson();
            return usuarios;
        }

 
    }
}
