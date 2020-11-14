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
    public class CategoriaServiceImplWS : WSConnection<CategoriaModel>, ICategoriasService
    {

        public CategoriaServiceImplWS()
        {
            base.httpClient = new HttpClient();
            base.Url = base.Url + "categoria.php";
        }
  

        public ObservableCollection<CategoriaModel> listarCategorias()
        {
            return StaticData.categorias;
        }

        public Task consultarJsonCategoria()
        {
            return Task.Run(async () => {
                var consultaSerializada = await httpClient.GetStringAsync(Url);
                var consultaDeserializada = JsonConvert.DeserializeObject<List<CategoriaModel>>(consultaSerializada);
                StaticData.categorias = new ObservableCollection<CategoriaModel>(consultaDeserializada);
            });
        }

        public CategoriaModel buscarCategoria(int codCategoria)
        {
            return StaticData.categorias.FirstOrDefault(c => c.CodCategoria==codCategoria);
        }
    }
}
