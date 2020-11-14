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
    class ClientesServiceImplWS : WSConnection<ClienteModel>, IClienteService
    {
        public ClientesServiceImplWS()
        {
            base.httpClient = new HttpClient();
            base.Url = base.Url + "cliente.php";
        }
        public ClienteModel buscarCliente(int codCliente)
        {
            return StaticData.clientes.FirstOrDefault(c => c.CodCliente ==codCliente);
        }

        public  Task consultarJson()
        {
            try
            {
                return Task.Run(async () =>
                {
                    var consultaSerializada = await httpClient.GetStringAsync(Url);
                    var consultaDeserializada = JsonConvert.DeserializeObject<List<ClienteModel>>(consultaSerializada);
                    StaticData.clientes = new ObservableCollection<ClienteModel>(consultaDeserializada);
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public  ObservableCollection<ClienteModel> listarClientes()
        {
            return StaticData.clientes;
        }

    }
}
