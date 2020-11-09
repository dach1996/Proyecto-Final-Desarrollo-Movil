using ProyectoFinalDM.Models;
using ProyectoFinalDM.ViewModel;
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
    public partial class NuevoTicketView : ContentPage
    {
        private TicketViewModel contexto;

        public NuevoTicketView(TicketModel ticket = null)
        {

            InitializeComponent();
            contexto = new TicketViewModel(ticket);
            BindingContext = contexto;

        }

    
    }
}