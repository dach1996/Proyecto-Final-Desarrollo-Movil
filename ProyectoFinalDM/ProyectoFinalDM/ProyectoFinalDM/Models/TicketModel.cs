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


        private string codTicket;

        public string CodTicket
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

        private string prioridadTicket;

        public string PrioridadTicket
        {
            get { return prioridadTicket; }
            set { prioridadTicket = value; this.OnPropertyChanged(); }
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

        private string mycategoriaTicketVar;

        public string CategoriaTicket
        {
            get { return mycategoriaTicketVar; }
            set { mycategoriaTicketVar = value; this.OnPropertyChanged(); }
        }

        private int codCliente;

        public int CodCliente
        {
            get { return codCliente; }
            set { codCliente = value; this.OnPropertyChanged(); }
        }

        private string codUsuario;

        public string CodUsuario
        {
            get { return codUsuario; }
            set { codUsuario = value; this.OnPropertyChanged(); }
        }

        private ClienteModel clienteSelected;

        public ClienteModel ClienteSelected
        {
            get { return clienteSelected; }
            set
            {
                clienteSelected = value; this.OnPropertyChanged();
            }
        }
    }
}
