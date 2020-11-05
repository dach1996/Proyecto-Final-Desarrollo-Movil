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
    public partial class ClienteView : ContentPage
    {
        private ClienteViewModel clienteViewModel;
        public ClienteView()
        {
            
            InitializeComponent();
            clienteViewModel = new ClienteViewModel();
            BindingContext = clienteViewModel;
            
        }

        private void clienteSeleccionado(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}