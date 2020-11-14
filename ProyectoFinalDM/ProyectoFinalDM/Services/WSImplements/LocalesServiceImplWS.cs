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
    public class LocalesServiceImplWS : WSConnection<LocalModel>, ILocalesService
    {

        public LocalesServiceImplWS()
        {
            base.httpClient = new HttpClient();
            base.Url = base.Url + "local.php";
        }
        public Task consultarJsonLocal()
        {
            return Task.Run(async()=>{
                var consultaSerializada = await httpClient.GetStringAsync(Url);
                var consultaDeserializada = JsonConvert.DeserializeObject<List<LocalModel>>(consultaSerializada);
                StaticData.locales = new ObservableCollection<LocalModel>(consultaDeserializada);
            });
        }
        public ObservableCollection<LocalModel> listarLocales()
        {
            return StaticData.locales;
        }

        public LocalModel buscarLocal(int codLocal)
        {
            return StaticData.locales.FirstOrDefault(l=>l.CodLocal==codLocal);
        }
    }
}
