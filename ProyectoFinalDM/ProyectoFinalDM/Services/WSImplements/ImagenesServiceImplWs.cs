using Newtonsoft.Json;
using Plugin.Media.Abstractions;
using ProyectoFinalDM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoFinalDM.Services.WSImplements
{
    public class ImagenesServiceImplWs : WSConnection<ImagenesModel>
    {
        public ImagenesServiceImplWs()
        {
            base.httpClient = new HttpClient();
            base.Url = base.Url + "imagen.php";
        }
        public async void guardarImagen(ImagenesModel modelo, MediaFile imagen)
        {

            //Nombre de imagen
            FileInfo imagenInformacion = new FileInfo(imagen.Path);
            var nombreImagen = imagenInformacion.Name;
            //Hacemos el post con la información
            httpClient = new HttpClient();

            //Conseguir Imagen y transformarla a tipo Input html
            FileStream fileStream = File.OpenRead(imagen.Path);
            var streamContent = new StreamContent(fileStream);
            var fileContent = new ByteArrayContent(streamContent.ReadAsByteArrayAsync().Result);
            //Crear Multipart
            var formContent = new MultipartFormDataContent(/* If you need a boundary, you can define it here */);
            formContent.Add(fileContent, "imagen", nombreImagen);
            formContent.Add(new StringContent(modelo.CodTicket.ToString()), "cod_ticket");
            formContent.Add(new StringContent(this.rutaBaseImagenes(modelo.CodTicket.ToString(), nombreImagen)), "ruta_imagen");
            formContent.Add(new StringContent(this.nombreUnicoArchivo(nombreImagen)), "nombre_archivo");
            //enviar post
            try
            {
                var response = await httpClient.PostAsync(Url, formContent);
                fileStream.Dispose();
                streamContent.Dispose();
            }
            catch (Exception e)
            {    
            
            }

            

        }

        public async Task<ObservableCollection<ImagenesModel>> listarImagenesPorId(int codTicket)
        {
            try
            {
                consulta = new ObservableCollection<ImagenesModel>();
                var consultaSerializada = await httpClient.GetStringAsync(Url+"?cod_ticket="+codTicket);
                var consultaDeserializada = JsonConvert.DeserializeObject<List<ImagenesModel>>(consultaSerializada);
                this.consulta.Clear();
                foreach (var item in consultaDeserializada)
                {
                    consulta.Add(new ImagenesModel
                    {
                        CodImagen = item.CodImagen,
                        RutaImagen = item.RutaImagen,
                        CodTicket = item.CodTicket,
                    });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return this.consulta;
        }

        private string nombreUnicoArchivo(string nombreOriginal)
        {
            return Guid.NewGuid().ToString() + "_" + nombreOriginal.Replace(" ", "_");
        }
        private string rutaBaseImagenes(string carpetaTicket, string nombreArchivo)
        {
            var rutaFinal = "bdd_imagenes/" + carpetaTicket + "/" + this.nombreUnicoArchivo(nombreArchivo);
            return rutaFinal;
        }

    }
}
