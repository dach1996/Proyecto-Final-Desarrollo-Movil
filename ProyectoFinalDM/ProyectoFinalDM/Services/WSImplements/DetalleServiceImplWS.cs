using Newtonsoft.Json;
using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services.IService;
using ProyectoFinalDM.Services.WSImplements;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace ProyectoFinalDM.Services
{
    public class DetalleServiceImplWS : WSConnection<DetalleModel>, IDetallesService
    {
        IUsuariosService usuariosService = new UsuarioServiceImplWS();
        public ObservableCollection<DetalleModel> detalles { get; set; }
        public DetalleServiceImplWS(TicketModel modelo=null)
        {
             detalles= new ObservableCollection<DetalleModel>();
            base.httpClient = new HttpClient();
            base.Url = base.Url + "detalles.php";
        }
        public async Task guardarDetalle(DetalleModel detalle)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new NameValueCollection();
                parametros.Add("texto_detalle", detalle.TextoDetalle);
                parametros.Add("fecha_detalle", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                parametros.Add("cod_ticket", detalle.Ticket.CodTicket.ToString());
                parametros.Add("cod_usuario", detalle.Usuario.CodUsuario.ToString());
                var respuesta = cliente.UploadValues(base.Url, "POST", parametros);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void editarDetalle(DetalleModel detalle)
        {
          
        }

        public void eliminarDetalle(int codDetalle)
        {
        
        }

        public Task consultarJsonDetalles()
        {
            return null;
        }

        public async Task<ObservableCollection<DetalleModel>> buscarDetallesPorIdTicket(int codTicket)
        {
            var consultaSerializada = await httpClient.GetStringAsync(Url + "?cod_ticket=" + codTicket);
            var consultaDeserializada = JsonConvert.DeserializeObject<List<DetallePartialModel>>(consultaSerializada);
            this.detalles.Clear();
            foreach (var item in consultaDeserializada)
            {
                detalles.Add(new DetalleModel
                {
                   
                    CodDetalle = item.CodDetalle,
                    FechaDetalle = item.FechaDetalle,
                    TextoDetalle = item.TextoDetalle,
                    Usuario = usuariosService.buscarUsuarioId(item.CodUsuario)

                }) ;
            }
            return this.detalles;
        }
    }
}