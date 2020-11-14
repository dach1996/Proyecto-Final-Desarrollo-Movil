using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services;
using ProyectoFinalDM.Services.IService;
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
        public NuevoTicketView(TicketModel ticket = null)
        {
            InitializeComponent();      
            BindingContext = new TicketViewModel(ticket); 

        }

  

    }
}