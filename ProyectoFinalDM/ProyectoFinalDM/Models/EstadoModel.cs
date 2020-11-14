using ProyectoFinalDM.INotifyProperty;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalDM.Models
{
   public  class EstadoModel:Notificaciones

    {
       
        private string nombreEstado;

        public string NombreEstado
        {
            get { return nombreEstado; }
            set { nombreEstado = value; this.OnPropertyChanged(); }
        }

        public override bool Equals(object obj)
        {
            return obj is EstadoModel model &&
                   IsBusy == model.IsBusy &&
                   nombreEstado == model.nombreEstado &&
                   NombreEstado == model.NombreEstado;
        }

        public override int GetHashCode()
        {
            int hashCode = 1681433788;
            hashCode = hashCode * -1521134295 + IsBusy.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nombreEstado);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NombreEstado);
            return hashCode;
        }

        public override string ToString()
        {
            return this.nombreEstado.ToString() ;
        }
    }
}
