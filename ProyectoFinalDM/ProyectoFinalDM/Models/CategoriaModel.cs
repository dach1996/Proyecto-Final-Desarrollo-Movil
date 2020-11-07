using ProyectoFinalDM.INotifyProperty;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalDM.Models
{
   public  class CategoriaModel:Notificaciones
    {
        private int codCategoria;

        public int CodCategoria
        {
            get { return codCategoria; }
            set { codCategoria = value; this.OnPropertyChanged(); }
        }

        private string nombreCategoria;

        public string NombreCategoria
        {
            get { return nombreCategoria; }
            set { nombreCategoria = value; this.OnPropertyChanged(); }
        }

        public override bool Equals(object obj)
        {
            return obj is CategoriaModel model &&
                   codCategoria == model.codCategoria &&
                   CodCategoria == model.CodCategoria &&
                   nombreCategoria == model.nombreCategoria &&
                   NombreCategoria == model.NombreCategoria;
        }

        public override int GetHashCode()
        {
            int hashCode = -329902330;
            hashCode = hashCode * -1521134295 + codCategoria.GetHashCode();
            hashCode = hashCode * -1521134295 + CodCategoria.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nombreCategoria);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NombreCategoria);
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
