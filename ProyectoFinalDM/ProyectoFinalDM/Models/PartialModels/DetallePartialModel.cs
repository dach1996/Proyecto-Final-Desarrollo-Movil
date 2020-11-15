using Newtonsoft.Json;
using ProyectoFinalDM.INotifyProperty;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalDM.Models
{
    public class DetallePartialModel:Notificaciones
    {
        private int codDetalle ;

        [JsonProperty(PropertyName = "cod_detalle")]
        public int CodDetalle
        {
            get { return codDetalle; }
            set { codDetalle = value; this.OnPropertyChanged(); }
        }

        private string textoDetalle;

        [JsonProperty(PropertyName = "texto_detalle")]
        public string TextoDetalle
        {
            get { return textoDetalle; }
            set { textoDetalle = value; this.OnPropertyChanged(); }
        }


        private DateTime fechaDetalle;

        [JsonProperty(PropertyName = "fecha_detalle")]
        public DateTime FechaDetalle
        {
            get { return fechaDetalle; }
            set { fechaDetalle = value; this.OnPropertyChanged(); }
        }

        private int codUsuarui;

        [JsonProperty(PropertyName = "cod_usuario")]
        public int CodUsuario
        {
            get { return codUsuarui; }
            set { codUsuarui = value; this.OnPropertyChanged(); }
        }


        public override string ToString()
        {
            return base.ToString();
        }


        public override bool Equals(object obj)
        {
            return obj is DetallePartialModel model &&
                   IsBusy == model.IsBusy &&
                   codDetalle == model.codDetalle &&
                   CodDetalle == model.CodDetalle &&
                   textoDetalle == model.textoDetalle &&
                   TextoDetalle == model.TextoDetalle &&
                   fechaDetalle == model.fechaDetalle &&
                   FechaDetalle == model.FechaDetalle &&
                   codUsuarui == model.codUsuarui &&
                   CodUsuario == model.CodUsuario;
        }

        public override int GetHashCode()
        {
            int hashCode = 1708532706;
            hashCode = hashCode * -1521134295 + IsBusy.GetHashCode();
            hashCode = hashCode * -1521134295 + codDetalle.GetHashCode();
            hashCode = hashCode * -1521134295 + CodDetalle.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(textoDetalle);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TextoDetalle);
            hashCode = hashCode * -1521134295 + fechaDetalle.GetHashCode();
            hashCode = hashCode * -1521134295 + FechaDetalle.GetHashCode();
            hashCode = hashCode * -1521134295 + codUsuarui.GetHashCode();
            hashCode = hashCode * -1521134295 + CodUsuario.GetHashCode();
            return hashCode;
        }
    }
}
