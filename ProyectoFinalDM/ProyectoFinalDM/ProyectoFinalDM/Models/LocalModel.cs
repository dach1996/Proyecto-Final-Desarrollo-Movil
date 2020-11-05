using ProyectoFinalDM.INotifyProperty;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalDM.Models
{
    class LocalModel : Notificaciones
    {
        private int codLocal;

        public int CodLocal
        {
            get { return codLocal; }
            set { codLocal = value; this.OnPropertyChanged(); }
        }

        private string nombreLocal;

        public string NombreLocal
        {
            get { return nombreLocal; }
            set { nombreLocal = value; this.OnPropertyChanged(); }
        }


    }
}
