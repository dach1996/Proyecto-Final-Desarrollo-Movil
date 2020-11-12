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
        private async Task consultarJson()
        { 

                var consultaSerializada = await  httpClient.GetStringAsync(Url);
                var consultaDeserializada = JsonConvert.DeserializeObject<List<UsuarioModel>>(consultaSerializada);
                consulta = new ObservableCollection<UsuarioModel>(consultaDeserializada);
        }
        public async Task<UsuarioModel> buscarUsuario(string username, string password)
        {
            await this.consultarJson();
            return consulta.FirstOrDefault(u => u.UsernameUsuario == username && u.PasswordUsuario == password);
        }

        public ObservableCollection<UsuarioModel> listarUsuarios()
        {

            return consulta;
        }

 
    }
}
