using ProyectoFinalDM.Models;
using ProyectoFinalDM.ViewModel.Imagenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinalDM.View.Imagenes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaImagenesView : ContentPage
    {
        private TicketModel ticket;
        public ListaImagenesView(TicketModel ticket)
        {
            InitializeComponent();
            this.ticket = ticket;
        }
        protected override void OnAppearing()
        {
            BindingContext = new ListaImagenesViewModel(ticket);
            base.OnAppearing();
        }
    }
}