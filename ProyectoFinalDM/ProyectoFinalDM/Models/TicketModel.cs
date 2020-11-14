using Newtonsoft.Json;
using ProyectoFinalDM.INotifyProperty;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalDM.Models
{
    public class TicketModel : Notificaciones
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

    
        private UsuarioModel usuario;


        public UsuarioModel Usuario
        {
            get { return usuario; }
            set { usuario = value; this.OnPropertyChanged(); }
        }


        private ClienteModel cliente;

        public ClienteModel Cliente
        {
            get { return cliente; }
            set
            {
                cliente = value; this.OnPropertyChanged();
            }
        }

        private CategoriaModel categoria;

        public CategoriaModel Categoria
        {
            get { return categoria; }
            set { categoria = value; this.OnPropertyChanged(); }
        }

        private string prioridadTicket;


        [JsonProperty(PropertyName = "estado_ticket")]
        public string PrioridadTicket
        {
            get { return prioridadTicket; }
            set { prioridadTicket = value; this.OnPropertyChanged(); }
        }
        private LocalModel local;

        public LocalModel Local
        {
            get { return local; }
            set { local = value; this.OnPropertyChanged(); }
        }
        public override string ToString()
        {
            return base.ToString();
        }



        public override bool Equals(object obj)
        {
            return obj is TicketModel model &&
                   IsBusy == model.IsBusy &&
                   codTicket == model.codTicket &&
                   CodTicket == model.CodTicket &&
                   tituloTicket == model.tituloTicket &&
                   TituloTicket == model.TituloTicket &&
                   fechaTicket == model.fechaTicket &&
                   FechaTicket == model.FechaTicket &&
                   fechaFinTicket == model.fechaFinTicket &&
                   FechaFinTicket == model.FechaFinTicket &&
                   estado == model.estado &&
                   Estado == model.Estado &&
                   EqualityComparer<UsuarioModel>.Default.Equals(usuario, model.usuario) &&
                   EqualityComparer<UsuarioModel>.Default.Equals(Usuario, model.Usuario) &&
                   EqualityComparer<ClienteModel>.Default.Equals(cliente, model.cliente) &&
                   EqualityComparer<ClienteModel>.Default.Equals(Cliente, model.Cliente) &&
                   EqualityComparer<CategoriaModel>.Default.Equals(categoria, model.categoria) &&
                   EqualityComparer<CategoriaModel>.Default.Equals(Categoria, model.Categoria) &&
                   prioridadTicket == model.prioridadTicket &&
                   PrioridadTicket == model.PrioridadTicket &&
                   EqualityComparer<LocalModel>.Default.Equals(local, model.local) &&
                   EqualityComparer<LocalModel>.Default.Equals(Local, model.Local);
        }

        public override int GetHashCode()
        {
            int hashCode = -227968216;
            hashCode = hashCode * -1521134295 + IsBusy.GetHashCode();
            hashCode = hashCode * -1521134295 + codTicket.GetHashCode();
            hashCode = hashCode * -1521134295 + CodTicket.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(tituloTicket);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TituloTicket);
            hashCode = hashCode * -1521134295 + fechaTicket.GetHashCode();
            hashCode = hashCode * -1521134295 + FechaTicket.GetHashCode();
            hashCode = hashCode * -1521134295 + fechaFinTicket.GetHashCode();
            hashCode = hashCode * -1521134295 + FechaFinTicket.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(estado);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Estado);
            hashCode = hashCode * -1521134295 + EqualityComparer<UsuarioModel>.Default.GetHashCode(usuario);
            hashCode = hashCode * -1521134295 + EqualityComparer<UsuarioModel>.Default.GetHashCode(Usuario);
            hashCode = hashCode * -1521134295 + EqualityComparer<ClienteModel>.Default.GetHashCode(cliente);
            hashCode = hashCode * -1521134295 + EqualityComparer<ClienteModel>.Default.GetHashCode(Cliente);
            hashCode = hashCode * -1521134295 + EqualityComparer<CategoriaModel>.Default.GetHashCode(categoria);
            hashCode = hashCode * -1521134295 + EqualityComparer<CategoriaModel>.Default.GetHashCode(Categoria);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(prioridadTicket);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PrioridadTicket);
            hashCode = hashCode * -1521134295 + EqualityComparer<LocalModel>.Default.GetHashCode(local);
            hashCode = hashCode * -1521134295 + EqualityComparer<LocalModel>.Default.GetHashCode(Local);
            return hashCode;
        }
    }



}
