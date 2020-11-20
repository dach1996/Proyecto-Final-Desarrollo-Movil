using ProyectoFinalDM.INotifyProperty;
using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services.WSImplements;
using ProyectoFinalDM.View.Imagenes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoFinalDM.ViewModel.Imagenes
{
    public class ListaImagenesViewModel : Notificaciones
    {

        public ICommand nuevaImagenCommand { get; set; }

        ImagenesServiceImplWs imagenesService = new ImagenesServiceImplWs();
        private TicketModel ticket;

        public ListaImagenesViewModel(TicketModel ticket)
        {
            this.ticket = ticket;
            nuevaImagenCommand = new Command(nuevaImagen);

        }

        private void nuevaImagen(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new ImagenView(ticket));
        }
    }
}
