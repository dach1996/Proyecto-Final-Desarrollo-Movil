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
        private ListaDetallesViewModel listaDetallesViewModel;
        public ListaDestallesView(TicketModel ticket)
        {
            InitializeComponent();
            listaDetallesViewModel = new ListaDetallesViewModel(ticket);
            BindingContext = listaDetallesViewModel;
        }
    }
}