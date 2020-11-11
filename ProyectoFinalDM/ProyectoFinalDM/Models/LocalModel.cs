using ProyectoFinalDM.INotifyProperty;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalDM.Models
{
   public class LocalModel : Notificaciones
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

        public override bool Equals(object obj)
        {
            return obj is LocalModel model &&
                   codLocal == model.codLocal &&
                   CodLocal == model.CodLocal &&
                   nombreLocal == model.nombreLocal &&
                   NombreLocal == model.NombreLocal;
        }

        public override int GetHashCode()
        {
            int hashCode = 209166502;
            hashCode = hashCode * -1521134295 + codLocal.GetHashCode();
            hashCode = hashCode * -1521134295 + CodLocal.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nombreLocal);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NombreLocal);
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
