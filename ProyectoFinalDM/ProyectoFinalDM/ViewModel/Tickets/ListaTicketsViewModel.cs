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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoFinalDM.ViewModel.Tickets
{

    class ListaTicketsViewModel : Notificaciones
    {
        private ITicketService ticketService = new TicketServiceImplWS();

        public ObservableCollection<TicketModel> tickets { get; set; }

        public ICommand verDetallesCommand { get; set; }
        public ICommand nuevoTicketCommand { get; set; }
        public ICommand editarTicketCommand { get; set; }
        public ICommand eliminarTicketCommand { get; set; }
        public ListaTicketsViewModel()
        {
            tickets = new ObservableCollection<TicketModel>();
            verDetallesCommand = new Command(verDetalles);
            nuevoTicketCommand = new Command(nuevoTicket);
            editarTicketCommand = new Command(editarTicket);
            eliminarTicketCommand = new Command(eliminarTicket);
            this.cargarTickets();
        }

        private async void eliminarTicket(Object o)
        {
            bool pregunta = await App.navegacion.DisplayAlert("Advertencia", "Desea eliminar este registro", "Sí", "No");
            if (pregunta)
            {
                var modelo = (TicketModel)o;
                await Task.Run(() => {
                    ticketService.eliminarTicket(modelo.CodTicket);
                });
                this.cargarTickets();
            }
        }

        private async void editarTicket(Object o)
        {
            var modelo = (TicketModel)o;
            await App.navegacion.PushAsync(new NuevoTicketView(modelo));
        }

        private async void nuevoTicket()
        {
            await App.navegacion.PushAsync(new NuevoTicketView());
        }

        private async void verDetalles(Object o)
        {
            var modelo = (TicketModel)o;
            await App.navegacion.PushAsync(new ListaDestallesView(modelo));
        }

        private  async void cargarTickets()
        {
            IsBusy = true;
            await Task.Run(async () =>
            {
                var consulta = await ticketService.consultarTickets();
                this.tickets.Clear();
                foreach (var item in consulta)
                {
                    tickets.Add(item);
                }
                IsBusy = false;
            });
        }
    }
}
