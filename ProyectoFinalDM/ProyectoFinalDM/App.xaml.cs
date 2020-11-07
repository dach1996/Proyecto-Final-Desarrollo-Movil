using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinalDM
{
    public partial class App : Application
    {
        public static NavigationPage navegacion;
        public App()
        {
            InitializeComponent();
            navegacion= new NavigationPage(new Login());
            MainPage = navegacion;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
