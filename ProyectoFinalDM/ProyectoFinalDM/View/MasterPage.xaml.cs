using ProyectoFinalDM.Models.MasterPage;
using ProyectoFinalDM.ViewModel.MaterPage;
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
    public partial class MasterPage : ContentPage
    {

        public MasterPage()
        {
            InitializeComponent();
            BindingContext = new MasterPageViewModel();
            NavigationDrawerList.ItemSelected += NavigationDrawerList_ItemSelected; 
        }

        private void NavigationDrawerList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MaterPageItems)e.SelectedItem;
            Type page = item.Pagina;
            App.PaginaMaestra.Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            App.PaginaMaestra.IsPresented = false;
        }

    }
}