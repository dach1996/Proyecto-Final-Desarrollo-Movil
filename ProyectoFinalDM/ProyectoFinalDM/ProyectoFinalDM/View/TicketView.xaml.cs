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
    public partial class TicketView : ContentPage
    {
        public TicketViewModel contexto;

        public TicketView()
        {
            InitializeComponent();
            contexto = new TicketViewModel();
            BindingContext = contexto;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NuevoTicketView());
        }
    }
}