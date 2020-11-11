using ProyectoFinalDM.INotifyProperty;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalDM.Models
{
    public class TicketModel : Notificaciones
    {
        private bool isBisy = false;

        public bool isBusy
        {
            get { return isBisy; }
            set { isBisy = value; this.OnPropertyChanged(); }
        }


        private int codTicket;

        public int CodTicket
        {
            get { return codTicket; }
            set { codTicket = value; this.OnPropertyChanged(); }
        }

        private string localTicket;

        public string LocalTicket
        {
            get { return localTicket; }
            set { localTicket = value; this.OnPropertyChanged(); }
        }

        private string tituloTicket;

        public string TituloTicket
        {
            get { return tituloTicket; }
            set { tituloTicket = value; this.OnPropertyChanged(); }
        }

        private DateTime fechaTicket;

        public DateTime FechaTicket
        {
            get { return fechaTicket; }
            set { fechaTicket = value; this.OnPropertyChanged(); }
        }

        private DateTime fechaFinTicket;

        public DateTime FechaFinTicket
        {
            get { return fechaFinTicket; }
            set { fechaFinTicket = value; this.OnPropertyChanged(); }
        }

        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; this.OnPropertyChanged(); }
        }


        private UsuarioModel usuario;

        public UsuarioModel Usuario
        {
            get { return usuario; }
            set { usuario = value; }
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
            set { categoria = value; }
        }

        private PrioridadModel prioridad;

        public PrioridadModel Prioridad 
        {
            get { return prioridad; }
            set { prioridad = value; }
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is TicketModel model &&
                   isBisy == model.isBisy &&
                   isBusy == model.isBusy &&
                   codTicket == model.codTicket &&
                   CodTicket == model.CodTicket &&
                   localTicket == model.localTicket &&
                   LocalTicket == model.LocalTicket &&
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
                   EqualityComparer<PrioridadModel>.Default.Equals(prioridad, model.prioridad) &&
                   EqualityComparer<PrioridadModel>.Default.Equals(Prioridad, model.Prioridad);
        }

        public override int GetHashCode()
        {
            int hashCode = -292620316;
            hashCode = hashCode * -1521134295 + isBisy.GetHashCode();
            hashCode = hashCode * -1521134295 + isBusy.GetHashCode();
            hashCode = hashCode * -1521134295 + codTicket.GetHashCode();
            hashCode = hashCode * -1521134295 + CodTicket.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(localTicket);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LocalTicket);
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
            hashCode = hashCode * -1521134295 + EqualityComparer<PrioridadModel>.Default.GetHashCode(prioridad);
            hashCode = hashCode * -1521134295 + EqualityComparer<PrioridadModel>.Default.GetHashCode(Prioridad);
            return hashCode;
        }
    }
}
