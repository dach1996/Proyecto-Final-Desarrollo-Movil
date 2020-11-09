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
        }
    }
}