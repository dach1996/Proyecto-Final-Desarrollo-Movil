using Newtonsoft.Json;
using ProyectoFinalDM.INotifyProperty;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalDM.Models.PartialModels
{
    public class TicketPartialModel:Notificaciones
    {
        private int codTicket;

        [JsonProperty(PropertyName = "cod_ticket")]
        public int CodTicket
        {
            get { return codTicket; }
            set { codTicket = value; this.OnPropertyChanged(); }
        }

        private string tituloTicket;

        [JsonProperty(PropertyName = "titulo_ticket")]
        public string TituloTicket
        {
            get { return tituloTicket; }
            set { tituloTicket = value; this.OnPropertyChanged(); }
        }

        private DateTime? fechaTicket;

        [JsonProperty(PropertyName = "fecha_inicio_ticket")]
        public DateTime? FechaTicket
        {
            get { return fechaTicket; }
            set { fechaTicket = value; this.OnPropertyChanged(); }
        }

        private string nombreCliente;

        [JsonProperty(PropertyName = "nomb_cliente")]
        public string NombreCliente
        {
            get { return nombreCliente; }
            set { nombreCliente = value; this.OnPropertyChanged(); }
        }

        private string nombreLocal;
        [JsonProperty(PropertyName = "nomb_local")]
        public string NombreLocal
        {
            get { return nombreLocal; }
            set { nombreLocal = value; this.OnPropertyChanged(); }
        }

        private string nombreCategoria;
        [JsonProperty(PropertyName = "nomb_categoria")]
        public string NombreCategoria
        {
            get { return nombreCategoria; }
            set { nombreCategoria = value; this.OnPropertyChanged(); }
        }

        private string estado;
        [JsonProperty(PropertyName = "estado_ticket")]
        public string Estado
        {
            get { return estado; }
            set { estado = value; this.OnPropertyChanged(); }
        }
    }
}
