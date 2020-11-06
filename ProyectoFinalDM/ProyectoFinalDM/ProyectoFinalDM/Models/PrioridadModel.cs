using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalDM.Models
{
    public class PrioridadModel
    {
        private int codPrioridad;

        public int CodPrioridad
        {
            get { return codPrioridad; }
            set { codPrioridad = value; }
        }

        private string nombrePrioridad;

        public string NombrePrioridad
        {
            get { return nombrePrioridad; }
            set { nombrePrioridad = value; }
        }

        public override bool Equals(object obj)
        {
            return obj is PrioridadModel model &&
                   codPrioridad == model.codPrioridad &&
                   CodPrioridad == model.CodPrioridad &&
                   nombrePrioridad == model.nombrePrioridad &&
                   NombrePrioridad == model.NombrePrioridad;
        }

        public override int GetHashCode()
        {
            int hashCode = 163619830;
            hashCode = hashCode * -1521134295 + codPrioridad.GetHashCode();
            hashCode = hashCode * -1521134295 + CodPrioridad.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nombrePrioridad);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NombrePrioridad);
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
