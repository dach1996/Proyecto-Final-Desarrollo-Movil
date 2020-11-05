using ProyectoFinalDM.INotifyProperty;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalDM.Models
{
    class Estados:Notificaciones

    {
        private int codEstado;

        public int CodEstado
        {
            get { return codEstado; }
            set { codEstado = value; this.OnPropertyChanged(); }
        }
        private string nombreEstado;

        public string NombreEstado
        {
            get { return nombreEstado; }
            set { nombreEstado = value; this.OnPropertyChanged(); }
        }


    }
}
