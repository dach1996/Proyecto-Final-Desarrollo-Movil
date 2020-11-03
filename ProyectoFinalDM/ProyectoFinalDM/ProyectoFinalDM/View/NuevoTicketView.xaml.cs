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
        private TicketViewModel contexto = new TicketViewModel();
        public NuevoTicketView()
        {
            InitializeComponent();
            BindingContext = contexto;
            lvTickets.ItemSelected += LvTickets_ItemSelected;
        }

        private void LvTickets_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                TicketModel modelo = (TicketModel)e.SelectedItem;
                
            }
        }
    }
}