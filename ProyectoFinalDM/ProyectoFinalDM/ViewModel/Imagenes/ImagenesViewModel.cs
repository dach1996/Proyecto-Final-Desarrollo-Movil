using Plugin.Media;
using ProyectoFinalDM.INotifyProperty;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoFinalDM.ViewModel.Imagenes
{
    class ImagenesViewModel: Notificaciones
    {
        public ICommand nuevaImagenCommand { get; set; }
        public ICommand cargarImagenCommand { get; set; }

        private ImageSource imagenSoruce;

        public ImageSource ImagenSource
        {
            get { return imagenSoruce; }
            set { imagenSoruce = value; this.OnPropertyChanged(); }
        }

        public ImagenesViewModel()
        {
            nuevaImagenCommand = new Command(nuevaImagen);
            cargarImagenCommand = new Command(cargarImagen);
        }
        private async void nuevaImagen()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await App.navegacion.DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000,
                DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front
            });

            if (file == null)
                return;

            await App.navegacion.DisplayAlert("File Location", file.Path, "OK");

            ImagenSource = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
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
            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,

            });


            if (file == null)
                return;

            ImagenSource = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }
    }
}
