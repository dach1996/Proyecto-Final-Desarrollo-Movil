using ProyectoFinalDM.INotifyProperty;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalDM.Models
{
    public class DetalleModel:Notificaciones
    {
        private int codDetalle ;

        public int CodDetalle
        {
            get { return codDetalle; }
            set { codDetalle = value; this.OnPropertyChanged(); }
        }

        private string textoDetalle;

        public string TextoDetalle
        {
            get { return textoDetalle; }
            set { textoDetalle = value; this.OnPropertyChanged(); }
        }


        private DateTime fechaDetalle;

        public DateTime FechaDetalle
        {
            get { return fechaDetalle; }
            set { fechaDetalle = value; this.OnPropertyChanged(); }
        }

        private TicketModel ticket;

        public TicketModel Ticket
        {
            get { return ticket; }
            set { ticket = value; this.OnPropertyChanged(); }
        }

        private UsuarioModel usuario;

        public UsuarioModel Usuario
        {
            get { return usuario; }
            set { usuario = value; this.OnPropertyChanged(); }
        }


        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is DetalleModel model &&
                   codDetalle == model.codDetalle &&
                   CodDetalle == model.CodDetalle &&
                   textoDetalle == model.textoDetalle &&
                   TextoDetalle == model.TextoDetalle &&
                   fechaDetalle == model.fechaDetalle &&
                   FechaDetalle == model.FechaDetalle &&
                   EqualityComparer<TicketModel>.Default.Equals(ticket, model.ticket) &&
                   EqualityComparer<TicketModel>.Default.Equals(Ticket, model.Ticket) &&
                   EqualityComparer<UsuarioModel>.Default.Equals(usuario, model.usuario) &&
                   EqualityComparer<UsuarioModel>.Default.Equals(Usuario, model.Usuario);
        }

        public override int GetHashCode()
        {
            int hashCode = -2022348130;
            hashCode = hashCode * -1521134295 + codDetalle.GetHashCode();
            hashCode = hashCode * -1521134295 + CodDetalle.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(textoDetalle);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TextoDetalle);
            hashCode = hashCode * -1521134295 + fechaDetalle.GetHashCode();
            hashCode = hashCode * -1521134295 + FechaDetalle.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<TicketModel>.Default.GetHashCode(ticket);
            hashCode = hashCode * -1521134295 + EqualityComparer<TicketModel>.Default.GetHashCode(Ticket);
            hashCode = hashCode * -1521134295 + EqualityComparer<UsuarioModel>.Default.GetHashCode(usuario);
            hashCode = hashCode * -1521134295 + EqualityComparer<UsuarioModel>.Default.GetHashCode(Usuario);
            return hashCode;
        }
    }
}
