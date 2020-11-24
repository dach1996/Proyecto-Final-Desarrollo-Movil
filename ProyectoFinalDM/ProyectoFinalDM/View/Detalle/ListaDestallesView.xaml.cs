using ProyectoFinalDM.Models;
using ProyectoFinalDM.ViewModel.Detalles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinalDM.View.Detalle
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaDestallesView : ContentPage
    {
        public ListaDestallesView(TicketModel ticket)
        {
            InitializeComponent();
            BindingContext = new ListaDetallesViewModel(ticket);
            //Nos suscribimos al evento
            MessagingCenter.Subscribe<object, object>(this, "MessageReceived", (sender, arg) => {
                LVTickets.ScrollTo(arg, ScrollToPosition.End, true);
            });
        }

        private void LVTickets_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
          
      
        }

        private void LVTickets_Refreshing(object sender, EventArgs e)
        {
 
        }
    }
}