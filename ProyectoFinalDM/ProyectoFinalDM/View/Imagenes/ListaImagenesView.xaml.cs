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
        public ListaImagenesView(TicketModel ticket)
        {
            InitializeComponent();
            BindingContext = new ListaImagenesViewModel(ticket);    
        }
    }
}