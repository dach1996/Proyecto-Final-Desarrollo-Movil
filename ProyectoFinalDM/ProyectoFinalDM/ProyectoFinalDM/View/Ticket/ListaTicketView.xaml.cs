using ProyectoFinalDM.Models;
using ProyectoFinalDM.ViewModel;
using ProyectoFinalDM.ViewModel.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinalDM.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicketView : ContentPage
    {
        private TicketViewModel ticketViewModel;
        public TicketView()
        {
            InitializeComponent();
            ticketViewModel = new TicketViewModel();
            BindingContext = ticketViewModel;
            LVTickets.ItemTapped += LVTickets_ItemTapped;
        }



        private async void LVTickets_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            TicketModel modelo = new TicketModel();
            modelo = (TicketModel)e.Item;
            if (e.Item == null) return;
            ((ListView)sender).SelectedItem = null;
            await Navigation.PushAsync(new NuevoTicketView(modelo));
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NuevoTicketView());
        }
    }
}