using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalDM.Models
{
    public class PrioridadModel
    {

        private string nombrePrioridad;

        public string NombrePrioridad
        {
            get { return nombrePrioridad; }
            set { nombrePrioridad = value; }
        }

        public override bool Equals(object obj)
        {
            return obj is PrioridadModel model &&
                   nombrePrioridad == model.nombrePrioridad &&
                   NombrePrioridad == model.NombrePrioridad;
        }

        public override int GetHashCode()
        {
            int hashCode = -1405374568;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nombrePrioridad);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NombrePrioridad);
            return hashCode;
        }

        public override string ToString()
        {
            return nombrePrioridad.ToString();
        }
    }
}
