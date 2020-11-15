using Newtonsoft.Json;
using ProyectoFinalDM.Models;
using ProyectoFinalDM.Models.PartialModels;
using ProyectoFinalDM.Services.IService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProyectoFinalDM.Services.WSImplements
{
    public class TicketServiceImplWS : WSConnection<TicketModel>, ITicketService
    {

        private IUsuariosService usuariosService = new UsuarioServiceImplWS();
        private IClienteService clienteService = new ClientesServiceImplWS();
        private ILocalesService localService = new LocalesServiceImplWS();
        private ICategoriasService categoriaService = new CategoriaServiceImplWS();
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
                        CodTicket = item.CodTicket,
                        TituloTicket = item.TituloTicket,
                        FechaTicket = item.FechaTicket,
                        FechaFinTicket = item.FechaFinTicket,
                        Estado = item.Estado,
                        Usuario = usuariosService.buscarUsuarioId(item.CodUsuario),
                        Cliente = clienteService.buscarCliente(item.CodCliente),
                        Local = localService.buscarLocal(item.CodLocal),
                        PrioridadTicket=item.PrioridadTicket,
                        Categoria = categoriaService.buscarCategoria(item.CodCategoria)
                    }) ;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        public async void guardarTicket(TicketModel ticketModel)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new NameValueCollection();
                parametros.Add("cod_local", ticketModel.Local.CodLocal.ToString());
                parametros.Add("titulo_ticket", ticketModel.TituloTicket);
                parametros.Add("fecha_inicio_ticket", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                parametros.Add("estado_ticket", ticketModel.Estado);
                parametros.Add("prioridad_ticket", ticketModel.PrioridadTicket);
                parametros.Add("cod_usuario", ticketModel.Usuario.CodUsuario.ToString());
                parametros.Add("cod_cliente", ticketModel.Cliente.CodCliente.ToString());
                parametros.Add("cod_categoria", ticketModel.Categoria.CodCategoria.ToString());
                var respuesta= cliente.UploadValues(base.Url, "POST", parametros);
                await App.Current.MainPage.DisplayAlert("Alerta", "Dato ingresado Correctamente", "ok");
                await App.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public async void modificarTicket(TicketModel ticketModel)
        {
            try
            {
                var builder = new UriBuilder(Url);
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["cod_ticket"] = ticketModel.CodTicket.ToString();
                query["cod_local"] = ticketModel.Local.CodLocal.ToString();
                query["titulo_ticket"] = ticketModel.TituloTicket;
                query["prioridad_ticket"] = ticketModel.PrioridadTicket;
                query["cod_cliente"] = ticketModel.Cliente.CodCliente.ToString();
                query["cod_categoria"] = ticketModel.Categoria.CodCategoria.ToString();
                builder.Query = query.ToString();
                string url = builder.ToString();
                var consultaSerializada = await httpClient.PutAsync(url, null);
                await App.Current.MainPage.DisplayAlert("Alerta", "Dato Guardado Correctamente", "ok");
                await App.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public async void eliminarTicket(int codTicket)
        {
           await httpClient.DeleteAsync(Url + "?cod_ticket="+codTicket);
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
