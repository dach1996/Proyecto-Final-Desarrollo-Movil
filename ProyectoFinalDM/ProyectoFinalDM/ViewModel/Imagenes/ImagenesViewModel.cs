using Plugin.Media;
using Plugin.Media.Abstractions;
using ProyectoFinalDM.INotifyProperty;
using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services.WSImplements;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoFinalDM.ViewModel.Imagenes
{
    class ImagenesViewModel : Notificaciones
    {
        public ICommand nuevaImagenCommand { get; set; }
        public ICommand cargarImagenCommand { get; set; }

        public ICommand guardarImagenCommand { get; set; }
        private ImageSource imagenSoruce;
        private MediaFile imagen;
        private TicketModel ticket;
        private ImagenesServiceImplWs imagenesService = new ImagenesServiceImplWs();
        public ImageSource ImagenSource
        {
            get { return imagenSoruce; }
            set { imagenSoruce = value; this.OnPropertyChanged(); }
        }

        public ImagenesViewModel(TicketModel ticket)
        {
            this.ticket = ticket;
            nuevaImagenCommand = new Command(nuevaImagen);
            cargarImagenCommand = new Command(cargarImagen);
            guardarImagenCommand = new Command(guardarImagen);
        }

        private async void guardarImagen()
        {
            this.IsBusy = true;
            await Task.Run(() =>
            {
                ImagenesModel modeloImagen = new ImagenesModel();
                modeloImagen.CodTicket = this.ticket.CodTicket;
                imagenesService.guardarImagen(modeloImagen, imagen);
                this.IsBusy = false;
              
                
            });
            await App.Current.MainPage.DisplayAlert("Éxito", "Imagen cargada Correctamente", "Continuar");
            imagen.Dispose();
            await App.Current.MainPage.Navigation.PopAsync();

        }

        private async void nuevaImagen()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await App.navegacion.DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            imagen = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000,
                DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front
            });

            if (imagen == null)
                return;

            await App.navegacion.DisplayAlert("File Location", imagen.Path, "OK");

            ImagenSource = ImageSource.FromStream(() =>
            {
                var stream = imagen.GetStream();
                return stream;
            });

        }

        private async void cargarImagen()
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await App.navegacion.DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return;
            }
            imagen = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,

            });


            if (imagen == null)
                return;

            ImagenSource = ImageSource.FromStream(() =>
            {
                var stream = imagen.GetStream();
                return stream;
            });
        }
    }
}
