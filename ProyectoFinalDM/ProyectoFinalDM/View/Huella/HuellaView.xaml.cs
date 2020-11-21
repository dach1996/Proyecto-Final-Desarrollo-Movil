using ProyectoFinalDM.ViewModel.Huella;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinalDM.View.Huella
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HuellaView : ContentPage
    {
        public HuellaView()
        {
            InitializeComponent();
            BindingContext = new HuellaViewModel();
        }
    }
}