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

        private int codLocal;

        [JsonProperty(PropertyName = "cod_local")]
        public int CodLocal
        {
            get { return codLocal; }
            set { codLocal = value; this.OnPropertyChanged(); }
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


        private DateTime? fechaFinTicket;

        [JsonProperty(PropertyName = "fecha_fin_ticket")]
        public DateTime? FechaFinTicket
        {
            get { return fechaFinTicket; }
            set { fechaFinTicket = value; this.OnPropertyChanged(); }
        }


        private string estado;
        [JsonProperty(PropertyName = "estado_ticket")]
        public string Estado
        {
            get { return estado; }
            set { estado = value; this.OnPropertyChanged(); }
        }


        private string prioridadTicket;
        [JsonProperty(PropertyName = "prioridad_ticket")]
        public string PrioridadTicket
        {
            get { return prioridadTicket; }
            set { prioridadTicket = value; this.OnPropertyChanged(); }
        }

        private int codUsuario;

        [JsonProperty(PropertyName = "cod_usuario")]
        public int CodUsuario
        {
            get { return codUsuario; }
            set { codUsuario = value; this.OnPropertyChanged(); }
        }

        private int codCliente;

        [JsonProperty(PropertyName = "cod_cliente")]
        public int CodCliente
        {
            get { return codCliente; }
            set { codCliente = value; this.OnPropertyChanged(); }
        }

        private int codCategoria;

        [JsonProperty(PropertyName = "cod_categoria")]
        public int CodCategoria
        {
            get { return codCategoria; }
            set { codCategoria = value; this.OnPropertyChanged(); }
        }

    }
}
