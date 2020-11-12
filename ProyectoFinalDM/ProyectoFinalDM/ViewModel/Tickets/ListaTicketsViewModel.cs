using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services;
using ProyectoFinalDM.Services.IService;
using ProyectoFinalDM.Services.WSImplements;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDM.ViewModel.Tickets
{
   
    class ListaTicketsViewModel : ProyectoFinalDM.INotifyProperty.Notificaciones
    {
        private ITicketService ticketService = new TicketServiceImplWS();

        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; this.OnPropertyChanged(); }
        }


        public ObservableCollection<TicketModel> tickets { get; set; }
        public ListaTicketsViewModel()
        {
            tickets = new ObservableCollection<TicketModel>();
            this.cargarTickets();
        }
        private void cargarTickets()
        {
            IsBusy = true;
            Task.Run(async () =>
            {
                var consulta = await ticketService.consultarTickets();
                foreach (var item in consulta)
                {
                    tickets.Add(item);
                }
                IsBusy = false;
            });
        
        }
    }
}
