using ProyectoFinalDM.INotifyProperty;
using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services;
using ProyectoFinalDM.Services.IService;
using ProyectoFinalDM.Services.WSImplements;
using ProyectoFinalDM.View;
using ProyectoFinalDM.View.Detalle;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoFinalDM.ViewModel
{
    public class TicketViewModel : Notificaciones
    {
        //Servicios
        private ITicketService ticketService = new TicketServiceImplWS();
        public TicketModel ticket { get; set; }
        public ObservableCollection<String> estados { get; set; }
        public ObservableCollection<ClienteModel> clientes { get; set; }
        public ObservableCollection<CategoriaModel> categorias { get; set; }
        public ObservableCollection<LocalModel> locales { get; set; }
        public ObservableCollection<String> prioridades { get; set; }
        public Command guardarTicketCommand { get; set; }
        public TicketViewModel(TicketModel ticket = null)
        {
           

            prioridades = StaticData.prioridades;
            clientes = StaticData.clientes;
            categorias = StaticData.categorias;
            locales = StaticData.locales;
            estados = StaticData.estados;

            if (ticket == null)
            {
                this.ticket = new TicketModel();
                this.ticket.Estado = ("Ingresado");
                this.ticket.Usuario = StaticData.usuaroLogeado;
            }
            else
            {
                this.ticket = ticket;
            }
            guardarTicketCommand = new Command(this.guardarTicket);
        }
        /* COMO RECORRER UN OBJETO
        private async void cargarDatosTicket(int codigoTicket)
        {
            IsBusy = true;
            var consulta = await ticketService.buscarTicketPorId(codigoTicket);
            PropertyInfo[] properties = typeof(TicketModel).GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                properties[i].SetValue(this.ticket, properties[i].GetValue(consulta));
            }
            await this.cargarClienteTicket();
            IsBusy = false;

        }*/


        private void guardarTicket()
        {
            if (ticket.CodTicket == 0)
            {
                ticketService.guardarTicket(this.ticket);
            }
            else
            {
                ticketService.modificarTicket(ticket);
            }
            //await App.navegacion.PopAsync();
        }


    }
}
