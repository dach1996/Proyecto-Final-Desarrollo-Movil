using Newtonsoft.Json;
using ProyectoFinalDM.Models;
using ProyectoFinalDM.Models.PartialModels;
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
    public class TicketServiceImplWS : WSConnection<TicketModel>, ITicketService
    {

        private IUsuariosService usuariosService = new UsuarioServiceImplWS();
        public TicketServiceImplWS()
        {
            base.httpClient = new HttpClient();
            base.Url = base.Url + "ticket.php";
        }
        private async Task consultarJson()
        {
            try
            {
                consulta = new ObservableCollection<TicketModel>();
                var consultaSerializada = await httpClient.GetStringAsync(Url);
                var consultaDeserializada = JsonConvert.DeserializeObject<List<TicketPartialModel>>(consultaSerializada);
                foreach (var item in consultaDeserializada)
                {
                    consulta.Add(new TicketModel {
                        CodTicket=item.CodTicket,
                        TituloTicket = item.TituloTicket,
                        FechaFinTicket = item.FechaTicket,
                        Cliente = new ClienteModel { NombreCliente=item.NombreCliente},
                        Local = new LocalModel { NombreLocal = item.NombreLocal},
                        Categoria = new CategoriaModel { NombreCategoria= item.NombreCategoria},
                        Estado = item.Estado
                    });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        public void guardarTicket(TicketModel ticketModel)
        {
            throw new NotImplementedException();
        }

        public void modificarTicket(TicketModel ticketModel)
        {
            throw new NotImplementedException();
        }

        public void eliminarTicket(int codTicket)
        {
            throw new NotImplementedException();
        }

        public async Task<ObservableCollection<TicketModel>> consultarTickets()
        {
            await this.consultarJson();
            return consulta;
        }

        public async Task<TicketModel> buscarTicketPorId(int codTicket)
        {
            try
            {
                var consultaSerializada = await httpClient.GetStringAsync(Url + "?cod_ticket=" + codTicket);
                var consultaDeserializada = JsonConvert.DeserializeObject<TicketModel>(consultaSerializada);
                return consultaDeserializada;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            
        }
    }
}
