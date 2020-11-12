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
   public class TicketServiceImplWS : WSConnection<TicketModel>, ITicketService
    {
        public TicketServiceImplWS()
        {
            base.httpClient = new HttpClient();
            base.Url = base.Url + "ticket.php";
        }
        private async Task consultarJson()
        { 

                var consultaSerializada = await  httpClient.GetStringAsync(Url);
                var consultaDeserializada = JsonConvert.DeserializeObject<List<TicketModel>>(consultaSerializada);
                consulta = new ObservableCollection<TicketModel>(consultaDeserializada);
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

        public TicketModel buscarTicketPorId(int codTicket)
        {
            throw new NotImplementedException();
        }
    }
}
