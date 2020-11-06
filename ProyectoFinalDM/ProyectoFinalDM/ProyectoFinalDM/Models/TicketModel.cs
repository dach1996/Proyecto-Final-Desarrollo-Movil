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

        private string codUsuario;

        public string CodUsuario
        {
            get { return codUsuario; }
            set { codUsuario = value; this.OnPropertyChanged(); }
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

    }
}
