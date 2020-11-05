using ProyectoFinalDM.INotifyProperty;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalDM.Models
{
    public class ClienteModel : Notificaciones

    {
        private int codCliente;

        public int CodCliente
        {
            get { return codCliente; }
            set { codCliente = value; this.OnPropertyChanged(); }
        }

        private string nombreCliente;

        public string NombreCliente
        {
            get { return nombreCliente; }
            set { nombreCliente = value; this.OnPropertyChanged(); }
        }

        private string imagenCliente;

        public string ImagenCliente
        {
            get { return imagenCliente; }
            set { imagenCliente = value; this.OnPropertyChanged(); }
        }

        private string userCliente;

        public string UserCliente
        {
            get { return userCliente; }
            set { userCliente = value; this.OnPropertyChanged(); }
        }

        private string passwordCliente;

        public string PasswordCliente
        {
            get { return passwordCliente; }
            set { passwordCliente = value; this.OnPropertyChanged(); }
        }



    }
}
