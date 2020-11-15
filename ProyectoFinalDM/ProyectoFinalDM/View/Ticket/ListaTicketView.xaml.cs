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
        }


        protected override void OnAppearing()
        {
            BindingContext = new ListaTicketsViewModel();
            base.OnAppearing();
        }


    }
}