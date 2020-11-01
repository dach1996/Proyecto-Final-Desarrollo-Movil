using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalDM.Models
{
    public class Cliente

    {
        private int codCliente1;
        private string nombreCliente1;
        private string imagenCliente1;
        private string userCliente1;
        private string passwordCliente1;

        public int codCliente { get => codCliente1; set => codCliente1 = value; }
        public string nombreCliente { get => nombreCliente1; set => nombreCliente1 = value; }
        public string imagenCliente { get => imagenCliente1; set => imagenCliente1 = value; }
        public string userCliente { get => userCliente1; set => userCliente1 = value; }
        public string passwordCliente { get => passwordCliente1; set => passwordCliente1 = value; }
    }
}
