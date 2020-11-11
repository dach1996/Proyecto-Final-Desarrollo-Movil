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
        private TicketViewModel contexto;
        private ILocalesService localService = new LocalServiceImplDatos();
        public NuevoTicketView(TicketModel ticket = null)
        {

            InitializeComponent();
            contexto = new TicketViewModel(ticket);
            
            BindingContext = contexto;

        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            pruebaCommand();
        }

        private async Task pruebaCommand()
        {
            var consulta = localService.listarLocales();
            contexto.locales.Clear();
            foreach (var item in consulta)
            {
                contexto.locales.Add(item);
            }
        }
    }
}