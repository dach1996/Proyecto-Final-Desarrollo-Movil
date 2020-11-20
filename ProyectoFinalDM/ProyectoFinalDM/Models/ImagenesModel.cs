using ProyectoFinalDM.INotifyProperty;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalDM.Models
{
    public class ImagenesModel: Notificaciones
    {
        private int codImagen;

        public int CodImagen
        {
            get { return codImagen; }
            set { codImagen = value; this.OnPropertyChanged(); }
        }

        private String rutaImagen;

        public String RutaImagen
        {
            get { return rutaImagen; }
            set { rutaImagen = value; this.OnPropertyChanged(); }
        }

        private int codTicket;

        public int CodTicket
        {
            get { return codTicket; }
            set { codTicket = value; this.OnPropertyChanged(); }
        }

        public override bool Equals(object obj)
        {
            return obj is ImagenesModel model &&
                   IsBusy == model.IsBusy &&
                   codImagen == model.codImagen &&
                   CodImagen == model.CodImagen &&
                   rutaImagen == model.rutaImagen &&
                   RutaImagen == model.RutaImagen &&
                   codTicket == model.codTicket &&
                   CodTicket == model.CodTicket;
        }

        public override int GetHashCode()
        {
            int hashCode = -117144010;
            hashCode = hashCode * -1521134295 + IsBusy.GetHashCode();
            hashCode = hashCode * -1521134295 + codImagen.GetHashCode();
            hashCode = hashCode * -1521134295 + CodImagen.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(rutaImagen);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(RutaImagen);
            hashCode = hashCode * -1521134295 + codTicket.GetHashCode();
            hashCode = hashCode * -1521134295 + CodTicket.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
