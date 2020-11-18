using ProyectoFinalDM.View;
using ProyectoFinalDM.View.Detalle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoFinalDM
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            App.PaginaMaestra = this;
            this.Master = new MasterPage();
            this.Detail = new NavigationPage(new TicketView());
        }
    }
}
