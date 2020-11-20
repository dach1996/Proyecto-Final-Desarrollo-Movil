using ProyectoFinalDM.INotifyProperty;
using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services.WSImplements;
using ProyectoFinalDM.View.Imagenes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoFinalDM.ViewModel.Imagenes
{
    public class ListaImagenesViewModel : Notificaciones
    {
        public ObservableCollection<ImagenesModel> imagenes { get; set; }
        public ICommand nuevaImagenCommand { get; set; }

        ImagenesServiceImplWs imagenesService = new ImagenesServiceImplWs();
        private TicketModel ticket;

        public ListaImagenesViewModel(TicketModel ticket)
        {
            this.ticket = ticket;
            nuevaImagenCommand = new Command(nuevaImagen);
            this.imagenes = new ObservableCollection<ImagenesModel>();
            listarImagenes(this.ticket);
        }

        private void nuevaImagen(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new ImagenView(ticket));
        }

        private async void listarImagenes(TicketModel ticket)
        {
            
            IsBusy = true;
            await Task.Run(async () =>
            {
                var consulta = await imagenesService.listarImagenesPorId(ticket.CodTicket);
                this.imagenes.Clear();
                foreach (var item in consulta)
                {
                    imagenes.Add(item);
                }
                IsBusy = false;
            });
        }
    }
}
