using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services;
using ProyectoFinalDM.Services.IService;
using ProyectoFinalDM.Services.WSImplements;
using ProyectoFinalDM.ViewModel;
using ProyectoFinalDM.ViewModel.Tickets;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinalDM.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicketView : ContentPage
    {
        public TicketView()
        {
            InitializeComponent();
            LVTickets.ItemTapped += LVTickets_ItemTapped;
        }


        protected override void OnAppearing()
        {
            BindingContext = new ListaTicketsViewModel();
            base.OnAppearing();
        }
        private async void LVTickets_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var modelo = (TicketModel)e.Item;
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