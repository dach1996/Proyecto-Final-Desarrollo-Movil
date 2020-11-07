using System;
using System.Collections.Generic;
using System.Text;
using ProyectoFinalDM.Models;
using System.Collections.ObjectModel;

namespace ProyectoFinalDM.ViewModel
{
   public class ClienteViewModel
    {
        private ObservableCollection<ClienteModel> clientes;

        public ClienteViewModel()
        {
            this.clientes = new ObservableCollection<ClienteModel>();
           /* clientes.Add(new ClienteModel
            {
                codCliente = 0,
                nombreCliente = "Crocs",
                imagenCliente = "https://es.shoppertrak.com/wp-content/uploads//2018/05/crocs-logo.jpg",
                userCliente = "",
                passwordCliente = ""
            });

            clientes.Add(new ClienteModel
            {
                codCliente = 1,
                nombreCliente = "Taty",
                imagenCliente = "https://www.taty.com.ec/wp-content/uploads/2020/05/taty-boutique-imagen-redes-sociales.png",
                userCliente = "",
                passwordCliente = ""
            });
            clientes.Add(new ClienteModel
            {
                codCliente = 2,
                nombreCliente = "Supermaxi",
                imagenCliente = "https://www.corporacionfavorita.com/wp-content/uploads/2020/03/cf-logos-supermaxi.jpg",
                userCliente = "",
                passwordCliente = ""
            });*/
        }

        public ObservableCollection<ClienteModel> Clientes { get => clientes; set => clientes = value; }
    }
}
